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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NPOI.SS.Formula.Functions;
using NPOI.HSSF.Record;

//Name : Sourav V
//Created Date : 01/06/2026
//Remark : this file defines functions getList and getRecords of operations for Data Entry Statistics


namespace Report.Repositories
{
    public class DataEntryStatRepository : IDataEntryStatRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public DataEntryStatRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var mbl_category = "";
                var mbl_mode = "";
                var rec_created_by = "";
                var mbl_isdetail = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;
                DateTime? from_dateTime = null;
                DateTime? to_dateTime = null;

                if (data.ContainsKey("mbl_from_date"))
                    mbl_from_date = data["mbl_from_date"].ToString();
                if (data.ContainsKey("mbl_to_date"))
                    mbl_to_date = data["mbl_to_date"].ToString();
                if (data.ContainsKey("mbl_category"))
                    mbl_category = data["mbl_category"].ToString();
                if (data.ContainsKey("mbl_mode"))
                    mbl_mode = data["mbl_mode"].ToString();
                if (data.ContainsKey("rec_created_by"))
                    rec_created_by = data["rec_created_by"].ToString();
                if (data.ContainsKey("mbl_isdetail"))
                    mbl_isdetail = data["mbl_isdetail"].ToString();

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
                    {"mbl_category", mbl_category!},
                    {"mbl_mode", mbl_mode!},
                    {"rec_created_by", rec_created_by!},
                    {"mbl_isdetail", mbl_isdetail!},
                };

                IQueryable<cargo_masterm> query = context.cargo_masterm;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);

                if (!Lib.IsBlank(mbl_from_date))
                {
                    if (mbl_category == "SHIPMENT")
                    {
                        from_date = Lib.ParseDateOnly(mbl_from_date!);
                        query = query.Where(w => w.mbl_ref_date >= from_date);
                    }
                    if (mbl_category == "AR/AP")
                    {
                        from_dateTime = Lib.ParseDate(mbl_from_date!);
                        query = query.Where(w => w.mbl_bo_attended_date >= from_dateTime);
                    }
                }
                if (!Lib.IsBlank(mbl_to_date))
                {
                    if (mbl_category == "SHIPMENT")
                    {
                        to_date = Lib.ParseDateOnly(mbl_to_date!);
                        query = query.Where(w => w.mbl_ref_date <= to_date);
                    }
                    if (mbl_category == "AR/AP")
                    {
                        to_dateTime = Lib.ParseDate(mbl_to_date!);
                        query = query.Where(w => w.mbl_bo_attended_date <= to_dateTime);
                    }
                }
                if (!Lib.IsBlank(rec_created_by))
                {
                    query = query.Where(w => w.rec_created_by == rec_created_by);
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
                if (mbl_category == "AR/AP")
                {
                    query = query.Where(w => w.mbl_bo_attended_date != null && w.mbl_bo_attended_code != "ADMIN");
                }

                List<rep_dataentrystat_dto> Records = new List<rep_dataentrystat_dto>();

                if (mbl_category == "SHIPMENT" || mbl_category == "AR/AP")
                {
                    var refGroups = await query
                            .Include(c => c.agent)
                            .Include(c => c.liner)
                            .Include(c => c.shipper)
                            .Include(c => c.consignee)
                            .Include(c => c.handledby)
                            .GroupBy(g => new { g.mbl_mode, g.rec_created_by })
                            .ToListAsync();

                    foreach (var refGroup in refGroups)
                    {
                        var orderedGroup = refGroup
                            .OrderBy(o => o.rec_created_by)
                            .ToList();

                        var groupRecords = orderedGroup.Select(e => new rep_dataentrystat_dto
                        {
                            mbl_id = e.mbl_id,
                            mbl_refno = e.mbl_refno,
                            mbl_category = mbl_category,
                            mbl_mode = e.mbl_mode,
                            mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                            mbl_no = e.mbl_no,
                            mbl_house_nos = e.mbl_house_nos,
                            mbl_agent_name = e.agent?.cust_name,
                            mbl_handled_name = e.handledby?.param_name,
                            mbl_date = mbl_category == "SHIPMENT" ? Lib.FormatDate(e.rec_created_date, Lib.outputDateFormat) : Lib.FormatDate(e.mbl_bo_attended_date, Lib.outputDateFormat),

                            rec_created_by = e.rec_created_by,
                        }).ToList();

                        if(mbl_isdetail == "Y")
                        {
                            Records.AddRange(groupRecords);
                        }
                        if(mbl_isdetail == "N")
                        {
                            Records.Add(new rep_dataentrystat_dto
                            {
                                mbl_category = mbl_category,
                                mbl_mode = refGroup.Key.mbl_mode,
                                rec_created_by = refGroup.Key.rec_created_by,
                                mbl_count = refGroup.Count(),
                                mbl_hbl_count = refGroup.Sum(x => x.mbl_house_tot)
                            });
                        }
                            
                    }
                    if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                    {
                        _page.rows = Records.Count(); // add 1 for total count if needed
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
                    // Records.AddRange(Records);
                }
                if (mbl_category == "AN SENT")
                {
                    from_date = Lib.ParseDateOnly(mbl_from_date!);
                    to_date = Lib.ParseDateOnly(mbl_to_date!);

                    query = query.OrderBy(o => o.mbl_mode).ThenBy(o => o.rec_created_by);

                    var data_ = from m in query
                    join h in context.cargo_housem
                        on m.mbl_id equals h.hbl_mbl_id into houseGroup

                    from h in houseGroup
                    where
                        (Lib.IsBlank(mbl_from_date) || h.hbl_an_sent_date >= from_date) &&
                        (Lib.IsBlank(mbl_to_date) || h.hbl_an_sent_date <= to_date)
                    where h.hbl_an_sent == "Y"
                    select new rep_dataentrystat_dto
                    {
                        mbl_id = m.mbl_id,
                        mbl_refno = m.mbl_refno,
                        mbl_category = mbl_category,
                        mbl_ref_date = Lib.FormatDate(m.mbl_ref_date, Lib.outputDateFormat),
                        mbl_mode = m.mbl_mode,
                        mbl_no = m.mbl_no,
                        mbl_house_nos = m.mbl_house_nos,
                        mbl_hbl_id = h.hbl_id,
                        mbl_agent_name = m.agent!.cust_name,
                        mbl_shipper_name = h.shipper!.cust_name,
                        mbl_consignee_name = h.consignee!.cust_name,
                        mbl_handled_name = h.handledby!.param_name,

                        rec_created_by = h != null ? h.rec_created_by : m.rec_created_by,
                        mbl_date = Lib.FormatDate(h.hbl_an_sent_date, Lib.outputDateFormat),
                    };

                    var list = await data_.ToListAsync();
                    if(mbl_isdetail == "Y")
                    {
                        Records.AddRange(list);   
                    }
                    if(mbl_isdetail == "N")
                    {
                        var summaryList = list
                            .GroupBy(g => new {g.rec_created_by, g.mbl_mode })
                            .Select(g => new rep_dataentrystat_dto
                            {
                                mbl_category = mbl_category,
                                mbl_mode = g.Key.mbl_mode,
                                rec_created_by = g.Key.rec_created_by,
                                mbl_count = g.Count(),
                                mbl_hbl_count = g.Sum(x => x.mbl_house_count)
                            })
                            .ToList();
                        Records.AddRange(summaryList);   
                    }

                    if (action == "SEARCH" || action == "PRINT" || action == "EXCEL" || action == "PDF")
                    {
                        _page.rows = Records.Count(); // add 1 for total count if needed
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
        public filesm ProcessPdfFileAsync(List<rep_dataentrystat_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Not Found");

            var record = new filesm();
            if(searchInfo["mbl_isdetail"] == "Y")
            {
                DataEntryStatDPdfFile bc = new DataEntryStatDPdfFile
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
                    Category = searchInfo.ContainsKey("mbl_category") ? searchInfo["mbl_category"] : "",
                    CreatedBy = searchInfo.ContainsKey("rec_created_by") ? searchInfo["rec_created_by"] : "",
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
            if(searchInfo["mbl_isdetail"] == "N")   // summary
            {
                DataEntryStatSPdfFile bc = new DataEntryStatSPdfFile
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
                    Category = searchInfo.ContainsKey("mbl_category") ? searchInfo["mbl_category"] : "",
                    CreatedBy = searchInfo.ContainsKey("rec_created_by") ? searchInfo["rec_created_by"] : "",
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
        public filesm ProcessExcelFileAsync(List<rep_dataentrystat_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            var record = new filesm();
            if(searchInfo["mbl_isdetail"] == "Y")
            {
                DataEntryStatDExcelFile bc = new DataEntryStatDExcelFile
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
                    Category = searchInfo.ContainsKey("mbl_category") ? searchInfo["mbl_category"] : "",
                    CreatedBy = searchInfo.ContainsKey("rec_created_by") ? searchInfo["rec_created_by"] : "",
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
            if(searchInfo["mbl_isdetail"] == "N")
            {
                DataEntryStatSExcelFile bc = new DataEntryStatSExcelFile
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
                    Category = searchInfo.ContainsKey("mbl_category") ? searchInfo["mbl_category"] : "",
                    CreatedBy = searchInfo.ContainsKey("rec_created_by") ? searchInfo["rec_created_by"] : "",
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
    // foreach (var e in orderedGroup)
                        // {
                        //     Records.Add(new rep_dataentrystat_dto
                        //     {
                        //         mbl_refno = e.mbl_refno,
                        //         mbl_no = e.mbl_no,
                        //         mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                        //         mbl_house_tot = e.mbl_house_tot,
                        //         mbl_agent_name = e.agent?.cust_name,
                        //         mbl_liner_name = e.liner?.param_name,
                        //         mbl_shipper_name = e.shipper?.cust_name,
                        //         mbl_consignee_name = e.consignee?.cust_name,
                        //         mbl_handled_name = e.handledby?.param_name,
                        //         mbl_inc_total = e.mbl_inc_total,
                        //         mbl_exp_total = e.mbl_exp_total,
                        //         mbl_revenue = e.mbl_revenue,
                        //         mbl_profit = e.mbl_revenue ?? 0,
                        //         mbl_cntr_type = e.mbl_cntr_type,
                        //         mbl_20 = e.mbl_20 ?? 0,
                        //         mbl_40 = e.mbl_40 ?? 0,
                        //         mbl_40hq = e.mbl_40hq ?? 0,
                        //         mbl_45 = e.mbl_45 ?? 0,
                        //         mbl_teu = e.mbl_teu ?? 0,
                        //         mbl_cbm = e.mbl_cbm ?? 0,
                        //         mbl_weight = e.mbl_weight ?? 0,
                        //     });
                        // }
                                                    // var summaryList = groupRecords
                            // .GroupBy(g => new {g.rec_created_by, g.mbl_mode })
                            // .Select(g => new rep_dataentrystat_dto
                            // {
                            //     mbl_category = mbl_category,
                            //     mbl_mode = g.Key.mbl_mode,
                            //     rec_created_by = g.Key.rec_created_by,
                            //     mbl_count = g.Count()
                            // })
                            // .ToList();
                            // Records.AddRange(summaryList);