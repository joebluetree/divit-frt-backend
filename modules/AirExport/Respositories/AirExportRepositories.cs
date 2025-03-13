using Database;
using Database.Lib;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.BaseTables;
using Common.Lib;
using Database.Models.Cargo;
using Common.DTO.AirExport;
using AirExport.Interfaces;


namespace AirExport.Repositories
{

    //Name : Alen Cherian
    //Date : 24/02/2025
    //Command :  Create Repository for the Air Export.

    public class AirExportRepository : IAirExportRepository
    {

        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        string mbl_mode = "AIR EXPORT";

        public AirExportRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var mbl_refno = "";
                var company_id = 0;
                var branch_id = 0;
                var mbl_from_date = "";
                var mbl_to_date = "";
                DateTime? from_date = null;
                DateTime? to_date = null;

                if (data.ContainsKey("mbl_refno"))
                    mbl_refno = data["mbl_refno"].ToString();
                if (data.ContainsKey("mbl_from_date"))
                    mbl_from_date = data["mbl_from_date"].ToString();
                if (data.ContainsKey("mbl_from_date"))
                    mbl_from_date = data["mbl_from_date"].ToString();
                if (data.ContainsKey("mbl_to_date"))
                    mbl_to_date = data["mbl_to_date"].ToString();

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

                IQueryable<cargo_masterm> query = context.cargo_masterm;
                query = query.Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.mbl_mode == mbl_mode);

                if (!Lib.IsBlank(mbl_from_date))
                {
                    from_date = Lib.ParseDate(mbl_from_date!);
                    query = query.Where(w => w.mbl_ref_date >= from_date);
                }
                if (!Lib.IsBlank(mbl_to_date))
                {
                    to_date = Lib.ParseDate(mbl_to_date!);
                    query = query.Where(w => w.mbl_ref_date <= to_date);
                }
                if (!Lib.IsBlank(mbl_refno))
                    query = query.Where(w => w.mbl_refno!.Contains(mbl_refno!));

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
                    .OrderBy(c => c.mbl_date)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_air_exportm_dto
                {
                    mbl_id = e.mbl_id,
                    mbl_refno = e.mbl_refno,
                    mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                    mbl_no = e.mbl_no,
                    mbl_agent_id = e.agent!.cust_id,
                    mbl_agent_name = e.agent!.cust_name,
                    mbl_liner_id = e.liner!.param_id,
                    mbl_liner_name = e.liner!.param_name,
                    mbl_pol_id = e.pol!.param_id,
                    mbl_pol_name = e.pol!.param_name,
                    mbl_pol_etd = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateFormat),
                    mbl_pod_id = e.pod!.param_id,
                    mbl_pod_name = e.pod!.param_name,
                    mbl_pod_eta = Lib.FormatDate(e.mbl_pod_eta, Lib.outputDateFormat),
                    mbl_handled_id = e.handledby!.param_id,
                    mbl_handled_name = e.handledby!.param_name,

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
        public async Task<List<cargo_air_exporth_dto>> GetDetailsAsync(int id)
        {
            var query = from e in context.cargo_housem
                        .Where(e => e.hbl_mbl_id == id)
                        .OrderBy(o => o.hbl_houseno)
                        select (new cargo_air_exporth_dto
                        {
                            hbl_id = e.hbl_id,
                            hbl_mbl_id = e.hbl_mbl_id,
                            hbl_houseno = e.hbl_houseno,
                            hbl_mbl_refno = e.master!.mbl_refno,

                            hbl_date = Lib.FormatDate(e.hbl_date, Lib.outputDateFormat),

                            hbl_shipper_id = e.hbl_shipper_id,
                            hbl_shipper_code = e.shipper!.cust_code,
                            hbl_shipper_name = e.hbl_shipper_name,

                            hbl_consignee_id = e.hbl_consignee_id,
                            hbl_consignee_code = e.consignee!.cust_code,
                            hbl_consignee_name = e.hbl_consignee_name,

                            hbl_handled_id = e.hbl_handled_id,
                            hbl_handled_name = e.handledby!.param_name,

                            hbl_packages = e.hbl_packages,
                            hbl_issued_date = Lib.FormatDate(e.hbl_issued_date, Lib.outputDateFormat),
                            hbl_delivery_date = Lib.FormatDate(e.hbl_delivery_date, Lib.outputDateFormat),

                            rec_version = e.rec_version,
                            rec_company_id = e.rec_company_id,
                            rec_branch_id = e.rec_branch_id,
                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        });


            var Record = await query.ToListAsync();


            return Record;
        }

