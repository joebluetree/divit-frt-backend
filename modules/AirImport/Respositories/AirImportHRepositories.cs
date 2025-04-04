using Database;
using Database.Lib;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.BaseTables;
using Common.Lib;
using Database.Models.Cargo;
using Common.DTO.AirImport;
using Database.Models.UserAdmin;
using AirImport.Interfaces;

namespace AirImport.Repositories
{

    //Name : Alen Cherian
    //Date : 31/03/2025
    //Command :  Create Repository for the Air Import House.
    //version 1.0

    public class AirImportHRepository : IAirImportHRepository
    {

        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        string hbl_mode = "AIR IMPORT";


        public AirImportHRepository(AppDbContext _context, IAuditLog _auditLog)
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


                var hbl_houseno = "";
                var company_id = 0;
                var branch_id = 0;
                var hbl_from_date = "";
                var hbl_to_date = "";
                DateTime? from_date = null;
                DateTime? to_date = null;


                if (data.ContainsKey("hbl_houseno"))
                    hbl_houseno = data["hbl_houseno"].ToString();
                if (data.ContainsKey("hbl_from_date"))
                    hbl_from_date = data["hbl_from_date"].ToString();
                if (data.ContainsKey("hbl_to_date"))
                    hbl_to_date = data["hbl_to_date"].ToString();


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

                IQueryable<cargo_housem> query = context.cargo_housem;
                query = query.Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.hbl_mode == hbl_mode);

