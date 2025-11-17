using Database;
using Database.Lib;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;

using Accounts.Interfaces;
using Database.Models.Accounts;
using Database.Models.BaseTables;
using Common.DTO.Accounts;
using Common.Lib.Accounts;
using Common.Lib;

namespace Accounts.Repositories
{
    public class OpenBalanceRepository : IOpenBalanceRepository
    {
        private readonly AppDbContext context;
        private DateTime log_date;
        // private string stype = "OP";

        public OpenBalanceRepository(AppDbContext _context)
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

                var jv_docno = "";
                var jv_year = 0;
                var company_id = 0;
                var branch_id = 0;

                var jv_type = data["jv_type"].ToString();
                if (data.ContainsKey("jv_docno"))
                    jv_docno = data["jv_docno"].ToString();

                jv_year = Lib.GetValidIntValue(data!, "jv_year", "Fin-Year Not Found");
                company_id = Lib.GetValidIntValue(data!, "rec_company_id", "Company Id Not Found");
                branch_id = Lib.GetValidIntValue(data!, "rec_branch_id", "Branch Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<acc_ledgerd> query = context.acc_ledgerd;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id && w.jv_year == jv_year);//&& w.jv_year == jv_year
                query = query.Where(w => w.jv_type == jv_type);

                if (!Lib.IsBlank(jv_docno))
                {
                    query = query.Where(w => w.jv_docno!.Contains(jv_docno!));
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
                    .OrderBy(c => c.jv_vrno)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new acc_opbalm_dto
                {
                    jv_id = e.jv_id,
                    jv_header_id = e.jv_header_id,
                    jv_date = Lib.FormatDate(e.jv_date, Lib.outputDateFormat),
                    jv_year = e.jv_year,
                    jv_vrno = e.jv_vrno,
                    jv_docno = e.jv_docno,
                    jv_type = e.jv_type,
                    jv_acc_code = e.accounts!.acc_code,
                    jv_acc_name = e.accounts!.acc_name,
                    jv_cur_code = e.currency!.param_code,
                    jv_exrate = e.jv_exrate,
                    jv_credit = e.jv_credit,
                    jv_debit = e.jv_debit,
                    jv_dcamt = e.jv_dcamt,
                    jv_refno = e.jv_refno,
                    jv_refdate = Lib.FormatDate(e.jv_refdate, Lib.outputDateFormat),
                    jv_shipment_ref = e.jv_shipment_ref,
                    jv_shipment_date = Lib.FormatDate(e.jv_shipment_date, Lib.outputDateFormat),
                    jv_narration = e.jv_narration,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),

                }).ToListAsync();

                var summary = new acc_ledgerd_dto
                {
                    jv_debit_total = Records.Sum(x => x.jv_debit ?? 0),
                    jv_credit_total = Records.Sum(x => x.jv_credit ?? 0),
                    jv_balance = Records.Sum(x => x.jv_debit ?? 0) - Records.Sum(x => x.jv_credit ?? 0)
                };

                RetData.Add("records", Records);
                RetData.Add("summary", summary!);
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
                    jvh_docno = e.jvh_docno,
                    jvh_type = e.jvh_type,
                    jvh_date = Lib.FormatDate(e.jvh_date, Lib.outputDateFormat),
                    jvh_refno = e.jvh_refno, //inv_no in header
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
                    throw new Exception("No Data Found");

                Record!.rec_error = CommonLib.IsYearLocked(context, Record.jvh_year, Record.rec_company_id, Record.rec_locked!);

                Record.ledger_detail = await GetDetailsAsync(Record.jvh_id);
                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<acc_ledgerd_dto> GetDetailsAsync(int id)
        {
            var query = from e in context.acc_ledgerd
                        .Where(e => e.jv_header_id == id)
                        .OrderBy(o => o.jv_ctr)
                            // Uncomment if you are using an order field
                        select new acc_ledgerd_dto
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
                            jv_acc_name = e.accounts!.acc_name,
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
                            jv_is_payroll = e.jv_is_payroll,

                            rec_branch_id = e.rec_branch_id,
                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        };

