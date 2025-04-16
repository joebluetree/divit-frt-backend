using Database;
using Database.Lib;
using Common.DTO.Masters;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;

using Database.Models.Cargo;
using System.Diagnostics.Eventing.Reader;
using CommonShipment.Interfaces;
using Database.Models.CommonShipment;
using Common.DTO.CommonShipment;

//Name : Sourav V
//Created Date : 10/04/2025
//Remark : this file defines functions like Save, Delete, getList and getRecords which save/retrieve data
//version v1-10-04-2025: added full repository

namespace CommonShipment.Repositories
{
    public class MemoRepository : IMemoRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;

        public MemoRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var company_id = 0;
                var branch_id = 0;

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

                IQueryable<cargo_memo> query = context.cargo_memo;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);

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
                    .OrderBy(c => c.memo_date)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_memo_dto
                {
                    memo_id = e.memo_id,
                    memo_parent_id = e.memo_parent_id,
                    memo_parent_type = e.memo_parent_type,
                    memo_remarks_id = e.memo_remarks_id,
                    memo_remarks_name = e.remarks!.param_name,
                    memo_date = Lib.FormatDate(e.memo_date, Lib.outputDateTimeFormat),

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
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
        public async Task<cargo_memo_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_memo> query = context.cargo_memo;
                //.Include(e => e.customer);

                query = query.Where(f => f.memo_id == id);

                var Record = await query.Select(e => new cargo_memo_dto
                {
                    memo_id = e.memo_id,
                    memo_parent_id = e.memo_parent_id,
                    memo_parent_type = e.memo_parent_type,
                    memo_remarks_id = e.memo_remarks_id,
                    memo_remarks_code = e.remarks!.param_code,
                    memo_remarks_name = e.memo_remarks_name,
                    memo_date = Lib.FormatDate(e.memo_date, Lib.outputDateTimeFormat),

                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
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
        public async Task<List<cargo_memo_dto>> GetMemoRemarksAsync(int id,string ParentType)
        {
            try
            {
                var query = from e in context.cargo_memo
                            .Where(e => e.memo_parent_id == id && e.memo_parent_type == ParentType)
                            .OrderBy(o => o.memo_id)
                            select (new cargo_memo_dto
                            {
                                memo_id = e.memo_id,
                                memo_parent_id = e.memo_parent_id,
                                memo_parent_type = e.memo_parent_type,
                                memo_date = Lib.FormatDate(e.memo_date, Lib.outputDateTimeFormat),
                                memo_remarks_id = e.memo_remarks_id,
                                memo_remarks_code = e.remarks!.param_code,
                                memo_remarks_name = e.memo_remarks_name,
                                rec_created_by = e.rec_created_by,
                                rec_branch_id = e.rec_branch_id,
                                rec_company_id = e.rec_company_id,
                            });
                var records = await query.ToListAsync();
                return records;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
          private Boolean AllValid(string mode, cargo_memo_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";
            if (Lib.IsBlank(record_dto.memo_remarks_name))
                str += "Remarks Cannot Be Blank!";
            
            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }

        public async Task<cargo_memo_dto> SaveAsync(int id, string mode, cargo_memo_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_memo_dto _Record = await SaveParentAsync(id, mode, record_dto);
                context.Database.CommitTransaction();
                return _Record;
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

        public async Task<cargo_memo_dto> SaveParentAsync(int id, string mode, cargo_memo_dto record_dto)
        {
            cargo_memo? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {

                    Record = new cargo_memo();
                
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";

                    Record.memo_parent_type = record_dto.memo_parent_type;
                    Record.memo_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.cargo_memo
                        .Include(c => c.remarks)
                        .Where(f => f.memo_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }

                if (mode == "edit")
                    await logHistory(Record,mode, record_dto);

                Record.memo_parent_id = record_dto.memo_parent_id;
                Record.memo_remarks_id = record_dto.memo_remarks_id;
                Record.memo_remarks_name = record_dto.memo_remarks_name;
                // Record.memo_date = DbLib.GetDateTime();


                if (mode == "add")
                    await context.cargo_memo.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.memo_id = Record.memo_id;

                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (mode == "edit")
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }
                record_dto.rec_version = Record.rec_version;


                return record_dto;
            }
            catch (Exception)
            {
                // throw new Exception(Ex.Message.ToString());
                throw;
            }

        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_memo
                    .FirstOrDefaultAsync(f => f.memo_id == id);
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

        public async Task logHistory(cargo_memo old_record,string mode, cargo_memo_dto record_dto)
        {

            var old_record_dto = new cargo_memo_dto
            {
                memo_id = old_record.memo_id,
                memo_parent_id = old_record.memo_parent_id,
                memo_parent_type = old_record.memo_parent_type,
                memo_remarks_name = old_record.memo_remarks_name,
                memo_date = Lib.FormatDate(old_record.memo_date, Lib.outputDateTimeFormat),

            };

            await new LogHistorym<cargo_memo_dto>(context)
                .Table("cargo_memo", log_date)
                .PrimaryKey("memo_parent_id", record_dto.memo_parent_id)
                .RefNo(record_dto.memo_parent_type!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("memo_remarks_name", "Remarks")
                .TrackColumn("memo_date", "Date")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();

        }

    }
}
