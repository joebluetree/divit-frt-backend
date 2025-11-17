using Database;
using Database.Lib;
using Common.DTO.Masters;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;

using Common.DTO.SeaExport;
using Database.Models.Cargo;
using SeaExport.Interfaces;
using System.Threading.Tasks.Dataflow;
using System.Numerics;
using SeaExport.Printing;

//Name : Sourav V
//Created Date : 03/03/2025
//Remark : this file defines functions like Save, Delete, getList and getRecords which save/retrieve data
//version v1-03-03-2025: added full repository
//        v2-10-03-2025: edited mbl_id reference 
//        v3-15-03-2025: added function UpdateHouse and GetTeuValue
//        v4-18-03-2025: modified SaveMarksandDesc for updating logHistory
//        v5- 12/07/2025: added print report function

namespace SeaExport.Repositories
{
    public class SeaExporthRepository : ISeaExporthRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        private string shbl_mode = "SEA EXPORT";
        public SeaExporthRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var hbl_mode = "";
                var hbl_from_date = "";
                var hbl_to_date = "";
                var hbl_mbl_refno = "";
                var hbl_houseno = "";
                var company_id = 0;
                var branch_id = 0;

                DateTime? from_date = null;
                DateTime? to_date = null;

                if (data.ContainsKey("hbl_mode"))
                    hbl_mode = data["hbl_mode"].ToString();
                if (data.ContainsKey("hbl_from_date"))
                    hbl_from_date = data["hbl_from_date"].ToString();
                if (data.ContainsKey("hbl_to_date"))
                    hbl_to_date = data["hbl_to_date"].ToString();
                if (data.ContainsKey("hbl_mbl_refno"))
                    hbl_mbl_refno = data["hbl_mbl_refno"].ToString();
                if (data.ContainsKey("hbl_houseno"))
                    hbl_houseno = data["hbl_houseno"].ToString();

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

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.hbl_mode == shbl_mode);

                if (!Lib.IsBlank(hbl_from_date))
                {
                    from_date = Lib.ParseDate(hbl_from_date!);
                    query = query.Where(w => w.master!.mbl_date >= from_date);
                }
                if (!Lib.IsBlank(hbl_to_date))
                {
                    to_date = Lib.ParseDate(hbl_to_date!);
                    query = query.Where(w => w.master!.mbl_date <= to_date);
                }
                if (!Lib.IsBlank(hbl_houseno))
                    query = query.Where(w => w.hbl_houseno!.Contains(hbl_houseno!));
                if (!Lib.IsBlank(hbl_mbl_refno))
                    query = query.Where(w => w.master!.mbl_refno!.Contains(hbl_mbl_refno!));

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
                    .OrderBy(c => c.hbl_houseno)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_sea_exporth_dto
                {
                    hbl_id = e.hbl_id,
                    hbl_mbl_refno = e.master!.mbl_refno,
                    hbl_mbl_no = e.master!.mbl_no,
                    hbl_houseno = e.hbl_houseno,
                    hbl_shipper_name = e.hbl_shipper_name,
                    hbl_consignee_name = e.hbl_consignee_name,
                    hbl_pcs = e.hbl_pcs,
                    hbl_handled_name = e.handledby!.param_name,
                    hbl_mbl_pol_etd = Lib.FormatDate(e.master!.mbl_pol_etd, Lib.outputDateFormat),
                    hbl_mbl_pod_eta = Lib.FormatDate(e.master!.mbl_pod_eta, Lib.outputDateFormat),

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).ToListAsync();
                var fileDataList = new List<filesm>();
                var searchInfo = new Dictionary<string, string>
                {
                    {"hbl_from_date",hbl_from_date!},
                    {"hbl_to_date",hbl_to_date!},
                    {"hbl_mbl_refno", hbl_mbl_refno!},
                    {"hbl_houseno", hbl_houseno!},
                };

                if (action == "PDF" || action == "PRINT")
                {
                    var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, hbl_houseno!, user_name!, branch_id, searchInfo);
                    fileDataList.Add(pdfResult);
                }
                if (action == "EXCEL" || action == "PRINT")
                {
                    var excelResult = ProcessExcelFileAsync(Records, title!, company_id, hbl_houseno!, user_name!, branch_id, searchInfo);
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
        public async Task<cargo_sea_exporth_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_housem> query = context.cargo_housem;
                //.Include(e => e.customer);

                query = query.Where(f => f.hbl_id == id);

                var Record = await query.Select(e => new cargo_sea_exporth_dto
                {
                    hbl_id = e.hbl_id,
                    hbl_mbl_id = e.hbl_mbl_id,
                    hbl_cfno = e.hbl_cfno,
                    hbl_mbl_refno = e.master!.mbl_refno,
                    hbl_houseno = e.hbl_houseno,
                    hbl_bltype = e.hbl_bltype,
                    hbl_shipment_stage_id = e.master.mbl_shipment_stage_id,
                    hbl_shipment_stage_name = e.master.shipstage!.param_name,
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
                    hbl_notify_id = e.hbl_notify_id,
                    hbl_notify_code = e.notify!.cust_code,
                    hbl_notify_name = e.hbl_notify_name,
                    hbl_notify_add1 = e.hbl_notify_add1,
                    hbl_notify_add2 = e.hbl_notify_add2,
                    hbl_notify_add3 = e.hbl_notify_add3,
                    hbl_notify_add4 = e.hbl_notify_add4,
                    hbl_notify_add5 = e.hbl_notify_add5,

                    hbl_exp_ref1 = e.hbl_exp_ref1,
                    hbl_exp_ref2 = e.hbl_exp_ref2,
                    hbl_exp_ref3 = e.hbl_exp_ref3,
                    hbl_agent_id = e.hbl_agent_id,//from master
                    hbl_agent_name = e.agent!.cust_name,
                    hbl_origin = e.hbl_origin,
                    hbl_rout1 = e.hbl_rout1,
                    hbl_rout2 = e.hbl_rout2,
                    hbl_rout3 = e.hbl_rout3,
                    hbl_rout4 = e.hbl_rout4,
                    hbl_pre_carriage = e.hbl_pre_carriage,
                    hbl_place_receipt = e.hbl_place_receipt,

                    hbl_pol_name = e.hbl_pol_name,//from master
                    hbl_pod_name = e.hbl_pod_name,//from master
                    hbl_place_delivery = e.hbl_place_delivery,//from master
                    hbl_pofd_name = e.hbl_pofd_name,
                    hbl_type_move = e.hbl_type_move,
                    hbl_is_cntrized = e.hbl_is_cntrized,
                    hbl_frt_status_name = e.hbl_frt_status_name,
                    hbl_handled_id = e.hbl_handled_id,
                    hbl_handled_name = e.handledby!.param_name,
                    hbl_salesman_id = e.hbl_salesman_id,
                    hbl_salesman_name = e.salesman!.param_name,
                    hbl_goods_nature = e.hbl_goods_nature,
                    hbl_commodity = e.hbl_commodity,
                    hbl_is_arranged = e.hbl_is_arranged,
                    hbl_obl_telex = e.hbl_obl_telex,
                    hbl_obl_slno = e.hbl_obl_slno,
                    hbl_format_id = e.hbl_format_id,
                    hbl_format_name = e.format!.param_name,
                    hbl_draft_format_id = e.hbl_draft_format_id,
                    hbl_draft_format_name = e.draftformat!.param_name,

                    hbl_lbs = e.hbl_lbs,
                    hbl_weight = e.hbl_weight,
                    hbl_cft = e.hbl_cft,
                    hbl_cbm = e.hbl_cbm,
                    hbl_pcs = e.hbl_pcs,
                    hbl_packages = e.hbl_packages,
                    hbl_uom_id = e.hbl_uom_id,
                    hbl_uom_name = e.packageunit!.param_name,
                    hbl_print_kgs = e.hbl_print_kgs,
                    hbl_print_lbs = e.hbl_print_lbs,
                    hbl_clean = e.hbl_clean,
                    hbl_remark1 = e.hbl_remark1,
                    hbl_remark2 = e.hbl_remark2,
                    hbl_remark3 = e.hbl_remark3,
                    hbl_by1 = e.hbl_by1,
                    hbl_by2 = e.hbl_by2,
                    hbl_issued_place = e.hbl_issued_place,
                    hbl_issued_date = Lib.FormatDate(e.hbl_issued_date, Lib.outputDateFormat),
                    hbl_delivery_date = Lib.FormatDate(e.hbl_delivery_date, Lib.outputDateFormat),
                    hbl_originals = e.hbl_originals,

                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                Record.house_cntr = await getCntrAsync(Record.hbl_id);

                await GetCargoDesc(Record);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<List<cargo_container_dto>> GetMastCntrAsync(int id)
        {
            var query = from e in context.cargo_container
                        .Where(a => a.cntr_mbl_id == id && a.cntr_catg == "M")
                        .OrderBy(o => o.cntr_order)
                        select (new cargo_container_dto
                        {
                            // cntr_id = e.cntr_id,
                            cntr_hbl_id = e.cntr_hbl_id,
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
                            cntr_packages = e.cntr_packages,
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
        public async Task<List<cargo_container_dto>> getCntrAsync(int id)
        {
            var query = from e in context.cargo_container
                        .Where(a => a.cntr_hbl_id == id && a.cntr_catg == "H")
                        .OrderBy(o => o.cntr_order)
                        select (new cargo_container_dto
                        {
                            cntr_id = e.cntr_id,
                            cntr_hbl_id = id,
                            cntr_mbl_id = e.cargom!.mbl_id,
                            cntr_catg = e.cntr_catg,
                            cntr_no = e.cntr_no,
                            cntr_type_id = e.cntr_type_id,
                            cntr_type_name = e.cntrtype!.param_name,
                            cntr_sealno = e.cntr_sealno,
                            cntr_movement = e.cntr_movement,
                            cntr_pieces = e.cntr_pieces,
                            cntr_packages_unit_id = e.cntr_packages_unit_id,
                            cntr_packages_unit_name = e.packunit!.param_name,
                            cntr_packages = e.cntr_packages,
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
        public async Task GetCargoDesc(cargo_sea_exporth_dto Record)
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
        public async Task<cargo_sea_exporth_dto?> GetDefaultData(int id)
        {
            try
            {
                IQueryable<cargo_masterm> query = context.cargo_masterm;

                query = query.Where(f => f.mbl_id == id && f.mbl_mode == shbl_mode);

                var Record = await query.Select(e => new cargo_sea_exporth_dto
                {
                    hbl_mbl_id = e.mbl_id,
                    hbl_shipment_stage_id = e.mbl_shipment_stage_id,
                    hbl_shipment_stage_name = e.shipstage!.param_name,
                    hbl_mbl_refno = e.mbl_refno,
                    hbl_agent_id = e.mbl_agent_id,
                    hbl_agent_name = e.agent!.cust_name,
                    hbl_pol_name = e.pol!.param_name,
                    hbl_pod_name = e.pod!.param_name,
                    hbl_place_delivery = e.mbl_place_delivery,
                    hbl_handled_id = e.mbl_handled_id,
                    hbl_handled_name = e.handledby!.param_name,
                    hbl_salesman_id = e.mbl_salesman_id,
                    hbl_salesman_name = e.salesman!.param_name,
                    hbl_by1 = e.handledby!.param_name,
                    hbl_issued_date = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateFormat),
                    marks1 = new cargo_desc_dto
                    {
                        desc_description = e.mbl_cntr_type == "FCL" || e.mbl_cntr_type == "CONSOLE" ? "SAID TO CONTAIN" :
                              e.mbl_cntr_type == "LCL" ? "SHIPPERS'S LOAD, COUNT, AND SEALED" :
                              ""

                    },
                    marks2 = new cargo_desc_dto
                    {
                        desc_description = e.mbl_cntr_type == "LCL" ? "SAID TO CONTAIN" : ""
                    },
                    hbl_notify_name = "SAME AS CONSIGNEE",
                    rec_branch_id = e.rec_branch_id,
                    rec_company_id = e.rec_company_id,
                }).FirstOrDefaultAsync();

                var caption = new List<string> { "DEFAULT-DRAFT-FORMAT", "DEFAULT-BLANK-FORMAT" };

                var settings = await context.mast_settings
                .Where(f => f.rec_company_id == Record!.rec_company_id && f.rec_branch_id == Record.rec_branch_id && caption.Contains(f.caption!))
                .ToListAsync();

                var blank_format_id = settings.FirstOrDefault(s => s.caption == "DEFAULT-BLANK-FORMAT")?.value;
                var blank_format_name = settings.FirstOrDefault(s => s.caption == "DEFAULT-BLANK-FORMAT")?.name;
                var draft_format_id = settings.FirstOrDefault(s => s.caption == "DEFAULT-DRAFT-FORMAT")?.value;
                var draft_format_name = settings.FirstOrDefault(s => s.caption == "DEFAULT-DRAFT-FORMAT")?.name;

                if (Record != null)
                {
                    Record.hbl_format_id = Lib.StringToInteger(blank_format_id!);
                    Record.hbl_format_name = blank_format_name;
                    Record.hbl_draft_format_id = Lib.StringToInteger(draft_format_id!);
                    Record.hbl_draft_format_name = draft_format_name;
                }

                if (Record == null)
                    throw new Exception("No Data Found");

                Record.house_cntr = await GetMastCntrAsync(id);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<cargo_sea_exporth_dto> SaveAsync(int id, string mode, cargo_sea_exporth_dto record_dto) //string mark,string package,string desc,int ctr,
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_sea_exporth_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await saveCntrAsync(_Record.hbl_id, mode, _Record);
                _Record = await SaveCargoDesc(_Record.hbl_id, mode, record_dto);
                await CommonLib.SaveMasterSummary(this.context, record_dto.hbl_mbl_id);

                _Record.house_cntr = await getCntrAsync(_Record.hbl_id);

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


        private Boolean AllValid(string mode, cargo_sea_exporth_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";
            string type = "";
            string unit = "";
            string cntr_no = "";


            if (Lib.IsZero(record_dto.hbl_shipment_stage_id))
                str += "Stage Cannot Be Blank! ";
            if (Lib.IsBlank(record_dto.hbl_shipper_code))
                str += "Shipper Code Cannot Be Blank! ";
            if (Lib.IsBlank(record_dto.hbl_shipper_name))
                str += "Shipper Name Cannot Be Blank! ";
            if (Lib.IsBlank(record_dto.hbl_shipper_add1))
                str += "Shipper Adress1 Cannot Be Blank! ";
            if (Lib.IsBlank(record_dto.hbl_consignee_code))
                str += "Consignee Code Cannot Be Blank! ";
            if (Lib.IsBlank(record_dto.hbl_consignee_name))
                str += "Consignee Name Cannot Be Blank! ";
            if (Lib.IsBlank(record_dto.hbl_pol_name))
                str += "Pol cannot be blank! ";
            if (Lib.IsBlank(record_dto.hbl_pod_name))
                str += "Pod cannot be blank! ";
            if (Lib.IsBlank(record_dto.hbl_frt_status_name))
                str += "Fright Status Cannot Be Blank! ";
            if (Lib.IsBlank(record_dto.hbl_bltype))
                str += "Client.Type Cannot Be Blank! ";
            if (Lib.IsZero(record_dto.hbl_lbs))
                str += "LBS Cannot Be Blank! ";
            if (Lib.IsZero(record_dto.hbl_weight))
                str += "Weight Cannot Be Blank! ";
            if (Lib.IsZero(record_dto.hbl_cft))
                str += "CFT Cannot Be Blank! ";
            if (Lib.IsZero(record_dto.hbl_cbm))
                str += "CBM Cannot Be Blank! ";
            if (Lib.IsZero(record_dto.hbl_packages))
                str += "PKGS Cannot Be Blank! ";
            if (Lib.IsBlank(record_dto.hbl_uom_name))
                str += "Uom Cannot Be Blank! ";
            foreach (cargo_container_dto rec in record_dto.house_cntr!)
            {
                if (Lib.IsBlank(rec.cntr_type_name))
                    type = "Type Cannot Be Blank! ";
                if (!CommonLib.IsValidContainerNumber(rec.cntr_no!))
                    cntr_no = $"Invalid Container Number: {rec.cntr_no}";
                if (Lib.IsBlank(rec.cntr_no))
                    cntr_no = "Cntr No Cannot Be Blank! ";
                if (Lib.IsBlank(rec.cntr_packages_unit_name))
                    unit = "Unit Cannot Be Blank! ";
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

        public async Task<cargo_sea_exporth_dto> SaveParentAsync(int id, string mode, cargo_sea_exporth_dto record_dto)
        {

            cargo_housem? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {

                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, "SEA-EXP-HOUSE-PREFIX,SEA-EXP-HOUSE-STARTING-NO");

                    var DefaultCfNo = 0;
                    var Defaultprefix = "";

                    if (result.ContainsKey("SEA-EXP-HOUSE-STARTING-NO"))
                    {
                        DefaultCfNo = Lib.StringToInteger(result["SEA-EXP-HOUSE-STARTING-NO"]);
                    }
                    if (result.ContainsKey("SEA-EXP-HOUSE-PREFIX"))
                    {
                        Defaultprefix = result["SEA-EXP-HOUSE-PREFIX"].ToString();
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

                    string sqtn_no = $"{Defaultprefix}{iNextNo}";  // to set ref no: by adding propper prefix
                    string stype = shbl_mode;

                    Record = new cargo_housem();

                    Record.hbl_cfno = iNextNo;
                    Record.hbl_houseno = sqtn_no;
                    Record.hbl_mode = stype;
                    Record.hbl_mbl_id = record_dto.hbl_mbl_id;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.cargo_housem
                        // .Include(c => c.master)
                        .Include(c => c.shipstage)
                        .Include(c => c.shipper)
                        .Include(c => c.consignee)
                        .Include(c => c.notify)
                        .Include(c => c.agent)
                        .Include(c => c.salesman)
                        .Include(c => c.handledby)
                        .Include(c => c.format)
                        .Include(c => c.draftformat)
                        .Include(c => c.packageunit)

                        .Where(f => f.hbl_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    record_dto.rec_version = Record.rec_version;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }


                if (mode == "edit")
                    await logHistory(Record, record_dto);

                if (Lib.IsZero(record_dto.hbl_shipment_stage_id))
                    Record.hbl_shipment_stage_id = null;
                else
                    Record.hbl_shipment_stage_id = record_dto.hbl_shipment_stage_id;
                Record.hbl_bltype = record_dto.hbl_bltype;

                if (Lib.IsZero(record_dto.hbl_shipper_id))
                    Record.hbl_shipper_id = null;
                else
                    Record.hbl_shipper_id = record_dto.hbl_shipper_id;
                Record.hbl_shipper_name = record_dto.hbl_shipper_name;
                Record.hbl_shipper_add1 = record_dto.hbl_shipper_add1;
                Record.hbl_shipper_add2 = record_dto.hbl_shipper_add2;
                Record.hbl_shipper_add3 = record_dto.hbl_shipper_add3;
                Record.hbl_shipper_add4 = record_dto.hbl_shipper_add4;
                Record.hbl_shipper_add5 = record_dto.hbl_shipper_add5;

                if (Lib.IsZero(record_dto.hbl_consignee_id))
                    Record.hbl_consignee_id = null;
                else
                    Record.hbl_consignee_id = record_dto.hbl_consignee_id;
                Record.hbl_consignee_name = record_dto.hbl_consignee_name;
                Record.hbl_consignee_add1 = record_dto.hbl_consignee_add1;
                Record.hbl_consignee_add2 = record_dto.hbl_consignee_add2;
                Record.hbl_consignee_add3 = record_dto.hbl_consignee_add3;
                Record.hbl_consignee_add4 = record_dto.hbl_consignee_add4;
                Record.hbl_consignee_add5 = record_dto.hbl_consignee_add5;

                if (Lib.IsZero(record_dto.hbl_notify_id))
                    Record.hbl_notify_id = null;
                else
                    Record.hbl_notify_id = record_dto.hbl_notify_id;
                Record.hbl_notify_name = record_dto.hbl_notify_name;
                Record.hbl_notify_add1 = record_dto.hbl_notify_add1;
                Record.hbl_notify_add2 = record_dto.hbl_notify_add2;
                Record.hbl_notify_add3 = record_dto.hbl_notify_add3;
                Record.hbl_notify_add4 = record_dto.hbl_notify_add4;
                Record.hbl_notify_add5 = record_dto.hbl_notify_add5;

                Record.hbl_exp_ref1 = record_dto.hbl_exp_ref1;
                Record.hbl_exp_ref2 = record_dto.hbl_exp_ref2;
                Record.hbl_exp_ref3 = record_dto.hbl_exp_ref3;

                if (Lib.IsZero(record_dto.hbl_agent_id))
                    Record.hbl_agent_id = null;
                else
                    Record.hbl_agent_id = record_dto.hbl_agent_id;
                Record.hbl_agent_name = record_dto.hbl_agent_name;
                Record.hbl_origin = record_dto.hbl_origin;
                Record.hbl_rout1 = record_dto.hbl_rout1;
                Record.hbl_rout2 = record_dto.hbl_rout2;
                Record.hbl_rout3 = record_dto.hbl_rout3;
                Record.hbl_rout4 = record_dto.hbl_rout4;
                Record.hbl_pre_carriage = record_dto.hbl_pre_carriage;
                Record.hbl_place_receipt = record_dto.hbl_place_receipt;
                Record.hbl_pol_name = record_dto.hbl_pol_name;
                Record.hbl_pod_name = record_dto.hbl_pod_name;
                Record.hbl_place_delivery = record_dto.hbl_place_delivery;
                Record.hbl_pofd_name = record_dto.hbl_pofd_name;
                Record.hbl_type_move = record_dto.hbl_type_move;
                Record.hbl_is_cntrized = record_dto.hbl_is_cntrized;
                Record.hbl_frt_status_name = record_dto.hbl_frt_status_name;

                if (Lib.IsZero(record_dto.hbl_handled_id))
                    Record.hbl_handled_id = null;
                else
                    Record.hbl_handled_id = record_dto.hbl_handled_id;
                if (Lib.IsZero(record_dto.hbl_salesman_id))
                    Record.hbl_salesman_id = null;
                else
                    Record.hbl_salesman_id = record_dto.hbl_salesman_id;
                Record.hbl_goods_nature = record_dto.hbl_goods_nature;
                Record.hbl_commodity = record_dto.hbl_commodity;
                Record.hbl_is_arranged = record_dto.hbl_is_arranged;
                Record.hbl_obl_telex = record_dto.hbl_obl_telex;
                Record.hbl_obl_slno = record_dto.hbl_obl_slno;
                if (Lib.IsZero(record_dto.hbl_format_id))
                    Record.hbl_format_id = null;
                else
                    Record.hbl_format_id = record_dto.hbl_format_id;

                if (Lib.IsZero(record_dto.hbl_draft_format_id))
                    Record.hbl_draft_format_id = null;
                else
                    Record.hbl_draft_format_id = record_dto.hbl_draft_format_id;

                Record.hbl_lbs = record_dto.hbl_lbs;
                Record.hbl_weight = record_dto.hbl_weight;
                Record.hbl_cft = record_dto.hbl_cft;
                Record.hbl_cbm = record_dto.hbl_cbm;
                Record.hbl_pcs = record_dto.hbl_pcs;
                Record.hbl_packages = record_dto.hbl_packages;
                if (Lib.IsZero(record_dto.hbl_uom_id))
                    Record.hbl_uom_id = null;
                else
                    Record.hbl_uom_id = record_dto.hbl_uom_id;

                Record.hbl_print_kgs = record_dto.hbl_print_kgs;
                Record.hbl_print_lbs = record_dto.hbl_print_lbs;
                Record.hbl_clean = record_dto.hbl_clean;
                Record.hbl_remark1 = record_dto.hbl_remark1;
                Record.hbl_remark2 = record_dto.hbl_remark2;
                Record.hbl_remark3 = record_dto.hbl_remark3;
                Record.hbl_by1 = record_dto.hbl_by1;
                Record.hbl_by2 = record_dto.hbl_by2;
                Record.hbl_issued_place = record_dto.hbl_issued_place;
                Record.hbl_issued_date = Lib.ParseDate(record_dto.hbl_issued_date!);
                Record.hbl_delivery_date = Lib.ParseDate(record_dto.hbl_delivery_date!);
                Record.hbl_originals = record_dto.hbl_originals;


                if (mode == "add")
                    await context.cargo_housem.AddAsync(Record);


                await context.SaveChangesAsync();

                // await SaveMasterSummary(record_dto.hbl_mbl_id);

                record_dto.hbl_id = Record.hbl_id;
                record_dto.hbl_mbl_id = Record.hbl_mbl_id;
                record_dto.hbl_houseno = Record.hbl_houseno;
                record_dto.rec_version = Record.rec_version;
                //Lib.AssignDates2DTO(record_dto.cust_id, mode, Record, record_dto);

                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (mode == "edit")
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }

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

            var CfNo = context.cargo_housem
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.hbl_mode == shbl_mode)
            .Select(e => e.hbl_cfno)
            .DefaultIfEmpty()
            .Max();

            CfNo = CfNo == 0 ? DefaultCfNo : CfNo + 1;
            return CfNo;
        }

        public async Task<cargo_sea_exporth_dto> saveCntrAsync(int id, string mode, cargo_sea_exporth_dto record_dto)
        {
            cargo_container? record;
            List<cargo_container_dto> records_dto;
            List<cargo_container> records;
            try
            {
                // get cntr details from the frontend
                records_dto = record_dto.house_cntr!;
                // read the cntr details from database
                records = await context.cargo_container
                    .Include(c => c.cntrtype)
                    .Include(c => c.packunit)
                    .Where(w => w.cntr_hbl_id == id)
                    .ToListAsync();

                if (mode == "edit")
                    await logHistoryDetail(records, record_dto);
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

                        record.cntr_catg = "H";
                        record.cntr_mbl_id = record_dto.hbl_mbl_id;
                    }
                    else
                    {
                        record = records.Find(f => f.cntr_id == rec.cntr_id);
                        if (record == null)
                            throw new Exception("Detail Record Not Found " + rec.cntr_id.ToString());

                        // record.rec_version++;
                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }

                    record.cntr_hbl_id = id;
                    record.cntr_no = rec.cntr_no;
                    record.cntr_type_id = rec.cntr_type_id;
                    record.cntr_sealno = rec.cntr_sealno;
                    record.cntr_movement = rec.cntr_movement;
                    record.cntr_pieces = rec.cntr_pieces;
                    record.cntr_packages_unit_id = rec.cntr_packages_unit_id;
                    record.cntr_packages = rec.cntr_packages;
                    record.cntr_teu = CommonLib.UpdateTeuValue(rec.cntr_type_name!); //updating teu value
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
        public async Task<cargo_sea_exporth_dto> SaveCargoDesc(int id, string mode, cargo_sea_exporth_dto record_dto)
        {
            try
            {
                var marks = new List<cargo_desc_dto?>
                {
                    record_dto.marks1,
                    record_dto.marks2,
                    record_dto.marks3,
                    record_dto.marks4,
                    record_dto.marks5,
                    record_dto.marks6,
                    record_dto.marks7,
                    record_dto.marks8,
                    record_dto.marks9,
                    record_dto.marks10,
                    record_dto.marks11,
                    record_dto.marks12,
                    record_dto.marks13,
                    record_dto.marks14,
                    record_dto.marks15,
                    record_dto.marks16,
                    record_dto.marks17,

                };

                await SaveMarksandNumber(id, mode, marks, record_dto);

                return record_dto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<cargo_sea_exporth_dto> SaveMarksandNumber(int id, string mode, List<cargo_desc_dto?> marks, cargo_sea_exporth_dto record_dto)
        {
            cargo_desc? Record;
            // Boolean bOk = true;
            string DescMode = "";
            int ctr = 0;

            try
            {
                if (marks == null || marks.Count == 0)
                    throw new Exception("Marks and Numbers are NULL");

                // int ctr = 1;
                foreach (var markItem in marks)
                {
                    Boolean bOk = true;
                    if (markItem == null)
                    {
                        throw new Exception("Description Record Not Found" + markItem!.desc_ctr);
                    }

                    ctr++;
                    var desc_id = markItem.desc_id;
                    var mark = markItem.desc_mark;
                    var package = markItem.desc_package;
                    var description = markItem.desc_description;


                    if (Lib.IsBlank(mark) && Lib.IsBlank(package) && Lib.IsBlank(description))
                        bOk = false;
                    if (bOk == false && desc_id == 0)
                        continue;


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
                        desc_package = package,
                        desc_description = description,
                        rec_company_id = record_dto.rec_company_id,
                        rec_branch_id = record_dto.rec_branch_id,
                        rec_created_by = record_dto.rec_created_by,
                        rec_version = record_dto.rec_version
                    };

                    if (DescMode == "add")
                    {
                        Record = new cargo_desc();

                        Record.rec_company_id = record_dto.rec_company_id;
                        Record.rec_branch_id = record_dto.rec_branch_id;
                        Record.rec_created_by = record_dto.rec_created_by;
                        Record.rec_created_date = DbLib.GetDateTime();
                        Record.rec_locked = "N";

                        Record.desc_parent_type = "SE-DESC";
                        Record.desc_parent_id = id;

                        if (mode == "edit")
                            await logHistoryCargoDesc(Record, NewRecord_dto, record_dto.hbl_houseno!, record_dto.hbl_id);//,record_dto.rec_version

                        Record.desc_ctr = NewRecord_dto.desc_ctr;
                        Record.desc_mark = NewRecord_dto.desc_mark;
                        Record.desc_package = NewRecord_dto.desc_package;
                        Record.desc_description = NewRecord_dto.desc_description;
                        Record.rec_version = record_dto.rec_version;

                    }
                    else
                    {
                        Record = await context.cargo_desc
                            .Where(f => f.desc_parent_id == id && f.desc_id == desc_id)//&& f.desc_id == desc_id
                            .FirstOrDefaultAsync();

                        if (Record == null)
                            throw new Exception("Description record Not Found" + Record!.desc_ctr.ToString());

                        if (DescMode == "edit" || DescMode == "delete")
                        {


                            await logHistoryCargoDesc(Record, NewRecord_dto, record_dto.hbl_houseno!, record_dto.hbl_id);//,record_dto.rec_version

                            // Record.desc_ctr = NewRecord_dto.desc_ctr;
                            Record.desc_mark = NewRecord_dto.desc_mark;
                            Record.desc_package = NewRecord_dto.desc_package;
                            Record.desc_description = NewRecord_dto.desc_description;

                            Record.rec_edited_by = record_dto.rec_created_by;
                            Record.rec_edited_date = DbLib.GetDateTime();
                            // Record.rec_version =record_dto.rec_version;
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

                    // record_dto.rec_version = Record.rec_version;
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
                throw new Exception(ex.Message);
            }
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_housem
                    .FirstOrDefaultAsync(f => f.hbl_id == id);

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                if (CommonLib.InvoiceExists(context, _Record!.hbl_mbl_id, _Record.rec_company_id))
                {
                    throw new Exception("Cannot Delete, Invoice Exists");
                }
                else
                {
                    await CommonLib.DeleteContainer(context, id, "HOUSE");
                    await CommonLib.DeleteDesc(context, id, "SE-DESC");
                    await CommonLib.DeleteGenRemark(context, id, "SEA EXPORT");

                    var mbl_id = _Record!.hbl_mbl_id;
                    context.Remove(_Record);
                    context.SaveChanges();
                    await CommonLib.SaveMasterSummary(this.context, mbl_id);

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
        private async Task DeleteGenRemark( int id, string type, int rec_company_id)
        {
            var _Remark = await context.gen_remarkm
                .Where(c => c.remk_parent_id == id && c.remk_parent_type == type && c.rec_company_id == rec_company_id)
                .ToListAsync();

            if (_Remark != null)
            {
                context.gen_remarkm.RemoveRange(_Remark);
            }
        }
        public async Task logHistory(cargo_housem old_record, cargo_sea_exporth_dto record_dto)
        {
            var old_record_dto = new cargo_sea_exporth_dto
            {
                hbl_id = old_record.hbl_id,
                hbl_houseno = old_record.hbl_houseno,
                hbl_bltype = old_record.hbl_bltype,
                hbl_shipment_stage_name = old_record.shipstage?.param_name,
                hbl_shipper_code = old_record.shipper?.cust_code,
                hbl_shipper_name = old_record.hbl_shipper_name,
                hbl_shipper_add1 = old_record.hbl_shipper_add1,
                hbl_shipper_add2 = old_record.hbl_shipper_add2,
                hbl_shipper_add3 = old_record.hbl_shipper_add3,
                hbl_shipper_add4 = old_record.hbl_shipper_add4,
                hbl_shipper_add5 = old_record.hbl_shipper_add5,
                hbl_consignee_code = old_record.consignee?.cust_code,
                hbl_consignee_name = old_record.hbl_consignee_name,
                hbl_consignee_add1 = old_record.hbl_consignee_add1,
                hbl_consignee_add2 = old_record.hbl_consignee_add2,
                hbl_consignee_add3 = old_record.hbl_consignee_add3,
                hbl_consignee_add4 = old_record.hbl_consignee_add4,
                hbl_consignee_add5 = old_record.hbl_consignee_add5,
                hbl_notify_code = old_record.notify?.cust_code,
                hbl_notify_name = old_record.hbl_notify_name,
                hbl_notify_add1 = old_record.hbl_notify_add1,
                hbl_notify_add2 = old_record.hbl_notify_add2,
                hbl_notify_add3 = old_record.hbl_notify_add3,
                hbl_notify_add4 = old_record.hbl_notify_add4,
                hbl_notify_add5 = old_record.hbl_notify_add5,
                hbl_exp_ref1 = old_record.hbl_exp_ref1,
                hbl_exp_ref2 = old_record.hbl_exp_ref2,
                hbl_exp_ref3 = old_record.hbl_exp_ref3,
                hbl_agent_name = old_record.agent?.cust_name,
                hbl_origin = old_record.hbl_origin,
                hbl_rout1 = old_record.hbl_rout1,
                hbl_rout2 = old_record.hbl_rout2,
                hbl_rout3 = old_record.hbl_rout3,
                hbl_rout4 = old_record.hbl_rout4,
                hbl_pre_carriage = old_record.hbl_pre_carriage,
                hbl_place_receipt = old_record.hbl_place_receipt,
                hbl_pol_name = old_record.hbl_pol_name,
                hbl_pod_name = old_record.hbl_pod_name,
                hbl_place_delivery = old_record.hbl_place_delivery,
                hbl_pofd_name = old_record.hbl_pofd_name,
                hbl_type_move = old_record.hbl_type_move,
                hbl_is_cntrized = old_record.hbl_is_cntrized,
                hbl_frt_status_name = old_record.hbl_frt_status_name,
                hbl_handled_name = old_record.handledby?.param_name,
                hbl_salesman_name = old_record.salesman?.param_name,
                hbl_goods_nature = old_record.hbl_goods_nature,
                hbl_commodity = old_record.hbl_commodity,
                hbl_is_arranged = old_record.hbl_is_arranged,
                hbl_obl_telex = old_record.hbl_obl_telex,
                hbl_obl_slno = old_record.hbl_obl_slno,
                hbl_format_name = old_record.format?.param_name,
                hbl_draft_format_name = old_record.draftformat?.param_name,
                hbl_lbs = old_record.hbl_lbs,
                hbl_weight = old_record.hbl_weight,
                hbl_cft = old_record.hbl_cft,
                hbl_cbm = old_record.hbl_cbm,
                hbl_pcs = old_record.hbl_pcs,
                hbl_packages = old_record.hbl_packages,
                hbl_uom_name = old_record.packageunit?.param_name,
                hbl_print_kgs = old_record.hbl_print_kgs,
                hbl_print_lbs = old_record.hbl_print_lbs,
                hbl_clean = old_record.hbl_clean,
                hbl_remark1 = old_record.hbl_remark1,
                hbl_remark2 = old_record.hbl_remark2,
                hbl_remark3 = old_record.hbl_remark3,
                hbl_by1 = old_record.hbl_by1,
                hbl_by2 = old_record.hbl_by2,
                hbl_issued_place = old_record.hbl_issued_place,
                hbl_issued_date = Lib.FormatDate(old_record.hbl_issued_date, Lib.outputDateFormat),
                hbl_delivery_date = Lib.FormatDate(old_record.hbl_delivery_date, Lib.outputDateFormat),
                hbl_originals = old_record.hbl_originals,

            };
            await new LogHistorym<cargo_sea_exporth_dto>(context)
            .Table("cargo_housem", log_date)
            .PrimaryKey("hbl_id", record_dto.hbl_id)
            .RefNo(record_dto.hbl_houseno!)
            .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
            .TrackColumn("hbl_houseno", "House No")
            .TrackColumn("hbl_bltype", "BL Type")
            .TrackColumn("hbl_shipment_stage_name", "Shipment Stage Name")
            .TrackColumn("hbl_shipper_code", "Shipper Code")
            .TrackColumn("hbl_shipper_name", "Shipper Name")
            .TrackColumn("hbl_shipper_add1", "Shipper Address 1")
            .TrackColumn("hbl_shipper_add2", "Shipper Address 2")
            .TrackColumn("hbl_shipper_add3", "Shipper Address 3")
            .TrackColumn("hbl_shipper_add4", "Shipper Address 4")
            .TrackColumn("hbl_shipper_add5", "Shipper Address 5")
            .TrackColumn("hbl_consignee_code", "Consignee Code")
            .TrackColumn("hbl_consignee_name", "Consignee Name")
            .TrackColumn("hbl_consignee_add1", "Consignee Address 1")
            .TrackColumn("hbl_consignee_add2", "Consignee Address 2")
            .TrackColumn("hbl_consignee_add3", "Consignee Address 3")
            .TrackColumn("hbl_consignee_add4", "Consignee Address 4")
            .TrackColumn("hbl_consignee_add5", "Consignee Address 5")
            .TrackColumn("hbl_notify_code", "Notify Code")
            .TrackColumn("hbl_notify_name", "Notify Name")
            .TrackColumn("hbl_notify_add1", "Notify Address 1")
            .TrackColumn("hbl_notify_add2", "Notify Address 2")
            .TrackColumn("hbl_notify_add3", "Notify Address 3")
            .TrackColumn("hbl_notify_add4", "Notify Address 4")
            .TrackColumn("hbl_notify_add5", "Notify Address 5")
            .TrackColumn("hbl_exp_ref1", "Export Ref 1")
            .TrackColumn("hbl_exp_ref2", "Export Ref 2")
            .TrackColumn("hbl_exp_ref3", "Export Ref 3")
            .TrackColumn("hbl_agent_name", "Agent Name")
            .TrackColumn("hbl_origin", "Origin")
            .TrackColumn("hbl_rout1", "Routing 1")
            .TrackColumn("hbl_rout2", "Routing 2")
            .TrackColumn("hbl_rout3", "Routing 3")
            .TrackColumn("hbl_rout4", "Routing 4")
            .TrackColumn("hbl_pre_carriage", "Pre-Carriage")
            .TrackColumn("hbl_place_receipt", "Place of Receipt")
            .TrackColumn("hbl_pol_name", "Port of Loading")
            .TrackColumn("hbl_pod_name", "Port of Discharge")
            .TrackColumn("hbl_place_delivery", "Place of Delivery")
            .TrackColumn("hbl_pofd_name", "Place of Final Delivery")
            .TrackColumn("hbl_type_move", "Type of Move")
            .TrackColumn("hbl_is_cntrized", "Is Containerized")
            .TrackColumn("hbl_frt_status_name", "Freight Status")
            .TrackColumn("hbl_handled_name", "Handled By")
            .TrackColumn("hbl_salesman_name", "Salesman Name")
            .TrackColumn("hbl_goods_nature", "Nature of Goods")
            .TrackColumn("hbl_commodity", "Commodity")
            .TrackColumn("hbl_is_arranged", "Is Arranged")
            .TrackColumn("hbl_obl_telex", "OBL Telex")
            .TrackColumn("hbl_obl_slno", "OBL Serial No")
            .TrackColumn("hbl_format_name", "Format Name")
            .TrackColumn("hbl_draft_format_name", "Draft Format Name")
            .TrackColumn("hbl_lbs", "Weight (lbs)", "decimal")
            .TrackColumn("hbl_weight", "Weight (kgs)", "decimal")
            .TrackColumn("hbl_cft", "CFT", "decimal")
            .TrackColumn("hbl_cbm", "CBM", "decimal")
            .TrackColumn("hbl_pcs", "Pieces", "int")
            .TrackColumn("hbl_packages", "Packages", "int")
            .TrackColumn("hbl_uom_name", "Unit of Measure")
            .TrackColumn("hbl_print_kgs", "Print in KGs")
            .TrackColumn("hbl_print_lbs", "Print in LBS")
            .TrackColumn("hbl_clean", "Clean B/L")
            .TrackColumn("hbl_remark1", "Remark 1")
            .TrackColumn("hbl_remark2", "Remark 2")
            .TrackColumn("hbl_remark3", "Remark 3")
            .TrackColumn("hbl_by1", "Issued By 1")
            .TrackColumn("hbl_by2", "Issued By 2")
            .TrackColumn("hbl_issued_place", "Issued Place")
            .TrackColumn("hbl_issued_date", "Issued Date", "date")
            .TrackColumn("hbl_delivery_date", "Delivery Date", "date")
            .TrackColumn("hbl_originals", "Number of Originals", "int")

            .SetRecord(old_record_dto, record_dto)
            .LogChangesAsync();
        }
        public async Task logHistoryDetail(List<cargo_container> old_records, cargo_sea_exporth_dto record_dto)
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
                cntr_packages = record.cntr_packages,
                // cntr_teu = record.cntr_teu,
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
                .Table("cargo_housem", log_date)
                .PrimaryKey("cntr_id", record_dto.hbl_id)
                .RefNo(record_dto.hbl_houseno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_edited_by!)
                .TrackColumn("cntr_catg", "Category")
                .TrackColumn("cntr_no", "Container No")
                .TrackColumn("cntr_type_name", "Container Type Name")
                .TrackColumn("cntr_sealno", "Seal No")
                .TrackColumn("cntr_movement", "Movement")
                .TrackColumn("cntr_pieces", "Pieces")
                .TrackColumn("cntr_packages_unit_name", "Packages Unit")
                .TrackColumn("cntr_packages", "Packages")
                // .TrackColumn("cntr_teu", "TEU", "decimal")
                .TrackColumn("cntr_cbm", "CBM", "decimal")
                .TrackColumn("cntr_weight_uom", "Weight UOM")
                .TrackColumn("cntr_weight", "Weight", "decimal")
                .TrackColumn("cntr_rider", "Rider")
                .TrackColumn("cntr_tare_weight", "Tare Weight", "decimal")
                .TrackColumn("cntr_pick_date", "Pick Date")
                .TrackColumn("cntr_return_date", "Return Date")
                .TrackColumn("cntr_lfd", "LFD")
                .TrackColumn("cntr_discharge_date", "Discharge Date")
                .SetRecords(old_records_dto, record_dto.house_cntr!)
                .LogChangesAsync();

        }
        public async Task logHistoryCargoDesc(cargo_desc old_record, cargo_desc_dto NewRecord_dto, string hbl_houseno, int hbl_id) // int id, int rec_version
        {
            var old_record_dto = new cargo_desc_dto
            {
                desc_parent_id = old_record.desc_parent_id,
                desc_id = old_record.desc_id,
                desc_ctr = old_record.desc_ctr,
                desc_mark = old_record.desc_mark,
                desc_package = old_record.desc_package,
                desc_description = old_record.desc_description,
            };

            await new LogHistorym<cargo_desc_dto>(context)
            .Table("cargo_housem", log_date)
            .PrimaryKey("desc_id", hbl_id)///hbl id pass while call
            .RefNo(hbl_houseno)
            .SetCompanyInfo(NewRecord_dto.rec_version, NewRecord_dto.rec_company_id, NewRecord_dto.rec_branch_id, NewRecord_dto.rec_created_by!)
            .TrackColumn("desc_mark", $"Mark and Nos - {NewRecord_dto.desc_ctr}")
            .TrackColumn("desc_package", $"Package - {NewRecord_dto.desc_ctr}")
            .TrackColumn("desc_description", $"Description - {NewRecord_dto.desc_ctr}")
            .SetRecord(old_record_dto, NewRecord_dto)
            .LogChangesAsync();

        }
        public filesm ProcessPdfFileAsync(List<cargo_sea_exporth_dto> Records, string title, int company_id, string name, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Records error");

            SeaExportHPdfFile bc = new SeaExportHPdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                Hbl_type = title,
                FromDate = searchInfo.ContainsKey("hbl_from_date") ? searchInfo["hbl_from_date"] : "",
                ToDate = searchInfo.ContainsKey("hbl_to_date") ? searchInfo["hbl_to_date"] : "",
                RefNo = searchInfo.ContainsKey("hbl_mbl_refno") ? searchInfo["hbl_mbl_refno"] : "",
                HouseNo = searchInfo.ContainsKey("hbl_houseno") ? searchInfo["hbl_houseno"] : "",
                
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
        public filesm ProcessExcelFileAsync(List<cargo_sea_exporth_dto> Records, string title, int company_id, string name, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            ProcessSeaExportHExcelFile bc = new ProcessSeaExportHExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                Hbl_type = title,
                FromDate = searchInfo.ContainsKey("hbl_from_date") ? searchInfo["hbl_from_date"] : "",
                ToDate = searchInfo.ContainsKey("hbl_to_date") ? searchInfo["hbl_to_date"] : "",
                RefNo = searchInfo.ContainsKey("hbl_mbl_refno") ? searchInfo["hbl_mbl_refno"] : "",
                HouseNo = searchInfo.ContainsKey("hbl_houseno") ? searchInfo["hbl_houseno"] : "",
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
