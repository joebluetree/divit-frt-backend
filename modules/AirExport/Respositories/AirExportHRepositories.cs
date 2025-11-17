using Database;
using Database.Lib;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.BaseTables;
using Common.Lib;
using Database.Models.Cargo;
using Common.DTO.AirExport;
using AirExport.Interfaces;
using Database.Models.UserAdmin;
using AirExport.Printing;

namespace AirExport.Repositories
{

    //Name : Alen Cherian
    //Date : 27/02/2025
    //Command :  Create Repository for the Air Export House.
    //version 1.0

    public class AirExportHRepository : IAirExportHRepository
    {

        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        string hbl_mode = "AIR EXPORT";


        public AirExportHRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var hbl_houseno = "";
                var hbl_mbl_refno = "";
                var company_id = 0;
                var branch_id = 0;
                var hbl_from_date = "";
                var hbl_to_date = "";
                DateTime? from_date = null;
                DateTime? to_date = null;


                if (data.ContainsKey("hbl_mbl_refno"))
                    hbl_mbl_refno = data["hbl_mbl_refno"].ToString();
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
                if (!Lib.IsBlank(hbl_mbl_refno))
                    query = query.Where(w => w.master!.mbl_refno!.Contains(hbl_mbl_refno!));
                if (!Lib.IsBlank(hbl_houseno))
                    query = query.Where(w => w.hbl_houseno!.Contains(hbl_houseno!));


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
                    .OrderBy(c => c.hbl_date)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_air_exporth_dto
                {
                    hbl_id = e.hbl_id,
                    hbl_cfno = e.hbl_cfno,
                    hbl_mbl_id = e.hbl_mbl_id,
                    hbl_houseno = e.hbl_houseno,
                    hbl_mbl_refno = e.master!.mbl_refno,
                    hbl_shipment_stage_id = e.hbl_shipment_stage_id,
                    hbl_shipment_stage_name = e.shipstage!.param_name,
                    hbl_date = Lib.FormatDate(e.hbl_date, Lib.outputDateFormat),
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
                    hbl_notify_name = e.hbl_notify_name,
                    hbl_notify_add1 = e.hbl_notify_add1,
                    hbl_notify_add2 = e.hbl_notify_add2,
                    hbl_notify_add3 = e.hbl_notify_add3,

                    hbl_exp_ref1 = e.hbl_exp_ref1,
                    hbl_exp_ref2 = e.hbl_exp_ref2,
                    hbl_exp_ref3 = e.hbl_exp_ref3,
                    hbl_agent_name = e.hbl_agent_name,
                    hbl_agent_city = e.hbl_agent_city,
                    hbl_place_delivery = e.hbl_place_delivery,
                    hbl_iata = e.hbl_iata,
                    hbl_accno = e.hbl_accno,
                    hbl_frt_status_name = e.hbl_frt_status_name,
                    hbl_oc_status = e.hbl_oc_status,
                    hbl_carriage_value = e.hbl_carriage_value,
                    hbl_customs_value = e.hbl_customs_value,
                    hbl_ins_amt = e.hbl_ins_amt,
                    hbl_aesno = e.hbl_aesno,
                    hbl_lcno = e.hbl_lcno,

                    hbl_bltype = e.hbl_bltype,
                    hbl_handled_id = e.hbl_handled_id,
                    hbl_handled_name = e.handledby!.param_name,
                    hbl_salesman_id = e.hbl_salesman_id,
                    hbl_salesman_name = e.salesman!.param_name,
                    hbl_goods_nature = e.hbl_goods_nature,
                    hbl_commodity = e.hbl_commodity,
                    hbl_format_id = e.hbl_format_id,
                    hbl_format_name = e.format!.param_name,
                    hbl_rout1 = e.hbl_rout1,
                    hbl_rout2 = e.hbl_rout2,
                    hbl_rout3 = e.hbl_rout3,
                    hbl_pol_name = e.hbl_pol_name,
                    hbl_pod_name = e.hbl_pod_name,
                    hbl_asarranged_consignee = e.hbl_asarranged_consignee,
                    hbl_asarranged_shipper = e.hbl_asarranged_shipper,

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
                    {"hbl_houseno", hbl_houseno!},
                    {"hbl_mbl_refno", hbl_mbl_refno!},
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

        public async Task<cargo_air_exporth_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_housem> query = context.cargo_housem;

                query = query.Where(f => f.hbl_id == id && f.hbl_mode == hbl_mode);


                var Record = await query.Select(e => new cargo_air_exporth_dto
                {

                    hbl_id = e.hbl_id,
                    hbl_mbl_id = e.hbl_mbl_id,
                    hbl_houseno = e.hbl_houseno,
                    hbl_mbl_refno = e.master!.mbl_refno,
                    hbl_shipment_stage_id = e.hbl_shipment_stage_id,
                    hbl_shipment_stage_name = e.shipstage!.param_name,
                    hbl_date = Lib.FormatDate(e.hbl_date, Lib.outputDateTimeFormat),
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
                    hbl_notify_name = e.hbl_notify_name,
                    hbl_notify_add1 = e.hbl_notify_add1,
                    hbl_notify_add2 = e.hbl_notify_add2,
                    hbl_notify_add3 = e.hbl_notify_add3,

                    hbl_exp_ref1 = e.hbl_exp_ref1,
                    hbl_exp_ref2 = e.hbl_exp_ref2,
                    hbl_exp_ref3 = e.hbl_exp_ref3,
                    hbl_agent_name = e.hbl_agent_name,
                    hbl_agent_city = e.hbl_agent_city,
                    hbl_place_delivery = e.hbl_place_delivery,
                    hbl_iata = e.hbl_iata,
                    hbl_accno = e.hbl_accno,
                    hbl_frt_status_name = e.hbl_frt_status_name,
                    hbl_oc_status = e.hbl_oc_status,
                    hbl_carriage_value = e.hbl_carriage_value,
                    hbl_customs_value = e.hbl_customs_value,
                    hbl_ins_amt = e.hbl_ins_amt,
                    hbl_aesno = e.hbl_aesno,
                    hbl_lcno = e.hbl_lcno,

                    hbl_bltype = e.hbl_bltype,
                    hbl_handled_id = e.hbl_handled_id,
                    hbl_handled_name = e.handledby!.param_name,
                    hbl_salesman_id = e.hbl_salesman_id,
                    hbl_salesman_name = e.salesman!.param_name,
                    hbl_goods_nature = e.hbl_goods_nature,
                    hbl_commodity = e.hbl_commodity,
                    hbl_format_id = e.hbl_format_id,
                    hbl_format_name = e.format!.param_name,
                    hbl_rout1 = e.hbl_rout1,
                    hbl_rout2 = e.hbl_rout2,
                    hbl_rout3 = e.hbl_rout3,
                    hbl_pol_name = e.hbl_pol_name,
                    hbl_pod_name = e.hbl_pod_name,
                    hbl_asarranged_consignee = e.hbl_asarranged_consignee,
                    hbl_asarranged_shipper = e.hbl_asarranged_shipper,

                    hbl_packages = e.hbl_packages,
                    hbl_weight = e.hbl_weight,
                    hbl_weight_unit = e.hbl_weight_unit,
                    hbl_class = e.hbl_class,
                    hbl_comm = e.hbl_comm,
                    hbl_chwt = e.hbl_chwt,
                    hbl_rate = e.hbl_rate,
                    hbl_total = e.hbl_total,


                    hbl_charges1 = e.hbl_charges1,
                    hbl_charges2 = e.hbl_charges2,
                    hbl_charges3 = e.hbl_charges3,
                    hbl_charges4 = e.hbl_charges4,
                    hbl_charges5 = e.hbl_charges5,

                    hbl_charges1_carrier = e.hbl_charges1_carrier,
                    hbl_charges2_carrier = e.hbl_charges2_carrier,
                    hbl_charges3_carrier = e.hbl_charges3_carrier,

                    hbl_remark1 = e.hbl_remark1,
                    hbl_remark2 = e.hbl_remark2,
                    hbl_remark3 = e.hbl_remark3,
                    hbl_by1 = e.hbl_by1,
                    hbl_by1_carrier = e.hbl_by1_carrier,
                    hbl_by2 = e.hbl_by2,
                    hbl_by2_carrier = e.hbl_by2_carrier,
                    hbl_issued_date = Lib.FormatDate(e.hbl_issued_date, Lib.outputDateTimeFormat),
                    hbl_delivery_date = Lib.FormatDate(e.hbl_delivery_date, Lib.outputDateTimeFormat),
                    hbl_issued_by = e.hbl_issued_by,


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

                Record.hbl_toagent1 = CommonLib.SplitString(Record.hbl_charges1, 0);
                Record.hbl_rate1 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges1, 1));

                Record.hbl_total1 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges1, 2));
                Record.hbl_printsc1 = CommonLib.SplitString(Record.hbl_charges1, 3);
                Record.hbl_printsc2 = CommonLib.SplitString(Record.hbl_charges1, 4);

