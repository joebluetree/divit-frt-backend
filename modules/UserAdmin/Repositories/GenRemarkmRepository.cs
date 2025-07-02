using Database;
using Database.Lib;
using Common.DTO.UserAdmin;
using UserAdmin.Interfaces;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.UserAdmin;
using Database.Models.BaseTables;
using Common.Lib;

namespace UserAdmin.Repositories
{
    public class GenRemarkmRepository : IGenRemarkmRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        public GenRemarkmRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var remk_desc = "";
                var company_id = 0;
                var branch_id = 0;

                if (data.ContainsKey("remk_desc"))
                    remk_desc = data["remk_desc"].ToString();

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

                IQueryable<gen_remarkm> query = context.gen_remarkm;

                query = query.Where(i => i.rec_company_id == company_id);

                if (!Lib.IsBlank(remk_desc))
                    query = query.Where(w => w.remk_desc!.Contains(remk_desc!));

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
                    .OrderBy(c => c.remk_order)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new gen_remarkm_dto
                {
                    remk_id = e.remk_id,
                    remk_parent_id = e.remk_parent_id,
                    remk_parent_type = e.remk_parent_type,
                    remk_desc = e.remk_desc,
                    remk_order = e.remk_order,

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
        public async Task<gen_remarkm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<gen_remarkm> query = context.gen_remarkm;


                query = query.Where(f => f.remk_id == id);

                var Record = await query.Select(e => new gen_remarkm_dto
                {
                    remk_id = e.remk_id,
                    remk_parent_id = e.remk_parent_id,
                    remk_parent_type = e.remk_parent_type,
                    remk_desc = e.remk_desc,
                    remk_order = e.remk_order,

                    rec_version = e.rec_version,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Remarks Found");
                // Record.rem_remarks = await GetDetailsAsync(Record.rem_id);
                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<gen_remarkm_dto>> GetDetailsAsync(int? parent_id, string? parent_type)
        {
            var query = from e in context.gen_remarkm
                        .Where(e => e.remk_parent_id == parent_id && e.remk_parent_type == parent_type)
                        .OrderBy(o => o.remk_order)
                        select (new gen_remarkm_dto
                        {
                            remk_id = e.remk_id,
                            remk_parent_id = e.remk_parent_id,
                            remk_parent_type = e.remk_parent_type,
                            remk_desc = e.remk_desc,
                            remk_order = e.remk_order,

                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        });
            var records = await query.ToListAsync();
            return records;
        }

        public async Task<gen_remarkm_dto> SaveAsync(int id, string parent_type,string mode, gen_remarkm_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                // gen_remarkm_dto _Record = await SaveParentAsync(id, mode, record_dto);
                gen_remarkm_dto _Record = await SaveDetailsAsync(id, parent_type, mode, record_dto);
                _Record.remk_remarks = await GetDetailsAsync(id,parent_type);
                await CommonLib.SaveGenMemoSummary(this.context, id, parent_type);
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

        private Boolean AllValid(string mode, gen_remarkm_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";
            string code = "";

            if (Lib.IsBlank(record_dto.remk_desc))
                str += "Desc Cannot Be Blank!";

            if (code != "")
                str += code;

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<gen_remarkm_dto> SaveParentAsync(int id, string mode, gen_remarkm_dto record_dto)
        {
            gen_remarkm? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    Record = new gen_remarkm();
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.gen_remarkm
                        .Where(f => f.remk_id == id)
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

                Record.remk_desc = record_dto.remk_desc;
                if (mode == "add")
                    await context.gen_remarkm.AddAsync(Record);
                context.SaveChanges();
                record_dto.remk_id = Record.remk_id;
                record_dto.rec_version = Record.rec_version;
                // Lib.AssignDates2DTO(id, mode, Record, record_dto);
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.remk_id != 0)
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }

                return record_dto;
            }
            catch (Exception)
            {
                // Lib.getErrorMessage(Ex, "uq", "rem_name", "Name Duplication");
                throw;
            }

        }

        public async Task<gen_remarkm_dto> SaveDetailsAsync(int id, string parent_type, string mode, gen_remarkm_dto record_dto)
        {
            gen_remarkm? record;
            List<gen_remarkm_dto> records_dto;
            List<gen_remarkm> records;
            // string error = "";

            try
            {
                records_dto = record_dto.remk_remarks!;
                records = await context.gen_remarkm
                    .Where(w => w.remk_parent_id == id && w.remk_parent_type == parent_type)
                    .ToListAsync();
                int nextorder = 1;

                // if (!AllValid(mode, record_dto, ref error))
                //     throw new Exception(error);

                if (mode == "edit")
                    await logHistoryDetail(records, record_dto);

                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.remk_id == existing_record.remk_id);
                    if (rec == null)
                        context.gen_remarkm.Remove(existing_record);
                }

                //Add or Edit Records 
                foreach (var rec in records_dto)
                {
                    if (rec.remk_id == 0)
                    {
                        record = new gen_remarkm();
                        record.rec_company_id = record_dto.rec_company_id;
                        record.rec_branch_id = record_dto.rec_branch_id;
                        record.rec_created_by = record_dto.rec_created_by;
                        record.rec_created_date = DbLib.GetDateTime();
                    }
                    else
                    {
                        record = records.Find(f => f.remk_id == rec.remk_id);
                        if (record == null)
                            throw new Exception("Detail Record Not Found " + rec.remk_id.ToString());
                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }
                    record.remk_parent_id = id;
                    record.remk_parent_type = parent_type;
                    record.remk_desc = rec.remk_desc;
                    record.remk_order = nextorder++;
                    if (rec.remk_id == 0)
                        await context.gen_remarkm.AddAsync(record);
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
                var _Record = await context.gen_remarkm
                    .Where(f => f.remk_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    var rem_remarks = context.gen_remarkm
                     .Where(c => c.remk_parent_id == id);
                    if (rem_remarks.Any())
                    {
                        context.gen_remarkm.RemoveRange(rem_remarks);
                    }
                    context.Remove(_Record);
                    await context.SaveChangesAsync();
                    await CommonLib.SaveGenMemoSummary(this.context, _Record.remk_parent_id, _Record.remk_parent_type);
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

        public async Task logHistory(gen_remarkm old_record, gen_remarkm_dto record_dto)
        {

            var old_record_dto = new gen_remarkm_dto
            {
                remk_id = old_record.remk_id,
                remk_desc = old_record.remk_desc,

            };

            await new LogHistorym<gen_remarkm_dto>(context)
                .Table("gen_remarkm", log_date)
                .PrimaryKey("remk_id", record_dto.remk_id)
                .RefNo(record_dto.remk_desc!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("remk_desc", "Desc")

                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();

        }

        public async Task logHistoryDetail(List<gen_remarkm> old_records, gen_remarkm_dto record_dto)
        {

            var old_records_dto = old_records.Select(record => new gen_remarkm_dto
            {
                remk_id = record.remk_id,
                remk_desc = record.remk_desc,
            }).ToList();

            await new LogHistorym<gen_remarkm_dto>(context)
                .Table("gen_remarkm", log_date)
                .PrimaryKey("remk_id", record_dto.remk_id)
                .RefNo(record_dto.remk_desc!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("remk_desc", "Description")
                .SetRecords(old_records_dto, record_dto.remk_remarks!)
                .LogChangesAsync();
        }
    }
}
