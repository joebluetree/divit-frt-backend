using Database;
using Database.Lib;
using Common.DTO.Masters;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;
using SeaExport.Interfaces;
using Common.DTO.SeaExport;
using Database.Models.Cargo;
using System.Diagnostics.Eventing.Reader;

namespace SeaExport.Repositories
{
    public class SeaExportmRepository : ISeaExportmRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        private string smbl_mode = "SEA EXPORT";
        public SeaExportmRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var mbl_mode = "";
                var mbl_from_date = "";
                var mbl_to_date = "";
                var mbl_refno = "";
                var mbl_agent_name = "";
                var mbl_pol_name = "";
                var mbl_pod_name = "";

                var company_id = 0;
                var branch_id = 0;

                DateTime? from_date = null;
                DateTime? to_date = null;

                if (data.ContainsKey("mbl_mode"))
                    mbl_mode = data["mbl_mode"].ToString();
                if (data.ContainsKey("mbl_from_date"))
                    mbl_from_date = data["mbl_from_date"].ToString();
                if (data.ContainsKey("mbl_to_date"))
                    mbl_to_date = data["mbl_to_date"].ToString();
                if (data.ContainsKey("mbl_refno"))
                    mbl_refno = data["mbl_refno"].ToString();
                if (data.ContainsKey("mbl_agent_name"))
                    mbl_agent_name = data["mbl_agent_name"].ToString();
                if (data.ContainsKey("mbl_pol_name"))
                    mbl_pol_name = data["mbl_pol_name"].ToString();
                if (data.ContainsKey("mbl_pod_name"))
                    mbl_pod_name = data["mbl_pod_name"].ToString();

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
                query = query.Where(w => w.mbl_mode == smbl_mode);

                if (!Lib.IsBlank(mbl_from_date))
                {
                    from_date = Lib.ParseDate(mbl_from_date!);
                    query = query.Where(w => w.mbl_ref_date >= from_date);
                }
                if (!Lib.IsBlank(mbl_to_date))
                {
                    to_date = Lib.ParseDate(mbl_to_date!);
                    query = query.Where(w => w.mbl_ref_date <= to_date);
                }
                if (!Lib.IsBlank(mbl_refno))
                    query = query.Where(w => w.mbl_refno!.Contains(mbl_refno!));
                if (!Lib.IsBlank(mbl_agent_name))
                    query = query.Where(w => w.agent!.cust_name!.Contains(mbl_agent_name!));
                if (!Lib.IsBlank(mbl_pol_name))
                    query = query.Where(w => w.pol!.param_name!.Contains(mbl_pol_name!));
                if (!Lib.IsBlank(mbl_pod_name))
                    query = query.Where(w => w.pod!.param_name!.Contains(mbl_pod_name!));

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

