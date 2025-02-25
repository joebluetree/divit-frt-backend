using Database;
using Database.Lib;
using Common.DTO.Masters;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;
using SeaExport.Interfaces;
using Common.DTO.SeaExport;
using Database.Models.Cargo;

namespace Masters.Repositories
{
    public class SeaExportmRepository : ISeaExportmRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        private string smbl_mode = "SEA EXPORT";
        public SeaExportmRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var mbl_mode = "";
                var mbl_from_date = "";
                var mbl_to_date = "";
                var mbl_refno = "";
                var company_id = 0;
                var branch_id = 0;

                DateTime? from_date = null;
                DateTime? to_date = null;

                if (data.ContainsKey("mbl_mode"))
                    mbl_mode = data["mbl_mode"].ToString();
                if (data.ContainsKey("mbl_from_date"))
                    mbl_from_date = data["mbl_from_date"].ToString();
                if (data.ContainsKey("mbl_to_date"))
                    mbl_to_date = data["mbl_to_date"].ToString();
                if (data.ContainsKey("mbl_refno"))
                    mbl_refno = data["mbl_refno"].ToString();

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

                IQueryable<cargo_masterm> query = context.cargo_masterm
                    .Include(e => e.customer);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.mbl_mode == smbl_mode);

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
                    .OrderBy(c => c.mbl_refno)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_sea_exportm_dto
                {
                    mbl_id = e.mbl_id,
                    mbl_refno = e.mbl_refno,
                    mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                    mbl_no = e.mbl_no,
                    mbl_agent_name = e.agent!.cust_name,
                    mbl_liner_name = e.liner!.param_name,
                    mbl_pol_name = e.pol!.param_name,
                    mbl_pol_etd = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateFormat),
                    mbl_pod_name = e.pol!.param_name,
                    mbl_pod_eta = Lib.FormatDate(e.mbl_pod_eta, Lib.outputDateFormat),
                    mbl_cntr_type = e.mbl_cntr_type,
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
        public async Task<cargo_sea_exportm_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_masterm> query = context.cargo_masterm;
                //.Include(e => e.customer);

                query = query.Where(f => f.mbl_id == id);

                var Record = await query.Select(e => new cargo_sea_exportm_dto
                {
                    mbl_id = e.mbl_id,
                    mbl_cfno = e.mbl_cfno,
                    mbl_refno = e.mbl_refno,
                    mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                    mbl_shipment_stage_id = e.mbl_shipment_stage_id,
                    mbl_shipment_stage_name = e.shipstage!.param_name,
                    mbl_no = e.mbl_no,
                    mbl_sub_houseno = e.mbl_sub_houseno,
                    mbl_liner_bookingno = e.mbl_liner_bookingno,
                    mbl_agent_id = e.mbl_agent_id,
                    mbl_agent_name = e.agent!.cust_name,
                    mbl_liner_id = e.mbl_liner_id,
                    mbl_liner_name = e.liner!.param_name,
                    mbl_handled_id = e.mbl_handled_id,
                    mbl_handled_name = e.handledby!.param_name,
                    mbl_salesman_id = e.mbl_salesman_id,
                    mbl_salesman_name = e.salesman!.param_name,
                    mbl_frt_status_name = e.mbl_frt_status_name,
                    mbl_ship_term_id = e.mbl_ship_term_id,
                    mbl_ship_term_name = e.shipterm!.param_name,
                    mbl_cntr_type = e.mbl_cntr_type,
                    mbl_direct = e.mbl_direct,
                    mbl_place_delivery = e.mbl_place_delivery,
                    mbl_pol_id = e.mbl_pol_id,
                    mbl_pol_name = e.pol!.param_name,
                    mbl_pol_etd = Lib.FormatDate(e.mbl_pol_etd, Lib.outputDateFormat),
                    mbl_pod_id = e.mbl_pod_id,
                    mbl_pod_name = e.pod!.param_name,
                    mbl_pod_eta = Lib.FormatDate(e.mbl_pod_eta, Lib.outputDateFormat),
                    mbl_pofd_id = e.mbl_pofd_id,
                    mbl_pofd_name = e.pofd!.param_name,
                    mbl_pofd_eta = Lib.FormatDate(e.mbl_pofd_eta, Lib.outputDateFormat),
                    mbl_country_id = e.mbl_country_id,
                    mbl_country_name = e.country!.param_name,
                    mbl_vessel_id = e.mbl_vessel_id,
                    mbl_vessel_code = e.vessel!.param_code,
                    mbl_vessel_name = e.mbl_vessel_name,
                    mbl_voyage = e.mbl_voyage,
                    mbl_book_slno = e.mbl_book_slno,
                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                // Record.cust_contacts = await GetDetAsync(Record.cust_id);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        // public async Task<List<mast_contactm_dto>> GetDetAsync(int id)
        // {
        //     var query = from e in context.mast_contactm
        //                 .Where(a => a.cont_parent_id == id)
        //                 .OrderBy(o => o.cont_id)
        //                 select (new mast_contactm_dto
        //                 {
        //                     cont_id = e.cont_id,
        //                     cont_parent_id = e.cont_parent_id,
        //                     cont_title = e.cont_title,
        //                     cont_name = e.cont_name,
        //                     cont_group_id = e.cont_group_id,
        //                     cont_group_name = e.contgroup!.param_name,
        //                     cont_designation = e.cont_designation,
        //                     cont_email = e.cont_email,
        //                     cont_tel = e.cont_tel,
        //                     cont_mobile = e.cont_mobile,
        //                     cont_remarks = e.cont_remarks,
        //                     cont_country_id = e.cont_country_id,
        //                     cont_country_name = e.country!.param_name,
        //                     rec_created_by = e.rec_created_by,
        //                     rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
        //                     rec_edited_by = e.rec_edited_by,
        //                     rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
        //                 });

        //     var records = await query.ToListAsync();

        //     return records;
        // }

        public async Task<cargo_sea_exportm_dto> SaveAsync(int id, string mode, cargo_sea_exportm_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_sea_exportm_dto _Record = await SaveParentAsync(id, mode, record_dto);
                // _Record = await saveDetAsync(_Record.cust_id, mode, _Record);
                // _Record.cust_contacts = await GetDetAsync(_Record.cust_id);
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


        private Boolean AllValid(string mode, cargo_sea_exportm_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            if (Lib.IsBlank(record_dto.mbl_ref_date))
                str += "Ref Date Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbl_shipment_stage_name))
                str += "Shipment Stage Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }

        public async Task<cargo_sea_exportm_dto> SaveParentAsync(int id, string mode, cargo_sea_exportm_dto record_dto)
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
                    
                    var result = CommonLib.GetBranchsettings(this.context, record_dto.rec_company_id, record_dto.rec_branch_id, "SEA-EXPORT-PREFIX,SEA-EXPORT-STARTING-NO");// 

                    var DefaultCfNo = 0;
                    var Defaultprefix = "";

                    if (result.ContainsKey("SEA-EXPORT-STARTING-NO"))
                    {
                        DefaultCfNo = Lib.StringToInteger(result["SEA-EXPORT-STARTING-NO"]);
                    }
                    if (result.ContainsKey("SEA-EXPORT-PREFIX"))
                    {
                        Defaultprefix = result["SEA-EXPORT-PREFIX"].ToString();
                    }
                    if (Lib.IsBlank(Defaultprefix) || Lib.IsZero(DefaultCfNo))
                    {
                        throw new Exception("Missing Sea Export master Prefix/Starting-Number in Branch Settings");
                    }

                    int iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                    if (Lib.IsZero(iNextNo))
                    {
                        throw new Exception("Quotation Number Cannot Be Generated");
                    }

                    string sqtn_no = $"{Defaultprefix}{iNextNo}";  // for setting quote no by adding propper prefix (here QL - Quotation LCL)
                    string stype = smbl_mode;

                    Record = new cargo_masterm();
                    
                    Record.mbl_cfno = iNextNo;
                    Record.mbl_refno = sqtn_no;
                    Record.mbl_mode = stype;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.cargo_masterm
                        .Include(c => c.country)
                        .Include(c => c.salesman)
                        .Include(c => c.handledby)
                        .Include(c => c.shipstage)
                        .Include(c => c.agent)
                        .Include(c => c.liner)
                        .Include(c => c.pol)
                        .Include(c => c.pod)
                        .Include(c => c.pofd)
                        .Include(c => c.vessel)
                        .Include(c => c.shipterm)
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

                Record.mbl_ref_date = Lib.ParseDate(record_dto.mbl_ref_date!);
                if (Lib.IsZero(record_dto.mbl_shipment_stage_id))
                    Record.mbl_shipment_stage_id = null;
                else
                    Record.mbl_shipment_stage_id = record_dto.mbl_shipment_stage_id;
                Record.mbl_no = record_dto.mbl_no;
                Record.mbl_sub_houseno = record_dto.mbl_sub_houseno;
                Record.mbl_liner_bookingno = record_dto.mbl_liner_bookingno;

                if (Lib.IsZero(record_dto.mbl_agent_id))
                    Record.mbl_agent_id = null;
                else
                    Record.mbl_agent_id = record_dto.mbl_agent_id;

                if (Lib.IsZero(record_dto.mbl_liner_id))
                    Record.mbl_liner_id = null;
                else
                    Record.mbl_liner_id = record_dto.mbl_liner_id;

                if (Lib.IsZero(record_dto.mbl_handled_id))
                    Record.mbl_handled_id = null;
                else
                    Record.mbl_handled_id = record_dto.mbl_handled_id;

                if (Lib.IsZero(record_dto.mbl_salesman_id))
                    Record.mbl_salesman_id = null;
                else
                    Record.mbl_salesman_id = record_dto.mbl_salesman_id;
                    
                Record.mbl_frt_status_name = record_dto.mbl_frt_status_name;
                if (Lib.IsZero(record_dto.mbl_ship_term_id))
                    Record.mbl_ship_term_id = null;
                else
                    Record.mbl_ship_term_id = record_dto.mbl_ship_term_id;

                Record.mbl_cntr_type = record_dto.mbl_cntr_type;
                Record.mbl_direct = record_dto.mbl_direct;
                Record.mbl_place_delivery = record_dto.mbl_place_delivery;

                if (Lib.IsZero(record_dto.mbl_pol_id))
                    Record.mbl_pol_id = null;
                else
                    Record.mbl_pol_id = record_dto.mbl_pol_id;
                Record.mbl_pol_etd = Lib.ParseDate(record_dto.mbl_pol_etd!);

                if (Lib.IsZero(record_dto.mbl_pod_id))
                    Record.mbl_pod_id = null;
                else
                    Record.mbl_pod_id = record_dto.mbl_pod_id;
                Record.mbl_pod_eta = Lib.ParseDate(record_dto.mbl_pod_eta!);

                if (Lib.IsZero(record_dto.mbl_pofd_id))
                    Record.mbl_pofd_id = null;
                else
                    Record.mbl_pofd_id = record_dto.mbl_pofd_id;
                Record.mbl_pofd_eta = Lib.ParseDate(record_dto.mbl_pofd_eta!);

                if (Lib.IsZero(record_dto.mbl_country_id))
                    Record.mbl_country_id = null;
                else
                    Record.mbl_country_id = record_dto.mbl_country_id;

                if (Lib.IsZero(record_dto.mbl_vessel_id))
                    Record.mbl_vessel_id = null;
                else
                    Record.mbl_vessel_id = record_dto.mbl_vessel_id;
                Record.mbl_vessel_name = record_dto.mbl_vessel_name;
                Record.mbl_voyage = record_dto.mbl_voyage;
                Record.mbl_book_slno = record_dto.mbl_book_slno;


                if (mode == "add")
                    await context.cargo_masterm.AddAsync(Record);


                await context.SaveChangesAsync();

                record_dto.mbl_id = Record.mbl_id;
                record_dto.mbl_refno = Record.mbl_refno;
                record_dto.rec_version = Record.rec_version;
                //Lib.AssignDates2DTO(record_dto.cust_id, mode, Record, record_dto);

                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                if (record_dto.mbl_id != 0)
                {
                    record_dto.rec_edited_by = Record.rec_edited_by;
                    record_dto.rec_edited_date = Lib.FormatDate(Record.rec_edited_date, Lib.outputDateTimeFormat);
                }

                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }

        }
        public int GetNextCfNo(int company_id, int? branch_id, int DefaultCfNo)
        {
            // int iDefaultCfNo = int.Parse(DefaultCfNo!);

            var CfNo = context.cargo_masterm
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.mbl_mode == smbl_mode)
            .Select(e => e.mbl_cfno)
            .DefaultIfEmpty()
            .Max();

            CfNo = CfNo == 0 ? DefaultCfNo : CfNo + 1;
            return CfNo;
        }

        // public async Task<mast_customerm_dto> saveDetAsync(int id, string mode, mast_customerm_dto record_dto)
        // {
        //     mast_contactm? record;
        //     List<mast_contactm_dto> records_dto;
        //     List<mast_contactm> records;
        //     try
        //     {

        //         // get contacts from the front end
        //         records_dto = record_dto.cust_contacts!;
        //         // read the contact details from database
        //         records = await context.mast_contactm
        //             .Include(c => c.country)
        //             .Include(c => c.contgroup)
        //             .Where(w => w.cont_parent_id == id)
        //             .ToListAsync();


        //         if (mode == "edit")
        //             await logHistoryDetail(records, record_dto);



        //         // Remove Deleted Records
        //         foreach (var existing_record in records)
        //         {
        //             var rec = records_dto.Find(f => f.cont_id == existing_record.cont_id);
        //             if (rec == null)
        //                 context.mast_contactm.Remove(existing_record);
        //         }

        //         //Add or Edit Records 
        //         foreach (var rec in records_dto)
        //         {

        //             if (rec.cont_id == 0)
        //             {
        //                 record = new mast_contactm();
        //                 record.rec_company_id = record_dto.rec_company_id;
        //                 record.rec_created_by = record_dto.rec_created_by;
        //                 record.rec_created_date = DbLib.GetDateTime();
        //                 record.rec_locked = "N";
        //             }
        //             else
        //             {
        //                 record = records.Find(f => f.cont_id == rec.cont_id);
        //                 if (record == null)
        //                     throw new Exception("Detail Record Not Found " + rec.cont_id.ToString());

        //                 record.rec_edited_by = record_dto.rec_created_by;
        //                 record.rec_edited_date = DbLib.GetDateTime();
        //             }

        //             record.cont_parent_id = id;
        //             record.cont_title = rec.cont_title;
        //             record.cont_name = rec.cont_name;
        //             record.cont_group_id = rec.cont_group_id;
        //             record.cont_designation = rec.cont_designation;
        //             record.cont_email = rec.cont_email;
        //             record.cont_tel = rec.cont_tel;
        //             record.cont_mobile = rec.cont_mobile;
        //             record.cont_remarks = rec.cont_remarks;
        //             record.cont_country_id = rec.cont_country_id;

        //             if (rec.cont_id == 0)
        //                 await context.mast_contactm.AddAsync(record);
        //         }


        //         context.SaveChanges();
        //         return record_dto;
        //     }
        //     catch (Exception Ex)
        //     {
        //         throw new Exception(Ex.Message.ToString());
        //     }
        // }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_masterm
                    .FirstOrDefaultAsync(f => f.mbl_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    // var _Contact = context.mast_contactm
                    // .Where(c => c.cont_parent_id == id);
                    // if (_Contact.Any())
                    // {
                    //     context.mast_contactm.RemoveRange(_Contact);

                    // }
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
        public async Task logHistory(cargo_masterm old_record, cargo_sea_exportm_dto record_dto)
        {

            var old_record_dto = new cargo_sea_exportm_dto
            {
                mbl_id = old_record.mbl_id,
                mbl_cfno = old_record.mbl_cfno,
                mbl_refno = old_record.mbl_refno,
                mbl_ref_date = Lib.FormatDate(old_record.mbl_ref_date, Lib.outputDateFormat),
                mbl_shipment_stage_name = old_record.shipstage?.param_name,
                mbl_no = old_record.mbl_no,
                mbl_sub_houseno = old_record.mbl_sub_houseno,
                mbl_liner_bookingno = old_record.mbl_liner_bookingno,
                mbl_agent_name = old_record.agent?.cust_name,
                mbl_liner_name = old_record.liner?.param_name,
                mbl_handled_name = old_record.handledby?.param_name,
                mbl_salesman_name = old_record.salesman?.param_name,
                mbl_frt_status_name = old_record.mbl_frt_status_name,
                mbl_ship_term_name = old_record.shipterm?.param_name,
                mbl_cntr_type = old_record.mbl_cntr_type,
                mbl_direct = old_record.mbl_direct,
                mbl_place_delivery = old_record.mbl_place_delivery,
                mbl_pol_name = old_record.pol?.param_name,
                mbl_pol_etd = Lib.FormatDate(old_record.mbl_pol_etd, Lib.outputDateFormat),
                mbl_pod_name = old_record.pod?.param_name,
                mbl_pod_eta = Lib.FormatDate(old_record.mbl_pod_eta, Lib.outputDateFormat),
                mbl_pofd_name = old_record.pofd?.param_name,
                mbl_pofd_eta = Lib.FormatDate(old_record.mbl_pofd_eta, Lib.outputDateFormat),
                mbl_country_name = old_record.country?.param_name,
                mbl_vessel_name = old_record.mbl_vessel_name,
                mbl_voyage = old_record.mbl_voyage,
                mbl_book_slno = old_record.mbl_book_slno,


            };

            await new LogHistorym<cargo_sea_exportm_dto>(context)
                .Table("cargo_masterm", log_date)
                .PrimaryKey("mbl_id", record_dto.mbl_id)
                .RefNo(record_dto.mbl_refno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)                
                .TrackColumn("mbl_cfno", "CF No")
                .TrackColumn("mbl_refno", "Reference No")
                .TrackColumn("mbl_ref_date", "Reference Date")
                .TrackColumn("mbl_shipment_stage_name", "Shipment Stage Name")
                .TrackColumn("mbl_no", "MBL No")
                .TrackColumn("mbl_sub_houseno", "Sub House No")
                .TrackColumn("mbl_liner_bookingno", "Liner Booking No")
                .TrackColumn("mbl_agent_name", "Agent Name")
                .TrackColumn("mbl_liner_name", "Liner Name")
                .TrackColumn("mbl_handled_name", "Handled By Name")
                .TrackColumn("mbl_salesman_name", "Salesman Name")
                .TrackColumn("mbl_frt_status_name", "Freight Status Name")
                .TrackColumn("mbl_ship_term_name", "Shipping Term Name")
                .TrackColumn("mbl_cntr_type", "Container Type")
                .TrackColumn("mbl_direct", "Direct Shipment")
                .TrackColumn("mbl_place_delivery", "Place of Delivery")
                .TrackColumn("mbl_pol_name", "Port of Loading")
                .TrackColumn("mbl_pol_etd", "ETD (POL)")
                .TrackColumn("mbl_pod_name", "Port of Discharge")
                .TrackColumn("mbl_pod_eta", "ETA (POD)")
                .TrackColumn("mbl_pofd_name", "Place of Final Delivery")
                .TrackColumn("mbl_pofd_eta", "ETA (POFD)")
                .TrackColumn("mbl_country_name", "Country Name")
                .TrackColumn("mbl_vessel_name", "Vessel Name")
                .TrackColumn("mbl_voyage", "Voyage")
                .TrackColumn("mbl_book_slno", "Booking Serial No")

                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();

        }
        // public async Task logHistoryDetail(List<mast_contactm> old_records, mast_customerm_dto record_dto)
        // {

        //     var old_records_dto = old_records.Select(record => new mast_contactm_dto
        //     {
        //         cont_id = record.cont_id,
        //         cont_title = record.cont_title,
        //         cont_name = record.cont_name,
        //         cont_group_name = record.contgroup?.param_name,
        //         cont_designation = record.cont_designation,
        //         cont_email = record.cont_email,
        //         cont_tel = record.cont_tel,
        //         cont_mobile = record.cont_mobile,
        //         cont_remarks = record.cont_remarks,
        //         cont_country_name = record.country?.param_name,
        //     }).ToList();

        //     await new LogHistorym<mast_contactm_dto>(context)
        //         .Table("mast_customerm", log_date)
        //         .PrimaryKey("cont_id", record_dto.cust_id)
        //         .RefNo(record_dto.cust_name!)
        //         .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
        //         .TrackColumn("cont_title", "Title")
        //         .TrackColumn("cont_name", "Contact Name")
        //         .TrackColumn("cont_group_name", "Group Name")
        //         .TrackColumn("cont_designation", "Designation")
        //         .TrackColumn("cont_email", "Email")
        //         .TrackColumn("cont_tel", "Telephone")
        //         .TrackColumn("cont_mobile", "Mobile")
        //         .TrackColumn("cont_remarks", "Remarks")
        //         .TrackColumn("cont_country_name", "Country Name")
        //         .SetRecords(old_records_dto, record_dto.cust_contacts!)
        //         .LogChangesAsync();

        // }
    }
}
