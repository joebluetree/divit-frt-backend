using Database;
using Database.Lib;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;

using Database.Models.BaseTables;
using Common.Lib;
using NPOI.SS.Formula.Functions;
using Database.Models.Cargo;
using NPOI.HSSF.Record;
using Common.DTO.OtherOp;
using Database.Models.Accounts;
using Common.DTO.CommonShipment;
using CommonShipment.Interfaces;
using CommonShipment.Printing;

//Name : Sourav V
//Created Date : 13/02/2026
//Remark : this file defines functions getList and getRecords of operations for Profit Master report/summary

namespace CommonShipment.Repositories
{
    public class ProfitReportRepository : IProfitReportRepository
    {
        private readonly AppDbContext context;

        public ProfitReportRepository(AppDbContext _context)
        {
            context = _context;
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
                var inv_report_type = "";
                var inv_unit_type = "";
                var rec_deleted = "";
                var parent_id = 0;
                var company_id = 0;
                var branch_id = 0;

                if (data.ContainsKey("inv_report_type"))
                    inv_report_type = data["inv_report_type"].ToString();
                if(inv_report_type == "HOUSE WISE")
                {
                    if (data.ContainsKey("inv_unit_type"))
                        inv_unit_type = data["inv_unit_type"].ToString();
                }
                if (data.ContainsKey("rec_deleted"))
                    rec_deleted = data["rec_deleted"].ToString();
                if (data.ContainsKey("parent_id"))
                    parent_id = int.Parse(data["parent_id"].ToString()!);

                company_id = Lib.GetValidIntValue(data!, "rec_company_id", "Company Id Not Found");
                branch_id = Lib.GetValidIntValue(data!, "rec_branch_id", "Branch Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);




                var fileDataList = new List<filesm>();

                var searchInfo = new Dictionary<string, string>
                {
                    {"inv_report_type",inv_report_type!},
                    {"inv_unit_type",inv_unit_type!},
                };

                var summary = await context.cargo_masterm
                    .Where(f => f.mbl_id == parent_id)
                    .Select(f => new cargo_profit_dto
                    {
                        inv_mbl_refno = f.mbl_refno,
                        inv_mbl_no = f.mbl_no,
                        inv_pol_name = f.pol!.param_name,
                        inv_pod_name = f.pod!.param_name,
                        inv_wt = f.mbl_weight,
                        inv_chwt = f.mbl_chwt,
                        inv_cbm = f.mbl_cbm,
                    }).ToListAsync();

                if(inv_report_type == "INVOICE WISE")
                {
                    IQueryable<acc_invoicem> query = context.acc_invoicem
                        .Include(c => c.house);

                    query = query.Where(w => w.rec_company_id == company_id);
                    query = query.Where(w => w.rec_branch_id == branch_id && w.inv_mbl_id == parent_id);

                    if (rec_deleted == "N")
                        query = query.Where(w => w.rec_deleted == "N");
                    if (rec_deleted == "Y")
                        query = query.Where(w => w.rec_deleted == "Y" || w.rec_deleted == "N");// for showing deleted records

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
                        .OrderBy(c => c.inv_no)
                        .Skip(StartRow)
                        .Take(_page.pageSize);

                    var Records = await query.Select(e => new cargo_profit_dto
                    {
                        inv_id = e.inv_id,
                        inv_date = Lib.FormatDate(e.inv_date, Lib.outputDateFormat),
                        inv_year = e.inv_year,
                        inv_no = e.inv_no,
                        inv_wt = e.house!.hbl_weight ?? 0,
                        inv_chwt = e.house!.hbl_chwt ?? 0,
                        inv_cbm = e.house!.hbl_cbm ?? 0,
                        inv_cust_id = e.inv_cust_id,
                        inv_cust_name = e.inv_cust_name,
                        inv_mbl_refno = e.inv_mbl_refno,
                        inv_houseno = e.inv_houseno,
                        inv_mbl_id = e.inv_mbl_id,
                        inv_hbl_id = e.inv_hbl_id,
                        inv_inc_total = e.inv_arap == "A/R" ? e.inv_total : null,
                        inv_exp_total = e.inv_arap == "A/P" ? e.inv_total : null,
                        inv_profit = null,
                        rec_deleted = e.rec_deleted,

                        rec_created_by = e.rec_created_by,
                        rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                        rec_edited_by = e.rec_edited_by,
                        rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                    }).ToListAsync();

                    var totals = query.Select(s => new cargo_profit_dto
                    {
                        inv_cust_name = "TOTAL",
                        inv_arap = s.inv_arap,
                        inv_inc_total = s.inv_arap == "A/R" ? s.inv_total : 0,
                        inv_exp_total = s.inv_arap == "A/P" ? s.inv_total : 0,
                    });

                    var totalRow = new cargo_profit_dto
                    {
                        inv_cust_name = "TOTAL",
                        inv_inc_total = totals.Sum(x => x.inv_inc_total) ?? 0,
                        inv_exp_total = totals.Sum(x => x.inv_exp_total) ?? 0,
                        inv_profit = totals.Sum(x => x.inv_inc_total) - totals.Sum(x => x.inv_exp_total) ?? 0,
                    };

                    var Profitper = new cargo_profit_dto
                    {
                        inv_cust_name = "PROFIT MARGIN %",
                        inv_profit = totalRow.inv_inc_total != 0 ? Math.Round(totalRow.inv_profit / totalRow.inv_inc_total* 100 ?? 0,3) : 0, // profit margin
                    };
                    
                    Records.Add(totalRow);
                    Records.Add(Profitper);

                    if (action == "PDF" || action == "PRINT")
                    {
                        var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, user_name!, branch_id, summary, searchInfo);
                        fileDataList.Add(pdfResult);
                    }
                    if (action == "EXCEL" || action == "PRINT")
                    {
                        var excelResult = ProcessExcelFileAsync(Records, title!, company_id, user_name!, branch_id, summary, searchInfo);
                        fileDataList.Add(excelResult);
                    }
                    
                    RetData.Add("records", Records);
                }

                if(inv_report_type == "HOUSE WISE")
                {
                    IQueryable<cargo_housem> query = context.cargo_housem
                        .Include(i => i.shipper)
                        .Include(i => i.master);

                    query = query.Where(w => w.rec_company_id == company_id);
                    query = query.Where(w => w.rec_branch_id == branch_id && w.hbl_mbl_id == parent_id);

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

                    var Records = await query.Select(e => new cargo_profit_dto
                    {
                        inv_id = e.hbl_id,
                        inv_date = Lib.FormatDate(e.master!.mbl_ref_date, Lib.outputDateFormat),
                        inv_no = e.hbl_houseno,
                        inv_wt = e.hbl_weight ?? 0,
                        inv_chwt = e.hbl_chwt ?? 0,
                        inv_cbm = e.hbl_cbm ?? 0,
                        inv_cust_id = e.hbl_shipper_id,
                        inv_cust_name = e.shipper!.cust_name,
                        inv_mbl_refno = e.master!.mbl_refno,
                        inv_houseno = e.hbl_houseno,
                        inv_mbl_id = e.hbl_mbl_id,
                        inv_hbl_id = e.hbl_id,
                        inv_inc_total = inv_unit_type == "CBM" ? e.hbl_inc_total_cbm : e.hbl_inc_total_wt,
                        inv_exp_total = inv_unit_type == "CBM" ? e.hbl_exp_total_cbm : e.hbl_exp_total_wt,
                        inv_profit = inv_unit_type == "CBM" ? e.hbl_revenue_cbm : e.hbl_revenue_wt,

                        rec_created_by = e.rec_created_by,
                        rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                        rec_edited_by = e.rec_edited_by,
                        rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                    }).ToListAsync();

                    var totals = query.Select(s => new cargo_profit_dto
                    {
                        inv_cust_name = "TOTAL",
                        inv_inc_total = inv_unit_type == "CBM" ? s.hbl_inc_total_cbm : s.hbl_inc_total_wt,
                        inv_exp_total = inv_unit_type == "CBM" ? s.hbl_exp_total_cbm : s.hbl_exp_total_wt,
                    });

                    var totalRow = new cargo_profit_dto
                    {
                        inv_cust_name = "TOTAL",
                        inv_inc_total = totals.Sum(x => x.inv_inc_total) ?? 0,
                        inv_exp_total = totals.Sum(x => x.inv_exp_total) ?? 0,
                        inv_profit = totals.Sum(x => x.inv_inc_total) - totals.Sum(x => x.inv_exp_total) ?? 0,
                    };

                    var Profitper = new cargo_profit_dto
                    {
                        inv_cust_name = "PROFIT MARGIN %",
                        inv_profit = totalRow.inv_inc_total != 0 ? Math.Round(totalRow.inv_profit / totalRow.inv_inc_total* 100 ?? 0,3) : 0, // profit margin
                    };
                    
                    Records.Add(totalRow);
                    Records.Add(Profitper);
                    
                    if (action == "PDF" || action == "PRINT")
                    {
                        var pdfResult = ProcessPdfFileAsync(Records, title!, company_id, user_name!, branch_id, summary, searchInfo);
                        fileDataList.Add(pdfResult);
                    }
                    if (action == "EXCEL" || action == "PRINT")
                    {
                        var excelResult = ProcessExcelFileAsync(Records, title!, company_id, user_name!, branch_id, summary, searchInfo);
                        fileDataList.Add(excelResult);
                    }
                    
                    RetData.Add("records", Records);
                }

                RetData.Add("summary", summary!);
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
        
        public filesm ProcessPdfFileAsync(List<cargo_profit_dto> Records, string title, int company_id, string user_name, int branch_id, List<cargo_profit_dto>summary, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Records error");
            var header = summary.FirstOrDefault();

            ProfitReportPdfFile bc = new ProfitReportPdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                Name = title,
                User_name = user_name,
                
                InvMblNo = header!.inv_mbl_no ?? "",
                InvRefno = header.inv_mbl_refno ?? "",
                POL = header.inv_pol_name ?? "",
                POD = header.inv_pod_name ?? "",
                WT = header.inv_wt ?? 0,
                CHWT = header.inv_chwt ?? 0,
                CBM = header.inv_cbm ?? 0,
                ReportType = searchInfo.ContainsKey("inv_report_type") ? searchInfo["inv_report_type"] : "",
                UnitType = searchInfo.ContainsKey("inv_unit_type") ? searchInfo["inv_unit_type"] : "",


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
        public filesm ProcessExcelFileAsync(List<cargo_profit_dto> Records, string title, int company_id, string user_name, int branch_id, List<cargo_profit_dto>summary, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");
            var header = summary.FirstOrDefault();

            ProfitReportExcelFile bc = new ProfitReportExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = title,
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                Name = title,
                User_name = user_name,
                
                InvMblNo = header!.inv_mbl_no ?? "",
                InvRefno = header.inv_mbl_refno ?? "",
                POL = header.inv_pol_name ?? "",
                POD = header.inv_pod_name ?? "",
                WT = header.inv_wt ?? 0,
                CHWT = header.inv_chwt ?? 0,
                CBM = header.inv_cbm ?? 0,
                ReportType = searchInfo.ContainsKey("inv_report_type") ? searchInfo["inv_report_type"] : "",
                UnitType = searchInfo.ContainsKey("inv_unit_type") ? searchInfo["inv_unit_type"] : "",
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
