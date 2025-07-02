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
using System.Diagnostics.Eventing.Reader;
using Cargo.Interfaces;

namespace SeaExport.Repositories
{
    public class CargoCooRepository : ICargoCooRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;
        private string smbld_mode = "SEA EXPORT";
        public CargoCooRepository(AppDbContext _context, IAuditLog _auditLog)
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
                var mbld_mode = "";
                var mbld_from_date = "";
                var mbld_to_date = "";
                var mbld_refno = "";
                var mbld_agent_name = "";
                var mbld_pol_name = "";
                var mbld_pod_name = "";

                var company_id = 0;
                var branch_id = 0;

                if (data.ContainsKey("mbld_mode"))
                    mbld_mode = data["mbld_mode"].ToString();
                if (data.ContainsKey("mbld_from_date"))
                    mbld_from_date = data["mbld_from_date"].ToString();
                if (data.ContainsKey("mbld_to_date"))
                    mbld_to_date = data["mbld_to_date"].ToString();
                if (data.ContainsKey("mbld_refno"))
                    mbld_refno = data["mbld_refno"].ToString();
                if (data.ContainsKey("mbld_agent_name"))
                    mbld_agent_name = data["mbld_agent_name"].ToString();
                if (data.ContainsKey("mbld_pol_name"))
                    mbld_pol_name = data["mbld_pol_name"].ToString();
                if (data.ContainsKey("mbld_pod_name"))
                    mbld_pod_name = data["mbld_pod_name"].ToString();

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