                var Records = await query.Select(e => new cargo_sea_exportm_dto
                {
                    mbl_id = e.mbl_id,
                    mbl_refno = e.mbl_refno,
                    mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                    mbl_no = e.mbl_no,
                    mbl_agent_name = e.agent!.cust_name,
                    mbl_liner_name = e.liner!.param_name,
                    mbl_pol_name = e.pol!.param_name,
                    mbl_pol_etd = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateFormat),
                    mbl_pod_name = e.pod!.param_name,
                    mbl_pod_eta = Lib.FormatDate(e.mbl_pod_eta, Lib.outputDateFormat),
                    mbl_cntr_type = e.mbl_cntr_type,
                    mbl_handled_name = e.handledby!.param_name,

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
        public async Task<cargo_sea_exportm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_masterm> query = context.cargo_masterm;
                //.Include(e => e.customer);

                query = query.Where(f => f.mbl_id == id);

                var Record = await query.Select(e => new cargo_sea_exportm_dto
                {
                    mbl_id = e.mbl_id,
                    mbl_cfno = e.mbl_cfno,
                    mbl_refno = e.mbl_refno,
                    mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                    mbl_shipment_stage_id = e.mbl_shipment_stage_id,
                    mbl_shipment_stage_name = e.shipstage!.param_name,
                    mbl_no = e.mbl_no,
                    mbl_sub_houseno = e.mbl_sub_houseno,
                    mbl_liner_bookingno = e.mbl_liner_bookingno,
                    mbl_agent_id = e.mbl_agent_id,
                    mbl_agent_name = e.agent!.cust_name,
                    mbl_liner_id = e.mbl_liner_id,
                    mbl_liner_name = e.liner!.param_name,
                    mbl_handled_id = e.mbl_handled_id,
                    mbl_handled_name = e.handledby!.param_name,
                    mbl_salesman_id = e.mbl_salesman_id,
                    mbl_salesman_name = e.salesman!.param_name,
                    mbl_frt_status_name = e.mbl_frt_status_name,
                    mbl_ship_term_id = e.mbl_ship_term_id,
                    mbl_ship_term_name = e.shipterm!.param_name,
                    mbl_cntr_type = e.mbl_cntr_type,
                    mbl_direct = e.mbl_direct,
                    mbl_place_delivery = e.mbl_place_delivery,
                    mbl_pol_id = e.mbl_pol_id,
                    mbl_pol_name = e.pol!.param_name,
                    mbl_pol_etd = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateFormat),
                    mbl_pod_id = e.mbl_pod_id,
                    mbl_pod_name = e.pod!.param_name,
                    mbl_pod_eta = Lib.FormatDate(e.mbl_pod_eta, Lib.outputDateFormat),
                    mbl_pofd_id = e.mbl_pofd_id,
                    mbl_pofd_name = e.pofd!.param_name,
                    mbl_pofd_eta = Lib.FormatDate(e.mbl_pofd_eta, Lib.outputDateFormat),
                    mbl_country_id = e.mbl_country_id,
                    mbl_country_name = e.country!.param_name,
                    mbl_vessel_id = e.mbl_vessel_id,
                    mbl_vessel_code = e.vessel!.param_code,
                    mbl_vessel_name = e.mbl_vessel_name,
                    mbl_voyage = e.mbl_voyage,
                    mbl_book_slno = e.mbl_book_slno,

                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                Record.master_cntr = await getCntrAsync(Record.mbl_id);
                Record.master_house = await GetHouseAsync(Record.mbl_id);

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

        public async Task<List<cargo_sea_exporth_dto>> GetHouseAsync(int id)
        {
            var query = from e in context.cargo_housem
                        .Where(a => a.hbl_mbl_id == id)
                        .OrderBy(o => o.hbl_id)
                        select (new cargo_sea_exporth_dto
                        {
                            hbl_id = e.hbl_id,
                            hbl_mbl_id = e.hbl_mbl_id,
                            hbl_houseno = e.hbl_houseno,
                            hbl_shipper_name = e.hbl_shipper_name,
                            hbl_consignee_name = e.consignee!.cust_name,
                            hbl_pcs = e.hbl_pcs,
                            hbl_handled_name = e.handledby!.param_name,
                            hbl_frt_status_name = e.hbl_frt_status_name,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateFormat),
                            rec_created_by = e.rec_created_by,
                        });

            var records = await query.ToListAsync();

            return records;
        }

        public async Task<cargo_sea_exportm_dto> SaveAsync(int id, string mode, cargo_sea_exportm_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_sea_exportm_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await saveCntrAsync(_Record.mbl_id, mode, _Record);
                // await 
                _Record.master_cntr = await getCntrAsync(_Record.mbl_id);
                _Record.master_house = await GetHouseAsync(_Record.mbl_id);
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


        private Boolean AllValid(string mode, cargo_sea_exportm_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";
            string type = "";
            string cntr_no = "";
            string unit = "";


            if (Lib.IsBlank(record_dto.mbl_agent_name))
                str += "Master Agent Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_shipment_stage_name))
                str += "Shipment Stage Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_handled_name))
                str += "Handled By Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_frt_status_name))
                str += "Fright Status Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_ship_term_name))
                str += "Shipping Term Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_cntr_type))
                str += "Shipping Type Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_pol_name))
                str += "POL Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_pol_etd))
                str += "ETD Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_pod_name))
                str += "Port.Discharge Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_pod_eta))
                str += "ETA Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_pofd_name))
                str += "Port.Final Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_country_name))
                str += "Dest.Country Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_vessel_name))
                str += "Vessel Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_voyage))
                str += "Voyage Cannot Be Blank!";
            foreach (cargo_container_dto rec in record_dto.master_cntr!)
            {
                if (Lib.IsBlank(rec.cntr_type_name))
                    type = "Type Cannot Be Blank!";
                if(!CommonLib.IsValidContainerNumber(rec.cntr_no!))
                    cntr_no = $"Invalid Container Number: {rec.cntr_no}";
                    if (Lib.IsBlank(rec.cntr_no))
                        cntr_no = "Cntr No Cannot Be Blank!";
                if (Lib.IsBlank(rec.cntr_packages_unit_name))
                    unit = "Unit Cannot Be Blank";
            }

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

        public async Task<cargo_sea_exportm_dto> SaveParentAsync(int id, string mode, cargo_sea_exportm_dto record_dto)
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

                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, "SEA-EXP-MASTER-PREFIX,SEA-EXP-MASTER-STARTING-NO");// 

                    var DefaultCfNo = 0;
                    var Defaultprefix = "";

                    if (result.ContainsKey("SEA-EXP-MASTER-STARTING-NO"))
                    {
                        DefaultCfNo = Lib.StringToInteger(result["SEA-EXP-MASTER-STARTING-NO"]);
                    }
                    if (result.ContainsKey("SEA-EXP-MASTER-PREFIX"))
                    {
                        Defaultprefix = result["SEA-EXP-MASTER-PREFIX"].ToString();
                    }
                    if (Lib.IsBlank(Defaultprefix) || Lib.IsZero(DefaultCfNo))
                    {
                        throw new Exception("Missing Sea Export master Prefix/Starting-Number in Branch Settings");
                    }

                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("Ref Number Cannot Be Generated");
                    }

                    string sqtn_no = $"{Defaultprefix}{iNextNo}";  // for setting quote no by adding propper prefix (here QL - Quotation LCL)
                    string stype = smbl_mode;

                    Record = new cargo_masterm();

                    Record.mbl_cfno = iNextNo;
                    Record.mbl_refno = sqtn_no;
                    Record.mbl_mode = stype;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.cargo_masterm
                        .Include(c => c.country)
                        .Include(c => c.salesman)
                        .Include(c => c.handledby)
                        .Include(c => c.shipstage)
                        .Include(c => c.agent)
                        .Include(c => c.liner)
                        .Include(c => c.pol)
                        .Include(c => c.pod)
                        .Include(c => c.pofd)
                        .Include(c => c.vessel)
                        .Include(c => c.shipterm)
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

                Record.mbl_ref_date = Lib.ParseDate(record_dto.mbl_ref_date!);
                if (Record.mbl_shipment_stage_id != record_dto.mbl_shipment_stage_id)
                {
                    Record.mbl_shipment_stage_id = record_dto.mbl_shipment_stage_id;

                    await CommonLib.UpdateHouseShipmentStage(context, Record.mbl_id, record_dto.mbl_shipment_stage_id);
                }
                Record.mbl_no = record_dto.mbl_no;
                Record.mbl_sub_houseno = record_dto.mbl_sub_houseno;
                Record.mbl_liner_bookingno = record_dto.mbl_liner_bookingno;

                if (Lib.IsZero(record_dto.mbl_agent_id))
                    Record.mbl_agent_id = null;
                else
                    Record.mbl_agent_id = record_dto.mbl_agent_id;

                if (Lib.IsZero(record_dto.mbl_liner_id))
                    Record.mbl_liner_id = null;
                else
                    Record.mbl_liner_id = record_dto.mbl_liner_id;

                if (Lib.IsZero(record_dto.mbl_handled_id))
                    Record.mbl_handled_id = null;
                else
                    Record.mbl_handled_id = record_dto.mbl_handled_id;

                if (Lib.IsZero(record_dto.mbl_salesman_id))
                    Record.mbl_salesman_id = null;
                else
                    Record.mbl_salesman_id = record_dto.mbl_salesman_id;

                Record.mbl_frt_status_name = record_dto.mbl_frt_status_name;
                if (Lib.IsZero(record_dto.mbl_ship_term_id))
                    Record.mbl_ship_term_id = null;
                else
                    Record.mbl_ship_term_id = record_dto.mbl_ship_term_id;

                Record.mbl_cntr_type = record_dto.mbl_cntr_type;
                Record.mbl_direct = record_dto.mbl_direct;
                Record.mbl_place_delivery = record_dto.mbl_place_delivery;

                if (Lib.IsZero(record_dto.mbl_pol_id))
                    Record.mbl_pol_id = null;
                else
                    Record.mbl_pol_id = record_dto.mbl_pol_id;
                Record.mbl_pol_etd = Lib.ParseDate(record_dto.mbl_pol_etd!);

                if (Lib.IsZero(record_dto.mbl_pod_id))
                    Record.mbl_pod_id = null;
                else
                    Record.mbl_pod_id = record_dto.mbl_pod_id;
                Record.mbl_pod_eta = Lib.ParseDate(record_dto.mbl_pod_eta!);

                if (Lib.IsZero(record_dto.mbl_pofd_id))
                    Record.mbl_pofd_id = null;
                else
                    Record.mbl_pofd_id = record_dto.mbl_pofd_id;
                Record.mbl_pofd_eta = Lib.ParseDate(record_dto.mbl_pofd_eta!);

                if (Lib.IsZero(record_dto.mbl_country_id))
                    Record.mbl_country_id = null;
                else
                    Record.mbl_country_id = record_dto.mbl_country_id;

                if (Lib.IsZero(record_dto.mbl_vessel_id))
                    Record.mbl_vessel_id = null;
                else
                    Record.mbl_vessel_id = record_dto.mbl_vessel_id;
                Record.mbl_vessel_name = record_dto.mbl_vessel_name;
                Record.mbl_voyage = record_dto.mbl_voyage;
                Record.mbl_book_slno = record_dto.mbl_book_slno;

                UpdateCntrCount(record_dto);

                Record.mbl_20 = record_dto.mbl_20;
                Record.mbl_40 = record_dto.mbl_40;
                Record.mbl_40hq = record_dto.mbl_40hq;
                Record.mbl_45 = record_dto.mbl_45;
                Record.mbl_teu = record_dto.mbl_teu;
                Record.mbl_container_tot = record_dto.mbl_container_tot;

                if (mode == "add")
                    await context.cargo_masterm.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.mbl_id = Record.mbl_id;
                record_dto.mbl_refno = Record.mbl_refno;

                //Lib.AssignDates2DTO(record_dto.cust_id, mode, Record, record_dto);

                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
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
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.mbl_mode == smbl_mode)
            .Select(e => e.mbl_cfno)
            .DefaultIfEmpty()
            .Max();

