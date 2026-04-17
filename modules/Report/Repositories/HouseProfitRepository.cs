using Database;
using Database.Lib;

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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

//Name : Sourav V
//Created Date : 05/03/2026
//Remark : this file defines functions getList and getRecords of operations for Shipment House Profit report/summary


namespace Report.Repositories
{
    public class HouseProfitRepository : IHouseProfitRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public HouseProfitRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var mbl_shipper_name = "";
                var mbl_consignee_name = "";
                var mbl_salesman_name = "";
                var mbl_handled_name = "";
                var mbl_parent_name = "";
                var mbl_client_type = "";

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
                if (data.ContainsKey("mbl_shipper_name"))
                    mbl_shipper_name = data["mbl_shipper_name"].ToString();
                if (data.ContainsKey("mbl_consignee_name"))
                    mbl_consignee_name = data["mbl_consignee_name"].ToString();

                if (data.ContainsKey("mbl_salesman_name"))
                    mbl_salesman_name = data["mbl_salesman_name"].ToString();
                if (data.ContainsKey("mbl_handled_name"))
                    mbl_handled_name = data["mbl_handled_name"].ToString();
                if (data.ContainsKey("mbl_parent_name"))
                    mbl_parent_name = data["mbl_parent_name"].ToString();
                if (data.ContainsKey("mbl_client_type"))
                    mbl_client_type = data["mbl_client_type"].ToString();

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
                    {"mbl_salesman_name", mbl_salesman_name!},
                    {"mbl_handled_name", mbl_handled_name!},
                    {"mbl_agent_name", mbl_agent_name!},
                    {"mbl_shipper_name", mbl_shipper_name!},
                    {"mbl_consignee_name", mbl_consignee_name!},
                    {"mbl_parent_name", mbl_parent_name!},
                    {"mbl_client_type", mbl_client_type!},
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
                if (!Lib.IsBlank(mbl_salesman_name))
                {
                    query = query.Where(w => w.salesman!.param_name == mbl_salesman_name);
                }
                if (!Lib.IsBlank(mbl_agent_name) && mbl_format == "AGENT")
                {
                    query = query.Where(w => w.agent!.cust_name == mbl_agent_name);
                }
                if (!Lib.IsBlank(mbl_shipper_name) && mbl_format == "SHIPPER")
                {
                    query = query.Where(w => w.shipper!.cust_name == mbl_shipper_name);
                }
                if (!Lib.IsBlank(mbl_consignee_name) && (mbl_format == "CONSIGNEE"|| mbl_format == "NOMINATION" || mbl_format == "CLIENT TYPE"))
                {
                    query = query.Where(w => w.consignee!.cust_name == mbl_consignee_name);
                }
                if (!Lib.IsBlank(mbl_handled_name) && mbl_format == "HANDLED-BY")
                {
                    query = query.Where(w => w.handledby!.param_name == mbl_handled_name);
                }
                if (!Lib.IsBlank(mbl_parent_name))
                {
                    query = query.Where(w => w.agent!.customer!.cust_name == mbl_parent_name);
                }
                if (!Lib.IsBlank(mbl_client_type) && mbl_client_type != "ALL")
                {
                    var types = mbl_client_type!.Split(',');
                    query = query.Where(w => types.Contains(w.agent!.cust_nomination));
                }
                if (!Lib.IsBlank(mbl_mode))
                {
                    if (mbl_mode == "ALL")
                    {
                        var Types = new[] { "SEA IMPORT", "SEA EXPORT", "AIR IMPORT", "AIR EXPORT", "OTHERS" };
                        query = query.Where(w => Types.Contains(w.mbl_mode));
                    }
                    else
                    {
                        query = query.Where(w => w.mbl_mode == mbl_mode);
                    }
                }

                List<rep_houseprofit_dto> Records = new List<rep_houseprofit_dto>();

                query = query.OrderBy(o => o.mbl_refno);


                var data_ =
                from m in query
                join h in context.cargo_housem
                    on m.mbl_id equals h.hbl_mbl_id into houseGroup

