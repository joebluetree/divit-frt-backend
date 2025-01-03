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

namespace Marketing.Repositories
{
    public class QtnmRepository : IQtnmRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public QtnmRepository (AppDbContext _context, IAuditLog _auditLog)
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
                
                
                var qtnm_no = "";
                var company_id = 0;
                
                if (data.ContainsKey("qtnm_no"))
                    qtnm_no = data["qtnm_no"].ToString();
                if (data.ContainsKey("rec_company_id"))
                    company_id = int.Parse(data["rec_company_id"].ToString()!);
                if (company_id == 0)
                    throw new Exception("Company Id Not Found");

                _page.currentPageNo = int.Parse(data["currentPageNo"].ToString()!);
                _page.pages = int.Parse(data["pages"].ToString()!);
                _page.rows = int.Parse(data["rows"].ToString()!);
                _page.pageSize = int.Parse(data["pageSize"].ToString()!);

                IQueryable<mark_qtnm> query = context.mark_qtnm;
                    // .Include(e => e.customer);

                query = query.Where(w => w.rec_company_id == company_id);

                if (!Lib.IsBlank(qtnm_no))
                    query = query.Where(w => w.qtnm_no!.Contains(qtnm_no!));

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
                    .OrderBy(c => c.qtnm_no)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mark_qtnm_dto
                {
                    qtnm_pkid = e.qtnm_pkid,
                    qtnm_cfno = e.qtnm_cfno,
                    qtnm_type = e.qtnm_type,
                    qtnm_no = e.qtnm_no,
                    qtnm_to_id = e.qtnm_to_id,
                    qtnm_to_name = e.customer!.cust_name,
                    qtnm_to_addr1 = e.customer.cust_address1,
                    qtnm_to_addr2 = e.customer.cust_address2,
                    qtnm_to_addr3 = e.customer.cust_address3,
                    qtnm_to_addr4 = e.qtnm_to_addr4,
                    qtnm_date = Lib.FormatDate(e.qtnm_date,Lib.outputDateFormat),
                    qtnm_quot_by = e.qtnm_quot_by,
                    qtnm_valid_date = Lib.FormatDate(e.qtnm_valid_date,Lib.outputDateFormat),
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
                    qtnm_por_name = e.por!.param_name,
                    qtnm_pol_id = e.qtnm_pol_id,
                    qtnm_pol_name = e.pol!.param_name,
                    qtnm_pod_id = e.qtnm_pod_id,
                    qtnm_pod_name = e.pod!.param_name,
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
                    // .Include(e => e.customer);

                query = query.Where(f => f.qtnm_pkid == id);

                var Record = await query.Select(e => new mark_qtnm_dto
                {
                    qtnm_pkid = e.qtnm_pkid,
                    qtnm_cfno = e.qtnm_cfno,
                    qtnm_type = e.qtnm_type,
                    qtnm_no = e.qtnm_no,
                    qtnm_to_id = e.qtnm_to_id,
                    qtnm_to_name = e.customer!.cust_name,
                    qtnm_to_addr1 = e.customer.cust_address1,
                    qtnm_to_addr2 = e.customer.cust_address2,
                    qtnm_to_addr3 = e.customer.cust_address3,
                    qtnm_to_addr4 = e.qtnm_to_addr4,
                    qtnm_date = Lib.FormatDate(e.qtnm_date,Lib.outputDateFormat),
                    qtnm_quot_by = e.qtnm_quot_by,
                    qtnm_valid_date = Lib.FormatDate(e.qtnm_valid_date,Lib.outputDateFormat),
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
                    qtnm_por_name = e.por!.param_name,
                    qtnm_pol_id = e.qtnm_pol_id,
                    qtnm_pol_name = e.pol!.param_name,
                    qtnm_pod_id = e.qtnm_pod_id,
                    qtnm_pod_name = e.pod!.param_name,
                    qtnm_pld_name = e.qtnm_pld_name,
                    qtnm_plfd_name = e.qtnm_plfd_name,
                    qtnm_trans_time = e.qtnm_trans_time,
                    qtnm_routing = e.qtnm_routing,
                    qtnm_amt = e.qtnm_amt,

                    rec_version = e.rec_version,
                    rec_branch_id =e.rec_branch_id,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Qtn Found");

                Record.qtnm_qtnd_lcl = await GetLclDetailsAsync(Record.qtnm_pkid);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<mark_qtnd_lcl_dto>> GetLclDetailsAsync(int qtnm_pkid)
        {
            var query = from e in context.mark_qtnd_lcl
                        .Where(a => a.qtnd_qtnm_pkid == qtnm_pkid)
                        .OrderBy(o => o.qtnd_pkid)
                        select (new mark_qtnd_lcl_dto
                        {
                            qtnd_pkid = e.qtnd_pkid,
                            qtnd_qtnm_pkid = e.qtnd_qtnm_pkid,
                            qtnd_acc_id = e.qtnd_acc_id,
                            qtnd_acc_name = e.acctm!.acc_name,
                            qtnd_amt = e.qtnd_amt,
                            qtnd_per = e.qtnd_per,

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
                context.Database.BeginTransaction();
                record_dto = await SaveParentAsync(id, mode, record_dto);
                record_dto = await saveLclDetailsAsync(id, record_dto);
                record_dto.qtnm_qtnd_lcl = await GetLclDetailsAsync(id);

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


        private Boolean AllValid(string mode, mark_qtnm_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            string code = "";
            string name = "";

            if (Lib.IsZero(record_dto.qtnm_to_id))
                str += "Quote To Cannot Be Blank!";
            if (Lib.IsZero(record_dto.qtnm_salesman_id))
                str += "Sales Rep. Cannot Be Blank!";

            foreach (mark_qtnd_lcl_dto rec in record_dto.qtnm_qtnd_lcl!)
            {
                if (Lib.IsZero(rec.qtnd_acc_id))
                    code = "Code Cannot Be Blank!";
                if (Lib.IsBlank(rec.qtnd_acc_name))
                    name = "Description Cannot Be Blank!";
            }
            if (code != "")
                str += code;
            if (name != "")
                str += name;

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            if (record_dto.qtnm_qtnd_lcl.Count == 0)
            {
                throw new Exception("No Quotation Detail to Save");
            }

            decimal? nTotal = this.FindTotal(record_dto);

            if ( record_dto.qtnm_amt !=  nTotal )
            {
                throw new Exception(" Qtnm total and Qtnd line item total does not match");
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
                    throw new Exception("No Data Found To Save");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id);
                    string sqtn_no = $"QL-{iNextNo}";

                    Record = new mark_qtnm();
                    Record.qtnm_cfno = iNextNo;
                    Record.qtnm_no = sqtn_no;
                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                }
                else
                {
                    Record = await context.mark_qtnm
                        .Where(f => f.qtnm_pkid == record_dto.qtnm_pkid)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                Record.qtnm_to_id = record_dto.qtnm_to_id;
                // Record.qtnm_to_name = record_dto.qtnm_to_name;
                // Record.qtnm_to_addr1 = record_dto.qtnm_to_addr1;
                // Record.qtnm_to_addr2 = record_dto.qtnm_to_addr2;
                // Record.qtnm_to_addr3 = record_dto.qtnm_to_addr3;
                // Record.qtnm_to_addr4 = record_dto.qtnm_to_addr4;
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
                Record.qtnm_por_id = record_dto.qtnm_por_id;
                Record.qtnm_pol_id = record_dto.qtnm_pol_id;
                Record.qtnm_pod_id = record_dto.qtnm_pod_id;    
                Record.qtnm_pld_name = record_dto.qtnm_pld_name;
                Record.qtnm_plfd_name = record_dto.qtnm_plfd_name;
                Record.qtnm_trans_time = record_dto.qtnm_trans_time;
                Record.qtnm_routing = record_dto.qtnm_routing;
                Record.qtnm_amt = record_dto.qtnm_amt;

                if (mode == "add")
                    await context.mark_qtnm.AddAsync(Record);


                await context.SaveChangesAsync();

                record_dto.qtnm_pkid = Record.qtnm_pkid;
                record_dto.qtnm_cfno = Record.qtnm_cfno;
                record_dto.qtnm_no = Record.qtnm_no;

                record_dto.rec_version = Record.rec_version;
                Lib.AssignDates2DTO(record_dto.qtnm_pkid, mode, Record, record_dto);
                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }

        }

        public async Task<mark_qtnm_dto> saveLclDetailsAsync(int id, mark_qtnm_dto record_dto)
        {
            mark_qtnd_lcl? record;
            List<mark_qtnd_lcl_dto> records_dto;
            List<mark_qtnd_lcl> records;
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                // get contacts from the front end
                records_dto = record_dto.qtnm_qtnd_lcl!;
                // read the contact details from database
                records = await context.mark_qtnd_lcl
                    .Where(w => w.qtnd_pkid == id)
                    .ToListAsync();

                // Remove Deleted Records
                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.qtnd_pkid == existing_record.qtnd_pkid);
                    if (rec == null)
                        context.mark_qtnd_lcl.Remove(existing_record);
                }

                //Add or Edit Records 
                foreach (var rec in records_dto)
                {
                    // if cont_id is zero it is a new record
                    if (rec.qtnd_pkid == 0)
                    {
                        record = new mark_qtnd_lcl();
                        record.rec_company_id = record_dto.rec_company_id;
                        record.rec_created_by = record_dto.rec_created_by;
                        record.rec_created_date = DbLib.GetDateTime();
                        record.rec_locked = "N";
                    }
                    else
                    {
                        record = records.Find(f => f.qtnd_pkid == rec.qtnd_pkid);
                        if (record == null)
                            throw new Exception("Detail Record Not Found " + rec.qtnd_pkid.ToString());
                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }
                    record.qtnd_qtnm_pkid = id;
                    record.qtnd_acc_id = rec.qtnd_acc_id;
                    record.qtnd_acc_name = rec.qtnd_acc_name;
                    record.qtnd_amt = rec.qtnd_amt ?? 0;
                    record.qtnd_per = rec.qtnd_per;

                    if (rec.qtnd_pkid == 0)
                        await context.mark_qtnd_lcl.AddAsync(record);
                }
                context.SaveChanges();
                return record_dto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int GetNextCfNo(int company_id, int? branch_id)
        {
            var maxCfNo = context.mark_qtnm
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id)
            .Select(e => e.qtnm_cfno)
            .DefaultIfEmpty()
            .Max();

            return maxCfNo + 1;
        }
        public decimal? FindTotal(mark_qtnm_dto record_dto)
        {
            decimal nTotal =  record_dto.qtnm_qtnd_lcl!.Sum(x => x.qtnd_amt )  ?? 0;
            return nTotal;
        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.mark_qtnm
                    .FirstOrDefaultAsync(f => f.qtnm_pkid == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                   var _Quote = context.mark_qtnd_lcl
                        .Where(c => c.qtnd_qtnm_pkid == id);
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

    }
}
