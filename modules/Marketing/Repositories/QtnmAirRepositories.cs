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
    public class QtnmAirRepository : IQtnmAirRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        public QtnmAirRepository(AppDbContext _context, IAuditLog _auditLog)
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
                query = query.Where(w => w.qtnm_type == "AIR");


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

                    rec_version = e.rec_version,
                    rec_branch_id = e.rec_branch_id,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Qtn Found");

                Record.qtnd_air = await GetDetailsAsync(Record.qtnm_id);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task<List<mark_qtnd_air_dto>> GetDetailsAsync(int id)
        {
            var query = from e in context.mark_qtnd_air
                        .Where(e => e.qtnd_qtnm_id == id)
                        .OrderBy(o => o.qtnd_order)
                        select (new mark_qtnd_air_dto
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
                            qtnd_carrier_name = e.carrier!.param_name,
                            qtnd_trans_time = e.qtnd_trans_time,
                            qtnd_routing = e.qtnd_routing,
                            qtnd_etd = e.qtnd_etd,
                            qtnd_min = e.qtnd_min,
                            qtnd_45k = e.qtnd_45k,
                            qtnd_100k = e.qtnd_100k,
                            qtnd_300k = e.qtnd_300k,
                            qtnd_500k = e.qtnd_500k,
                            qtnd_1000k = e.qtnd_1000k,
                            qtnd_fsc = e.qtnd_fsc,
                            qtnd_war = e.qtnd_war,
                            qtnd_sfc = e.qtnd_sfc,
                            qtnd_hac = e.qtnd_hac,
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
                _Record = await SaveDetailsAsync(_Record.qtnm_id, _Record);
                _Record.qtnd_air = await GetDetailsAsync(_Record.qtnm_id);
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

            string pol = "";
            string pod = "";
            string carrier = "";
            string ttime = "";

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

            foreach (mark_qtnd_air_dto rec in record_dto.qtnd_air!)
            {
                if (Lib.IsBlank(rec.qtnd_pol_code))
                    pol = "POL Cannot Be Blank!";
                if (Lib.IsBlank(rec.qtnd_pod_code))
                    pod = "POD Cannot Be Blank!";
                if (Lib.IsBlank(rec.qtnd_carrier_code))
                    carrier = "Carrier Cannot Be Blank";
                if (Lib.IsBlank(rec.qtnd_trans_time))
                    ttime = "Transit Time Cannot Be Blank";
            }

            if (record_dto.qtnd_air.Count == 0)
            {
                str += "Quotation Line Item Need To Be Entered";
            }
            
            if (pol != "")
                str += pol;
            if (pod != "")
                str += pod;
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
                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id);
                    string sqtn_no = $"QA-{iNextNo}";
                    string stype = "AIR";
                    int amt = 0;

                    Record = new mark_qtnm();
                    Record.qtnm_cfno = iNextNo;
                    Record.qtnm_no = sqtn_no;
                    Record.qtnm_type = stype;
                    Record.qtnm_amt = amt;

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

                record_dto.rec_version = Record.rec_version;
                Lib.AssignDates2DTO(id, mode, Record, record_dto);
                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }

        }

        public async Task<mark_qtnm_dto> SaveDetailsAsync(int id, mark_qtnm_dto record_dto)
        {
            mark_qtnd_air? record;
            List<mark_qtnd_air_dto> records_dto;
            List<mark_qtnd_air> records;
            try
            {

                records_dto = record_dto.qtnd_air!;

                records = await context.mark_qtnd_air
                    .Where(w => w.qtnd_qtnm_id == id)
                    .ToListAsync();

                int nextorder = 1;

                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.qtnd_id == existing_record.qtnd_id);
                    if (rec == null)
                        context.mark_qtnd_air.Remove(existing_record);
                }

                foreach (var rec in records_dto)
                {

                    if (rec.qtnd_id == 0)
                    {
                        record = new mark_qtnd_air();
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
                    if (Lib.IsZero(rec.qtnd_pol_id))
                        record.qtnd_pol_id = null;
                    else
                        record.qtnd_pol_id = rec.qtnd_pol_id;
                    record.qtnd_pol_name = rec.qtnd_pol_name;
                    if (Lib.IsZero(rec.qtnd_pod_id))
                        record.qtnd_pod_id = null;
                    else
                        record.qtnd_pod_id = rec.qtnd_pod_id;
                    record.qtnd_pod_name = rec.qtnd_pod_name;
                    if (Lib.IsZero(rec.qtnd_carrier_id))
                        record.qtnd_carrier_id = null;
                    else
                        record.qtnd_carrier_id = rec.qtnd_carrier_id;
                        record.qtnd_carrier_name = rec.qtnd_carrier_name;
                    record.qtnd_trans_time = rec.qtnd_trans_time;
                    record.qtnd_routing = rec.qtnd_routing;
                    record.qtnd_etd = rec.qtnd_etd;
                    record.qtnd_min = rec.qtnd_min;
                    record.qtnd_45k = rec.qtnd_45k;
                    record.qtnd_100k = rec.qtnd_100k;
                    record.qtnd_300k = rec.qtnd_300k;
                    record.qtnd_500k = rec.qtnd_500k;
                    record.qtnd_1000k = rec.qtnd_1000k;
                    record.qtnd_fsc = rec.qtnd_fsc;
                    record.qtnd_war = rec.qtnd_war;
                    record.qtnd_sfc = rec.qtnd_sfc;
                    record.qtnd_hac = rec.qtnd_hac;
                    record.qtnd_order = nextorder++;

                    if (rec.qtnd_id == 0)
                        await context.mark_qtnd_air.AddAsync(record);
                }
                context.SaveChanges();
                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
                // Lib.getErrorMessage(Ex, "fk", "qtnd_pol_id", "POL Cannot be blank");
                // throw;
            }
        }
        public int GetNextCfNo(int company_id, int? branch_id)
        {
            var maxCfNo = context.mark_qtnm
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.qtnm_type == "AIR")
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
                    var _Quote = context.mark_qtnd_air
                     .Where(c => c.qtnd_qtnm_id == id);
                    if (_Quote.Any())
                    {
                        context.mark_qtnd_air.RemoveRange(_Quote);

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
