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
//Created Date : 09/06/2026
//Remark : this file defines functions like Save, Delete, getList and getRecords which save/retrieve data
//version v1-09/06/2026: added full repository

namespace CommonShipment.Repositories
{
    public class ApprovedRepository : IApprovedRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        private string ca_req_type = "";

        public ApprovedRepository(AppDbContext _context, IAuditLog _auditLog)
        {
            this.context = _context;
            this.auditLog = _auditLog;
            // this.ca_req_type = ca_req_type;
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

                var ca_parent_id = 0;
                var ca_from_date = "";
                var ca_to_date = "";
                var ca_doc_type = "";
                var ca_type = "";
                var ca_sortby = "";
                var ca_is_hide = "";
                var ca_ref_no = "";
                var ca_user = "";

                var company_id = 0;
                var branch_id = 0;

                DateOnly? from_date = null;
                DateOnly? to_date = null;

                if (data.ContainsKey("ca_from_date"))
                    ca_from_date = data["ca_from_date"].ToString();
                if (data.ContainsKey("ca_to_date"))
                    ca_to_date = data["ca_to_date"].ToString();
                if (data.ContainsKey("ca_doc_type"))
                    ca_doc_type = data["ca_doc_type"].ToString();
                if (data.ContainsKey("ca_type"))
                    ca_type = data["ca_type"].ToString();
                if (data.ContainsKey("ca_sortby"))
                    ca_sortby = data["ca_sortby"].ToString();
                if (data.ContainsKey("ca_is_hide"))
                    ca_is_hide = data["ca_is_hide"].ToString()!;
                if (data.ContainsKey("ca_ref_no"))
                    ca_ref_no = data["ca_ref_no"].ToString();
                if (data.ContainsKey("ca_user"))
                    ca_user = data["ca_user"].ToString();
                if (data.ContainsKey("ca_parent_id"))
                    ca_parent_id = int.Parse(data["ca_parent_id"].ToString()!);
                if (data.ContainsKey("ca_req_type"))
                    ca_req_type = data["ca_req_type"].ToString()!;

                company_id = Lib.GetValidIntValue(data!, "rec_company_id", "Company Id Not Found");
                branch_id = Lib.GetValidIntValue(data!, "rec_branch_id", "Branch Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<cargo_approvedm> query = context.cargo_approvedm
                .Include(i => i.consignee);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                if (!Lib.IsBlank(ca_from_date))
                {
                    from_date = Lib.ParseDateOnly(ca_from_date!);
                    query = query.Where(w => w.ca_date >= from_date);
                }
                if (!Lib.IsBlank(ca_to_date))
                {
                    to_date = Lib.ParseDateOnly(ca_to_date!);
                    query = query.Where(w => w.ca_date <= to_date);
                }
                if (!Lib.IsBlank(ca_type) && ca_type != "ALL")
                {
                    query = query.Where(w => w.ca_type == ca_type);
                }
                if (!Lib.IsBlank(ca_doc_type) && ca_doc_type != "ALL")
                {
                    query = query.Where(w => w.ca_doc_type == ca_doc_type);
                }
                if (!Lib.IsBlank(ca_ref_no))
                {
                    query = query.Where(w => w.ca_ref_no == ca_ref_no);
                }
                if(ca_req_type != "APPROVE" && !Lib.IsZero(ca_parent_id))
                {
                    query = query.Where(w => w.ca_mbl_id == ca_parent_id);
                }
                if(ca_req_type == "APPROVE")
                {
                    query = query.Where(w => w.ca_is_hide == ca_is_hide);
                }

                var data_ =
                from m in query
                join d in context.cargo_approvedd
                    on m.ca_id equals d.cad_parent_id into ApproveGroup

                from d in ApproveGroup.DefaultIfEmpty()
                where Lib.IsBlank(ca_user) || m.user!.user_name == ca_user || d.approvedby!.user_name == ca_user 
                orderby m.ca_req_no
                select new cargo_approvedd_dto
                {
                    ca_id = m.ca_id,
                    ca_req_no = m.ca_req_no,
                    ca_type = m.ca_type,
                    ca_doc_type = m.ca_doc_type,
                    ca_mbl_id = m.ca_mbl_id,
                    ca_ref_no = m.ca_ref_no,        //master ref
                    ca_remarks = m.ca_remarks,
                    ca_user_id = m.ca_user_id,
                    ca_user_name = m.user!.user_name,
                    ca_is_approved = m.ca_is_approved,
                    ca_date = Lib.FormatDate(m.ca_date, Lib.outputDateFormat),
                    ca_hbl_id = m.ca_hbl_id,
                    ca_hbl_no = m.house!.hbl_houseno,
                    ca_inv_id = m.ca_inv_id,
                    ca_inv_no = m.invoice!.inv_no,
                    ca_inv_cust = m.invoice!.inv_cust_name,
                    ca_inv_amt = m.invoice!.inv_total,
                    ca_consignee_id = m.ca_consignee_id,
                    ca_consignee_name = m.consignee!.cust_name,
                    cad_approvedby_name = d.approvedby!.user_name,
                    cad_approved_date = Lib.FormatDate(d.cad_approved_date, Lib.outputDateFormat),
                    cad_is_approved = d.cad_is_approved == null ? "NOT APPROVED" : d.cad_is_approved == "Y" ? "APPROVED" : "NOT APPROVED",

                    ca_approved_tot = m.ca_approved_tot,
                    ca_notapproved_tot = m.ca_notapproved_tot,
                    ca_obl_recvd_date = Lib.FormatDate(m.ca_obl_recvd_date, Lib.outputDateTimeFormat),
                    ca_payment_recvd_date = Lib.FormatDate(m.ca_payment_recvd_date, Lib.outputDateTimeFormat),
                    ca_is_hide = m.ca_is_hide,
                    ca_is_ar_issued = m.ca_is_ar_issued,
                    ca_is_hide2 = m.ca_is_hide2,
                    rec_files_attached = m.rec_files_attached,
                    // rec_record_id = m.rec_record_id,
                    // rec_location_id = m.rec_location_id,

                    rec_created_by = m.rec_created_by,
                    rec_created_date = Lib.FormatDate(m.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = m.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(m.rec_edited_date, Lib.outputDateTimeFormat),
                };

                var records = await data_.ToListAsync();

                if (action == "SEARCH")
                {
                    _page.rows = records.Count();
                    _page.pages = Lib.getTotalPages(_page.rows, _page.pageSize);
                    _page.currentPageNo = 1;
                }
                else
                {
                    _page.currentPageNo = Lib.FindPage(action, _page.currentPageNo, _page.pages);
                }

                int StartRow = Lib.getStartRow(_page.currentPageNo, _page.pageSize);

                records = records.OrderBy(c => c.ca_date).Skip(StartRow).Take(_page.pageSize).ToList();
                
                Func<cargo_approvedd_dto, object> groupSelector = x => "";

                if (ca_sortby == "REQUEST NO")
                    groupSelector = x => x.ca_req_no!;
                if (ca_sortby == "REQUEST-BY")
                    groupSelector = x => x.ca_user_name!;
                if (ca_sortby == "REQUEST-DATE")
                    groupSelector = x => x.ca_date!;
                if (ca_sortby == "TYPE")
                    groupSelector = x => x.ca_type!;
                if (ca_sortby == "REF#")
                    groupSelector = x => x.ca_ref_no!;
                if (ca_sortby == "HOUSE#")
                    groupSelector = x => x.ca_hbl_no!;
                if (ca_sortby == "CONSIGNEE")
                    groupSelector = x => x.ca_consignee_name!;
                if (ca_sortby == "INVOICE#")
                    groupSelector = x => x.ca_inv_no!;
                if (ca_sortby == "CUSTOMER")
                    groupSelector = x => x.ca_inv_cust!;
                if (ca_sortby == "APPROVED-BY")
                    groupSelector = x => x.cad_approvedby_name!;
                if (ca_sortby == "APPROVED-DATE")
                    groupSelector = x => x.cad_approved_date!;
                if (ca_sortby == "STATUS")
                    groupSelector = x => x.cad_is_approved == "Y" ? "APPROVED" : "NOT APPROVED";
                if (ca_sortby == "REMARKS")
                    groupSelector = x => x.ca_remarks!;

                records = records.OrderBy(groupSelector).ToList();

                RetData.Add("records", records);
                RetData.Add("page", _page);

                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<cargo_approvedm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_approvedm> query = context.cargo_approvedm;
                //.Include(e => e.customer);

                query = query.Where(f => f.ca_id == id);

                var Record = await query.Select(e => new cargo_approvedm_dto
                {
                    ca_id = e.ca_id,
                    ca_req_no = e.ca_req_no,
                    ca_type = e.ca_type,
                    ca_doc_type = e.ca_doc_type,
                    ca_mbl_id = e.ca_mbl_id,
                    ca_ref_no = e.ca_ref_no,        //master ref
                    ca_remarks = e.ca_remarks,
                    ca_user_id = e.ca_user_id,
                    ca_user_name = e.user!.user_name,
                    ca_is_approved = e.ca_is_approved,
                    ca_date = Lib.FormatDate(e.ca_date, Lib.outputDateFormat),
                    ca_hbl_id = e.ca_hbl_id,
                    ca_hbl_no = e.house!.hbl_houseno,
                    ca_inv_id = e.ca_inv_id,
                    ca_inv_no = e.invoice!.inv_no,
                    ca_consignee_id = e.ca_consignee_id,
                    ca_consignee_name = e.consignee!.cust_name,
                    ca_approved_tot = e.ca_approved_tot,
                    ca_notapproved_tot = e.ca_notapproved_tot,
                    ca_obl_recvd_date = Lib.FormatDate(e.ca_obl_recvd_date, Lib.outputDateTimeFormat),
                    ca_payment_recvd_date = Lib.FormatDate(e.ca_payment_recvd_date, Lib.outputDateTimeFormat),
                    ca_is_hide = e.ca_is_hide,
                    ca_is_ar_issued = e.ca_is_ar_issued,
                    ca_is_hide2 = e.ca_is_hide2,
                    rec_files_attached = e.rec_files_attached,
                    rec_record_id = e.rec_record_id,
                    rec_location_id = e.rec_location_id,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");
                
                Record.approved_details = await GetDetRecordAsync(Record.ca_id);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<List<cargo_approvedd_dto>> GetDetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_approvedd> query = context.cargo_approvedd
                .Include(e => e.approvedby);

                query = query.Where(f => f.cad_parent_id == id);

                var Record = await query.Select(e => new cargo_approvedd_dto
                {
                    cad_id = e.cad_id,
                    cad_parent_id = e.cad_parent_id,
                    cad_approvedby_id = e.cad_approvedby_id,
                    cad_approvedby_name = e.approvedby!.user_name,
                    cad_is_approved = e.cad_is_approved == "Y" ? "APPROVED" : "NOT APPROVED",
                    cad_approved_date = Lib.FormatDate(e.cad_approved_date, Lib.outputDateTimeFormat),
                    cad_is_hide = e.cad_is_hide,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).ToListAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        private Boolean AllValid(string mode, cargo_approvedm_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";
            if (Lib.IsBlank(record_dto.ca_hbl_no))
                str += "House Cannot Be Blank!";
            
            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }
        private Boolean AllValid_Det(string mode, cargo_approvedd_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";

            if (Lib.IsBlank(record_dto.cad_is_approved))
                str += "Select Approved or Not Approved!";
            
            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }

        public async Task<cargo_approvedm_dto> SaveAsync(int id, string mode, cargo_approvedm_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_approvedm_dto _Record = await SaveParentAsync(id, mode, record_dto);
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

        public async Task<cargo_approvedm_dto> SaveParentAsync(int id, string mode, cargo_approvedm_dto record_dto)
        {
            cargo_approvedm? Record;
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

                    Record = new cargo_approvedm();
                
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                    Record.ca_req_no = iNextNo;
                    Record.ca_is_hide = "N";
                    Record.ca_doc_type = record_dto.ca_doc_type;
                }
                else
                {
                    Record = await context.cargo_approvedm
                        .Include(c => c.user)
                        .Include(c => c.master)
                        .Include(c => c.house)
                        .Include(c => c.invoice)
                        .Include(c => c.consignee)
                        .Where(f => f.ca_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");
                    
                    var isApproved = await context.cargo_approvedd.Where(i => i.cad_parent_id == id).FirstOrDefaultAsync();
                    if (isApproved != null)
                        throw new Exception("Cannot Edit, Approval Exists");
                    
                    // context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    // Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }

                if (mode == "edit")
                    await logHistory(Record, record_dto);

                Record.ca_type = record_dto.ca_type;
                Record.ca_mbl_id = record_dto.ca_mbl_id;
                Record.ca_ref_no = record_dto.ca_ref_no;
                Record.ca_user_id = record_dto.ca_user_id;
                Record.ca_hbl_id = record_dto.ca_hbl_id;
                Record.ca_consignee_id = record_dto.ca_consignee_id;
                Record.ca_inv_id = record_dto.ca_inv_id;
                Record.ca_is_approved = record_dto.ca_is_approved;
                Record.ca_is_ar_issued = record_dto.ca_is_ar_issued;
                Record.ca_remarks = record_dto.ca_remarks;
                Record.ca_obl_recvd_date = Lib.ParseDate(record_dto.ca_obl_recvd_date!);
                Record.ca_payment_recvd_date = Lib.ParseDate(record_dto.ca_payment_recvd_date!);
                Record.ca_date = Lib.ParseDateOnly(record_dto.ca_date!);

                if (mode == "add")
                    await context.cargo_approvedm.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.ca_id = Record.ca_id;
                record_dto.ca_req_no = Record.ca_req_no;

                
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (mode == "edit")
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }
                // record_dto.rec_version = Record.rec_version;
                


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
            var CfNo = context.cargo_approvedm
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id)
            .Select(e => e.ca_req_no)
            .DefaultIfEmpty()
            .Max();

            CfNo = CfNo == 0 ? DefaultCfNo : CfNo + 1;
            return CfNo;
        }
        public async Task<cargo_approvedd_dto> SaveApprovedDetAsync(int id, string mode, cargo_approvedd_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                
                cargo_approvedd_dto _Record = await SaveApproveDetAsync(id, mode, record_dto);
                await SaveApprovemSummary(_Record.cad_parent_id);

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
        public async Task<cargo_approvedd_dto> SaveApproveDetAsync(int id, string mode, cargo_approvedd_dto records_dto)
        {
            cargo_approvedd? Record;
            string error = "";
            try
            {
                if (records_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid_Det(mode, records_dto, ref error))
                    throw new Exception(error);
                
                bool isDuplicate = await context.cargo_approvedd
                    .AnyAsync(x => x.cad_parent_id == records_dto.cad_parent_id && x.cad_approvedby_id == records_dto.cad_approvedby_id 
                            && x.cad_is_approved == records_dto.cad_is_approved );

                if (isDuplicate)
                    throw new Exception("Duplicate Record");

                if (mode == "add")
                {
                    Record = new cargo_approvedd();
                
                    Record.rec_company_id = records_dto.rec_company_id;
                    Record.rec_branch_id = records_dto.rec_branch_id;
                    Record.rec_created_by = records_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();

                    Record.cad_approved_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.cargo_approvedd
                        .Include(c => c.approvedm)
                        .Include(c => c.approvedby)
                        .Where(f => f.cad_parent_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    // Record.rec_edited_by = records_dto.rec_created_by;
                    // Record.rec_edited_date = DbLib.GetDateTime();
                }

                Record.cad_parent_id = records_dto.cad_parent_id;
                Record.cad_approvedby_id = records_dto.cad_approvedby_id;
                Record.cad_is_approved = records_dto.cad_is_approved;

                if (mode == "add")
                    await context.cargo_approvedd.AddAsync(Record);

                await context.SaveChangesAsync();

                records_dto.cad_id = Record.cad_id;

                return records_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
                // throw;
            }

        }
        public async Task SaveApprovemSummary(int? ca_id)
        {
            var ApprovedList = context.cargo_approvedd
            .Where(c => c.cad_parent_id == ca_id)
            .Include(i => i.approvedby)
            .Select(x => new {x.cad_is_approved})
            .ToList();

            var approved = 0;
            var not_approved = 0;

            foreach (var item in ApprovedList)
            {
                // item.cad_is_approved == "Y" ? approved++ : not_approved ++ ;
                approved += item.cad_is_approved == "Y" ? 1 : 0;
                not_approved += item.cad_is_approved == "N" ? 1 : 0;
            }

            var _Record = context.cargo_approvedm
                .Where(m => m.ca_id == ca_id)
                .FirstOrDefault();

            if (_Record != null)
            {
                _Record.ca_approved_tot = approved;
                _Record.ca_notapproved_tot = not_approved;
                await context.SaveChangesAsync();
            }
        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();
                
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_approvedm
                    .FirstOrDefaultAsync(f => f.ca_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                if(CommonLib.ApprovalExists(context, id, _Record!.rec_company_id))
                {
                    throw new Exception("Cannot Delete, Approval Exists");
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
        public async Task<Dictionary<string, object>> HideRecordAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();
                
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_approvedm
                    .FirstOrDefaultAsync(f => f.ca_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                if (_Record!.ca_is_hide == "N")
                {
                    _Record.ca_is_hide = "Y";
                }
                else
                {
                    _Record.ca_is_hide = "N";
                }
                context.SaveChanges();
                context.Database.CommitTransaction();
             
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
        public async Task logHistory(cargo_approvedm old_record, cargo_approvedm_dto record_dto)
        {
            var old_record_dto = new cargo_approvedm_dto
            {
                ca_id = old_record.ca_id,
                ca_type = old_record.ca_type,
                ca_hbl_no = old_record.house?.hbl_houseno,
                ca_consignee_name = old_record.consignee?.cust_name,
                ca_inv_no = old_record.invoice?.inv_no,
                ca_is_ar_issued = old_record.ca_is_ar_issued,
                ca_remarks = old_record.ca_remarks,
                ca_date = Lib.FormatDate(old_record.ca_date, Lib.outputDateFormat),
                ca_obl_recvd_date = Lib.FormatDate(old_record.ca_obl_recvd_date, Lib.outputDateFormat),
                ca_payment_recvd_date = Lib.FormatDate(old_record.ca_payment_recvd_date, Lib.outputDateFormat),
            };

            await new LogHistorym<cargo_approvedm_dto>(context)
                .Table("cargo_approvedm", log_date)
                .PrimaryKey("ca_id", record_dto.ca_id)
                .RefNo(record_dto.ca_req_no.ToString()!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("ca_hbl_no", "House No")
                .TrackColumn("ca_type", "Type")
                .TrackColumn("ca_consignee_name", "Consignee Name")
                .TrackColumn("ca_inv_cust", "Customer")
                .TrackColumn("ca_inv_total", "Total")
                .TrackColumn("ca_is_ar_issued", "Is AR Issued")
                .TrackColumn("ca_remarks", "Remarks")
                .TrackColumn("ca_obl_recvd_date", "OBL Rec Date", "date")
                .TrackColumn("ca_payment_recvd_date", "Payment Rec Date", "date")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }
    }
}
        /*--/\--*/
        /*-/  \-*/
        /*/    \*/