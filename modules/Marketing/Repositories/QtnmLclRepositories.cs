using Database;
using Database.Lib;
using Common.DTO.Masters;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Marketing.Interfaces;
using Database.Models.Marketing;
using Common.DTO.Marketing;
using Common.Lib;

//Name : Sourav V
//Created Date : 03/01/2025
//Remark : this file defines functions like Save, Delete, getList and getRecords which save/retrieve data

namespace Marketing.Repositories
{
    public class QtnmLclRepository : IQtnmLclRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private string sqtnm_type = "LCL";
        private DateTime log_date;

        public QtnmLclRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var qtnm_from_date = "";
                var qtnm_to_date = "";
                var qtnm_type = "";
                var qtnm_to_name = "";
                var qtnm_no = "";
                var qtnm_pld_name = "";
                var company_id = 0;
                var branch_id = 0;
                DateTime? from_date = null;
                DateTime? to_date = null;

                if (data.ContainsKey("qtnm_type"))
                    qtnm_type = data["qtnm_type"].ToString();
                if (data.ContainsKey("qtnm_from_date"))
                    qtnm_from_date = data["qtnm_from_date"].ToString();
                if (data.ContainsKey("qtnm_to_date"))
                    qtnm_to_date = data["qtnm_to_date"].ToString();
                if (data.ContainsKey("qtnm_to_name"))
                    qtnm_to_name = data["qtnm_to_name"].ToString();
                if (data.ContainsKey("qtnm_no"))
                    qtnm_no = data["qtnm_no"].ToString();
                if (data.ContainsKey("qtnm_pld_name"))
                    qtnm_pld_name = data["qtnm_pld_name"].ToString();
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