            CfNo = CfNo == 0 ? DefaultCfNo : CfNo + 1;
            return CfNo;
        }

        public async Task<cargo_sea_exportm_dto> saveCntrAsync(int id, string mode, cargo_sea_exportm_dto record_dto)
        {
            cargo_container? record;
            List<cargo_container_dto> records_dto;
            List<cargo_container> records;
            try
            {
                // get cntr details from the frontend
                records_dto = record_dto.master_cntr!;
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
                    // CommonLib.ValidContainerNumber(rec.cntr_no!);
                    // {
                    //     throw new Exception($"Invalid Container Number: {rec.cntr_no}");// 4 Character And 7 digits.
                    // }

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
        public cargo_sea_exportm_dto UpdateCntrCount(cargo_sea_exportm_dto record_dto)
        {
            try
            {

                int mbl_40hq = 0;
                int mbl_40 = 0;
                int mbl_20 = 0;
                int mbl_45 = 0;
                decimal mbl_teu = 0;
                int mbl_container_tot = 0;

                foreach (var cntr in record_dto.master_cntr!)
                {
                    var containerType = cntr.cntr_type_name;

                    if (containerType!.Contains("20"))
                    {
                        mbl_20++;
                        mbl_teu += 1.0m;
                    }
                    if (containerType.Contains("40"))
                    {
                        if (containerType!.Contains("HC"))
                        {
                            mbl_40hq++;
                            mbl_teu += 2.25m;
                        }
                        else
                        {
                            mbl_40++;
                            mbl_teu += 2.0m;
                        }

                    }
                    if (containerType.Contains("45"))
                    {
                        mbl_45++;
                        mbl_teu += 2.5m;
                    }
                    mbl_container_tot++;
                }
                record_dto.mbl_20 = mbl_20;
                record_dto.mbl_40 = mbl_40;
                record_dto.mbl_40hq = mbl_40hq;
                record_dto.mbl_45 = mbl_45;
                record_dto.mbl_teu = mbl_teu;
                record_dto.mbl_container_tot = mbl_container_tot;

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
                    var _Container = context.cargo_container
                    .Where(c => c.cntr_mbl_id == id);
                    if (_Container.Any())
                    {
                        context.cargo_container.RemoveRange(_Container);
                    }

                    var _House = context.cargo_housem
                    .Where(c => c.hbl_mbl_id == id);
                    if (_House.Any())
                    {
                        context.cargo_housem.RemoveRange(_House);
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
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task logHistory(cargo_masterm old_record, cargo_sea_exportm_dto record_dto)
        {

            var old_record_dto = new cargo_sea_exportm_dto
            {
                mbl_id = old_record.mbl_id,
                mbl_refno = old_record.mbl_refno,
                mbl_ref_date = Lib.FormatDate(old_record.mbl_ref_date, Lib.outputDateFormat),
                mbl_shipment_stage_name = old_record.shipstage?.param_name,
                mbl_no = old_record.mbl_no,
                mbl_sub_houseno = old_record.mbl_sub_houseno,
                mbl_liner_bookingno = old_record.mbl_liner_bookingno,
                mbl_agent_name = old_record.agent?.cust_name,
                mbl_liner_name = old_record.liner?.param_name,
                mbl_handled_name = old_record.handledby?.param_name,
                mbl_salesman_name = old_record.salesman?.param_name,
                mbl_frt_status_name = old_record.mbl_frt_status_name,
                mbl_ship_term_name = old_record.shipterm?.param_name,
                mbl_cntr_type = old_record.mbl_cntr_type,
                mbl_direct = old_record.mbl_direct,
                mbl_place_delivery = old_record.mbl_place_delivery,
                mbl_pol_name = old_record.pol?.param_name,
                mbl_pol_etd = Lib.FormatDate(old_record.mbl_pol_etd, Lib.outputDateFormat),
                mbl_pod_name = old_record.pod?.param_name,
                mbl_pod_eta = Lib.FormatDate(old_record.mbl_pod_eta, Lib.outputDateFormat),
                mbl_pofd_name = old_record.pofd?.param_name,
                mbl_pofd_eta = Lib.FormatDate(old_record.mbl_pofd_eta, Lib.outputDateFormat),
                mbl_country_name = old_record.country?.param_name,
                mbl_vessel_name = old_record.mbl_vessel_name,
                mbl_voyage = old_record.mbl_voyage,
                mbl_book_slno = old_record.mbl_book_slno,


            };

            await new LogHistorym<cargo_sea_exportm_dto>(context)
                .Table("cargo_masterm", log_date)
                .PrimaryKey("mbl_id", record_dto.mbl_id)
                .RefNo(record_dto.mbl_refno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("mbl_refno", "Reference No")
                .TrackColumn("mbl_ref_date", "Reference Date")
                .TrackColumn("mbl_shipment_stage_name", "Shipment Stage Name")
                .TrackColumn("mbl_no", "MBL No")
                .TrackColumn("mbl_sub_houseno", "Sub House No")
                .TrackColumn("mbl_liner_bookingno", "Liner Booking No")
                .TrackColumn("mbl_agent_name", "Agent Name")
                .TrackColumn("mbl_liner_name", "Liner Name")
                .TrackColumn("mbl_handled_name", "Handled By Name")
                .TrackColumn("mbl_salesman_name", "Salesman Name")
                .TrackColumn("mbl_frt_status_name", "Freight Status Name")
                .TrackColumn("mbl_ship_term_name", "Shipping Term Name")
                .TrackColumn("mbl_cntr_type", "Shipping Type")
                .TrackColumn("mbl_direct", "Direct Shipment")
                .TrackColumn("mbl_place_delivery", "Place of Delivery")
                .TrackColumn("mbl_pol_name", "Port of Loading")
                .TrackColumn("mbl_pol_etd", "ETD (POL)", "date")
                .TrackColumn("mbl_pod_name", "Port of Discharge")
                .TrackColumn("mbl_pod_eta", "ETA (POD)", "date")
                .TrackColumn("mbl_pofd_name", "Place of Final Delivery")
                .TrackColumn("mbl_pofd_eta", "ETA (POFD)", "date")
                .TrackColumn("mbl_country_name", "Country Name")
                .TrackColumn("mbl_vessel_name", "Vessel Name")
                .TrackColumn("mbl_voyage", "Voyage")
                .TrackColumn("mbl_book_slno", "Booking Serial No")

                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();

        }
        public async Task logHistoryCntrDetail(List<cargo_container> old_records, cargo_sea_exportm_dto record_dto)
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
                // cntr_order = record.cntr_order
            }).ToList();

            await new LogHistorym<cargo_container_dto>(context)
                .Table("cargo_masterm", log_date)
                .PrimaryKey("cntr_id", record_dto.mbl_id)
                .RefNo(record_dto.mbl_refno!)
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
                // .TrackColumn("cntr_order", "Order", "int")
                .SetRecords(old_records_dto, record_dto.master_cntr!)
                .LogChangesAsync();

        }

    }
}
