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
using NPOI.SS.Formula.Functions;

namespace Accounts.Repositories
{
    public class InvoicemRepository : IInvoicemRepository
    {
        private readonly AppDbContext context;
        private DateTime log_date;

        public InvoicemRepository(AppDbContext _context)
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

                var rec_deleted = "";
                var parent_id = 0;
                var company_id = 0;
                var branch_id = 0;

                if (data.ContainsKey("rec_deleted"))
                    rec_deleted = data["rec_deleted"].ToString();
                if (data.ContainsKey("parent_id"))
                    parent_id = int.Parse(data["parent_id"].ToString()!);
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

                IQueryable<acc_invoicem> query = context.acc_invoicem;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id && w.inv_mbl_id == parent_id);

                if (rec_deleted == "N")
                    query = query.Where(w => w.rec_deleted == "N");
                if (rec_deleted == "Y")
                    query = query.Where(w => w.rec_deleted == "Y" || w.rec_deleted == "N");// for showing deleted records

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
                    .OrderBy(c => c.inv_no)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new acc_invoicem_dto
                {
                    inv_id = e.inv_id,
                    inv_date = Lib.FormatDate(e.inv_date, Lib.outputDateFormat),
                    inv_year = e.inv_year,
                    inv_no = e.inv_no,
                    inv_cust_id = e.inv_cust_id,
                    inv_cust_name = e.inv_cust_name,
                    inv_arap = e.inv_arap,
                    inv_mbl_refno = e.inv_mbl_refno,
                    inv_houseno = e.inv_houseno,
                    inv_total = e.inv_total,
                    inv_paid = e.inv_paid,
                    inv_ar_total = e.inv_arap == "A/R" ? e.inv_total : null,
                    inv_ap_total = e.inv_arap == "A/P" ? e.inv_total : null,
                    inv_mbl_id = e.inv_mbl_id,
                    inv_hbl_id = e.inv_hbl_id,
                    inv_balance = e.inv_total - e.inv_paid,
                    rec_deleted = e.rec_deleted,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).ToListAsync();

                // to find sum of inv_paid in AR and AP for calculating balance
                var inv_ar_paid = Records.Where(r => r.inv_arap == "A/R" && r.rec_deleted == "N").Sum(r => r.inv_paid ?? 0);
                var inv_ap_paid = Records.Where(r => r.inv_arap == "A/P" && r.rec_deleted == "N").Sum(r => r.inv_paid ?? 0);

                var summary = await context.cargo_masterm
                .Where(f => f.mbl_id == parent_id)
                .Select(f => new acc_invoicem_dto
                {
                    inv_loss_memo = f.mbl_loss_memo,
                    inv_loss_approved = f.mbl_loss_approved,
                    inv_profit_req = f.mbl_profit_req,
                    inv_bo_status = f.mbl_bo_status,
                    inv_remarks = f.mbl_inv_remarks,
                    inv_mbl_stage = f.shipstage!.param_name ?? "",
                    inv_mbl_refno = f.mbl_refno,
                    inv_inc_total = f.mbl_inc_total ?? 0,
                    inv_exp_total = f.mbl_exp_total ?? 0,
                    inv_revenue = f.mbl_revenue ?? 0,
                    inv_ar_balance = (f.mbl_inc_total ?? 0) - inv_ar_paid,
                    inv_ap_balance = (f.mbl_exp_total ?? 0) - inv_ap_paid
                }).ToListAsync();

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
        public async Task<acc_invoicem_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<acc_invoicem> query = context.acc_invoicem;

                query = query.Where(f => f.inv_id == id);