                IQueryable<cargo_coo> query = context.cargo_coo;
                // .Include(e => e.customer);

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);
                query = query.Where(w => w.mbld_mode == smbld_mode);

                if (!Lib.IsBlank(mbld_agent_name))
                    query = query.Where(w => w.agent!.cust_name!.Contains(mbld_agent_name!));

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
                    .OrderBy(c => c.mbld_exp_ref)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_coo_dto
                {
                    mbld_id = e.mbld_id,
                    // mbld_no = e.mbld_no,
                    mbld_agent_name = e.agent!.cust_name,
                    mbld_shipper_name = e.shipper!.cust_name,
                    mbld_consignee_name = e.consignee!.cust_name,
                    mbld_pol_name = e.mbld_pol_name,
                    mbld_pod_name = e.mbld_pod_name,
                    mbld_handled_name = e.handledby!.param_name,

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
        public async Task<cargo_coo_dto?> GetRecordAsync(int id, string parent_type)
        {
            try
            {
                IQueryable<cargo_coo> query = context.cargo_coo;
                //.Include(e => e.customer);

                query = query.Where(f => f.mbld_parent_id == id && f.mbld_mode == parent_type);

                var Record = await query.Select(e => new cargo_coo_dto
                {
                    mbld_id = e.mbld_id,
                    mbld_parent_id = e.mbld_parent_id,
                    mbld_mode = e.mbld_mode,
                    mbld_exp_ref = e.mbld_exp_ref,

                    mbld_shipper_id = e.mbld_shipper_id,
                    mbld_shipper_code = e.shipper!.cust_code,
                    mbld_shipper_name = e.mbld_shipper_name,
                    mbld_shipper_add1 = e.mbld_shipper_add1,
                    mbld_shipper_add2 = e.mbld_shipper_add2,
                    mbld_shipper_add3 = e.mbld_shipper_add3,
                    mbld_shipper_add4 = e.mbld_shipper_add4,

                    mbld_consignee_id = e.mbld_consignee_id,
                    mbld_consignee_code = e.consignee!.cust_code,
                    mbld_consignee_name = e.mbld_consignee_name,
                    mbld_consignee_add1 = e.mbld_consignee_add1,
                    mbld_consignee_add2 = e.mbld_consignee_add2,
                    mbld_consignee_add3 = e.mbld_consignee_add3,
                    mbld_consignee_add4 = e.mbld_consignee_add4,

                    mbld_notify_id = e.mbld_notify_id,
                    mbld_notify_code = e.notify!.cust_code,
                    mbld_notify_name = e.mbld_notify_name,
                    mbld_notify_add1 = e.mbld_notify_add1,
                    mbld_notify_add2 = e.mbld_notify_add2,
                    mbld_notify_add3 = e.mbld_notify_add3,
                    mbld_notify_add4 = e.mbld_notify_add4,

                    mbld_agent_id = e.mbld_agent_id,
                    mbld_agent_name = e.agent!.cust_name,
                    mbld_place_receipt = e.mbld_place_receipt,
                    mbld_pol_name = e.mbld_pol_name,
                    mbld_pod_name = e.mbld_pod_name,
                    mbld_place_delivery = e.mbld_place_delivery,
                    mbld_move_type = e.mbld_move_type,
                    mbld_is_cntrized = e.mbld_is_cntrized,
                    mbld_handled_id = e.mbld_handled_id,
                    mbld_handled_name = e.handledby!.param_name,
                    mbld_print_vsl_voy = e.mbld_print_vsl_voy,
                    mbld_clean = e.mbld_clean,

                    mbld_cbm = e.mbld_cbm,
                    mbld_weight = e.mbld_weight,
                    mbld_lbs = e.mbld_lbs,
                    mbld_cft = e.mbld_cft,

                    mbld_remark1 = e.mbld_remark1,
                    mbld_remark2 = e.mbld_remark2,
                    mbld_remark3 = e.mbld_remark3,
                    mbld_print_kgs = e.mbld_print_kgs,
                    mbld_print_lbs = e.mbld_print_lbs,
                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    Record = new cargo_coo_dto { mbld_id = 0 };

                await GetCargoDesc(Record);
                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task GetCargoDesc(cargo_coo_dto Record)
        {
            //setting initial value to null or new,
            for (int i = 1; i <= 17; i++)
            {
                Record.GetType().GetProperty($"marks{i}")?.SetValue(Record, new cargo_desc_dto());
            }

            // retriving from. db
            var records = await context.cargo_desc
                .Where(a => a.desc_parent_id == Record.mbld_id)
                .ToListAsync();

            foreach (var desc in records)
            {
                var markGroup = new cargo_desc_dto
                {
                    desc_id = desc.desc_id,
                    desc_parent_id = desc.desc_parent_id,
                    desc_parent_type = desc.desc_parent_type,
                    desc_ctr = desc.desc_ctr,
                    desc_mark = desc.desc_mark,
                    desc_package = desc.desc_package,
                    desc_description = desc.desc_description
                };

                Record.GetType().GetProperty($"marks{markGroup.desc_ctr}")?.SetValue(Record, markGroup);
            }
        }
        public async Task<cargo_coo_dto> GetDefaultData(int id, string parent_type)
        {
            try
            {
                IQueryable<cargo_masterm> query = context.cargo_masterm;

                query = query.Where(f => f.mbl_id == id && f.mbl_mode == parent_type);

                var Record = await query.Select(e => new cargo_coo_dto
                {
                    mbld_parent_id = e.mbl_id,
                    mbld_exp_ref = e.mbl_refno,
                    mbld_move_type = e.shipterm!.param_name,

                    mbld_notify_name = "SAME AS CONSIGNEE",
                    rec_branch_id = e.rec_branch_id,
                    rec_company_id = e.rec_company_id,
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<cargo_coo_dto> GetCntrDetails(int id)
        {
            try
            {
                IQueryable<cargo_container> query = context.cargo_container;

                query = query.Where(f => f.cntr_mbl_id == id);

                var Record = await query.Select(e => new cargo_coo_dto
                {
                    marks6 = new cargo_desc_dto
                    {
                        desc_mark = "CONTAINER NO./ SEAL NO."

                    },
                    marks7 = new cargo_desc_dto
                    {
                        desc_mark = !Lib.IsBlank(e.cntr_no) && !Lib.IsBlank(e.cntr_sealno) ? e.cntr_no + "/" + e.cntr_sealno : ""
                    },
                }).FirstOrDefaultAsync();

                if (Record == null)
                {
                    Record = new cargo_coo_dto
                    {
                        marks6 = new cargo_desc_dto
                        {
                            desc_mark = "CONTAINER NO./ SEAL NO."
                        }
                    };
                }
                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<cargo_coo_dto> SaveAsync(int id, string mode, cargo_coo_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_coo_dto _Record = await SaveParentAsync(id, mode, record_dto);
                _Record = await SaveCargoDesc(_Record.mbld_id, mode, record_dto);

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


        private Boolean AllValid(string mode, cargo_coo_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            if (Lib.IsBlank(record_dto.mbld_shipper_code))
                str += "Shipper Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbld_consignee_code))
                str += "Consignee Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbld_agent_name))
                str += "Agent Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbld_handled_name))
                str += "Handled By Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbld_pol_name))
                str += "POL Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.mbld_pod_name))
                str += "POD Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbld_lbs))
                str += "Lbs Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbld_weight))
                str += "Kgs Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbld_cft))
                str += "Cft Cannot Be Blank!";
            if (Lib.IsZero(record_dto.mbld_cbm))
                str += "Cbm Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }

        public async Task<cargo_coo_dto> SaveParentAsync(int id, string mode, cargo_coo_dto record_dto)
        {
            cargo_coo? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {
                    Record = new cargo_coo();

                    Record.mbld_mode = smbld_mode;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.cargo_coo
                        .Include(c => c.handledby)
                        .Include(c => c.agent)
                        .Include(c => c.shipper)
                        .Include(c => c.consignee)
                        .Include(c => c.notify)
                        .Where(f => f.mbld_id == id)
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

                Record.mbld_parent_id = record_dto.mbld_parent_id;
                Record.mbld_exp_ref = record_dto.mbld_exp_ref;
                Record.mbld_shipper_id = record_dto.mbld_shipper_id;
                Record.mbld_shipper_name = record_dto.mbld_shipper_name;
                Record.mbld_shipper_add1 = record_dto.mbld_shipper_add1;
                Record.mbld_shipper_add2 = record_dto.mbld_shipper_add2;
                Record.mbld_shipper_add3 = record_dto.mbld_shipper_add3;
                Record.mbld_shipper_add4 = record_dto.mbld_shipper_add4;
                Record.mbld_consignee_id = record_dto.mbld_consignee_id;
                Record.mbld_consignee_name = record_dto.mbld_consignee_name;
                Record.mbld_consignee_add1 = record_dto.mbld_consignee_add1;
                Record.mbld_consignee_add2 = record_dto.mbld_consignee_add2;
                Record.mbld_consignee_add3 = record_dto.mbld_consignee_add3;
                Record.mbld_consignee_add4 = record_dto.mbld_consignee_add4;
                Record.mbld_notify_id = record_dto.mbld_notify_id;
                Record.mbld_notify_name = record_dto.mbld_notify_name;
                Record.mbld_notify_add1 = record_dto.mbld_notify_add1;
                Record.mbld_notify_add2 = record_dto.mbld_notify_add2;
                Record.mbld_notify_add3 = record_dto.mbld_notify_add3;
                Record.mbld_notify_add4 = record_dto.mbld_notify_add4;
                Record.mbld_agent_id = record_dto.mbld_agent_id;
                Record.mbld_place_receipt = record_dto.mbld_place_receipt;
                Record.mbld_pol_name = record_dto.mbld_pol_name;
                Record.mbld_pod_name = record_dto.mbld_pod_name;
                Record.mbld_place_delivery = record_dto.mbld_place_delivery;
                Record.mbld_move_type = record_dto.mbld_move_type;
                Record.mbld_is_cntrized = record_dto.mbld_is_cntrized;
                Record.mbld_handled_id = record_dto.mbld_handled_id;
                Record.mbld_print_vsl_voy = record_dto.mbld_print_vsl_voy;
                Record.mbld_lbs = record_dto.mbld_lbs;
                Record.mbld_weight = record_dto.mbld_weight;
                Record.mbld_cft = record_dto.mbld_cft;
                Record.mbld_cbm = record_dto.mbld_cbm;

                if (mode == "add")
                    await context.cargo_coo.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.mbld_id = Record.mbld_id;

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
            catch (Exception)
            {
                // throw new Exception(Ex.Message.ToString());
                throw;
            }

        }
        public async Task<cargo_coo_dto> SaveCargoDesc(int id, string mode, cargo_coo_dto record_dto)
        {
            try
            {
                var marks = new List<cargo_desc_dto?>
                {
                    record_dto.marks1,
                    record_dto.marks2,
                    record_dto.marks3,
                    record_dto.marks4,
                    record_dto.marks5,
                    record_dto.marks6,
                    record_dto.marks7,
                    record_dto.marks8,
                    record_dto.marks9,
                    record_dto.marks10,
                    record_dto.marks11,
                    record_dto.marks12,
                    record_dto.marks13,
                    record_dto.marks14,
                    record_dto.marks15,
                    record_dto.marks16,
                    record_dto.marks17,

                };

                await SaveMarksandNumber(id, mode, marks, record_dto);

                return record_dto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<cargo_coo_dto> SaveMarksandNumber(int id, string mode, List<cargo_desc_dto?> marks, cargo_coo_dto record_dto)
        {
            cargo_desc? Record;
            // Boolean bOk = true;
            string DescMode = "";
            int ctr = 0;

            try
            {
                if (marks == null || marks.Count == 0)
                    throw new Exception("Marks and Numbers are NULL");

                // int ctr = 1;
                foreach (var markItem in marks)
                {
                    Boolean bOk = true;
                    if (markItem == null)
                    {
                        throw new Exception("Description Record Not Found" + markItem!.desc_ctr);
                    }

                    ctr++;
                    var desc_id = markItem.desc_id;
                    var mark = markItem.desc_mark;
                    var package = markItem.desc_package;
                    var description = markItem.desc_description;


                    if (Lib.IsBlank(mark) && Lib.IsBlank(package) && Lib.IsBlank(description))
                        bOk = false;
                    if (bOk == false && desc_id == 0)
                        continue;


                    if (bOk && desc_id == 0)  // new record && id!=0
                        DescMode = "add";
                    if (bOk && desc_id != 0)  // edit record                  
                        DescMode = "edit";
                    if (bOk == false && desc_id != 0)  // delete record                 
                        DescMode = "delete";

                    var NewRecord_dto = new cargo_desc_dto
                    {
                        desc_parent_id = record_dto.desc_parent_id,
                        desc_id = desc_id,
                        desc_ctr = ctr,
                        desc_mark = mark,
                        desc_package = package,
                        desc_description = description,
                        rec_company_id = record_dto.rec_company_id,
                        rec_branch_id = record_dto.rec_branch_id,
                        rec_created_by = record_dto.rec_created_by,
                        rec_version = record_dto.rec_version
                    };

                    if (DescMode == "add")
                    {
                        Record = new cargo_desc();

                        Record.rec_company_id = record_dto.rec_company_id;
                        Record.rec_branch_id = record_dto.rec_branch_id;
                        Record.rec_created_by = record_dto.rec_created_by;
                        Record.rec_created_date = DbLib.GetDateTime();
                        Record.rec_locked = "N";

                        Record.desc_parent_type = "COO-DESC";
                        Record.desc_parent_id = id;

                        if (mode == "edit")
                            await logHistoryCargoDesc(Record, NewRecord_dto, record_dto.mbld_exp_ref!, record_dto.mbld_id);//,record_dto.rec_version

                        Record.desc_ctr = NewRecord_dto.desc_ctr;
                        Record.desc_mark = NewRecord_dto.desc_mark;
                        Record.desc_package = NewRecord_dto.desc_package;
                        Record.desc_description = NewRecord_dto.desc_description;
                        Record.rec_version = record_dto.rec_version;

                    }
                    else
                    {
                        Record = await context.cargo_desc
                            .Where(f => f.desc_parent_id == id && f.desc_id == desc_id)//&& f.desc_id == desc_id
                            .FirstOrDefaultAsync();

                        if (Record == null)
                            throw new Exception("Description record Not Found" + Record!.desc_ctr.ToString());

                        if (DescMode == "edit" || DescMode == "delete")
                        {


                            await logHistoryCargoDesc(Record, NewRecord_dto, record_dto.mbld_exp_ref!, record_dto.mbld_id);//,record_dto.rec_version

                            // Record.desc_ctr = NewRecord_dto.desc_ctr;
                            Record.desc_mark = NewRecord_dto.desc_mark;
                            Record.desc_package = NewRecord_dto.desc_package;
                            Record.desc_description = NewRecord_dto.desc_description;

                            Record.rec_edited_by = record_dto.rec_created_by;
                            Record.rec_edited_date = DbLib.GetDateTime();
                            // Record.rec_version =record_dto.rec_version;
                        }
                    }

                    if (DescMode == "add")
                        await context.cargo_desc.AddAsync(Record);
                    if (DescMode == "delete")
                    {
                        context.cargo_desc.Remove(Record);
                        desc_id = 0;
                        Record.desc_ctr = 0;
                        Record.desc_parent_id = 0;
                        Record.desc_parent_type = "";
                    }

                    await context.SaveChangesAsync();

                    // record_dto.rec_version = Record.rec_version;
                    if (DescMode == "add")
                        desc_id = Record.desc_id;

                    markItem.desc_id = desc_id;
                    markItem.desc_ctr = Record.desc_ctr;
                    markItem.desc_parent_id = Record.desc_parent_id;
                    markItem.desc_parent_type = Record.desc_parent_type;
                }
                return record_dto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_coo
                    .FirstOrDefaultAsync(f => f.mbld_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
                    await CommonLib.DeleteDesc(context, id);
                    await CommonLib.DeleteMemo(context, id);

                    context.Remove(_Record);
                    context.SaveChanges();

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

        public async Task logHistory(cargo_coo old_record, cargo_coo_dto record_dto)
        {

            var old_record_dto = new cargo_coo_dto
            {
                mbld_id = old_record.mbld_id,
                mbld_exp_ref = old_record.mbld_exp_ref,
                mbld_shipper_id = old_record.mbld_shipper_id,
                mbld_shipper_name = old_record.mbld_shipper_name,
                mbld_shipper_add1 = old_record.mbld_shipper_add1,
                mbld_shipper_add2 = old_record.mbld_shipper_add2,
                mbld_shipper_add3 = old_record.mbld_shipper_add3,
                mbld_shipper_add4 = old_record.mbld_shipper_add4,
                mbld_consignee_id = old_record.mbld_consignee_id,
                mbld_consignee_name = old_record.mbld_consignee_name,
                mbld_consignee_add1 = old_record.mbld_consignee_add1,
                mbld_consignee_add2 = old_record.mbld_consignee_add2,
                mbld_consignee_add3 = old_record.mbld_consignee_add3,
                mbld_consignee_add4 = old_record.mbld_consignee_add4,
                mbld_notify_id = old_record.mbld_notify_id,
                mbld_notify_name = old_record.mbld_notify_name,
                mbld_notify_add1 = old_record.mbld_notify_add1,
                mbld_notify_add2 = old_record.mbld_notify_add2,
                mbld_notify_add3 = old_record.mbld_notify_add3,
                mbld_notify_add4 = old_record.mbld_notify_add4,
                mbld_agent_id = old_record.mbld_agent_id,
                mbld_agent_name = old_record.agent?.cust_name,
                mbld_place_receipt = old_record.mbld_place_receipt,
                mbld_pol_name = old_record.mbld_pol_name,
                mbld_pod_name = old_record.mbld_pod_name,
                mbld_place_delivery = old_record.mbld_place_delivery,
                mbld_move_type = old_record.mbld_move_type,
                mbld_is_cntrized = old_record.mbld_is_cntrized,
                mbld_handled_id = old_record.mbld_handled_id,
                mbld_handled_name = old_record.handledby?.param_name,
                mbld_print_vsl_voy = old_record.mbld_print_vsl_voy,
                mbld_lbs = old_record.mbld_lbs,
                mbld_weight = old_record.mbld_weight,
                mbld_cft = old_record.mbld_cft,
                mbld_cbm = old_record.mbld_cbm,
            };

            await new LogHistorym<cargo_coo_dto>(context)
                .Table("cargo_coo", log_date)
                .PrimaryKey("mbld_id", record_dto.mbld_id)
                .RefNo(record_dto.mbld_exp_ref!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("mbld_exp_ref", "Export Ref No")
                .TrackColumn("mbld_shipper_name", "Shipper Name")
                .TrackColumn("mbld_shipper_add1", "Shipper Address 1")
                .TrackColumn("mbld_shipper_add2", "Shipper Address 2")
                .TrackColumn("mbld_shipper_add3", "Shipper Address 3")
                .TrackColumn("mbld_shipper_add4", "Shipper Address 4")
                .TrackColumn("mbld_consignee_name", "Consignee Name")
                .TrackColumn("mbld_consignee_add1", "Consignee Address 1")
                .TrackColumn("mbld_consignee_add2", "Consignee Address 2")
                .TrackColumn("mbld_consignee_add3", "Consignee Address 3")
                .TrackColumn("mbld_consignee_add4", "Consignee Address 4")
                .TrackColumn("mbld_notify_name", "Notify Name")
                .TrackColumn("mbld_notify_add1", "Notify Address 1")
                .TrackColumn("mbld_notify_add2", "Notify Address 2")
                .TrackColumn("mbld_notify_add3", "Notify Address 3")
                .TrackColumn("mbld_notify_add4", "Notify Address 4")
                .TrackColumn("mbld_agent_name", "Agent")
                .TrackColumn("mbld_place_receipt", "Place of Receipt")
                .TrackColumn("mbld_pol_name", "Port of Loading")
                .TrackColumn("mbld_pod_name", "Port of Discharge")
                .TrackColumn("mbld_place_delivery", "Place of Delivery")
                .TrackColumn("mbld_move_type", "Movement Type")
                .TrackColumn("mbld_is_cntrized", "Is Containerized")
                .TrackColumn("mbld_handled_name", "Handled By Name")
                .TrackColumn("mbld_print_vsl_voy", "Print Vessel/Voyage")
                .TrackColumn("mbld_lbs", "LBS","decimal")
                .TrackColumn("mbld_weight", "Weight","decimal")
                .TrackColumn("mbld_cft", "CFT","decimal")
                .TrackColumn("mbld_cbm", "CBM","decimal")

                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }
        public async Task logHistoryCargoDesc(cargo_desc old_record, cargo_desc_dto NewRecord_dto, string mbld_exp_ref, int mbld_id) // int id, int rec_version
        {
            var old_record_dto = new cargo_desc_dto
            {
                desc_parent_id = old_record.desc_parent_id,
                desc_id = old_record.desc_id,
                desc_ctr = old_record.desc_ctr,
                desc_mark = old_record.desc_mark,
                desc_package = old_record.desc_package,
                desc_description = old_record.desc_description,
            };

            await new LogHistorym<cargo_desc_dto>(context)
            .Table("cargo_coo", log_date)
            .PrimaryKey("desc_id", mbld_id)///hbl id pass while call
            .RefNo(mbld_exp_ref)
            .SetCompanyInfo(NewRecord_dto.rec_version, NewRecord_dto.rec_company_id, NewRecord_dto.rec_branch_id, NewRecord_dto.rec_created_by!)
            .TrackColumn("desc_mark", $"Mark and Nos - {NewRecord_dto.desc_ctr}")
            .TrackColumn("desc_package", $"Package - {NewRecord_dto.desc_ctr}")
            .TrackColumn("desc_description", $"Description - {NewRecord_dto.desc_ctr}")
            .SetRecord(old_record_dto, NewRecord_dto)
            .LogChangesAsync();

        }

    }
}
