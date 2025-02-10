using System;
using Common.DTO.UserAdmin;
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
            var company_id = 0;
            var branch_id = 0;
            var log_from_date = "";
            var log_to_date = "";
            DateTime? from_date = null;
            DateTime? to_date = null;


            if (data.ContainsKey("log_table"))
                log_table = data["log_table"].ToString();
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

            _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
            _page.pages = int.Parse(data["pages"].ToString()!);
            _page.rows = int.Parse(data["rows"].ToString()!);
            _page.pageSize = int.Parse(data["pageSize"].ToString()!);

            IQueryable<mast_history> query = context.mast_history;

            query = query.Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id);

            if (!Lib.IsBlank(log_from_date))
            {
                from_date = Lib.ParseDate(log_from_date!);
                query = query.Where(w => w.log_date >= from_date);
            }
            if (!Lib.IsBlank(log_to_date))
            {
                to_date = Lib.ParseDate(log_to_date!);
                query = query.Where(w => w.log_date <= to_date);
            }
            if (!Lib.IsBlank(log_table))
                query = query.Where(w => w.log_table!.Contains(log_table!));



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

            public async Task<mast_history_dto> SaveAsync(int id, string mode, mast_history_dto record_dto)
        {
            try
            {
                context.Database.BeginTransaction();
                // record_dto = await SaveParentAsync(id, mode, record_dto);
                context.Database.CommitTransaction();
                return record_dto;
            }
            catch (DbUpdateConcurrencyException)
            {
                context.Database.RollbackTransaction();
                throw new Exception("Kindly reload the record, Another User May have modified the same record");
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                // var _Record = await context.mast_mail_serverm
                //     .Where(f => f.mail_id == id)
                //     .FirstOrDefaultAsync();

                // if (_Record == null)
                // {
                //     RetData.Add("status", false);
                //     RetData.Add("message", "No Record Found");
                // }
                // else
                // {
                //     context.Remove(_Record);
                //     context.SaveChanges();
                //     RetData.Add("status", true);
                //     RetData.Add("message", "");
                // }
                return RetData;
            }
            catch (Exception)
            {
                throw;
            }
        }

}
