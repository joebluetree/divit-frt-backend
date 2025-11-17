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
using SeaExport.Printing;
using Marketing.Printing;

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
                var title = data["title"].ToString();
                var user_name = data["global_user_name"].ToString();
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

                if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
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
                    oth_pol_etd = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateFormat),
                    oth_pod_name = e.pod!.param_name,
                    oth_pod_eta = Lib.FormatDate(e.mbl_pod_eta, Lib.outputDateFormat),
                    oth_handled_name = e.handledby!.param_name,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),

                }).ToListAsync();
                var fileDataList = new List<filesm>();
                var searchInfo = new Dictionary<string, string>
                {
                    {"oth_from_date",oth_from_date!},
                    {"oth_to_date",oth_to_date!},
                    {"oth_refno", oth_refno! },
                };

                if (action == "PDF" || action == "PRINT")
                {
                    var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                    fileDataList.Add(pdfResult);
                }
                if (action == "EXCEL" || action == "PRINT")
                {
                    var excelResult = ProcessExcelFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                    fileDataList.Add(excelResult);
                }

                RetData.Add("fileData", fileDataList);
                RetData.Add("action", action);

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
                    oth_mode = e.mbl_mode,
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

                    rec_files_count = e.rec_files_count,
                    rec_files_attached = e.rec_files_attached,
                    rec_memo_count = e.rec_memo_count,
                    rec_memo_attached = e.rec_memo_attached,
                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                Record.otherop_cntr = await getCntrAsync(Record.oth_id, "M");
                Record.otherop_house = await GetHouseAsync(Record.oth_id);
                // await GetHouseAsync(Record.oth_id);
                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<cargo_container_dto>> getCntrAsync(int id, string cntr_catg)
        {
            var query = from e in context.cargo_container
                        .Where(a => a.cntr_mbl_id == id && a.cntr_catg == cntr_catg)
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
            // records!.otherop_cntr = await getCntrAsync(records.oth_id, "H");
            return records;
        }
        
        public async Task<cargo_otherop_dto> GetDefaultData()
        {
            try
            {
                IQueryable<mast_param> query = context.mast_param;

                query = query.Where(f => f.param_type == "SHIPSTAGE OTH" && f.param_name == "NIL");

                var Record = await query.Select(e => new cargo_otherop_dto
                {
                    oth_shipment_stage_id = e.param_id,
                    oth_shipment_stage_name = e.param_name,
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("Shipment Stage 'NIL' not found.");

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
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
                _Record = await saveCntrAsync(_Record.oth_id, "M", mode, _Record);
                _Record = await SaveHouseAsync(_Record.oth_id, mode, _Record);

                _Record.otherop_cntr = await getCntrAsync(_Record.oth_id, "M");

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

            if (Lib.IsBlank(record_dto.oth_handled_name))
                str += "Handled By Cannot Be Blank!";

            foreach (cargo_container_dto rec in record_dto.otherop_cntr!)
            {
                if (Lib.IsBlank(rec.cntr_type_name))
                    type = "Type Cannot Be Blank!";
                if (!CommonLib.IsValidContainerNumber(rec.cntr_no!))
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

                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, "OTHER-OPERATION-PREFIX,OTHER-OPERATION-STARTING-NO");// 

                    var DefaultCfNo = 0;
                    var Defaultprefix = "";

                    if (result.ContainsKey("OTHER-OPERATION-STARTING-NO"))
                    {
                        DefaultCfNo = Lib.StringToInteger(result["OTHER-OPERATION-STARTING-NO"]);
                    }
                    if (result.ContainsKey("OTHER-OPERATION-PREFIX"))
                    {
                        Defaultprefix = result["OTHER-OPERATION-PREFIX"].ToString();
                    }
                    if (Lib.IsBlank(Defaultprefix) || Lib.IsZero(DefaultCfNo))
                    {
                        throw new Exception("Missing Other Operation Prefix/Starting-Number in Branch Settings");
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
                        .Include(c => c.agent)
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
                Record.mbl_shipment_stage_id = record_dto.oth_shipment_stage_id;
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

                UpdateCntrCount(record_dto);

                Record.mbl_20 = record_dto.oth_20;
                Record.mbl_40 = record_dto.oth_40;
                Record.mbl_40hq = record_dto.oth_40hq;
                Record.mbl_45 = record_dto.oth_45;
                Record.mbl_teu = record_dto.oth_teu;
                Record.mbl_container_tot = record_dto.oth_container_tot;
                Record.mbl_cbm_tot = GetCbmTotal(record_dto);

                if (mode == "add")
                    await context.cargo_masterm.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.oth_mode = Record.mbl_mode;
                record_dto.oth_id = Record.mbl_id;
                record_dto.oth_refno = Record.mbl_refno;

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
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.mbl_mode == oth_mode)
            .Select(e => e.mbl_cfno)
            .DefaultIfEmpty()
            .Max();

            CfNo = CfNo == 0 ? DefaultCfNo : CfNo + 1;
            return CfNo;
        }

        public async Task<cargo_otherop_dto> saveCntrAsync(int id, string cntr_catg, string mode, cargo_otherop_dto record_dto)
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
                    .Where(w => w.cntr_catg == cntr_catg && w.cntr_mbl_id == id)
                    .ToListAsync();

                if (mode == "edit")
                    await logHistoryCntrDetail(records, record_dto);
                int nextorder = 1;
                //remove deleted cntr details
                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.cntr_id == existing_record.cntr_id);
                    if (rec == null)
                    {
                        context.cargo_container.Remove(existing_record);
                    }
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

                        record.cntr_catg = cntr_catg;
                    }
                    else
                    {
                        record = records.Find(f => f.cntr_id == rec.cntr_id);
                        if (record == null)
                            throw new Exception("Container Detail Record Not Found " + rec.cntr_catg!.ToString());

                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }

                    record.cntr_mbl_id = id;
                    record.cntr_no = rec.cntr_no;
                    record.cntr_type_id = rec.cntr_type_id;
                    record.cntr_sealno = rec.cntr_sealno;
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
                        .Include(c => c.shipper)
                        .Include(c => c.consignee)
                        .Include(c => c.location)
                        .Where(f => f.hbl_id == record_dto.oth_hbl_id)
                        .FirstOrDefaultAsync();

                    if (record == null)
                        throw new Exception("House Record Not Found");

                    record.rec_edited_by = record_dto.rec_created_by;
                    record.rec_edited_date = DbLib.GetDateTime();
                }

                if (mode == "edit")
                    await logHistoryHouse(record, record_dto);

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

                await SaveCntrHouseAsync(record.hbl_mbl_id, record.hbl_id, mode, record_dto);

                record_dto.oth_hbl_id = record.hbl_id;
                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public cargo_otherop_dto UpdateCntrCount(cargo_otherop_dto record_dto)
        {
            try
            {
                int oth_40hq = 0;
                int oth_40 = 0;
                int oth_20 = 0;
                int oth_45 = 0;
                decimal oth_teu = 0;
                int oth_container_tot = 0;

                foreach (var cntr in record_dto.otherop_cntr!)
                {
                    var containerType = cntr.cntr_type_name;

                    if (containerType!.Contains("20"))
                    {
                        oth_20++;
                        oth_teu += 1.0m;
                    }
                    if (containerType.Contains("40"))
                    {
                        if (containerType!.Contains("HC"))
                        {
                            oth_40hq++;
                            oth_teu += 2.25m;
                        }
                        else
                        {
                            oth_40++;
                            oth_teu += 2.0m;
                        }

                    }
                    if (containerType.Contains("45"))
                    {
                        oth_45++;
                        oth_teu += 2.5m;
                    }
                    oth_container_tot++;
                }
                record_dto.oth_20 = oth_20;
                record_dto.oth_40 = oth_40;
                record_dto.oth_40hq = oth_40hq;
                record_dto.oth_45 = oth_45;
                record_dto.oth_teu = oth_teu;
                record_dto.oth_container_tot = oth_container_tot;

                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task SaveCntrHouseAsync(int mbl_id, int hbl_id, string mode, cargo_otherop_dto record_dto)
        {
            try
            {
                var records_dto = record_dto.otherop_cntr!;

                // Get all cntr (H and M) for the mbl_id in one query
                var allCntrs = await context.cargo_container
                    .Where(c => c.cntr_mbl_id == mbl_id)
                    .ToListAsync();

                // Split house and master cntr data in seprate var
                var houseCntrs = allCntrs.Where(c => c.cntr_catg == "H" && c.cntr_hbl_id == hbl_id).ToList();
                var masterCntrs = allCntrs.Where(c => c.cntr_catg == "M").ToList();

                foreach (var m in masterCntrs)
                {
                    cargo_container? record;
                    // to find existing house container with same cntr_no under this house
                    record = houseCntrs.FirstOrDefault(h => h.cntr_no == m.cntr_no);

                    if (record == null)
                    {
                        record = new cargo_container();
                        record.rec_company_id = m.rec_company_id;
                        record.rec_branch_id = m.rec_branch_id;
                        record.rec_created_by = record_dto.rec_created_by;
                        record.rec_created_date = DbLib.GetDateTime();
                        record.rec_locked = "N";
                        record.cntr_catg = "H";
                    }
                    else
                    {
                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }

                    record.cntr_mbl_id = mbl_id;
                    record.cntr_hbl_id = hbl_id;
                    record.cntr_no = m.cntr_no;
                    record.cntr_type_id = m.cntr_type_id;
                    record.cntr_sealno = m.cntr_sealno;
                    record.cntr_pieces = m.cntr_pieces;
                    record.cntr_packages_unit_id = m.cntr_packages_unit_id;
                    record.cntr_teu = m.cntr_teu;
                    record.cntr_cbm = m.cntr_cbm;
                    record.cntr_weight_uom = m.cntr_weight_uom;
                    record.cntr_weight = m.cntr_weight;
                    record.cntr_rider = m.cntr_rider;
                    record.cntr_tare_weight = m.cntr_tare_weight;
                    record.cntr_pick_date = m.cntr_pick_date;
                    record.cntr_return_date = m.cntr_return_date;
                    record.cntr_lfd = m.cntr_lfd;
                    record.cntr_discharge_date = m.cntr_discharge_date;
                    record.cntr_order = m.cntr_order;

                    if (record.cntr_id == 0)
                        await context.cargo_container.AddAsync(record);
                }

                foreach (var rec in houseCntrs)
                {
                    bool existsInMaster = masterCntrs.Any(m => m.cntr_no == rec.cntr_no);
                    if (!existsInMaster)
                    {
                        context.cargo_container.Remove(rec);
                    }
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error copying master containers to house: " + ex.Message);
            }
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_masterm
                    .FirstOrDefaultAsync(f => f.mbl_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                if (CommonLib.InvoiceExists(context, id, _Record!.rec_company_id))
                {
                    throw new Exception("Cannot Delete, Invoice Exists");
                }
                if (CommonLib.FollowupExists(context, id, _Record!.rec_company_id))
                {
                    throw new Exception("Cannot Delete, Follow Up Exists");
                }
                else
                {

                    await CommonLib.DeleteContainer(context, id, "MASTER");
                    await CommonLib.DeleteMessengerSlip(context, id, "OTHERS");
                    await CommonLib.DeleteDeliveryOrder(context, id, "OTHERS", _Record.rec_company_id);
                    await CommonLib.DeleteMemo(context, id, "OTH-CNTR-MEMO", _Record.rec_company_id);

                    await DeleteHouses(id, "OTHERS");

                    context.Remove(_Record);
                    context.SaveChanges();

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
        public async Task DeleteHouses(int mbl_id, string type)
        {   
            var houses = await context.cargo_housem
                .Where(c => c.hbl_mbl_id == mbl_id && c.hbl_mode == type)
                .ToListAsync();

             foreach (var house in houses)
            {
                await CommonLib.DeleteContainer(context, house.hbl_id, "HOUSE");
                context.cargo_housem.Remove(house);
            }
            
            await context.SaveChangesAsync();
        }

        public async Task logHistory(cargo_masterm old_record, cargo_otherop_dto record_dto)
        {

            var old_record_dto = new cargo_otherop_dto
            {
                oth_id = old_record.mbl_id,
                oth_refno = old_record.mbl_refno,
                oth_ref_date = Lib.FormatDate(old_record.mbl_ref_date, Lib.outputDateFormat),
                oth_shipment_stage_name = old_record.shipstage?.param_name,
                oth_mbl_no = old_record.mbl_no,
                oth_agent_id = old_record.mbl_agent_id,
                oth_agent_name = old_record.agent?.cust_name,
                oth_liner_id = old_record.mbl_liner_id,
                oth_liner_name = old_record.liner?.param_name,
                oth_handled_id = old_record.mbl_handled_id,
                oth_handled_name = old_record.handledby?.param_name,
                oth_salesman_id = old_record.mbl_salesman_id,
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
                .TrackColumn("oth_refno", "Reference No")
                .TrackColumn("oth_ref_date", "Reference Date", "date")
                .TrackColumn("oth_shipment_stage_name", "Shipment Stage Name")
                .TrackColumn("oth_mbl_no", "MBL No")
                .TrackColumn("oth_agent_name", "Agent Name")
                .TrackColumn("oth_liner_name", "Carrier Name")
                .TrackColumn("oth_handled_name", "Handled By Name")
                .TrackColumn("oth_salesman_name", "Salesman Name")
                .TrackColumn("oth_mbl_frt_status", "Freight Status Name")
                .TrackColumn("oth_pol_name", "Port of Loading")
                .TrackColumn("oth_pol_etd", "ETD (POL)", "date")
                .TrackColumn("oth_pod_name", "Port of Discharge")
                .TrackColumn("oth_pod_eta", "ETA (POD)", "date")
                .TrackColumn("oth_place_delivery", "Place of Delivery")
                .TrackColumn("oth_country_name", "Country Name")
                .TrackColumn("oth_vessel_name", "Vessel Name")
                .TrackColumn("oth_voyage", "Voyage")

                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();

        }
        public async Task logHistoryHouse(cargo_housem old_record, cargo_otherop_dto record_dto)
        {
            var old_record_dto = new cargo_otherop_dto
            {
                oth_hbl_no = old_record.hbl_houseno,
                oth_bltype = old_record.hbl_bltype,

                oth_shipper_id = old_record.hbl_shipper_id,
                oth_shipper_code = old_record.shipper?.cust_code,
                oth_shipper_name = old_record.hbl_shipper_name,
                oth_shipper_add1 = old_record.hbl_shipper_add1,
                oth_shipper_add2 = old_record.hbl_shipper_add2,
                oth_shipper_add3 = old_record.hbl_shipper_add3,
                oth_shipper_add4 = old_record.hbl_shipper_add4,

                oth_consignee_id = old_record.hbl_consignee_id,
                oth_consignee_code = old_record.consignee?.cust_code,
                oth_consignee_name = old_record.hbl_consignee_name,
                oth_consignee_add1 = old_record.hbl_consignee_add1,
                oth_consignee_add2 = old_record.hbl_consignee_add2,
                oth_consignee_add3 = old_record.hbl_consignee_add3,
                oth_consignee_add4 = old_record.hbl_consignee_add4,

                oth_location_id = old_record.hbl_location_id,
                oth_location_code = old_record.location?.cust_code,
                oth_location_name = old_record.hbl_location_name,
                oth_location_add1 = old_record.hbl_location_add1,
                oth_location_add2 = old_record.hbl_location_add2,
                oth_location_add3 = old_record.hbl_location_add3,
                oth_location_add4 = old_record.hbl_location_add4,

                oth_it_no = old_record.hbl_it_no,
                oth_it_date = Lib.FormatDate(old_record.hbl_it_date, Lib.outputDateFormat),
                oth_it_port = old_record.hbl_it_port,

                oth_hbl_frt_status = old_record.hbl_frt_status_name,
                oth_packages = old_record.hbl_packages,
                oth_cbm = old_record.hbl_cbm,
                oth_weight = old_record.hbl_weight,
                oth_chwt = old_record.hbl_chwt,
                oth_lbs = old_record.hbl_lbs,
                oth_cft = old_record.hbl_cft,
                oth_chwt_lbs = old_record.hbl_chwt_lbs,
                oth_commodity = old_record.hbl_commodity,

                oth_handled_id = old_record.hbl_handled_id,
                oth_salesman_id = old_record.hbl_salesman_id,
                oth_isf_no = old_record.hbl_isf_no,
                oth_lfd_date = Lib.FormatDate(old_record.hbl_lfd_date, Lib.outputDateFormat),
                oth_shipment_stage_id = old_record.hbl_shipment_stage_id,

                oth_is_pl = old_record.hbl_is_pl,
                oth_is_ci = old_record.hbl_is_ci,
                oth_is_carr_an = old_record.hbl_is_carr_an,

                oth_custom_reles_status = old_record.hbl_custom_reles_status,
                oth_is_delivery = old_record.hbl_is_delivery
            };

            await new LogHistorym<cargo_otherop_dto>(context)
                .Table("cargo_masterm", log_date)
                .PrimaryKey("hbl_id", record_dto.oth_id)
                .RefNo(record_dto.oth_refno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_edited_by!)

                .TrackColumn("oth_hbl_no", "House No")
                .TrackColumn("oth_bltype", "BL Type")

                .TrackColumn("oth_shipper_name", "Shipper Name")
                .TrackColumn("oth_shipper_add1", "Shipper Address 1")
                .TrackColumn("oth_shipper_add2", "Shipper Address 2")
                .TrackColumn("oth_shipper_add3", "Shipper Address 3")
                .TrackColumn("oth_shipper_add4", "Shipper Address 4")

                .TrackColumn("oth_consignee_name", "Consignee Name")
                .TrackColumn("oth_consignee_add1", "Consignee Address 1")
                .TrackColumn("oth_consignee_add2", "Consignee Address 2")
                .TrackColumn("oth_consignee_add3", "Consignee Address 3")
                .TrackColumn("oth_consignee_add4", "Consignee Address 4")

                .TrackColumn("oth_location_name", "Location Name")
                .TrackColumn("oth_location_add1", "Location Address 1")
                .TrackColumn("oth_location_add2", "Location Address 2")
                .TrackColumn("oth_location_add3", "Location Address 3")
                .TrackColumn("oth_location_add4", "Location Address 4")

                .TrackColumn("oth_it_no", "IT No")
                .TrackColumn("oth_it_date", "IT Date", "date")
                .TrackColumn("oth_it_port", "IT Port")

                .TrackColumn("oth_hbl_frt_status", "Freight Status")
                .TrackColumn("oth_packages", "Packages", "int")
                .TrackColumn("oth_cbm", "CBM", "decimal")
                .TrackColumn("oth_weight", "Weight", "decimal")
                .TrackColumn("oth_chwt", "Chargeable Weight", "decimal")
                .TrackColumn("oth_lbs", "LBS", "decimal")
                .TrackColumn("oth_cft", "CFT", "decimal")
                .TrackColumn("oth_chwt_lbs", "Chargeable Weight (LBS)", "decimal")
                .TrackColumn("oth_commodity", "Commodity")

                .TrackColumn("oth_isf_no", "ISF No")
                .TrackColumn("oth_lfd_date", "LFD Date", "date")
                .TrackColumn("oth_shipment_stage_id", "Shipment Stage")

                .TrackColumn("oth_is_pl", "Packing List")
                .TrackColumn("oth_is_ci", "Commercial Invoice")
                .TrackColumn("oth_is_carr_an", "Carrier AN")

                .TrackColumn("oth_custom_reles_status", "Custom Release Status")
                .TrackColumn("oth_is_delivery", "Delivery Status")


                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }

        public async Task logHistoryCntrDetail(List<cargo_container> old_records, cargo_otherop_dto record_dto)
        {

            var old_records_dto = old_records.Select(record => new cargo_container_dto
            {
                cntr_id = record.cntr_id,
                cntr_no = record.cntr_no,
                cntr_type_name = record.cntrtype?.param_name,
                cntr_sealno = record.cntr_sealno,
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
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_edited_by!)
                .TrackColumn("cntr_no", "Container No")
                .TrackColumn("cntr_type_name", "Container Type Name")
                .TrackColumn("cntr_sealno", "Seal No")
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
        public filesm ProcessPdfFileAsync(List<cargo_otherop_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Records error");

            OtherOpPdfFile bc = new OtherOpPdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                Mbl_type = title,
                FromDate = searchInfo.ContainsKey("oth_from_date") ? searchInfo["oth_from_date"] : "",
                ToDate = searchInfo.ContainsKey("oth_to_date") ? searchInfo["oth_to_date"] : "",
                RefNo = searchInfo.ContainsKey("oth_refno") ? searchInfo["oth_refno"] : "",

            };
            bc.Process();

            if (bc.FList == null || !bc.FList.Any())
                throw new Exception("File generation failed.");

            var file = bc.FList[0];

            var record = new filesm
            {
                filepath = file.filename!,
                filename = file.filedisplayname!,
                filetype = file.filetype!
            };
            return record;
        }
        public filesm ProcessExcelFileAsync(List<cargo_otherop_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            ProcessOtherOpExcelFile bc = new ProcessOtherOpExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                Mbl_type = title,
                FromDate = searchInfo.ContainsKey("oth_from_date") ? searchInfo["oth_from_date"] : "",
                ToDate = searchInfo.ContainsKey("oth_to_date") ? searchInfo["oth_to_date"] : "",
                RefNo = searchInfo.ContainsKey("oth_refno") ? searchInfo["oth_refno"] : "",

            };
            bc.Process();

            if (bc.fList == null || !bc.fList.Any())
                throw new Exception("Excel generation failed.");

            var file = bc.fList[0];

            var record = new filesm
            {
                filepath = file.filename!,
                filename = file.filedisplayname!,
                filetype = file.filetype!
            };
            return record;
        }
    }
}