                if (!Lib.IsBlank(hbl_from_date))
                {
                    from_date = Lib.ParseDate(hbl_from_date!);
                    query = query.Where(w => w.hbl_date >= from_date);
                }
                if (!Lib.IsBlank(hbl_to_date))
                {
                    to_date = Lib.ParseDate(hbl_to_date!);
                    query = query.Where(w => w.hbl_date <= to_date);
                }
                if (!Lib.IsBlank(hbl_houseno))
                    query = query.Where(w => w.hbl_houseno!.Contains(hbl_houseno!));


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
                    .OrderBy(c => c.hbl_date)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_air_importh_dto
                {
                    hbl_id = e.hbl_id,
                    hbl_cfno = e.hbl_cfno,
                    hbl_mbl_id = e.hbl_mbl_id,
                    hbl_houseno = e.hbl_houseno,
                    hbl_mbl_refno = e.master!.mbl_refno,
                    hbl_shipment_stage_id = e.hbl_shipment_stage_id,
                    hbl_shipment_stage_name = e.shipstage!.param_name,
                    hbl_mode = e.hbl_mode,
                    hbl_shipper_id = e.hbl_shipper_id,
                    hbl_shipper_code = e.shipper!.cust_code,
                    hbl_shipper_name = e.shipper!.cust_name,
                    hbl_shipper_add1 = e.shipper!.cust_address1,
                    hbl_shipper_add2 = e.shipper!.cust_address2,
                    hbl_shipper_add3 = e.shipper!.cust_address3,
                    hbl_shipper_add4 = e.hbl_shipper_add4,
                    hbl_shipper_add5 = e.shipper!.cust_tel,
                    hbl_consignee_id = e.hbl_consignee_id,
                    hbl_consignee_code = e.consignee!.cust_code,
                    hbl_consignee_name = e.hbl_consignee_name,
                    hbl_consignee_add1 = e.hbl_consignee_add1,
                    hbl_consignee_add2 = e.hbl_consignee_add2,
                    hbl_consignee_add3 = e.hbl_consignee_add3,
                    hbl_consignee_add4 = e.hbl_consignee_add4,
                    hbl_consignee_add5 = e.hbl_consignee_add5,

                    hbl_agent_name = e.hbl_agent_name,
                    hbl_frt_status_name = e.hbl_frt_status_name,
                    hbl_packages = e.hbl_packages,

                    hbl_bltype = e.hbl_bltype,
                    hbl_handled_id = e.hbl_handled_id,
                    hbl_handled_name = e.handledby!.param_name,
                    hbl_salesman_id = e.hbl_salesman_id,
                    hbl_salesman_name = e.salesman!.param_name,

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

        public async Task<cargo_air_importh_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_housem> query = context.cargo_housem;

                query = query.Where(f => f.hbl_id == id && f.hbl_mode == hbl_mode);


                var Record = await query.Select(e => new cargo_air_importh_dto
                {

                    hbl_id = e.hbl_id,
                    hbl_mbl_id = e.hbl_mbl_id,
                    hbl_houseno = e.hbl_houseno,
                    hbl_mbl_refno = e.master!.mbl_refno,
                    hbl_shipment_stage_id = e.hbl_shipment_stage_id,
                    hbl_shipment_stage_name = e.shipstage!.param_name,
                    hbl_mode = e.hbl_mode,
                    hbl_shipper_id = e.hbl_shipper_id,
                    hbl_shipper_code = e.shipper!.cust_code,
                    hbl_shipper_name = e.hbl_shipper_name,
                    hbl_shipper_add1 = e.hbl_shipper_add1,
                    hbl_shipper_add2 = e.hbl_shipper_add2,
                    hbl_shipper_add3 = e.hbl_shipper_add3,
                    hbl_shipper_add4 = e.hbl_shipper_add4,
                    hbl_shipper_add5 = e.hbl_shipper_add5,
                    hbl_consignee_id = e.hbl_consignee_id,
                    hbl_consignee_code = e.consignee!.cust_code,
                    hbl_consignee_name = e.hbl_consignee_name,
                    hbl_consignee_add1 = e.hbl_consignee_add1,
                    hbl_consignee_add2 = e.hbl_consignee_add2,
                    hbl_consignee_add3 = e.hbl_consignee_add3,
                    hbl_consignee_add4 = e.hbl_consignee_add4,
                    hbl_consignee_add5 = e.hbl_consignee_add5,
                    hbl_agent_id = e.hbl_agent_id,
                    hbl_agent_name = e.agent!.cust_name,

                    hbl_cha_id = e.hbl_cha_id,
                    hbl_cha_code = e.cha!.cust_code,
                    hbl_cha_name = e.hbl_cha_name,
                    hbl_cha_attn = e.hbl_cha_attn,
                    hbl_cha_tel = e.hbl_cha_tel,
                    hbl_cha_fax = e.hbl_cha_fax,
                    hbl_location_id = e.hbl_location_id,
                    hbl_location_code = e.location!.cust_code,
                    hbl_location_name = e.hbl_location_name,
                    hbl_location_add1 = e.hbl_location_add1,
                    hbl_location_add2 = e.hbl_location_add2,
                    hbl_location_add3 = e.hbl_location_add3,
                    hbl_location_add4 = e.hbl_location_add4,
                    hbl_frt_status_name = e.hbl_frt_status_name,
                    hbl_uom_id = e.hbl_uom_id,
                    hbl_uom_name = e.packageunit!.param_name,
                    hbl_packages = e.hbl_packages,
                    hbl_weight = e.hbl_weight,
                    hbl_lbs = e.hbl_lbs,
                    hbl_chwt_lbs = e.hbl_chwt_lbs,
                    hbl_chwt = e.hbl_chwt,
                    hbl_commodity = e.hbl_commodity,
                    hbl_handled_id = e.hbl_handled_id,
                    hbl_handled_name = e.handledby!.param_name,
                    hbl_salesman_id = e.hbl_salesman_id,
                    hbl_salesman_name = e.salesman!.param_name,

                    hbl_remark1 = e.hbl_remark1,
                    hbl_remark2 = e.hbl_remark2,
                    hbl_remark3 = e.hbl_remark3,
                    hbl_lfd_date = Lib.FormatDate(e.hbl_lfd_date, Lib.outputDateFormat),
                    hbl_pickup_date = Lib.FormatDate(e.hbl_pickup_date, Lib.outputDateFormat),
                    hbl_careof_id = e.hbl_careof_id,
                    hbl_careof_name = e.careof!.cust_name,
                    hbl_pono = e.hbl_pono,
                    hbl_paid_status_id = e.hbl_paid_status_id,
                    hbl_paid_status_name = e.paidstatus!.param_name,
                    hbl_cargo_release_status = e.hbl_cargo_release_status,
                    hbl_is_itshipment = e.hbl_is_itshipment,
                    hbl_book_slno = e.hbl_book_slno,
                    hbl_is_pl = e.hbl_is_pl,
                    hbl_is_ci = e.hbl_is_ci,
                    hbl_is_carr_an = e.hbl_is_carr_an,
                    hbl_custom_reles_status = e.hbl_custom_reles_status,
                    hbl_is_delivery = e.hbl_is_delivery,
                    hbl_paid_remarks = e.hbl_paid_remarks,
                    hbl_incoterm_id = e.hbl_incoterm_id,
                    hbl_incoterm = e.incoterm!.param_name,
                    hbl_invoiceno = e.hbl_invoiceno,

                    hbl_it_no = e.hbl_it_no,
                    hbl_it_no2 = e.hbl_it_no2,
                    hbl_it_no3 = e.hbl_it_no3,
                    hbl_it_date = Lib.FormatDate(e.hbl_it_date, Lib.outputDateFormat),
                    hbl_it_date2 = Lib.FormatDate(e.hbl_it_date2, Lib.outputDateFormat),
                    hbl_it_date3 = Lib.FormatDate(e.hbl_it_date3, Lib.outputDateFormat),
                    hbl_it_port = e.hbl_it_port,
                    hbl_it_port2 = e.hbl_it_port2,
                    hbl_it_port3 = e.hbl_it_port3,
                    hbl_it_pcs = e.hbl_it_pcs,
                    hbl_it_pcs2 = e.hbl_it_pcs2,
                    hbl_it_pcs3 = e.hbl_it_pcs3,
                    hbl_it_wt = e.hbl_it_wt,
                    hbl_it_wt2 = e.hbl_it_wt2,
                    hbl_it_wt3 = e.hbl_it_wt3,

                    hbl_bltype = e.hbl_bltype,
                    hbl_place_final = e.hbl_place_final,
                    hbl_plf_eta = Lib.FormatDate(e.hbl_plf_eta, Lib.outputDateFormat),
                    hbl_delivery_date = Lib.FormatDate(e.hbl_delivery_date, Lib.outputDateFormat),

                    rec_version = e.rec_version,
                    rec_company_id = e.rec_company_id,
                    rec_branch_id = e.rec_branch_id,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No House Found");

                await GetCargoDesc(Record);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task GetCargoDesc(cargo_air_importh_dto Record)
        {
            //setting initial value to null or new,
            for (int i = 1; i <= 17; i++)
            {
                Record.GetType().GetProperty($"marks{i}")?.SetValue(Record, new cargo_desc_dto());
            }

            // retriving from. db
            var records = await context.cargo_desc
                .Where(a => a.desc_parent_id == Record.hbl_id)
                .ToListAsync();

            foreach (var desc in records)
            {
                int? ctr = desc.desc_ctr;
                if (ctr <= 17)//is >= 1 and 
                {
                    var markGroup = new cargo_desc_dto
                    {
                        desc_id = desc.desc_id,
                        desc_parent_id = desc.desc_parent_id,
                        desc_parent_type = desc.desc_parent_type,
                        desc_ctr = desc.desc_ctr,
                        desc_mark = desc.desc_mark,
                        desc_package = desc.desc_package,
                        desc_description = desc.desc_description
                    };

                    Record.GetType().GetProperty($"marks{markGroup.desc_ctr}")?.SetValue(Record, markGroup);
                }
            }
        }

        public async Task<cargo_air_importh_dto?> GetDefaultDataAsync(int id)
        {
            try
            {
                var query = context.cargo_masterm
                    .Where(f => f.mbl_id == id && f.mbl_mode == hbl_mode);

                var Record = await query
                    .Select(e => new cargo_air_importh_dto
                    {
                        hbl_mbl_id = e.mbl_id,
                        hbl_mbl_refno = e.mbl_refno,
                        hbl_shipment_stage_id = e.mbl_shipment_stage_id,
                        hbl_shipment_stage_name = e.shipstage!.param_name,
                        hbl_agent_id = e.mbl_agent_id,
                        hbl_agent_name = e.agent!.cust_name,
                        hbl_location_id = e.mbl_cargo_loc_id,
                        hbl_location_code = e.cargoloc!.cust_code,
                        hbl_location_name = e.mbl_cargo_loc_name,
                        hbl_location_add1 = e.mbl_cargo_loc_add1,
                        hbl_location_add2 = e.mbl_cargo_loc_add2,
                        hbl_location_add3 = e.mbl_cargo_loc_add3,
                        hbl_location_add4 = e.mbl_cargo_loc_add4,
                        hbl_handled_id = e.mbl_handled_id,
                        hbl_handled_name = e.handledby!.param_name,
                        hbl_salesman_id = e.mbl_salesman_id,
                        hbl_salesman_name = e.salesman!.param_name,
                        rec_branch_id = e.rec_branch_id,
                        rec_company_id = e.rec_company_id,
                    })
                    .FirstOrDefaultAsync();


                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public async Task<cargo_air_importh_dto> SaveAsync(int id, string mode, cargo_air_importh_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_air_importh_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await SaveCargoDesc(_Record.hbl_id, mode, _Record);
                await CommonLib.SaveMasterSummary(this.context, _Record.hbl_mbl_id);
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

        private Boolean AllValid(string mode, cargo_air_importh_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";
            if (Lib.IsBlank(record_dto.hbl_houseno))
                str += "House Number Cannot Be Blank!";
            if (Lib.IsZero(record_dto.hbl_shipment_stage_id))
                str += "Shipment Stage To Cannot Be Blank!";
            if (Lib.IsZero(record_dto.hbl_shipper_id))
                str += "Shipper code Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.hbl_shipper_name))
                str += "Shipper name Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.hbl_shipper_add1))
                str += "Shipper Address1 Cannot Be Blank!";
            if (Lib.IsZero(record_dto.hbl_consignee_id))
                str += "Consignee code Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.hbl_consignee_name))
                str += "Consignee Name Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.hbl_consignee_add1))
                str += "Consignee Address1 Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.hbl_location_code))
                str += "Location detail Cannot Be Blank";
            if (Lib.IsZero(record_dto.hbl_agent_id))
                str += "Agent Details Cannot Be Blank";
            if (Lib.IsBlank(record_dto.hbl_place_final))
                str += "Final Destination Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.hbl_plf_eta))
                str += "Final Date Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.hbl_bltype))
                str += "Client.Type Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.hbl_frt_status_name))
                str += "Frt.Status Cannot Be Blank!";
            if (Lib.IsZero(record_dto.hbl_packages))
                str += "PCS Cannot Be Blank!";
            if (Lib.IsZero(record_dto.hbl_weight))
                str += "Weight Cannot Be Blank!";
            if (Lib.IsZero(record_dto.hbl_chwt))
                str += "CH.WT Cannot Be Blank!";
            if (Lib.IsZero(record_dto.hbl_lbs))
                str += "LBS can't be blank";
            if (Lib.IsZero(record_dto.hbl_chwt_lbs))
                str += "LBS can't be blank";
            if (Lib.IsBlank(record_dto.hbl_commodity))
                str += "Goods description can't be blank";


            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<cargo_air_importh_dto> SaveParentAsync(int id, string mode, cargo_air_importh_dto record_dto)
        {
            cargo_housem? Record;

            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                //Other Charges To Agent Details and concatenate values into a single string

                if (mode == "add")
                {

                    var DefaultCfNo = 0;

                    //Getting the Cfno from using the GetNextCfno() function
                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("House Number Cannot Be Generated");
                    }

                    Record = new cargo_housem();  //Assigning the values to the database elements
                    Record.hbl_cfno = iNextNo;
                    Record.hbl_mode = hbl_mode;
                    Record.hbl_mbl_id = record_dto.hbl_mbl_id;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    //code retrives the data from cargo_housem table in database

                    Record = await context.cargo_housem
                        .Include(c => c.shipper)
                        .Include(c => c.consignee)
                        .Include(c => c.agent)
                        .Include(c => c.cha)
                        .Include(c => c.packageunit)
                        .Include(c => c.incoterm)
                        .Include(c => c.careof)
                        .Include(c => c.shipstage)
                        .Include(c => c.handledby)
                        .Include(c => c.format)
                        .Include(c => c.location)
                        .Include(c => c.salesman)
                        .Include(c => c.paidstatus)
                        .Where(f => f.hbl_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    //concurency checking code by using rec_version
                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++; //incrementing the rec_version after the concurrency check
                    record_dto.rec_version = Record.rec_version; //asigning the rec_version value to the dto.
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                //Mode is edit, Then Check the LogHistory.
                if (mode == "edit")
                    await logHistory(Record, record_dto);

                //Save values to the database from dto.
                Record.hbl_houseno = record_dto.hbl_houseno;
                Record.hbl_shipment_stage_id = record_dto.hbl_shipment_stage_id;
                Record.hbl_shipper_id = record_dto.hbl_shipper_id;
                Record.hbl_shipper_name = record_dto.hbl_shipper_name;
                Record.hbl_shipper_add1 = record_dto.hbl_shipper_add1;
                Record.hbl_shipper_add2 = record_dto.hbl_shipper_add2;
                Record.hbl_shipper_add3 = record_dto.hbl_shipper_add3;
                Record.hbl_shipper_add4 = record_dto.hbl_shipper_add4;
                Record.hbl_shipper_add5 = record_dto.hbl_shipper_add5;
                Record.hbl_consignee_id = record_dto.hbl_consignee_id;
                Record.hbl_consignee_name = record_dto.hbl_consignee_name;
                Record.hbl_consignee_add1 = record_dto.hbl_consignee_add1;
                Record.hbl_consignee_add2 = record_dto.hbl_consignee_add2;
                Record.hbl_consignee_add3 = record_dto.hbl_consignee_add3;
                Record.hbl_consignee_add4 = record_dto.hbl_consignee_add4;
                Record.hbl_consignee_add5 = record_dto.hbl_consignee_add5;

                Record.hbl_agent_id = record_dto.hbl_agent_id;
                Record.hbl_agent_name = record_dto.hbl_agent_name;
                Record.hbl_cha_id = record_dto.hbl_cha_id;
                Record.hbl_cha_name = record_dto.hbl_cha_name;
                Record.hbl_cha_attn = record_dto.hbl_cha_attn;
                Record.hbl_cha_tel = record_dto.hbl_cha_tel;
                Record.hbl_cha_fax = record_dto.hbl_cha_fax;
                Record.hbl_location_id = record_dto.hbl_location_id;
                Record.hbl_location_name = record_dto.hbl_location_name;
                Record.hbl_location_add1 = record_dto.hbl_location_add1;
                Record.hbl_location_add2 = record_dto.hbl_location_add2;
                Record.hbl_location_add3 = record_dto.hbl_location_add3;
                Record.hbl_location_add4 = record_dto.hbl_location_add4;
                Record.hbl_frt_status_name = record_dto.hbl_frt_status_name;
                Record.hbl_uom_id = record_dto.hbl_uom_id;
                Record.hbl_packages = record_dto.hbl_packages;
                Record.hbl_weight = record_dto.hbl_weight;
                Record.hbl_lbs = record_dto.hbl_lbs;
                Record.hbl_chwt_lbs = record_dto.hbl_chwt_lbs;
                Record.hbl_chwt = record_dto.hbl_chwt;
                Record.hbl_commodity = record_dto.hbl_commodity;
                Record.hbl_handled_id = record_dto.hbl_handled_id;
                Record.hbl_salesman_id = record_dto.hbl_salesman_id;
                Record.hbl_remark1 = record_dto.hbl_remark1;
                Record.hbl_remark2 = record_dto.hbl_remark2;
                Record.hbl_remark3 = record_dto.hbl_remark3;
                Record.hbl_lfd_date = Lib.ParseDate(record_dto.hbl_lfd_date!);
                Record.hbl_pickup_date = Lib.ParseDate(record_dto.hbl_pickup_date!);
                Record.hbl_careof_id = record_dto.hbl_careof_id;
                Record.hbl_pono = record_dto.hbl_pono;
                Record.hbl_paid_status_id = record_dto.hbl_paid_status_id;
                Record.hbl_cargo_release_status = record_dto.hbl_cargo_release_status;
                Record.hbl_is_itshipment = record_dto.hbl_is_itshipment;
                Record.hbl_book_slno = record_dto.hbl_book_slno;
                Record.hbl_is_pl = record_dto.hbl_is_pl;
                Record.hbl_is_ci = record_dto.hbl_is_ci;
                Record.hbl_is_carr_an = record_dto.hbl_is_carr_an;
                Record.hbl_custom_reles_status = record_dto.hbl_custom_reles_status;
                Record.hbl_is_delivery = record_dto.hbl_is_delivery;
                Record.hbl_paid_remarks = record_dto.hbl_paid_remarks;
                Record.hbl_incoterm_id = record_dto.hbl_incoterm_id;
                Record.hbl_incoterm = record_dto.hbl_incoterm;
                Record.hbl_invoiceno = record_dto.hbl_invoiceno;
                Record.hbl_delivery_date = Lib.ParseDate(record_dto.hbl_delivery_date!);

                Record.hbl_it_no = record_dto.hbl_it_no;
                Record.hbl_it_no2 = record_dto.hbl_it_no2;
                Record.hbl_it_no3 = record_dto.hbl_it_no3;
                Record.hbl_it_date = Lib.ParseDate(record_dto.hbl_it_date!);
                Record.hbl_it_date2 = Lib.ParseDate(record_dto.hbl_it_date2!);
                Record.hbl_it_date3 = Lib.ParseDate(record_dto.hbl_it_date3!);
                Record.hbl_it_port = record_dto.hbl_it_port;
                Record.hbl_it_port2 = record_dto.hbl_it_port2;
                Record.hbl_it_port3 = record_dto.hbl_it_port3;
                Record.hbl_it_pcs = record_dto.hbl_it_pcs;
                Record.hbl_it_pcs2 = record_dto.hbl_it_pcs2;
                Record.hbl_it_pcs3 = record_dto.hbl_it_pcs3;
                Record.hbl_it_wt = record_dto.hbl_it_wt;
                Record.hbl_it_wt2 = record_dto.hbl_it_wt2;
                Record.hbl_it_wt3 = record_dto.hbl_it_wt3;

                Record.hbl_bltype = record_dto.hbl_bltype;
                Record.hbl_place_final = record_dto.hbl_place_final;
                Record.hbl_plf_eta = Lib.ParseDate(record_dto.hbl_plf_eta!);
                Record.hbl_delivery_date = Lib.ParseDate(record_dto.hbl_delivery_date!);
                //Mode = add, Then add values to the table cargo_housem.
                if (mode == "add")
                    await context.cargo_housem.AddAsync(Record);
                //Save changes to database
                context.SaveChanges();
                //After the save return values to the dto from database table.
                record_dto.hbl_id = Record.hbl_id;
                record_dto.hbl_houseno = Record.hbl_houseno;
                record_dto.hbl_mbl_id = Record.hbl_mbl_id;

                record_dto.rec_version = Record.rec_version;

                if (mode == "add")
                {
                    record_dto.rec_created_by = Record.rec_created_by;
                    record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                }
                if (mode == "edit")
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }

                return record_dto;
            }
            catch (Exception)
            {
                throw;
            }

        }


        //function for save description
        public async Task<cargo_air_importh_dto> SaveCargoDesc(int id, string mode, cargo_air_importh_dto record_dto)
        {
            try
            {
                // List to store marks for simplified iteration
                var marks = new List<cargo_desc_dto?>
                {
                    record_dto.marks1, record_dto.marks2, record_dto.marks3, record_dto.marks4, record_dto.marks5,
                    record_dto.marks6, record_dto.marks7, record_dto.marks8, record_dto.marks9, record_dto.marks10,
                    record_dto.marks11, record_dto.marks12, record_dto.marks13, record_dto.marks14, record_dto.marks15,
                    record_dto.marks16, record_dto.marks17
                };


                // Save all marks using the updated SaveMarksandDesc function
                await SaveMarksandNumbers(id, mode, marks, record_dto);
                return record_dto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in SaveCargoDesc: {ex.Message}", ex);
            }
        }


        public async Task<cargo_air_importh_dto> SaveMarksandNumbers(int id, string mode, List<cargo_desc_dto?> marks, cargo_air_importh_dto record_dto)
        {
            cargo_desc? Record;
            string DescMode = "";
            int? ctr = 0;

            try
            {
                if (marks == null || marks.Count == 0)
                    throw new Exception("No Marks and Numbers Found");

                foreach (var markItem in marks)
                {
                    Boolean bOk = true;

                    if (markItem == null)
                    {
                        throw new Exception("Invalid marks and nos : " + ctr);
                    }

                    ctr++;
                    var desc_id = markItem.desc_id;
                    var mark = markItem.desc_mark;
                    var description = markItem.desc_description;

                    if (Lib.IsBlank(mark) && Lib.IsBlank(description))
                        bOk = false;
                    if (bOk == false && desc_id == 0)
                    {
                        continue;
                    }

                    if (bOk && desc_id == 0)  // new record && id!=0
                        DescMode = "add";
                    if (bOk && desc_id != 0)  // edit record                  
                        DescMode = "edit";
                    if (bOk == false && desc_id != 0)  // delete record                 
                        DescMode = "delete";

                    var NewRecord_dto = new cargo_desc_dto
                    {
                        desc_parent_id = record_dto.desc_parent_id,
                        desc_id = desc_id,
                        desc_ctr = ctr,
                        desc_mark = mark,
                        desc_description = description,
                        rec_company_id = record_dto.rec_company_id,
                        rec_branch_id = record_dto.rec_branch_id,
                        rec_created_by = record_dto.rec_created_by,
                        rec_version = record_dto.rec_version,
                    };

                    if (DescMode == "add")
                    {
                        Record = new cargo_desc();

                        Record.rec_company_id = record_dto.rec_company_id;
                        Record.rec_branch_id = record_dto.rec_branch_id;
                        Record.rec_created_by = record_dto.rec_created_by;
                        Record.rec_created_date = DbLib.GetDateTime();
                        Record.rec_version = record_dto.rec_version;
                        Record.rec_locked = "N";

                        Record.desc_parent_type = "AE-DESC";
                        Record.desc_parent_id = id;

                        if (mode == "edit")
                            await logHistoryCargoDesc(Record, NewRecord_dto, record_dto.hbl_houseno!, record_dto.hbl_id, ctr);

                        Record.desc_ctr = ctr;
                        Record.desc_mark = mark;
                        Record.desc_description = description;

                    }
                    else
                    {
                        Record = await context.cargo_desc
                            .Where(f => f.desc_parent_id == id && f.desc_id == desc_id)
                            .FirstOrDefaultAsync();

                        if (Record == null)
                            throw new Exception("Description record Not Found " + ctr);

                        if (DescMode == "edit" || DescMode == "delete")
                        {
                            await logHistoryCargoDesc(Record, NewRecord_dto, record_dto.hbl_houseno!, record_dto.hbl_id, ctr);

                            Record.desc_mark = NewRecord_dto.desc_mark;
                            Record.desc_description = NewRecord_dto.desc_description;

                            // context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                            Record.rec_version = record_dto.rec_version;
                            Record.rec_edited_by = record_dto.rec_created_by;
                            Record.rec_edited_date = DbLib.GetDateTime();
                        }
                    }

                    if (DescMode == "add")
                        await context.cargo_desc.AddAsync(Record);

                    if (DescMode == "delete")
                    {
                        context.cargo_desc.Remove(Record);
                        desc_id = 0;
                        Record.desc_ctr = 0;
                        Record.desc_parent_id = 0;
                        Record.desc_parent_type = "";
                    }

                    await context.SaveChangesAsync();

                    if (DescMode == "add")
                        desc_id = Record.desc_id;

                    markItem.desc_id = desc_id;
                    markItem.desc_ctr = Record.desc_ctr;
                    markItem.desc_parent_id = Record.desc_parent_id;
                    markItem.desc_parent_type = Record.desc_parent_type;

                }
                return record_dto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in saving marks and descriptions: {ex.Message}");
            }
        }




        public int GetNextCfNo(int company_id, int? branch_id, int DefaultCfNo)
        {
            var CfNo = context.cargo_housem
                .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.hbl_mode == hbl_mode)
                .Select(e => e.hbl_cfno)
                .DefaultIfEmpty()
                .Max();

            CfNo = CfNo == 0 ? DefaultCfNo : CfNo + 1;
            return CfNo;
        }


        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_housem
                    .Where(f => f.hbl_id == id)
                    .FirstOrDefaultAsync();
                var mbl_id = _Record?.hbl_mbl_id;

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    var desc = context.cargo_desc
                        .Where(c => c.desc_parent_id == id);
                    if (desc.Any())
                    {
                        context.cargo_desc.RemoveRange(desc);
                    }
                    context.Remove(_Record);
                    context.SaveChanges();
                    await CommonLib.SaveMasterSummary(this.context, mbl_id);
                    RetData.Add("status", true);
                    RetData.Add("message", "");
                }
                return RetData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task logHistory(cargo_housem old_record, cargo_air_importh_dto record_dto)
        {

            var old_record_dto = new cargo_air_importh_dto
            {
                hbl_id = old_record.hbl_id,
                hbl_houseno = old_record.hbl_houseno,
                hbl_shipment_stage_name = old_record.shipstage?.param_name,
                hbl_shipper_name = old_record.hbl_shipper_name,
                hbl_shipper_add1 = old_record.hbl_shipper_add1,
                hbl_shipper_add2 = old_record.hbl_shipper_add2,
                hbl_shipper_add3 = old_record.hbl_shipper_add3,
                hbl_shipper_add4 = old_record.hbl_shipper_add4,
                hbl_shipper_add5 = old_record.hbl_shipper_add5,
                hbl_consignee_name = old_record.hbl_consignee_name,
                hbl_consignee_add1 = old_record.hbl_consignee_add1,
                hbl_consignee_add2 = old_record.hbl_consignee_add2,
                hbl_consignee_add3 = old_record.hbl_consignee_add3,
                hbl_consignee_add4 = old_record.hbl_consignee_add4,
                hbl_consignee_add5 = old_record.hbl_consignee_add5,

                hbl_agent_name = old_record.agent?.cust_name,
                hbl_cha_name = old_record.hbl_cha_name,
                hbl_cha_attn = old_record.hbl_cha_attn,
                hbl_cha_tel = old_record.hbl_cha_tel,
                hbl_cha_fax = old_record.hbl_cha_fax,
                hbl_location_name = old_record.hbl_location_name,
                hbl_location_add1 = old_record.hbl_location_add1,
                hbl_location_add2 = old_record.hbl_location_add2,
                hbl_location_add3 = old_record.hbl_location_add3,
                hbl_location_add4 = old_record.hbl_location_add4,
                hbl_frt_status_name = old_record.hbl_frt_status_name,
                hbl_uom_name = old_record.packageunit?.param_name,
                hbl_packages = old_record.hbl_packages,
                hbl_weight = old_record.hbl_weight,
                hbl_lbs = old_record.hbl_lbs,
                hbl_chwt_lbs = old_record.hbl_chwt_lbs,
                hbl_chwt = old_record.hbl_chwt,
                hbl_commodity = old_record.hbl_commodity,
                hbl_handled_name = old_record.handledby?.param_name,
                hbl_salesman_name = old_record.salesman?.param_name,
                hbl_remark1 = old_record.hbl_remark1,
                hbl_remark2 = old_record.hbl_remark2,
                hbl_remark3 = old_record.hbl_remark3,

                hbl_bltype = old_record.hbl_bltype,
                hbl_it_no = old_record.hbl_it_no,
                hbl_it_date = Lib.FormatDate(old_record.hbl_it_date, Lib.outputDateFormat),
                hbl_it_port = old_record.hbl_it_port,
                hbl_it_pcs = old_record.hbl_it_pcs,
                hbl_it_wt = old_record.hbl_it_wt,
                hbl_it_no2 = old_record.hbl_it_no2,
                hbl_it_date2 = Lib.FormatDate(old_record.hbl_it_date2, Lib.outputDateFormat),
                hbl_it_port2 = old_record.hbl_it_port2,
                hbl_it_pcs2 = old_record.hbl_it_pcs2,
                hbl_it_wt2 = old_record.hbl_it_wt2,
                hbl_it_no3 = old_record.hbl_it_no3,
                hbl_it_date3 = Lib.FormatDate(old_record.hbl_it_date3, Lib.outputDateFormat),
                hbl_it_port3 = old_record.hbl_it_port3,
                hbl_it_pcs3 = old_record.hbl_it_pcs3,
                hbl_it_wt3 = old_record.hbl_it_wt3,
                hbl_place_final = old_record.hbl_place_final,
                hbl_plf_eta = Lib.FormatDate(old_record.hbl_plf_eta, Lib.outputDateFormat),

                hbl_lfd_date = Lib.FormatDate(old_record.hbl_lfd_date, Lib.outputDateFormat),
                hbl_pickup_date = Lib.FormatDate(old_record.hbl_pickup_date, Lib.outputDateFormat),
                hbl_careof_name = old_record.careof?.cust_name,
                hbl_pono = old_record.hbl_pono,
                hbl_paid_status_name = old_record.paidstatus?.param_name,
                hbl_cargo_release_status = old_record.hbl_cargo_release_status,
                hbl_is_itshipment = old_record.hbl_is_itshipment,
                hbl_book_slno = old_record.hbl_book_slno,
                hbl_is_pl = old_record.hbl_is_pl,
                hbl_is_ci = old_record.hbl_is_ci,
                hbl_is_carr_an = old_record.hbl_is_carr_an,
                hbl_custom_reles_status = old_record.hbl_custom_reles_status,
                hbl_is_delivery = old_record.hbl_is_delivery,
                hbl_paid_remarks = old_record.hbl_paid_remarks,
                hbl_incoterm = old_record.incoterm?.param_name,
                hbl_invoiceno = old_record.hbl_invoiceno,
                hbl_delivery_date = Lib.FormatDate(old_record.hbl_delivery_date, Lib.outputDateFormat),

            };

            await new LogHistorym<cargo_air_importh_dto>(context)
                .Table("cargo_housem", log_date)
                .PrimaryKey("hbl_id", record_dto.hbl_id)
                .RefNo(record_dto.hbl_houseno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("hbl_houseno", "House Number")
                .TrackColumn("hbl_shipment_stage_name", "Shipment Stage")
                .TrackColumn("hbl_shipper_name", "Shipper Name")
                .TrackColumn("hbl_shipper_add1", "Shipper Address 1")
                .TrackColumn("hbl_shipper_add2", "Shipper Address 2")
                .TrackColumn("hbl_shipper_add3", "Shipper Address 3")
                .TrackColumn("hbl_shipper_add4", "Shipper Address 4")
                .TrackColumn("hbl_shipper_add5", "Shipper Address 5")
                .TrackColumn("hbl_consignee_name", "Consignee Name ")
                .TrackColumn("hbl_consignee_add1", "Consignee Address 1")
                .TrackColumn("hbl_consignee_add2", "Consignee Address 2")
                .TrackColumn("hbl_consignee_add3", "Consignee Address 3")
                .TrackColumn("hbl_consignee_add4", "Consignee Address 4")
                .TrackColumn("hbl_consignee_add5", "Consignee Address 5")
                .TrackColumn("hbl_agent_name", "Agent Name")
                .TrackColumn("hbl_cha_name", "CHA Name")
                .TrackColumn("hbl_cha_attn", "CHA Attention")
                .TrackColumn("hbl_cha_tel", "CHA Telephone")
                .TrackColumn("hbl_cha_fax", "CHA Fax")
                .TrackColumn("hbl_location_name", "Location Name")
                .TrackColumn("hbl_location_add1", "Location Address 1")
                .TrackColumn("hbl_location_add2", "Location Address 2")
                .TrackColumn("hbl_location_add3", "Location Address 3")
                .TrackColumn("hbl_location_add4", "Location Address 4")
                .TrackColumn("hbl_frt_status_name", "Freight Status Name")
                .TrackColumn("hbl_uom_name", "UOM Name")
                .TrackColumn("hbl_packages", "Packages", "int")
                .TrackColumn("hbl_weight", "Weight", "decimal")
                .TrackColumn("hbl_lbs", "LBS", "decimal")
                .TrackColumn("hbl_chwt_lbs", "Chargeable Weight LBS", "decimal")
                .TrackColumn("hbl_chwt", "Chargeable Weight", "decimal")
                .TrackColumn("hbl_commodity", "Commodity")
                .TrackColumn("hbl_handled_name", "Handled By Name")
                .TrackColumn("hbl_salesman_name", "Salesman Name")
                .TrackColumn("hbl_remark1", "Remark 1")
                .TrackColumn("hbl_remark2", "Remark 2")
                .TrackColumn("hbl_remark3", "Remark 3")
                .TrackColumn("hbl_lfd_date", "LFD Date")
                .TrackColumn("hbl_pickup_date", "Pickup Date")
                .TrackColumn("hbl_careof_name", "Care Of Name")
                .TrackColumn("hbl_pono", "PO Number")
                .TrackColumn("hbl_paid_status_name", "Paid Status")
                .TrackColumn("hbl_cargo_release_status", "Cargo Release Status")
                .TrackColumn("hbl_is_itshipment", "Is IT Shipment")
                .TrackColumn("hbl_book_slno", "Book SL No")
                .TrackColumn("hbl_is_pl", "Is PL")
                .TrackColumn("hbl_is_ci", "Is CI")
                .TrackColumn("hbl_is_carr_an", "Is Carrier AN")
                .TrackColumn("hbl_custom_reles_status", "Custom Release Status")
                .TrackColumn("hbl_is_delivery", "Is Delivery")
                .TrackColumn("hbl_paid_remarks", "Paid Remarks")
                .TrackColumn("hbl_incoterm", "Incoterm")
                .TrackColumn("hbl_invoiceno", "Invoice Number")
                .TrackColumn("hbl_delivery_date", "Delivery Date")
                .TrackColumn("hbl_it_no", "IT.No.1")
                .TrackColumn("hbl_it_date", "IT.Date 1")
                .TrackColumn("hbl_it_port", "IT.Port 1")
                .TrackColumn("hbl_it_pcs", "IT.Pcs 1", "int")
                .TrackColumn("hbl_it_wt", "IT.Weight 1", "decimal")
                .TrackColumn("hbl_it_no2", "IT.No.2")
                .TrackColumn("hbl_it_date2", "IT.Date 2")
                .TrackColumn("hbl_it_port2", "IT.Port 2")
                .TrackColumn("hbl_it_pcs2", "IT.Pcs 2", "int")
                .TrackColumn("hbl_it_wt2", "IT.Weight 2", "decimal")
                .TrackColumn("hbl_it_no3", "IT.No.3")
                .TrackColumn("hbl_it_date3", "IT.Date 3")
                .TrackColumn("hbl_it_port3", "IT.Port 3")
                .TrackColumn("hbl_it_pcs3", "IT.Pcs 3", "int")
                .TrackColumn("hbl_it_wt3", "IT.Weight 3", "decimal")
                .TrackColumn("hbl_place_final", "Final Destination")
                .TrackColumn("hbl_plf_eta", "Final Date")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }
        public async Task logHistoryCargoDesc(cargo_desc old_record, cargo_desc_dto NewRecord, string hbl_houseno, int hbl_id, int? ctr)// int id
        {
            var old_record_dto = new cargo_desc_dto
            {
                desc_parent_id = old_record.desc_parent_id,
                desc_id = old_record.desc_id,
                desc_ctr = ctr,
                desc_mark = old_record.desc_mark,
                desc_description = old_record.desc_description,
            };

            await new LogHistorym<cargo_desc_dto>(context)
            .Table("cargo_housem", log_date)
            .PrimaryKey("desc_id", hbl_id)///hbl id pass while call
            .RefNo(hbl_houseno)
            .SetCompanyInfo(NewRecord.rec_version, NewRecord.rec_company_id, NewRecord.rec_branch_id, NewRecord.rec_created_by!)

            .TrackColumn("desc_mark", $"Mark {ctr}")
            .TrackColumn("desc_description", $"Description {ctr}")

            .SetRecord(old_record_dto, NewRecord)
            .LogChangesAsync();

        }

    }
}
