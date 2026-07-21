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
using System.Threading.Tasks.Dataflow;
using NPOI.SS.Formula.Functions;

//Name : Sourav V
//Created Date : 07/07/2026
//Remark : this file defines functions like Save, Delete, getList and getRecords which save/retrieve data
//version v1-07/07/2026: added full repository

namespace CommonShipment.Repositories
{
    public class PayRequestRepository : IPayRequestRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        private string cp_req_type = "";

        public PayRequestRepository(AppDbContext _context, IAuditLog _auditLog)
        {
            this.context = _context;
            this.auditLog = _auditLog;
            // this.cp_req_type = cp_req_type;
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

                var cp_parent_id = 0;
                var cp_from_date = "";
                var cp_to_date = "";
                var cp_source = "";
                var cp_mode = "";
                var cp_sortby = "";
                var cp_is_hide = "";
                var cp_ref_no = "";
                var cp_user = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("cp_from_date"))
                    cp_from_date = data["cp_from_date"].ToString();
                if (data.ContainsKey("cp_to_date"))
                    cp_to_date = data["cp_to_date"].ToString();
                if (data.ContainsKey("cp_source"))
                    cp_source = data["cp_source"].ToString();
                if (data.ContainsKey("cp_mode"))
                    cp_mode = data["cp_mode"].ToString();
                if (data.ContainsKey("cp_sortby"))
                    cp_sortby = data["cp_sortby"].ToString();
                if (data.ContainsKey("cp_is_hide"))
                    cp_is_hide = data["cp_is_hide"].ToString()!;
                if (data.ContainsKey("cp_ref_no"))
                    cp_ref_no = data["cp_ref_no"].ToString();
                if (data.ContainsKey("cp_user"))
                    cp_user = data["cp_user"].ToString();
                if (data.ContainsKey("cp_parent_id"))
                    cp_parent_id = int.Parse(data["cp_parent_id"].ToString()!);
                if (data.ContainsKey("cp_req_type"))
                    cp_req_type = data["cp_req_type"].ToString()!;

