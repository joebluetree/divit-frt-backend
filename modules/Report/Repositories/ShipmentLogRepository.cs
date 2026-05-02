using Database;
using Database.Lib;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;

using Database.Models.Cargo;
using System.Threading.Tasks.Dataflow;
using System.Numerics;
using Report.Interfaces;
using Common.DTO.Report;
using Report.Printing;

//Name : Sourav V
//Created Date : 19/03/2026
//Remark : this file defines functions getList of operations for Shipment Log report


namespace Report.Repositories
{
    public class ShipmentLogRepository : IShipmentLogRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public ShipmentLogRepository(AppDbContext _context, IAuditLog _auditLog)
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
                bool isPrint = false;
                var title = data["title"].ToString();
                var user_name = data["global_user_name"].ToString();

                var mbl_date_type = "";
                var mbl_from_date = "";
                var mbl_to_date = "";
                var mbl_mode = "";
                var mbl_agent_name = "";
                var mbl_shipper_name = "";
                var mbl_consignee_name = "";
                var mbl_handled_name = "";
                var mbl_user_role = "";
                var rec_created_name = "";
                var mbl_incoterm = "";
                var mbl_is_master = "";
                var mbl_is_house = "";
                var mbl_stages = "";
                var mbl_sort_order = "";
                var mbl_eta_within = 0;
                var mbl_pending_ams = "";
                var mbl_format = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("mbl_date_type"))
                    mbl_date_type = data["mbl_date_type"].ToString();
                if (data.ContainsKey("mbl_from_date"))
                    mbl_from_date = data["mbl_from_date"].ToString();
                if (data.ContainsKey("mbl_to_date"))
                    mbl_to_date = data["mbl_to_date"].ToString();
                if (data.ContainsKey("mbl_mode"))
                    mbl_mode = data["mbl_mode"].ToString();
                if (data.ContainsKey("mbl_agent_name"))
                    mbl_agent_name = data["mbl_agent_name"].ToString()!;
                if (data.ContainsKey("mbl_shipper_name"))
                    mbl_shipper_name = data["mbl_shipper_name"].ToString();
                if (data.ContainsKey("mbl_consignee_name"))
                    mbl_consignee_name = data["mbl_consignee_name"].ToString();
                if (data.ContainsKey("mbl_handled_name"))
                    mbl_handled_name = data["mbl_handled_name"].ToString();
                if (data.ContainsKey("mbl_user_role"))
                    mbl_user_role = data["mbl_user_role"].ToString();
                if (data.ContainsKey("mbl_is_master"))
                    mbl_is_master = data["mbl_is_master"].ToString();
                if (data.ContainsKey("mbl_is_house"))
                    mbl_is_house = data["mbl_is_house"].ToString();
                if (data.ContainsKey("mbl_stages"))
                    mbl_stages = data["mbl_stages"].ToString();
                if (data.ContainsKey("rec_created_name"))
                    rec_created_name = data["rec_created_name"].ToString();
                if (data.ContainsKey("mbl_incoterm"))
                    mbl_incoterm = data["mbl_incoterm"].ToString();
                if (data.ContainsKey("mbl_sort_order"))
                    mbl_sort_order = data["mbl_sort_order"].ToString();
                if (data.ContainsKey("mbl_eta_within"))
                    mbl_eta_within = int.Parse(data["mbl_eta_within"].ToString()!);
                if (data.ContainsKey("mbl_pending_ams"))
                    mbl_pending_ams = data["mbl_pending_ams"].ToString();
                if (data.ContainsKey("mbl_format"))
                    mbl_format = data["mbl_format"].ToString();

                company_id = Lib.GetValidIntValue(data!, "rec_company_id", "Company Id Not Found");
                branch_id = Lib.GetValidIntValue(data!, "rec_branch_id", "Branch Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                if (action == "PRINT" || action == "EXCEL" || action == "PDF")
                {
                    isPrint = true;
                }
                var fileDataList = new List<filesm>();
                var searchInfo = new Dictionary<string, string>
                {
                    {"mbl_date_type",mbl_date_type!},
                    {"mbl_from_date",mbl_from_date!},
                    {"mbl_to_date",mbl_to_date!},
                    {"mbl_mode", mbl_mode!},
                    {"mbl_shipper_name", mbl_shipper_name!},
                    {"mbl_consignee_name", mbl_consignee_name!},
                    {"mbl_agent_name", mbl_agent_name!},
                    {"mbl_handled_name", mbl_handled_name!},
                    {"mbl_user_role", mbl_user_role!},
                    {"rec_created_name", rec_created_name!},
                    {"mbl_format", mbl_format!},
                };

                List<rep_shipmentlog_dto> Records = new List<rep_shipmentlog_dto>();

                if (mbl_is_master == "Y" && mbl_mode != "OTHERS")
                {
                    IQueryable<cargo_masterm> query = context.cargo_masterm
                        .Include(h => h.shipper)
                        .Include(h => h.consignee)
                        .Include(h => h.incoterm)
                        .Include(h => h.liner)
                        .Include(h => h.pol)
                        .Include(h => h.pod)
                        .Include(h => h.agent);

                    query = query.Where(w => w.rec_company_id == company_id);
                    query = query.Where(w => w.rec_branch_id == branch_id);

                    if (!Lib.IsBlank(mbl_from_date))
                    {
                        from_date = Lib.ParseDateOnly(mbl_from_date!);
                        if (mbl_date_type == "REF. DATE")
                        {
                            query = query.Where(w => w.mbl_ref_date >= from_date);
                        }
                        if (mbl_date_type == "ETD")
                        {
                            query = query.Where(w => w.mbl_pol_etd >= from_date);
                        }
                        if (mbl_date_type == "ETA")
                        {
                            query = query.Where(w => w.mbl_pod_eta >= from_date);
                        }
                        if (mbl_date_type == "A/N Received")
                        {
                            query = query.Where(w => w.mbl_carrier_an_recd_dt >= from_date);
                        }
                        if (mbl_date_type == "A/N Sent")
                        {
                            query = query.Where(w => w.mbl_an_sent_dt >= from_date);
                        }
                    }
                    if (!Lib.IsBlank(mbl_to_date))
                    {
                        to_date = Lib.ParseDateOnly(mbl_to_date!);
                        if (mbl_date_type == "REF. DATE")
                        {
                            query = query.Where(w => w.mbl_ref_date <= to_date);
                        }
                        if (mbl_date_type == "ETD")
                        {
                            query = query.Where(w => w.mbl_pol_etd <= to_date);
                        }
                        if (mbl_date_type == "ETA")
                        {
                            query = query.Where(w => w.mbl_pod_eta <= to_date);
                        }
                        if (mbl_date_type == "A/N Received")
                        {
                            query = query.Where(w => w.mbl_carrier_an_recd_dt <= to_date);
                        }
                        if (mbl_date_type == "A/N Sent")
                        {
                            query = query.Where(w => w.mbl_an_sent_dt <= to_date);
                        }
                    }
                    if (!Lib.IsBlank(mbl_mode))
                    {
                        query = query.Where(w => w.mbl_mode == mbl_mode);
                    }
                    if (!Lib.IsBlank(mbl_stages))
                    {
                        var types = mbl_stages!.Split(',');
                        query = query.Where(w => types.Contains(w.shipstage!.param_code));
                    }
                    if (!Lib.IsBlank(mbl_shipper_name))
                    {
                        query = query.Where(w => w.shipper!.cust_name == mbl_shipper_name);
                    }
                    if (!Lib.IsBlank(mbl_consignee_name))
                    {
                        query = query.Where(w => w.consignee!.cust_name == mbl_consignee_name);
                    }
                    if (!Lib.IsBlank(mbl_agent_name))
                    {
                        query = query.Where(w => w.agent!.cust_name == mbl_agent_name);
                    }
                    if (!Lib.IsBlank(mbl_handled_name))
                    {
                        if(mbl_user_role == "Handled By")
                            query = query.Where(w => w.handledby!.param_name == mbl_handled_name);
                        if(mbl_user_role == "Sales. Rep")
                            query = query.Where(w => w.salesman!.param_name == mbl_handled_name);
                    }
                    if (!Lib.IsBlank(rec_created_name))
                    {
                        query = query.Where(w => w.rec_created_by == rec_created_name);
                    }
                    if (!Lib.IsBlank(mbl_incoterm) && mbl_incoterm != "ALL" )
                    {
                        query = query.Where(w => w.incoterm!.param_name == mbl_incoterm);
                    }
                    if (!Lib.IsZero(mbl_eta_within))
                    {
                        var today = DateOnly.FromDateTime(DbLib.GetDateTime());
                        query = query.Where(w => w.mbl_pod_eta >= today && w.mbl_pod_eta <= today.AddDays(mbl_eta_within));
                    }

                    query = query.OrderBy(o => o.mbl_refno);

                    var MRecords = await query.Select(e => new rep_shipmentlog_dto
                    {
                        mbl_id = e.mbl_id,
                        mbl_refno = e.mbl_refno,
                        mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                        mbl_mode = e.mbl_mode,
                        mbl_no = e.mbl_no,
                        mbl_houseno = e.mbl_no,
                        mbl_shipstage = e.shipstage!.param_name,

                        mbl_agent_name = e.agent!.cust_name,
                        mbl_shipper_name = e.shipper!.cust_name,
                        mbl_consignee_name = e.consignee!.cust_name,
                        mbl_handled_name = e.handledby!.param_name,
                        mbl_liner_name = e.liner!.param_name,
                        mbl_liner_bookingno = e.mbl_liner_bookingno,
                        mbl_cntr_type = e.mbl_cntr_type,
                        mbl_incoterm = e.incoterm!.param_name,

                        mbl_firm_code = e.cargoloc!.cust_firm_code,
                        mbl_it_tot = e.mbl_it_tot,
                        mbl_bo_status = e.mbl_bo_status,
                        mbl_bo_attended_code = e.mbl_bo_attended_code,
                        mbl_mstatus = e.mblstatus!.param_name,

                        mbl_pol_name = e.pol!.param_name,
                        mbl_pod_name = e.pod!.param_name,
                        mbl_pol_etd = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateFormat),
                        mbl_pod_eta = Lib.FormatDate(e.mbl_pod_eta, Lib.outputDateFormat),
                        mbl_carrier_an_recd_dt = Lib.FormatDate(e.mbl_carrier_an_recd_dt, Lib.outputDateFormat),
                        mbl_an_sent_dt = Lib.FormatDate(e.mbl_an_sent_dt, Lib.outputDateFormat),

                        rec_created_by = e.rec_created_by,
                        rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                        rec_edited_by = e.rec_edited_by,
                        rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                    }).ToListAsync();
                    Records.AddRange(MRecords);
                }

                if (mbl_is_house == "Y")
                {
                    IQueryable<cargo_housem> query = context.cargo_housem
                        .Include(h => h.shipper)
                        .Include(h => h.consignee)
                        .Include(h => h.incoterm)
                        .Include(h => h.master)
                            .ThenInclude(m => m!.liner)
                        .Include(h => h.master)
                            .ThenInclude(m => m!.pol)
                        .Include(h => h.master)
                            .ThenInclude(m => m!.pod)
                        .Include(h => h.master)
                            .ThenInclude(m => m!.agent);

                    query = query.Where(w => w.rec_company_id == company_id);
                    query = query.Where(w => w.rec_branch_id == branch_id);

                    if (!Lib.IsBlank(mbl_from_date))
                    {
                        from_date = Lib.ParseDateOnly(mbl_from_date!);
                        if (mbl_date_type == "REF. DATE")
                        {
                            query = query.Where(w => w.master!.mbl_ref_date >= from_date);
                        }
                        if (mbl_date_type == "ETD")
                        {
                            query = query.Where(w => w.master!.mbl_pol_etd >= from_date);
                        }
                        if (mbl_date_type == "ETA")
                        {
                            query = query.Where(w => w.master!.mbl_pod_eta >= from_date);
                        }
                        if (mbl_date_type == "A/N Received")
                        {
                            query = query.Where(w => w.master!.mbl_carrier_an_recd_dt >= from_date);
                        }
                        if (mbl_date_type == "A/N Sent")
                        {
                            query = query.Where(w => w.master!.mbl_an_sent_dt >= from_date);
                        }
                    }
                    if (!Lib.IsBlank(mbl_to_date))
                    {
                        to_date = Lib.ParseDateOnly(mbl_to_date!);
                        if (mbl_date_type == "REF. DATE")
                        {
                            query = query.Where(w => w.master!.mbl_ref_date <= to_date);
                        }
                        if (mbl_date_type == "ETD")
                        {
                            query = query.Where(w => w.master!.mbl_pol_etd <= to_date);
                        }
                        if (mbl_date_type == "ETA")
                        {
                            query = query.Where(w => w.master!.mbl_pod_eta <= to_date);
                        }
                        if (mbl_date_type == "A/N Received")
                        {
                            query = query.Where(w => w.master!.mbl_carrier_an_recd_dt <= to_date);
                        }
                        if (mbl_date_type == "A/N Sent")
                        {
                            query = query.Where(w => w.master!.mbl_an_sent_dt <= to_date);
                        }
                    }
                    if (!Lib.IsBlank(mbl_mode))
                    {
                        query = query.Where(w => w.master!.mbl_mode == mbl_mode);
                    }
                    if (!Lib.IsBlank(mbl_stages))
                    {
                        var types = mbl_stages!.Split(',');
                        query = query.Where(w => types.Contains(w.shipstage!.param_code));
                    }
                    if (!Lib.IsBlank(mbl_shipper_name))
                    {
                        query = query.Where(w => w.shipper!.cust_name == mbl_shipper_name);
                    }
                    if (!Lib.IsBlank(mbl_consignee_name))
                    {
                        query = query.Where(w => w.consignee!.cust_name == mbl_consignee_name);
                    }
                    if (!Lib.IsBlank(mbl_agent_name))
                    {
                        query = query.Where(w => w.agent!.cust_name == mbl_agent_name);
                    }
                    if (!Lib.IsBlank(mbl_handled_name))
                    {
                        if(mbl_user_role == "Handled By")
                            query = query.Where(w => w.handledby!.param_name == mbl_handled_name);
                        if(mbl_user_role == "Sales. Rep")
                            query = query.Where(w => w.salesman!.param_name == mbl_handled_name);
                    }
                    if (!Lib.IsBlank(rec_created_name))
                    {
                        query = query.Where(w => w.rec_created_by == rec_created_name);
                    }
                    if (!Lib.IsBlank(mbl_incoterm) && mbl_incoterm != "ALL" )
                    {
                        query = query.Where(w => w.incoterm!.param_name == mbl_incoterm);
                    }
                    if (!Lib.IsZero(mbl_eta_within))
                    {
                        var today = DateOnly.FromDateTime(DbLib.GetDateTime());
                        query = query.Where(w => w.master!.mbl_pod_eta >= today && w.master.mbl_pod_eta <= today.AddDays(mbl_eta_within));
                    }
                    if (mbl_pending_ams == "Y")
                    {
                        query = query.Where(w => w.hbl_ams_fileno!.Length < 8 || w.hbl_ams_fileno == null );
                    }

                    query = query.OrderBy(o => o.master!.mbl_refno);

                    var HRecords = await query.Select(e => new rep_shipmentlog_dto
                    {
                        mbl_id = e.master!.mbl_id,
                        mbl_hbl_id = e.hbl_id,
                        mbl_refno = e.master!.mbl_refno,
                        mbl_ref_date = Lib.FormatDate(e.master.mbl_ref_date, Lib.outputDateFormat),
                        mbl_mode = e.master.mbl_mode,
                        mbl_houseno = e.hbl_houseno,
                        mbl_shipstage = e.shipstage!.param_name,

                        mbl_agent_name = e.master.agent!.cust_name,
                        mbl_shipper_name = e.shipper!.cust_name,
                        mbl_consignee_name = e.consignee!.cust_name,
                        mbl_incoterm = e.incoterm!.param_name,
                        mbl_pol_name = e.master.pol!.param_name,
                        mbl_pod_name = e.master.pod!.param_name,
                        mbl_pol_etd = Lib.FormatDate(e.master.mbl_pol_etd, Lib.outputDateFormat),
                        mbl_pod_eta = Lib.FormatDate(e.master.mbl_pod_eta, Lib.outputDateFormat),
                        mbl_firm_code = e.location!.cust_firm_code,

                        mbl_ams_fileno = e.hbl_ams_fileno,
                        mbl_it_tot = e.hbl_is_itshipment,
                        mbl_bo_status = e.master.mbl_bo_status,
                        mbl_isf_no = e.hbl_isf_no,
                        mbl_mstatus = e.master.mblstatus!.param_name,
                        mbl_hstatus = e.telexrelease!.param_name,
                        mbl_is_pl = e.hbl_is_pl == "Y" ? "YES" : "NO",
                        mbl_is_ci = e.hbl_is_ci == "Y" ? "YES" : "NO",
                        mbl_is_carr_an = e.hbl_is_carr_an == "Y" ? "YES" : "NO",
                        mbl_custom_reles_status = e.hbl_custom_reles_status,
                        mbl_frt_status_name = e.hbl_frt_status_name,
                        mbl_paid_status = $"{e.paidstatus!.param_name} {e.hbl_paid_remarks}",
                        mbl_lfd = Lib.FormatDate(e.hbl_lfd_date, Lib.outputDateFormat),
                        mbl_is_delivery = e.hbl_is_delivery,
                        mbl_packages = e.hbl_packages,
                        mbl_place_final = e.hbl_place_final,
                        hbl_plf_eta = Lib.FormatDate(e.hbl_plf_eta, Lib.outputDateFormat),
                        // mbl_carrier_an_recd_dt = Lib.FormatDate(e.mbl_carrier_an_recd_dt, Lib.outputDateFormat),
                        rec_created_by = e.rec_created_by,
                        rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                        rec_edited_by = e.rec_edited_by,
                        rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                    }).ToListAsync();
                    Records.AddRange(HRecords);
                }

                Func<rep_shipmentlog_dto, string> groupSelector = x => "";

                if (mbl_sort_order == "REFNO")
                    groupSelector = x => x.mbl_refno!;
                if (mbl_sort_order == "MASTER")
                    groupSelector = x => x.mbl_no!;
                if (mbl_sort_order == "HOUSE")
                    groupSelector = x => x.mbl_houseno!;
                if (mbl_sort_order == "SHIPMENT-STAGE")
                    groupSelector = x => x.mbl_shipstage!;
                if (mbl_sort_order == "CARRIER")
                    groupSelector = x => x.mbl_liner_name!;
                if (mbl_sort_order == "CONSIGNEE")
                    groupSelector = x => x.mbl_consignee_name!;
                if (mbl_sort_order == "ETA")
                    groupSelector = x => x.mbl_pod_eta!;
                if (mbl_sort_order == "CLIENT-PAID")
                    groupSelector = x => x.mbl_paid_status!;
                if (mbl_sort_order == "FINAL-DESTINATION")
                    groupSelector = x => x.mbl_place_final!;
                if (mbl_sort_order == "A/N RECEIVED")
                    groupSelector = x => x.mbl_carrier_an_recd_dt!;
                if (mbl_sort_order == "A/N SENT")
                    groupSelector = x => x.mbl_an_sent_dt!;

                Records = Records.OrderBy(groupSelector).ToList();


                if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                {
                    _page.rows = Records.Count();
                    _page.pages = Lib.getTotalPages(_page.rows, _page.pageSize);
                    _page.currentPageNo = 1;
                }
                else
                {
                    _page.currentPageNo = Lib.FindPage(action, _page.currentPageNo, _page.pages);
                }
                if (!isPrint)
                {
                    int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

                    Records = Records.Skip(StartRow).Take(_page.pageSize).ToList();
                }

                RetData.Add("records", Records);

                if (action == "PDF" || action == "PRINT")
                {
                    var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                    fileDataList.Add(pdfResult);
                }
                // if (action == "EXCEL" || action == "PRINT")
                // {
                //     var excelResult = ProcessExcelFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                //     fileDataList.Add(excelResult);
                // }

                RetData.Add("fileData", fileDataList);
                RetData.Add("action", action);
                RetData.Add("page", _page);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public filesm ProcessPdfFileAsync(List<rep_shipmentlog_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Records error");

            ShipmentLogPdfFile bc = new ShipmentLogPdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                DateType = searchInfo.ContainsKey("mbl_date_type") ? searchInfo["mbl_date_type"] : "",
                FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
                ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
                ShipperName = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
                ConsigneeName = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
                AgentName = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
                UserRole = searchInfo.ContainsKey("mbl_user_role") ? searchInfo["mbl_user_role"] : "",
                handledBy = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
                CreatedBy = searchInfo.ContainsKey("rec_created_name") ? searchInfo["rec_created_name"] : "",
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
        // public filesm ProcessExcelFileAsync(List<rep_shipmentlog_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        // {
        //     var Dt_List = Records;
        //     if (Dt_List.Count <= 0)
        //         throw new Exception("Excel List Records error");

        //     ITShipmentExcelFile bc = new ITShipmentExcelFile
        //     {
        //         Dt_List = Dt_List,
        //         report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //         Title = title,
        //         Company_id = company_id,
        //         Branch_id = branch_id,
        //         context = context,
        //         User_name = user_name,
        //         DateType = searchInfo.ContainsKey("mbl_date_type") ? searchInfo["mbl_date_type"] : "",
        //         FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
        //         // ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
        //         // OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
        //         // ParentName = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
        //         // ShipperName = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
        //         // ConsigneeName = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
        //     };
        //     bc.Process();

        //     if (bc.fList == null || !bc.fList.Any())
        //         throw new Exception("Excel generation failed.");

        //     var file = bc.fList[0];

        //     var record = new filesm
        //     {
        //         filepath = file.filename!,
        //         filename = file.filedisplayname!,
        //         filetype = file.filetype!
        //     };

        //     return record;
        // }
    }
}

// | (*)-(*) |
// |    |    |
// |   ._.   |

//      __________
//      |:-)||(-:|
//      ----------