        public async Task<cargo_air_exportm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_masterm> query = context.cargo_masterm;

                query = query.Where(f => f.mbl_id == id && f.mbl_mode == mbl_mode);

                var Record = await query.Select(e => new cargo_air_exportm_dto
                {
                    mbl_id = e.mbl_id,
                    mbl_cfno = e.mbl_cfno,
                    mbl_refno = e.mbl_refno,
                    mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateTimeFormat),
                    mbl_shipment_stage_id = e.mbl_shipment_stage_id,
                    mbl_shipment_stage_name = e.shipstage!.param_name,
                    mbl_mode = e.mbl_mode,
                    mbl_no = e.mbl_no,
                    mbl_agent_id = e.mbl_agent_id,
                    mbl_agent_name = e.agent!.cust_name,
                    mbl_frt_status_name = e.mbl_frt_status_name,
                    mbl_pol_id = e.mbl_pol_id,
                    mbl_pol_name = e.pol!.param_name,
                    mbl_pol_etd = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateTimeFormat),
                    mbl_pod_id = e.mbl_pod_id,
                    mbl_pod_name = e.pod!.param_name,
                    mbl_pod_eta = Lib.FormatDate(e.mbl_pod_eta, Lib.outputDateTimeFormat),
                    mbl_country_id = e.mbl_country_id,
                    mbl_country_name = e.country!.param_name,
                    mbl_liner_id = e.mbl_liner_id,
                    mbl_liner_name = e.liner!.param_name,
                    mbl_by_carrier1 = e.mbl_by_carrier1,
                    mbl_by_carrier2 = e.mbl_by_carrier2,
                    mbl_by_carrier3 = e.mbl_by_carrier3,
                    mbl_to_port1 = e.mbl_to_port1,
                    mbl_to_port2 = e.mbl_to_port2,
                    mbl_to_port3 = e.mbl_to_port3,
                    mbl_currency_id = e.mbl_currency_id,
                    mbl_currency_code = e.currency!.param_code,
                    mbl_handled_id = e.mbl_handled_id,
                    mbl_handled_name = e.handledby!.param_name,
                    mbl_salesman_id = e.mbl_salesman_id,
                    mbl_salesman_name = e.salesman!.param_name,
                    mbl_mawb_weight = e.mbl_mawb_weight,
                    mbl_mawb_chwt = e.mbl_mawb_chwt,
                    mbl_3rdparty = e.mbl_3rdparty,
                    mbl_direct = e.mbl_direct,
                    mbl_vessel_name = e.mbl_vessel_name,
                    mbl_voyage = e.mbl_voyage,

                    rec_version = e.rec_version,
                    rec_branch_id = e.rec_branch_id,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Qtn Found");