            var records = await query.FirstOrDefaultAsync();

            return records!;
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

                    var cur = await context.mast_param                                // to get cur_code and exrate using default cur_id
                        .Where(p => p.param_id == Record_dto!.ledger_detail!.jv_cur_id)
                        .FirstOrDefaultAsync();

                    if (cur != null)
                    {
                        Record_dto!.ledger_detail!.jv_cur_code = cur.param_code ?? "";
                        Record_dto!.ledger_detail!.jv_exrate = Lib.StringToDecimal(cur.param_value1 ?? "0");
                    }
                }

                if (Record_dto == null)
                    throw new Exception("No Data Found");

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
                context.Database.CommitTransaction();
                return _Record;
            }
            catch (DbUpdateConcurrencyException)
            {
                context.Database.RollbackTransaction();
                throw new Exception("Kindly reload the record, Another User May have modified the same record");
            }

            catch (Exception Ex)
            {
                context.Database.RollbackTransaction();
                // throw;
                throw new Exception(Ex.Message.ToString());
            }
        }


        private Boolean AllValid(string mode, acc_ledgerh_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";
            string cur = "";
            string exrate = "";

            if (Lib.IsBlank(record_dto.jvh_date))
                str += "Date Cannot Be Blank!";
            if (Lib.IsZero(record_dto.jvh_year))
                str += "Fin-year Cannot Be Blank!";
            if (!Lib.IsBlank(record_dto.jvh_refno) && Lib.IsBlank(record_dto.jvh_refdate))
                str += "inv.date Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.jvh_refno) && !Lib.IsBlank(record_dto.jvh_refdate))
                str += "inv.no Cannot Be Blank!";
            if (!Lib.IsBlank(record_dto.jvh_shipment_ref) && Lib.IsBlank(record_dto.jvh_shipment_date))
                str += "Reference Date Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.jvh_shipment_ref) && !Lib.IsBlank(record_dto.jvh_shipment_date))
                str += "Reference Cannot Be Blank!";

            if (record_dto.ledger_detail != null)
            {
                if (Lib.IsZero(record_dto.ledger_detail.jv_acc_id))
                    str += "A/C Code Cannot Be Blank!";
                if (Lib.IsZero(record_dto.ledger_detail.jv_famt))
                    str += "Amount Cannot Be Blank!";
                if (Lib.IsZero(record_dto.ledger_detail.jv_cur_id))
                    str += "Currency Cannot Be Blank!";
                if (Lib.IsZero(record_dto.ledger_detail.jv_exrate))
                    str += "Exrate Cannot Be Blank!";
            }
            
            var isDateValid = CommonLib.IsValidDate(context, record_dto.jvh_year!, record_dto.rec_company_id, record_dto.jvh_date!);
            if (!Lib.IsBlank(isDateValid))
                str += isDateValid;
            
            if (Lib.IsBlank(record_dto.jvh_narration))
                str += "Narration Cannot Be Blank!";

            if (cur != "")
                str += cur;
            if (exrate != "")
                str += exrate;

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
                    //if prefix and starting no: provided in branch settings
                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, "OPENING-BALANCE-PREFIX,OPENING-BALANCE-STARTING-NO");

                    var DefaultCfNo = 1;
                    var Defaultprefix = "OP-";

                    if (result.ContainsKey("OPENING-BALANCE-STARTING-NO"))
                    {
                        DefaultCfNo = Lib.StringToInteger(result["OPENING-BALANCE-STARTING-NO"]);
                    }
                    if (result.ContainsKey("OPENING-BALANCE-PREFIX"))
                    {
                        Defaultprefix = result["OPENING-BALANCE-PREFIX"].ToString();
                    }
                    if (Lib.IsBlank(Defaultprefix) || Lib.IsZero(DefaultCfNo))
                    {
                        throw new Exception("Missing Opening Balance Prefix/Starting-Number in Branch Settings");
                    }

                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.jvh_type!, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("Ref Number Cannot Be Generated");
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

                await context.SaveChangesAsync();

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
            acc_ledgerd_dto? records_dto;
            acc_ledgerd? records;
            try
            {
                // get details from the frontend
                records_dto = record_dto.ledger_detail!;
                // read the details from database
                records = await context.acc_ledgerd
                    .Include(c => c.header)
                    .Include(c => c.accounts)
                    .Include(c => c.currency)
                    .Where(w => w.jv_header_id == id)
                    .FirstOrDefaultAsync();

                if (mode == "edit")
                    await logHistoryDetail(records!, record_dto);


                if (records_dto.jv_id == 0)
                {
                    record = new acc_ledgerd();
                    record.rec_company_id = record_dto.rec_company_id;
                    record.rec_branch_id = record_dto.rec_branch_id;
                    record.rec_created_by = record_dto.rec_created_by;
                    record.rec_created_date = DbLib.GetDateTime();
                    record.rec_locked = "N";
                    record.jv_type = record_dto.jvh_type;
                }
                else
                {
                    record = records;
                    if (record == null)
                        throw new Exception("Detail Record Not Found " + records!.jv_id.ToString());
                    record.rec_edited_by = record_dto.rec_created_by;
                    record.rec_edited_date = DbLib.GetDateTime();
                }

                record.jv_header_id = id;
                // same as header
                record.jv_status = record_dto.jvh_status;
                record.jv_year = record_dto.jvh_year;
                record.jv_vrno = record_dto.jvh_vrno;
                record.jv_docno = record_dto.jvh_docno;
                record.jv_date = Lib.ParseDateOnly(record_dto.jvh_date!);
                record.jv_refno = record_dto.jvh_refno;
                record.jv_refdate = Lib.ParseDateOnly(record_dto.jvh_refdate!);
                record.jv_shipment_ref = record_dto.jvh_shipment_ref;
                record.jv_shipment_date = Lib.ParseDateOnly(record_dto.jvh_shipment_date!);
                record.jv_narration = record_dto.jvh_narration;

                //separte column only for detail table
                record.jv_acc_id = records_dto.jv_acc_id;
                record.jv_famt = records_dto.jv_famt;
                record.jv_cur_id = records_dto.jv_cur_id;
                record.jv_exrate = records_dto.jv_exrate;
                record.jv_drcr = records_dto.jv_drcr;
                record.jv_dcamt = records_dto.jv_dcamt;
                if (records_dto.jv_drcr == "DR")
                {
                    record.jv_debit = records_dto.jv_dcamt;
                    record.jv_credit = 0;
                }
                if (records_dto.jv_drcr == "CR")
                {
                    record.jv_credit = records_dto.jv_dcamt;
                    record.jv_debit = 0;
                }
                record.jv_inv_id = records_dto.jv_inv_id;
                record.jv_remarks = records_dto.jv_remarks;
                record.jv_doc_type = records_dto.jv_doc_type;
                record.jv_bank = records_dto.jv_bank;
                record.jv_chqno = records_dto.jv_chqno;
                record.jv_chq_date = Lib.ParseDateOnly(records_dto.jv_chq_date!);
                record.jv_master_date = Lib.ParseDateOnly(records_dto.jv_master_date!);
                record.jv_is_payroll = records_dto.jv_is_payroll;
                record.jv_ctr = records_dto.jv_ctr;

                if (records_dto.jv_id == 0)
                    await context.acc_ledgerd.AddAsync(record);

                context.SaveChanges();

                records_dto.jv_year = record.jv_year;
                records_dto.jv_credit = record.jv_credit;
                records_dto.jv_debit = record.jv_debit;

                return record_dto;
            }
            catch (Exception Ex)
            {
                // Lib.getErrorMessage(Ex, "fk", "jv_acc_id", "Account type Cannot be blank");
                throw new Exception(Ex.Message.ToString());
            }
        }
        public int GetNextCfNo(int company_id, int? branch_id, string jvh_type,int DefaultCfNo)
        {
            // int iDefaultCfNo = int.Parse(DefaultCfNo!);

            var CfNo = context.acc_ledgerh
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.jvh_type == jvh_type)
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
                    var _ledgerd = context.acc_ledgerd
                    .Where(c => c.jv_header_id == id);
                    if (_ledgerd.Any())
                    {
                        context.acc_ledgerd.RemoveRange(_ledgerd);
                    }
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
                jvh_status = old_record.jvh_status,
                jvh_remarks = old_record.jvh_remarks,
                jvh_narration = old_record.jvh_narration,
                jvh_master_date = Lib.FormatDate(old_record.jvh_master_date, Lib.outputDateFormat),
                jvh_is_payroll = old_record.jvh_is_payroll,
                jvh_shipment_ref = old_record.jvh_shipment_ref,
                jvh_shipment_date = Lib.FormatDate(old_record.jvh_shipment_date, Lib.outputDateFormat),

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
                .TrackColumn("jvh_status", "Status")
                .TrackColumn("jvh_remarks", "Remarks")
                .TrackColumn("jvh_narration", "Narration")
                .TrackColumn("jvh_master_date", "Master Date", "date")
                .TrackColumn("jvh_is_payroll", "Is Payroll")
                .TrackColumn("jvh_shipment_ref", "Ref #")
                .TrackColumn("jvh_shipment_date", "Ref. Date", "date")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }

        public async Task logHistoryDetail(acc_ledgerd old_records, acc_ledgerh_dto record_dto)
        {
            var old_records_dto = new acc_ledgerd_dto
            {
                jv_id = old_records.jv_id,
                jv_header_id = old_records.jv_header_id,
                jv_year = old_records.jv_year,
                jv_vrno = old_records.jv_vrno,
                jv_docno = old_records.jv_docno,
                jv_type = old_records.jv_type,
                jv_date = Lib.FormatDate(old_records.jv_date, Lib.outputDateFormat),
                jv_refno = old_records.jv_refno,
                jv_refdate = Lib.FormatDate(old_records.jv_refdate, Lib.outputDateFormat),
                jv_acc_id = old_records.jv_acc_id,
                jv_acc_code = old_records.accounts?.acc_code,
                jv_acc_name = old_records.accounts?.acc_name,
                jv_famt = old_records.jv_famt,
                jv_cur_id = old_records.jv_cur_id,
                jv_cur_code = old_records.currency?.param_code,
                jv_exrate = old_records.jv_exrate,
                jv_drcr = old_records.jv_drcr,
                jv_dcamt = old_records.jv_dcamt,
                jv_debit = old_records.jv_debit,
                jv_credit = old_records.jv_credit,
                jv_inv_id = old_records.jv_inv_id,
                jv_remarks = old_records.jv_remarks,
                jv_doc_type = old_records.jv_doc_type,
                jv_bank = old_records.jv_bank,
                jv_chqno = old_records.jv_chqno,
                jv_chq_date = Lib.FormatDate(old_records.jv_chq_date, Lib.outputDateFormat),
                jv_master_date = Lib.FormatDate(old_records.jv_master_date, Lib.outputDateFormat),
                jv_is_payroll = old_records.jv_is_payroll,
            };

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
                .TrackColumn("jv_debit", "Debit", "decimal")
                .TrackColumn("jv_credit", "Credit", "decimal")
                .TrackColumn("jv_remarks", "Remarks")
                .TrackColumn("jv_narration", "Narration")
                .TrackColumn("jv_doc_type", "Doc Type")
                .TrackColumn("jv_bank", "Bank")
                .TrackColumn("jv_chqno", "Cheque No")
                .TrackColumn("jv_chq_date", "Cheque Date")
                .TrackColumn("jv_master_date", "Master Date")
                .TrackColumn("jv_is_payroll", "Is Payroll")
                .TrackColumn("jv_ctr", "Counter", "number")
                .SetRecord(old_records_dto, record_dto.ledger_detail!)
                .LogChangesAsync();
        }
    }
}
