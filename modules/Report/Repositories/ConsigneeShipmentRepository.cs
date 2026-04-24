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
//Created Date : 29/01/2026
//Remark : this file defines functions getList and getRecords of operations for Consignee Shipment report


namespace Report.Repositories
{
    public class ConsigneeShipmentRepository : IConsigneeShipmentRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public ConsigneeShipmentRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var hbl_date_type = "";
                var hbl_from_date = "";
                var hbl_to_date = "";
                var hbl_mode = "";
                var hbl_parent_name = "";
                var hbl_consignee_name = "";
                var hbl_bl_type = "";
                var hbl_format = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("hbl_date_type"))
                    hbl_date_type = data["hbl_date_type"].ToString();
                if (data.ContainsKey("hbl_from_date"))
                    hbl_from_date = data["hbl_from_date"].ToString();
                if (data.ContainsKey("hbl_to_date"))
                    hbl_to_date = data["hbl_to_date"].ToString();
                if (data.ContainsKey("hbl_mode"))
                    hbl_mode = data["hbl_mode"].ToString();
                if (data.ContainsKey("hbl_parent_name"))
                    hbl_parent_name = data["hbl_parent_name"].ToString()!;
                if (data.ContainsKey("hbl_consignee_name"))
                    hbl_consignee_name = data["hbl_consignee_name"].ToString();
                if (data.ContainsKey("hbl_bl_type"))
                    hbl_bl_type = data["hbl_bl_type"].ToString();
                if (data.ContainsKey("hbl_format"))
                    hbl_format = data["hbl_format"].ToString();

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
                    {"hbl_date_type",hbl_date_type!},
                    {"hbl_from_date",hbl_from_date!},
                    {"hbl_to_date",hbl_to_date!},
                    {"hbl_mode", hbl_mode!},
                    {"hbl_parent_name", hbl_parent_name},
                    {"hbl_consignee_name", hbl_consignee_name!},
                    {"hbl_bl_type", hbl_bl_type!},
                    {"hbl_format", hbl_format!},
                };

                List<rep_consigneeship_dto> Records = new List<rep_consigneeship_dto>();

                if (hbl_bl_type == "MASTER WISE")
                {
                    IQueryable<cargo_masterm> query = context.cargo_masterm
                        .Include(m => m.shipper)
                        .Include(m => m.consignee)     
                        .Include(m => m.liner)
                        .Include(m => m.vessel)
                        .Include(m => m.pol)
                        .Include(m => m.pod)
                        .Include(m => m.agent);

                    query = query.Where(w => w.rec_company_id == company_id);
                    query = query.Where(w => w.rec_branch_id == branch_id);

                    if (!Lib.IsBlank(hbl_from_date))
                    {
                        from_date = Lib.ParseDateOnly(hbl_from_date!);
                        if (hbl_date_type == "REF. DATE")
                        {
                            query = query.Where(w => w.mbl_ref_date >= from_date);
                        }
                        if (hbl_date_type == "ETD")
                        {
                            query = query.Where(w => w.mbl_pol_etd >= from_date);
                        }
                        if (hbl_date_type == "ETA")
                        {
                            query = query.Where(w => w.mbl_pod_eta >= from_date);
                        }
                        
                    }
                    if (!Lib.IsBlank(hbl_to_date))
                    {
                        to_date = Lib.ParseDateOnly(hbl_to_date!);
                        if (hbl_date_type == "REF. DATE")
                        {
                            query = query.Where(w => w.mbl_ref_date <= to_date);
                        }
                        if (hbl_date_type == "ETD")
                        {
                            query = query.Where(w => w.mbl_pol_etd <= to_date);
                        }
                        if (hbl_date_type == "ETA")
                        {
                            query = query.Where(w => w.mbl_pod_eta <= to_date);
                        }
                    }
                    if (!Lib.IsBlank(hbl_mode))
                    {
                        query = query.Where(w => w.mbl_mode == hbl_mode);
                    }
                    if (!Lib.IsBlank(hbl_parent_name))
                    {
                        query = query.Where(w => w.agent!.customer!.cust_name == hbl_parent_name);     // check  cust_is_parent 
                    }
                    if (!Lib.IsBlank(hbl_consignee_name))
                    {
                        query = query.Where(w => w.consignee!.cust_name == hbl_consignee_name);
                    }
                    
                    var MasterList = await query
                        .OrderBy(o => o.mbl_ref_date)
                        .ToListAsync();
                    
                    List<cargo_container> allContainers = new List<cargo_container>();

                    var master_cntr = MasterList
                        .Select(h => h.mbl_id).ToList();

                    allContainers = await context.cargo_container
                        .Where(c => master_cntr.Contains(c.cntr_mbl_id) && c.cntr_catg == "M")
                        .Include(c => c.cntrtype)
                        .ToListAsync();

                    foreach (var m in MasterList)
                    {
                        List<cargo_container> cntr_list = new List<cargo_container>();
                        
                        cntr_list = allContainers
                            .Where(c => c.cntr_mbl_id == m.mbl_id)
                            .ToList();

                        if (cntr_list.Count == 0)
                        {
                            Records.Add(new rep_consigneeship_dto
                            {
                                hbl_id = m.mbl_id,
                                hbl_mbl_id = m.mbl_id,
                                hbl_mbl_refno = m.mbl_refno,
                                hbl_ref_date = Lib.FormatDate(m.mbl_ref_date, Lib.outputDateFormat),
                                hbl_mode = m.mbl_mode,

                                hbl_agent_name = m.agent?.cust_name,
                                hbl_liner_name = m.liner?.param_name,
                                hbl_shipper_name = m.shipper?.cust_name,
                                hbl_consignee_name = m.consignee?.cust_name,
                                hbl_pol_name = m.pol?.param_name,
                                hbl_pod_name = m.pod?.param_name,
                                hbl_mbl_no = m.mbl_no,

                                hbl_vessel_name = m.mbl_vessel_name,
                                hbl_voyage = m.mbl_voyage,
                                hbl_pol_etd = Lib.FormatDate(m.mbl_pol_etd, Lib.outputDateFormat),
                                hbl_pod_eta = Lib.FormatDate(m.mbl_pod_eta, Lib.outputDateFormat),

                                hbl_an_sent = m.mbl_shipment_stage_id > 500 ? "SENT" : "",

                                rec_created_by = m.rec_created_by,
                                rec_created_date = Lib.FormatDate(m.rec_created_date, Lib.outputDateTimeFormat),
                                rec_edited_by = m.rec_edited_by,
                                rec_edited_date = Lib.FormatDate(m.rec_edited_date, Lib.outputDateTimeFormat),
                            });
                        }
                        if(cntr_list.Count != 0)
                        {
                            foreach (var c in cntr_list)
                            {
                                Records.Add(new rep_consigneeship_dto
                                {
                                    hbl_id = m.mbl_id,
                                    hbl_mbl_id = m.mbl_id,
                                    hbl_mbl_refno = m.mbl_refno,
                                    hbl_ref_date = Lib.FormatDate(m.mbl_ref_date, Lib.outputDateFormat),
                                    hbl_mode = m.mbl_mode,

                                    hbl_agent_name = m.agent?.cust_name,
                                    hbl_liner_name = m.liner?.param_name,
                                    hbl_shipper_name = m.shipper?.cust_name,
                                    hbl_consignee_name = m.consignee?.cust_name,
                                    hbl_pol_name = m.pol?.param_name,
                                    hbl_pod_name = m.pod?.param_name,
                                    hbl_mbl_no = m.mbl_no,

                                    hbl_vessel_name = m.mbl_vessel_name,
                                    hbl_voyage = m.mbl_voyage,
                                    hbl_pol_etd = Lib.FormatDate(m.mbl_pol_etd, Lib.outputDateFormat),
                                    hbl_pod_eta = Lib.FormatDate(m.mbl_pod_eta, Lib.outputDateFormat),

                                    hbl_cntr_no = c.cntr_no,
                                    hbl_cntr_type_name = c.cntrtype?.param_name,
                                    hbl_cntr_sealno = c.cntr_sealno,

                                    hbl_an_sent = m.mbl_shipment_stage_id > 500 ? "SENT" : "",

                                    cntr_lfd = Lib.FormatDate(c.cntr_lfd, Lib.outputDateFormat),
                                    cntr_pick_date = Lib.FormatDate(c.cntr_pick_date, Lib.outputDateFormat),
                                    cntr_pick_status = Lib.IsBlank( Lib.FormatDate(c.cntr_pick_date, Lib.outputDateFormat)) ? "" : "PICK UP",
                                    cntr_return_date = Lib.FormatDate(c.cntr_return_date, Lib.outputDateFormat),

                                    rec_created_by = m.rec_created_by,
                                    rec_created_date = Lib.FormatDate(m.rec_created_date, Lib.outputDateTimeFormat),
                                    rec_edited_by = m.rec_edited_by,
                                    rec_edited_date = Lib.FormatDate(m.rec_edited_date, Lib.outputDateTimeFormat),
                                });
                            }
                        }
                    }    
                }
                if (hbl_bl_type == "HOUSE WISE")
                {
                    IQueryable<cargo_housem> query = context.cargo_housem
                        .Include(h => h.shipper)
                        .Include(h => h.consignee)
                        .Include(h => h.master)
                            .ThenInclude(m => m!.liner)
                        .Include(h => h.master)
                            .ThenInclude(m => m!.vessel)
                        .Include(h => h.master)
                            .ThenInclude(m => m!.pol)
                        .Include(h => h.master)
                            .ThenInclude(m => m!.pod)
                        .Include(h => h.master)
                            .ThenInclude(m => m!.agent);

                    query = query.Where(w => w.rec_company_id == company_id);
                    query = query.Where(w => w.rec_branch_id == branch_id);

                    if (!Lib.IsBlank(hbl_from_date))
                    {
                        from_date = Lib.ParseDateOnly(hbl_from_date!);
                        if (hbl_date_type == "REF. DATE")
                        {
                            query = query.Where(w => w.master!.mbl_ref_date >= from_date);
                        }
                        if (hbl_date_type == "ETD")
                        {
                            query = query.Where(w => w.master!.mbl_pol_etd >= from_date);
                        }
                        if (hbl_date_type == "ETA")
                        {
                            query = query.Where(w => w.master!.mbl_pod_eta >= from_date);
                        }
                        
                    }
                    if (!Lib.IsBlank(hbl_to_date))
                    {
                        to_date = Lib.ParseDateOnly(hbl_to_date!);
                        if (hbl_date_type == "REF. DATE")
                        {
                            query = query.Where(w => w.master!.mbl_ref_date <= to_date);
                        }
                        if (hbl_date_type == "ETD")
                        {
                            query = query.Where(w => w.master!.mbl_pol_etd <= to_date);
                        }
                        if (hbl_date_type == "ETA")
                        {
                            query = query.Where(w => w.master!.mbl_pod_eta <= to_date);
                        }
                    }
                    if (!Lib.IsBlank(hbl_mode))
                    {
                        query = query.Where(w => w.hbl_mode == hbl_mode);
                    }
                    if (!Lib.IsBlank(hbl_parent_name))
                    {
                        query = query.Where(w => w.agent!.customer!.cust_name == hbl_parent_name);
                    }
                    if (!Lib.IsBlank(hbl_consignee_name))
                    {
                        query = query.Where(w => w.consignee!.cust_name == hbl_consignee_name);
                    }

                    query = query.OrderBy(o => o.hbl_houseno);
                    
                    var houseList = await query
                        .OrderBy(o => o.master!.mbl_ref_date)
                        .ToListAsync();
                    
                    List<cargo_container> allContainers = new List<cargo_container>();

                    var house_cntr = houseList
                        .Select(h => h.hbl_id).ToList();

                    allContainers = await context.cargo_container
                        .Where(c => house_cntr.Contains(c.cntr_hbl_id) && c.cntr_catg == "H")
                        .Include(c => c.cntrtype)
                        .ToListAsync();

                    foreach (var h in houseList)
                    {
                        List<cargo_container> cntr_list = new List<cargo_container>();

                        cntr_list = allContainers
                            .Where(c => c.cntr_hbl_id == h.hbl_id)
                            .ToList();

                        if (cntr_list.Count == 0)
                        {
                            Records.Add(new rep_consigneeship_dto
                            {
                                hbl_id = h.hbl_id,
                                hbl_mbl_id = h.hbl_mbl_id,
                                hbl_mbl_refno = h.master!.mbl_refno,
                                hbl_ref_date = Lib.FormatDate(h.master.mbl_ref_date, Lib.outputDateFormat),
                                hbl_mode = h.hbl_mode,

                                hbl_agent_name = h.master.agent?.cust_name,
                                hbl_liner_name = h.master.liner?.param_name,
                                hbl_shipper_name = h.shipper?.cust_name,
                                hbl_consignee_name = h.consignee?.cust_name,
                                hbl_location_name = h.location?.cust_name,
                                hbl_pol_name = h.master.pol?.param_name,
                                hbl_pod_name = h.master.pod?.param_name,
                                hbl_mbl_no = h.master.mbl_no,
                                hbl_houseno = h.hbl_houseno,

                                hbl_packages = h.hbl_packages,
                                hbl_pono = h.hbl_pono,
                                hbl_vessel_name = h.master.mbl_vessel_name,
                                hbl_voyage = h.master.mbl_voyage,
                                hbl_pol_etd = Lib.FormatDate(h.master.mbl_pol_etd, Lib.outputDateFormat),
                                hbl_pod_eta = Lib.FormatDate(h.master.mbl_pod_eta, Lib.outputDateFormat),

                                hbl_weight = h.hbl_weight,
                                hbl_remarks = $"{h.hbl_remark1} {h.hbl_remark2} {h.hbl_remark3}",
                                hbl_delivery_date = Lib.FormatDate(h.hbl_delivery_date, Lib.outputDateFormat),
                                hbl_an_sent = h.hbl_shipment_stage_id > 500 ? "SENT" : "",

                                cntr_lfd = hbl_mode == "AIR IMPORT" ? Lib.FormatDate(h.hbl_lfd_date, Lib.outputDateFormat) : "",

                                rec_created_by = h.rec_created_by,
                                rec_created_date = Lib.FormatDate(h.rec_created_date, Lib.outputDateTimeFormat),
                                rec_edited_by = h.rec_edited_by,
                                rec_edited_date = Lib.FormatDate(h.rec_edited_date, Lib.outputDateTimeFormat),
                            });
                        }
                        if(cntr_list.Count != 0)
                        {
                            foreach (var c in cntr_list)
                            {
                                Records.Add(new rep_consigneeship_dto
                                {
                                    hbl_id = h.hbl_id,
                                    hbl_mbl_id = h.hbl_mbl_id,
                                    hbl_mbl_refno = h.master!.mbl_refno,
                                    hbl_ref_date = Lib.FormatDate(h.master.mbl_ref_date, Lib.outputDateFormat),
                                    hbl_mode = h.hbl_mode,

                                    hbl_agent_name = h.master.agent?.cust_name,
                                    hbl_liner_name = h.master.liner?.param_name,
                                    hbl_shipper_name = h.shipper?.cust_name,
                                    hbl_consignee_name = h.consignee?.cust_name,
                                    hbl_location_name = h.location?.cust_name,
                                    hbl_pol_name = h.master.pol?.param_name,
                                    hbl_pod_name = h.master.pod?.param_name,
                                    hbl_mbl_no = h.master.mbl_no,
                                    hbl_houseno = h.hbl_houseno,

                                    hbl_packages = h.hbl_packages,
                                    hbl_pono = h.hbl_pono,
                                    hbl_vessel_name = h.master.mbl_vessel_name,
                                    hbl_voyage = h.master.mbl_voyage,
                                    hbl_pol_etd = Lib.FormatDate(h.master.mbl_pol_etd, Lib.outputDateFormat),
                                    hbl_pod_eta = Lib.FormatDate(h.master.mbl_pod_eta, Lib.outputDateFormat),

                                    hbl_cntr_no = c.cntr_no,
                                    hbl_cntr_type_name = c.cntrtype?.param_name,
                                    hbl_cntr_sealno = c.cntr_sealno,

                                    hbl_weight = h.hbl_weight,
                                    hbl_remarks = $"{h.hbl_remark1} {h.hbl_remark2} {h.hbl_remark3}",
                                    hbl_delivery_date = Lib.FormatDate(h.hbl_delivery_date, Lib.outputDateFormat),
                                    hbl_an_sent = h.hbl_shipment_stage_id > 500 ? "SENT" : "",

                                    cntr_lfd = Lib.FormatDate(c.cntr_lfd, Lib.outputDateFormat),
                                    cntr_pick_date = Lib.FormatDate(c.cntr_pick_date, Lib.outputDateFormat),
                                    cntr_pick_status = Lib.IsBlank( Lib.FormatDate(c.cntr_pick_date, Lib.outputDateFormat)) ? "" : "PICK UP",
                                    cntr_return_date = Lib.FormatDate(c.cntr_return_date, Lib.outputDateFormat),

                                    rec_created_by = h.rec_created_by,
                                    rec_created_date = Lib.FormatDate(h.rec_created_date, Lib.outputDateTimeFormat),
                                    rec_edited_by = h.rec_edited_by,
                                    rec_edited_date = Lib.FormatDate(h.rec_edited_date, Lib.outputDateTimeFormat),
                                });
                            }
                        }
                    }    
                }
                


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

                // if (action == "PDF" || action == "PRINT")
                // {
                //     var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                //     fileDataList.Add(pdfResult);
                // }
                if (action == "EXCEL" || action == "PRINT")
                {
                    var excelResult = ProcessExcelFileAsync(Records, title!, company_id, user_name!, branch_id, searchInfo);
                    fileDataList.Add(excelResult);
                }

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
        // public filesm ProcessPdfFileAsync(List<rep_consigneeship_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        // {
        //     var Dt_List = Records;
        //     if (Dt_List.Count <= 0)
        //         throw new Exception("Print List Records error");

        //     ConsigneeShipmentPdfFile bc = new ConsigneeShipmentPdfFile
        //     {
        //         Dt_List = Dt_List,
        //         Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
        //         Title = title,
        //         Company_id = company_id,
        //         Branch_id = branch_id,
        //         context = context,
        //         User_name = user_name,
        //         FromDate = searchInfo.ContainsKey("hbl_from_date") ? searchInfo["hbl_from_date"] : "",
        //         ToDate = searchInfo.ContainsKey("hbl_to_date") ? searchInfo["hbl_to_date"] : "",
        //         OpGroup = searchInfo.ContainsKey("hbl_mode") ? searchInfo["hbl_mode"] : "",
        //         ParentName = searchInfo.ContainsKey("hbl_parent_name") ? searchInfo["hbl_parent_name"] : "",
        //         AgentName = searchInfo.ContainsKey("hbl_agent_name") ? searchInfo["hbl_agent_name"] : "",
        //         ShipperName = searchInfo.ContainsKey("hbl_shipper_name") ? searchInfo["hbl_shipper_name"] : "",
        //         ConsigneeName = searchInfo.ContainsKey("hbl_consignee_name") ? searchInfo["hbl_consignee_name"] : "",
        //     };
        //     bc.Process();

        //     if (bc.FList == null || !bc.FList.Any())
        //         throw new Exception("File generation failed.");

        //     var file = bc.FList[0];

        //     var record = new filesm
        //     {
        //         filepath = file.filename!,
        //         filename = file.filedisplayname!,
        //         filetype = file.filetype!
        //     };
        //     return record;
        // }
        public filesm ProcessExcelFileAsync(List<rep_consigneeship_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            ConsigneeShipmentExcelFile bc = new ConsigneeShipmentExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                DateType = searchInfo.ContainsKey("hbl_date_type") ? searchInfo["hbl_date_type"] : "",
                FromDate = searchInfo.ContainsKey("hbl_from_date") ? searchInfo["hbl_from_date"] : "",
                ToDate = searchInfo.ContainsKey("hbl_to_date") ? searchInfo["hbl_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("hbl_mode") ? searchInfo["hbl_mode"] : "",
                ParentName = searchInfo.ContainsKey("hbl_parent_name") ? searchInfo["hbl_parent_name"] : "",
                BlType = searchInfo.ContainsKey("hbl_bl_type") ? searchInfo["hbl_bl_type"] : "",
                HblFormat = searchInfo.ContainsKey("hbl_format") ? searchInfo["hbl_format"] : "",
                ConsigneeName = searchInfo.ContainsKey("hbl_consignee_name") ? searchInfo["hbl_consignee_name"] : "",
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