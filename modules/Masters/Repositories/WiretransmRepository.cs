using Database;
using Database.Lib;
using Common.DTO.Masters;
using Masters.Interfaces;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;

namespace Masters.Repositories
{
    public class WiretransmRepository : IWiretransmRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public WiretransmRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var wtim_refno = "";
                var company_id = 0;
                var branch_id = 0;
                var wtim_from_date = "";
                var wtim_to_date = "";
                DateTime? from_date = null;
                DateTime? to_date = null;

                if (data.ContainsKey("wtim_refno"))
                    wtim_refno = data["wtim_refno"].ToString();
                if (data.ContainsKey("wtim_from_date"))
                    wtim_from_date = data["wtim_from_date"].ToString();
                if (data.ContainsKey("wtim_to_date"))
                    wtim_to_date = data["wtim_to_date"].ToString();

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

                IQueryable<mast_wiretransm> query = context.mast_wiretransm;
                query = query.Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id);

                if (!Lib.IsBlank(wtim_from_date))
                {
                    from_date = Lib.ParseDate(wtim_from_date!);
                    query = query.Where(w => w.wtim_date >= from_date);
                }
                if (!Lib.IsBlank(wtim_to_date))
                {
                    to_date = Lib.ParseDate(wtim_to_date!);
                    query = query.Where(w => w.wtim_date <= to_date);
                }
                if (!Lib.IsBlank(wtim_refno))
                    query = query.Where(w => w.wtim_refno!.Contains(wtim_refno!));

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
                    .OrderBy(c => c.wtim_slno)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mast_wiretransm_dto
                {
                    wtim_id = e.wtim_id,
                    wtim_slno = e.wtim_slno,
                    wtim_refno = e.wtim_refno,
                    wtim_to_name = e.wtim_to_name,
                    wtim_cust_id = e.wtim_cust_id,
                    wtim_cust_code = e.customer!.cust_code,
                    wtim_cust_name = e.customer!.cust_name,
                    wtim_cust_fax = e.wtim_cust_fax,
                    wtim_cust_tel = e.wtim_cust_tel,
                    wtim_acc_no = e.wtim_acc_no,
                    wtim_req_type = e.wtim_req_type,
                    wtim_from_name = e.wtim_from_name,
                    wtim_date = Lib.FormatDate(e.wtim_date, Lib.outputDateFormat),
                    wtim_sender_ref = e.wtim_sender_ref,
                    wtim_your_ref = e.wtim_your_ref,
                    wtim_is_urgent = e.wtim_is_urgent,
                    wtim_is_review = e.wtim_is_review,
                    wtim_is_comment = e.wtim_is_comment,
                    wtim_is_reply = e.wtim_is_reply,
                    wtim_is_recycle = e.wtim_is_recycle,
                    wtim_remarks = e.wtim_remarks,

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
        public async Task<mast_wiretransm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<mast_wiretransm> query = context.mast_wiretransm;
                query = query.Where(f => f.wtim_id == id);
                var Record = await query.Select(e => new mast_wiretransm_dto
                {
                    wtim_id = e.wtim_id,
                    wtim_slno = e.wtim_slno,
                    wtim_refno = e.wtim_refno,
                    wtim_to_name = e.wtim_to_name,
                    wtim_cust_id = e.wtim_cust_id,
                    wtim_cust_code = e.customer!.cust_code,
                    wtim_cust_name = e.customer!.cust_name,
                    wtim_cust_fax = e.wtim_cust_fax,
                    wtim_cust_tel = e.wtim_cust_tel,
                    wtim_acc_no = e.wtim_acc_no,
                    wtim_req_type = e.wtim_req_type,
                    wtim_from_name = e.wtim_from_name,
                    wtim_date = Lib.FormatDate(e.wtim_date, Lib.outputDateFormat),
                    wtim_sender_ref = e.wtim_sender_ref,
                    wtim_your_ref = e.wtim_your_ref,
                    wtim_is_urgent = e.wtim_is_urgent,
                    wtim_is_review = e.wtim_is_review,
                    wtim_is_comment = e.wtim_is_comment,
                    wtim_is_reply = e.wtim_is_reply,
                    wtim_is_recycle = e.wtim_is_recycle,
                    wtim_remarks = e.wtim_remarks,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();
                if (Record == null)
                    throw new Exception("No Data Found");

                Record.wtim_details = await GetDetailsAsync(Record.wtim_id);
                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<mast_wiretransd_dto>> GetDetailsAsync(int id)
        {
            var query = from e in context.mast_wiretransd
                        .Where(a => a.wtid_wtim_id == id)
                        .OrderBy(o => o.wtid_id)
                        select (new mast_wiretransd_dto
                        {
                            wtid_id = e.wtid_id,
                            wtid_wtim_id = e.wtid_wtim_id,
                            wtid_benef_id = e.wtid_benef_id,
                            wtid_benef_name = e.benef!.cust_name,
                            wtid_benef_ref = e.wtid_benef_ref,
                            wtid_bank_id = e.wtid_bank_id,
                            wtid_bank_name = e.bank!.cust_name,
                            wtid_trns_amt = e.wtid_trns_amt,
                            wtid_order = e.wtid_order,

                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        });
            var records = await query.ToListAsync();
            return records;
        }


        public async Task<mast_wiretransm_dto> SaveAsync(int id, string mode, mast_wiretransm_dto record_dto)
        {
            try
            {
                context.Database.BeginTransaction();
                record_dto = await SaveParentAsync(id, mode, record_dto);
                record_dto = await saveDetailsAsync(record_dto.wtim_id, record_dto);
                record_dto.wtim_details = await GetDetailsAsync(id);
                context.Database.CommitTransaction();
                return record_dto;
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


        private Boolean AllValid(string mode, mast_wiretransm_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";
            string name = "";
            string email = "";
            string reference = "";
            string benef = "";

            if (Lib.IsBlank(record_dto.wtim_to_name))
                str += "To Name Cannot Be Blank!";
            if (Lib.IsZero(record_dto.wtim_cust_id))
                str += "Customer Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.wtim_date))
                str += "Date Cannot Be Blank!";

            foreach (mast_wiretransd_dto rec in record_dto.wtim_details!)
            {
                
                if (Lib.IsZero(rec.wtid_benef_id))
                    name = "Beneficiary Name Cannot Be Blank!";
                if (Lib.IsZero(rec.wtid_bank_id))
                    email = "Bank Name Cannot Be Blank!";
                if (Lib.IsBlank(rec.wtid_benef_ref))
                    benef = "Beneficiary details Cannot Be Blank!";
                if (Lib.IsZero(rec.wtid_trns_amt))
                    reference = "Amount Cannot Be Blank!";
            }
            if (record_dto.wtim_details.Count == 0)
            {
                str += "Details item Need To Be Entered";
            }
            if (name != "")
                str += name;
            if (email != "")
                str += email;
            if (benef != "")
                str += benef;
            if (reference != "")
                str += reference;
            
            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public int GetNextRefNo(int company_id, int? branch_id)          // function used to get the next cf number
        {
            var maxRefNo = context.mast_wiretransm
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id)
            .Select(e => e.wtim_slno)
            .DefaultIfEmpty()
            .Max();
            return maxRefNo + 1;
        }

        public async Task<mast_wiretransm_dto> SaveParentAsync(int id, string mode, mast_wiretransm_dto record_dto)
        {
            mast_wiretransm? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found To Save");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    int iNextNo = GetNextRefNo(record_dto.rec_company_id, record_dto.rec_branch_id);
                    string sqtn_no = $"REF-{iNextNo}";               

                    Record = new mast_wiretransm();
                    Record.wtim_slno = iNextNo;
                    Record.wtim_refno = sqtn_no;
                    
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.mast_wiretransm
                        .Where(f => f.wtim_id == id)
                        .FirstOrDefaultAsync();


                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                Record.wtim_to_name = record_dto.wtim_to_name;
                Record.wtim_cust_id = record_dto.wtim_cust_id;
                Record.wtim_cust_name = record_dto.wtim_cust_name;
                Record.wtim_cust_fax = record_dto.wtim_cust_fax;
                Record.wtim_cust_tel = record_dto.wtim_cust_tel;
                Record.wtim_acc_no = record_dto.wtim_acc_no;
                Record.wtim_req_type = record_dto.wtim_req_type;
                Record.wtim_from_name = record_dto.wtim_from_name;
                Record.wtim_date = Lib.ParseDate(record_dto.wtim_date!);
                Record.wtim_sender_ref = record_dto.wtim_sender_ref;
                Record.wtim_your_ref = record_dto.wtim_your_ref;
                Record.wtim_is_urgent = record_dto.wtim_is_urgent;
                Record.wtim_is_review = record_dto.wtim_is_review;
                Record.wtim_is_comment = record_dto.wtim_is_comment;
                Record.wtim_is_reply = record_dto.wtim_is_reply;
                Record.wtim_is_recycle = record_dto.wtim_is_recycle;
                Record.wtim_remarks = record_dto.wtim_remarks;

                if (mode == "add")
                    await context.mast_wiretransm.AddAsync(Record);
                    
                context.SaveChanges();
                record_dto.wtim_id = Record.wtim_id;
                record_dto.wtim_refno = Record.wtim_refno;
                record_dto.rec_version = Record.rec_version;
                Lib.AssignDates2DTO(id, mode, Record, record_dto);
                return record_dto;
            }
            catch (Exception Ex)
            {
                //Lib.getErrorMessage(Ex, "uq", "cust_code", "Code Duplication");
                throw new Exception(Ex.Message.ToString());
            }

        }

        public async Task<mast_wiretransm_dto> saveDetailsAsync(int id, mast_wiretransm_dto record_dto)
        {
            mast_wiretransd? record;
            List<mast_wiretransd_dto> records_dto;
            List<mast_wiretransd> records;
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                records_dto = record_dto.wtim_details!;
                records = await context.mast_wiretransd
                    .Where(w => w.wtid_wtim_id == id)
                    .ToListAsync();
                int nextorder = 1;

                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.wtid_id == existing_record.wtid_id);
                    if (rec == null)
                        context.mast_wiretransd.Remove(existing_record);
                }
                foreach (var rec in records_dto)
                {
                    if (rec.wtid_id == 0)
                    {
                        record = new mast_wiretransd();
                        record.rec_company_id = record_dto.rec_company_id;
                        record.rec_branch_id = record_dto.rec_branch_id;
                        record.rec_created_by = record_dto.rec_created_by;
                        record.rec_created_date = DbLib.GetDateTime();
                        record.rec_locked = "N";
                    }
                    else
                    {
                        record = records.Find(f => f.wtid_id == rec.wtid_id);
                        if (record == null)
                            throw new Exception("Detail Record Not Found " + rec.wtid_id.ToString());
                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }
                    record.wtid_wtim_id = id;
                    record.wtid_benef_id = rec.wtid_benef_id;
                    record.wtid_benef_ref = rec.wtid_benef_ref;
                    record.wtid_bank_id = rec.wtid_bank_id;
                    record.wtid_trns_amt = rec.wtid_trns_amt;
                    record.wtid_order = nextorder++;

                    if (rec.wtid_id == 0)
                        await context.mast_wiretransd.AddAsync(record);
                }
                context.SaveChanges();
                return record_dto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mast_wiretransm
                    .Where(f => f.wtim_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    var _Quote = context.mast_wiretransd
                     .Where(c => c.wtid_wtim_id == id);
                    if (_Quote.Any())
                    {
                        context.mast_wiretransd.RemoveRange(_Quote);
                    }
                    context.Remove(_Record);
                    context.SaveChanges();
                    RetData.Add("status", true);
                    RetData.Add("message", "");
                }
                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
    }
}
