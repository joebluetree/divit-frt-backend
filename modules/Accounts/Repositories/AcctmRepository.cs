using Database;
using Database.Lib;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;

using Accounts.Interfaces;
using Database.Models.Accounts;
using Database.Models.BaseTables;
using Common.DTO.Accounts;
using Common.Lib.Accounts;

namespace Accounts.Repositories
{
    public class AcctmRepository : IAcctmRepository
    {
        private readonly AppDbContext context;

        public AcctmRepository(AppDbContext _context)
        {
            context = _context;
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
                    
                var acc_name = data["acc_name"].ToString();
                var acc_row_type = data["acc_row_type"].ToString();

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<acc_acctm> query = context.acc_acctm
                    .Include(m => m.acc_groupm)
                    .Include(m => m.acctm);

                query = query.Where(w => w.acc_row_type == acc_row_type);

                if (acc_name != "" && acc_name != null)
                    query = query.Where(w => w.acc_name!.Contains(acc_name));


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
                    .OrderBy(c => c.acc_name)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new acc_acctm_dto
                {
                    acc_id = e.acc_id,
                    acc_code = e.acc_code,
                    acc_short_name = e.acc_short_name,
                    acc_name = e.acc_name,
                    acc_type = e.acc_type,
                    acc_grp_name = e.acc_groupm!.grp_name,
                    acc_maincode = e.acc_id == e.acc_maincode_id ? "" : e.acctm!.acc_code,
                    acc_maincode_name = e.acc_id == e.acc_maincode_id ? "" : e.acctm!.acc_name,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = e.rec_created_date.ToString(Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = e.rec_edited_date.HasValue ? e.rec_edited_date.Value.ToString(Lib.outputDateTimeFormat) : null,
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
        public async Task<acc_acctm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<acc_acctm> query = context.acc_acctm
                    .Include(m => m.acctm)
                    .Include(m => m.acc_groupm);

                query = query.Where(f => f.acc_id == id);

                var Record = await query.Select(e => new acc_acctm_dto
                {
                    acc_id = e.acc_id,
                    acc_code = e.acc_code,
                    acc_short_name = e.acc_short_name,
                    acc_name = e.acc_name,
                    acc_type = e.acc_type,
                    acc_grp_id = e.acc_grp_id,
                    acc_grp_name = e.acc_groupm!.grp_name,
                    acc_row_type = e.acc_row_type,
                    rec_version = e.rec_version,
                    acc_maincode_id = e.acc_id == e.acc_maincode_id ? null : e.acc_maincode_id,
                    acc_maincode_name = e.acc_id == e.acc_maincode_id ? null : e.acctm!.acc_name,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = e.rec_created_date.ToString(Lib.outputDateFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = e.rec_edited_date.HasValue ? e.rec_edited_date.Value.ToString(Lib.outputDateFormat) : null,
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

        public async Task<acc_acctm_dto> SaveAsync(int id, string mode, acc_acctm_dto Record)
        {
            try
            {
                context.Database.BeginTransaction();
                acc_acctm_dto _Record = await AcctmLib.SaveAsync(this.context, mode, Record);
                context.Database.CommitTransaction();
                return _Record;
            }
            catch (DbUpdateConcurrencyException)
            {
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
                var _Record = await context.acc_acctm
                    .Where(f => f.acc_id == id)
                    .FirstOrDefaultAsync();
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    context.Remove(_Record);
                    context.SaveChanges();
                    RetData.Add("status", true);
                    RetData.Add("message", "");
                }
                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

    }
}
