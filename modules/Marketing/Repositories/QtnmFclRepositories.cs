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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Common.Lib;


namespace Marketing.Repositories
{

    //Name : Alen Cherian
    //Date : 03/01/2025
    //Command :  Create Repository for the Quotation Fcl.

    public class QtnmFclRepository : IQtnmFclRepository
    {

        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        string qtnm_type = "QUOTATION-FCL";
        private DateTime log_date;

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
                var qtnm_from_date = "";
                var qtnm_to_date = "";
                DateTime? from_date = null;
                DateTime? to_date = null;

                if (data.ContainsKey("qtnm_to_name"))
                    qtnm_to_name = data["qtnm_to_name"].ToString();
                if (data.ContainsKey("qtnm_no"))
                    qtnm_no = data["qtnm_no"].ToString();
                if (data.ContainsKey("qtnm_pld_name"))
                    qtnm_pld_name = data["qtnm_pld_name"].ToString();
                if (data.ContainsKey("qtnm_from_date"))
                    qtnm_from_date = data["qtnm_from_date"].ToString();
                if (data.ContainsKey("qtnm_to_date"))
                    qtnm_to_date = data["qtnm_to_date"].ToString();

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
                query = query.Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.qtnm_type == qtnm_type);

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
                    .OrderBy(c => c.qtnm_date)
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

                query = query.Where(f => f.qtnm_id == id && f.qtnm_type == qtnm_type);

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
                    rec_files_attached = e.rec_files_attached,
                    rec_files_count = e.rec_files_count,

                    rec_version = e.rec_version,
                    rec_branch_id = e.rec_branch_id,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Qtn Found");

                Record.qtnd_fcl = await GetDetailsAsync(Record.qtnm_id);
                Record.remk_remarks = await CommonLib.GetRemarksDetailsAsync(context, Record.qtnm_id, Record.qtnm_type);

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
                            qtnd_pol_code = e.pol!.param_code,
                            qtnd_pol_name = e.pol!.param_name,
                            qtnd_pod_id = e.qtnd_pod_id,
                            qtnd_pod_code = e.pod!.param_code,
                            qtnd_pod_name = e.pod!.param_name,
                            qtnd_carrier_id = e.qtnd_carrier_id,
                            qtnd_carrier_code = e.carrier!.param_code,
                            qtnd_carrier_name = e.qtnd_carrier_name,
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
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                mark_qtnm_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await SaveDetailsAsync(_Record.qtnm_id, mode, record_dto);
                _Record = await CommonLib.SaveMarketingRemarksAsync(this.context, _Record.qtnm_id, _Record.qtnm_type, mode, record_dto);
                _Record.qtnd_fcl = await GetDetailsAsync(_Record.qtnm_id);
                _Record.remk_remarks = await CommonLib.GetRemarksDetailsAsync(this.context, _Record.qtnm_id, _Record.qtnm_type);
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

            foreach (mark_qtnd_fcl_dto rec in record_dto.qtnd_fcl!)
            {
                if (Lib.IsZero(rec.qtnd_pod_id))
                    code = "POD Cannot Be Blank!";
                if (Lib.IsZero(rec.qtnd_pol_id))
                    name = "POL Cannot Be Blank!";
            }

            if (record_dto.qtnd_fcl == null || record_dto.qtnd_fcl.Count == 0)
            {
                str += "No data found in FCL Details";
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
            return bRet;
        }

