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
    public class QtnmFclRepository : IQtnmFclRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public QtnmFclRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var qtnm_to_name = "";
                var qtnm_no = "";
                var company_id = 0;
                var branch_id = 0;
                var qtnm_pld_name = "";

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

                query = query.Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.qtnm_type == "FCL");

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
                    .OrderBy(c => c.qtnm_no)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new mark_qtnm_dto
                {
                    qtnm_id = e.qtnm_id,
                    qtnm_cfno = e.qtnm_cfno,
                    qtnm_type = e.qtnm_type,
                    qtnm_no = e.qtnm_no,
                    qtnm_to_id = e.customer!.cust_id,
                    qtnm_to_code = e.customer!.cust_code,
                    qtnm_to_name = e.customer!.cust_name,
                    qtnm_to_addr1 = e.customer!.cust_address1,
                    qtnm_to_addr2 = e.customer!.cust_address2,
                    qtnm_to_addr3 = e.customer!.cust_address3,
                    qtnm_to_addr4 = e.qtnm_to_addr4,
                    qtnm_date = Lib.FormatDate(e.qtnm_date, Lib.outputDateFormat),
                    qtnm_quot_by = e.qtnm_quot_by,
                    qtnm_valid_date = Lib.FormatDate(e.qtnm_valid_date, Lib.outputDateFormat),
                    qtnm_salesman_id = e.salesman!.param_id,
                    qtnm_salesman_name = e.salesman!.param_name,
                    qtnm_move_type = e.qtnm_move_type,
                    qtnm_commodity = e.qtnm_commodity,

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

                query = query.Where(f => f.qtnm_id == id && f.qtnm_type == "FCL");

                var Record = await query.Select(e => new mark_qtnm_dto
                {
                    qtnm_id = e.qtnm_id,
                    qtnm_cfno = e.qtnm_cfno,
                    qtnm_type = e.qtnm_type,
                    qtnm_no = e.qtnm_no,
                    qtnm_to_id = e.qtnm_to_id,
                    qtnm_to_code = e.customer!.cust_code,
                    qtnm_to_name = e.customer!.cust_name,
                    qtnm_to_addr1 = e.customer!.cust_address1,
                    qtnm_to_addr2 = e.customer!.cust_address2,
                    qtnm_to_addr3 = e.customer!.cust_address3,
                    qtnm_to_addr4 = e.qtnm_to_addr4,
                    qtnm_date = Lib.FormatDate(e.qtnm_date, Lib.outputDateFormat),
                    qtnm_quot_by = e.qtnm_quot_by,
                    qtnm_valid_date = Lib.FormatDate(e.qtnm_valid_date, Lib.outputDateFormat),
                    qtnm_salesman_id = e.salesman!.param_id,
                    qtnm_salesman_name = e.salesman!.param_name,
                    qtnm_move_type = e.qtnm_move_type,
                    qtnm_commodity = e.qtnm_commodity,

                    rec_version = e.rec_version,
                    rec_branch_id = e.rec_branch_id,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Qtn Found");

                Record.qtnm_fcl = await GetDetailsAsync(Record.qtnm_id);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<mark_qtnd_fcl_dto>> GetDetailsAsync(int id)
        {
            var query = from e in context.mark_qtnd_fcl
                        .Where(e => e.qtnd_qtnm_id == id)
                        .OrderBy(o => o.qtnd_order)
                        select (new mark_qtnd_fcl_dto
                        {
                            qtnd_id = e.qtnd_id,
                            qtnd_qtnm_id = e.qtnd_qtnm_id,
                            qtnd_pol_id = e.qtnd_pol_id,
                            qtnd_pol_name = e.pol!.param_name,
                            qtnd_pod_id = e.qtnd_pod_id,
                            qtnd_pod_name = e.pod!.param_name,
                            qtnd_carrier_id = e.qtnd_carrier_id,
                            qtnd_carrier_name = e.carrier!.param_name,
                            qtnd_trans_time = e.qtnd_trans_time,
                            qtnd_routing = e.qtnd_routing,
                            qtnd_cntr_type = e.qtnd_cntr_type,
                            qtnd_etd = e.qtnd_etd,
                            qtnd_cutoff = e.qtnd_cutoff,
                            qtnd_of = e.qtnd_of,
                            qtnd_pss = e.qtnd_pss,
                            qtnd_baf = e.qtnd_baf,
                            qtnd_isps = e.qtnd_isps,
                            qtnd_haulage = e.qtnd_haulage,
                            qtnd_ifs = e.qtnd_ifs,
                            qtnd_tot_amt = e.qtnd_tot_amt,
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
                context.Database.BeginTransaction();
                mark_qtnm_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await SaveDetailsAsync(_Record.qtnm_id, record_dto);
                _Record.qtnm_fcl = await GetDetailsAsync(_Record.qtnm_id);
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

            if (Lib.IsZero(record_dto.qtnm_to_id))
                str += "Quote To Cannot Be Blank!";
            if (Lib.IsZero(record_dto.qtnm_salesman_id))
                str += "Sales Rep. Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.qtnm_date))
                str += "Quote Date Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.qtnm_quot_by))
                str += "Quote By Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.qtnm_move_type))
                str += "Move Type Cannot Be Blank!";

            foreach (mark_qtnd_fcl_dto rec in record_dto.qtnm_fcl!)
            {
                if (Lib.IsBlank(rec.qtnd_pod_name))
                    code = "POD Cannot Be Blank!";
                if (Lib.IsBlank(rec.qtnd_pol_name))
                    name = "POL Cannot Be Blank!";
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

            if (record_dto.qtnm_fcl.Count == 0)
            {
                throw new Exception("No Quotation Detail to Save"); /// change this
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
                    int iNextNo = GetCfNo(record_dto.rec_company_id, record_dto.rec_branch_id);
                    string sqtn_no = $"QF-{iNextNo}";

                    Record = new mark_qtnm();
                    Record.qtnm_cfno = iNextNo;
                    Record.qtnm_no = sqtn_no;
                    Record.qtnm_type = "FCL";


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

        public decimal? GetTotalAmount(mark_qtnd_fcl_dto record_dto)
        {
            var totcost = new List<decimal?>
            {
                record_dto.qtnd_of,
                record_dto.qtnd_pss,
                record_dto.qtnd_baf,
                record_dto.qtnd_isps,
                record_dto.qtnd_haulage,
                record_dto.qtnd_ifs
            };
            return totcost.Sum();
        }

        public async Task<mark_qtnm_dto> SaveDetailsAsync(int id, mark_qtnm_dto record_dto)
        {
            mark_qtnd_fcl? record;
            List<mark_qtnd_fcl_dto> records_dto;
            List<mark_qtnd_fcl> records;
            try
            {

                records_dto = record_dto.qtnm_fcl!;

                records = await context.mark_qtnd_fcl
                    .Where(w => w.qtnd_qtnm_id == id)
                    .ToListAsync();

                int nextorder = 1;


                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.qtnd_id == existing_record.qtnd_id);
                    if (rec == null)
                        context.mark_qtnd_fcl.Remove(existing_record);
                }

                //Add or Edit Records 
                foreach (var rec in records_dto)
                {
                    var tot_amt = GetTotalAmount(rec);

                    if (rec.qtnd_id == 0)
                    {
                        record = new mark_qtnd_fcl();
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
                    record.qtnd_pol_id = rec.qtnd_pol_id;
                    record.qtnd_pol_name = rec.qtnd_pol_name;
                    record.qtnd_pod_id = rec.qtnd_pod_id;
                    record.qtnd_pod_name = rec.qtnd_pod_name;
                    if (Lib.IsZero(record.qtnd_carrier_id))
                        record.qtnd_carrier_id = null;
                    else
                        record.qtnd_carrier_id = rec.qtnd_carrier_id;
                    record.qtnd_carrier_name = rec.qtnd_carrier_name;
                    record.qtnd_trans_time = rec.qtnd_trans_time;
                    record.qtnd_routing = rec.qtnd_routing;
                    record.qtnd_cntr_type = rec.qtnd_cntr_type;
                    record.qtnd_etd = rec.qtnd_etd;
                    record.qtnd_cutoff = rec.qtnd_cutoff;
                    record.qtnd_of = rec.qtnd_of;
                    record.qtnd_pss = rec.qtnd_pss;
                    record.qtnd_baf = rec.qtnd_baf;
                    record.qtnd_isps = rec.qtnd_isps;
                    record.qtnd_haulage = rec.qtnd_haulage;
                    record.qtnd_ifs = rec.qtnd_ifs;
                    record.qtnd_tot_amt = tot_amt;
                    record.qtnd_order = nextorder++;
                    if (rec.qtnd_id == 0)
                        await context.mark_qtnd_fcl.AddAsync(record);
                }
                context.SaveChanges();
                return record_dto;
            }
            catch (Exception Ex)
            {
                Lib.getErrorMessage(Ex, "fk", "qtnd_pol_id", "POL type Cannot be blank");
                throw;
            }
        }
        public int GetCfNo(int company_id, int? branch_id)
        {
            var maxCfNo = context.mark_qtnm
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.qtnm_type == "FCL")
            .Select(e => e.qtnm_cfno)
            .DefaultIfEmpty()
            .Max();
            return maxCfNo + 1;
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
                    var Qtnd_Fcl = context.mark_qtnd_fcl
                     .Where(c => c.qtnd_qtnm_id == id);
                    if (Qtnd_Fcl.Any())
                    {
                        context.mark_qtnd_fcl.RemoveRange(Qtnd_Fcl);

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
