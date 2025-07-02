using Database;
using Database.Lib;
using Common.DTO.Masters;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;

using Database.Models.Cargo;
using System.Diagnostics.Eventing.Reader;
using CommonShipment.Interfaces;
using Database.Models.CommonShipment;
using Common.DTO.CommonShipment;

//Name : Sourav V
//Created Date : 01/07/2025
//Remark : this file defines functions like Save, Delete, getList and getRecords which save/retrieve data
//version v1 : 01/07/2025: added full repository

namespace CommonShipment.Repositories
{
    public class CustomHoldRepository : ICustomHoldRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;

        public CustomHoldRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var company_id = 0;
                var branch_id = 0;

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

                IQueryable<cargo_custom_hold> query = context.cargo_custom_hold;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);

                if (action == "SEARCH")
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
                    .OrderBy(c => c.custom_id)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_custom_hold_dto
                {
                    custom_id = e.custom_id,
                    custom_parent_id = e.custom_parent_id,
                    custom_refno = e.custom_refno,
                    custom_title = e.custom_title,
                    custom_comm_inv_yn = e.custom_comm_inv_yn,
                    custom_comm_inv = e.custom_comm_inv,
                    custom_fumi_cert_yn = e.custom_fumi_cert_yn,
                    custom_fumi_cert = e.custom_fumi_cert,
                    custom_insp_chrg_yn = e.custom_insp_chrg_yn,
                    custom_insp_chrg = e.custom_insp_chrg,

                    custom_remarks = e.custom_remarks,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).ToListAsync();

                RetData.Add("records", Records);
                RetData.Add("page", _page);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<cargo_custom_hold_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_custom_hold> query = context.cargo_custom_hold;

                query = query.Where(f => f.custom_parent_id == id);

                var Record = await query.Select(e => new cargo_custom_hold_dto
                {
                    custom_id = e.custom_id,
                    custom_parent_id = e.custom_parent_id,
                    custom_refno = e.custom_refno,
                    custom_houseno = e.custom_houseno,
                    custom_title = e.custom_title,
                    custom_comm_inv_yn = e.custom_comm_inv_yn,
                    custom_comm_inv = e.custom_comm_inv,
                    custom_fumi_cert_yn = e.custom_fumi_cert_yn,
                    custom_fumi_cert = e.custom_fumi_cert,
                    custom_insp_chrg_yn = e.custom_insp_chrg_yn,
                    custom_insp_chrg = e.custom_insp_chrg,
                    custom_remarks = e.custom_remarks,

                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                {
                    Record = new cargo_custom_hold_dto { custom_id = 0 };
                }

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<cargo_custom_hold_dto?> GetDefaultDataAsync(int id)
        {
            try
            {
                var query = context.cargo_housem
                    .Where(f => f.hbl_id == id);

                var Record = await query
                    .Select(e => new cargo_custom_hold_dto
                    {
                        custom_parent_id = e.hbl_id,
                        custom_refno = e.master!.mbl_refno,
                        custom_houseno = e.hbl_houseno,
                        rec_branch_id = e.rec_branch_id,
                        rec_company_id = e.rec_company_id,
                    })
                    .FirstOrDefaultAsync();


                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        private Boolean AllValid(string mode, cargo_custom_hold_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";
            if (Lib.IsBlank(record_dto.custom_remarks))
                str += "Remarks Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }

        public async Task<cargo_custom_hold_dto> SaveAsync(int id, string mode, cargo_custom_hold_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_custom_hold_dto _Record = await SaveParentAsync(id, mode, record_dto);
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

        public async Task<cargo_custom_hold_dto> SaveParentAsync(int id, string mode, cargo_custom_hold_dto record_dto)
        {
            cargo_custom_hold? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {

                    Record = new cargo_custom_hold();
                
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";                    
                    
                }
                else
                {
                    Record = await context.cargo_custom_hold
                        .Where(f => f.custom_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }

                if (mode == "edit")
                    await logHistory(Record,mode, record_dto);

                Record.custom_parent_id = record_dto.custom_parent_id;
                Record.custom_refno = record_dto.custom_refno;
                Record.custom_houseno = record_dto.custom_houseno;
                Record.custom_title = record_dto.custom_title;
                Record.custom_comm_inv_yn = record_dto.custom_comm_inv_yn;
                Record.custom_comm_inv = record_dto.custom_comm_inv;
                Record.custom_fumi_cert_yn = record_dto.custom_fumi_cert_yn;
                Record.custom_fumi_cert = record_dto.custom_fumi_cert;
                Record.custom_insp_chrg_yn = record_dto.custom_insp_chrg_yn;
                Record.custom_insp_chrg = record_dto.custom_insp_chrg;
                Record.custom_remarks = record_dto.custom_remarks;

                if (mode == "add")
                    await context.cargo_custom_hold.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.custom_id = Record.custom_id;

                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (mode == "edit")
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }
                record_dto.rec_version = Record.rec_version;


                return record_dto;
            }
            catch (Exception)
            {
                // throw new Exception(Ex.Message.ToString());
                throw;
            }

        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();
                
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_custom_hold
                    .FirstOrDefaultAsync(f => f.custom_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    context.Remove(_Record);
                    context.SaveChanges();
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

        public async Task logHistory(cargo_custom_hold old_record, string mode, cargo_custom_hold_dto record_dto)
        {
            var old_record_dto = new cargo_custom_hold_dto
            {
                custom_id = old_record.custom_id,
                custom_parent_id = old_record.custom_parent_id,
                custom_refno = old_record.custom_refno,
                custom_title = old_record.custom_title,
                custom_comm_inv_yn = old_record.custom_comm_inv_yn,
                custom_comm_inv = old_record.custom_comm_inv,
                custom_fumi_cert_yn = old_record.custom_fumi_cert_yn,
                custom_fumi_cert = old_record.custom_fumi_cert,
                custom_insp_chrg_yn = old_record.custom_insp_chrg_yn,
                custom_insp_chrg = old_record.custom_insp_chrg,
                custom_remarks = old_record.custom_remarks,
            };

            await new LogHistorym<cargo_custom_hold_dto>(context)
                .Table("cargo_custom_hold", log_date)
                .PrimaryKey("custom_parent_id", record_dto.custom_parent_id)
                .RefNo(record_dto.custom_refno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("custom_title", "Title")
                .TrackColumn("custom_comm_inv_yn", "Comm Inv(Y/N)")
                .TrackColumn("custom_comm_inv", "Comm Inv Detail")
                .TrackColumn("custom_fumi_cert_yn", "Fumigation Cert(Y/N)")
                .TrackColumn("custom_fumi_cert", "Fumigation Cert Detail")
                .TrackColumn("custom_insp_chrg_yn", "Inspection Charges(Y/N)")
                .TrackColumn("custom_insp_chrg", "Inspection Charges Detail")
                .TrackColumn("custom_remarks", "Remarks")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }


    }
}