        public async Task<mark_qtnm_dto> SaveParentAsync(int id, string mode, mark_qtnm_dto record_dto)
        {
            mark_qtnm? Record;
            string error = "";
            try
            {
                //check the dto is null or not.
                if (record_dto == null)
                    throw new Exception("No Data Found");
                //check all the validations
                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    //getting the prefix and default number from branchsettings
                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, "QUOTATION-FCL-PREFIX,QUOTATION-FCL-STARTING-NO");// 

                    var DefaultCfNo = 0;
                    var Defaultprefix = "";

                    if (result.ContainsKey("QUOTATION-FCL-STARTING-NO"))
                    {
                        DefaultCfNo = Lib.StringToInteger(result["QUOTATION-FCL-STARTING-NO"]);
                    }
                    if (result.ContainsKey("QUOTATION-FCL-PREFIX"))
                    {
                        Defaultprefix = result["QUOTATION-FCL-PREFIX"].ToString();
                    }
                    if (Lib.IsBlank(Defaultprefix) || Lib.IsZero(DefaultCfNo))
                    {
                        throw new Exception("Missing Quotation Prefix/Starting-Number in Branch Settings");
                    }
                    //getting the next cfno
                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("Quotation Number Cannot Be Generated");
                    }
                    string sqtn_no = $"{Defaultprefix}{iNextNo}"; //add the quotation number into the variable.
                    //if the mode is add, updated the cfno,quotation number,quotation type to the database.
                    Record = new mark_qtnm();
                    Record.qtnm_cfno = iNextNo;
                    Record.qtnm_no = sqtn_no;
                    Record.qtnm_type = qtnm_type;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    //if the mode is edit, the get the records from the database
                    Record = await context.mark_qtnm
                        .Include(c => c.salesman)
                        .Where(f => f.qtnm_id == id)
                        .FirstOrDefaultAsync();
                    //check the record is null or not.
                    if (Record == null)
                        throw new Exception("Record Not Found");
                    //concurrency control checking for the rec_version
                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                if (mode == "edit") //if mode is edit, then call the log history
                    await logHistory(Record, record_dto);
                //Add and edit records to the database
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
                if (mode == "add")  //add the record to database
                    await context.mark_qtnm.AddAsync(Record);
                context.SaveChanges();//Save changes in database
                //return the elements from database to dto.
                record_dto.qtnm_id = Record.qtnm_id;
                record_dto.qtnm_no = Record.qtnm_no;
                record_dto.qtnm_amt = Record.qtnm_amt;
                record_dto.qtnm_type = Record.qtnm_type;

