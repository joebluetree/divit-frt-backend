using Database;
using Database.Lib;
using Common.DTO.Masters;
using Masters.Interfaces;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;

namespace Masters.Repositories
{
    public class RemarkmRepository : IRemarkmRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        public RemarkmRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var rem_name = "";
                var company_id = 0;

                if (data.ContainsKey("rem_name"))
                    rem_name = data["rem_name"].ToString();

                if (data.ContainsKey("rec_company_id"))
                    company_id = int.Parse(data["rec_company_id"].ToString()!);
                if (company_id == 0)
                    throw new Exception("Company Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_remarkm> query = context.mast_remarkm;

                query = query.Where(i => i.rec_company_id == company_id);

                if (!Lib.IsBlank(rem_name))
                    query = query.Where(w => w.rem_name!.Contains(rem_name!));

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
                    .OrderBy(c => c.rem_name)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_remarkm_dto
                {
                    rem_id = e.rem_id,
                    rem_name = e.rem_name,

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
        public async Task<mast_remarkm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<mast_remarkm> query = context.mast_remarkm;


                query = query.Where(f => f.rem_id == id);

                var Record = await query.Select(e => new mast_remarkm_dto
                {
                    rem_id = e.rem_id,
                    rem_name = e.rem_name,

                    rec_version = e.rec_version,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Qtn Found");
                Record.rem_remarks = await GetDetailsAsync(Record.rem_id);
                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<mast_remarkd_dto>> GetDetailsAsync(int? id)
        {
            var query = from e in context.mast_remarkd
                        .Where(e => e.remd_remarkm_id == id)
                        .OrderBy(o => o.remd_order)
                        select (new mast_remarkd_dto
                        {
                            remd_id = e.remd_id,
                            remd_remarkm_id = e.remd_remarkm_id,
                            remd_desc1 = e.remd_desc1,
                            remd_order = e.remd_order,

                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        });
            var records = await query.ToListAsync();
            return records;
        }

        public async Task<mast_remarkm_dto> SaveAsync(int id, string mode, mast_remarkm_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                mast_remarkm_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await SaveDetailsAsync(_Record.rem_id, mode, record_dto);
                _Record.rem_remarks = await GetDetailsAsync(_Record.rem_id);
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

        private Boolean AllValid(string mode, mast_remarkm_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";
            string code = "";

            if (Lib.IsBlank(record_dto.rem_name))
                str += "Name Cannot Be Blank!";

            foreach (mast_remarkd_dto rec in record_dto.rem_remarks!)
            {
                if (Lib.IsBlank(rec.remd_desc1))
                    code = "Description Cannot Be Blank!";
            }

            if (record_dto.rem_remarks == null || record_dto.rem_remarks.Count == 0)
            {
                str += "No data found in Remarks Description Details";
            }

            if (code != "")
                str += code;

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<mast_remarkm_dto> SaveParentAsync(int id, string mode, mast_remarkm_dto record_dto)
        {
            mast_remarkm? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    Record = new mast_remarkm();
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.mast_remarkm
                        .Where(f => f.rem_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                if (mode == "edit")
                    await logHistory(Record, record_dto);

                Record.rem_name = record_dto.rem_name;
                if (mode == "add")
                    await context.mast_remarkm.AddAsync(Record);
                context.SaveChanges();
                record_dto.rem_id = Record.rem_id;
                record_dto.rec_version = Record.rec_version;
                // Lib.AssignDates2DTO(id, mode, Record, record_dto);
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.rem_id != 0)
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }

                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "rem_name", "Name Duplication");
                throw;
            }

        }

        public async Task<mast_remarkm_dto> SaveDetailsAsync(int? id, string mode, mast_remarkm_dto record_dto)
        {
            mast_remarkd? record;
            List<mast_remarkd_dto> records_dto;
            List<mast_remarkd> records;
            try
            {
                records_dto = record_dto.rem_remarks!;
                records = await context.mast_remarkd
                    .Where(w => w.remd_remarkm_id == id)
                    .ToListAsync();
                int nextorder = 1;

                if (mode == "edit")
                    await logHistoryDetail(records, record_dto);


                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.remd_id == existing_record.remd_id);
                    if (rec == null)
                        context.mast_remarkd.Remove(existing_record);
                }

                //Add or Edit Records 
                foreach (var rec in records_dto)
                {
                    if (rec.remd_id == 0)
                    {
                        record = new mast_remarkd();
                        record.rec_company_id = record_dto.rec_company_id;
                        record.rec_created_by = record_dto.rec_created_by;
                        record.rec_created_date = DbLib.GetDateTime();
                    }
                    else
                    {
                        record = records.Find(f => f.remd_id == rec.remd_id);
                        if (record == null)
                            throw new Exception("Detail Record Not Found " + rec.remd_id.ToString());
                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }
                    record.remd_remarkm_id = id;
                    record.remd_desc1 = rec.remd_desc1;
                    record.remd_order = nextorder++;
                    if (rec.remd_id == 0)
                        await context.mast_remarkd.AddAsync(record);
                }
                context.SaveChanges();
                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_remarkm
                    .Where(f => f.rem_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    var rem_remarks = context.mast_remarkd
                     .Where(c => c.remd_remarkm_id == id);
                    if (rem_remarks.Any())
                    {
                        context.mast_remarkd.RemoveRange(rem_remarks);
                    }
                    context.Remove(_Record);
                    await context.SaveChangesAsync();

                    context.Database.CommitTransaction();

                    RetData.Add("status", true);
                    RetData.Add("message", "");
                }
                return RetData;
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }

        public async Task logHistory(mast_remarkm old_record, mast_remarkm_dto record_dto)
        {

            var old_record_dto = new mast_remarkm_dto
            {
                rem_id = old_record.rem_id,
                rem_name = old_record.rem_name,

            };

            await new LogHistorym<mast_remarkm_dto>(context)
                .Table("mast_remarkm", log_date)
                .PrimaryKey("rem_id", record_dto.rem_id)
                .RefNo(record_dto.rem_name!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("rem_name", "Name")

                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();

        }

        public async Task logHistoryDetail(List<mast_remarkd> old_records, mast_remarkm_dto record_dto)
        {

            var old_records_dto = old_records.Select(record => new mast_remarkd_dto
            {
                remd_id = record.remd_id,
                remd_desc1 = record.remd_desc1,
            }).ToList();

            await new LogHistorym<mast_remarkd_dto>(context)
                .Table("mast_remarkm", log_date)
                .PrimaryKey("remd_id", record_dto.rem_id)
                .RefNo(record_dto.rem_name!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("remd_desc1", "Description")
                .SetRecords(old_records_dto, record_dto.rem_remarks!)
                .LogChangesAsync();

        }
    }
}
