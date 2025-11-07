//using Database;
using Database.Lib;
using Microsoft.EntityFrameworkCore;
using Common.UserAdmin.DTO;
using UserAdmin.Interfaces;
using Database.Lib.Interfaces;

using Database.Models.BaseTables;
using Database.Models.UserAdmin;
using Database;

using Common.Lib;

namespace UserAdmin.Repositories
{
    public class YearRepository : IYearRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;

        public YearRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var year_name = data["year_name"].ToString();
                var company_id = int.Parse(data["rec_company_id"].ToString()!);

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_yearm> query = context.mast_yearm;

                query = query.Where(w => w.rec_company_id == company_id);

                if (year_name != "" && year_name != null)
                    query = query.Where(w => w.year_name!.Contains(year_name));

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
                    .OrderBy(c => c.year_name)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_yearm_dto
                {
                    year_id = e.year_id,
                    year_code = e.year_code,
                    year_name = e.year_name,
                    year_start_date = Lib.FormatDate(e.year_start_date, Lib.outputDateFormat),
                    year_end_date = Lib.FormatDate(e.year_end_date, Lib.outputDateFormat),
                    year_closed = e.year_closed,
                    year_default = e.year_default,

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
        public async Task<mast_yearm_dto?> GetRecordAsync(int comp_id, int id)
        {
            try
            {
                IQueryable<mast_yearm> query = context.mast_yearm;
                
                query = query.Where(f => f.year_id == id);

                var Record = await query.Select(e => new mast_yearm_dto
                {
                    year_id = e.year_id,
                    year_code = e.year_code,
                    year_name = e.year_name,
                    year_start_date = Lib.FormatDate(e.year_start_date, Lib.outputDateFormat),
                    year_end_date = Lib.FormatDate(e.year_end_date, Lib.outputDateFormat),
                    year_closed = e.year_closed,
                    year_default = e.year_default,

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

        public async Task<mast_yearm_dto> SaveAsync(int id, string mode, mast_yearm_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                mast_yearm_dto _Record = await SaveParentAsync(id, mode, record_dto);
                // _Record = await SaveDetAsync(_Record.year_id, _Record);
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


        private Boolean AllValid(string mode, mast_yearm_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";

            if (Lib.IsZero(record_dto.year_code))
                str += "Code Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.year_name))
                str += "Name Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.year_start_date))
                str += "Start Date Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.year_end_date))
                str += "End Date Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }


        public async Task<mast_yearm_dto> SaveParentAsync(int id, string mode, mast_yearm_dto record_dto)
        {
            mast_yearm? Record;
            List<mast_yearm> records;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found To Save");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    Record = new mast_yearm();
                    Record.year_id = record_dto.year_id;
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    }
                    else
                    {
                        Record = await context.mast_yearm
                        .Where(f => f.year_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("No Record Found");

                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                    // context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    // Record.rec_version++;
                }
                if (mode == "edit")
                    await logHistory(Record, record_dto);

                Record.year_code = record_dto.year_code;
                Record.year_name = record_dto.year_name;
                Record.year_start_date = Lib.ParseDate(record_dto.year_start_date!);
                Record.year_end_date = Lib.ParseDate(record_dto.year_end_date!);
                Record.year_closed = record_dto.year_closed;

                if(record_dto.year_default == "Y")//Record.year_default=="N" && 
                {
                    records = await context.mast_yearm
                    .Where(w => w.year_id != id)
                    .ToListAsync();

                    foreach (var existing_record in records)
                    {
                        if (existing_record.year_default == "Y")
                        {
                            var oldDto = new mast_yearm_dto
                            {
                                year_id = existing_record.year_id,
                                year_code = existing_record.year_code,
                                year_name = existing_record.year_name,
                                year_start_date = Lib.FormatDate(existing_record.year_start_date, Lib.outputDateFormat),
                                year_end_date = Lib.FormatDate(existing_record.year_end_date, Lib.outputDateFormat),
                                year_closed = existing_record.year_closed,
                                year_default = "N",
                                rec_company_id = existing_record.rec_company_id,
                                rec_created_by = record_dto.rec_created_by,
                                rec_edited_by = record_dto.rec_created_by
                            };
                            await logHistory(existing_record, oldDto);
                            
                            existing_record.year_default = "N";
                            existing_record.rec_edited_by = record_dto.rec_created_by; // add edit-date if neded
                            existing_record.rec_edited_date = DbLib.GetDateTime();
                        }
                    }   
                }
                
                Record.year_default = record_dto.year_default;

                if (mode == "add")
                    await context.mast_yearm.AddAsync(Record);

                context.SaveChanges();
                record_dto.year_id = Record.year_id;
                record_dto.year_default = Record.year_default;

                // Lib.AssignDates2DTO(id, mode, Record, record_dto);
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.year_id != 0)
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }
                return record_dto;
            }

            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "year_code", "Code Duplication");
                Lib.getErrorMessage(Ex, "uq", "year_name", "Name Duplication");
                throw;
            }
        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_yearm
                    .Where(f => f.year_id == id)
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
        public async Task logHistory(mast_yearm old_record, mast_yearm_dto record_dto)
        {
            var old_record_dto = new mast_yearm_dto
            {
                year_id = old_record.year_id,
                year_code = old_record.year_code,
                year_name = old_record.year_name,
                year_start_date = Lib.FormatDate(old_record.year_start_date, Lib.outputDateFormat),
                year_end_date = Lib.FormatDate(old_record.year_end_date, Lib.outputDateFormat),
                year_closed = old_record.year_closed,
                year_default = old_record.year_default,
            };

            await new LogHistorym<mast_yearm_dto>(context)
                .Table("mast_yearm", log_date)
                .PrimaryKey("year_id", record_dto.year_id)
                .RefNo(record_dto.year_name!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0 , record_dto.rec_created_by!)
                .TrackColumn("year_code", "code")
                .TrackColumn("year_name", "name")
                .TrackColumn("year_start_date", "Start Date", "date")
                .TrackColumn("year_end_date", "End Date", "date")
                .TrackColumn("year_closed", "Closed")
                .TrackColumn("year_default", "Default")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }

    }
}