                record_dto.rec_version = Record.rec_version;
                // Lib.AssignDates2DTO(id, mode, Record, record_dto);
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.qtnm_id != 0)
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }
                return record_dto;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //The function for total amount of Logistics Charges and Surcharges
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

        public async Task<mark_qtnm_dto> SaveDetailsAsync(int id, string mode, mark_qtnm_dto record_dto)
        {
            mark_qtnd_fcl? record;
            List<mark_qtnd_fcl_dto> records_dto;
            List<mark_qtnd_fcl> records;
            try
            {

                records_dto = record_dto.qtnd_fcl!;

                records = await context.mark_qtnd_fcl
                    .Include(c => c.pol)
                    .Include(c => c.pod)
                    .Include(c => c.carrier)
                    .Where(w => w.qtnd_qtnm_id == id)
                    .ToListAsync();

                if (mode == "edit")
                    await logHistoryDetail(records, record_dto);

                int nextorder = 1;


                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.qtnd_id == existing_record.qtnd_id);
                    if (rec == null)
                        context.mark_qtnd_fcl.Remove(existing_record);
                }

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
        public int GetNextCfNo(int company_id, int? branch_id, int DefaultCfNo)
        {
            var CfNo = context.mark_qtnm
                .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.qtnm_type == qtnm_type)
                .Select(e => e.qtnm_cfno)
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
                    await context.SaveChangesAsync();

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

        public async Task logHistory(mark_qtnm old_record, mark_qtnm_dto record_dto)
        {

            var old_record_dto = new mark_qtnm_dto
            {
                qtnm_id = old_record.qtnm_id,
                qtnm_cfno = old_record.qtnm_cfno,
                qtnm_no = old_record.qtnm_no,
                qtnm_to_name = old_record.qtnm_to_name,
                qtnm_to_addr1 = old_record.qtnm_to_addr1,
                qtnm_to_addr2 = old_record.qtnm_to_addr2,
                qtnm_to_addr3 = old_record.qtnm_to_addr3,
                qtnm_to_addr4 = old_record.qtnm_to_addr4,
                qtnm_date = Lib.FormatDate(old_record.qtnm_date, Lib.outputDateFormat),
                qtnm_quot_by = old_record.qtnm_quot_by,
                qtnm_valid_date = Lib.FormatDate(old_record.qtnm_valid_date, Lib.outputDateFormat),
                qtnm_salesman_name = old_record.salesman?.param_name,
                qtnm_move_type = old_record.qtnm_move_type,
                qtnm_commodity = old_record.qtnm_commodity

            };

            await new LogHistorym<mark_qtnm_dto>(context)
                .Table("mark_qtnm", log_date)
                .PrimaryKey("qtnm_id", record_dto.qtnm_id)
                .RefNo(record_dto.qtnm_no!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("qtnm_cfno", "CF-No", "integer")
                .TrackColumn("qtnm_no", "Quotation-No")
                .TrackColumn("qtnm_to_name", "To Name")
                .TrackColumn("qtnm_to_addr1", "To Address 1")
                .TrackColumn("qtnm_to_addr2", "To Address 2")
                .TrackColumn("qtnm_to_addr3", "To Address 3")
                .TrackColumn("qtnm_to_addr4", "To Address 4")
                .TrackColumn("qtnm_date", "Quotation Date")
                .TrackColumn("qtnm_quot_by", "Quoted By")
                .TrackColumn("qtnm_valid_date", "Valid Until")
                .TrackColumn("qtnm_salesman_name", "Salesman Name")
                .TrackColumn("qtnm_move_type", "Move Type")
                .TrackColumn("qtnm_commodity", "Commodity")

                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();

        }

        public async Task logHistoryDetail(List<mark_qtnd_fcl> old_records, mark_qtnm_dto record_dto)
        {

            var old_records_dto = old_records.Select(record => new mark_qtnd_fcl_dto
            {
                qtnd_id = record.qtnd_id,
                qtnd_pol_name = record.qtnd_pol_name,
                qtnd_pod_name = record.qtnd_pod_name,
                qtnd_carrier_name = record.qtnd_carrier_name,
                qtnd_trans_time = record.qtnd_trans_time,
                qtnd_routing = record.qtnd_routing,
                qtnd_cntr_type = record.qtnd_cntr_type,
                qtnd_etd = record.qtnd_etd,
                qtnd_cutoff = record.qtnd_cutoff,
                qtnd_of = record.qtnd_of,
                qtnd_pss = record.qtnd_pss,
                qtnd_baf = record.qtnd_baf,
                qtnd_isps = record.qtnd_isps,
                qtnd_haulage = record.qtnd_haulage,
                qtnd_ifs = record.qtnd_ifs,
                qtnd_tot_amt = record.qtnd_tot_amt
            }).ToList();

            await new LogHistorym<mark_qtnd_fcl_dto>(context)
                .Table("mark_qtnm_dto", log_date)
                .PrimaryKey("qtnd_id", record_dto.qtnm_id)
                .RefNo(record_dto.qtnm_no!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("qtnd_pol_name", "POL Name")
                .TrackColumn("qtnd_pod_name", "POD Name")
                .TrackColumn("qtnd_carrier_name", "Carrier Name")
                .TrackColumn("qtnd_trans_time", "Transit Time")
                .TrackColumn("qtnd_routing", "Routing")
                .TrackColumn("qtnd_cntr_type", "Container Type")
                .TrackColumn("qtnd_etd", "ETD")
                .TrackColumn("qtnd_cutoff", "Cutoff")
                .TrackColumn("qtnd_of", "OF", "decimal")
                .TrackColumn("qtnd_pss", "PSS", "decimal")
                .TrackColumn("qtnd_baf", "BAF", "decimal")
                .TrackColumn("qtnd_isps", "ISPS", "decimal")
                .TrackColumn("qtnd_haulage", "Haulage", "decimal")
                .TrackColumn("qtnd_ifs", "IFS", "decimal")
                .TrackColumn("qtnd_tot_amt", "Total Amount", "decimal")
                .SetRecords(old_records_dto, record_dto.qtnd_fcl!)
                .LogChangesAsync();

        }

    }
}
