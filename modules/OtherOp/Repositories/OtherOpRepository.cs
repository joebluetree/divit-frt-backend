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
using OtherOp.Interfaces;
using Common.DTO.OtherOp;

namespace OtherOp.Repositories
{
    public class OtherOpRepository : IOtherOpRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        private string oth_mode = "OTHERS";
        public OtherOpRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var oth_mode = "";
                var oth_from_date = "";
                var oth_to_date = "";
                var oth_refno = "";

                var company_id = 0;
                var branch_id = 0;

                DateTime? from_date = null;
                DateTime? to_date = null;

                if (data.ContainsKey("oth_mode"))
                    oth_mode = data["oth_mode"].ToString();
                if (data.ContainsKey("oth_from_date"))
                    oth_from_date = data["oth_from_date"].ToString();
                if (data.ContainsKey("oth_to_date"))
                    oth_to_date = data["oth_to_date"].ToString();
                if (data.ContainsKey("oth_refno"))
                    oth_refno = data["oth_refno"].ToString();

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

                IQueryable<cargo_masterm> query = context.cargo_masterm
                    .Include(e => e.customer);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.mbl_mode == "OTHERS");

                if (!Lib.IsBlank(oth_from_date))
                {
                    from_date = Lib.ParseDate(oth_from_date!);
                    query = query.Where(w => w.mbl_ref_date >= from_date);
                }
                if (!Lib.IsBlank(oth_to_date))
                {
                    to_date = Lib.ParseDate(oth_to_date!);
                    query = query.Where(w => w.mbl_ref_date <= to_date);
                }
                if (!Lib.IsBlank(oth_refno))
                    query = query.Where(w => w.mbl_refno!.Contains(oth_refno!));

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
                    .OrderBy(c => c.mbl_refno)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_otherop_dto
                {
                    oth_id = e.mbl_id,
                    oth_refno = e.mbl_refno,
                    oth_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                    oth_mbl_no = e.mbl_no,
                    oth_agent_name = e.agent!.cust_name,
                    oth_liner_name = e.liner!.param_name,
                    oth_pol_name = e.pol!.param_name,


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
        public async Task<cargo_otherop_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_masterm> query = context.cargo_masterm;

                query = query.Where(f => f.mbl_id == id);

                var Record = await query.Select(e => new cargo_otherop_dto
                {
                    oth_id = e.mbl_id,
                    oth_cfno = e.mbl_cfno,
                    oth_refno = e.mbl_refno,
                    oth_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                    oth_shipment_stage_id = e.mbl_shipment_stage_id,
                    oth_shipment_stage_name = e.shipstage!.param_name,
                    oth_mbl_no = e.mbl_no,
                    oth_agent_id = e.mbl_agent_id,
                    oth_agent_name = e.agent!.cust_name,
                    oth_liner_id = e.mbl_liner_id,
                    oth_liner_name = e.liner!.param_name,
                    oth_handled_id = e.mbl_handled_id,
                    oth_handled_name = e.handledby!.param_name,
                    oth_salesman_id = e.mbl_salesman_id,
                    oth_salesman_name = e.salesman!.param_name,
                    oth_mbl_frt_status = e.mbl_frt_status_name,

                    oth_pol_id = e.mbl_pol_id,
                    oth_pol_name = e.pol!.param_name,
                    oth_pol_etd = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateFormat),
                    oth_pod_id = e.mbl_pod_id,
                    oth_pod_name = e.pod!.param_name,
                    oth_pod_eta = Lib.FormatDate(e.mbl_pod_eta, Lib.outputDateFormat),
                    oth_place_delivery = e.mbl_place_delivery,
                    oth_country_id = e.mbl_country_id,
                    oth_country_name = e.country!.param_name,
                    oth_vessel_name = e.mbl_vessel_name,
                    oth_voyage = e.mbl_voyage,

                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                Record.otherop_cntr = await getCntrAsync(Record.oth_id);
                Record.otherop_house = await GetHouseAsync(Record.oth_id);
                // await GetHouseAsync(Record.oth_id);
                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<cargo_container_dto>> getCntrAsync(int id)
        {
            var query = from e in context.cargo_container
                        .Where(a => a.cntr_mbl_id == id && a.cntr_catg == "M")
                        .OrderBy(o => o.cntr_order)
                        select (new cargo_container_dto
                        {
                            cntr_id = e.cntr_id,
                            cntr_mbl_id = e.cntr_mbl_id,
                            cntr_catg = e.cntr_catg,
                            cntr_no = e.cntr_no,
                            cntr_type_id = e.cntr_type_id,
                            cntr_type_name = e.cntrtype!.param_name,
                            cntr_sealno = e.cntr_sealno,
                            cntr_movement = e.cntr_movement,
                            cntr_pieces = e.cntr_pieces,
                            cntr_packages_unit_id = e.cntr_packages_unit_id,
                            cntr_packages_unit_name = e.packunit!.param_name,
                            cntr_teu = e.cntr_teu,
                            cntr_cbm = e.cntr_cbm,
                            cntr_weight_uom = e.cntr_weight_uom,
                            cntr_weight = e.cntr_weight,
                            cntr_rider = e.cntr_rider,
                            cntr_tare_weight = e.cntr_tare_weight,
                            cntr_pick_date = Lib.FormatDate(e.cntr_pick_date, Lib.outputDateFormat),
                            cntr_return_date = Lib.FormatDate(e.cntr_return_date, Lib.outputDateFormat),
                            cntr_lfd = Lib.FormatDate(e.cntr_lfd, Lib.outputDateFormat),
                            cntr_discharge_date = Lib.FormatDate(e.cntr_discharge_date, Lib.outputDateFormat),
                            cntr_order = e.cntr_order,

                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat)
                        });

            var records = await query.ToListAsync();

            return records;
        }
        public async Task<cargo_otherop_dto?> GetHouseAsync(int id)
        {
            var query = from e in context.cargo_housem
                .Where(a => a.hbl_mbl_id == id)  //record_dto.oth_
                        select new cargo_otherop_dto
                        {
                            oth_hbl_id = e.hbl_id,
                            oth_id = e.hbl_mbl_id,
                            oth_hbl_no = e.hbl_houseno,
                            oth_bltype = e.hbl_bltype,

                            oth_shipper_id = e.hbl_shipper_id,
                            oth_shipper_code = e.shipper!.cust_code,
                            oth_shipper_name = e.hbl_shipper_name,
                            oth_shipper_add1 = e.hbl_shipper_add1,
                            oth_shipper_add2 = e.hbl_shipper_add2,
                            oth_shipper_add3 = e.hbl_shipper_add3,
                            oth_shipper_add4 = e.hbl_shipper_add4,

                            oth_consignee_id = e.hbl_consignee_id,
                            oth_consignee_code = e.consignee!.cust_code,
                            oth_consignee_name = e.hbl_consignee_name,
                            oth_consignee_add1 = e.hbl_consignee_add1,
                            oth_consignee_add2 = e.hbl_consignee_add2,
                            oth_consignee_add3 = e.hbl_consignee_add3,
                            oth_consignee_add4 = e.hbl_consignee_add4,

                            oth_location_id = e.hbl_location_id,
                            oth_location_code = e.location!.cust_code,
                            oth_location_name = e.hbl_location_name,
                            oth_location_add1 = e.hbl_location_add1,
                            oth_location_add2 = e.hbl_location_add2,
                            oth_location_add3 = e.hbl_location_add3,
                            oth_location_add4 = e.hbl_location_add4,

                            oth_it_no = e.hbl_it_no,
                            oth_it_date = Lib.FormatDate(e.hbl_it_date, Lib.outputDateFormat),
                            oth_it_port = e.hbl_it_port,

                            oth_hbl_frt_status = e.hbl_frt_status_name,
                            oth_packages = e.hbl_packages,
                            oth_cbm = e.hbl_cbm,
                            oth_weight = e.hbl_weight,
                            oth_chwt = e.hbl_chwt,
                            oth_lbs = e.hbl_lbs,
                            oth_cft = e.hbl_cft,
                            oth_chwt_lbs = e.hbl_chwt_lbs,
                            oth_commodity = e.hbl_commodity,

                            oth_handled_id = e.hbl_handled_id,
                            oth_salesman_id = e.hbl_salesman_id,
                            oth_isf_no = e.hbl_isf_no,
                            oth_lfd_date = Lib.FormatDate(e.hbl_lfd_date, Lib.outputDateFormat),
                            oth_shipment_stage_id = e.hbl_shipment_stage_id,

                            oth_is_pl = e.hbl_is_pl,
                            oth_is_ci = e.hbl_is_ci,
                            oth_is_carr_an = e.hbl_is_carr_an,
                            oth_custom_reles_status = e.hbl_custom_reles_status,
                            oth_is_delivery = e.hbl_is_delivery,

                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        };
            var records = await query.FirstOrDefaultAsync();
            return records;
        }
        // to get cbm total from container table

        public decimal? GetCbmTotal(cargo_otherop_dto record_dto)
        {
            decimal? cbmTotal = 0;
            if (record_dto.otherop_cntr != null)
                cbmTotal = record_dto.otherop_cntr.Sum(c => c.cntr_cbm);
            return cbmTotal;
        }

        public async Task<cargo_otherop_dto> SaveAsync(int id, string mode, cargo_otherop_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_otherop_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await saveCntrAsync(_Record.oth_id, mode, _Record);
                _Record = await SaveHouseAsync(_Record.oth_id, mode, _Record);

                _Record.otherop_cntr = await getCntrAsync(_Record.oth_id);
                // _Record.master_house = await GetHouseAsync(_Record.mbl_id);
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


        private Boolean AllValid(string mode, cargo_otherop_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";
            string type = "";
            string cntr_no = "";
            string unit = "";
            DateTime? etd_date = Lib.ParseDate(record_dto.oth_pol_etd!) ?? null;
            DateTime? eta_date = Lib.ParseDate(record_dto.oth_pod_eta!) ?? null;


            if (Lib.IsBlank(record_dto.oth_agent_name))
                str += "Master Agent Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.oth_shipment_stage_name))
                str += "Shipment Stage Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.oth_handled_name))
                str += "Handled By Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.oth_mbl_frt_status))
                str += "Fright Status Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.oth_pol_name))
                str += "POL Cannot Be Blank!";

            if (Lib.IsBlank(record_dto.oth_pol_etd))
                str += "ETD Cannot Be Blank!";

            if (Lib.IsBlank(record_dto.oth_pod_name))
                str += "Port.Discharge Cannot Be Blank!";
            if (eta_date < etd_date)
            {
                str += "ETD Cannot be Greater than POD ETA";
                if (Lib.IsBlank(record_dto.oth_pod_eta))
                    str += "ETA Cannot Be Blank!";
            }
            if (Lib.IsBlank(record_dto.oth_country_name))
                str += "Dest.Country Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.oth_vessel_name))
                str += "Vessel Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.oth_voyage))
                str += "Voyage Cannot Be Blank!";
            // foreach (cargo_container_dto rec in record_dto.master_cntr!)
            // {
            //     if (Lib.IsBlank(rec.cntr_type_name))
            //         type = "Type Cannot Be Blank!";
            //     if (!CommonLib.IsValidContainerNumber(rec.cntr_no!))
            //         cntr_no = $"Invalid Container Number: {rec.cntr_no}";
            //     if (Lib.IsBlank(rec.cntr_no))
            //         cntr_no = "Cntr No Cannot Be Blank!";
            //     if (Lib.IsBlank(rec.cntr_packages_unit_name))
            //         unit = "Unit Cannot Be Blank";
            // }

            if (type != "")
                str += type;
            if (cntr_no != "")
                str += cntr_no;
            if (unit != "")
                str += unit;
            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }

        public async Task<cargo_otherop_dto> SaveParentAsync(int id, string mode, cargo_otherop_dto record_dto)
        {
            cargo_masterm? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {

                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, "SEA-IMP-MASTER-PREFIX,SEA-IMP-MASTER-STARTING-NO");// 

                    var DefaultCfNo = 0;
                    var Defaultprefix = "";

                    if (result.ContainsKey("SEA-IMP-MASTER-STARTING-NO"))
                    {
                        DefaultCfNo = Lib.StringToInteger(result["SEA-IMP-MASTER-STARTING-NO"]);
                    }
                    if (result.ContainsKey("SEA-IMP-MASTER-PREFIX"))
                    {
                        Defaultprefix = result["SEA-IMP-MASTER-PREFIX"].ToString();
                    }
                    if (Lib.IsBlank(Defaultprefix) || Lib.IsZero(DefaultCfNo))
                    {
                        throw new Exception("Missing Sea Import master Prefix/Starting-Number in Branch Settings");
                    }

                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("Ref Number Cannot Be Generated");
                    }

                    string sqtn_no = $"{Defaultprefix}{iNextNo}";  // for setting quote no by adding propper prefix (here QL - Quotation LCL)
                    string stype = oth_mode;

                    Record = new cargo_masterm();

                    Record.mbl_cfno = iNextNo;
                    Record.mbl_refno = sqtn_no;
                    Record.mbl_mode = stype;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";

                    Record.mbl_mode = oth_mode;
                }
                else
                {
                    Record = await context.cargo_masterm
                        .Include(c => c.country)
                        .Include(c => c.salesman)
                        .Include(c => c.handledby)
                        .Include(c => c.shipstage)
                        .Include(c => c.liner)
                        .Include(c => c.pol)
                        .Include(c => c.pod)
                        .Include(c => c.vessel)
                        .Include(c => c.cargoloc)
                        .Include(c => c.devanloc)
                        .Where(f => f.mbl_id == id)
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

                Record.mbl_ref_date = Lib.ParseDate(record_dto.oth_ref_date!);
                if (Record.mbl_shipment_stage_id != record_dto.oth_shipment_stage_id)
                {
                    Record.mbl_shipment_stage_id = record_dto.oth_shipment_stage_id;

                    await CommonLib.UpdateHouseShipmentStage(context, Record.mbl_id, record_dto.oth_shipment_stage_id);
                }
                Record.mbl_no = record_dto.oth_mbl_no;
                Record.mbl_agent_id = record_dto.oth_agent_id;
                Record.mbl_liner_id = record_dto.oth_liner_id;
                Record.mbl_handled_id = record_dto.oth_handled_id;
                Record.mbl_salesman_id = record_dto.oth_salesman_id;
                Record.mbl_frt_status_name = record_dto.oth_mbl_frt_status;
                Record.mbl_pol_id = record_dto.oth_pol_id;
                Record.mbl_pol_etd = Lib.ParseDate(record_dto.oth_pol_etd!);
                Record.mbl_pod_id = record_dto.oth_pod_id;
                Record.mbl_pod_eta = Lib.ParseDate(record_dto.oth_pod_eta!);
                Record.mbl_place_delivery = record_dto.oth_place_delivery;
                Record.mbl_country_id = record_dto.oth_country_id;
                Record.mbl_vessel_name = record_dto.oth_vessel_name;
                Record.mbl_voyage = record_dto.oth_voyage;
                Record.mbl_shipper_id = record_dto.oth_shipper_id;
                Record.mbl_consignee_id = record_dto.oth_consignee_id;

                // UpdateCntrCount(record_dto);

                // Record.mbl_20 = record_dto.oth_20;
                // Record.mbl_40 = record_dto.oth_40;
                // Record.mbl_40hq = record_dto.oth_40hq;
                // Record.mbl_45 = record_dto.oth_45;
                // Record.mbl_teu = record_dto.oth_teu;
                // Record.mbl_container_tot = record_dto.oth_container_tot;
                // Record.mbl_cbm_tot = GetCbmTotal(record_dto);

                if (mode == "add")
                    await context.cargo_masterm.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.oth_id = Record.mbl_id;
                record_dto.oth_refno = Record.mbl_refno;
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
                record_dto.rec_version = Record.rec_version;


                return record_dto;
            }
            catch (Exception)
            {
                // throw new Exception(Ex.Message.ToString());
                throw;
            }

        }
        public int GetNextCfNo(int company_id, int? branch_id, int DefaultCfNo)
        {
            // int iDefaultCfNo = int.Parse(DefaultCfNo!);

            var CfNo = context.cargo_masterm
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.mbl_mode == oth_mode)
            .Select(e => e.mbl_cfno)
            .DefaultIfEmpty()
            .Max();

            CfNo = CfNo == 0 ? DefaultCfNo : CfNo + 1;
            return CfNo;
        }

        public async Task<cargo_otherop_dto> saveCntrAsync(int id, string mode, cargo_otherop_dto record_dto)
        {
            cargo_container? record;
            List<cargo_container_dto> records_dto;
            List<cargo_container> records;
            try
            {
                // get cntr details from the frontend
                records_dto = record_dto.otherop_cntr!;
                // read the cntr details from database
                records = await context.cargo_container
                    .Include(c => c.cntrtype)
                    .Include(c => c.packunit)
                    .Where(w => w.cntr_mbl_id == id && w.cntr_catg == "M")
                    .ToListAsync();

                if (mode == "edit")
                    await logHistoryCntrDetail(records, record_dto);
                int nextorder = 1;
                //remove deleted cntr details
                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.cntr_id == existing_record.cntr_id);
                    if (rec == null)
                        context.cargo_container.Remove(existing_record);
                }

                //Add or Edit Records cntr
                foreach (var rec in records_dto)
                {

                    if (rec.cntr_id == 0)
                    {
                        record = new cargo_container();
                        record.rec_company_id = record_dto.rec_company_id;
                        record.rec_branch_id = record_dto.rec_branch_id;
                        record.rec_created_by = record_dto.rec_created_by;
                        record.rec_created_date = DbLib.GetDateTime();
                        record.rec_locked = "N";

                        record.cntr_catg = "M";
                    }
                    else
                    {
                        record = records.Find(f => f.cntr_id == rec.cntr_id);
                        if (record == null)
                            throw new Exception("Container Detail Record Not Found " + rec.cntr_id.ToString());

                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }

                    record.cntr_mbl_id = id;
                    record.cntr_no = rec.cntr_no;
                    record.cntr_type_id = rec.cntr_type_id;
                    record.cntr_sealno = rec.cntr_sealno;
                    record.cntr_movement = rec.cntr_movement;
                    record.cntr_pieces = rec.cntr_pieces;
                    record.cntr_packages_unit_id = rec.cntr_packages_unit_id;
                    record.cntr_teu = CommonLib.UpdateTeuValue(rec.cntr_type_name!);
                    record.cntr_cbm = rec.cntr_cbm;
                    record.cntr_weight_uom = rec.cntr_weight_uom;
                    record.cntr_weight = rec.cntr_weight;
                    record.cntr_rider = rec.cntr_rider;
                    record.cntr_tare_weight = rec.cntr_tare_weight;
                    record.cntr_pick_date = Lib.ParseDate(rec.cntr_pick_date!);
                    record.cntr_return_date = Lib.ParseDate(rec.cntr_return_date!);
                    record.cntr_lfd = Lib.ParseDate(rec.cntr_lfd!);
                    record.cntr_discharge_date = Lib.ParseDate(rec.cntr_discharge_date!);
                    record.cntr_order = nextorder++;

                    if (rec.cntr_id == 0)
                        await context.cargo_container.AddAsync(record);
                }

                context.SaveChanges();
                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<cargo_otherop_dto> SaveHouseAsync(int id, string mode, cargo_otherop_dto record_dto)
        {
            cargo_housem? record;
            try
            {
                if (mode == "add")
                {
                    record = new cargo_housem
                    {
                        rec_company_id = record_dto.rec_company_id,
                        rec_branch_id = record_dto.rec_branch_id,
                        rec_created_by = record_dto.rec_created_by,
                        rec_created_date = DbLib.GetDateTime(),
                        rec_locked = "N",
                        hbl_mode = oth_mode
                    };
                }
                else
                {
                    record = await context.cargo_housem
                        .Where(f => f.hbl_id == record_dto.oth_hbl_id)
                        .FirstOrDefaultAsync();

                    if (record == null)
                        throw new Exception("House Record Not Found");

                    record.rec_edited_by = record_dto.rec_created_by;
                    record.rec_edited_date = DbLib.GetDateTime();
                }

                record.hbl_mbl_id = id;
                record.hbl_houseno = record_dto.oth_hbl_no;
                record.hbl_bltype = record_dto.oth_bltype;

                record.hbl_shipper_id = record_dto.oth_shipper_id;
                record.hbl_shipper_name = record_dto.oth_shipper_name;
                record.hbl_shipper_add1 = record_dto.oth_shipper_add1;
                record.hbl_shipper_add2 = record_dto.oth_shipper_add2;
                record.hbl_shipper_add3 = record_dto.oth_shipper_add3;
                record.hbl_shipper_add4 = record_dto.oth_shipper_add4;

                record.hbl_consignee_id = record_dto.oth_consignee_id;
                record.hbl_consignee_name = record_dto.oth_consignee_name;
                record.hbl_consignee_add1 = record_dto.oth_consignee_add1;
                record.hbl_consignee_add2 = record_dto.oth_consignee_add2;
                record.hbl_consignee_add3 = record_dto.oth_consignee_add3;
                record.hbl_consignee_add4 = record_dto.oth_consignee_add4;

                record.hbl_location_id = record_dto.oth_location_id;
                record.hbl_location_name = record_dto.oth_location_name;
                record.hbl_location_add1 = record_dto.oth_location_add1;
                record.hbl_location_add2 = record_dto.oth_location_add2;
                record.hbl_location_add3 = record_dto.oth_location_add3;
                record.hbl_location_add4 = record_dto.oth_location_add4;

                record.hbl_it_no = record_dto.oth_it_no;
                record.hbl_it_date = Lib.ParseDate(record_dto.oth_it_date!);
                record.hbl_it_port = record_dto.oth_it_port;

                record.hbl_frt_status_name = record_dto.oth_hbl_frt_status;
                record.hbl_packages = record_dto.oth_packages;
                record.hbl_cbm = record_dto.oth_cbm;
                record.hbl_weight = record_dto.oth_weight;
                record.hbl_chwt = record_dto.oth_chwt;
                record.hbl_lbs = record_dto.oth_lbs;
                record.hbl_cft = record_dto.oth_cft;
                record.hbl_chwt_lbs = record_dto.oth_chwt_lbs;
                record.hbl_commodity = record_dto.oth_commodity;

                record.hbl_handled_id = record_dto.oth_handled_id;
                record.hbl_salesman_id = record_dto.oth_salesman_id;
                record.hbl_isf_no = record_dto.oth_isf_no;
                record.hbl_lfd_date = Lib.ParseDate(record_dto.oth_lfd_date!);
                record.hbl_shipment_stage_id = record_dto.oth_shipment_stage_id;

                record.hbl_is_pl = record_dto.oth_is_pl;
                record.hbl_is_ci = record_dto.oth_is_ci;
                record.hbl_is_carr_an = record_dto.oth_is_carr_an;

                record.hbl_custom_reles_status = record_dto.oth_custom_reles_status;
                record.hbl_is_delivery = record_dto.oth_is_delivery;

                if (mode == "add")
                    await context.cargo_housem.AddAsync(record);

                await context.SaveChangesAsync();

                record_dto.oth_hbl_id = record.hbl_id;
                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        // public cargo_otherop_dto UpdateCntrCount(cargo_otherop_dto record_dto)
        // {
        //     try
        //     {

        //         int mbl_40hq = 0;
        //         int mbl_40 = 0;
        //         int mbl_20 = 0;
        //         int mbl_45 = 0;
        //         decimal mbl_teu = 0;
        //         int mbl_container_tot = 0;

        //         foreach (var cntr in record_dto.otherop_cntr!)
        //         {
        //             var containerType = cntr.cntr_type_name;

        //             if (containerType!.Contains("20"))
        //             {
        //                 mbl_20++;
        //                 mbl_teu += 1.0m;
        //             }
        //             if (containerType.Contains("40"))
        //             {
        //                 if (containerType!.Contains("HC"))
        //                 {
        //                     mbl_40hq++;
        //                     mbl_teu += 2.25m;
        //                 }
        //                 else
        //                 {
        //                     mbl_40++;
        //                     mbl_teu += 2.0m;
        //                 }

        //             }
        //             if (containerType.Contains("45"))
        //             {
        //                 mbl_45++;
        //                 mbl_teu += 2.5m;
        //             }
        //             mbl_container_tot++;
        //         }
        //         record_dto.oth_20 = mbl_20;
        //         record_dto.oth_40 = mbl_40;
        //         record_dto.oth_40hq = mbl_40hq;
        //         record_dto.oth_45 = mbl_45;
        //         record_dto.oth_teu = mbl_teu;
        //         record_dto.oth_container_tot = mbl_container_tot;

        //         return record_dto;
        //     }
        //     catch (Exception Ex)
        //     {
        //         throw new Exception(Ex.Message.ToString());
        //     }
        // }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_masterm
                    .FirstOrDefaultAsync(f => f.mbl_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    await CommonLib.DeleteContainer(context, id);
                    await CommonLib.DeleteHouses(context, id);
                    await CommonLib.DeleteDesc(context, id);
                    await CommonLib.DeleteDeliveryOrder(context, id);
                    await CommonLib.DeleteMemo(context, id);

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

        public async Task logHistory(cargo_masterm old_record, cargo_otherop_dto record_dto)
        {

            var old_record_dto = new cargo_otherop_dto
            {
                oth_id = old_record.mbl_id,
                oth_cfno = old_record.mbl_cfno,
                oth_refno = old_record.mbl_refno,
                oth_ref_date = Lib.FormatDate(old_record.mbl_ref_date, Lib.outputDateFormat),
                oth_shipment_stage_name = old_record.shipstage?.param_name,
                oth_mbl_no = old_record.mbl_no,
                oth_agent_name = old_record.agent?.cust_name,
                oth_liner_name = old_record.liner?.param_name,
                oth_handled_name = old_record.handledby?.param_name,
                oth_salesman_name = old_record.salesman?.param_name,
                oth_mbl_frt_status = old_record.mbl_frt_status_name,
                oth_pol_name = old_record.pol?.param_name,
                oth_pol_etd = Lib.FormatDate(old_record.mbl_pol_etd, Lib.outputDateFormat),
                oth_pod_name = old_record.pod?.param_name,
                oth_pod_eta = Lib.FormatDate(old_record.mbl_pod_eta, Lib.outputDateFormat),
                oth_place_delivery = old_record.mbl_place_delivery,
                oth_country_name = old_record.country?.param_name,
                oth_vessel_name = old_record.mbl_vessel_name,
                oth_voyage = old_record.mbl_voyage,

            };

            await new LogHistorym<cargo_otherop_dto>(context)
                .Table("cargo_masterm", log_date)
                .PrimaryKey("mbl_id", record_dto.oth_id)
                .RefNo(record_dto.oth_refno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("mbl_cfno", "CF No")
                .TrackColumn("mbl_refno", "Reference No")
                .TrackColumn("mbl_ref_date", "Reference Date", "date")
                .TrackColumn("mbl_shipment_stage_name", "Shipment Stage Name")
                .TrackColumn("mbl_no", "MBL No")
                .TrackColumn("mbl_agent_name", "Agent Name")
                .TrackColumn("mbl_liner_name", "Liner Name")
                .TrackColumn("mbl_coloader_name", "Coloader Name")
                .TrackColumn("mbl_handled_name", "Handled By Name")
                .TrackColumn("mbl_salesman_name", "Salesman Name")
                .TrackColumn("mbl_frt_status_name", "Freight Status Name")
                .TrackColumn("mbl_ship_term_name", "Shipping Term Name")
                .TrackColumn("mbl_cntr_type", "Container Type")
                .TrackColumn("mbl_incoterm_name", "Incoterm Name")
                .TrackColumn("mbl_pol_name", "Port of Loading")
                .TrackColumn("mbl_pol_etd", "ETD (POL)", "date")
                .TrackColumn("mbl_pod_name", "Port of Discharge")
                .TrackColumn("mbl_pod_eta", "ETA (POD)", "date")
                .TrackColumn("mbl_place_delivery", "Place of Delivery")
                .TrackColumn("mbl_pofd_eta", "ETA (POFD)", "date")
                .TrackColumn("mbl_country_name", "Country Name")
                .TrackColumn("mbl_vessel_name", "Vessel Name")
                .TrackColumn("mbl_voyage", "Voyage")
                .TrackColumn("mbl_status_name", "Status Name")
                .TrackColumn("mbl_is_sea_waybill", "Sea Waybill")
                .TrackColumn("mbl_ombl_sent_on", "OMBL Sent On", "date")
                .TrackColumn("mbl_ombl_sent_ampm", "OMBL AM/PM")
                .TrackColumn("mbl_of_sent_on", "OF Sent On", "date")
                .TrackColumn("mbl_cargo_loc_code", "Cargo Location Code")
                .TrackColumn("mbl_cargo_loc_name", "Cargo Location Name")
                .TrackColumn("mbl_cargo_loc_add1", "Cargo Loc Address 1")
                .TrackColumn("mbl_cargo_loc_add2", "Cargo Loc Address 2")
                .TrackColumn("mbl_cargo_loc_add3", "Cargo Loc Address 3")
                .TrackColumn("mbl_cargo_loc_add4", "Cargo Loc Address 4")
                .TrackColumn("mbl_devan_loc_code", "Devan Location Code")
                .TrackColumn("mbl_devan_loc_name", "Devan Location Name")
                .TrackColumn("mbl_devan_loc_add1", "Devan Loc Address 1")
                .TrackColumn("mbl_devan_loc_add2", "Devan Loc Address 2")
                .TrackColumn("mbl_devan_loc_add3", "Devan Loc Address 3")
                .TrackColumn("mbl_devan_loc_add4", "Devan Loc Address 4")


                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();

        }
        public async Task logHistoryCntrDetail(List<cargo_container> old_records, cargo_otherop_dto record_dto)
        {

            var old_records_dto = old_records.Select(record => new cargo_container_dto
            {
                cntr_id = record.cntr_id,
                cntr_catg = record.cntr_catg,
                cntr_no = record.cntr_no,
                cntr_type_name = record.cntrtype?.param_name,
                cntr_sealno = record.cntr_sealno,
                cntr_movement = record.cntr_movement,
                cntr_pieces = record.cntr_pieces,
                cntr_packages_unit_name = record.packunit?.param_name,
                cntr_cbm = record.cntr_cbm,
                cntr_weight_uom = record.cntr_weight_uom,
                cntr_weight = record.cntr_weight,
                cntr_rider = record.cntr_rider,
                cntr_tare_weight = record.cntr_tare_weight,
                cntr_pick_date = Lib.FormatDate(record.cntr_pick_date, Lib.outputDateFormat),
                cntr_return_date = Lib.FormatDate(record.cntr_return_date, Lib.outputDateFormat),
                cntr_lfd = Lib.FormatDate(record.cntr_lfd, Lib.outputDateFormat),
                cntr_discharge_date = Lib.FormatDate(record.cntr_discharge_date, Lib.outputDateFormat),
                cntr_order = record.cntr_order
            }).ToList();

            await new LogHistorym<cargo_container_dto>(context)
                .Table("cargo_masterm", log_date)
                .PrimaryKey("cntr_id", record_dto.oth_id)
                .RefNo(record_dto.oth_refno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("cntr_catg", "Category")
                .TrackColumn("cntr_no", "Container No")
                .TrackColumn("cntr_type_name", "Container Type Name")
                .TrackColumn("cntr_sealno", "Seal No")
                .TrackColumn("cntr_movement", "Movement")
                .TrackColumn("cntr_pieces", "Pieces", "int")
                .TrackColumn("cntr_packages_unit_name", "Packages Unit")
                .TrackColumn("cntr_cbm", "CBM", "decimal")
                .TrackColumn("cntr_weight_uom", "Weight UOM")
                .TrackColumn("cntr_weight", "Weight", "decimal")
                .TrackColumn("cntr_rider", "Rider")
                .TrackColumn("cntr_tare_weight", "Tare Weight", "decimal")
                .TrackColumn("cntr_pick_date", "Pick Date")
                .TrackColumn("cntr_return_date", "Return Date")
                .TrackColumn("cntr_lfd", "LFD")
                .TrackColumn("cntr_discharge_date", "Discharge Date")
                .TrackColumn("cntr_order", "Order", "int")
                .SetRecords(old_records_dto, record_dto.otherop_cntr!)
                .LogChangesAsync();

        }

    }
}