                from h in houseGroup.DefaultIfEmpty()
                orderby m.mbl_refno
                select new rep_houseprofit_dto
                {
                    mbl_id = m.mbl_id,
                    mbl_refno = m.mbl_refno,
                    mbl_ref_date = Lib.FormatDate(m.mbl_ref_date, Lib.outputDateFormat),
                    mbl_mode = m.mbl_mode,
                    mbl_no = m.mbl_no,
                    mbl_houseno = h.hbl_houseno,
                    mbl_hbl_id = h.hbl_id,
                    mbl_agent_name = m.agent!.cust_name,
                    mbl_shipper_name = h.shipper!.cust_name,
                    mbl_consignee_name = h.consignee!.cust_name,
                    mbl_bltype = h.hbl_bltype,
                    mbl_agent_bltype = m.agent.cust_nomination,
                    mbl_handled_name = h.handledby!.param_name,
                    mbl_house_count = h != null ? 1 : 0,
                    mbl_house_tot = m.mbl_house_tot,
                    mbl_inc_total = h != null ? h.hbl_inc_total_wt : m.mbl_inc_total,
                    mbl_exp_total = h != null ? h.hbl_exp_total_wt : m.mbl_exp_total,
                    mbl_revenue = h != null ? h.hbl_revenue_wt : m.mbl_revenue,

                    mbl_cntr_type = m.mbl_cntr_type,
                    mbl_20 = m.mbl_20,
                    mbl_40 = m.mbl_40,
                    mbl_40hq = m.mbl_40hq,
                    mbl_45 = m.mbl_45,
                    mbl_teu = m.mbl_teu,
                    mbl_cbm = h != null ? h.hbl_cbm : m.mbl_cbm,
                    mbl_weight = h != null ? h.hbl_weight : m.mbl_weight,

                    rec_created_by = h != null ? h.rec_created_by : m.rec_created_by,
                    rec_created_date = h != null ? Lib.FormatDate(h.rec_created_date, Lib.outputDateTimeFormat) : Lib.FormatDate(m.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = h != null ? h.rec_edited_by : m.rec_edited_by,
                    rec_edited_date = h != null ? Lib.FormatDate(h.rec_edited_date, Lib.outputDateTimeFormat) : Lib.FormatDate(m.rec_edited_date, Lib.outputDateTimeFormat),
                };

                var list = await data_.ToListAsync();

                var totals = list.Select(s => new
                {
                    mbl_id = s.mbl_id,
                    // mbl_house_count = list.
                    mbl_inc_total = s.mbl_inc_total ?? 0,
                    mbl_exp_total = s.mbl_exp_total ?? 0,
                    mbl_revenue = s.mbl_inc_total - s.mbl_exp_total ?? 0,
                    mbl_pcs = s.mbl_pcs ?? 0,
                    mbl_20 = s.mbl_20 ?? 0,
                    mbl_40 = s.mbl_40 ?? 0,
                    mbl_40hq = s.mbl_40hq ?? 0,
                    mbl_45 = s.mbl_45 ?? 0,
                    mbl_teu = s.mbl_teu ?? 0,
                    mbl_cbm = s.mbl_cbm ?? 0,
                    mbl_weight = s.mbl_weight ?? 0,
                });

                var totalExpense = totals.Sum(x => x.mbl_exp_total);
                var totalProfit = totals.Sum(x => x.mbl_revenue);

                var totalRow = new rep_houseprofit_dto
                {
                    mbl_mode = "GRAND TOTAL",
                    mbl_refno = action == "PRINT" ? "GRAND TOTAL" : "",
                    mbl_agent_name = mbl_report_type == "SUMMARY" ? "TOTAL" : "",
                    mbl_shipper_name = mbl_report_type == "SUMMARY" ? "TOTAL" : "",
                    mbl_consignee_name = mbl_report_type == "SUMMARY" ? "TOTAL" : "",
                    mbl_handled_name = mbl_report_type == "SUMMARY" ? "TOTAL" : "",
                    mbl_bltype = mbl_report_type == "SUMMARY" ? "TOTAL" : "",
                    mbl_agent_bltype = mbl_report_type == "SUMMARY" ? "TOTAL" : "",
                    mbl_ref_count = list.Select(x => x.mbl_refno).Distinct().Count(),
                    mbl_house_count = list.Sum(x => x.mbl_house_count),
                    mbl_inc_total = totals.Sum(x => x.mbl_inc_total),
                    mbl_exp_total = totalExpense,
                    mbl_revenue = totalProfit,
                    mbl_profit_per = !Lib.IsZero(totalExpense) ? Math.Round((totalProfit / totalExpense) * 100, 3) : 0, // profit %
                    mbl_pcs = totals.Sum(x => x.mbl_pcs),
                    mbl_20 = totals.Sum(x => x.mbl_20),
                    mbl_40 = totals.Sum(x => x.mbl_40),
                    mbl_40hq = totals.Sum(x => x.mbl_40hq),
                    mbl_45 = totals.Sum(x => x.mbl_45),
                    mbl_teu = totals.Sum(x => x.mbl_teu),
                    mbl_cbm = totals.Sum(x => x.mbl_cbm),
                    mbl_weight = totals.Sum(x => x.mbl_weight),
                };

                Func<rep_houseprofit_dto, string> groupSelector = x => "";
                if (mbl_report_type == "DETAIL")
                {

                    if (mbl_format == "SHIPPER")
                        groupSelector = x => x.mbl_shipper_name!;
                    if (mbl_format == "CONSIGNEE")
                        groupSelector = x => x.mbl_consignee_name!;
                    if (mbl_format == "AGENT")
                        groupSelector = x => x.mbl_agent_name!;
                    if (mbl_format == "HANDLED-BY")
                        groupSelector = x => x.mbl_handled_name!;
                    if (mbl_format == "NOMINATION")//CLIENT TYPE (HOUSE)
                        groupSelector = x => x.mbl_bltype!;
                    if (mbl_format == "CLIENT TYPE")//CLIENT TYPE (ADDRESS BOOK)
                        groupSelector = x => x.mbl_agent_bltype!;

                    List<rep_houseprofit_dto> groupRecords = new List<rep_houseprofit_dto>();

                    var formatGroups = list.GroupBy(groupSelector);

                    foreach (var formatGroup in formatGroups)
                    {
                        IEnumerable<IGrouping<string, rep_houseprofit_dto>> modeGroups;

                        if (mbl_mode == "ALL")
                        {
                            modeGroups = formatGroup.GroupBy(x => x.mbl_mode)!;
                        }
                        else
                        {
                            modeGroups = formatGroup.GroupBy(x => mbl_mode)!;
                        }

                        foreach (var mode in modeGroups)
                        {
                            groupRecords.AddRange(mode);

                            var subtotal = new rep_houseprofit_dto
                            {
                                mbl_refno = action == "PRINT" ? "SUB TOTAL" : "",
                                mbl_mode = "SUB TOTAL",

                                mbl_inc_total = mode.Sum(x => x.mbl_inc_total),
                                mbl_exp_total = mode.Sum(x => x.mbl_exp_total),
                                mbl_revenue = mode.Sum(x => x.mbl_revenue),
                                mbl_20 = mode.Sum(x => x.mbl_20),
                                mbl_40 = mode.Sum(x => x.mbl_40),
                                mbl_40hq = mode.Sum(x => x.mbl_40hq),
                                mbl_45 = mode.Sum(x => x.mbl_45),
                                mbl_teu = mode.Sum(x => x.mbl_teu),
                                mbl_cbm = mode.Sum(x => x.mbl_cbm),
                                mbl_weight = mode.Sum(x => x.mbl_weight),
                            };

                            groupRecords.Add(subtotal);
                        }

                        var total = new rep_houseprofit_dto
                        {
                            mbl_refno = action == "PRINT" ? "TOTAL" : "",
                            mbl_mode = "TOTAL",
                            mbl_inc_total = formatGroup.Sum(x => x.mbl_inc_total),
                            mbl_exp_total = formatGroup.Sum(x => x.mbl_exp_total),
                            mbl_revenue = formatGroup.Sum(x => x.mbl_revenue),
                            mbl_20 = formatGroup.Sum(x => x.mbl_20),
                            mbl_40 = formatGroup.Sum(x => x.mbl_40),
                            mbl_40hq = formatGroup.Sum(x => x.mbl_40hq),
                            mbl_45 = formatGroup.Sum(x => x.mbl_45),
                            mbl_teu = formatGroup.Sum(x => x.mbl_teu),
                            mbl_cbm = formatGroup.Sum(x => x.mbl_cbm),
                            mbl_weight = formatGroup.Sum(x => x.mbl_weight),
                        };

                        groupRecords.Add(total);
                    }

                    if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                    {
                        _page.rows = groupRecords.Count(); // add 1 for total count if needed
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

                        groupRecords = groupRecords.Skip(StartRow).Take(_page.pageSize).ToList();
                    }
                    Records.AddRange(groupRecords);
                }
                if (mbl_report_type == "SUMMARY")
                {

                    if (mbl_format == "SHIPPER")
                        groupSelector = x => x.mbl_shipper_name!;
                    if (mbl_format == "CONSIGNEE")
                        groupSelector = x => x.mbl_consignee_name!;
                    if (mbl_format == "AGENT")
                        groupSelector = x => x.mbl_agent_name!;
                    if (mbl_format == "HANDLED-BY")
                        groupSelector = x => x.mbl_handled_name!;
                    if (mbl_format == "NOMINATION")//CLIENT TYPE (HOUSE)
                        groupSelector = x => x.mbl_bltype!;
                    if (mbl_format == "CLIENT TYPE")//CLIENT TYPE (ADDRESS BOOK)
                        groupSelector = x => x.mbl_agent_bltype!;


                    var grouped = list.GroupBy(groupSelector);

                    List<rep_houseprofit_dto> summaryRecords = new();

                    foreach (var grp in grouped)
                    {
                        summaryRecords.Add(new rep_houseprofit_dto
                        {
                            mbl_agent_name = grp.Key,
                            mbl_shipper_name = grp.Key,
                            mbl_consignee_name = grp.Key,
                            mbl_handled_name = grp.Key,
                            mbl_bltype = grp.Key,
                            mbl_agent_bltype = grp.Key,

                            mbl_ref_count = grp.Select(x => x.mbl_refno).Distinct().Count(),
                            mbl_house_count = grp.Sum(x => x.mbl_house_count),

                            mbl_inc_total = grp.Sum(x => x.mbl_inc_total),
                            mbl_exp_total = grp.Sum(x => x.mbl_exp_total),
                            mbl_revenue = grp.Sum(x => x.mbl_revenue),

                            mbl_teu = grp.Sum(x => x.mbl_teu),
                            mbl_cbm = grp.Sum(x => x.mbl_cbm),
                            mbl_weight = grp.Sum(x => x.mbl_weight)
                        });
                    }

                    summaryRecords = summaryRecords.OrderBy(groupSelector).ToList();

                    if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                    {
                        _page.rows = summaryRecords.Count(); // add 1 for total count if needed
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

                        summaryRecords = summaryRecords.Skip(StartRow).Take(_page.pageSize).ToList();
                    }
                    Records.AddRange(summaryRecords);
                }

                if (_page.currentPageNo == _page.pages || (action == "PRINT" && Records.Count() != 0))
                    Records.Add(totalRow);

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
        public filesm ProcessPdfFileAsync(List<rep_houseprofit_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Not Found");

            var record = new filesm();
            if(searchInfo["mbl_report_type"] == "DETAIL")
            {
                HouseProfitDetPdfFile bc = new HouseProfitDetPdfFile
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
                    Salesman = searchInfo.ContainsKey("mbl_salesman_name") ? searchInfo["mbl_salesman_name"] : "",
                    Parent = searchInfo.ContainsKey("mbl_parent_name") ? searchInfo["mbl_parent_name"] : "",
                    Agent = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
                    Shipper = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
                    Consignee = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
                    HandledBY = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
                    Client_Type = searchInfo.ContainsKey("mbl_client_type") ? searchInfo["mbl_client_type"] : "",
                };
                bc.Process();
                if (bc.FList == null || !bc.FList.Any())
                throw new Exception("File generation failed.");

                var file = bc.FList[0];

                record = new filesm
                {
                    filepath = file.filename!,
                    filename = file.filedisplayname!,
                    filetype = file.filetype!
                };
            }
            if(searchInfo["mbl_report_type"] == "SUMMARY")
            {
                HouseProfitSummaryPdfFile bc = new HouseProfitSummaryPdfFile
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
                    Salesman = searchInfo.ContainsKey("mbl_salesman_name") ? searchInfo["mbl_salesman_name"] : "",
                    Parent = searchInfo.ContainsKey("mbl_parent_name") ? searchInfo["mbl_parent_name"] : "",
                    Agent = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
                    Shipper = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
                    Consignee = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
                    HandledBY = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
                    Client_Type = searchInfo.ContainsKey("mbl_client_type") ? searchInfo["mbl_client_type"] : "",
                };
                bc.Process();
                if (bc.FList == null || !bc.FList.Any())
                throw new Exception("File generation failed.");

                var file = bc.FList[0];

                record = new filesm
                {
                    filepath = file.filename!,
                    filename = file.filedisplayname!,
                    filetype = file.filetype!
                };
            }
            return record;
        }
        public filesm ProcessExcelFileAsync(List<rep_houseprofit_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            var record = new filesm();
            if(searchInfo["mbl_report_type"] == "DETAIL")
            {
                HouseProfitDetExcelFile bc = new HouseProfitDetExcelFile
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
                    Salesman = searchInfo.ContainsKey("mbl_salesman_name") ? searchInfo["mbl_salesman_name"] : "",
                    Parent = searchInfo.ContainsKey("mbl_parent_name") ? searchInfo["mbl_parent_name"] : "",
                    Agent = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
                    Shipper = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
                    Consignee = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
                    HandledBY = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
                    Client_Type = searchInfo.ContainsKey("mbl_client_type") ? searchInfo["mbl_client_type"] : "",
                };
                bc.Process();

                if (bc.fList == null || !bc.fList.Any())
                    throw new Exception("Excel generation failed.");

                var file = bc.fList[0];

                record = new filesm
                {
                    filepath = file.filename!,
                    filename = file.filedisplayname!,
                    filetype = file.filetype!
                };
            }
            if(searchInfo["mbl_report_type"] == "SUMMARY")
            {
                    HouseProfitSummaryExcelFile bc = new HouseProfitSummaryExcelFile
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
                    Salesman = searchInfo.ContainsKey("mbl_salesman_name") ? searchInfo["mbl_salesman_name"] : "",
                    Parent = searchInfo.ContainsKey("mbl_parent_name") ? searchInfo["mbl_parent_name"] : "",
                    Agent = searchInfo.ContainsKey("mbl_agent_name") ? searchInfo["mbl_agent_name"] : "",
                    Shipper = searchInfo.ContainsKey("mbl_shipper_name") ? searchInfo["mbl_shipper_name"] : "",
                    Consignee = searchInfo.ContainsKey("mbl_consignee_name") ? searchInfo["mbl_consignee_name"] : "",
                    HandledBY = searchInfo.ContainsKey("mbl_handled_name") ? searchInfo["mbl_handled_name"] : "",
                    Client_Type = searchInfo.ContainsKey("mbl_client_type") ? searchInfo["mbl_client_type"] : "",
                };
                bc.Process();

                if (bc.fList == null || !bc.fList.Any())
                    throw new Exception("Excel generation failed.");

                var file = bc.fList[0];

                record = new filesm
                {
                    filepath = file.filename!,
                    filename = file.filedisplayname!,
                    filetype = file.filetype!
                };
            }
            return record;
        }
    }
}