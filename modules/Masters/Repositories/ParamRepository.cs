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
    public class ParamRepository : IParamRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;

        public ParamRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var param_name = data["param_name"].ToString();
                var param_type = data["param_type"].ToString();
                var company_id = int.Parse(data["rec_company_id"].ToString()!);

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_param> query = context.mast_param;

                query = query.Where(w => w.rec_company_id == company_id);

                query = query.Where(w => w.param_type!.Contains(param_type!));

                if (param_name != "" && param_name != null)
                    query = query.Where(w => w.param_name!.Contains(param_name));


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
                    .OrderBy(c => c.param_order)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_param_dto
                {
                    param_id = e.param_id,
                    param_type = e.param_type,
                    param_code = e.param_code,
                    param_name = e.param_name,
                    param_value1 = e.param_value1 ?? "",
                    param_value2 = e.param_value2 ?? "",
                    param_value3 = e.param_value3 ?? "",
                    param_value4 = e.param_value4 ?? "",
                    param_value5 = e.param_value5 ?? "",

                    param_order = e.param_order,
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
        public async Task<mast_param_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<mast_param> query = context.mast_param;
                query = query.Where(f => f.param_id == id);

                var Record = await query.Select(e => new mast_param_dto
                {
                    param_id = e.param_id,
                    param_code = e.param_code,
                    param_name = e.param_name,
                    param_type = e.param_type,
                    param_order = e.param_order,
                    param_value1 = e.param_value1 ?? "",
                    param_value2 = e.param_value2 ?? "",
                    param_value3 = e.param_value3 ?? "",
                    param_value4 = e.param_value4 ?? "",
                    param_value5 = e.param_value5 ?? "",
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

        public async Task<mast_param_dto> SaveAsync(int id, string mode, mast_param_dto record_dto)
        {
            try
            {
                log_date = DateTime.UtcNow;
                context.Database.BeginTransaction();
                record_dto = await SaveParentAsync(id, mode, record_dto);
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

        private Boolean AllValid(string mode, mast_param_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";

            if (Lib.IsBlank(record_dto.param_code))
                str += "Code Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.param_name))
                str += "Name Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }


        public async Task<mast_param_dto> SaveParentAsync(int id, string mode, mast_param_dto record_dto)
        {

            string error = "";
            mast_param? Record;

            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found To Save");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    Record = new mast_param();
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.mast_param
                        .Where(f => f.param_id == id)
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

                Record.param_id = record_dto.param_id;
                Record.param_type = record_dto.param_type;
                Record.param_code = record_dto.param_code;
                Record.param_name = record_dto.param_name;

                Record.param_value1 = record_dto.param_value1;
                Record.param_value2 = record_dto.param_value2;
                Record.param_value3 = record_dto.param_value3;
                Record.param_value4 = record_dto.param_value4;
                Record.param_value5 = record_dto.param_value5;

                Record.param_order = record_dto.param_order;

                if (mode == "add")
                    await context.mast_param.AddAsync(Record);

                context.SaveChanges();
                record_dto.param_id = Record.param_id;
                record_dto.rec_version = Record.rec_version;
                Lib.AssignDates2DTO(id, mode, Record, record_dto);
                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "param_name", "Name Duplication");
                throw;
            }

        }
        	public async Task logHistory(mast_param old_record, mast_param_dto record_dto)
        {
            var new_record = new mast_param
            {
                param_id = record_dto.param_id,
                param_type = record_dto.param_type,
                param_code = record_dto.param_code,
                param_name = record_dto.param_name,
                
                param_value1 = record_dto.param_value1,
                param_value2 = record_dto.param_value2,
                param_value3 = record_dto.param_value3,
                param_value4 = record_dto.param_value4,
                param_value5 = record_dto.param_value5,

            };

            await new LogHistory<mast_param>(context)
                .Table("mast_param", log_date)
                .PrimaryKey("param_id", record_dto.param_id)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0 , record_dto.rec_created_by!)
                .TrackColumn("param_code", "code")
                .TrackColumn("param_name", "name")
                .TrackColumn("param_route", "routes")
                .TrackColumn("param_param", "param-param")
                .TrackColumn("param_module_id", "module")
                .TrackColumn("param_subparam_id", "sub-param")
                .SetRecord(old_record, new_record)
                .LogChangesAsync();
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_param
                    .FirstOrDefaultAsync(f => f.param_id == id);
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
