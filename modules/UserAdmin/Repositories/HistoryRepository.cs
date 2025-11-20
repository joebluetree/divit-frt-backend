using System;
using Common.DTO.UserAdmin;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Lib.Interfaces;
using Database.Models.BaseTables;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore;
using UserAdmin.Interfaces;

namespace UserAdmin.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly AppDbContext context;
    private readonly IAuditLog auditLog;

    public HistoryRepository(AppDbContext _context, IAuditLog _auditLog)
    {
        this.context = _context;
        this.auditLog = _auditLog;
    }
    public async Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data)
    {
        try
        {
            Dictionary<string, object> RetData = new Dictionary<string, object>();

            Page _page = new Page();

            var action = data["action"].ToString();
            if (action == null)
                action = "search";

            var log_table = "";
            var log_table_row_id = 0;
            var log_desc = "";
            var log_type = "";
            var company_id = 0;
            var branch_id = 0;
            var log_from_date = "";
            var log_to_date = "";
            DateTime? from_date = null;
            DateTime? to_date = null;


            if (data.ContainsKey("log_table"))
                log_table = data["log_table"].ToString()!.ToUpper();

            if (data.ContainsKey("log_table_row_id"))
                log_table_row_id = int.Parse(data["log_table_row_id"].ToString()!);

            if (data.ContainsKey("log_desc"))
                log_desc = data["log_desc"].ToString();
                
            if (data.ContainsKey("log_type"))
                log_type = data["log_type"].ToString();

            if (data.ContainsKey("log_from_date"))
                log_from_date = data["log_from_date"].ToString();
            if (data.ContainsKey("log_to_date"))
                log_to_date = data["log_to_date"].ToString();



            if (data.ContainsKey("rec_company_id"))
                company_id = int.Parse(data["rec_company_id"].ToString()!);
            if (company_id == 0)
                throw new Exception("Company Id Not Found");
            if (data.ContainsKey("rec_branch_id"))
                branch_id = int.Parse(data["rec_branch_id"].ToString()!);
            if (branch_id == 0)
                throw new Exception("Branch Id Not Found");
            
            if (Lib.IsZero(log_table_row_id) && Lib.IsBlank(log_type))/// for new record history return blank record
            {
                RetData.Add("records", new List<mast_history_dto>());
                RetData.Add("page", _page);
                return RetData;
            }
            _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
            _page.pages = int.Parse(data["pages"].ToString()!);
            _page.rows = int.Parse(data["rows"].ToString()!);
            _page.pageSize = int.Parse(data["pageSize"].ToString()!);

            IQueryable<mast_history> query = context.mast_history;

            query = query.Where(i => i.rec_company_id == company_id);

            if (!Lib.IsBlank(log_from_date))
            {
                from_date = CommonLib.ParseDateTimestamp(log_from_date!);
                query = query.Where(w => w.log_date >= from_date);
            }

            if (!Lib.IsBlank(log_to_date))
            {
                to_date = CommonLib.ParseDateTimestamp(log_to_date!);
                query = query.Where(w => w.log_date <= to_date);
            }

            if (!Lib.IsBlank(log_table))
                query = query.Where(w => w.log_table!.ToUpper().Contains(log_table!));

            if (!Lib.IsBlank(log_desc))
                query = query.Where(w => w.log_desc!.ToUpper().Contains(log_desc!));

            if (!Lib.IsZero(log_table_row_id))
                query = query.Where(w => w.log_table_row_id == log_table_row_id);

            if (action == "SEARCH")
            {
                _page.rows = query.Count();
                _page.pages = Lib.getTotalPages(_page.rows, _page.pageSize);
                _page.currentPageNo = 1;
            }
            else
            {
                _page.currentPageNo = Lib.FindPage(action, _page.currentPageNo, _page.pages);
            }

            int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

            query = query
                .OrderBy(c => c.log_date)
                .Skip(StartRow)
                .Take(_page.pageSize);

            var Records = await query.Select(e => new mast_history_dto
            {
                log_id = e.log_id,
                log_date = Lib.FormatDate(e.log_date, Lib.outputDateTimeFormat),
                log_user_code = e.log_user_code,
                log_table = e.log_table,
                log_table_row_id = e.log_table_row_id,
                log_column = e.log_column,
                log_desc = e.log_desc,
                log_refno = e.log_refno,
                log_old_value = e.log_old_value,
                log_new_value = e.log_new_value,
                log_status = e.log_status,

                rec_version = e.rec_version,
                rec_order = e.rec_order,
                rec_company_id = e.rec_company_id,
                rec_branch_id = e.rec_branch_id,
            }).ToListAsync();

            RetData.Add("records", Records);
            RetData.Add("page", _page);

            return RetData;
        }
        catch (Exception Ex)
        {
            throw new Exception(Ex.Message.ToString());
        }
    }
    public async Task<mast_history_dto?> GetRecordAsync(int id)
    {
        try
        {
            IQueryable<mast_history> query = context.mast_history;
            query = query.Where(f => f.log_id == id);

            var Record = await query.Select(e => new mast_history_dto
            {
                log_id = e.log_id,
                log_date = Lib.FormatDate(e.log_date, Lib.outputDateFormat),
                log_user_code = e.log_user_code,
                log_table = e.log_table,
                log_table_row_id = e.log_table_row_id,
                log_column = e.log_column,
                log_desc = e.log_desc,
                log_refno = e.log_refno,
                log_old_value = e.log_old_value,
                log_new_value = e.log_new_value,
                log_status = e.log_status,

                rec_version = e.rec_version,
                rec_order = e.rec_order,
                rec_company_id = e.rec_company_id,
                rec_branch_id = e.rec_branch_id,
            }).FirstOrDefaultAsync();

            if (Record == null)
                throw new Exception("No Data Found");

            return Record;
        }
        catch (Exception Ex)
        {
            throw new Exception(Ex.Message.ToString());
        }
    }

}

