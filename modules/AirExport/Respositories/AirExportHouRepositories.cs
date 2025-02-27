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
    //Date : 27/02/2025
    //Command :  Create Repository for the Air Export House.
    //version 1.0

    public class AirExportHouRepository : IAirExportHouRepository
    {

        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        string hbl_mode = "AIR EXPORT";

        public AirExportHouRepository(AppDbContext _context, IAuditLog _auditLog)
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


                var hbl_houseno = "";
                var company_id = 0;
                var branch_id = 0;
                var hbl_from_date = "";
                var hbl_to_date = "";
                DateTime? from_date = null;
                DateTime? to_date = null;


                if (data.ContainsKey("hbl_houseno"))
                    hbl_houseno = data["hbl_houseno"].ToString();
                if (data.ContainsKey("hbl_from_date"))
                    hbl_from_date = data["hbl_from_date"].ToString();
                if (data.ContainsKey("hbl_to_date"))
                    hbl_to_date = data["hbl_to_date"].ToString();


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

                IQueryable<cargo_housem> query = context.cargo_housem;
                query = query.Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.hbl_mode == hbl_mode);

                if (!Lib.IsBlank(hbl_from_date))
                {
                    from_date = Lib.ParseDate(hbl_from_date!);
                    query = query.Where(w => w.hbl_date >= from_date);
                }
                if (!Lib.IsBlank(hbl_to_date))
                {
                    to_date = Lib.ParseDate(hbl_to_date!);
                    query = query.Where(w => w.hbl_date <= to_date);
                }
                if (!Lib.IsBlank(hbl_houseno))
                    query = query.Where(w => w.hbl_houseno!.Contains(hbl_houseno!));


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
                    .OrderBy(c => c.hbl_date)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_air_exporth_dto
                {
                    hbl_id = e.hbl_id,
                    hbl_mbl_id = e.hbl_mbl_id,
                    hbl_houseno = e.hbl_houseno,
                    hbl_mbl_refno = e.master!.mbl_refno,
                    hbl_shipment_stage_id = e.hbl_shipment_stage_id,
                    hbl_shipment_stage_name = e.shipstage!.param_name,
                    hbl_date = Lib.FormatDate(e.hbl_date, Lib.outputDateTimeFormat),
                    hbl_mode = e.hbl_mode,
                    hbl_shipper_id = e.hbl_shipper_id,
                    hbl_shipper_code = e.shipper!.cust_code,
                    hbl_shipper_name = e.shipper!.cust_name,
                    hbl_shipper_add1 = e.shipper!.cust_address1,
                    hbl_shipper_add2 = e.shipper!.cust_address2,
                    hbl_shipper_add3 = e.shipper!.cust_address3,
                    hbl_shipper_add4 = e.hbl_shipper_add4,
                    hbl_shipper_add5 = e.shipper!.cust_tel,
                    hbl_consignee_id = e.hbl_consignee_id,
                    hbl_consigned_code = e.consignee!.cust_code,
                    hbl_consigned_to1 = e.consignee!.cust_name,
                    hbl_consigned_to2 = e.consignee!.cust_address1,
                    hbl_consigned_to3 = e.consignee!.cust_address2,
                    hbl_consigned_to4 = e.consignee!.cust_address3,
                    hbl_consigned_to5 = e.hbl_consigned_to5,
                    hbl_consigned_to6 = e.consignee!.cust_tel,
                    hbl_notify_name = e.hbl_notify_name,
                    hbl_notify_add1 = e.hbl_notify_add1,
                    hbl_notify_add2 = e.hbl_notify_add2,
                    hbl_notify_add3 = e.hbl_notify_add3,

                    hbl_exp_ref1 = e.hbl_exp_ref1,
                    hbl_exp_ref2 = e.hbl_exp_ref2,
                    hbl_exp_ref3 = e.hbl_exp_ref3,
                    hbl_agent_name = e.hbl_agent_name,
                    hbl_agent_city = e.hbl_agent_city,
                    hbl_place_delivery = e.hbl_place_delivery,
                    hbl_iata = e.hbl_iata,
                    hbl_accno = e.hbl_accno,
                    hbl_frt_status_name = e.hbl_frt_status_name,
                    hbl_oc_status = e.hbl_oc_status,
                    hbl_carriage_value = e.hbl_carriage_value,
                    hbl_customs_value = e.hbl_customs_value,
                    hbl_ins_amt = e.hbl_ins_amt,
                    hbl_aesno = e.hbl_aesno,
                    hbl_lcno = e.hbl_lcno,

                    hbl_bltype = e.hbl_bltype,
                    hbl_handled_id = e.hbl_handled_id,
                    hbl_handled_name = e.handledby!.param_name,
                    hbl_salesman_id = e.hbl_salesman_id,
                    hbl_salesman_name = e.salesman!.param_name,
                    hbl_goods_nature = e.hbl_goods_nature,
                    hbl_commodity = e.hbl_commodity,
                    hbl_format_id = e.hbl_format_id,
                    hbl_format_name = e.format!.param_name,
                    hbl_rout1 = e.hbl_rout1,
                    hbl_rout2 = e.hbl_rout2,
                    hbl_rout3 = e.hbl_rout3,
                    hbl_pol_name = e.hbl_pol_name,
                    hbl_pod_name = e.hbl_pod_name,
                    hbl_asarranged_consignee = e.hbl_asarranged_consignee,
                    hbl_asarranged_shipper = e.hbl_asarranged_shipper,

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

        public async Task<cargo_air_exporth_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_housem> query = context.cargo_housem;

                query = query.Where(f => f.hbl_id == id && f.hbl_mode == hbl_mode);

                var Record = await query.Select(e => new cargo_air_exporth_dto
                {
                    hbl_id = e.hbl_id,
                    hbl_mbl_id = e.hbl_mbl_id,
                    hbl_houseno = e.hbl_houseno,
                    hbl_mbl_refno = e.master!.mbl_refno,
                    hbl_shipment_stage_id = e.hbl_shipment_stage_id,
                    hbl_shipment_stage_name = e.shipstage!.param_name,
                    hbl_date = Lib.FormatDate(e.hbl_date, Lib.outputDateTimeFormat),
                    hbl_mode = e.hbl_mode,
                    hbl_shipper_id = e.hbl_shipper_id,
                    hbl_shipper_code = e.shipper!.cust_code,
                    hbl_shipper_name = e.shipper!.cust_name,
                    hbl_shipper_add1 = e.shipper!.cust_address1,
                    hbl_shipper_add2 = e.shipper!.cust_address2,
                    hbl_shipper_add3 = e.shipper!.cust_address3,
                    hbl_shipper_add4 = e.hbl_shipper_add4,
                    hbl_shipper_add5 = e.shipper!.cust_tel,
                    hbl_consignee_id = e.hbl_consignee_id,
                    hbl_consigned_code = e.consignee!.cust_code,
                    hbl_consigned_to1 = e.consignee!.cust_name,
                    hbl_consigned_to2 = e.consignee!.cust_address1,
                    hbl_consigned_to3 = e.consignee!.cust_address2,
                    hbl_consigned_to4 = e.consignee!.cust_address3,
                    hbl_consigned_to5 = e.hbl_consigned_to5,
                    hbl_consigned_to6 = e.consignee!.cust_tel,
                    hbl_notify_name = e.hbl_notify_name,
                    hbl_notify_add1 = e.hbl_notify_add1,
                    hbl_notify_add2 = e.hbl_notify_add2,
                    hbl_notify_add3 = e.hbl_notify_add3,

                    hbl_exp_ref1 = e.hbl_exp_ref1,
                    hbl_exp_ref2 = e.hbl_exp_ref2,
                    hbl_exp_ref3 = e.hbl_exp_ref3,
                    hbl_agent_name = e.hbl_agent_name,
                    hbl_agent_city = e.hbl_agent_city,
                    hbl_place_delivery = e.hbl_place_delivery,
                    hbl_iata = e.hbl_iata,
                    hbl_accno = e.hbl_accno,
                    hbl_frt_status_name = e.hbl_frt_status_name,
                    hbl_oc_status = e.hbl_oc_status,
                    hbl_carriage_value = e.hbl_carriage_value,
                    hbl_customs_value = e.hbl_customs_value,
                    hbl_ins_amt = e.hbl_ins_amt,
                    hbl_aesno = e.hbl_aesno,
                    hbl_lcno = e.hbl_lcno,

                    hbl_bltype = e.hbl_bltype,
                    hbl_handled_id = e.hbl_handled_id,
                    hbl_handled_name = e.handledby!.param_name,
                    hbl_salesman_id = e.hbl_salesman_id,
                    hbl_salesman_name = e.salesman!.param_name,
                    hbl_goods_nature = e.hbl_goods_nature,
                    hbl_commodity = e.hbl_commodity,
                    hbl_format_id = e.hbl_format_id,
                    hbl_format_name = e.format!.param_name,
                    hbl_rout1 = e.hbl_rout1,
                    hbl_rout2 = e.hbl_rout2,
                    hbl_rout3 = e.hbl_rout3,
                    hbl_pol_name = e.hbl_pol_name,
                    hbl_pod_name = e.hbl_pod_name,
                    hbl_asarranged_consignee = e.hbl_asarranged_consignee,
                    hbl_asarranged_shipper = e.hbl_asarranged_shipper,

                    rec_version = e.rec_version,
                    rec_branch_id = e.rec_branch_id,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Qtn Found");
                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }


        public async Task<cargo_air_exporth_dto> SaveAsync(int id, string mode, cargo_air_exporth_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_air_exporth_dto _Record = await SaveParentAsync(id, mode, record_dto);
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

        private Boolean AllValid(string mode, cargo_air_exporth_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            if (Lib.IsZero(record_dto.hbl_shipment_stage_id))
                str += "Shipment Stage To Cannot Be Blank!";
            if (Lib.IsZero(record_dto.hbl_shipper_id))
                str += "Shipper Cannot Be Blank!";
            if (Lib.IsZero(record_dto.hbl_consignee_id))
                str += "Consignee Cannot Be Blank!";
            if (Lib.IsZero(record_dto.hbl_handled_id))
                str += "Handled By Cannot Be Blank!";
            if (Lib.IsZero(record_dto.hbl_salesman_id))
                str += "Sales Rep. Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.hbl_houseno))
                str += "House By Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<cargo_air_exporth_dto> SaveParentAsync(int id, string mode, cargo_air_exporth_dto record_dto)
        {
            cargo_housem? Record;
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
                        throw new Exception("Missing Quotation Prefix/Starting-Number in Branch Settings");
                    }

                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("Quotation Number Cannot Be Generated");
                    }
                    string sref_no = $"{Defaultprefix}{iNextNo}";

                    Record = new cargo_housem();
                    Record.hbl_cfno = iNextNo;
                    Record.hbl_houseno = sref_no;
                    Record.hbl_mode = hbl_mode;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.cargo_housem
                        .Include(c => c.salesman)
                        .Where(f => f.hbl_id == id)
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

                Record.hbl_shipment_stage_id = record_dto.hbl_shipment_stage_id;
                Record.hbl_date = Lib.ParseDate(record_dto.hbl_date!);
                Record.hbl_shipper_id = record_dto.hbl_shipper_id;
                Record.hbl_shipper_name = record_dto.hbl_shipper_name;
                Record.hbl_shipper_add1 = record_dto.hbl_shipper_add1;
                Record.hbl_shipper_add2 = record_dto.hbl_shipper_add2;
                Record.hbl_shipper_add3 = record_dto.hbl_shipper_add3;
                Record.hbl_shipper_add4 = record_dto.hbl_shipper_add4;
                Record.hbl_shipper_add5 = record_dto.hbl_shipper_add5;
                Record.hbl_consignee_id = record_dto.hbl_consignee_id;
                Record.hbl_consigned_to1 = record_dto.hbl_consigned_to1;
                Record.hbl_consigned_to2 = record_dto.hbl_consigned_to2;
                Record.hbl_consigned_to3 = record_dto.hbl_consigned_to3;
                Record.hbl_consigned_to4 = record_dto.hbl_consigned_to4;
                Record.hbl_consigned_to5 = record_dto.hbl_consigned_to5;
                Record.hbl_consigned_to6 = record_dto.hbl_consigned_to6;
                Record.hbl_notify_name = record_dto.hbl_notify_name;
                Record.hbl_notify_add1 = record_dto.hbl_notify_add1;
                Record.hbl_notify_add2 = record_dto.hbl_notify_add2;
                Record.hbl_notify_add3 = record_dto.hbl_notify_add3;

                Record.hbl_exp_ref1 = record_dto.hbl_exp_ref1;
                Record.hbl_exp_ref2 = record_dto.hbl_exp_ref2;
                Record.hbl_exp_ref3 = record_dto.hbl_exp_ref3;
                Record.hbl_agent_name = record_dto.hbl_agent_name;
                Record.hbl_agent_city = record_dto.hbl_agent_city;
                Record.hbl_place_delivery = record_dto.hbl_place_delivery;
                Record.hbl_iata = record_dto.hbl_iata;
                Record.hbl_accno = record_dto.hbl_accno;
                Record.hbl_frt_status_name = record_dto.hbl_frt_status_name;
                Record.hbl_oc_status = record_dto.hbl_oc_status;
                Record.hbl_carriage_value = record_dto.hbl_carriage_value;
                Record.hbl_customs_value = record_dto.hbl_customs_value;
                Record.hbl_ins_amt = record_dto.hbl_ins_amt;
                Record.hbl_aesno = record_dto.hbl_aesno;
                Record.hbl_lcno = record_dto.hbl_lcno;

                Record.hbl_bltype = record_dto.hbl_bltype;
                Record.hbl_handled_id = record_dto.hbl_handled_id;
                Record.hbl_salesman_id = record_dto.hbl_salesman_id;
                Record.hbl_goods_nature = record_dto.hbl_goods_nature;
                Record.hbl_commodity = record_dto.hbl_commodity;
                Record.hbl_format_id = record_dto.hbl_format_id;
                Record.hbl_rout1 = record_dto.hbl_rout1;
                Record.hbl_rout2 = record_dto.hbl_rout2;
                Record.hbl_rout3 = record_dto.hbl_rout3;
                Record.hbl_pol_name = record_dto.hbl_pol_name;
                Record.hbl_pod_name = record_dto.hbl_pod_name;
                Record.hbl_asarranged_consignee = record_dto.hbl_asarranged_consignee;
                Record.hbl_asarranged_shipper = record_dto.hbl_asarranged_shipper;

                if (mode == "add")
                    await context.cargo_housem.AddAsync(Record);
                context.SaveChanges();
                record_dto.hbl_id = Record.hbl_id;
                record_dto.hbl_houseno = Record.hbl_houseno;

                record_dto.rec_version = Record.rec_version;
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.hbl_id != 0)
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
            var CfNo = context.cargo_housem
                .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.hbl_mode == hbl_mode)
                .Select(e => e.hbl_cfno)
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
                var _Record = await context.cargo_housem
                    .Where(f => f.hbl_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
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

        public async Task logHistory(cargo_housem old_record, cargo_air_exporth_dto record_dto)
        {

            var old_record_dto =  new cargo_air_exporth_dto
            {
                hbl_id = old_record.hbl_id,
                hbl_shipper_name = old_record.hbl_shipper_name,
                hbl_shipper_add1 = old_record.hbl_shipper_add1,
                hbl_shipper_add2 = old_record.hbl_shipper_add2,
                hbl_shipper_add3 = old_record.hbl_shipper_add3,
                hbl_shipper_add4 = old_record.hbl_shipper_add4,
                hbl_shipper_add5 = old_record.hbl_shipper_add5,
                hbl_consigned_to1 = old_record.hbl_consigned_to1,
                hbl_consigned_to2 = old_record.hbl_consigned_to2,
                hbl_consigned_to3 = old_record.hbl_consigned_to3,
                hbl_consigned_to4 = old_record.hbl_consigned_to4,
                hbl_consigned_to5 = old_record.hbl_consigned_to5,
                hbl_consigned_to6 = old_record.hbl_consigned_to6,
                hbl_notify_name = old_record.hbl_notify_name,
                hbl_notify_add1 = old_record.hbl_notify_add1,
                hbl_notify_add2 = old_record.hbl_notify_add2,
                hbl_notify_add3 = old_record.hbl_notify_add3,

                hbl_exp_ref1 = old_record.hbl_exp_ref1,
                hbl_exp_ref2 = old_record.hbl_exp_ref2,
                hbl_exp_ref3 = old_record.hbl_exp_ref3,
                hbl_agent_name = old_record.hbl_agent_name,
                hbl_agent_city = old_record.hbl_agent_city,
                hbl_place_delivery = old_record.hbl_place_delivery,
                hbl_iata = old_record.hbl_iata,
                hbl_accno = old_record.hbl_accno,
                hbl_frt_status_name = old_record.hbl_frt_status_name,
                hbl_oc_status = old_record.hbl_oc_status,
                hbl_carriage_value = old_record.hbl_carriage_value,
                hbl_customs_value = old_record.hbl_customs_value,
                hbl_ins_amt = old_record.hbl_ins_amt,
                hbl_aesno = old_record.hbl_aesno,
                hbl_lcno = old_record.hbl_lcno,

                hbl_bltype = old_record.hbl_bltype,
                hbl_goods_nature = old_record.hbl_goods_nature,
                hbl_commodity = old_record.hbl_commodity,
                hbl_rout1 = old_record.hbl_rout1,
                hbl_rout2 = old_record.hbl_rout2,
                hbl_rout3 = old_record.hbl_rout3,
                hbl_pol_name = old_record.hbl_pol_name,
                hbl_pod_name = old_record.hbl_pod_name,
                hbl_asarranged_consignee = old_record.hbl_asarranged_consignee,
                hbl_asarranged_shipper = old_record.hbl_asarranged_shipper

            };

            await new LogHistorym<cargo_air_exporth_dto>(context)
                .Table("cargo_housem", log_date)
                .PrimaryKey("hbl_id", record_dto.hbl_id)
                .RefNo(record_dto.hbl_houseno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("hbl_shipper_name", "Shipper Name")
                .TrackColumn("hbl_shipper_add1", "Shipper Address 1")
                .TrackColumn("hbl_shipper_add2", "Shipper Address 2")
                .TrackColumn("hbl_shipper_add3", "Shipper Address 3")
                .TrackColumn("hbl_shipper_add4", "Shipper Address 4")
                .TrackColumn("hbl_shipper_add5", "Shipper Address 5")
                .TrackColumn("hbl_consigned_to1", "Consigned To 1")
                .TrackColumn("hbl_consigned_to2", "Consigned To 2")
                .TrackColumn("hbl_consigned_to3", "Consigned To 3")
                .TrackColumn("hbl_consigned_to4", "Consigned To 4")
                .TrackColumn("hbl_consigned_to5", "Consigned To 5")
                .TrackColumn("hbl_consigned_to6", "Consigned To 6")
                .TrackColumn("hbl_notify_name", "Notify Name")
                .TrackColumn("hbl_notify_add1", "Notify Address 1")
                .TrackColumn("hbl_notify_add2", "Notify Address 2")
                .TrackColumn("hbl_notify_add3", "Notify Address 3")
                .TrackColumn("hbl_exp_ref1", "Export Reference 1")
                .TrackColumn("hbl_exp_ref2", "Export Reference 2")
                .TrackColumn("hbl_exp_ref3", "Export Reference 3")
                .TrackColumn("hbl_agent_name", "Agent Name")
                .TrackColumn("hbl_agent_city", "Agent City")
                .TrackColumn("hbl_place_delivery", "Place of Delivery")
                .TrackColumn("hbl_iata", "IATA")
                .TrackColumn("hbl_accno", "Account Number")
                .TrackColumn("hbl_frt_status_name", "Freight Status Name")
                .TrackColumn("hbl_oc_status", "OC Status")
                .TrackColumn("hbl_carriage_value", "Carriage Value")
                .TrackColumn("hbl_customs_value", "Customs Value")
                .TrackColumn("hbl_ins_amt", "Insurance Amount")
                .TrackColumn("hbl_aesno", "AES Number")
                .TrackColumn("hbl_lcno", "LC Number")
                .TrackColumn("hbl_bltype", "BL Type")
                .TrackColumn("hbl_goods_nature", "Goods Nature")
                .TrackColumn("hbl_commodity", "Commodity")
                .TrackColumn("hbl_rout1", "Route 1")
                .TrackColumn("hbl_rout2", "Route 2")
                .TrackColumn("hbl_rout3", "Route 3")
                .TrackColumn("hbl_pol_name", "POL Name")
                .TrackColumn("hbl_pod_name", "POD Name")
                .TrackColumn("hbl_asarranged_consignee", "As Arranged Consignee")
                .TrackColumn("hbl_asarranged_shipper", "As Arranged Shipper")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }

    }
}