                company_id = Lib.GetValidIntValue(data!, "rec_company_id", "Company Id Not Found");
                branch_id = Lib.GetValidIntValue(data!, "rec_branch_id", "Branch Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<cargo_payrequest> query = context.cargo_payrequest
                .Include(i => i.master);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                if (!Lib.IsBlank(cp_from_date))
                {
                    from_date = Lib.ParseDateOnly(cp_from_date!);
                    query = query.Where(w => w.cp_payment_date >= from_date);
                }
                if (!Lib.IsBlank(cp_to_date))
                {
                    to_date = Lib.ParseDateOnly(cp_to_date!);
                    query = query.Where(w => w.cp_payment_date <= to_date);
                }
                if (!Lib.IsBlank(cp_mode) && cp_mode != "ALL")
                {
                    query = query.Where(w => w.cp_mode == cp_mode);
                }
                if (!Lib.IsBlank(cp_source) && cp_source != "ALL")
                {
                    query = query.Where(w => w.cp_source == cp_source);
                }
                // if (!Lib.IsBlank(cp_ref_no))
                // {
                //     query = query.Where(w => w.cp_ref_no == cp_ref_no);
                // }
                if(cp_req_type != "APPROVE" && !Lib.IsZero(cp_parent_id))
                {
                    query = query.Where(w => w.cp_master_id == cp_parent_id);
                }
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
                    .OrderBy(c => c.cp_slno)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_payrequest_dto
                {
                    cp_id = e.cp_id,
                    cp_slno = e.cp_slno,
                    cp_mode = e.cp_mode,
                    cp_source = e.cp_source,
                    cp_master_id = e.cp_master_id,
                    cp_master_no = e.master!.mbl_refno,
                    cp_paytype_needed = e.cp_paytype_needed,
                    cp_spl_notes = e.cp_spl_notes,
                    cp_payment_date = Lib.FormatDate(e.cp_payment_date, Lib.outputDateFormat),
                    cp_pay_status = e.cp_pay_status,
                    cp_cust_id = e.cp_cust_id,
                    cp_cust_name = e.customer!.cust_name,
                    cp_inv_id = e.cp_inv_id,
                    cp_inv_no = e.invoice!.inv_no,

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
        public async Task<cargo_payrequest_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_payrequest> query = context.cargo_payrequest
                .Include(e => e.customer);

                query = query.Where(f => f.cp_id == id);

                var Record = await query.Select(e => new cargo_payrequest_dto
                {
                    cp_id = e.cp_id,
                    cp_slno = e.cp_slno,
                    cp_mode = e.cp_mode,
                    cp_source = e.cp_source,
                    cp_master_id = e.cp_master_id,
                    cp_master_no = e.master!.mbl_refno,
                    cp_paytype_needed = e.cp_paytype_needed,
                    cp_spl_notes = e.cp_spl_notes,
                    cp_payment_date = Lib.FormatDate(e.cp_payment_date, Lib.outputDateFormat),
                    cp_pay_status = e.cp_pay_status,
                    cp_cust_id = e.cp_cust_id,
                    cp_cust_name = e.customer!.cust_name,
                    cp_inv_id = e.cp_inv_id,
                    cp_inv_no = e.invoice!.inv_no,
                    rec_record_id = e.rec_record_id,
                    rec_location_id = e.rec_location_id,

                    rec_version = e.rec_version,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");
                
                // Record.approved_details = await GetDetRecordAsync(Record.cp_id);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<List<cargo_payrequest_dto>> GetPayRequestDetAsync(int id,string ParentType)
        {
            try
            {
                var query = from e in context.cargo_payrequest
                            .Where(e => e.cp_master_id == id && e.cp_source == ParentType && e.rec_deleted == "N")
                            .OrderBy(o => o.cp_slno)
                            select (new cargo_payrequest_dto
                            {
                                cp_id = e.cp_id,
                                cp_slno = e.cp_slno,
                                cp_paytype_needed = e.cp_paytype_needed,
                                cp_mode = e.cp_mode,
                                cp_inv_id = e.cp_inv_id,
                                cp_inv_no = e.cp_inv_no,
                                cp_cust_id = e.cp_cust_id,
                                cp_cust_name = e.customer!.cust_name,
                                cp_payment_date = Lib.FormatDate(e.cp_payment_date, Lib.outputDateFormat),
                                cp_pay_status = e.cp_pay_status,
                                cp_spl_notes = e.cp_spl_notes,
                                rec_created_by = e.rec_created_by,
                                rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                                rec_branch_id = e.rec_branch_id,
                                rec_company_id = e.rec_company_id,
                            });
                var records = await query.ToListAsync();
                return records;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        private Boolean AllValid(string mode, cargo_payrequest_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";
            if (Lib.IsBlank(record_dto.cp_paytype_needed))
                str += "RequestType Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.cp_payment_date))
                str += "Payment Date Cannot Be Blank!";
            
            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }

        public async Task<cargo_payrequest_dto> SaveAsync(int id, string mode, cargo_payrequest_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_payrequest_dto _Record = await SaveParentAsync(id, mode, record_dto);
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

        public async Task<cargo_payrequest_dto> SaveParentAsync(int id, string mode, cargo_payrequest_dto record_dto)
        {
            cargo_payrequest? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {

                    var DefaultCfNo = 1;

                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("Req Number Cannot Be Generated");
                    }

                    Record = new cargo_payrequest();
                
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                    Record.cp_slno = iNextNo;
                    Record.rec_deleted = "N";
                }
                else
                {
                    Record = await context.cargo_payrequest
                        .Include(c => c.master)
                        .Where(f => f.cp_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");
                    
                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }

                if (mode == "edit")
                    await logHistory(Record, record_dto);

                Record.cp_master_id = record_dto.cp_master_id;
                Record.cp_mode = record_dto.cp_mode;
                Record.cp_source = record_dto.cp_source;
                Record.cp_paytype_needed = record_dto.cp_paytype_needed;
                Record.cp_spl_notes = record_dto.cp_spl_notes;
                Record.cp_payment_date = Lib.ParseDateOnly(record_dto.cp_payment_date!);
                Record.cp_pay_status = !Lib.IsBlank(record_dto.cp_pay_status) ? record_dto.cp_pay_status : "PENDING";
                Record.cp_inv_id = record_dto.cp_inv_id;
                Record.cp_inv_no = record_dto.cp_inv_no;
                Record.cp_cust_id = record_dto.cp_cust_id;

                if (mode == "add")
                    await context.cargo_payrequest.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.cp_id = Record.cp_id;
                record_dto.cp_slno = Record.cp_slno;

                
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
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
                // throw;
            }

        }
        public int GetNextCfNo(int company_id, int? branch_id, int DefaultCfNo)
        {
            var CfNo = context.cargo_payrequest
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id)
            .Select(e => e.cp_slno)
            .DefaultIfEmpty()
            .Max();

            CfNo = CfNo == 0 ? DefaultCfNo : CfNo + 1;
            return CfNo;
        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id, cargo_payrequest_dto record_dto)
        {
            try
            {
                context.Database.BeginTransaction();
                
                if (record_dto == null)
                    throw new Exception("No Data Found");

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var Record = await context.cargo_payrequest
                    .FirstOrDefaultAsync(f => f.cp_id == id);
                if (Record == null)
                    throw new Exception("Record Not Found");
                context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                Record.rec_version++;
                Record.rec_edited_by = record_dto.rec_created_by;
                Record.rec_edited_date = DbLib.GetDateTime();
                Record.rec_deleted = "Y";
                Record.rec_deleted_by = record_dto.rec_deleted_by;
                Record.rec_deleted_date = Lib.ParseDateOnly(record_dto.rec_deleted_date!);
                
                await context.SaveChangesAsync();

                record_dto.cp_id = Record.cp_id;
                record_dto.cp_slno = Record.cp_slno;
                record_dto.rec_edited_by = Record.rec_edited_by;
                record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                record_dto.rec_version = Record.rec_version;
                context.Database.CommitTransaction();
                return RetData;
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
        public async Task<Dictionary<string, object>> HideRecordAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();
                
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_payrequest
                    .FirstOrDefaultAsync(f => f.cp_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    /**//**/
                    context.Remove(_Record);
                    context.SaveChanges();
                    context.Database.CommitTransaction();
                }
             
                RetData.Add("status", true);
                RetData.Add("message", "");
                return RetData;
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }
        public async Task logHistory(cargo_payrequest old_record, cargo_payrequest_dto record_dto)
        {
            var old_record_dto = new cargo_payrequest_dto
            {
                cp_id = old_record.cp_id,
                cp_mode = old_record.cp_mode,
                cp_source = old_record.cp_source,
                cp_paytype_needed = old_record.cp_source,
                cp_spl_notes = old_record.cp_spl_notes,
                cp_payment_date = Lib.FormatDate(old_record.cp_payment_date, Lib.outputDateFormat),
                cp_pay_status = old_record.cp_pay_status,
            };

            await new LogHistorym<cargo_payrequest_dto>(context)
                .Table("cargo_payrequest", log_date)
                .PrimaryKey("cp_id", record_dto.cp_id)
                .RefNo(record_dto.cp_slno.ToString()!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("cp_mode", "Mode")
                .TrackColumn("cp_source", "Source")
                .TrackColumn("cp_paytype_needed", "Pay Type")
                .TrackColumn("cp_spl_notes", "Notes")
                .TrackColumn("cp_pay_status", "Status")
                .TrackColumn("cp_payment_date", "Payment Date", "date")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }
    }
}