                IQueryable<mark_qtnm> query = context.mark_qtnm;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.qtnm_type == sqtnm_type);


                if (!Lib.IsBlank(qtnm_from_date))
                {
                    from_date = Lib.ParseDate(qtnm_from_date!);
                    query = query.Where(w => w.qtnm_date >= from_date);
                }
                if (!Lib.IsBlank(qtnm_to_date))
                {
                    to_date = Lib.ParseDate(qtnm_to_date!);
                    query = query.Where(w => w.qtnm_date <= to_date);
                }
                if (!Lib.IsBlank(qtnm_to_name))
                    query = query.Where(w => w.qtnm_to_name!.Contains(qtnm_to_name!));
                if (!Lib.IsBlank(qtnm_no))
                    query = query.Where(w => w.qtnm_no!.Contains(qtnm_no!));
                if (!Lib.IsBlank(qtnm_pld_name))
                    query = query.Where(w => w.qtnm_pld_name!.Contains(qtnm_pld_name!));


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
                    .OrderBy(c => c.qtnm_cfno)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mark_qtnm_dto
                {
                    qtnm_id = e.qtnm_id,
                    qtnm_cfno = e.qtnm_cfno,
                    qtnm_type = e.qtnm_type,
                    qtnm_no = e.qtnm_no,
                    qtnm_to_id = e.qtnm_to_id,
                    qtnm_to_code = e.customer!.cust_code,
                    qtnm_to_name = e.qtnm_to_name,
                    qtnm_to_addr1 = e.qtnm_to_addr1,
                    qtnm_to_addr2 = e.qtnm_to_addr2,
                    qtnm_to_addr3 = e.qtnm_to_addr3,
                    qtnm_to_addr4 = e.qtnm_to_addr4,
                    qtnm_date = Lib.FormatDate(e.qtnm_date, Lib.outputDateFormat),
                    qtnm_quot_by = e.qtnm_quot_by,
                    qtnm_valid_date = Lib.FormatDate(e.qtnm_valid_date, Lib.outputDateFormat),
                    qtnm_salesman_id = e.qtnm_salesman_id,
                    qtnm_salesman_name = e.salesman!.param_name,
                    qtnm_move_type = e.qtnm_move_type,
                    qtnm_commodity = e.qtnm_commodity,
                    qtnm_package = e.qtnm_package,
                    qtnm_kgs = e.qtnm_kgs,
                    qtnm_lbs = e.qtnm_lbs,
                    qtnm_cbm = e.qtnm_cbm,
                    qtnm_cft = e.qtnm_cft,
                    qtnm_por_id = e.qtnm_por_id,
                    qtnm_por_code = e.por!.param_code,
                    qtnm_por_name = e.qtnm_por_name,
                    qtnm_pol_id = e.qtnm_pol_id,
                    qtnm_pol_code = e.pol!.param_code,
                    qtnm_pol_name = e.qtnm_pol_name,
                    qtnm_pod_id = e.qtnm_pod_id,
                    qtnm_pod_code = e.pod!.param_code,
                    qtnm_pod_name = e.qtnm_pod_name,
                    qtnm_pld_name = e.qtnm_pld_name,
                    qtnm_plfd_name = e.qtnm_plfd_name,
                    qtnm_trans_time = e.qtnm_trans_time,
                    qtnm_routing = e.qtnm_routing,
                    qtnm_amt = e.qtnm_amt,


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
        public async Task<mark_qtnm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<mark_qtnm> query = context.mark_qtnm;

                query = query.Where(f => f.qtnm_id == id);

                var Record = await query.Select(e => new mark_qtnm_dto
                {
                    qtnm_id = e.qtnm_id,
                    qtnm_cfno = e.qtnm_cfno,
                    qtnm_type = e.qtnm_type,
                    qtnm_no = e.qtnm_no,
                    qtnm_to_id = e.qtnm_to_id,
                    qtnm_to_code = e.customer!.cust_code,
                    qtnm_to_name = e.qtnm_to_name,
                    qtnm_to_addr1 = e.qtnm_to_addr1,
                    qtnm_to_addr2 = e.qtnm_to_addr2,
                    qtnm_to_addr3 = e.qtnm_to_addr3,
                    qtnm_to_addr4 = e.qtnm_to_addr4,
                    qtnm_date = Lib.FormatDate(e.qtnm_date, Lib.outputDateFormat),
                    qtnm_quot_by = e.qtnm_quot_by,
                    qtnm_valid_date = Lib.FormatDate(e.qtnm_valid_date, Lib.outputDateFormat),
                    qtnm_salesman_id = e.qtnm_salesman_id,
                    qtnm_salesman_name = e.salesman!.param_name,
                    qtnm_move_type = e.qtnm_move_type,
                    qtnm_commodity = e.qtnm_commodity,
                    qtnm_package = e.qtnm_package,
                    qtnm_kgs = e.qtnm_kgs,
                    qtnm_lbs = e.qtnm_lbs,
                    qtnm_cbm = e.qtnm_cbm,
                    qtnm_cft = e.qtnm_cft,
                    qtnm_por_id = e.qtnm_por_id,
                    qtnm_por_code = e.por!.param_code,
                    qtnm_por_name = e.qtnm_por_name,
                    qtnm_pol_id = e.qtnm_pol_id,
                    qtnm_pol_code = e.pol!.param_code,
                    qtnm_pol_name = e.qtnm_pol_name,
                    qtnm_pod_id = e.qtnm_pod_id,
                    qtnm_pod_code = e.pod!.param_code,
                    qtnm_pod_name = e.qtnm_pod_name,
                    qtnm_pld_name = e.qtnm_pld_name,
                    qtnm_plfd_name = e.qtnm_plfd_name,
                    qtnm_trans_time = e.qtnm_trans_time,
                    qtnm_routing = e.qtnm_routing,
                    qtnm_amt = e.qtnm_amt,

                    rec_version = e.rec_version,
                    rec_branch_id = e.rec_branch_id,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Qtn Found");

                Record.qtnd_lcl = await GetDetailsAsync(Record.qtnm_id);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<mark_qtnd_lcl_dto>> GetDetailsAsync(int id)
        {
            var query = from e in context.mark_qtnd_lcl
                        .Where(e => e.qtnd_qtnm_id == id)
                        .OrderBy(o => o.qtnd_order)
                        select (new mark_qtnd_lcl_dto
                        {
                            qtnd_id = e.qtnd_id,
                            qtnd_qtnm_id = e.qtnd_qtnm_id,
                            qtnd_acc_id = e.qtnd_acc_id,
                            qtnd_acc_code = e.acctm!.acc_code,
                            qtnd_acc_name = e.qtnd_acc_name,
                            qtnd_amt = e.qtnd_amt,
                            qtnd_per = e.qtnd_per,
                            qtnd_order = e.qtnd_order,

                            rec_branch_id = e.rec_branch_id,
                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        });

            var records = await query.ToListAsync();

            return records;
        }


        public async Task<mark_qtnm_dto> SaveAsync(int id, string mode, mark_qtnm_dto record_dto)
        {
            try
            {
                log_date = DateTime.UtcNow;

                context.Database.BeginTransaction();
                mark_qtnm_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await SaveDetailsAsync(_Record.qtnm_id, mode, _Record);
                _Record.qtnd_lcl = await GetDetailsAsync(_Record.qtnm_id);
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


        private Boolean AllValid(string mode, mark_qtnm_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            string code = "";
            string name = "";
            string per = "";

            if (Lib.IsZero(record_dto.qtnm_to_id))
                str += "Quote To Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.qtnm_date))
                str += "Quote Date Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.qtnm_quot_by))
                str += "Quote By Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.qtnm_valid_date))
                str += "Validity Cannot Be Blank!";
            if (Lib.IsZero(record_dto.qtnm_salesman_id))
                str += "Sales Rep. Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.qtnm_move_type))
                str += "Move Type Cannot Be Blank!";

            foreach (mark_qtnd_lcl_dto rec in record_dto.qtnd_lcl!)
            {
                if (Lib.IsBlank(rec.qtnd_acc_code))
                    code = "Code Cannot Be Blank!";
                if (Lib.IsBlank(rec.qtnd_acc_name))
                    name = "Description Cannot Be Blank!";
                if (Lib.IsZero(rec.qtnd_amt) && Lib.IsBlank(rec.qtnd_per))
                    per = "Per Cannot Be Blank";
            }

            if (record_dto.qtnd_lcl.Count == 0)
            {
                str += "Quotation Line Item Need To Be Entered";
            }

            decimal? nTotal = this.FindTotal(record_dto);                   //find sum of each detail amount

            if (record_dto.qtnm_amt != nTotal)
            {
                str += " Qtnm total and Qtnd line item total does not match";
            }

            if (code != "")
                str += code;
            if (name != "")
                str += name;
            if (per != "")
                str += per;

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<mark_qtnm_dto> SaveParentAsync(int id, string mode, mark_qtnm_dto record_dto)
        {
            mark_qtnm? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, "QUOTATION-LCL-PREFIX,QUOTATION-LCL-STARTING-NO");// 

                    var DefaultCfNo = 0;
                    var Defaultprefix = "";

                    if (result.ContainsKey("QUOTATION-LCL-STARTING-NO"))
                    {
                        DefaultCfNo = Lib.StringToInteger(result["QUOTATION-LCL-STARTING-NO"]);
                    }
                    if (result.ContainsKey("QUOTATION-LCL-PREFIX"))
                    {
                        Defaultprefix = result["QUOTATION-LCL-PREFIX"].ToString();
                    }
                    if (Lib.IsBlank(Defaultprefix) || Lib.IsZero(DefaultCfNo))
                    {
                        throw new Exception("Missing Quotation Prefix/Starting-Number in Branch Settings");
                    }

                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("Quotation Number Cannot Be Generated");
                    }


                    string sqtn_no = $"{Defaultprefix}{iNextNo}";  // for setting quote no by adding propper prefix (here QL - Quotation LCL)
                    string stype = sqtnm_type;

                    Record = new mark_qtnm();
                    Record.qtnm_cfno = iNextNo;
                    Record.qtnm_no = sqtn_no;
                    Record.qtnm_type = stype;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.mark_qtnm
                        .Where(f => f.qtnm_id == id)
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

                Record.qtnm_to_id = record_dto.qtnm_to_id;
                Record.qtnm_to_name = record_dto.qtnm_to_name;
                Record.qtnm_to_addr1 = record_dto.qtnm_to_addr1;
                Record.qtnm_to_addr2 = record_dto.qtnm_to_addr2;
                Record.qtnm_to_addr3 = record_dto.qtnm_to_addr3;
                Record.qtnm_to_addr4 = record_dto.qtnm_to_addr4;
                Record.qtnm_date = Lib.ParseDate(record_dto.qtnm_date!);
                Record.qtnm_quot_by = record_dto.qtnm_quot_by;
                Record.qtnm_valid_date = Lib.ParseDate(record_dto.qtnm_valid_date!);
                Record.qtnm_salesman_id = record_dto.qtnm_salesman_id;
                Record.qtnm_move_type = record_dto.qtnm_move_type;
                Record.qtnm_commodity = record_dto.qtnm_commodity;
                Record.qtnm_package = record_dto.qtnm_package;
                Record.qtnm_kgs = record_dto.qtnm_kgs;
                Record.qtnm_lbs = record_dto.qtnm_lbs;
                Record.qtnm_cbm = record_dto.qtnm_cbm;
                Record.qtnm_cft = record_dto.qtnm_cft;
                if (Lib.IsZero(record_dto.qtnm_por_id))
                    Record.qtnm_por_id = null;
                else
                    Record.qtnm_por_id = record_dto.qtnm_por_id;
                Record.qtnm_por_name = record_dto.qtnm_por_name;
                if (Lib.IsZero(record_dto.qtnm_pol_id))
                    Record.qtnm_pol_id = null;
                else
                    Record.qtnm_pol_id = record_dto.qtnm_pol_id;
                Record.qtnm_pol_name = record_dto.qtnm_pol_name;
                if (Lib.IsZero(record_dto.qtnm_pod_id))
                    Record.qtnm_pod_id = null;
                else
                    Record.qtnm_pod_id = record_dto.qtnm_pod_id;
                Record.qtnm_pod_name = record_dto.qtnm_pod_name;
                Record.qtnm_pld_name = record_dto.qtnm_pld_name;
                Record.qtnm_plfd_name = record_dto.qtnm_plfd_name;
                Record.qtnm_trans_time = record_dto.qtnm_trans_time;
                Record.qtnm_routing = record_dto.qtnm_routing;
                Record.qtnm_amt = record_dto.qtnm_amt ?? 0;

                if (mode == "add")
                    await context.mark_qtnm.AddAsync(Record);


                context.SaveChanges();
                record_dto.qtnm_id = Record.qtnm_id;
                record_dto.qtnm_no = Record.qtnm_no;
                record_dto.qtnm_amt = Record.qtnm_amt;

                record_dto.rec_version = Record.rec_version;
                Lib.AssignDates2DTO(id, mode, Record, record_dto);
                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }

        }

        public async Task<mark_qtnm_dto> SaveDetailsAsync(int id, string mode,mark_qtnm_dto record_dto)
        {
            mark_qtnd_lcl? record;
            List<mark_qtnd_lcl_dto> records_dto;
            List<mark_qtnd_lcl> records;
            try
            {

                records_dto = record_dto.qtnd_lcl!;

                records = await context.mark_qtnd_lcl
                    .Where(w => w.qtnd_qtnm_id == id)
                    .ToListAsync();

                // if(mode == "edit")
                    // await logHistoryDetail(records, record_dto);
                int nextorder = 1;

                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.qtnd_id == existing_record.qtnd_id);
                    if (rec == null)
                        context.mark_qtnd_lcl.Remove(existing_record);
                }

                foreach (var rec in records_dto)
                {

                    if (rec.qtnd_id == 0)
                    {
                        record = new mark_qtnd_lcl();
                        record.rec_company_id = record_dto.rec_company_id;
                        record.rec_branch_id = record_dto.rec_branch_id;
                        record.rec_created_by = record_dto.rec_created_by;
                        record.rec_created_date = DbLib.GetDateTime();
                    }
                    else
                    {
                        record = records.Find(f => f.qtnd_id == rec.qtnd_id);
                        if (record == null)
                            throw new Exception("Detail Record Not Found " + rec.qtnd_id.ToString());
                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }
                    record.qtnd_qtnm_id = id;
                    record.qtnd_acc_id = rec.qtnd_acc_id;
                    record.qtnd_acc_name = rec.qtnd_acc_name;
                    record.qtnd_amt = rec.qtnd_amt ?? 0;
                    record.qtnd_per = rec.qtnd_per;
                    record.qtnd_order = nextorder++;

                    if (rec.qtnd_id == 0)
                        await context.mark_qtnd_lcl.AddAsync(record);
                }
                context.SaveChanges();
                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "fk", "qtnd_acc_id", "Account type Cannot be blank");
                throw;
            }
        }
        public int GetNextCfNo(int company_id, int? branch_id, int DefaultCfNo)
        {
            // int iDefaultCfNo = int.Parse(DefaultCfNo!);

            var CfNo = context.mark_qtnm
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.qtnm_type == sqtnm_type)
            .Select(e => e.qtnm_cfno)
            .DefaultIfEmpty()
            .Max();

            CfNo = CfNo == 0 ? DefaultCfNo : CfNo + 1;
            return CfNo;
        }
        public decimal? FindTotal(mark_qtnm_dto record_dto)   // used to find total amount from each records
        {
            decimal nTotal = record_dto.qtnd_lcl!.Sum(x => x.qtnd_amt) ?? 0;
            return nTotal;
        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mark_qtnm
                    .Where(f => f.qtnm_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    var _Quote = context.mark_qtnd_lcl
                     .Where(c => c.qtnd_qtnm_id == id);
                    if (_Quote.Any())
                    {
                        context.mark_qtnd_lcl.RemoveRange(_Quote);

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
        public async Task logHistory(mark_qtnm old_record, mark_qtnm_dto record_dto)
        {

            var new_record = new mark_qtnm
            {
                qtnm_id = record_dto.qtnm_id,
                qtnm_cfno = record_dto.qtnm_cfno,
                qtnm_no = record_dto.qtnm_no,
                qtnm_to_name = record_dto.qtnm_to_name,
                qtnm_to_addr1 = record_dto.qtnm_to_addr1,
                qtnm_to_addr2 = record_dto.qtnm_to_addr2,
                qtnm_to_addr3 = record_dto.qtnm_to_addr3,
                qtnm_to_addr4 = record_dto.qtnm_to_addr4,
                qtnm_date = Lib.ParseDate(record_dto.qtnm_date!),
                qtnm_quot_by = record_dto.qtnm_quot_by,
                qtnm_valid_date = Lib.ParseDate(record_dto.qtnm_valid_date!),
                qtnm_move_type = record_dto.qtnm_move_type,
                qtnm_commodity = record_dto.qtnm_commodity,
                qtnm_package = record_dto.qtnm_package,
                qtnm_kgs = record_dto.qtnm_kgs,
                qtnm_lbs = record_dto.qtnm_lbs,
                qtnm_cbm = record_dto.qtnm_cbm,
                qtnm_cft = record_dto.qtnm_cft,
                qtnm_por_name = record_dto.qtnm_por_name,
                qtnm_pol_name = record_dto.qtnm_pol_name,
                qtnm_pod_name = record_dto.qtnm_pod_name,
                qtnm_pld_name = record_dto.qtnm_pld_name,
                qtnm_plfd_name = record_dto.qtnm_plfd_name,
                qtnm_trans_time = record_dto.qtnm_trans_time,
                qtnm_routing = record_dto.qtnm_routing,
                qtnm_amt = record_dto.qtnm_amt ?? 0
            };

            await new LogHistory<mark_qtnm>(context)
                .Table("mark_qtnm", log_date)
                .PrimaryKey("qtnm_id", record_dto.qtnm_id)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("qtnm_cfno", "CF-No")
                .TrackColumn("qtnm_no", "Quotation-No")
                .TrackColumn("qtnm_to_name", "To Name")
                .TrackColumn("qtnm_to_addr1", "To Address 1")
                .TrackColumn("qtnm_to_addr2", "To Address 2")
                .TrackColumn("qtnm_to_addr3", "To Address 3")
                .TrackColumn("qtnm_to_addr4", "To Address 4")
                .TrackColumn("qtnm_date", "Quotation Date")
                .TrackColumn("qtnm_quot_by", "Quoted By")
                .TrackColumn("qtnm_valid_date", "Valid Until")
                .TrackColumn("qtnm_move_type", "Move Type")
                .TrackColumn("qtnm_commodity", "Commodity")
                .TrackColumn("qtnm_package", "Package")
                .TrackColumn("qtnm_kgs", "KGS")
                .TrackColumn("qtnm_lbs", "LBS")
                .TrackColumn("qtnm_cbm", "CBM")
                .TrackColumn("qtnm_cft", "CFT")
                .TrackColumn("qtnm_por_name", "Port of Origin Name")
                .TrackColumn("qtnm_pol_name", "Port of Loading Name")
                .TrackColumn("qtnm_pod_name", "Port of Discharge Name")
                .TrackColumn("qtnm_pld_name", "Place of Delivery Name")
                .TrackColumn("qtnm_plfd_name", "Final Destination Name")
                .TrackColumn("qtnm_trans_time", "Transit Time")
                .TrackColumn("qtnm_routing", "Routing")
                .TrackColumn("qtnm_amt", "Amount")
                .SetRecord(old_record, new_record)
                .LogChangesAsync();
        }

        public async Task logHistoryDetail(List<mark_qtnd_lcl> old_records, mark_qtnm_dto record_dto)
        {
            var new_records = record_dto.qtnd_lcl!.Select(record_dto => new mark_qtnd_lcl
            {
                qtnd_id = record_dto.qtnd_id,
                qtnd_acc_name = record_dto.qtnd_acc_name,
                qtnd_amt = record_dto.qtnd_amt,
                qtnd_per = record_dto.qtnd_per,
            }).ToList();

            await new LogHistory<mark_qtnd_lcl>(context)
                .Table("mark_qtnm", log_date) 
                .PrimaryKey("qtnd_id", record_dto.qtnm_id) 
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("qtnd_acc_name", "Account Name")
                .TrackColumn("qtnd_amt", "Amount")
                .TrackColumn("qtnd_per", "Percentage")
                .SetRecords(old_records, new_records)
                .LogChangesAsync();
        }

    }

}