                var Record = await query.Select(e => new acc_invoicem_dto
                {
                    inv_id = e.inv_id,
                    inv_cfno = e.inv_cfno,
                    inv_no = e.inv_no,
                    inv_date = Lib.FormatDate(e.inv_date, Lib.outputDateFormat),
                    inv_year = e.inv_year,
                    inv_cust_id = e.inv_cust_id,
                    inv_cust_code = e.customer!.cust_code,
                    inv_cust_name = e.inv_cust_name,
                    inv_mbl_refno = e.inv_mbl_refno,
                    inv_arrnotice = e.inv_arrnotice,
                    inv_cust_refno = e.inv_cust_refno,
                    inv_quoteno = e.inv_quoteno,

                    inv_mbl_code = e.master!.mbl_refno,
                    inv_houseno = e.inv_houseno,
                    inv_shipper = e.inv_shipper,
                    inv_consignee = e.inv_consignee,
                    inv_pcs = e.inv_pcs,
                    inv_uom_id = e.inv_uom_id,
                    inv_uom_code = e.unit!.param_code,
                    inv_lbs = e.inv_lbs,
                    inv_kgs = e.inv_kgs,
                    inv_cbm = e.inv_cbm,
                    inv_cft = e.inv_cft,
                    inv_ftotal = e.inv_ftotal,
                    inv_cur_id = e.inv_cur_id,
                    inv_cur_code = e.currency!.param_code,
                    inv_exrate = e.inv_exrate,
                    inv_total = e.inv_total,
                    inv_paid = e.inv_paid,
                    inv_remarks1 = e.inv_remarks1,
                    inv_remarks2 = e.inv_remarks2,
                    inv_remarks3 = e.inv_remarks3,

                    inv_cost_type = e.inv_cost_type,
                    inv_arap = e.inv_arap,
                    inv_type = e.inv_type,
                    inv_mbl_id = e.inv_mbl_id,
                    inv_hbl_id = e.inv_hbl_id,
                    rec_deleted = e.rec_deleted,
                    rec_files_count = e.rec_files_count,
                    rec_files_attached = e.rec_files_attached,
                    rec_check_count = e.rec_check_count,
                    rec_check_attached = e.rec_check_attached,

                    rec_version = e.rec_version,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                    rec_company_id = e.rec_company_id,
                    rec_branch_id = e.rec_branch_id,
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                var result = CommonLib.GetBranchsettings(context,Record!.rec_company_id, Record.rec_branch_id, "EXRATE DECIMAL");

                if (result.ContainsKey("EXRATE DECIMAL"))
                    Record.exrate_decimal = Lib.StringToInteger(result["EXRATE DECIMAL"]);

                Record.invoiced = await GetDetailsAsync(Record.inv_id);
                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<List<acc_invoiced_dto>> GetDetailsAsync(int id)
        {
            var query = from e in context.acc_invoiced
                        .Where(e => e.invd_parent_id == id)
                        .OrderBy(o => o.invd_order)                             // Uncomment if you are using an order field
                        select new acc_invoiced_dto
                        {
                            invd_id = e.invd_id,
                            invd_parent_id = e.invd_parent_id,
                            invd_acc_id = e.invd_acc_id,
                            invd_acc_code = e.account!.acc_code,
                            invd_acc_name = e.invd_acc_name,
                            invd_qty = e.invd_qty,
                            invd_frate = e.invd_frate,
                            invd_ftotal = e.invd_ftotal,
                            invd_cur_id = e.invd_cur_id,
                            invd_cur_code = e.currency!.param_code,
                            invd_exrate = e.invd_exrate,
                            invd_rate = e.invd_rate,
                            invd_total = e.invd_total,
                            invd_remarks = e.invd_remarks,
                            invd_order = e.invd_order, // Uncomment if available

                            rec_branch_id = e.rec_branch_id,
                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        };

            var records = await query.ToListAsync();

            return records;
        }
        public async Task<acc_invoicem_dto> GetDefaultData(int id)
        {
            try
            {
                acc_invoicem_dto? Record_dto = null;

                Record_dto = await context.cargo_masterm
                    .Where(f => f.mbl_id == id)
                    .Select(e => new acc_invoicem_dto
                    {
                        inv_mbl_id = e.mbl_id,
                        inv_mbl_refno = e.mbl_refno,
                        rec_branch_id = e.rec_branch_id,
                        rec_company_id = e.rec_company_id,
                    }).FirstOrDefaultAsync();

                var caption = "CURRENCY,EXRATE DECIMAL";

                var result = CommonLib.GetBranchsettings(context,Record_dto!.rec_company_id, Record_dto.rec_branch_id, caption);

                if (result.ContainsKey("CURRENCY"))
                {
                    Record_dto.inv_cur_id = Lib.StringToInteger(result["CURRENCY"]);

                    var cur = await context.mast_param                                // to get cur_code and exrate using default cur_id
                        .Where(p => p.param_id == Record_dto.inv_cur_id)
                        .FirstOrDefaultAsync();

                    if (cur != null)
                    {
                        Record_dto.inv_cur_code = cur.param_code ?? "";
                        Record_dto.inv_exrate = Lib.StringToDecimal(cur.param_value1 ?? "0");
                    }
                }

                // if (result.ContainsKey("EXRATE DECIMAL"))
                //     Record_dto.exrate_decimal = Lib.StringToInteger(result["EXRATE DECIMAL"]);

                if (Record_dto == null)
                    throw new Exception("No Data Found");

                return Record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<acc_invoicem_dto> GetQtnmlistData(string qtnm_no)
        {
            try
            {
                // acc_invoicem_dto? Record_dto = null;

                var qtnm = await context.mark_qtnm
                    .Include(f=>f.currency)
                    .Where(f => f.qtnm_no == qtnm_no)
                    .FirstOrDefaultAsync();

                if (qtnm == null)
                    throw new Exception("Quotation Not Found");

                var Record = new acc_invoicem_dto
                {
                    inv_cur_id = qtnm!.qtnm_cur_id,
                    inv_cur_code = qtnm.currency!.param_code,
                    inv_exrate = qtnm.qtnm_exrate,
                };

                Record.invoiced = await (
                    from e in context.mark_qtnd_lcl
                        .Where(d => d.qtnd_qtnm_id == qtnm.qtnm_id)
                        .OrderBy(d => d.qtnd_order)
                    select new acc_invoiced_dto
                    {
                        invd_acc_id = e.qtnd_acc_id,
                        invd_acc_code = e.acctm!.acc_code,
                        invd_acc_name = e.qtnd_acc_name,
                        invd_ftotal = e.qtnd_amt,
                        invd_frate = e.qtnd_amt,
                        invd_qty = 1,
                        invd_remarks = e.qtnd_per,
                        invd_cur_id = qtnm.qtnm_cur_id,
                        invd_exrate = qtnm.qtnm_exrate,
                        rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                    }
                ).ToListAsync();

               return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<acc_invoicem_dto> SaveAsync(int id, string mode, acc_invoicem_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                acc_invoicem_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await SaveDetailsAsync(_Record.inv_id, mode, _Record);
                _Record.invoiced = await GetDetailsAsync(_Record.inv_id);
                await CommonLib.UpdateMasterInvoiceSummary(this.context, _Record.inv_mbl_id);
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


        private Boolean AllValid(string mode, acc_invoicem_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";
            string desc = "";
            string qty = "";
            string rate = "";
            string cur = "";
            string exrate = "";

            if (Lib.IsBlank(record_dto.inv_date))
                str += "Date Cannot Be Blank!";
            if (Lib.IsZero(record_dto.inv_year))
                str += "Fin-year Cannot Be Blank!";
            if (Lib.IsZero(record_dto.inv_cust_id))
                str += "Customer Cannot Be Blank!";
            if (Lib.IsZero(record_dto.inv_cur_id))
                str += "Currency Cannot Be Blank!";
            if (Lib.IsZero(record_dto.inv_exrate))
                str += "Ex-Rate Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.inv_mbl_code))
                str += "Master/House Cannot Be Blank!";

            foreach (acc_invoiced_dto rec in record_dto.invoiced!)
            {
                if (Lib.IsZero(rec.invd_acc_id))
                    desc = "Description Cannot Be Blank!";
                if (Lib.IsZero(rec.invd_qty))
                    qty = "Quantity Cannot Be Blank!";
                if (Lib.IsZero(rec.invd_frate))
                    rate = "Rate Cannot Be Blank!";
                if (Lib.IsZero(rec.invd_cur_id))
                    cur = "Currency Cannot Be Blank!";
                if (Lib.IsZero(rec.invd_exrate))
                    exrate = "ExRate Cannot Be Blank!";
            }
            
            var isDateValid = CommonLib.IsValidDate(context, record_dto.inv_year!, record_dto.rec_company_id, record_dto.inv_date!);
            if (!Lib.IsBlank(isDateValid))
                str += isDateValid;

            if (record_dto.invoiced.Count == 0)
            {
                str += "Invoice Line Item Need To Be Entered!";
            }

            if (desc != "")
                str += desc;
            if (qty != "")
                str += qty;
            if (rate != "")
                str += rate;
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

        public async Task<acc_invoicem_dto> SaveParentAsync(int id, string mode, acc_invoicem_dto record_dto)
        {
            acc_invoicem? Record;
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
                    if (record_dto.inv_arap == "A/R")
                    {
                        prefix = "INV-AR-PREFIX";
                        startNo = "INV-AR-STARTING-NO";
                    }
                    if (record_dto.inv_arap == "A/P")
                    {
                        prefix = "INV-AP-PREFIX";
                        startNo = "INV-AP-STARTING-NO";
                    }

                    var caption = prefix + "," + startNo; // to pass string by coma seprated

                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, caption);// 

                    var DefaultCfNo = 0;
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
                        throw new Exception("Missing Invoice (" + record_dto.inv_arap + ") Prefix/Starting-Number in Branch Settings");
                    }

                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("Ref Number Cannot Be Generated");
                    }

                    string sinv_no = $"{Defaultprefix}{iNextNo}";  // for setting invoice no by adding branch-settings prefix 

                    Record = new acc_invoicem();

                    Record.inv_cfno = iNextNo;
                    Record.inv_no = sinv_no;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.acc_invoicem
                        .Include(c => c.customer)
                        .Include(c => c.master)
                        .Include(c => c.unit)
                        .Include(c => c.currency)
                        .Where(f => f.inv_id == id)
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

                Record.inv_date = Lib.ParseDate(record_dto.inv_date!);
                Record.inv_year = record_dto.inv_year;
                Record.inv_cust_id = record_dto.inv_cust_id;
                Record.inv_cust_name = record_dto.inv_cust_name;
                Record.inv_mbl_refno = record_dto.inv_mbl_refno;
                Record.inv_arrnotice = record_dto.inv_arrnotice;
                Record.inv_cust_refno = record_dto.inv_cust_refno;
                Record.inv_quoteno = record_dto.inv_quoteno;

                Record.inv_houseno = record_dto.inv_houseno;
                Record.inv_shipper = record_dto.inv_shipper;
                Record.inv_consignee = record_dto.inv_consignee;
                Record.inv_pcs = record_dto.inv_pcs;
                Record.inv_uom_id = record_dto.inv_uom_id;
                Record.inv_lbs = record_dto.inv_lbs;
                Record.inv_kgs = record_dto.inv_kgs;
                Record.inv_cbm = record_dto.inv_cbm;
                Record.inv_cft = record_dto.inv_cft;
                Record.inv_ftotal = record_dto.inv_ftotal;
                Record.inv_cur_id = record_dto.inv_cur_id;
                Record.inv_exrate = record_dto.inv_exrate;
                Record.inv_total = record_dto.inv_total;
                Record.inv_paid = record_dto.inv_paid;

                Record.inv_remarks1 = record_dto.inv_remarks1;
                Record.inv_remarks2 = record_dto.inv_remarks2;
                Record.inv_remarks3 = record_dto.inv_remarks3;

                Record.inv_cost_type = record_dto.inv_cost_type;
                Record.inv_arap = record_dto.inv_arap;
                Record.inv_type = record_dto.inv_type;
                Record.inv_mbl_id = record_dto.inv_mbl_id;
                Record.inv_hbl_id = record_dto.inv_hbl_id;

                //rec_deleted by default N
                Record.rec_deleted = record_dto.rec_deleted;

                if (mode == "add")
                    await context.acc_invoicem.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.inv_id = Record.inv_id;
                record_dto.inv_no = Record.inv_no;
                record_dto.inv_mbl_id = Record.inv_mbl_id;
                record_dto.inv_hbl_id = Record.inv_hbl_id;

                //Lib.AssignDates2DTO(record_dto.cust_id, mode, Record, record_dto);

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
        public async Task<acc_invoicem_dto> SaveDetailsAsync(int id, string mode, acc_invoicem_dto record_dto)
        {
            acc_invoiced? record;
            List<acc_invoiced_dto> records_dto;
            List<acc_invoiced> records;
            try
            {
                // get details from the frontend
                records_dto = record_dto.invoiced!;
                // read the details from database
                records = await context.acc_invoiced
                    .Include(c => c.account)
                    .Include(c => c.currency)
                    .Where(w => w.invd_parent_id == id)
                    .ToListAsync();

                if (mode == "edit")
                    await logHistoryDetail(records, record_dto);

                int nextorder = 1; // to make list in order of creation 

                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.invd_id == existing_record.invd_id);
                    if (rec == null)
                        context.acc_invoiced.Remove(existing_record);
                }

                foreach (var rec in records_dto)
                {

                    if (rec.invd_id == 0)
                    {
                        record = new acc_invoiced();
                        record.rec_company_id = record_dto.rec_company_id;
                        record.rec_branch_id = record_dto.rec_branch_id;
                        record.rec_created_by = record_dto.rec_created_by;
                        record.rec_created_date = DbLib.GetDateTime();
                        record.rec_locked = "N";
                    }
                    else
                    {
                        record = records.Find(f => f.invd_id == rec.invd_id);
                        if (record == null)
                            throw new Exception("Detail Record Not Found " + rec.invd_id.ToString());
                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }
                    record.invd_parent_id = id;
                    record.invd_acc_id = rec.invd_acc_id;
                    record.invd_acc_name = rec.invd_acc_name;
                    record.invd_remarks = rec.invd_remarks;
                    record.invd_qty = rec.invd_qty;
                    record.invd_frate = rec.invd_frate;
                    record.invd_ftotal = rec.invd_ftotal;
                    record.invd_cur_id = rec.invd_cur_id;
                    record.invd_exrate = rec.invd_exrate;
                    record.invd_rate = rec.invd_rate;
                    record.invd_total = rec.invd_total;
                    record.invd_order = nextorder++;

                    if (rec.invd_id == 0)
                        await context.acc_invoiced.AddAsync(record);
                }
                context.SaveChanges();
                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "fk", "invd_acc_id", "Account type Cannot be blank");
                throw;
            }
        }
        public async Task<acc_invoicem_dto> SaveMemoAsync(int id, acc_invoicem_dto record_dto)
        {
            try
            {
                var masterRecord = await context.cargo_masterm
                .Where(m => m.mbl_id == id)
                .FirstOrDefaultAsync();

                if (masterRecord != null)
                {
                    masterRecord.mbl_loss_memo = record_dto.inv_loss_memo;
                    masterRecord.mbl_loss_approved = record_dto.inv_loss_approved;
                    masterRecord.mbl_profit_req = record_dto.inv_profit_req;
                    masterRecord.mbl_bo_status = record_dto.inv_bo_status;
                    masterRecord.mbl_inv_remarks = record_dto.inv_remarks;
                }

                await context.SaveChangesAsync();

                return record_dto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in saving invoice summary: " + ex.Message);
            }
        }

        public int GetNextCfNo(int company_id, int? branch_id, int DefaultCfNo)
        {
            // int iDefaultCfNo = int.Parse(DefaultCfNo!);

            var CfNo = context.acc_invoicem
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id)
            .Select(e => e.inv_cfno)
            .DefaultIfEmpty()
            .Max();

            CfNo = CfNo == 0 ? DefaultCfNo : CfNo + 1;
            return CfNo;
        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.acc_invoicem
                    .Where(f => f.inv_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                if (_Record!.rec_deleted == "Y")
                {
                    var _InvoiseD = context.acc_invoiced
                     .Where(c => c.invd_parent_id == id);
                    if (_InvoiseD.Any())
                    {
                        context.acc_invoiced.RemoveRange(_InvoiseD);

                    }
                    context.Remove(_Record);
                }
                if (_Record.rec_deleted == "N")
                {
                    _Record.rec_deleted = "Y";
                }
                    context.SaveChanges();
                    await CommonLib.UpdateMasterInvoiceSummary(this.context, _Record.inv_mbl_id);
                    RetData.Add("status", true);
                    RetData.Add("message", "");
                return RetData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Dictionary<string, object>> DeleteDetailsAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.acc_invoicem
                    .Where(f => f.inv_id == id)
                    .FirstOrDefaultAsync();
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    var _InvoiseD = context.acc_invoiced
                     .Where(c => c.invd_parent_id == id);
                    if (_InvoiseD.Any())
                    {
                        context.acc_invoiced.RemoveRange(_InvoiseD);

                    }
                    context.Remove(_Record);
                    context.SaveChanges();
                    await CommonLib.UpdateMasterInvoiceSummary(this.context, _Record.inv_mbl_id);
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
        public async Task logHistory(acc_invoicem old_record, acc_invoicem_dto record_dto)
        {
            var old_record_dto = new acc_invoicem_dto
            {
                inv_id = old_record.inv_id,
                inv_cfno = old_record.inv_cfno,
                inv_no = old_record.inv_no,
                inv_date = Lib.FormatDate(old_record.inv_date, Lib.outputDateFormat),
                inv_year = old_record.inv_year,
                inv_cust_code = old_record.customer?.cust_code,
                inv_cust_name = old_record.inv_cust_name,
                inv_mbl_refno = old_record.inv_mbl_refno,
                inv_arrnotice = old_record.inv_arrnotice,
                inv_cust_refno = old_record.inv_cust_refno,
                inv_quoteno = old_record.inv_quoteno,

                inv_mbl_code = old_record.master?.mbl_refno,
                inv_houseno = old_record.inv_houseno,
                inv_shipper = old_record.inv_shipper,
                inv_consignee = old_record.inv_consignee,
                inv_pcs = old_record.inv_pcs,
                inv_uom_code = old_record.unit?.param_code,
                inv_lbs = old_record.inv_lbs,
                inv_kgs = old_record.inv_kgs,
                inv_cbm = old_record.inv_cbm,
                inv_cft = old_record.inv_cft,
                inv_ftotal = old_record.inv_ftotal,
                inv_cur_code = old_record.currency?.param_code,
                inv_exrate = old_record.inv_exrate,
                inv_total = old_record.inv_total,
                inv_paid = old_record.inv_paid,

                inv_remarks1 = old_record.inv_remarks1,
                inv_remarks2 = old_record.inv_remarks2,
                inv_remarks3 = old_record.inv_remarks3,
                rec_deleted = old_record.rec_deleted,
            };

            await new LogHistorym<acc_invoicem_dto>(context)
                .Table("acc_invoicem", log_date)
                .PrimaryKey("inv_id", record_dto.inv_id)
                .RefNo(record_dto.inv_no!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("inv_no", "Invoice No")
                .TrackColumn("inv_date", "Invoice Date", "date")
                .TrackColumn("inv_year", "Financial Year")
                .TrackColumn("inv_cust_name", "Customer Name")
                .TrackColumn("inv_mbl_refno", "MBL Ref No")
                .TrackColumn("inv_arrnotice", "Arrival Notice")
                .TrackColumn("inv_cust_refno", "Customer Ref No")
                .TrackColumn("inv_quoteno", "Quote No")
                .TrackColumn("inv_houseno", "House No")
                .TrackColumn("inv_shipper", "Shipper")
                .TrackColumn("inv_consignee", "Consignee")
                .TrackColumn("inv_pcs", "PCS", "int")
                .TrackColumn("inv_uom_code", "Unit")
                .TrackColumn("inv_lbs", "LBS", "decimal")
                .TrackColumn("inv_kgs", "KGS", "decimal")
                .TrackColumn("inv_cbm", "CBM", "decimal")
                .TrackColumn("inv_cft", "CFT", "decimal")
                .TrackColumn("inv_ftotal", "Freight Total", "decimal")
                .TrackColumn("inv_cur_code", "Currency")
                .TrackColumn("inv_exrate", "Exchange Rate", "decimal")
                .TrackColumn("inv_total", "Total", "decimal")
                .TrackColumn("inv_paid", "Paid", "decimal")
                .TrackColumn("inv_remarks1", "Remarks 1")
                .TrackColumn("inv_remarks2", "Remarks 2")
                .TrackColumn("inv_remarks3", "Remarks 3")
                .TrackColumn("rec_deleted", "Deleted")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }

        public async Task logHistoryDetail(List<acc_invoiced> old_records, acc_invoicem_dto record_dto)
        {
            var old_records_dto = old_records.Select(e => new acc_invoiced_dto
            {
                invd_id = e.invd_id,
                invd_parent_id = e.invd_parent_id,
                invd_acc_code = e.account?.acc_code,
                invd_acc_name = e.invd_acc_name,
                invd_qty = e.invd_qty,
                invd_frate = e.invd_frate,
                invd_ftotal = e.invd_ftotal,
                invd_cur_code = e.currency?.param_code,
                invd_exrate = e.invd_exrate,
                invd_rate = e.invd_rate,
                invd_total = e.invd_total,
                invd_remarks = e.invd_remarks,
            }).ToList();

            await new LogHistorym<acc_invoiced_dto>(context)
                .Table("acc_invoicem", log_date)
                .PrimaryKey("invd_id", record_dto.inv_id)
                .RefNo(record_dto.inv_no!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_edited_by!)
                .TrackColumn("invd_acc_code", "Account Code")
                .TrackColumn("invd_acc_name", "Account Name")
                .TrackColumn("invd_qty", "Quantity", "decimal")
                .TrackColumn("invd_frate", "Freight Rate", "decimal")
                .TrackColumn("invd_ftotal", "Freight Total", "decimal")
                .TrackColumn("invd_cur_code", "Currency Code")
                .TrackColumn("invd_exrate", "Exchange Rate", "decimal")
                .TrackColumn("invd_rate", "Rate", "decimal")
                .TrackColumn("invd_total", "Total", "decimal")
                .TrackColumn("invd_remarks", "Remarks")
                .SetRecords(old_records_dto, record_dto.invoiced!)
                .LogChangesAsync();
        }
    }
}
