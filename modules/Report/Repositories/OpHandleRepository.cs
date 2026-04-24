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
using Report.Interfaces;
using Common.DTO.Report;
using Report.Printing;

//Name : Sourav V
//Created Date : 26/12/2025
//Remark : this file defines functions getList and getRecords of operations for report/summary


namespace Report.Repositories
{
    public class OpHandleRepository : IOpHandleRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public OpHandleRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var ophandle_from_date = "";
                var ophandle_to_date = "";
                var ophandle_type = "";
                var ophandle_group = "";
                var ophandle_handled_by = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("ophandle_from_date"))
                    ophandle_from_date = data["ophandle_from_date"].ToString();
                if (data.ContainsKey("ophandle_to_date"))
                    ophandle_to_date = data["ophandle_to_date"].ToString();
                if (data.ContainsKey("ophandle_type"))
                    ophandle_type = data["ophandle_type"].ToString();
                if (data.ContainsKey("ophandle_group"))
                    ophandle_group = data["ophandle_group"].ToString();

                if (data.ContainsKey("ophandle_handled_by"))
                    ophandle_handled_by = data["ophandle_handled_by"].ToString();

                company_id = Lib.GetValidIntValue(data!, "rec_company_id", "Company Id Not Found");
                branch_id = Lib.GetValidIntValue(data!, "rec_branch_id", "Branch Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                if( action == "PRINT" || action == "EXCEL" || action == "PDF")
                {
                    isPrint = true;
                }
                var fileDataList = new List<filesm>();
                var searchInfo = new Dictionary<string, string>
                {
                    {"ophandle_from_date",ophandle_from_date!},
                    {"ophandle_to_date",ophandle_to_date!},
                    {"ophandle_group", ophandle_group!},
                    {"ophandle_type", ophandle_type!},
                };

                List<rep_ophandle_dto> Records = new List<rep_ophandle_dto>();

                if (ophandle_group == "MASTER")
                {
                    // fetch master details including type(ai,ae,si,se)

                    IQueryable<cargo_masterm> query = context.cargo_masterm;

                    query = query.Where(w => w.rec_company_id == company_id);
                    query = query.Where(w => w.rec_branch_id == branch_id);
                    if (!Lib.IsBlank(ophandle_handled_by))
                    {
                        query = query.Where(w => w.handledby!.param_name == ophandle_handled_by);
                    }
                    if (!Lib.IsBlank(ophandle_type))
                    {
                        if (ophandle_type == "ALL")
                        {
                            var Types = new[] { "SEA IMPORT", "SEA EXPORT", "AIR IMPORT", "AIR EXPORT" };
                            query = query.Where(w => Types.Contains(w.mbl_mode));
                        }
                        else
                        {
                            query = query.Where(w => w.mbl_mode == ophandle_type);
                        }
                    }

                    if (!Lib.IsBlank(ophandle_from_date))
                    {
                        from_date = Lib.ParseDateOnly(ophandle_from_date!);
                        query = query.Where(w => w.mbl_ref_date >= from_date);
                    }
                    if (!Lib.IsBlank(ophandle_to_date))
                    {
                        to_date = Lib.ParseDateOnly(ophandle_to_date!);
                        query = query.Where(w => w.mbl_ref_date <= to_date);
                    }

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

                    query = query
                        .OrderBy(c => c.mbl_ref_date);

                    if (!isPrint)
                    {
                        int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

                        query = query
                            .Skip(StartRow)
                            .Take(_page.pageSize);
                    }

                    Records = await query.Select(e => new rep_ophandle_dto
                    {
                        ophandle_id = e.mbl_id,
                        ophandle_refno = e.mbl_refno,
                        ophandle_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                        ophandle_type = e.mbl_mode,
                        ophandle_agent_id = e.mbl_agent_id,
                        ophandle_agent_name = e.agent!.cust_name,
                        ophandle_handled_id = e.mbl_handled_id,
                        ophandle_handled_name = e.handledby!.param_name,
                        ophandle_pol_id = e.mbl_pol_id,
                        ophandle_pol_name = e.pol!.param_name,
                        ophandle_pod_id = e.mbl_pod_id,
                        ophandle_pod_name = e.pod!.param_name,
                        ophandle_pol_etd = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateFormat),
                        ophandle_pod_eta = Lib.FormatDate(e.mbl_pod_eta, Lib.outputDateFormat),

                        rec_created_by = e.rec_created_by,
                        rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                        rec_edited_by = e.rec_edited_by,
                        rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                    }).ToListAsync();

                    RetData.Add("records", Records);

                }
                if (ophandle_group == "HOUSE")
                {
                    // fetch master details including type(ai,ae,si,se)

                    IQueryable<cargo_housem> query = context.cargo_housem;

                    query = query.Where(w => w.rec_company_id == company_id);
                    query = query.Where(w => w.rec_branch_id == branch_id);
                    if (!Lib.IsBlank(ophandle_handled_by))
                    {
                        query = query.Where(w => w.handledby!.param_name == ophandle_handled_by);
                    }
                    // query = query.Where(w => w.hbl_mode == ophandle_type);
                    if (!Lib.IsBlank(ophandle_type))
                    {
                        if (ophandle_type == "ALL")
                        {
                            var Types = new[] { "SEA IMPORT", "SEA EXPORT", "AIR IMPORT", "AIR EXPORT" };
                            query = query.Where(w => Types.Contains(w.hbl_mode));
                        }
                        else
                        {
                            query = query.Where(w => w.hbl_mode == ophandle_type);
                        }
                    }

                    if (!Lib.IsBlank(ophandle_from_date))
                    {
                        from_date = Lib.ParseDateOnly(ophandle_from_date!);
                        query = query.Where(w => w.master!.mbl_ref_date >= from_date);
                    }
                    if (!Lib.IsBlank(ophandle_to_date))
                    {
                        to_date = Lib.ParseDateOnly(ophandle_to_date!);
                        query = query.Where(w => w.master!.mbl_ref_date <= to_date);
                    }

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

                    query = query
                        .OrderBy(c => c.master!.mbl_ref_date);
                    if (!isPrint)
                    {
                        int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

                        query= query
                            .Skip(StartRow)
                            .Take(_page.pageSize);
                    }

                    Records = await query.Select(e => new rep_ophandle_dto
                    {
                        ophandle_id = e.master!.mbl_id,
                        ophandle_hbl_id = e.hbl_id,
                        ophandle_refno = e.master!.mbl_refno,
                        ophandle_ref_date = Lib.FormatDate(e.master!.mbl_ref_date, Lib.outputDateFormat),
                        ophandle_type = e.hbl_mode,
                        ophandle_agent_id = e.hbl_agent_id,
                        ophandle_agent_name = e.agent!.cust_name ?? e.master.agent!.cust_name,
                        ophandle_handled_id = e.hbl_handled_id,
                        ophandle_handled_name = e.handledby!.param_name,
                        ophandle_pol_name = e.hbl_pol_name ?? e.master.pol!.param_name,
                        ophandle_pod_name = e.hbl_pod_name ?? e.master.pod!.param_name,
                        ophandle_houseno = e.hbl_houseno,
                        ophandle_shipper_id = e.hbl_shipper_id,
                        ophandle_shipper_name = e.hbl_shipper_name,
                        ophandle_consignee_id = e.hbl_consignee_id,
                        ophandle_consignee_name = e.hbl_consignee_name,
                        ophandle_shipterm_id = e.hbl_ship_term_id,
                        ophandle_shipterm_name = e.shipterm!.param_name,

                        ophandle_pol_etd = Lib.FormatDate(e.master.mbl_pol_etd, Lib.outputDateFormat),
                        ophandle_pod_eta = Lib.FormatDate(e.master.mbl_pod_eta, Lib.outputDateFormat),

                        rec_created_by = e.rec_created_by,
                        rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                        rec_edited_by = e.rec_edited_by,
                        rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        
                    }).ToListAsync();

                    RetData.Add("records", Records);
                }
                if (ophandle_group == "SUMMARY")
                {

                    IQueryable<cargo_masterm> query = context.cargo_masterm;

                    query = query.Where(w => w.rec_company_id == company_id);
                    query = query.Where(w => w.rec_branch_id == branch_id);
                    if (!Lib.IsBlank(ophandle_handled_by))
                    {
                        query = query.Where(w => w.handledby!.param_name == ophandle_handled_by);
                    }
                    if (!Lib.IsBlank(ophandle_type))
                    {
                        if (ophandle_type == "ALL")
                        {
                            var Types = new[] { "SEA IMPORT", "SEA EXPORT", "AIR IMPORT", "AIR EXPORT" };
                            query = query.Where(w => Types.Contains(w.mbl_mode));
                        }
                        else
                        {
                            query = query.Where(w => w.mbl_mode == ophandle_type);
                        }
                    }

                    if (!Lib.IsBlank(ophandle_from_date))
                    {
                        from_date = Lib.ParseDateOnly(ophandle_from_date!);
                        query = query.Where(w => w.mbl_ref_date >= from_date);
                    }

                    if (!Lib.IsBlank(ophandle_to_date))
                    {
                        to_date = Lib.ParseDateOnly(ophandle_to_date!);
                        query = query.Where(w => w.mbl_ref_date <= to_date);
                    }

                    Records = await query
                    .GroupBy(g => new { g.mbl_handled_id, g.handledby!.param_name })
                    .Select(m => new rep_ophandle_dto
                    {
                        ophandle_handled_id = m.Key.mbl_handled_id,
                        ophandle_handled_name = m.Key.param_name,
                        ophandle_master_count = m.Count(),
                        ophandle_house_count = m.Sum(x => x.mbl_house_tot ?? 0)
                    })
                    .OrderBy(o => o.ophandle_handled_name)
                    .ToListAsync();

                    int totalMasterCount = Records.Sum(x => x.ophandle_master_count) ?? 0;
                    int totalHouseCount  = Records.Sum(x => x.ophandle_house_count)?? 0;

                    Records.Add(new rep_ophandle_dto
                    {
                        ophandle_handled_name = "TOTAL",
                        ophandle_master_count = totalMasterCount,
                        ophandle_house_count = totalHouseCount
                    });

                    RetData.Add("records", Records);
                    
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

                }
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
                RetData.Add("page", _page);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public filesm ProcessPdfFileAsync(List<rep_ophandle_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Records error");

            OpHandlePdfFile bc = new OpHandlePdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("ophandle_from_date") ? searchInfo["ophandle_from_date"] : "",
                ToDate = searchInfo.ContainsKey("ophandle_to_date") ? searchInfo["ophandle_to_date"] : "",
                Type = searchInfo.ContainsKey("ophandle_type") ? searchInfo["ophandle_type"] : "",
                OpGroup = searchInfo.ContainsKey("ophandle_group") ? searchInfo["ophandle_group"] : ""

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
        public filesm ProcessExcelFileAsync(List<rep_ophandle_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            ProcessOpHandleExcelFile bc = new ProcessOpHandleExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("ophandle_from_date") ? searchInfo["ophandle_from_date"] : "",
                ToDate = searchInfo.ContainsKey("ophandle_to_date") ? searchInfo["ophandle_to_date"] : "",
                Type = searchInfo.ContainsKey("ophandle_type") ? searchInfo["ophandle_type"] : "",
                OpGroup = searchInfo.ContainsKey("ophandle_group") ? searchInfo["ophandle_group"] : ""
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
