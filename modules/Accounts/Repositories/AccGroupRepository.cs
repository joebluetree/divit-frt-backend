using Database;
using Database.Lib;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Accounts.Interfaces;
using Database.Models.Accounts;
using Database.Models.BaseTables;
using Common.DTO.Accounts;
using Common.Lib;

namespace Accounts.Repositories
{
    public class AccGroupRepository : IAccGroupRepository
    {

        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private readonly IHeaderRepository _headerRepository;
        private DateTime log_date;

        public AccGroupRepository(AppDbContext _context, IAuditLog _auditLog, IHeaderRepository headerRepository)
        {
            context = _context;
            auditLog = _auditLog;
            _headerRepository = headerRepository;
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

                var grp_name = data["grp_name"].ToString();
                var grp_main_group = data["grp_main_group"].ToString();

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<acc_groupm> query = context.acc_groupm;

                if (grp_name != "" && grp_name != null)
                    query = query.Where(w => w.grp_name!.Contains(grp_name));

                if (grp_main_group != "" && grp_main_group != "NA")
                    query = query.Where(w => w.grp_main_group!.Contains(grp_main_group!));

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
                    .OrderBy(c => c.grp_name)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new acc_groupm_dto
                {
                    grp_id = e.grp_id,
                    grp_name = e.grp_name,
                    grp_main_group = e.grp_main_group,
                    grp_order = e.grp_order,
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
        public async Task<acc_groupm_dto?> GetRecordAsync(int id)
        {
            try
            {

                var headers = _headerRepository.GetHeaders();
                System.Diagnostics.Debug.Print(headers["global_user_branch_id"]);


                IQueryable<acc_groupm> query = context.acc_groupm;
                query = query.Where(f => f.grp_id == id);

                var Record = await query.Select(e => new acc_groupm_dto
                {
                    grp_id = e.grp_id,
                    grp_name = e.grp_name,
                    grp_main_group = e.grp_main_group,
                    grp_order = e.grp_order,
                    rec_version = e.rec_version,
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

        public async Task<acc_groupm_dto> SaveAsync(int id, string mode, acc_groupm_dto Record)
        {
            try
            {
                log_date = DateTime.UtcNow;
                context.Database.BeginTransaction();
                acc_groupm_dto _Record = await SaveParentAsync(id, mode, Record);
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

        private Boolean AllValid(int id, string mode, acc_groupm_dto Record_DTO)
        {
            Boolean bRet = true;
            if (Record_DTO.grp_name == "")
            {
                throw new Exception("Invalid Name");
            }
            if (Record_DTO.grp_main_group == "")
            {
                throw new Exception("Invalid Type");
            }
            if (Record_DTO.grp_order <= 0)
            {
                throw new Exception("Invalid Order");
            }
            return bRet;
        }
        public async Task<acc_groupm_dto> SaveParentAsync(int id, string mode, acc_groupm_dto Record_DTO)
        {
            acc_groupm? Record;



            try
            {
                if (Record_DTO == null)
                    throw new Exception("No Data Found To Save");

                AllValid(id, mode, Record_DTO);

                if (mode == "add")
                {
                    Record = new acc_groupm();
                    Record.rec_company_id = Record_DTO.rec_company_id;
                    Record.rec_created_by = Record_DTO.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.acc_groupm
                        .Where(f => f.grp_id == id)
                        .FirstOrDefaultAsync();
                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = Record_DTO.rec_version;
                    Record.rec_version++;

                    Record.rec_edited_by = Record_DTO.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                if (mode == "edit")
                    await logHistory(Record, Record_DTO);

                Record.grp_name = Record_DTO.grp_name;
                Record.grp_main_group = Record_DTO.grp_main_group;
                Record.grp_order = Record_DTO.grp_order;

                if (mode == "add")
                {
                    await context.acc_groupm.AddAsync(Record);
                }

                context.SaveChanges();
                Record_DTO.grp_id = Record.grp_id;
                Record_DTO.rec_version = Record.rec_version;
                Lib.AssignDates2DTO(id, mode, Record, Record_DTO);
                return Record_DTO;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "grp_name", "Name Duplication");
                throw;
            }
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int grp_id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", grp_id);
                var _Record = await context.acc_groupm
                    .Where(f => f.grp_id == grp_id)
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

        public async Task logHistory(acc_groupm old_record, acc_groupm_dto record_dto)
        {
            var old_record_dto = new acc_groupm_dto
            {
                grp_id = old_record.grp_id,
                grp_name = old_record.grp_name,
                grp_main_group = old_record.grp_main_group,
            };

            await new LogHistorym<acc_groupm_dto>(context)
                .Table("acc_groupm", log_date)
                .PrimaryKey("grp_id", record_dto.grp_id)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0 , record_dto.rec_created_by!)
                .TrackColumn("grp_name", "name")
                .TrackColumn("grp_main_group", "main-group")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }


    }
}
