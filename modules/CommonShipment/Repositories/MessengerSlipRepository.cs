using Common.DTO.CommonShipment;
using Common.Lib;
using CommonShipment.Interfaces;
using Database;
using Database.Lib;
using Database.Lib.Interfaces;
using Database.Models.BaseTables;
using Database.Models.CommonShipment;
using Microsoft.EntityFrameworkCore;

namespace CommonShipment.Repositories
{
    //Name : Alen Cherian
    //Date : 22/04/2025
    //Command : Create Repository for the Messenger Slip.
    //version 1.0

    public class MessengerSlipRepository : IMessengerSlipRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;

        public MessengerSlipRepository(AppDbContext _context, IAuditLog _auditLog)
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

                var company_id = 0;
                var branch_id = 0;
                var cs_from_date = "";
                var cs_to_date = "";
                var parent_type = "";
                DateOnly? from_date = null;
                DateOnly? to_date = null;


                if (data.ContainsKey("cs_from_date"))
                    cs_from_date = data["cs_from_date"].ToString();
                if (data.ContainsKey("cs_to_date"))
                    cs_to_date = data["cs_to_date"].ToString();

                if (data.ContainsKey("parent_type"))
                    parent_type = data["parent_type"].ToString();


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

                IQueryable<cargo_slip> query = context.cargo_slip;
                query = query.Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id);

                if (!Lib.IsBlank(cs_from_date))
                {
                    from_date = Lib.ParseDateOnly(cs_from_date!);
                    query = query.Where(w => w.cs_date >= from_date);
                }
                if (!Lib.IsBlank(cs_to_date))
                {
                    to_date = Lib.ParseDateOnly(cs_to_date!);
                    query = query.Where(w => w.cs_date <= to_date);
                }

                if (!Lib.IsBlank(parent_type))
                    query = query.Where(w => w.cs_mode!.Contains(parent_type!));


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
                    .OrderBy(c => c.cs_date)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_slip_dto
                {
                    cs_id = e.cs_id,
                    cs_mbl_id = e.cs_mbl_id,
                    cs_refno = e.cs_refno,
                    cs_to_id = e.cs_to_id,
                    cs_to_name = e.to!.cust_name,
                    cs_to_tel = e.to.cust_tel,
                    cs_to_fax = e.to.cust_fax,
                    cs_date = Lib.FormatDate(e.cs_date, Lib.outputDateFormat),

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

        public async Task<cargo_slip_dto?> GetRecordAsync(int id, string parent_type)
        {
            try
            {
                IQueryable<cargo_slip> query = context.cargo_slip;

                query = query.Where(f => f.cs_id == id && f.cs_mode == parent_type);

                var Record = await query.Select(e => new cargo_slip_dto
                {
                    cs_id = e.cs_id,
                    cs_mbl_id = e.cs_mbl_id,
                    cs_refno = e.cs_refno,
                    cs_mbl_no = e.master!.mbl_no,
                    cs_mode = e.cs_mode,
                    cs_slno = e.cs_slno,
                    cs_date = Lib.FormatDate(e.cs_date, Lib.outputDateFormat),
                    cs_time = e.cs_time,
                    cs_ampm = e.cs_ampm,
                    cs_to_id = e.cs_to_id,
                    cs_to_code = e.to!.cust_code,
                    cs_to_name = e.to.cust_name,
                    cs_to_tel = e.to.cust_tel,
                    cs_to_fax = e.to.cust_fax,
                    cs_from_id = e.cs_from_id,
                    cs_from_name = e.from!.param_name,
                    cs_is_drop = e.cs_is_drop,
                    cs_is_pick = e.cs_is_pick,
                    cs_is_receipt = e.cs_is_receipt,
                    cs_is_check = e.cs_is_check,
                    cs_check_det = e.cs_check_det,
                    cs_is_bl = e.cs_is_bl,
                    cs_bl_det = e.cs_bl_det,
                    cs_is_oth = e.cs_is_oth,
                    cs_oth_det = e.cs_oth_det,
                    cs_deliver_to_id = e.cs_deliver_to_id,
                    cs_deliver_to_code = e.deliver!.cust_code,
                    cs_deliver_to_name = e.cs_deliver_to_name,
                    cs_deliver_to_add1 = e.cs_deliver_to_add1,
                    cs_deliver_to_add2 = e.cs_deliver_to_add2,
                    cs_deliver_to_add3 = e.cs_deliver_to_add3,
                    cs_deliver_to_tel = e.cs_deliver_to_tel,
                    cs_deliver_to_attn = e.cs_deliver_to_attn,
                    cs_remark = e.cs_remark,

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

        public async Task<cargo_slip_dto?> GetDefaultDataAsync(int id)
        {
            try
            {
                var query = context.cargo_masterm
                    .Where(f => f.mbl_id == id);

                var Record = await query
                    .Select(e => new cargo_slip_dto
                    {
                        cs_mbl_id = e.mbl_id,
                        cs_refno = e.mbl_refno,
                        cs_mbl_no = e.mbl_no,
                        cs_mode = e.mbl_mode,
                        cs_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                        cs_from_id = e.mbl_handled_id,
                        cs_from_name = e.handledby!.param_name,
                        rec_branch_id = e.rec_branch_id,
                        rec_company_id = e.rec_company_id,
                    })
                    .FirstOrDefaultAsync();

                var captions = "DEFAULT-MESSENGER";

                var settings = await context.mast_settings
                    .Where(f => f.rec_company_id == Record!.rec_company_id && f.rec_branch_id == Record!.rec_branch_id && captions
                    .Contains(f.caption!))
                    .ToListAsync();

                var to_id = settings.FirstOrDefault(s => s.caption == captions)?.value;

                var customer = await context.mast_customerm
                    .Where(f => f.rec_company_id == Record!.rec_company_id && f.cust_id == int.Parse(to_id!))
                    .FirstOrDefaultAsync();

                if (Record != null)
                {

                    Record.cs_to_id = int.Parse(to_id!);
                    Record.cs_to_name = customer!.cust_name;
                    Record.cs_to_code = customer!.cust_code;
                    Record.cs_to_tel = customer!.cust_tel;
                    Record.cs_to_fax = customer!.cust_fax;
                }

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public async Task<List<cargo_slip_dto>> GetDetailsAsync(int id, string parent_type)
        {
            var query = from e in context.cargo_slip
                .Where(e => e.cs_mbl_id == id && e.cs_mode == parent_type)
                .OrderBy(e => e.cs_date)
                        select (new cargo_slip_dto
                        {
                            cs_id = e.cs_id,
                            cs_mbl_id = e.cs_mbl_id,
                            cs_refno = e.cs_refno,
                            cs_mode = e.cs_mode,
                            cs_date = Lib.FormatDate(e.cs_date, Lib.outputDateFormat),
                            cs_time = e.cs_time,
                            cs_ampm = e.cs_ampm,
                            cs_to_id = e.cs_to_id,
                            cs_to_code = e.to!.cust_code,
                            cs_to_name = e.to.cust_name,
                            cs_to_tel = e.to.cust_tel,
                            cs_to_fax = e.to.cust_fax,
                            cs_from_id = e.cs_from_id,
                            cs_from_name = e.master!.salesman!.param_name,
                            cs_is_drop = e.cs_is_drop,
                            cs_is_pick = e.cs_is_pick,
                            cs_is_receipt = e.cs_is_receipt,
                            cs_is_check = e.cs_is_check,
                            cs_check_det = e.cs_check_det,
                            cs_is_bl = e.cs_is_bl,
                            cs_bl_det = e.cs_bl_det,
                            cs_is_oth = e.cs_is_oth,
                            cs_oth_det = e.cs_oth_det,
                            cs_deliver_to_id = e.cs_deliver_to_id,
                            cs_deliver_to_code = e.deliver!.cust_code,
                            cs_deliver_to_name = e.cs_deliver_to_name,
                            cs_deliver_to_add1 = e.cs_deliver_to_add1,
                            cs_deliver_to_add2 = e.cs_deliver_to_add2,
                            cs_deliver_to_add3 = e.cs_deliver_to_add3,
                            cs_deliver_to_tel = e.cs_deliver_to_tel,
                            cs_deliver_to_attn = e.cs_deliver_to_attn,
                            cs_remark = e.cs_remark,

                            rec_version = e.rec_version,
                            rec_branch_id = e.rec_branch_id,
                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        });

            var records = await query.ToListAsync();
            return records;
        }


        public async Task<cargo_slip_dto> SaveAsync(int id, string mode, cargo_slip_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_slip_dto _Record = await SaveParentAsync(id, mode, record_dto);
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

        private Boolean AllValid(string mode, cargo_slip_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            if (Lib.IsZero(record_dto.cs_to_id))
                str += "Shipment Stage To Cannot Be Blank!";


            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<cargo_slip_dto> SaveParentAsync(int id, string mode, cargo_slip_dto record_dto)
        {
            cargo_slip? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    var DefaultCfNo = 1;
                    int iNextNo = 0;

                    if (Lib.IsBlank(record_dto.cs_mode) || Lib.IsZero(record_dto.cs_mbl_id))
                    {
                        record_dto.cs_mode = "GENERAL";
                        iNextNo = GetNextCfNo(record_dto.rec_company_id, record_dto.rec_branch_id, DefaultCfNo);
                        record_dto.cs_refno = $"MS-{iNextNo}";
                        record_dto.cs_slno = iNextNo;
                    }

                    Record = new cargo_slip();
                    Record.cs_refno = record_dto.cs_refno;
                    Record.cs_slno = record_dto.cs_slno;
                    Record.cs_mode = record_dto.cs_mode;
                    Record.cs_mbl_id = record_dto.cs_mbl_id;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.cargo_slip
                        .Include(c => c.master)
                        .Include(c => c.to)
                        .Include(c => c.from)
                        .Include(c => c.deliver)
                        .Where(f => f.cs_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");


                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    record_dto.rec_version = Record.rec_version;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }

                if (mode == "edit")
                    await logHistory(Record, record_dto);

                Record.cs_date = Lib.ParseDateOnly(record_dto.cs_date!);
                Record.cs_time = record_dto.cs_time;
                Record.cs_ampm = record_dto.cs_ampm;
                Record.cs_to_id = record_dto.cs_to_id;
                Record.cs_from_id = record_dto.cs_from_id;
                Record.cs_is_drop = record_dto.cs_is_drop;
                Record.cs_is_pick = record_dto.cs_is_pick;
                Record.cs_is_receipt = record_dto.cs_is_receipt;
                Record.cs_is_bl = record_dto.cs_is_bl;
                Record.cs_bl_det = record_dto.cs_bl_det;
                Record.cs_is_check = record_dto.cs_is_check;
                Record.cs_check_det = record_dto.cs_check_det;
                Record.cs_is_oth = record_dto.cs_is_oth;
                Record.cs_oth_det = record_dto.cs_oth_det;
                Record.cs_deliver_to_id = record_dto.cs_deliver_to_id;
                Record.cs_deliver_to_name = record_dto.cs_deliver_to_name;
                Record.cs_deliver_to_add1 = record_dto.cs_deliver_to_add1;
                Record.cs_deliver_to_add2 = record_dto.cs_deliver_to_add2;
                Record.cs_deliver_to_add3 = record_dto.cs_deliver_to_add3;
                Record.cs_deliver_to_tel = record_dto.cs_deliver_to_tel;
                Record.cs_deliver_to_attn = record_dto.cs_deliver_to_attn;
                Record.cs_remark = record_dto.cs_remark;

                if (mode == "add")
                    await context.cargo_slip.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.cs_id = Record.cs_id;
                record_dto.rec_version = Record.rec_version;
                record_dto.rec_created_by = Record.rec_created_by;
                record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);

                if (mode == "add" && record_dto.cs_mode == "GENERAL")
                {
                    Record.cs_mbl_id = Record.cs_id;
                    await context.SaveChangesAsync();
                }
                record_dto.cs_mbl_id = Record.cs_mbl_id;
                record_dto.cs_refno = Record.cs_refno;

                if (mode == "edit")
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

        public int GetNextCfNo(int company_id, int? branch_id, int defaultCfNo)
        {
            int cfNo = context.cargo_slip
                .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.cs_mode == "GENERAL")
                .Select(e => e.cs_slno)
                .DefaultIfEmpty()
                .Max() ?? 0;
            return cfNo == 0 ? defaultCfNo : cfNo + 1;
        }

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();
                
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_slip
                    .Where(f => f.cs_id == id)
                    .FirstOrDefaultAsync();

                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
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

        public async Task logHistory(cargo_slip old_record, cargo_slip_dto record_dto)
        {

            var old_record_dto = new cargo_slip_dto
            {
                cs_id = old_record.cs_id,
                cs_mbl_id = old_record.cs_mbl_id,
                cs_refno = old_record.cs_refno,
                cs_mode = old_record.cs_mode,
                cs_date = Lib.FormatDate(old_record.cs_date, Lib.outputDateFormat),
                cs_time = old_record.cs_time,
                cs_ampm = old_record.cs_ampm,
                cs_to_id = old_record.cs_to_id,
                cs_to_name = old_record.to?.cust_name,
                cs_to_tel = old_record.to?.cust_tel,
                cs_to_fax = old_record.to?.cust_fax,
                cs_from_id = old_record.cs_from_id,
                cs_from_name = old_record.from?.param_name,
                cs_is_drop = old_record.cs_is_drop,
                cs_is_pick = old_record.cs_is_pick,
                cs_is_receipt = old_record.cs_is_receipt,
                cs_is_check = old_record.cs_is_check,
                cs_check_det = old_record.cs_check_det,
                cs_is_bl = old_record.cs_is_bl,
                cs_bl_det = old_record.cs_bl_det,
                cs_is_oth = old_record.cs_is_oth,
                cs_oth_det = old_record.cs_oth_det,
                cs_deliver_to_id = old_record.cs_deliver_to_id,
                cs_deliver_to_name = old_record.deliver?.cust_name,
                cs_deliver_to_add1 = old_record.cs_deliver_to_add1,
                cs_deliver_to_add2 = old_record.cs_deliver_to_add2,
                cs_deliver_to_add3 = old_record.cs_deliver_to_add3,
                cs_deliver_to_tel = old_record.cs_deliver_to_tel,
                cs_deliver_to_attn = old_record.cs_deliver_to_attn,
                cs_remark = old_record.cs_remark

            };

            await new LogHistorym<cargo_slip_dto>(context)
                .Table("cargo_slip", log_date)
                .PrimaryKey("cs_id", record_dto.cs_id)
                .RefNo(record_dto.cs_refno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, 0, record_dto.rec_created_by!)
                .TrackColumn("cs_slno", "Slip No", "integer")
                .TrackColumn("cs_mbl_id", "MBL ID", "integer")
                .TrackColumn("cs_mode", "Mode")
                .TrackColumn("cs_date", "Cargo Date")
                .TrackColumn("cs_ampm", "AM/PM")
                .TrackColumn("cs_time", "Time")
                .TrackColumn("cs_to_id", "To ID", "integer")
                .TrackColumn("cs_to_name", "To Name")
                .TrackColumn("cs_to_tel", "To Telephone")
                .TrackColumn("cs_to_fax", "To Fax")
                .TrackColumn("cs_from_id", "From ID", "integer")
                .TrackColumn("cs_from_name", "From Name")
                .TrackColumn("cs_is_drop", "Is Drop")
                .TrackColumn("cs_is_pick", "Is Pick")
                .TrackColumn("cs_is_receipt", "Is Receipt")
                .TrackColumn("cs_is_check", "Is Check")
                .TrackColumn("cs_check_det", "Check Details")
                .TrackColumn("cs_is_bl", "Is BL")
                .TrackColumn("cs_bl_det", "BL Details")
                .TrackColumn("cs_is_oth", "Is Other")
                .TrackColumn("cs_oth_det", "Other Details")
                .TrackColumn("cs_deliver_to_id", "Deliver To ID", "integer")
                .TrackColumn("cs_deliver_to_name", "Deliver To Name")
                .TrackColumn("cs_deliver_to_add1", "Deliver Address Line 1")
                .TrackColumn("cs_deliver_to_add2", "Deliver Address Line 2")
                .TrackColumn("cs_deliver_to_add3", "Deliver Address Line 3")
                .TrackColumn("cs_deliver_to_tel", "Deliver Telephone")
                .TrackColumn("cs_deliver_to_attn", "Deliver Attention")
                .TrackColumn("cs_remark", "Remark")

                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();


        }


    }
}