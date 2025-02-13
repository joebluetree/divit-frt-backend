using Database;
using Database.Lib;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Common.UserAdmin.DTO;
using UserAdmin.Interfaces;
using Database.Lib.Interfaces;
using Database.Models.BaseTables;
using Database.Models.UserAdmin;
using Database.Models.Masters;

using Common.Lib;

namespace UserAdmin.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        // private DateTime log_date;

        public SettingsRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var category = data["category"].ToString();
                var caption = data["caption"].ToString();
                var company_id = int.Parse(data["rec_company_id"].ToString()!);

                var branch_id = int.Parse(data["branch_id"].ToString()!);
                var param_id = 0;

                if (data.ContainsKey("param_id"))
                {
                    param_id = int.Parse(data["param_id"].ToString()!);
                }

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_settings> query = context.mast_settings;
                query = query.Where(w => w.category == category);

                if (category == "COMPANY-SETTINGS")
                {
                    query = query.Where(w => w.rec_company_id == company_id);
                }
                else if (category == "BRANCH-SETTINGS")
                {
                    query = query.Where(w => w.rec_company_id == company_id);
                    query = query.Where(w => w.rec_branch_id == branch_id);
                }
                else
                {
                    query = query.Where(w => w.rec_company_id == company_id);
                    query = query.Where(w => w.param_id == param_id);
                    if (branch_id > 0)
                        query = query.Where(w => w.rec_branch_id == branch_id);
                }

                if (caption != "" && caption != null)
                    query = query.Where(w => w.caption!.Contains(caption));

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
                    .OrderBy(c => c.order)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_settings_dto
                {
                    id = e.id,
                    category = e.category,
                    caption = e.caption,
                    remarks = e.remarks,
                    type = e.type,
                    table = e.table,
                    value = e.value,
                    code = e.code,
                    name = e.name,
                    order = e.order,
                    rec_version = e.rec_version,

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
        public async Task<mast_settings_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<mast_settings> query = context.mast_settings;

                query = query.Where(f => f.id == id);

                var Record = await query.Select(e => new mast_settings_dto
                {
                    id = e.id,
                    category = e.category,
                    caption = e.caption,
                    remarks = e.remarks,
                    type = e.type,
                    table = e.table,
                    value = e.value,
                    code = e.code,
                    name = e.name,
                    order = e.order,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by ?? "",
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

        public async Task<mast_settings_dto> SaveAsync(int id, string mode, mast_settings_dto record_dto)
        {
            try
            {
                // log_date = DateTime.UtcNow;

                context.Database.BeginTransaction();
                record_dto = await SaveParentAsync(id, mode, record_dto);
                context.Database.CommitTransaction();
                return record_dto;
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }
        public async Task<mast_settings_dto> SaveParentAsync(int id, string mode, mast_settings_dto record_dto)
        {
            mast_settings? Record;
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found To Save");

                Record = await context.mast_settings
                .Where(f => f.id == id)
                .FirstOrDefaultAsync();
                if (Record == null)
                    throw new Exception("No Record Found");

                if (Record == null)
                {
                    throw new Exception("No Data Found To Save");
                }

                // await logHistory(Record, record_dto);

                Record.rec_edited_by = record_dto.rec_created_by;
                Record.rec_edited_date = DbLib.GetDateTime();
                Record.value = record_dto.value;
                Record.code = record_dto.code;
                Record.name = record_dto.name;

                // if (mode == "edit")
                    

                var br_id = 0;
                if (Record.rec_branch_id != null)
                    br_id = int.Parse(Record.rec_branch_id.ToString()!);

                context.SaveChanges();

                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "caption", "Caption Duplication");
                throw;
            }
        }
    	// public async Task logHistory(mast_settings old_record, mast_settings_dto record_dto)
        // {
        //     var new_record = new mast_settings
        //     {
        //         category = record_dto.category,
        //         caption = record_dto.caption,
        //         remarks = record_dto.remarks,
        //         type = record_dto.type,
        //         table = record_dto.table,
        //         value = record_dto.value,
        //         code = record_dto.code,
        //         name = record_dto.name

        //     };

        //     await new LogHistory<mast_settings>(context)
        //         .Table("mast_settings", log_date)
        //         .PrimaryKey("id", record_dto.id)
        //         .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id ?? 0, record_dto.rec_created_by!)
        //         .TrackColumn("category", "category")
        //         .TrackColumn("caption", "caption")
        //         .TrackColumn("remarks", "remarks")
        //         .TrackColumn("type", "type")
        //         .TrackColumn("table", "table")
        //         .TrackColumn("value", "value")
        //         .TrackColumn("code", "code")
        //         .TrackColumn("name", "name")
        //         .SetRecord(old_record, new_record)
        //         .LogChangesAsync();
        // }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_settings
                    .Where(f => f.id == id)
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

        public async Task<int> ReUpdateAsync(string category, int comp_id, int branch_id, int param_id, string user_code)
        {
            try
            {
                int retValue = 0;
                context.Database.BeginTransaction();
                if (category == "COMPANY-SETTINGS")
                    retValue = await SaveCompanySettingsAsync(user_code, category, comp_id, 0, 0);
                if (category == "BRANCH-SETTINGS")
                    retValue = await SaveBranchSettingsAsync(user_code, category, comp_id, branch_id, 0);
                if (category == "SEA CARRIER")
                {
                    retValue = await SaveSeaCarrierSettingsAsync(user_code, category, comp_id, branch_id, param_id);
                    await UpdateCarrierCredentials(comp_id, param_id);
                }

                context.Database.CommitTransaction();
                return retValue;
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }

        public async Task<int> SaveCompanySettingsAsync(string user_code, string category, int comp_id, int branch_id, int param_id)
        {
            int retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "DECIMALS", "", "INT", "", "3", "", "", 1);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "SOFTWARE FOLDER", "", "STRING", "", "", "", "", 2);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "DATE-FORMAT", "", "STRING", "", "DD-MM-YYYY", "", "", 2);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "LOGO SMALL", "", "STRING", "", "", "", "", 3);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "LOGO MEDIUM", "", "STRING", "", "", "", "", 4);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "LOGO LARGE", "", "STRING", "", "", "", "", 5);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "SUNDRY DEBTORS", "", "TABLE", "acctm,acc_id,acc_code,acc_name", "", "", "", 7);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "SUNDRY CREDITORS", "", "TABLE", "acctm,acc_id,acc_code,acc_name", "", "", "", 8);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "MAIN BRANCH", "", "TABLE", "branchm,branch_id,branch_code, branch_name", "", "", "", 9);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "SHIPSGO-ID", "", "STRING", "", "35448b76451fe9919422b17e11b9a2c8", "", "", 10);
            return retValue;
        }
        public async Task<int> SaveBranchSettingsAsync(string user_code, string category, int comp_id, int branch_id, int param_id)
        {
            int retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "LOCATION", "", "STRING", "", "2", "", "", 1);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "REPORT FOLDER", "", "STRING", "", "", "", "", 2);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "TEMP FOLDER", "", "STRING", "", "", "", "", 3);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "SHOW BOE", "", "BOOLEAN", "", "", "", "", 4);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "QUOTATION-LCL-PREFIX", "", "STRING", "", "", "", "", 5);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "QUOTATION-LCL-STARTING-NO", "", "INT", "", "", "", "", 6);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "QUOTATION-AIR-PREFIX", "", "STRING", "", "", "", "", 7);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "QUOTATION-AIR-STARTING-NO", "", "INT", "", "", "", "", 8);

            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "QUOTATION-FCL-PREFIX", "", "STRING", "", "", "", "", 9);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "QUOTATION-FCL-STARTING-NO", "", "INT", "", "", "", "",10);

            return retValue;
        }

        public async Task<int> SaveSeaCarrierSettingsAsync(string user_code, string category, int comp_id, int branch_id, int param_id)
        {
            int retValue = 0;
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-URL", "", "STRING", "", "", "", "", 1);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-USERID", "", "STRING", "", "", "", "", 2);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-PASSWORD", "", "STRING", "", "", "", "", 3);

            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-TYPE", "", "STRING", "", "", "", "", 4);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-CLIENT-ID", "", "STRING", "", "", "", "", 5);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-CLIENT-SECRET", "", "STRING", "", "", "", "", 6);

            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-API-URL", "", "STRING", "", "", "", "", 7);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-API-HEADER1", "", "STRING", "", "", "", "", 8);

            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-ACCESS-TOKEN-TYPE", "", "STRING", "", "", "", "", 9);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-ACCESS-TOKEN-URL", "", "STRING", "", "", "", "", 10);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-ACCESS-TOKEN-HEADER1", "", "STRING", "", "", "", "", 11);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-ACCESS-TOKEN", "", "STRING", "", "", "", "", 12);
            retValue = await addSettingsAsync(comp_id, branch_id, param_id, user_code, category, "CNTR-TRACKING-ACCESS-TOKEN-EXPIRY", "", "STRING", "", "", "", "", 13);

            return retValue;
        }

        public async Task<int> addSettingsAsync(int comp_id, int branch_id, int param_id, string user_code, string category, string caption, string remarks, string type, string table, string value, string code, string name, int order)
        {
            mast_settings? Record;
            int id = 0;

            try
            {

                IQueryable<mast_settings> query = context.mast_settings;
                query = query.Where(m => m.category == category);
                query = query.Where(m => m.rec_company_id == comp_id);

                if (category == "BRANCH-SETTINGS")
                    query = query.Where(m => m.rec_branch_id == branch_id);
                if (category != "COMPANY-SETTINGS" && category != "BRANCH-SETTINGS")
                    query = query.Where(m => m.param_id == param_id);

                query = query.Where(m => m.caption == caption);

                Record = await query.FirstOrDefaultAsync();

                if (Record == null)
                {
                    Record = new mast_settings();
                    Record.rec_company_id = comp_id;
                    Record.rec_created_by = user_code;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.category = category;
                    Record.caption = caption;
                    Record.remarks = remarks;
                    Record.type = type;
                    Record.table = table;
                    Record.json = "";
                    Record.order = order;
                    Record.rec_company_id = comp_id;
                    Record.rec_branch_id = branch_id == 0 ? null : branch_id;
                    Record.param_id = param_id == 0 ? null : param_id;
                    Record.value = value;
                    Record.code = code;
                    Record.name = name;
                    await context.mast_settings.AddAsync(Record);
                    context.SaveChanges();
                    id = Record.id;
                }
                return id;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "caption", "Duplicate Caption : " + caption + " Company:" + comp_id + " Branch:" + branch_id);
                throw;
            }
        }
        public async Task UpdateCarrierCredentials(int comp_id, int param_id)
        {
            try
            {
                IQueryable<mast_param> query = context.mast_param;
                query = query.Where(m => m.param_type == "SEA CARRIER");
                query = query.Where(m => m.param_id == param_id);
                mast_param param_record = await query.FirstAsync();
                if (param_record == null)
                    return;
                var dc = new DataContainer();

                if (param_record.param_value1 == "HLCU")
                {
                    dc = new DataContainer()
                        .Set("CNTR-TRACKING-URL", "https://api-portal.hlag.com/#/products/events-tracing-for-web-api-product-d73213")
                        .Set("CNTR-TRACKING-USERID", "kochisales")
                        .Set("CNTR-TRACKING-PASSWORD", "2021COKcpl")
                        .Set("CNTR-TRACKING-CLIENT-ID", "2f89b67a-003c-4f91-9130-80a1a4c8212a")
                        .Set("CNTR-TRACKING-CLIENT-SECRET", "Hcm8Q~L5QDCa3Y14HaerCR.1jLOs4xBT.~gsOb32")

                        .Set("CNTR-TRACKING-TYPE", "API")
                        .Set("CNTR-TRACKING-API-URL", "https://api.hlag.com/hlag/external/v2/events")
                        .Set("CNTR-TRACKING-API-HEADER1", "API-Version:1,X-IBM-Client-Id:2f89b67a-003c-4f91-9130-80a1a4c8212a,X-IBM-Client-Secret:Hcm8Q~L5QDCa3Y14HaerCR.1jLOs4xBT.~gsOb32")

                        .Set("CNTR-TRACKING-ACCESS-TOKEN-TYPE", "")
                        .Set("CNTR-TRACKING-ACCESS-TOKEN-URL", "")
                        .Set("CNTR-TRACKING-ACCESS-TOKEN-HEADER1", "")
                        .Set("CNTR-TRACKING-ACCESS-TOKEN", "")
                        .Set("CNTR-TRACKING-ACCESS-TOKEN-EXPIRY", "");

                    await UpdateParam(dc, comp_id, param_id, param_record.param_value1);
                }
                if (param_record.param_value1 == "CMDU")
                {
                    dc = new DataContainer()
                    .Set("CNTR-TRACKING-URL", "https://api-portal.cma-cgm.com")
                    .Set("CNTR-TRACKING-USERID", "joy@cargomar.in")
                    .Set("CNTR-TRACKING-PASSWORD", "CargoApi1973#")
                    .Set("CNTR-TRACKING-CLIENT-ID", "YbElDwUjsHSfirYN7ZEgkw5nqwhgHERW")
                    .Set("CNTR-TRACKING-CLIENT-SECRET", "")

                    .Set("CNTR-TRACKING-TYPE", "API")
                    .Set("CNTR-TRACKING-API-URL", "https://apis.cma-cgm.net/operation/trackandtrace/v1/events")
                    .Set("CNTR-TRACKING-API-HEADER1", "KeyId:YbElDwUjsHSfirYN7ZEgkw5nqwhgHERW")

                    .Set("CNTR-TRACKING-ACCESS-TOKEN-TYPE", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-URL", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-HEADER1", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-EXPIRY", "");

                    await UpdateParam(dc, comp_id, param_id, param_record.param_value1);
                }
                if (param_record.param_value1 == "YMLU")
                {
                    dc = new DataContainer()
                    .Set("CNTR-TRACKING-URL", "https://api.yangming.com/open/dcsa/api/dev/tnt/1.1.0/events")
                    .Set("CNTR-TRACKING-USERID", "joy@cargomar.in")
                    .Set("CNTR-TRACKING-PASSWORD", "CargoApi1973#")
                    .Set("CNTR-TRACKING-CLIENT-ID", "c07c2bea-a142-4fd7-9d59-1185025a8c5c")
                    .Set("CNTR-TRACKING-CLIENT-SECRET", "")

                    .Set("CNTR-TRACKING-TYPE", "API-1")
                    .Set("CNTR-TRACKING-API-URL", "https://api.yangming.com/open/dcsa/api/tnt/1.1.0/events")
                    .Set("CNTR-TRACKING-API-HEADER1", "KeyId:c07c2bea-a142-4fd7-9d59-1185025a8c5c")

                    .Set("CNTR-TRACKING-ACCESS-TOKEN-TYPE", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-URL", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-HEADER1", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-EXPIRY", "");

                    await UpdateParam(dc, comp_id, param_id, param_record.param_value1);
                }
                if (param_record.param_value1 == "MAEU")
                {
                    dc = new DataContainer()
                    .Set("CNTR-TRACKING-URL", "https://developer.maersk.com")
                    .Set("CNTR-TRACKING-USERID", " joy@cargomar.in")
                    .Set("CNTR-TRACKING-PASSWORD", "CargoApi1973#")
                    .Set("CNTR-TRACKING-CLIENT-ID", "7v5FaxMh98Gs2id7sce5sp9AGOdiAGG0")
                    .Set("CNTR-TRACKING-CLIENT-SECRET", "7A7F1bT77QEOZPXS")

                    .Set("CNTR-TRACKING-TYPE", "API")
                    .Set("CNTR-TRACKING-API-URL", "https://api.maersk.com/track-and-trace-private/events")
                    .Set("CNTR-TRACKING-API-HEADER1", "Authorization:Bearer {access_token},Consumer-Key:7v5FaxMh98Gs2id7sce5sp9AGOdiAGG0")

                    .Set("CNTR-TRACKING-ACCESS-TOKEN-TYPE", "OAUTH2")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-URL", "https://api.maersk.com/oauth2/access_token")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-HEADER1", "grant_type=client_credentials,client_id=7v5FaxMh98Gs2id7sce5sp9AGOdiAGG0,client_secret=7A7F1bT77QEOZPXS")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-EXPIRY", "");

                    await UpdateParam(dc, comp_id, param_id, param_record.param_value1);
                }
                if (param_record.param_value1 == "COSU")
                {
                    dc = new DataContainer()
                    .Set("CNTR-TRACKING-URL", "https://shipsgo.com/api/v1.2/ContainerService")
                    .Set("CNTR-TRACKING-USERID", "joy@cargomar.in")
                    .Set("CNTR-TRACKING-PASSWORD", "CargoApi1973#")
                    .Set("CNTR-TRACKING-CLIENT-ID", "")
                    .Set("CNTR-TRACKING-CLIENT-SECRET", "")

                    .Set("CNTR-TRACKING-TYPE", "SHIPSGO")
                    .Set("CNTR-TRACKING-API-URL", "https://shipsgo.com/api/v1.2/ContainerService")
                    .Set("CNTR-TRACKING-API-HEADER1", "Content-Type:application/x-www-form-urlencoded")

                    .Set("CNTR-TRACKING-ACCESS-TOKEN-TYPE", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-URL", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-HEADER1", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-EXPIRY", "");

                    await UpdateParam(dc, comp_id, param_id, param_record.param_value1);
                }
                if (param_record.param_value1 == "OOLU")
                {
                    dc = new DataContainer()
                    .Set("CNTR-TRACKING-URL", "https://shipsgo.com/api/v1.2/ContainerService")
                    .Set("CNTR-TRACKING-USERID", "joy@cargomar.in")
                    .Set("CNTR-TRACKING-PASSWORD", "CargoApi1973#")
                    .Set("CNTR-TRACKING-CLIENT-ID", "")
                    .Set("CNTR-TRACKING-CLIENT-SECRET", "")

                    .Set("CNTR-TRACKING-TYPE", "SHIPSGO")
                    .Set("CNTR-TRACKING-API-URL", "https://shipsgo.com/api/v1.2/ContainerService")
                    .Set("CNTR-TRACKING-API-HEADER1", "Content-Type:application/x-www-form-urlencoded")

                    .Set("CNTR-TRACKING-ACCESS-TOKEN-TYPE", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-URL", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-HEADER1", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-EXPIRY", "");

                    await UpdateParam(dc, comp_id, param_id, param_record.param_value1);
                }
                if (param_record.param_value1 == "MSCU")
                {
                    dc = new DataContainer()
                    .Set("CNTR-TRACKING-URL", "https://shipsgo.com/api/v1.2/ContainerService")
                    .Set("CNTR-TRACKING-USERID", "joy@cargomar.in")
                    .Set("CNTR-TRACKING-PASSWORD", "CargoApi1973#")
                    .Set("CNTR-TRACKING-CLIENT-ID", "")
                    .Set("CNTR-TRACKING-CLIENT-SECRET", "")

                    .Set("CNTR-TRACKING-TYPE", "SHIPSGO")
                    .Set("CNTR-TRACKING-API-URL", "https://shipsgo.com/api/v1.2/ContainerService")
                    .Set("CNTR-TRACKING-API-HEADER1", "Content-Type:application/x-www-form-urlencoded")

                    .Set("CNTR-TRACKING-ACCESS-TOKEN-TYPE", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-URL", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-HEADER1", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN", "")
                    .Set("CNTR-TRACKING-ACCESS-TOKEN-EXPIRY", "");

                    await UpdateParam(dc, comp_id, param_id, param_record.param_value1);
                }

                //SEGU9471335

                //COSU
                //OOLU
                //BEAU6030782

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateParam(DataContainer dc, int comp_id, int param_id, string scac_code)
        {
            mast_settings? Record;
            List<mast_settings> Records = await context.mast_settings
                    .Where(m => m.param_id == param_id)
                    .ToListAsync();
            dc.ForEach((key, value) =>
            {
                Record = Records.Find(f => f.caption == key);
                if (Record != null)
                    Record.value = (string)value;

            });
            context.SaveChanges();
        }
    }
}
