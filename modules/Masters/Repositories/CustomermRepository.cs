using Database;
using Database.Lib;
using Common.DTO.Masters;
using Masters.Interfaces;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;

namespace Masters.Repositories
{
    public class CustomermRepository : ICustomermRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public CustomermRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var cust_row_type = "";
                var cust_name = "";
                var company_id = 0;
                
                if (data.ContainsKey("cust_row_type"))
                    cust_row_type = data["cust_row_type"].ToString();
                if (data.ContainsKey("cust_name"))
                    cust_name = data["cust_name"].ToString();
                if (data.ContainsKey("rec_company_id"))
                    company_id = int.Parse(data["rec_company_id"].ToString()!);
                if (company_id == 0)
                    throw new Exception("Company Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mast_customerm> query = context.mast_customerm
                    .Include(e => e.customer);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.cust_row_type == cust_row_type);

                if (!Lib.IsBlank(cust_name))
                    query = query.Where(w => w.cust_name!.Contains(cust_name!));

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
                    .OrderBy(c => c.cust_name)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_customerm_dto
                {
                    cust_id = e.cust_id,
                    cust_type = e.cust_type,
                    cust_code = e.cust_code,
                    cust_short_name = e.cust_short_name,
                    cust_name = e.cust_name,
                    cust_official_name = e.cust_official_name,
                    cust_address1 = e.cust_address1,
                    cust_address2 = e.cust_address3,
                    cust_address3 = e.cust_address3,
                    cust_city = e.cust_city,
                    cust_state_id = e.cust_state_id,
                    cust_state_code = e.state!.param_code,
                    cust_state_name = e.cust_state_name,
                    cust_country_id = e.cust_country_id,
                    cust_country_code = e.country!.param_code,
                    cust_country_name = e.cust_country_name,
                    cust_zip_code = e.cust_zip_code,
                    cust_contact = e.cust_contact,
                    cust_title = e.cust_title,
                    cust_tel = e.cust_tel,
                    cust_fax = e.cust_fax,
                    cust_mobile = e.cust_mobile,
                    cust_web = e.cust_web,
                    cust_email = e.cust_email,
                    cust_refer_by = e.cust_refer_by,            
                    cust_salesman_id = e.cust_salesman_id,
                    cust_salesman_name = e.salesman!.param_name,
                    cust_handled_id = e.cust_handled_id,
                    cust_handled_name = e.handled!.param_name,
                    cust_location = e.cust_location,
                    cust_row_type = e.customer!.cust_row_type,
                    cust_is_parent = e.customer.cust_is_parent,
                    cust_parent_name = e.customer.cust_name,

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
        public async Task<mast_customerm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<mast_customerm> query = context.mast_customerm
                    .Include(e => e.customer);

                query = query.Where(f => f.cust_id == id);

                var Record = await query.Select(e => new mast_customerm_dto
                {
                    cust_id = e.cust_id,
                    cust_type = e.cust_type,
                    cust_code = e.cust_code,
                    cust_short_name = e.cust_short_name,
                    cust_name = e.cust_name,
                    cust_official_name = e.cust_official_name,
                    cust_address1 = e.cust_address1,
                    cust_address2 = e.cust_address3,
                    cust_address3 = e.cust_address3,
                    cust_city = e.cust_city,
                    cust_state_id = e.cust_state_id,
                    cust_state_code = e.state!.param_code,
                    cust_state_name = e.cust_state_name,
                    cust_country_id = e.cust_country_id,
                    cust_country_code = e.country!.param_code,
                    cust_country_name = e.cust_country_name,
                    cust_zip_code = e.cust_zip_code,
                    cust_contact = e.cust_contact,
                    cust_title = e.cust_title,
                    cust_tel = e.cust_tel,
                    cust_fax = e.cust_fax,
                    cust_mobile = e.cust_mobile,
                    cust_web = e.cust_web,
                    cust_email = e.cust_email,
                    cust_refer_by = e.cust_refer_by,            
                    cust_salesman_id = e.cust_salesman_id,
                    cust_salesman_name = e.salesman!.param_name,
                    cust_handled_id = e.cust_handled_id,
                    cust_handled_name = e.handled!.param_name,
                    cust_location = e.cust_location,

                    cust_row_type = e.customer!.cust_row_type,
                    cust_is_parent = e.customer.cust_is_parent,
                    cust_credit_limit = e.cust_credit_limit,

                    cust_est_dt = Lib.FormatDate(e.cust_est_dt, Lib.outputDateFormat),

                    rec_version = e.rec_version,
                    cust_parent_id = e.cust_parent_id,
                    cust_parent_name = e.customer!.cust_name,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                Record.cust_contacts = await GetContactsAsync(Record.cust_id);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<mast_contactm_dto>> GetContactsAsync(int cust_id)
        {
            var query = from e in context.mast_contactm
                        .Where(a => a.cont_parent_id == cust_id)
                        .OrderBy(o => o.cont_id)
                        select (new mast_contactm_dto
                        {
                            cont_id = e.cont_id,
                            cont_parent_id = e.cont_parent_id,
                            cont_title = e.cont_title,
                            cont_name = e.cont_name,
                            cont_designation = e.cont_designation,
                            cont_email = e.cont_email,
                            cont_tel = e.cont_tel,
                            cont_mobile = e.cont_mobile,
                            cont_remarks = e.cont_remarks,
                            cont_country_id = e.cont_country_id,
                            cont_country_code = e.country!.param_code,
                            cont_country_name = e.country.param_name,
                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        });

            var records = await query.ToListAsync();

            return records;
        }


        public async Task<mast_customerm_dto> SaveAsync(int id, string mode, mast_customerm_dto record_dto)
        {
            try
            {
                context.Database.BeginTransaction();
                record_dto = await SaveParentAsync(id, mode, record_dto);
                record_dto = await saveContactAsync(id, record_dto);
                record_dto.cust_contacts = await GetContactsAsync(id);

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


        private Boolean AllValid(string mode, mast_customerm_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            string title = "";
            string name = "";
            string email = "";
            string country = "";

            if (Lib.IsBlank(record_dto.cust_code))
                str += "Code Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.cust_name))
                str += "Name Cannot Be Blank!";
            if (Lib.IsZero(record_dto.cust_parent_id))
                str += "Parent Cannot Be Blank!";

            foreach (mast_contactm_dto rec in record_dto.cust_contacts!)
            {
                if (Lib.IsBlank(rec.cont_title))
                    title = "Title Cannot Be Blank!";
                if (Lib.IsBlank(rec.cont_name))
                    name = "Name Cannot Be Blank!";
                if (Lib.IsBlank(rec.cont_email))
                    email = "Email Cannot Be Blank!";
                if (Lib.IsZero(rec.cont_country_id))
                    email = "Country Name Cannot Be Blank!";
            }
            if (title != "")
                str += title;
            if (name != "")
                str += name;
            if (email != "")
                str += email;
            if (country != "")
                str += country;

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }

        public async Task<mast_customerm_dto> SaveParentAsync(int id, string mode, mast_customerm_dto record_dto)
        {
            mast_customerm? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found To Save");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    Record = new mast_customerm();
                    Record.cust_id = record_dto.cust_id;
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.mast_customerm
                        .Where(f => f.cust_id == record_dto.cust_id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                Record.cust_type = record_dto.cust_type;
                Record.cust_code = record_dto.cust_code;
                Record.cust_short_name = record_dto.cust_short_name;
                Record.cust_name = record_dto.cust_name;
                Record.cust_official_name = record_dto.cust_official_name;
                Record.cust_address1 = record_dto.cust_address1;
                Record.cust_address2 = record_dto.cust_address2;
                Record.cust_address3 = record_dto.cust_address3;
                Record.cust_city =record_dto.cust_city;
                Record.cust_state_id = record_dto.cust_state_id;
                Record.cust_state_name = record_dto.cust_state_name;
                Record.cust_country_id = record_dto.cust_country_id;
                Record.cust_country_name = record_dto.cust_country_name;
                
                Record.cust_zip_code =record_dto.cust_zip_code;
                Record.cust_contact =record_dto.cust_contact;
                Record.cust_title =record_dto.cust_title;
                Record.cust_tel =record_dto.cust_tel;
                Record.cust_fax =record_dto.cust_fax;
                Record.cust_mobile =record_dto.cust_mobile;
                Record.cust_web =record_dto.cust_web;
                Record.cust_email =record_dto.cust_email;
                Record.cust_refer_by =record_dto.cust_refer_by;
                Record.cust_salesman_id =record_dto.cust_salesman_id;
                Record.cust_salesman_name =record_dto.cust_salesman_name;
                Record.cust_handled_id =record_dto.cust_handled_id;
                Record.cust_handled_name =record_dto.cust_handled_name;
                Record.cust_location =record_dto.cust_location;


                Record.cust_row_type = record_dto.cust_row_type;

                Record.cust_credit_limit = record_dto.cust_credit_limit ?? 0;

                Record.cust_est_dt = Lib.ParseDate(record_dto.cust_est_dt!);

                Record.cust_parent_id = record_dto.cust_parent_id;

                Record.cust_is_parent = "N";
                if (record_dto.cust_id == record_dto.cust_parent_id)
                    Record.cust_is_parent = "Y";

                if (mode == "add")
                    await context.mast_customerm.AddAsync(Record);


                await context.SaveChangesAsync();

                record_dto.cust_id = Record.cust_id;
                record_dto.rec_version = Record.rec_version;
                Lib.AssignDates2DTO(record_dto.cust_id, mode, Record, record_dto);
                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "uq", "cust_code", "Code Duplication");
                Lib.getErrorMessage(Ex, "uq", "cust_short_name", "Short Name Duplication");
                Lib.getErrorMessage(Ex, "uq", "cust_name", "Name Duplication");
                throw;
            }

        }

        public async Task<mast_customerm_dto> saveContactAsync(int id, mast_customerm_dto record_dto)
        {
            mast_contactm? record;
            List<mast_contactm_dto> records_dto;
            List<mast_contactm> records;
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                // get contacts from the front end
                records_dto = record_dto.cust_contacts!;
                // read the contact details from database
                records = await context.mast_contactm
                    .Where(w => w.cont_parent_id == id)
                    .ToListAsync();

                // Remove Deleted Records
                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.cont_id == existing_record.cont_id);
                    if (rec == null)
                        context.mast_contactm.Remove(existing_record);
                }

                //Add or Edit Records 
                foreach (var rec in records_dto)
                {
                    // if cont_id is zero it is a new record
                    if (rec.cont_id == 0)
                    {
                        record = new mast_contactm();
                        record.rec_company_id = record_dto.rec_company_id;
                        record.rec_created_by = record_dto.rec_created_by;
                        record.rec_created_date = DbLib.GetDateTime();
                        record.rec_locked = "N";
                    }
                    else
                    {
                        record = records.Find(f => f.cont_id == rec.cont_id);
                        if (record == null)
                            throw new Exception("Detail Record Not Found " + rec.cont_id.ToString());
                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }
                    record.cont_parent_id = id;
                    record.cont_title = rec.cont_title;
                    record.cont_name = rec.cont_name;
                    record.cont_designation = rec.cont_designation;
                    record.cont_email = rec.cont_email;
                    record.cont_tel = rec.cont_tel;
                    record.cont_mobile = rec.cont_mobile;
                    record.cont_remarks = rec.cont_remarks;
                    record.cont_country_id = rec.cont_country_id;

                    if (rec.cont_id == 0)
                        await context.mast_contactm.AddAsync(record);
                }
                context.SaveChanges();
                return record_dto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_customerm
                    .FirstOrDefaultAsync(f => f.cust_id == id);
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
                Lib.getErrorMessage(Ex, "fk", "cust_parent_id", "Child Company Exists");
                throw;
            }
        }

    }
}