                Record.air_export = await GetDetailsAsync(Record.mbl_id);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }


        public async Task<cargo_air_exportm_dto> SaveAsync(int id, string mode, cargo_air_exportm_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_air_exportm_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record.air_export = await GetDetailsAsync(_Record.mbl_id);
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

        private Boolean AllValid(string mode, cargo_air_exportm_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            if (Lib.IsBlank(record_dto.mbl_no))
                str += "Mawb By Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbl_shipment_stage_id))
                str += "Shipment Stage To Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbl_agent_id))
                str += "Agent Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbl_liner_id))
                str += "Carrier Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbl_country_id))
                str += "Country Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbl_handled_id))
                str += "Handled by. Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_ref_date))
                str += "Quote Date Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbl_pol_id))
                str += "Port of loading Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_pol_etd))
                str += "ETD Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbl_pod_id))
                str += "Port of Discharge Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_pod_eta))
                str += "ETA Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbl_mawb_weight))
                str += "Weight Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbl_mawb_chwt))
                str += "Ch.Weight Cannot Be Blank!";


            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<cargo_air_exportm_dto> SaveParentAsync(int id, string mode, cargo_air_exportm_dto record_dto)
        {
            cargo_masterm? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, "AIREXPORT-MASTER-PREFIX,AIREXPORT-MASTER-STARTING-NO");// 

                    var DefaultCfNo = 0;
                    var Defaultprefix = "";

                    if (result.ContainsKey("AIREXPORT-MASTER-STARTING-NO"))
                    {
                        DefaultCfNo = Lib.StringToInteger(result["AIREXPORT-MASTER-STARTING-NO"]);
                    }
                    if (result.ContainsKey("AIREXPORT-MASTER-PREFIX"))
                    {
                        Defaultprefix = result["AIREXPORT-MASTER-PREFIX"].ToString();
                    }
                    if (Lib.IsBlank(Defaultprefix) || Lib.IsZero(DefaultCfNo))
                    {
                        throw new Exception("Missing AirExport Master Prefix/Starting-Number in Branch Settings");
                    }

                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("AirExport Number Cannot Be Generated");
                    }
                    string sref_no = $"{Defaultprefix}{iNextNo}";

                    Record = new cargo_masterm();
                    Record.mbl_cfno = iNextNo;
                    Record.mbl_refno = sref_no;
                    Record.mbl_mode = mbl_mode;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.cargo_masterm
                        .Include(c => c.salesman)
                        .Include(c => c.agent)
                        .Include(c => c.liner)
                        .Include(c => c.country)
                        .Include(c => c.currency)
                        .Include(c => c.shipstage)
                        .Include(c => c.handledby)
                        .Include(c => c.pol)
                        .Include(c => c.pod)
                        .Where(f => f.mbl_id == id)
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

                Record.mbl_shipment_stage_id = record_dto.mbl_shipment_stage_id;
                Record.mbl_ref_date = Lib.ParseDate(record_dto.mbl_ref_date!);
                Record.mbl_no = record_dto.mbl_no;
                Record.mbl_agent_id = record_dto.mbl_agent_id;
                Record.mbl_frt_status_name = record_dto.mbl_frt_status_name;
                Record.mbl_pol_id = record_dto.mbl_pol_id;
                Record.mbl_pol_etd = Lib.ParseDate(record_dto.mbl_pol_etd!);
                Record.mbl_pod_id = record_dto.mbl_pod_id;
                Record.mbl_pod_eta = Lib.ParseDate(record_dto.mbl_pod_eta!);
                Record.mbl_country_id = record_dto.mbl_country_id;
                Record.mbl_liner_id = record_dto.mbl_liner_id;
                Record.mbl_by_carrier1 = record_dto.mbl_by_carrier1;
                Record.mbl_by_carrier2 = record_dto.mbl_by_carrier2;
                Record.mbl_by_carrier3 = record_dto.mbl_by_carrier3;
                Record.mbl_to_port1 = record_dto.mbl_to_port1;
                Record.mbl_to_port2 = record_dto.mbl_to_port2;
                Record.mbl_to_port3 = record_dto.mbl_to_port3;
                Record.mbl_currency_id = record_dto.mbl_currency_id;
                Record.mbl_handled_id = record_dto.mbl_handled_id;
                Record.mbl_salesman_id = record_dto.mbl_salesman_id;
                Record.mbl_mawb_weight = record_dto.mbl_mawb_weight;
                Record.mbl_mawb_chwt = record_dto.mbl_mawb_chwt;
                Record.mbl_3rdparty = record_dto.mbl_3rdparty;
                Record.mbl_direct = record_dto.mbl_direct;
                Record.mbl_vessel_name = record_dto.mbl_vessel_name;
                Record.mbl_voyage = record_dto.mbl_voyage;
                if (mode == "add")
                    await context.cargo_masterm.AddAsync(Record);
                context.SaveChanges();
                record_dto.mbl_id = Record.mbl_id;
                record_dto.mbl_refno = Record.mbl_refno;

                record_dto.rec_version = Record.rec_version;
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.mbl_id != 0)
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


        public int GetNextCfNo(int company_id, int? branch_id, int DefaultCfNo)
        {
            var CfNo = context.cargo_masterm
                .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.mbl_mode == mbl_mode)
                .Select(e => e.mbl_cfno)
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
                var _Record = await context.cargo_masterm
                    .Where(f => f.mbl_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    var air_exporth = context.cargo_housem
                    .Where(c => c.hbl_mbl_id == id);
                    if (air_exporth.Any())
                    {
                        context.cargo_housem.RemoveRange(air_exporth);

                    }
                    context.Remove(_Record);
                    context.SaveChanges();
                    RetData.Add("status", true);
                    RetData.Add("message", "");
                }
                return RetData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task logHistory(cargo_masterm old_record, cargo_air_exportm_dto record_dto)
        {

            var old_record_dto = new cargo_air_exportm_dto
            {
                mbl_id = old_record.mbl_id,
                mbl_cfno = old_record.mbl_cfno,
                mbl_refno = old_record.mbl_refno,
                mbl_ref_date = Lib.FormatDate(old_record.mbl_ref_date, Lib.outputDateFormat),
                mbl_shipment_stage_name = old_record.shipstage?.param_name,
                mbl_mode = old_record.mbl_mode,
                mbl_no = old_record.mbl_no,
                mbl_agent_name = old_record.agent?.cust_name,
                mbl_frt_status_name = old_record.mbl_frt_status_name,
                mbl_pol_name = old_record.pol?.param_name,
                mbl_pol_etd = Lib.FormatDate(old_record.mbl_pol_etd, Lib.outputDateFormat),
                mbl_pod_name = old_record.pod?.param_name,
                mbl_pod_eta = Lib.FormatDate(old_record.mbl_pod_eta, Lib.outputDateFormat),
                mbl_country_name = old_record.country?.param_name,
                mbl_liner_name = old_record.liner?.param_name,
                mbl_by_carrier1 = old_record.mbl_by_carrier1,
                mbl_by_carrier2 = old_record.mbl_by_carrier2,
                mbl_by_carrier3 = old_record.mbl_by_carrier3,
                mbl_to_port1 = old_record.mbl_to_port1,
                mbl_to_port2 = old_record.mbl_to_port2,
                mbl_to_port3 = old_record.mbl_to_port3,
                mbl_currency_code = old_record.currency?.param_code,
                mbl_handled_name = old_record.handledby?.param_name,
                mbl_salesman_name = old_record.salesman?.param_name,
                mbl_mawb_weight = old_record.mbl_mawb_weight,
                mbl_mawb_chwt = old_record.mbl_mawb_chwt,
                mbl_3rdparty = old_record.mbl_3rdparty,
                mbl_direct = old_record.mbl_direct,
                mbl_vessel_name = old_record.mbl_vessel_name,
                mbl_voyage = old_record.mbl_voyage,


            };

            await new LogHistorym<cargo_air_exportm_dto>(context)
                .Table("cargo_masterm", log_date)
                .PrimaryKey("mbl_id", record_dto.mbl_id)
                .RefNo(record_dto.mbl_refno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("mbl_cfno", "CF-No", "integer")
                .TrackColumn("mbl_refno", "Reference No")
                .TrackColumn("mbl_ref_date", "Reference Date")
                .TrackColumn("mbl_shipment_stage_name", "Shipment Stage")
                .TrackColumn("mbl_mode", "Mode")
                .TrackColumn("mbl_no", "MBL No")
                .TrackColumn("mbl_agent_name", "Agent Name")
                .TrackColumn("mbl_frt_status_name", "Freight Status")
                .TrackColumn("mbl_pol_name", "POL Name")
                .TrackColumn("mbl_pol_etd", "POL ETD")
                .TrackColumn("mbl_pod_name", "POD Name")
                .TrackColumn("mbl_pod_eta", "POD ETA")
                .TrackColumn("mbl_country_name", "Country Name")
                .TrackColumn("mbl_liner_name", "Liner Name")
                .TrackColumn("mbl_by_carrier1", "By Carrier 1")
                .TrackColumn("mbl_by_carrier2", "By Carrier 2")
                .TrackColumn("mbl_by_carrier3", "By Carrier 3")
                .TrackColumn("mbl_to_port1", "To Port 1")
                .TrackColumn("mbl_to_port2", "To Port 2")
                .TrackColumn("mbl_to_port3", "To Port 3")
                .TrackColumn("mbl_currency_code", "Currency Code")
                .TrackColumn("mbl_handled_name", "Handled By")
                .TrackColumn("mbl_salesman_name", "Salesman Name")
                .TrackColumn("mbl_mawb_weight", "MAWB Weight")
                .TrackColumn("mbl_mawb_chwt", "MAWB Chargeable Weight")
                .TrackColumn("mbl_3rdparty", "Third Party")
                .TrackColumn("mbl_direct", "Direct")
                .TrackColumn("mbl_vessel_name", "Vessel Name")
                .TrackColumn("mbl_voyage", "Voyage")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();


        }

    }
}
