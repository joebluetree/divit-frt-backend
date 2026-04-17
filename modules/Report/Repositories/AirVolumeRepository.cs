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
//Created Date : 16/01/2026
//Remark : this file defines functions getList and getRecords of operations for Air Volume report/summary


namespace Report.Repositories
{
    public class AirVolumeRepository : IAirVolumeRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public AirVolumeRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var mbl_from_date = "";
                var mbl_to_date = "";
                var mbl_format = "";
                var mbl_mode = "";
                var mbl_report_type = "";
                var mbl_agent_name = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("mbl_from_date"))
                    mbl_from_date = data["mbl_from_date"].ToString();
                if (data.ContainsKey("mbl_to_date"))
                    mbl_to_date = data["mbl_to_date"].ToString();
                if (data.ContainsKey("mbl_format"))
                    mbl_format = data["mbl_format"].ToString();
                if (data.ContainsKey("mbl_mode"))
                    mbl_mode = data["mbl_mode"].ToString();
                if (data.ContainsKey("mbl_report_type"))
                    mbl_report_type = data["mbl_report_type"].ToString();
                if (data.ContainsKey("mbl_agent_name"))
                    mbl_agent_name = data["mbl_agent_name"].ToString();

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
                    {"mbl_from_date",mbl_from_date!},
                    {"mbl_to_date",mbl_to_date!},
                    {"mbl_format", mbl_format!},
                    {"mbl_mode", mbl_mode!},
                    {"mbl_report_type", mbl_report_type!},
                };

                IQueryable<cargo_masterm> query = context.cargo_masterm;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);

                if (!Lib.IsBlank(mbl_from_date))
                {
                    from_date = Lib.ParseDateOnly(mbl_from_date!);
                    query = query.Where(w => w.mbl_ref_date >= from_date);
                }
                if (!Lib.IsBlank(mbl_to_date))
                {
                    to_date = Lib.ParseDateOnly(mbl_to_date!);
                    query = query.Where(w => w.mbl_ref_date <= to_date);
                }
                if (!Lib.IsBlank(mbl_agent_name))
                {
                    query = query.Where(w => w.agent!.cust_name == mbl_agent_name);
                }
                if (!Lib.IsBlank(mbl_mode))
                {
                    query = query.Where(w => w.mbl_mode == mbl_mode);
                }

                var totals = query.Select(s => new
                {
                    mbl_pcs = s.mbl_pcs ?? 0,
                    mbl_weight = s.mbl_weight ?? 0,
                    mbl_chwt = s.mbl_chwt ?? 0,
                });

                var totalRow = new rep_airvolume_dto
                {
                    mbl_agent_name = action == "PRINT" ? "GRAND TOTAL" : "TOTAL",
                    mbl_pcs = totals.Sum(x => x.mbl_pcs),
                    mbl_weight = totals.Sum(x => x.mbl_weight),
                    mbl_chwt = totals.Sum(x => x.mbl_chwt),
                };
                var totalTon = new rep_airvolume_dto
                {
                    mbl_agent_name = action == "PRINT" ? "GRAND TON" : "TOTAL/TON",
                    mbl_pcs = null,
                    mbl_weight = totals.Sum(x => x.mbl_weight)/1000m,
                    mbl_chwt = totals.Sum(x => x.mbl_chwt)/1000m,
                };
                List<rep_airvolume_dto> Records = new List<rep_airvolume_dto>();

                if (mbl_report_type == "DETAIL")
                {
                    if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                    {
                        _page.rows = query.Count(); // add 1 for total count
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

                        query = query
                            .Skip(StartRow)
                            .Take(_page.pageSize);
                    }

                    if (!isPrint)
                    {
                        Records = await query
                        .OrderBy(o => o.mbl_refno)
                        .Select(e => new rep_airvolume_dto
                        {
                            mbl_id = e.mbl_id,
                            mbl_refno = e.mbl_refno,
                            mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                            mbl_mode = e.mbl_mode,
                            mbl_agent_id = e.mbl_agent_id,
                            mbl_agent_name = e.agent!.cust_name,
                            mbl_liner_id = e.mbl_liner_id,
                            mbl_liner_name = e.liner!.param_name,
                            mbl_shipper_id = e.mbl_shipper_id,
                            mbl_shipper_name = e.shipper!.cust_name,
                            mbl_consignee_id = e.mbl_consignee_id,
                            mbl_consignee_name = e.consignee!.cust_name,
                            mbl_pcs = e.mbl_pcs,
                            mbl_weight = e.mbl_weight,
                            mbl_chwt = e.mbl_chwt,

                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        }).ToListAsync();
                    }
                    if (mbl_format == "AGENT" && isPrint)
                    {
                        var agentGroups = await query
                            .Include(c => c.agent).Include(c => c.liner)
                            .Include(c => c.shipper).Include(c => c.consignee)
                            .OrderBy(o => o.agent!.cust_name)
                            .GroupBy(g => new { g.mbl_agent_id, g.agent!.cust_name })
                            .ToListAsync();

                        foreach (var agentGroup in agentGroups)
                        {
                            var orderedGroup = agentGroup
                                .OrderBy(o => o.mbl_ref_date)
                                .ToList();

                            Records.Add(new rep_airvolume_dto
                            {
                                IsAgentTitle = true,
                                mbl_agent_name = agentGroup.Key.cust_name,
                                mbl_pcs = null,
                                mbl_weight = null,
                                mbl_chwt = null,
                            });

                            foreach (var e in orderedGroup)
                            {
                                Records.Add(new rep_airvolume_dto
                                {
                                    mbl_refno = e.mbl_refno,
                                    mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                                    mbl_agent_name = e.agent?.cust_name,
                                    mbl_liner_name = e.liner?.param_name,
                                    mbl_shipper_name = e.shipper?.cust_name,
                                    mbl_consignee_name = e.consignee?.cust_name,
                                    mbl_pcs = e.mbl_pcs ?? 0,
                                    mbl_weight = e.mbl_weight ?? 0,
                                    mbl_chwt = e.mbl_chwt ?? 0,
                                });
                            }

                            // single agent total
                            Records.Add(new rep_airvolume_dto
                            {
                                mbl_refno = "TOTAL",
                                mbl_pcs = agentGroup.Sum(x => x.mbl_pcs ?? 0),
                                mbl_weight = agentGroup.Sum(x => x.mbl_weight ?? 0),
                                mbl_chwt = agentGroup.Sum(x => x.mbl_chwt ?? 0),
                            });
                        }
                    }
                    if (mbl_format == "OPERATION GROUP" && isPrint)
                    {
                        var OpGroups = await query
                            .Include(c => c.agent).Include(c => c.liner)
                            .Include(c => c.shipper).Include(c => c.consignee)
                            .GroupBy(g => new { g.mbl_mode})
                            .ToListAsync();

                        foreach (var OpGroup in OpGroups)
                        {
                            var orderedGroup = OpGroup
                                .OrderBy(o => o.mbl_ref_date)
                                .ToList();
                            foreach (var e in orderedGroup)
                            {
                                Records.Add(new rep_airvolume_dto
                                {
                                    mbl_refno = e.mbl_refno,
                                    mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                                    mbl_agent_name = e.agent?.cust_name,
                                    mbl_liner_name = e.liner?.param_name,
                                    mbl_shipper_name = e.shipper?.cust_name,
                                    mbl_consignee_name = e.consignee?.cust_name,
                                    mbl_pcs = e.mbl_pcs ?? 0,
                                    mbl_weight = e.mbl_weight ?? 0,
                                    mbl_chwt = e.mbl_chwt ?? 0,
                                });
                            }

                            // single Group total
                            Records.Add(new rep_airvolume_dto
                            {
                                mbl_refno = "TOTAL",
                                mbl_pcs = OpGroup.Sum(x => x.mbl_pcs ?? 0),
                                mbl_weight = OpGroup.Sum(x => x.mbl_weight ?? 0),
                                mbl_chwt = OpGroup.Sum(x => x.mbl_chwt ?? 0),
                            });
                        }
                    }
                }
                if (mbl_report_type == "SUMMARY")
                {
                    if (mbl_format == "AGENT")
                    {
                        Records = await query
                        .GroupBy(g => new { g.mbl_agent_id, g.agent!.cust_name })
                        .Select(m => new rep_airvolume_dto
                        {
                            mbl_agent_id = m.Key.mbl_agent_id,
                            mbl_agent_name = m.Key.cust_name,
                            mbl_pcs = m.Sum(x => x.mbl_pcs ?? 0),
                            mbl_weight = m.Sum(x => x.mbl_weight ?? 0),
                            mbl_chwt = m.Sum(x => x.mbl_chwt ?? 0),
                        })
                        .OrderBy(o => o.mbl_agent_name)
                        .ToListAsync();
                    }

                    if (mbl_format == "OPERATION GROUP")
                    {
                        var OpSummary = await query
                        .Select(m => new rep_airvolume_dto
                        {
                            mbl_mode = m.mbl_mode,
                            mbl_pcs = m.mbl_pcs ?? 0,
                            mbl_weight = m.mbl_weight ?? 0,
                            mbl_chwt = m.mbl_chwt ?? 0,
                        }).ToListAsync();

                        var SummaryTotal = new rep_airvolume_dto
                        {
                            mbl_mode = OpSummary.FirstOrDefault()?.mbl_mode,
                            mbl_pcs = OpSummary.Sum(x => x.mbl_pcs),
                            mbl_weight = OpSummary.Sum(x => x.mbl_weight),
                            mbl_chwt = OpSummary.Sum(x => x.mbl_chwt),
                        };
                        Records.Add(SummaryTotal);
                    }

                    if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")///
                    {
                        _page.rows = Records.Count(); // add 1 for total count
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

                        Records = Records.Skip(StartRow).ToList();
                    }
                }

                if (_page.currentPageNo == _page.pages || (action == "PRINT" && Records.Count() != 0))
                {
                    Records.Add(totalRow);
                    Records.Add(totalTon);
                }

                RetData.Add("records", Records);

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
        public filesm ProcessPdfFileAsync(List<rep_airvolume_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Records error");

            AirVolumePdfFile bc = new AirVolumePdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
                ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
                Format = searchInfo.ContainsKey("mbl_format") ? searchInfo["mbl_format"] : "",
                ReportType = searchInfo.ContainsKey("mbl_report_type") ? searchInfo["mbl_report_type"] : "",
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
        public filesm ProcessExcelFileAsync(List<rep_airvolume_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            AirVolumeExcelFile bc = new AirVolumeExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                FromDate = searchInfo.ContainsKey("mbl_from_date") ? searchInfo["mbl_from_date"] : "",
                ToDate = searchInfo.ContainsKey("mbl_to_date") ? searchInfo["mbl_to_date"] : "",
                OpGroup = searchInfo.ContainsKey("mbl_mode") ? searchInfo["mbl_mode"] : "",
                Format = searchInfo.ContainsKey("mbl_format") ? searchInfo["mbl_format"] : "",
                ReportType = searchInfo.ContainsKey("mbl_report_type") ? searchInfo["mbl_report_type"] : "",
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