                Record.hbl_toagent2 = CommonLib.SplitString(Record.hbl_charges2, 0);
                Record.hbl_rate2 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges2, 1));
                Record.hbl_total2 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges2, 2));
                Record.hbl_printsc3 = CommonLib.SplitString(Record.hbl_charges2, 3);
                Record.hbl_printsc4 = CommonLib.SplitString(Record.hbl_charges2, 4);

                Record.hbl_toagent3 = CommonLib.SplitString(Record.hbl_charges3, 0);
                Record.hbl_rate3 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges3, 1));
                Record.hbl_total3 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges3, 2));
                Record.hbl_printsc5 = CommonLib.SplitString(Record.hbl_charges3, 3);
                Record.hbl_printsc6 = CommonLib.SplitString(Record.hbl_charges3, 4);

                Record.hbl_toagent4 = CommonLib.SplitString(Record.hbl_charges4, 0);
                Record.hbl_rate4 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges4, 1));
                Record.hbl_total4 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges4, 2));
                Record.hbl_printsc7 = CommonLib.SplitString(Record.hbl_charges4, 3);
                Record.hbl_printsc8 = CommonLib.SplitString(Record.hbl_charges4, 4);

                Record.hbl_toagent5 = CommonLib.SplitString(Record.hbl_charges5, 0);
                Record.hbl_rate5 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges5, 1));
                Record.hbl_total5 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges5, 2));
                Record.hbl_printsc9 = CommonLib.SplitString(Record.hbl_charges5, 3);
                Record.hbl_printsc10 = CommonLib.SplitString(Record.hbl_charges5, 4);

                //Charges to carrier details

                Record.hbl_tocarrier1 = CommonLib.SplitString(Record.hbl_charges1_carrier, 0);
                Record.hbl_carrate1 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges1_carrier, 1));
                Record.hbl_cartotal1 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges1_carrier, 2));
                Record.hbl_carprintsc1 = CommonLib.SplitString(Record.hbl_charges1_carrier, 3);
                Record.hbl_carprintsc2 = CommonLib.SplitString(Record.hbl_charges1_carrier, 4);

                Record.hbl_tocarrier2 = CommonLib.SplitString(Record.hbl_charges2_carrier, 0);
                Record.hbl_carrate2 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges2_carrier, 1));
                Record.hbl_cartotal2 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges2_carrier, 2));
                Record.hbl_carprintsc3 = CommonLib.SplitString(Record.hbl_charges2_carrier, 3);
                Record.hbl_carprintsc4 = CommonLib.SplitString(Record.hbl_charges2_carrier, 4);

                Record.hbl_tocarrier3 = CommonLib.SplitString(Record.hbl_charges3_carrier, 0);
                Record.hbl_carrate3 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges3_carrier, 1));
                Record.hbl_cartotal3 = Lib.StringToDecimal(CommonLib.SplitString(Record.hbl_charges3_carrier, 2));
                Record.hbl_carprintsc5 = CommonLib.SplitString(Record.hbl_charges3_carrier, 3);
                Record.hbl_carprintsc6 = CommonLib.SplitString(Record.hbl_charges3_carrier, 4);

                await GetCargoDesc(Record);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task GetCargoDesc(cargo_air_exporth_dto Record)
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

        public async Task<cargo_air_exporth_dto?> GetDefaultDataAsync(int id)
        {
            try
            {
                var query = context.cargo_masterm
                    .Where(f => f.mbl_id == id && f.mbl_mode == hbl_mode);

                var Record = await query
                    .Select(e => new cargo_air_exporth_dto
                    {
                        hbl_mbl_id = e.mbl_id,
                        hbl_mbl_refno = e.mbl_refno,
                        hbl_handled_id = e.mbl_handled_id,
                        hbl_handled_name = e.handledby!.param_name,
                        hbl_salesman_id = e.mbl_salesman_id,
                        hbl_salesman_name = e.salesman!.param_name,
                        hbl_pol_name = e.pol!.param_code,
                        hbl_pod_name = e.pod!.param_code,
                        hbl_issued_date = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateFormat),
                        hbl_issued_by = e.handledby!.param_name,
                        hbl_by2_carrier = e.liner!.param_name,
                        rec_branch_id = e.rec_branch_id,
                        rec_company_id = e.rec_company_id,
                    })
                    .FirstOrDefaultAsync();

                var captions = new List<string> { "ISSUING AGENT NAME", "ISSUING AGENT ADDRESS", "ISSUING AGENT CITY", "IATA CODE", "HAWB-FORMAT" };

                var settings = await context.mast_settings
                    .Where(f => f.rec_company_id == Record!.rec_company_id && f.rec_branch_id == Record!.rec_branch_id && captions
                    .Contains(f.caption!))
                    .ToListAsync();

                var agentname = settings.FirstOrDefault(s => s.caption == "ISSUING AGENT NAME")?.value;
                var agentcity = settings.FirstOrDefault(s => s.caption == "ISSUING AGENT CITY")?.value;
                var agentadress = settings.FirstOrDefault(s => s.caption == "ISSUING AGENT ADDRESS")?.value;
                var iata = settings.FirstOrDefault(s => s.caption == "IATA CODE")?.value;
                var hawb_id = settings.FirstOrDefault(s => s.caption == "HAWB-FORMAT")?.value;
                var hawb_name = settings.FirstOrDefault(s => s.caption == "HAWB-FORMAT")?.name;

                var shipmentStage = await context.mast_param
                    .Where(f => f.param_type == "SHIPSTAGE AI" && f.param_name == "NIL")
                    .Select(e => new 
                    {
                        e.param_id,
                        e.param_name
                    })
                    .FirstOrDefaultAsync();

                if (Record != null)
                {
                    if (shipmentStage != null)
                    {
                        Record.hbl_shipment_stage_id = shipmentStage.param_id;
                        Record.hbl_shipment_stage_name = shipmentStage.param_name;
                    }
                    Record.hbl_agent_name = agentname;
                    Record.hbl_agent_city = agentcity;
                    Record.hbl_exp_ref1 = agentname;
                    Record.hbl_exp_ref2 = agentcity;
                    Record.hbl_exp_ref3 = agentadress;
                    Record.hbl_iata = iata;
                    Record.hbl_by1 = $"{agentname} AGENT FOR";
                    Record.hbl_by2 = $"{agentname} AGENT FOR";
                    Record.hbl_rout3 = $"PLEASE CONTACT WITH CONSIGNEE UPON SHIPMENT ARRIVAL.";
                    Record.hbl_ins_amt = $"NILL";
                    Record.hbl_customs_value = $"NCV";
                    Record.hbl_carriage_value = $"NVD";
                    Record.hbl_format_id = int.Parse(hawb_id!);
                    Record.hbl_format_name = hawb_name;
                }

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public async Task<cargo_air_exporth_dto> SaveAsync(int id, string mode, cargo_air_exporth_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_air_exporth_dto _Record = await SaveParentAsync(id, mode, record_dto);
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

        private Boolean AllValid(string mode, cargo_air_exporth_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

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


            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<cargo_air_exporth_dto> SaveParentAsync(int id, string mode, cargo_air_exporth_dto record_dto)
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

                var hbl_charges1 = $"{record_dto.hbl_toagent1},{record_dto.hbl_rate1},{record_dto.hbl_total1},{record_dto.hbl_printsc1},{record_dto.hbl_printsc2}";
                var hbl_charges2 = $"{record_dto.hbl_toagent2},{record_dto.hbl_rate2},{record_dto.hbl_total2},{record_dto.hbl_printsc3},{record_dto.hbl_printsc4}";
                var hbl_charges3 = $"{record_dto.hbl_toagent3},{record_dto.hbl_rate3},{record_dto.hbl_total3},{record_dto.hbl_printsc5},{record_dto.hbl_printsc6}";
                var hbl_charges4 = $"{record_dto.hbl_toagent4},{record_dto.hbl_rate4},{record_dto.hbl_total4},{record_dto.hbl_printsc7},{record_dto.hbl_printsc8}";
                var hbl_charges5 = $"{record_dto.hbl_toagent5},{record_dto.hbl_rate5},{record_dto.hbl_total5},{record_dto.hbl_printsc9},{record_dto.hbl_printsc10}";

                //Other Charges To Carrier Details and concatenate values into a single string
                var hbl_charges1_carrier = $"{record_dto.hbl_tocarrier1},{record_dto.hbl_carrate1},{record_dto.hbl_cartotal1},{record_dto.hbl_carprintsc1},{record_dto.hbl_carprintsc2}";
                var hbl_charges2_carrier = $"{record_dto.hbl_tocarrier2},{record_dto.hbl_carrate2},{record_dto.hbl_cartotal2},{record_dto.hbl_carprintsc3},{record_dto.hbl_carprintsc4}";
                var hbl_charges3_carrier = $"{record_dto.hbl_tocarrier3},{record_dto.hbl_carrate3},{record_dto.hbl_cartotal3},{record_dto.hbl_carprintsc5},{record_dto.hbl_carprintsc6}";

                if (mode == "add")
                {
                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, "AIR-EXP-HOUSE-PREFIX,AIR-EXP-HOUSE-STARTING-NO");//Call the branch settings for the prefix and suffix. 

                    var DefaultCfNo = 0;
                    var Defaultprefix = "";
                    // Check if the result contains the required keys and values from Branch Settings
                    if (result.ContainsKey("AIR-EXP-HOUSE-STARTING-NO"))
                    {
                        DefaultCfNo = Lib.StringToInteger(result["AIR-EXP-HOUSE-STARTING-NO"]);
                    }
                    if (result.ContainsKey("AIR-EXP-HOUSE-PREFIX"))
                    {
                        Defaultprefix = result["AIR-EXP-HOUSE-PREFIX"]?.ToString();
                    }
                    if (Lib.IsBlank(Defaultprefix) || Lib.IsZero(DefaultCfNo))
                    {
                        throw new Exception("Missing Airexport House Prefix/Starting-Number in Branch Settings");
                    }

                    //Getting the Cfno from using the GetNextCfno() function
                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("House Number Cannot Be Generated");
                    }
                    string sref_no = $"{Defaultprefix}{iNextNo}"; //Assigning the prefix and suffix to a new element..

                    Record = new cargo_housem();  //Assigning the values to the database elements
                    Record.hbl_cfno = iNextNo;
                    Record.hbl_houseno = sref_no;
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
                        .Include(c => c.shipstage)
                        .Include(c => c.handledby)
                        .Include(c => c.format)
                        .Include(c => c.salesman)
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

                Record.hbl_shipment_stage_id = record_dto.hbl_shipment_stage_id;
                Record.hbl_date = Lib.ParseDate(record_dto.hbl_date!);
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
                Record.hbl_notify_name = record_dto.hbl_notify_name;
                Record.hbl_notify_add1 = record_dto.hbl_notify_add1;
                Record.hbl_notify_add2 = record_dto.hbl_notify_add2;
                Record.hbl_notify_add3 = record_dto.hbl_notify_add3;

                Record.hbl_exp_ref1 = record_dto.hbl_exp_ref1;
                Record.hbl_exp_ref2 = record_dto.hbl_exp_ref2;
                Record.hbl_exp_ref3 = record_dto.hbl_exp_ref3;
                Record.hbl_agent_name = record_dto.hbl_agent_name;
                Record.hbl_agent_city = record_dto.hbl_agent_city;
                Record.hbl_place_delivery = record_dto.hbl_place_delivery;
                Record.hbl_iata = record_dto.hbl_iata;
                Record.hbl_accno = record_dto.hbl_accno;
                Record.hbl_frt_status_name = record_dto.hbl_frt_status_name;
                Record.hbl_oc_status = record_dto.hbl_oc_status;
                Record.hbl_carriage_value = record_dto.hbl_carriage_value;
                Record.hbl_customs_value = record_dto.hbl_customs_value;
                Record.hbl_ins_amt = record_dto.hbl_ins_amt;
                Record.hbl_aesno = record_dto.hbl_aesno;
                Record.hbl_lcno = record_dto.hbl_lcno;

                Record.hbl_bltype = record_dto.hbl_bltype;
                Record.hbl_handled_id = record_dto.hbl_handled_id;
                Record.hbl_salesman_id = record_dto.hbl_salesman_id;
                Record.hbl_goods_nature = record_dto.hbl_goods_nature;
                Record.hbl_commodity = record_dto.hbl_commodity;
                Record.hbl_format_id = record_dto.hbl_format_id;
                Record.hbl_rout1 = record_dto.hbl_rout1;
                Record.hbl_rout2 = record_dto.hbl_rout2;
                Record.hbl_rout3 = record_dto.hbl_rout3;
                Record.hbl_pol_name = record_dto.hbl_pol_name;
                Record.hbl_pod_name = record_dto.hbl_pod_name;
                Record.hbl_asarranged_consignee = record_dto.hbl_asarranged_consignee;
                Record.hbl_asarranged_shipper = record_dto.hbl_asarranged_shipper;

                Record.hbl_packages = record_dto.hbl_packages;
                Record.hbl_weight = record_dto.hbl_weight;
                Record.hbl_weight_unit = record_dto.hbl_weight_unit;
                Record.hbl_class = record_dto.hbl_class;
                Record.hbl_comm = record_dto.hbl_comm;
                Record.hbl_chwt = record_dto.hbl_chwt;
                Record.hbl_rate = record_dto.hbl_rate;
                Record.hbl_total = record_dto.hbl_total;

                Record.hbl_charges1 = hbl_charges1;
                Record.hbl_charges2 = hbl_charges2;
                Record.hbl_charges3 = hbl_charges3;
                Record.hbl_charges4 = hbl_charges4;
                Record.hbl_charges5 = hbl_charges5;

                Record.hbl_charges1_carrier = hbl_charges1_carrier;
                Record.hbl_charges2_carrier = hbl_charges2_carrier;
                Record.hbl_charges3_carrier = hbl_charges3_carrier;

                Record.hbl_remark1 = record_dto.hbl_remark1;
                Record.hbl_remark2 = record_dto.hbl_remark2;
                Record.hbl_remark3 = record_dto.hbl_remark3;
                Record.hbl_by1 = record_dto.hbl_by1;
                Record.hbl_by1_carrier = record_dto.hbl_by1_carrier;
                Record.hbl_by2 = record_dto.hbl_by2;
                Record.hbl_by2_carrier = record_dto.hbl_by2_carrier;
                Record.hbl_issued_date = Lib.ParseDate(record_dto.hbl_issued_date!);
                Record.hbl_delivery_date = Lib.ParseDate(record_dto.hbl_delivery_date!);
                Record.hbl_issued_by = record_dto.hbl_issued_by;

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
        public async Task<cargo_air_exporth_dto> SaveCargoDesc(int id, string mode, cargo_air_exporth_dto record_dto)
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


        public async Task<cargo_air_exporth_dto> SaveMarksandNumbers(int id, string mode, List<cargo_desc_dto?> marks, cargo_air_exporth_dto record_dto)
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
                context.Database.BeginTransaction();

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
                if (CommonLib.InvoiceExists(context, id, _Record!.rec_company_id))
                {
                    throw new Exception("Cannot Delete, Invoice Exists");
                }
                else
                {
                    await CommonLib.DeleteDesc(context, id, "AE-DESC");
                    
                    context.Remove(_Record);
                    await context.SaveChangesAsync();
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

        public async Task logHistory(cargo_housem old_record, cargo_air_exporth_dto record_dto)
        {

            var old_record_dto = new cargo_air_exporth_dto
            {
                hbl_id = old_record.hbl_id,
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
                hbl_notify_name = old_record.hbl_notify_name,
                hbl_notify_add1 = old_record.hbl_notify_add1,
                hbl_notify_add2 = old_record.hbl_notify_add2,
                hbl_notify_add3 = old_record.hbl_notify_add3,

                hbl_exp_ref1 = old_record.hbl_exp_ref1,
                hbl_exp_ref2 = old_record.hbl_exp_ref2,
                hbl_exp_ref3 = old_record.hbl_exp_ref3,
                hbl_agent_name = old_record.hbl_agent_name,
                hbl_agent_city = old_record.hbl_agent_city,
                hbl_place_delivery = old_record.hbl_place_delivery,
                hbl_iata = old_record.hbl_iata,
                hbl_accno = old_record.hbl_accno,
                hbl_frt_status_name = old_record.hbl_frt_status_name,
                hbl_oc_status = old_record.hbl_oc_status,
                hbl_carriage_value = old_record.hbl_carriage_value,
                hbl_customs_value = old_record.hbl_customs_value,
                hbl_ins_amt = old_record.hbl_ins_amt,
                hbl_aesno = old_record.hbl_aesno,
                hbl_lcno = old_record.hbl_lcno,

                hbl_bltype = old_record.hbl_bltype,
                hbl_handled_name = old_record.handledby?.param_name,
                hbl_salesman_name = old_record.salesman?.param_name,
                hbl_goods_nature = old_record.hbl_goods_nature,
                hbl_commodity = old_record.hbl_commodity,
                hbl_format_name = old_record.format?.param_name,
                hbl_rout1 = old_record.hbl_rout1,
                hbl_rout2 = old_record.hbl_rout2,
                hbl_rout3 = old_record.hbl_rout3,
                hbl_pol_name = old_record.hbl_pol_name,
                hbl_pod_name = old_record.hbl_pod_name,
                hbl_asarranged_consignee = old_record.hbl_asarranged_consignee,
                hbl_asarranged_shipper = old_record.hbl_asarranged_shipper,

                hbl_packages = old_record.hbl_packages,
                hbl_weight = old_record.hbl_weight,
                hbl_weight_unit = old_record.hbl_weight_unit,
                hbl_class = old_record.hbl_class,
                hbl_comm = old_record.hbl_comm,
                hbl_chwt = old_record.hbl_chwt,
                hbl_rate = old_record.hbl_rate,
                hbl_total = old_record.hbl_total,

                hbl_remark1 = old_record.hbl_remark1,
                hbl_remark2 = old_record.hbl_remark2,
                hbl_remark3 = old_record.hbl_remark3,
                hbl_by1 = old_record.hbl_by1,
                hbl_by1_carrier = old_record.hbl_by1_carrier,
                hbl_by2 = old_record.hbl_by2,
                hbl_by2_carrier = old_record.hbl_by2_carrier,
                hbl_issued_date = Lib.FormatDate(old_record.hbl_issued_date, Lib.outputDateFormat),
                hbl_delivery_date = Lib.FormatDate(old_record.hbl_delivery_date, Lib.outputDateFormat),
                hbl_issued_by = old_record.hbl_issued_by,

                hbl_charges1 = old_record.hbl_charges1,
                hbl_charges2 = old_record.hbl_charges2,
                hbl_charges3 = old_record.hbl_charges3,
                hbl_charges4 = old_record.hbl_charges4,
                hbl_charges5 = old_record.hbl_charges5,

                hbl_charges1_carrier = old_record.hbl_charges1_carrier,
                hbl_charges2_carrier = old_record.hbl_charges2_carrier,
                hbl_charges3_carrier = old_record.hbl_charges3_carrier,

                hbl_toagent1 = CommonLib.SplitString(old_record.hbl_charges1, 0),
                hbl_rate1 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges1, 1)),
                hbl_total1 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges1, 2)),
                hbl_printsc1 = CommonLib.SplitString(old_record.hbl_charges1, 3),
                hbl_printsc2 = CommonLib.SplitString(old_record.hbl_charges1, 4),

                hbl_toagent2 = CommonLib.SplitString(old_record.hbl_charges2, 0),
                hbl_rate2 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges2, 1)),
                hbl_total2 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges2, 2)),
                hbl_printsc3 = CommonLib.SplitString(old_record.hbl_charges2, 3),
                hbl_printsc4 = CommonLib.SplitString(old_record.hbl_charges2, 4),

                hbl_toagent3 = CommonLib.SplitString(old_record.hbl_charges3, 0),
                hbl_rate3 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges3, 1)),
                hbl_total3 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges3, 2)),
                hbl_printsc5 = CommonLib.SplitString(old_record.hbl_charges3, 3),
                hbl_printsc6 = CommonLib.SplitString(old_record.hbl_charges3, 4),

                hbl_toagent4 = CommonLib.SplitString(old_record.hbl_charges4, 0),
                hbl_rate4 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges4, 1)),
                hbl_total4 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges4, 2)),
                hbl_printsc7 = CommonLib.SplitString(old_record.hbl_charges4, 3),
                hbl_printsc8 = CommonLib.SplitString(old_record.hbl_charges4, 4),

                hbl_toagent5 = CommonLib.SplitString(old_record.hbl_charges5, 0),
                hbl_rate5 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges5, 1)),
                hbl_total5 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges5, 2)),
                hbl_printsc9 = CommonLib.SplitString(old_record.hbl_charges5, 3),
                hbl_printsc10 = CommonLib.SplitString(old_record.hbl_charges5, 4),

                //Charges to carrier details

                hbl_tocarrier1 = CommonLib.SplitString(old_record.hbl_charges1_carrier, 0),
                hbl_carrate1 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges1_carrier, 1)),
                hbl_cartotal1 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges1_carrier, 2)),
                hbl_carprintsc1 = CommonLib.SplitString(old_record.hbl_charges1_carrier, 3),
                hbl_carprintsc2 = CommonLib.SplitString(old_record.hbl_charges1_carrier, 4),

                hbl_tocarrier2 = CommonLib.SplitString(old_record.hbl_charges2_carrier, 0),
                hbl_carrate2 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges2_carrier, 1)),
                hbl_cartotal2 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges2_carrier, 2)),
                hbl_carprintsc3 = CommonLib.SplitString(old_record.hbl_charges2_carrier, 3),
                hbl_carprintsc4 = CommonLib.SplitString(old_record.hbl_charges2_carrier, 4),

                hbl_tocarrier3 = CommonLib.SplitString(old_record.hbl_charges3_carrier, 0),
                hbl_carrate3 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges3_carrier, 1)),
                hbl_cartotal3 = Lib.StringToDecimal(CommonLib.SplitString(old_record.hbl_charges3_carrier, 2)),
                hbl_carprintsc5 = CommonLib.SplitString(old_record.hbl_charges3_carrier, 3),
                hbl_carprintsc6 = CommonLib.SplitString(old_record.hbl_charges3_carrier, 4),

            };

            await new LogHistorym<cargo_air_exporth_dto>(context)
                .Table("cargo_housem", log_date)
                .PrimaryKey("hbl_id", record_dto.hbl_id)
                .RefNo(record_dto.hbl_houseno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
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
                .TrackColumn("hbl_notify_name", "Notify Name")
                .TrackColumn("hbl_notify_add1", "Notify Address 1")
                .TrackColumn("hbl_notify_add2", "Notify Address 2")
                .TrackColumn("hbl_notify_add3", "Notify Address 3")

                .TrackColumn("hbl_exp_ref1", "Export Reference 1")
                .TrackColumn("hbl_exp_ref2", "Export Reference 2")
                .TrackColumn("hbl_exp_ref3", "Export Reference 3")
                .TrackColumn("hbl_agent_name", "Agent Name")
                .TrackColumn("hbl_agent_city", "Agent City")
                .TrackColumn("hbl_place_delivery", "Place of Delivery")
                .TrackColumn("hbl_iata", "IATA")
                .TrackColumn("hbl_accno", "Account Number")
                .TrackColumn("hbl_frt_status_name", "Freight Status Name")
                .TrackColumn("hbl_oc_status", "OC Status")
                .TrackColumn("hbl_carriage_value", "Carriage Value")
                .TrackColumn("hbl_customs_value", "Customs Value")
                .TrackColumn("hbl_ins_amt", "Insurance Amount")
                .TrackColumn("hbl_aesno", "AES Number")

                .TrackColumn("hbl_lcno", "LC Number")
                .TrackColumn("hbl_bltype", "BL Type")
                .TrackColumn("hbl_handled_name", "Handled By")
                .TrackColumn("hbl_salesman_name", "Salesman")
                .TrackColumn("hbl_goods_nature", "Goods Nature")
                .TrackColumn("hbl_commodity", "Commodity")
                .TrackColumn("hbl_format_name", "Format")
                .TrackColumn("hbl_rout1", "Route 1")
                .TrackColumn("hbl_rout2", "Route 2")
                .TrackColumn("hbl_rout3", "Route 3")
                .TrackColumn("hbl_pol_name", "POL Name")
                .TrackColumn("hbl_pod_name", "POD Name")
                .TrackColumn("hbl_asarranged_consignee", "As Arranged Consignee")
                .TrackColumn("hbl_asarranged_shipper", "As Arranged Shipper")

                .TrackColumn("hbl_packages", "Packages", "int")
                .TrackColumn("hbl_weight", "Weight", "decimal")
                .TrackColumn("hbl_weight_unit", "Weight Unit")
                .TrackColumn("hbl_class", "Class")
                .TrackColumn("hbl_comm", "Commodity")
                .TrackColumn("hbl_chwt", "Chargeable Weight", "decimal")
                .TrackColumn("hbl_rate", "Rate", "decimal")
                .TrackColumn("hbl_total", "Total", "decimal")

                .TrackColumn("hbl_remark1", "Remark 1")
                .TrackColumn("hbl_remark2", "Remark 2")
                .TrackColumn("hbl_remark3", "Remark 3")
                .TrackColumn("hbl_by1", "By 1")
                .TrackColumn("hbl_by1_carrier", "By 1 Carrier")
                .TrackColumn("hbl_by2", "By 2")
                .TrackColumn("hbl_by2_carrier", "By 2 Carrier")
                .TrackColumn("hbl_issued_date", "Issued Date")
                .TrackColumn("hbl_delivery_date", "Delivery Date")
                .TrackColumn("hbl_issued_by", "Issued By")

                .TrackColumn("hbl_toagent1", "Agent Charges")
                .TrackColumn("hbl_rate1", "Agent Rate")
                .TrackColumn("hbl_total1", "Agent Total")
                .TrackColumn("hbl_printsc1", "Agent Print SC1")
                .TrackColumn("hbl_printsc2", "Agent Print SC2")

                .TrackColumn("hbl_toagent2", "Agent Charges 2")
                .TrackColumn("hbl_rate2", "Agent Rate 2")
                .TrackColumn("hbl_total2", "Agent Total 2")
                .TrackColumn("hbl_printsc3", "Agent Print SC3")
                .TrackColumn("hbl_printsc4", "Agent Print SC4")

                .TrackColumn("hbl_toagent3", "Agent Charges 3")
                .TrackColumn("hbl_rate3", "Agent Rate 3")
                .TrackColumn("hbl_total3", "Agent Total 3")
                .TrackColumn("hbl_printsc5", "Agent Print SC5")
                .TrackColumn("hbl_printsc6", "Agent Print SC6")

                .TrackColumn("hbl_toagent4", "Agent Charges 4")
                .TrackColumn("hbl_rate4", "Agent Rate 4")
                .TrackColumn("hbl_total4", "Agent Total 4")
                .TrackColumn("hbl_printsc7", "Agent Print SC7")
                .TrackColumn("hbl_printsc8", "Agent Print SC8")

                .TrackColumn("hbl_toagent5", "Agent Charges 5")
                .TrackColumn("hbl_rate5", "Agent Rate 5")
                .TrackColumn("hbl_total5", "Agent Total 5")
                .TrackColumn("hbl_printsc9", "Agent Print SC9")
                .TrackColumn("hbl_printsc10", "Agent Print SC10")

                .TrackColumn("hbl_tocarrier1", "Carrier Charges 2")
                .TrackColumn("hbl_carrate1", "Carrier Rate 2")
                .TrackColumn("hbl_cartotal1", "Carrier Total 2")
                .TrackColumn("hbl_carprintsc1", "Carrier Print SC3")
                .TrackColumn("hbl_carprintsc2", "Carrier Print SC4")

                .TrackColumn("hbl_tocarrier2", "Carrier Charges 2")
                .TrackColumn("hbl_carrate2", "Carrier Rate 2")
                .TrackColumn("hbl_cartotal2", "Carrier Total 2")
                .TrackColumn("hbl_carprintsc3", "Carrier Print SC3")
                .TrackColumn("hbl_carprintsc4", "Carrier Print SC4")

                .TrackColumn("hbl_tocarrier3", "Carrier Charges 3")
                .TrackColumn("hbl_carrate3", "Carrier Rate 3")
                .TrackColumn("hbl_cartotal3", "Carrier Total 3")
                .TrackColumn("hbl_carprintsc5", "Carrier Print SC5")
                .TrackColumn("hbl_carprintsc6", "Carrier Print SC6")

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
        public filesm ProcessPdfFileAsync(List<cargo_air_exporth_dto> Records, string title, int company_id, string name, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Records error");

            AirExportHPdfFile bc = new AirExportHPdfFile
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
                HouseNo = searchInfo.ContainsKey("hbl_houseno") ? searchInfo["hbl_houseno"] : "",
                RefNo = searchInfo.ContainsKey("hbl_mbl_refno") ? searchInfo["hbl_mbl_refno"] : "",
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
        public filesm ProcessExcelFileAsync(List<cargo_air_exporth_dto> Records, string title, int company_id, string name, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            ProcessAirExportHExcelFile bc = new ProcessAirExportHExcelFile
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
                HouseNo = searchInfo.ContainsKey("hbl_houseno") ? searchInfo["hbl_houseno"] : "",
                RefNo = searchInfo.ContainsKey("hbl_mbl_refno") ? searchInfo["hbl_mbl_refno"] : "",
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
