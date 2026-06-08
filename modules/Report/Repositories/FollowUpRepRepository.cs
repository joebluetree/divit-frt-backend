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
using System.ComponentModel.DataAnnotations;
using Report.Printing;
using Database.Models.CommonShipment;

//Name : Sourav V
//Created Date : 25/05/2026
//Remark : this file defines functions getList of operations for follow up report

namespace Report.Repositories
{
    public class FollowUpRepRepository : IFollowUpRepRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public FollowUpRepRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var cf_mode = "";

                var company_id = 0;
                var branch_id = 0;

                if (data.ContainsKey("cf_mode"))
                    cf_mode = data["cf_mode"].ToString();

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
                    {"cf_mode", cf_mode!},
                };

                IQueryable<cargo_followup> query = context.cargo_followup
                    .Include(i => i.master)
                    .Include(i => i.user)
                    .Include(i => i.assigned);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.assigned!.user_name == user_name);

                if (!Lib.IsBlank(cf_mode) && cf_mode != "ALL")
                {
                    query = query.Where(w => w.master!.mbl_mode == cf_mode);
                }

                query = query.OrderBy(o => o.cf_followup_date);

                var Records = await query.Select(e => new rep_followup_dto
                {
                    cf_id = e.cf_id,
                    cf_mbl_id = e.cf_mbl_id,
                    cf_mbl_refno = e.master!.mbl_refno,
                    cf_mode = e.cf_mode,
                    cf_assigned_id = e.cf_assigned_id,
                    cf_assigned_name = e.assigned!.user_name,
                    cf_followup_date = Lib.FormatDate(e.cf_followup_date, Lib.outputDateFormat),
                    cf_remarks = e.cf_remarks,

                    rec_locked = e.rec_locked,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).ToListAsync();
                // Records.AddRange(HRecords);

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
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_followup
                    .Where(f => f.cf_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    context.Remove(_Record);
                    await context.SaveChangesAsync();

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
        public filesm ProcessPdfFileAsync(List<rep_followup_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Print List Not Found");

            FollowUpPdfFile bc = new FollowUpPdfFile
            {
                Dt_List = Dt_List,
                Report_Folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = "Follow Up List",
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                OpGroup = searchInfo.ContainsKey("cf_mode") ? searchInfo["cf_mode"] : "",
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
        public filesm ProcessExcelFileAsync(List<rep_followup_dto> Records, string title, int company_id, string user_name, int branch_id, Dictionary<string, string> searchInfo)
        {
            var Dt_List = Records;
            if (Dt_List.Count <= 0)
                throw new Exception("Excel List Records error");

            FollowUpExcelFile bc = new FollowUpExcelFile
            {
                Dt_List = Dt_List,
                report_folder = Path.Combine(Lib.rootFolder, Lib.TempFolder, CommonLib.GetSubFolderFromDate()),
                Title = "Follow Up List",
                Company_id = company_id,
                Branch_id = branch_id,
                context = context,
                User_name = user_name,
                OpGroup = searchInfo.ContainsKey("cf_mode") ? searchInfo["cf_mode"] : "",
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