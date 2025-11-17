using Database;
using Database.Lib;
using Common.DTO.Masters;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.BaseTables;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Common.Lib;
using Database.Models.Cargo;
using Accounts.Interfaces;
using Database.Models.Accounts;
using Common.DTO.Accounts;
using System.Threading.Tasks;

//Name : Sourav V
//Created Date : 15/10/2025
//Remark : this file defines functions like Save, Delete, getList and getRecords which save/retrieve data
//versio 2 : updated AllValid Condition 28/10/2025

namespace Accounts.Repositories
{
    public class AccTransRepository : IAccTransRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        // private string sjvh_type = "";
        private DateTime log_date;

        public AccTransRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var jvh_from_date = "";
                var jvh_to_date = "";
                var jvh_to_name = "";
                var jvh_docno = "";
                var company_id = 0;
                var branch_id = 0;
                DateOnly? from_date = null;
                DateOnly? to_date = null;
                var jvh_type = data["jvh_type"].ToString();

                if (data.ContainsKey("jvh_from_date"))
                    jvh_from_date = data["jvh_from_date"].ToString();
                if (data.ContainsKey("jvh_to_date"))
                    jvh_to_date = data["jvh_to_date"].ToString();
                if (data.ContainsKey("jvh_to_name"))
                    jvh_to_name = data["jvh_to_name"].ToString();
                if (data.ContainsKey("jvh_docno"))
                    jvh_docno = data["jvh_docno"].ToString();
                company_id = Lib.GetValidIntValue(data!, "rec_company_id", "Company Id Not Found");
                branch_id = Lib.GetValidIntValue(data!, "rec_branch_id", "Branch Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<acc_ledgerh> query = context.acc_ledgerh;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.jvh_type == jvh_type!);

                if (!Lib.IsBlank(jvh_docno))
                {
                    query = query.Where(w => w.jvh_docno!.Contains(jvh_docno!));
                }
                if (!Lib.IsBlank(jvh_from_date))
                {
                    from_date = Lib.ParseDateOnly(jvh_from_date!);
                    query = query.Where(w =>w.jvh_date >= from_date);
                }
                if (!Lib.IsBlank(jvh_to_date))
                {
                    to_date = Lib.ParseDateOnly(jvh_to_date!);
                    query = query.Where(w => w.jvh_date <= to_date);
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
                    .OrderBy(c => c.jvh_vrno)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new acc_ledgerh_dto
                {
                    jvh_id = e.jvh_id,
                    jvh_vrno = e.jvh_vrno,
                    jvh_docno = e.jvh_docno,
                    jvh_type = e.jvh_type,
                    jvh_date = Lib.FormatDate(e.jvh_date, Lib.outputDateFormat),
                    jvh_year = e.jvh_year,
                    jvh_shipment_ref = e.jvh_shipment_ref,
                    jvh_shipment_date = Lib.FormatDate(e.jvh_shipment_date, Lib.outputDateFormat),
                    jvh_narration = e.jvh_narration,
                    jvh_debit = e.jvh_debit,// debit or credit (since both are same here)

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
        public async Task<acc_ledgerh_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<acc_ledgerh> query = context.acc_ledgerh;

                query = query.Where(f => f.jvh_id == id);

                var Record = await query.Select(e => new acc_ledgerh_dto
                {
                    jvh_id = e.jvh_id,
                    jvh_vrno = e.jvh_vrno,
                    jvh_year = e.jvh_year,
                    // jvh_year_name = e.year!.year_name,
                    jvh_docno = e.jvh_docno,
                    jvh_type = e.jvh_type,
                    jvh_date = Lib.FormatDate(e.jvh_date, Lib.outputDateFormat),
                    jvh_refno = e.jvh_refno,
                    jvh_refdate = Lib.FormatDate(e.jvh_refdate, Lib.outputDateFormat),
                    jvh_status = e.jvh_status,
                    jvh_remarks = e.jvh_remarks,
                    jvh_narration = e.jvh_narration,

                    jvh_master_date = Lib.FormatDate(e.jvh_master_date, Lib.outputDateFormat),
                    jvh_is_payroll = e.jvh_is_payroll,
                    jvh_shipment_ref = e.jvh_shipment_ref,
                    jvh_shipment_date = Lib.FormatDate(e.jvh_shipment_date, Lib.outputDateFormat),

                    rec_version = e.rec_version,
                    rec_locked = e.rec_locked,
                    rec_error = "",
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                    rec_company_id = e.rec_company_id,
                    rec_branch_id = e.rec_branch_id,
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Record Found");

                Record!.rec_error = CommonLib.IsYearLocked(context, Record.jvh_year, Record.rec_company_id, Record.rec_locked!);
                
                Record.ledger_details = await GetDetailsAsync(Record.jvh_id);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<acc_ledgerd_dto>> GetDetailsAsync(int id)
        {
            var query = from e in context.acc_ledgerd
                        .Where(e => e.jv_header_id == id)
                        .OrderBy(o => o.jv_ctr)
                        select (new acc_ledgerd_dto
                        {
                            jv_id = e.jv_id,
                            jv_header_id = e.jv_header_id,
                            jv_year = e.jv_year,
                            jv_vrno = e.jv_vrno,
                            jv_docno = e.jv_docno,
                            jv_type = e.jv_type,
                            jv_date = Lib.FormatDate(e.jv_date, Lib.outputDateFormat),
                            jv_refno = e.jv_refno,
                            jv_refdate = Lib.FormatDate(e.jv_refdate, Lib.outputDateFormat),
                            jv_acc_id = e.jv_acc_id,
                            jv_acc_code = e.accounts!.acc_code,
                            jv_acc_name = e.jv_acc_name,
                            jv_status = e.jv_status,
                            jv_famt = e.jv_famt,
                            jv_cur_id = e.jv_cur_id,
                            jv_cur_code = e.currency!.param_code,
                            jv_exrate = e.jv_exrate,
                            jv_drcr = e.jv_drcr,
                            jv_dcamt = e.jv_dcamt,
                            jv_debit = e.jv_debit,
                            jv_credit = e.jv_credit,
                            jv_inv_id = e.jv_inv_id,
                            jv_inv_code = e.invoice!.inv_no,
                            jv_remarks = e.jv_remarks,
                            jv_narration = e.jv_narration,
                            jv_doc_type = e.jv_doc_type,
                            jv_bank = e.jv_bank,
                            jv_chqno = e.jv_chqno,
                            jv_chq_date = Lib.FormatDate(e.jv_chq_date, Lib.outputDateFormat),
                            jv_master_date = Lib.FormatDate(e.jv_master_date, Lib.outputDateFormat),
                            jv_tax_amt = e.jv_tax_amt,
                            jv_tax_per = e.jv_tax_per,
                            jv_is_payroll = e.jv_is_payroll,

                            rec_branch_id = e.rec_branch_id,
                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        });

            var records = await query.ToListAsync();

            return records;
        }
        public async Task<acc_ledgerh_dto> GetDefaultData(int company_id, int branch_id)
        {
            try
            {
                // acc_ledgerh_dto? Record_dto = null;
                var Record_dto = new acc_ledgerh_dto
                {
                    ledger_detail = new acc_ledgerd_dto()
                };

                var caption = "CURRENCY,EXRATE DECIMAL";

                var result = CommonLib.GetBranchsettings(context, company_id, branch_id, caption);

                if (result.ContainsKey("CURRENCY"))
                {
                    Record_dto!.ledger_detail!.jv_cur_id = Lib.StringToInteger(result["CURRENCY"]);

                    int cur_id = Lib.StringToInteger(result["CURRENCY"]);
                    var cur = await context.mast_param                                // to get cur_code and exrate using default cur_id
                        .Where(p => p.param_id == cur_id)
                        .FirstOrDefaultAsync();

                    if (cur != null)
                    {
                        Record_dto!.ledger_detail!.jv_cur_code = cur.param_code ?? "";
                        Record_dto!.ledger_detail!.jv_exrate = Lib.StringToDecimal(cur.param_value1 ?? "0");
                    }
                }

                if (Record_dto == null)
                    throw new Exception("No Default Data Found");

                return Record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<acc_ledgerh_dto> SaveAsync(int id, string mode, acc_ledgerh_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                acc_ledgerh_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await SaveDetailsAsync(_Record.jvh_id, mode, _Record);
                _Record.ledger_details = await GetDetailsAsync(_Record.jvh_id);
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


        private Boolean AllValid(string mode, acc_ledgerh_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            string acc_code = "";
            string amt = "";
            string carrier = "";
            string ttime = "";

            if (Lib.IsBlank(record_dto.jvh_date))
                str += "Date Cannot Be Blank!";
            if (Lib.IsZero(record_dto.jvh_year))
                str += "Fin-year Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.jvh_narration))
                str += "Narration Cannot Be Blank!";
            if (!Lib.IsBlank(record_dto.jvh_shipment_ref) && Lib.IsBlank(record_dto.jvh_shipment_date))
                str += "Reference Date Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.jvh_shipment_ref) && !Lib.IsBlank(record_dto.jvh_shipment_date))
                str += "Reference Cannot Be Blank!";

            foreach (acc_ledgerd_dto rec in record_dto.ledger_details!)
            {
                if (Lib.IsBlank(rec.jv_acc_code))
                    acc_code = "A/C Code Cannot Be Blank! ";
                if (Lib.IsZero(rec.jv_dcamt))
                    amt = "Amount Cannot Be Blank! ";
            }

            var isDateValid = CommonLib.IsValidDate(context, record_dto.jvh_year!, record_dto.rec_company_id, record_dto.jvh_date!);
            if (!Lib.IsBlank(isDateValid))
                str += isDateValid;

            if (record_dto.ledger_details!.Count < 2)
            {
                str += "Minimum Two Ledger Line Item Need To Be Entered! ";
            }

            decimal totalDebit = this.FindTotal(record_dto, "DR") ?? 0;
            decimal totalCredit = this.FindTotal(record_dto, "CR") ?? 0;
            // decimal? nBalance = 

            if (totalCredit != totalDebit)
            {
                str += "Debits and Credits Should Be Balanced! ";
            }

            if (acc_code != "")
                str += acc_code;
            if (amt != "")
                str += amt;
            if (carrier != "")
                str += carrier;
            if (ttime != "")
                str += ttime;

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<acc_ledgerh_dto> SaveParentAsync(int id, string mode, acc_ledgerh_dto record_dto)
        {
            acc_ledgerh? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    string prefix = "";
                    string startNo = "";

                    prefix = $"ACCTRANS-{record_dto.jvh_type}-PREFIX";
                    startNo = $"ACCTRANS-{record_dto.jvh_type}-STARTING-NO";
                    
                    var caption = prefix + "," + startNo; // to pass string by coma seprated

                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, caption);// 

                    var DefaultCfNo = 1;
                    var Defaultprefix = "";
                    
                    if (result.ContainsKey(startNo))
                    {
                        DefaultCfNo = Lib.StringToInteger(result[startNo]);
                    }
                    if (result.ContainsKey(prefix))
                    {
                        Defaultprefix = result[prefix].ToString();
                    }
                    if (Lib.IsBlank(Defaultprefix) || Lib.IsZero(DefaultCfNo))
                    {
                        throw new Exception("Missing AccTrans (" + record_dto.jvh_type + ") Prefix/Starting-Number in Branch Settings");
                    }
                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.jvh_type!, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("Voucher Number Cannot Be Generated");
                    }

                    string sinv_no = $"{Defaultprefix}{iNextNo}";  // for setting invoice no by adding branch-settings prefix 

                    Record = new acc_ledgerh();

                    Record.jvh_vrno = iNextNo;
                    Record.jvh_docno = sinv_no;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";

                    Record.jvh_type = record_dto.jvh_type;
                    Record.jvh_status = "POSTED"; // in OP status is always POSTED
                }
                else
                {
                    Record = await context.acc_ledgerh
                        .Where(f => f.jvh_id == id)
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

                Record.jvh_year = record_dto.jvh_year;
                Record.jvh_date = Lib.ParseDateOnly(record_dto.jvh_date!);
                Record.jvh_refno = record_dto.jvh_refno;
                Record.jvh_refdate = Lib.ParseDateOnly(record_dto.jvh_refdate!);
                Record.jvh_remarks = record_dto.jvh_remarks;
                Record.jvh_narration = record_dto.jvh_narration;
                Record.jvh_master_date = Lib.ParseDateOnly(record_dto.jvh_master_date!);
                Record.jvh_is_payroll = record_dto.jvh_is_payroll;
                Record.jvh_shipment_ref = record_dto.jvh_shipment_ref;
                Record.jvh_shipment_date = Lib.ParseDateOnly(record_dto.jvh_shipment_date!);

                if (mode == "add")
                    await context.acc_ledgerh.AddAsync(Record);

                context.SaveChanges();

                record_dto.jvh_id = Record.jvh_id;
                record_dto.jvh_vrno = Record.jvh_vrno;
                record_dto.jvh_docno = Record.jvh_docno;
                record_dto.jvh_status = Record.jvh_status;

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
            }

        }

        public async Task<acc_ledgerh_dto> SaveDetailsAsync(int id, string mode, acc_ledgerh_dto record_dto)
        {
            acc_ledgerd? record;
            List<acc_ledgerd_dto> records_dto;
            List<acc_ledgerd> records;
            try
            {

                records_dto = record_dto.ledger_details!;

                records = await context.acc_ledgerd
                    .Include(c => c.header)
                    .Include(c => c.accounts)
                    .Include(c => c.currency)
                    .Where(w => w.jv_header_id == id)
                    .ToListAsync();

                if (mode == "edit")
                    await logHistoryDetail(records, record_dto);
                
                int nextorder = 1;
                
                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.jv_id == existing_record.jv_id);
                    if (rec == null)
                        context.acc_ledgerd.Remove(existing_record);
                }

                foreach (var rec in records_dto)
                {

                    if (rec.jv_id == 0)
                    {
                        record = new acc_ledgerd();
                        record.rec_company_id = record_dto.rec_company_id;
                        record.rec_branch_id = record_dto.rec_branch_id;
                        record.rec_created_by = record_dto.rec_created_by;
                        record.rec_created_date = DbLib.GetDateTime();
                        record.rec_locked = "N";
                    }
                    else
                    {
                        record = records.Find(f => f.jv_id == rec.jv_id);
                        if (record == null)
                            throw new Exception("Detail Record Not Found " + rec.jv_id.ToString());
                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }
                    record.jv_header_id = id;

                    // same as header
                    record.jv_status = record_dto.jvh_status;
                    record.jv_year = record_dto.jvh_year;
                    record.jv_type = record_dto.jvh_type;
                    record.jv_vrno = record_dto.jvh_vrno;
                    record.jv_docno = record_dto.jvh_docno;
                    record.jv_date = Lib.ParseDateOnly(record_dto.jvh_date!);
                    record.jv_refno = record_dto.jvh_refno;
                    record.jv_refdate = Lib.ParseDateOnly(record_dto.jvh_refdate!);
                    record.jv_shipment_ref = record_dto.jvh_shipment_ref;
                    record.jv_shipment_date = Lib.ParseDateOnly(record_dto.jvh_shipment_date!);
                    record.jv_narration = record_dto.jvh_narration;

                    //separte column only for detail table
                    record.jv_acc_id = rec.jv_acc_id;
                    record.jv_acc_name = rec.jv_acc_name;
                    record.jv_famt = rec.jv_famt;
                    record.jv_cur_id = rec.jv_cur_id;
                    record.jv_exrate = rec.jv_exrate;
                    record.jv_drcr = rec.jv_drcr;
                    record.jv_dcamt = rec.jv_dcamt;
                    if (rec.jv_drcr == "DR")
                    {
                        record.jv_debit = rec.jv_dcamt;
                        record.jv_credit = 0;
                    }
                    if (rec.jv_drcr == "CR")
                    {
                        record.jv_credit = rec.jv_dcamt;
                        record.jv_debit = 0;
                    }
                    record.jv_inv_id = rec.jv_inv_id;
                    record.jv_remarks = rec.jv_remarks;
                    record.jv_doc_type = rec.jv_doc_type;
                    record.jv_bank = rec.jv_bank;
                    record.jv_chqno = rec.jv_chqno;
                    record.jv_chq_date = Lib.ParseDateOnly(rec.jv_chq_date!);
                    record.jv_master_date = Lib.ParseDateOnly(rec.jv_master_date!);
                    record.jv_tax_amt = rec.jv_tax_amt;
                    record.jv_tax_per = rec.jv_tax_per;
                    record.jv_is_payroll = rec.jv_is_payroll;

                    record.jv_ctr = nextorder++;

                    if (rec.jv_id == 0)
                        await context.acc_ledgerd.AddAsync(record);
                }
                context.SaveChanges();
                await UpdateSummary(record_dto);
                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public decimal? FindTotal(acc_ledgerh_dto record_dto, string jv_drcr)
        {
            if (record_dto.ledger_details == null || record_dto.ledger_details.Count == 0)
                return 0;

            decimal? total = record_dto.ledger_details
                    .Where(x => x.jv_drcr == jv_drcr)
                    .Sum(x => x.jv_dcamt);

            return total;
        }

        public async Task   UpdateSummary(acc_ledgerh_dto record_dto)
        {
            try
            {
                // return if rec didnt exist
                if (record_dto.ledger_details == null || record_dto.ledger_details.Count == 0)
                    return;

                decimal totalDebit = this.FindTotal(record_dto, "DR") ?? 0;
                decimal totalCredit = this.FindTotal(record_dto, "CR") ?? 0;

                var header = await context.acc_ledgerh
                    .FirstOrDefaultAsync(x => x.jvh_id == record_dto.jvh_id);

                if (header == null)
                    throw new Exception("Header record not found for summary update.");

                // Update header
                header.jvh_debit = totalDebit;
                header.jvh_credit = totalCredit;
                // header.rec_edited_by = updatedBy;
                // header.rec_edited_date = DbLib.GetDateTime();

                await context.SaveChangesAsync();
                record_dto.jvh_debit = header.jvh_debit;
                record_dto.jvh_credit = header.jvh_credit;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating ledger summary from DTO: " + ex.Message);
            }
        }
        public int GetNextCfNo(int company_id, int? branch_id, string jvh_type, int DefaultCfNo)
        {
            var CfNo = context.acc_ledgerh
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.jvh_type == jvh_type)//&& i.jvh_type == jvh_type
            .Select(e => e.jvh_vrno)
            .DefaultIfEmpty()
            .Max();

            CfNo = CfNo == 0 ? DefaultCfNo : CfNo + 1;
            return CfNo;
        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.acc_ledgerh
                    .Where(f => f.jvh_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    var _Ledgerd = context.acc_ledgerd
                     .Where(c => c.jv_header_id == id);
                    if (_Ledgerd.Any())
                    {
                        context.acc_ledgerd.RemoveRange(_Ledgerd);

                    }
                    context.Remove(_Record);
                    context.SaveChanges();
                    context.Database.CommitTransaction();
                    RetData.Add("status", true);
                    RetData.Add("message", "");
                }
                return RetData;
            }
            catch (Exception Ex)
            {
                context.Database.RollbackTransaction();
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task logHistory(acc_ledgerh old_record, acc_ledgerh_dto record_dto)
        {
            var old_record_dto = new acc_ledgerh_dto
            {
                jvh_id = old_record.jvh_id,
                jvh_vrno = old_record.jvh_vrno,
                jvh_docno = old_record.jvh_docno,
                jvh_type = old_record.jvh_type,
                jvh_date = Lib.FormatDate(old_record.jvh_date, Lib.outputDateFormat),
                jvh_year = old_record.jvh_year,
                jvh_refno = old_record.jvh_refno,
                jvh_refdate = Lib.FormatDate(old_record.jvh_refdate, Lib.outputDateFormat),
                // jvh_status = old_record.jvh_status,
                jvh_remarks = old_record.jvh_remarks,
                jvh_narration = old_record.jvh_narration,
                jvh_shipment_ref = old_record.jvh_shipment_ref,
                jvh_shipment_date = Lib.FormatDate(old_record.jvh_shipment_date, Lib.outputDateFormat),
                jvh_cur_code = old_record.currency?.param_code,
                jvh_exrate = old_record.jvh_exrate,
            };

            await new LogHistorym<acc_ledgerh_dto>(context)
                .Table("acc_ledgerh", log_date)
                .PrimaryKey("inv_id", record_dto.jvh_id)
                .RefNo(record_dto.jvh_docno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("jvh_vrno", "Voucher No")
                .TrackColumn("jvh_docno", "Document No")
                .TrackColumn("jvh_type", "Voucher Type")
                .TrackColumn("jvh_date", "Voucher Date", "date")
                .TrackColumn("jvh_year", "Fin-Year")
                .TrackColumn("jvh_refno", "Inv No")
                .TrackColumn("jvh_refdate", "Inv Date", "date")
                // .TrackColumn("jvh_status", "Status")
                .TrackColumn("jvh_remarks", "Remarks")
                .TrackColumn("jvh_narration", "Narration")
                .TrackColumn("jvh_shipment_ref", "Ref #")
                .TrackColumn("jvh_shipment_date", "Ref. Date", "date")
                .TrackColumn("jvh_cur_code", "Currency")
                .TrackColumn("jvh_exrate", "Ex-Rate", "decimal")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }
        public async Task logHistoryDetail(List<acc_ledgerd> old_records, acc_ledgerh_dto record_dto)
        {
            var old_records_dto = old_records.Select(record => new acc_ledgerd_dto
            {
                jv_id = record.jv_id,
                jv_header_id = record.jv_header_id,
                jv_year = record.jv_year,
                jv_vrno = record.jv_vrno,
                jv_docno = record.jv_docno,
                jv_type = record.jv_type,
                jv_date = Lib.FormatDate(record.jv_date, Lib.outputDateFormat),
                jv_refno = record.jv_refno,
                jv_refdate = Lib.FormatDate(record.jv_refdate, Lib.outputDateFormat),
                jv_acc_id = record.jv_acc_id,
                jv_acc_code = record.accounts?.acc_code,
                jv_acc_name = record.jv_acc_name,
                jv_famt = record.jv_famt,
                jv_cur_id = record.jv_cur_id,
                jv_cur_code = record.currency?.param_code,
                jv_exrate = record.jv_exrate,
                jv_drcr = record.jv_drcr,
                jv_dcamt = record.jv_dcamt,
                jv_debit = record.jv_debit,
                jv_credit = record.jv_credit,
                jv_inv_id = record.jv_inv_id,
                jv_remarks = record.jv_remarks,
                jv_doc_type = record.jv_doc_type,
                jv_bank = record.jv_bank,
                jv_chqno = record.jv_chqno,
                jv_chq_date = Lib.FormatDate(record.jv_chq_date, Lib.outputDateFormat),
                jv_master_date = Lib.FormatDate(record.jv_master_date, Lib.outputDateFormat),
                jv_tax_amt = record.jv_tax_amt,
                jv_tax_per = record.jv_tax_per,
                jv_is_payroll = record.jv_is_payroll,
            }).ToList();

            await new LogHistorym<acc_ledgerd_dto>(context)
                .Table("acc_ledgerh", log_date)
                .PrimaryKey("jv_id", record_dto.jvh_id)
                .RefNo(record_dto.jvh_docno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_edited_by!)
                .TrackColumn("jv_acc_code", "Account Code")// track only data not common in header table 
                .TrackColumn("jv_acc_name", "Account Name")
                .TrackColumn("jv_status", "Status")
                .TrackColumn("jv_famt", "Amount", "decimal")
                .TrackColumn("jv_cur_code", "Currency Code")
                .TrackColumn("jv_exrate", "Exchange Rate", "decimal")
                .TrackColumn("jv_drcr", "Type")
                .TrackColumn("jv_dcamt", "Total Amount", "decimal")
                // .TrackColumn("jv_debit", "Debit", "decimal")
                // .TrackColumn("jv_credit", "Credit", "decimal")
                .TrackColumn("jv_remarks", "Remarks")
                .TrackColumn("jv_narration", "Narration")
                .TrackColumn("jv_doc_type", "Doc Type")
                .TrackColumn("jv_bank", "Bank")
                .TrackColumn("jv_chqno", "Cheque No")
                .TrackColumn("jv_chq_date", "Cheque Date")
                .TrackColumn("jv_master_date", "Master Date")
                .TrackColumn("jv_tax_amt", "Tax Amount", "decimal")
                .TrackColumn("jv_tax_per", "Tax %", "decimal")
                .TrackColumn("jv_is_payroll", "Is Payroll")
                .TrackColumn("jv_ctr", "Counter", "number")
                .SetRecords(old_records_dto, record_dto.ledger_details!)
                .LogChangesAsync();
        }
    }
}
