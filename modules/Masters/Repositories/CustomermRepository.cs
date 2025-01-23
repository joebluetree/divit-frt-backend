﻿using Database;
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
                    cust_address2 = e.cust_address2,
                    cust_address3 = e.cust_address3,
                    cust_city = e.cust_city,
                    cust_state_id = e.cust_state_id,
                    cust_state_name = e.state!.param_name,
                    cust_country_id = e.cust_country_id,
                    cust_country_name = e.country!.param_name,
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
                    cust_is_parent = e.cust_is_parent,
                    cust_parent_name = e.cust_name,

                    cust_is_shipper = e.cust_is_shipper,
                    cust_is_consignee = e.cust_is_consignee,
                    cust_is_importer = e.cust_is_importer,
                    cust_is_exporter = e.cust_is_exporter,
                    cust_is_cha = e.cust_is_cha,
                    cust_is_forwarder = e.cust_is_forwarder,
                    cust_is_oagent = e.cust_is_oagent,
                    cust_is_acarrier = e.cust_is_acarrier,
                    cust_is_scarrier = e.cust_is_scarrier,
                    cust_is_trucker = e.cust_is_trucker,
                    cust_is_warehouse = e.cust_is_warehouse,
                    cust_is_sterminal = e.cust_is_sterminal,
                    cust_is_aterminal = e.cust_is_aterminal,
                    cust_is_shipvendor = e.cust_is_shipvendor,
                    cust_is_gvendor = e.cust_is_gvendor,
                    cust_is_employee = e.cust_is_employee,
                    cust_is_contract = e.cust_is_contract,
                    cust_is_miscell = e.cust_is_miscell,
                    cust_is_tbd = e.cust_is_tbd,
                    cust_is_bank = e.cust_is_bank,

                    cust_nomination = e.cust_nomination,
                    cust_priority = e.cust_priority,
                    cust_criteria = e.cust_criteria,
                    cust_min_profit = e.cust_min_profit,
                    cust_firm_code = e.cust_firm_code,
                    cust_einirsno = e.cust_einirsno,
                    cust_days = e.cust_days,
                    cust_is_splacc = e.cust_is_splacc,
                    cust_is_actual_vendor = e.cust_is_actual_vendor,
                    cust_is_blackacc = e.cust_is_blackacc,
                    cust_splacc_memo = e.cust_splacc_memo,
                    cust_is_ctpat = e.cust_is_ctpat,
                    cust_ctpat_no = e.cust_ctpat_no,
                    cust_marketing_mail = e.cust_marketing_mail,

                    cust_chb_id = e.cust_chb_id,
                    cust_chb_code = e.customer!.cust_code,
                    cust_chb_name = e.cust_chb_name,
                    cust_chb_address1 = e.cust_chb_address1,
                    cust_chb_address2 = e.cust_chb_address2,
                    cust_chb_address3 = e.cust_chb_address3,
                    cust_chb_group = e.cust_chb_group,
                    cust_chb_contact = e.cust_chb_contact,
                    cust_chb_tel = e.cust_chb_tel,
                    cust_chb_fax = e.cust_chb_fax,
                    cust_chb_email = e.cust_chb_email,

                    cust_poa_customs_yn = e.cust_poa_customs_yn,
                    cust_brokers = e.cust_brokers,
                    cust_poa_isf_yn = e.cust_poa_isf_yn,
                    cust_bond_yn = e.cust_bond_yn,
                    cust_punch_from = e.cust_punch_from,
                    cust_bond_no = e.cust_bond_no,
                    cust_bond_expdt = Lib.FormatDate(e.cust_bond_expdt, Lib.outputDateFormat),

                    cust_branch = e.cust_branch,
                    cust_protected = e.cust_protected,
                    cust_cur_code = e.cust_cur_code,


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
                    cust_address2 = e.cust_address2,
                    cust_address3 = e.cust_address3,
                    cust_city = e.cust_city,
                    cust_state_id = e.cust_state_id,
                    cust_state_name = e.state!.param_name,
                    cust_country_id = e.cust_country_id,
                    cust_country_name = e.country!.param_name,
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

                    cust_is_shipper = e.cust_is_shipper,
                    cust_is_consignee = e.cust_is_consignee,
                    cust_is_importer = e.cust_is_importer,
                    cust_is_exporter = e.cust_is_exporter,
                    cust_is_cha = e.cust_is_cha,
                    cust_is_forwarder = e.cust_is_forwarder,
                    cust_is_oagent = e.cust_is_oagent,
                    cust_is_acarrier = e.cust_is_acarrier,
                    cust_is_scarrier = e.cust_is_scarrier,
                    cust_is_trucker = e.cust_is_trucker,
                    cust_is_warehouse = e.cust_is_warehouse,
                    cust_is_sterminal = e.cust_is_sterminal,
                    cust_is_aterminal = e.cust_is_aterminal,
                    cust_is_shipvendor = e.cust_is_shipvendor,
                    cust_is_gvendor = e.cust_is_gvendor,
                    cust_is_employee = e.cust_is_employee,
                    cust_is_contract = e.cust_is_contract,
                    cust_is_miscell = e.cust_is_miscell,
                    cust_is_tbd = e.cust_is_tbd,
                    cust_is_bank = e.cust_is_bank,

                    cust_nomination = e.cust_nomination,
                    cust_priority = e.cust_priority,
                    cust_criteria = e.cust_criteria,
                    cust_min_profit = e.cust_min_profit,
                    cust_firm_code = e.cust_firm_code,
                    cust_einirsno = e.cust_einirsno,
                    cust_days = e.cust_days,
                    cust_is_splacc = e.cust_is_splacc,
                    cust_is_actual_vendor = e.cust_is_actual_vendor,
                    cust_is_blackacc = e.cust_is_blackacc,
                    cust_splacc_memo = e.cust_splacc_memo,
                    cust_is_ctpat = e.cust_is_ctpat,
                    cust_ctpat_no = e.cust_ctpat_no,
                    cust_marketing_mail = e.cust_marketing_mail,

                    cust_chb_id = e.cust_chb_id,
                    cust_chb_code = e.customer!.cust_code,
                    cust_chb_name = e.cust_chb_name,
                    cust_chb_address1 = e.cust_chb_address1,
                    cust_chb_address2 = e.cust_chb_address2,
                    cust_chb_address3 = e.cust_chb_address3,
                    cust_chb_group = e.cust_chb_group,
                    cust_chb_contact = e.cust_chb_contact,
                    cust_chb_tel = e.cust_chb_tel,
                    cust_chb_fax = e.cust_chb_fax,
                    cust_chb_email = e.cust_chb_email,

                    cust_poa_customs_yn = e.cust_poa_customs_yn,
                    cust_brokers = e.cust_brokers,
                    cust_poa_isf_yn = e.cust_poa_isf_yn,
                    cust_bond_yn = e.cust_bond_yn,
                    cust_punch_from = e.cust_punch_from,
                    cust_bond_no = e.cust_bond_no,
                    cust_bond_expdt = Lib.FormatDate(e.cust_bond_expdt, Lib.outputDateFormat),

                    cust_branch = e.cust_branch,
                    cust_protected = e.cust_protected,
                    cust_cur_code = e.cust_cur_code,

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

        public async Task<List<mast_contactm_dto>> GetContactsAsync(int id)
        {
            var query = from e in context.mast_contactm
                        .Where(a => a.cont_parent_id == id)
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
                mast_customerm_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await saveContactAsync(_Record.cust_id, _Record);
                _Record.cust_contacts = await GetContactsAsync(_Record.cust_id);
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
                    country = "Country Name Cannot Be Blank!";
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

        // to add cust_type value when selected
        public string GetCustomerType(mast_customerm_dto record_dto)
        {
            var custTypeMapping = new Dictionary<string, string>
            {
                { "Shipper", "S" },
                { "Consignee", "C" },
                { "Importer", "I" },
                { "Exporter", "X" },
                { "Customs Broker", "B" },
                { "Domestic Forwarder", "F" },
                { "Overseas Agent", "A" },
                { "Air Carrier", "L" },
                { "Sea Carrier", "R" },
                { "Trucker", "T" },
                { "Warehouse", "W" },
                { "Terminal Sea / Rail", "N" },
                { "Terminal Air", "P" },
                { "Shipping Vendor", "H" },
                { "General Vendor", "V" },
                { "Employees", "E" },
                { "Contractor", "O" },
                { "Miscellaneous", "M" },
                { "TBD", "D" },
                { "Bank / Financial Institute", "K" }
            };
            var custTypes = new List<string>();

            if (record_dto.cust_is_shipper == "Y") custTypes.Add("Shipper");
            if (record_dto.cust_is_consignee == "Y") custTypes.Add("Consignee");
            if (record_dto.cust_is_importer == "Y") custTypes.Add("Importer");
            if (record_dto.cust_is_exporter == "Y") custTypes.Add("Exporter");
            if (record_dto.cust_is_cha == "Y") custTypes.Add("Customs Broker");
            if (record_dto.cust_is_forwarder == "Y") custTypes.Add("Domestic Forwarder");
            if (record_dto.cust_is_oagent == "Y") custTypes.Add("Overseas Agent");
            if (record_dto.cust_is_acarrier == "Y") custTypes.Add("Air Carrier");
            if (record_dto.cust_is_scarrier == "Y") custTypes.Add("Sea Carrier");
            if (record_dto.cust_is_trucker == "Y") custTypes.Add("Trucker");
            if (record_dto.cust_is_warehouse == "Y") custTypes.Add("Warehouse");
            if (record_dto.cust_is_sterminal == "Y") custTypes.Add("Terminal Sea / Rail");
            if (record_dto.cust_is_aterminal == "Y") custTypes.Add("Terminal Air");
            if (record_dto.cust_is_shipvendor == "Y") custTypes.Add("Shipping Vendor");
            if (record_dto.cust_is_gvendor == "Y") custTypes.Add("General Vendor");
            if (record_dto.cust_is_employee == "Y") custTypes.Add("Employees");
            if (record_dto.cust_is_contract == "Y") custTypes.Add("Contractor");
            if (record_dto.cust_is_miscell == "Y") custTypes.Add("Miscellaneous");
            if (record_dto.cust_is_tbd == "Y") custTypes.Add("TBD");
            if (record_dto.cust_is_bank == "Y") custTypes.Add("Bank / Financial Institute");

            return string.Join("", custTypes.Select(type => custTypeMapping[type]));
        }


        public async Task<mast_customerm_dto> SaveParentAsync(int id, string mode, mast_customerm_dto record_dto)
        {
            mast_customerm? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

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
                        .Where(f => f.cust_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                string cust_type = GetCustomerType(record_dto);
                Record.cust_type = cust_type;
                Record.cust_code = record_dto.cust_code;
                Record.cust_short_name = record_dto.cust_short_name;
                Record.cust_name = record_dto.cust_name;
                Record.cust_official_name = record_dto.cust_official_name;
                Record.cust_address1 = record_dto.cust_address1;
                Record.cust_address2 = record_dto.cust_address2;
                Record.cust_address3 = record_dto.cust_address3;
                Record.cust_city = record_dto.cust_city;
                if (Lib.IsZero(record_dto.cust_state_id))
                    Record.cust_state_id = null;
                else
                    Record.cust_state_id = record_dto.cust_state_id;
                Record.cust_state_name = record_dto.cust_state_name;
                if (Lib.IsZero(record_dto.cust_country_id))
                    Record.cust_country_id = null;
                else
                    Record.cust_country_id = record_dto.cust_country_id;
                Record.cust_country_name = record_dto.cust_country_name;

                Record.cust_zip_code = record_dto.cust_zip_code;
                Record.cust_contact = record_dto.cust_contact;
                Record.cust_title = record_dto.cust_title;
                Record.cust_tel = record_dto.cust_tel;
                Record.cust_fax = record_dto.cust_fax;
                Record.cust_mobile = record_dto.cust_mobile;
                Record.cust_web = record_dto.cust_web;
                Record.cust_email = record_dto.cust_email;
                Record.cust_refer_by = record_dto.cust_refer_by;
                if (Lib.IsZero(record_dto.cust_salesman_id))
                    Record.cust_salesman_id = null;
                else
                    Record.cust_salesman_id = record_dto.cust_salesman_id;
                Record.cust_salesman_name = record_dto.cust_salesman_name;
                if (Lib.IsZero(record_dto.cust_handled_id))
                    Record.cust_handled_id = null;
                else
                    Record.cust_handled_id = record_dto.cust_handled_id;
                Record.cust_handled_name = record_dto.cust_handled_name;
                Record.cust_location = record_dto.cust_location;
                Record.cust_is_shipper = record_dto.cust_is_shipper;
                Record.cust_is_consignee = record_dto.cust_is_consignee;
                Record.cust_is_importer = record_dto.cust_is_importer;
                Record.cust_is_exporter = record_dto.cust_is_exporter;
                Record.cust_is_cha = record_dto.cust_is_cha;
                Record.cust_is_forwarder = record_dto.cust_is_forwarder;
                Record.cust_is_oagent = record_dto.cust_is_oagent;
                Record.cust_is_acarrier = record_dto.cust_is_acarrier;
                Record.cust_is_scarrier = record_dto.cust_is_scarrier;
                Record.cust_is_trucker = record_dto.cust_is_trucker;
                Record.cust_is_warehouse = record_dto.cust_is_warehouse;
                Record.cust_is_sterminal = record_dto.cust_is_sterminal;
                Record.cust_is_aterminal = record_dto.cust_is_aterminal;
                Record.cust_is_shipvendor = record_dto.cust_is_shipvendor;
                Record.cust_is_gvendor = record_dto.cust_is_gvendor;
                Record.cust_is_employee = record_dto.cust_is_employee;
                Record.cust_is_contract = record_dto.cust_is_contract;
                Record.cust_is_miscell = record_dto.cust_is_miscell;
                Record.cust_is_tbd = record_dto.cust_is_tbd;
                Record.cust_is_bank = record_dto.cust_is_bank;

                Record.cust_nomination = record_dto.cust_nomination;
                Record.cust_priority = record_dto.cust_priority;
                Record.cust_criteria = record_dto.cust_criteria;
                Record.cust_min_profit = record_dto.cust_min_profit;
                Record.cust_firm_code = record_dto.cust_firm_code;
                Record.cust_einirsno = record_dto.cust_einirsno;
                Record.cust_days = record_dto.cust_days;
                Record.cust_is_splacc = record_dto.cust_is_splacc;
                Record.cust_is_actual_vendor = record_dto.cust_is_actual_vendor;
                Record.cust_is_blackacc = record_dto.cust_is_blackacc;
                Record.cust_splacc_memo = record_dto.cust_splacc_memo;
                Record.cust_is_ctpat = record_dto.cust_is_ctpat;
                Record.cust_ctpat_no = record_dto.cust_ctpat_no;
                Record.cust_marketing_mail = record_dto.cust_marketing_mail;

                Record.cust_chb_id = record_dto.cust_chb_id;
                Record.cust_chb_name = record_dto.cust_chb_name;
                Record.cust_chb_address1 = record_dto.cust_chb_address1;
                Record.cust_chb_address2 = record_dto.cust_chb_address2;
                Record.cust_chb_address3 = record_dto.cust_chb_address3;
                Record.cust_chb_group = record_dto.cust_chb_group;
                Record.cust_chb_contact = record_dto.cust_chb_contact;
                Record.cust_chb_tel = record_dto.cust_chb_tel;
                Record.cust_chb_fax = record_dto.cust_chb_fax;
                Record.cust_chb_email = record_dto.cust_chb_email;

                Record.cust_poa_customs_yn = record_dto.cust_poa_customs_yn;
                Record.cust_brokers = record_dto.cust_brokers;
                Record.cust_poa_isf_yn = record_dto.cust_poa_isf_yn;
                Record.cust_bond_yn = record_dto.cust_bond_yn;
                Record.cust_punch_from = record_dto.cust_punch_from;
                Record.cust_bond_no = record_dto.cust_bond_no;
                Record.cust_bond_expdt = Lib.ParseDate(record_dto.cust_bond_expdt!);

                Record.cust_branch = record_dto.cust_branch;
                Record.cust_protected = record_dto.cust_protected;
                Record.cust_cur_code = record_dto.cust_cur_code;

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
                    var _Contact = context.mast_contactm
                    .Where(c => c.cont_parent_id == id);
                    if (_Contact.Any())
                    {
                        context.mast_contactm.RemoveRange(_Contact);

                    }
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
