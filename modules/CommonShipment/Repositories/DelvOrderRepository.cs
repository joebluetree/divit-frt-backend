using Database;
using Database.Lib;
using Common.DTO.Masters;

using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;
using Database.Models.Masters;
using Database.Models.BaseTables;
using Common.Lib;

using Database.Models.Cargo;
using System.Diagnostics.Eventing.Reader;
using CommonShipment.Interfaces;
using Common.DTO.CommonShipment;

//Name : Sourav V
//Created Date : 17/04/2025
//Remark : this file defines functions like Save, Delete, getList and getRecords which save/retrieve data
//version v1-17-04-2025: added full repository

namespace CommonShipment.Repositories
{
    public class DelvOrderRepository : IDelvOrderRepository

    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;

        public DelvOrderRepository(AppDbContext _context, IAuditLog _auditLog)
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

                IQueryable<cargo_delivery_order> query = context.cargo_delivery_order;

                query = query.Where(w => w.rec_company_id == company_id);
                query = query.Where(w => w.rec_branch_id == branch_id);

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
                    .OrderBy(c => c.do_date)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_delivery_order_dto
                {
                    do_id = e.do_id,
                    do_cfno = e.do_cfno,
                    do_parent_id = e.do_parent_id,
                    do_truck_id = e.do_truck_id,
                    do_truck_code = e.truck!.cust_code,

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
        public async Task<cargo_delivery_order_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_delivery_order> query = context.cargo_delivery_order;
                //.Include(e => e.customer);

                query = query.Where(f => f.do_id == id);

                var Record = await query.Select(e => new cargo_delivery_order_dto
                {
                    do_id = e.do_id,
                    do_cfno = e.do_cfno,
                    do_parent_id = e.do_parent_id,
                    do_truck_id = e.do_truck_id,
                    do_truck_code = e.truck!.cust_code,
                    do_truck_name = e.do_truck_name,
                    do_truck_attn = e.do_truck_attn,
                    do_truck_tel = e.do_truck_tel,
                    do_truck_fax = e.do_truck_fax,
                    do_truck_cc = e.do_truck_cc,
                    do_pickup = e.do_pickup,
                    do_addr1 = e.do_addr1,
                    do_addr2 = e.do_addr2,
                    do_addr3 = e.do_addr3,
                    do_date = Lib.FormatDate(e.do_date, Lib.outputDateFormat),
                    do_time = e.do_time,
                    do_attn = e.do_attn,
                    do_tel = e.do_tel,

                    do_from_id = e.do_from_id,
                    do_from_code = e.fromAdd!.cust_code,
                    do_from_name = e.do_from_name,
                    do_from_addr1 = e.do_from_addr1,
                    do_from_addr2 = e.do_from_addr2,
                    do_from_addr3 = e.do_from_addr3,
                    do_from_addr4 = e.do_from_addr4,
                    do_to_id = e.do_to_id,
                    do_to_code = e.toAdd!.cust_code,
                    do_to_name = e.do_to_name,
                    do_to_addr1 = e.do_to_addr1,
                    do_to_addr2 = e.do_to_addr2,
                    do_to_addr3 = e.do_to_addr3,
                    do_to_addr4 = e.do_to_addr4,

                    do_uom1_id = e.do_uom1_id,
                    do_uom1_name = e.uom1!.param_name,
                    do_desc1 = e.do_desc1,
                    do_tot_piece1 = e.do_tot_piece1,
                    do_wt1 = e.do_wt1,
                    do_cbm_cft1 = e.do_cbm_cft1,

                    do_uom2_id = e.do_uom2_id,
                    do_uom2_name = e.uom2!.param_name,
                    do_desc2 = e.do_desc2,
                    do_tot_piece2 = e.do_tot_piece2,
                    do_wt2 = e.do_wt2,
                    do_cbm_cft2 = e.do_cbm_cft2,

                    do_uom3_id = e.do_uom3_id,
                    do_uom3_name = e.uom3!.param_name,
                    do_desc3 = e.do_desc3,
                    do_tot_piece3 = e.do_tot_piece3,
                    do_wt3 = e.do_wt3,
                    do_cbm_cft3 = e.do_cbm_cft3,

                    do_uom4_id = e.do_uom4_id,
                    do_uom4_name = e.uom4!.param_name,
                    do_desc4 = e.do_desc4,
                    do_tot_piece4 = e.do_tot_piece4,
                    do_wt4 = e.do_wt4,
                    do_cbm_cft4 = e.do_cbm_cft4,

                    do_remark_1 = e.do_remark_1,
                    do_remark_2 = e.do_remark_2,
                    do_remark_3 = e.do_remark_3,
                    do_remark_4 = e.do_remark_4,
                    do_danger_goods = e.do_danger_goods,
                    do_terms_ship = e.do_terms_ship,
                    do_vessel = e.do_vessel,
                    do_voyage = e.do_voyage,
                    do_freight = e.do_freight,// use split
                    do_export_doc = e.do_export_doc,// use split
                    do_order_no = e.do_order_no,
                    do_order_date = Lib.FormatDate(e.do_order_date, Lib.outputDateFormat),
                    do_category = e.do_category,
                    do_is_delivery_sent = e.do_is_delivery_sent,
                    do_delivery_date = Lib.FormatDate(e.do_delivery_date, Lib.outputDateFormat),

                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Data Found");

                Record.do_is_exw = CommonLib.SplitString(Record.do_freight, 0);
                Record.do_is_fob = CommonLib.SplitString(Record.do_freight, 1);
                Record.do_is_fca = CommonLib.SplitString(Record.do_freight, 2);
                Record.do_is_cpu = CommonLib.SplitString(Record.do_freight, 3);
                Record.do_is_ddu = CommonLib.SplitString(Record.do_freight, 4);
                Record.do_is_frt_others = CommonLib.SplitString(Record.do_freight, 5);
                Record.do_freight_remark = CommonLib.SplitString(Record.do_freight, 6);

                Record.do_is_comm_inv = CommonLib.SplitString(Record.do_export_doc, 0);
                Record.do_is_lc = CommonLib.SplitString(Record.do_export_doc, 1);
                Record.do_is_coo = CommonLib.SplitString(Record.do_export_doc, 2);
                Record.do_is_pl = CommonLib.SplitString(Record.do_export_doc, 3);
                Record.do_is_expdec = CommonLib.SplitString(Record.do_export_doc, 4);
                Record.do_is_exp_others = CommonLib.SplitString(Record.do_export_doc, 5);
                Record.do_export_doc_remark = CommonLib.SplitString(Record.do_export_doc, 6);

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        // public async Task<List<cargo_delivery_order_dto>> GetMemoRemarksAsync(int id, string ParentType)
        // {
        //     try
        //     {
        //         var query = from e in context.cargo_delivery_order
        //                     .Where(e => e.memo_parent_id == id && e.memo_parent_type == ParentType)
        //                     .OrderBy(o => o.memo_id)
        //                     select (new cargo_delivery_order_dto
        //                     {
        //                         memo_id = e.memo_id,
        //                         memo_parent_id = e.memo_parent_id,
        //                         memo_parent_type = e.memo_parent_type,
        //                         memo_date = Lib.FormatDate(e.memo_date, Lib.outputDateTimeFormat),
        //                         memo_remarks_id = e.memo_remarks_id,
        //                         memo_remarks_code = e.remarks!.param_code,
        //                         memo_remarks_name = e.memo_remarks_name,
        //                         rec_created_by = e.rec_created_by,
        //                         rec_branch_id = e.rec_branch_id,
        //                         rec_company_id = e.rec_company_id,
        //                     });
        //         var records = await query.ToListAsync();
        //         return records;
        //     }
        //     catch (Exception Ex)
        //     {
        //         throw new Exception(Ex.Message.ToString());
        //     }
        // }
        private Boolean AllValid(string mode, cargo_delivery_order_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";
            if (Lib.IsBlank(record_dto.do_truck_name))
                str += "Trucker Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }

        public async Task<cargo_delivery_order_dto> SaveAsync(int id, string mode, cargo_delivery_order_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_delivery_order_dto _Record = await SaveParentAsync(id, mode, record_dto);
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

        public async Task<cargo_delivery_order_dto> SaveParentAsync(int id, string mode, cargo_delivery_order_dto record_dto)
        {
            cargo_delivery_order? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                var do_freight = $"{record_dto.do_is_exw},{record_dto.do_is_fob},{record_dto.do_is_fca},{record_dto.do_is_cpu},{record_dto.do_is_ddu},{record_dto.do_is_frt_others},{record_dto.do_freight_remark}";
                var do_export_doc = $"{record_dto.do_is_comm_inv},{record_dto.do_is_lc},{record_dto.do_is_coo},{record_dto.do_is_pl},{record_dto.do_is_expdec},{record_dto.do_is_exp_others},{record_dto.do_export_doc_remark}";

                if (mode == "add")
                {

                    Record = new cargo_delivery_order();

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";

                }
                else
                {
                    Record = await context.cargo_delivery_order
                        .Include(c => c.truck)
                        .Include(c => c.fromAdd)
                        .Include(c => c.toAdd)
                        .Include(c => c.uom1)
                        .Include(c => c.uom2)
                        .Include(c => c.uom3)
                        .Include(c => c.uom4)
                        .Where(f => f.do_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }

                if (mode == "edit")
                    await logHistory(Record, mode, record_dto);

                Record.do_cfno = record_dto.do_cfno;
                Record.do_parent_id = record_dto.do_parent_id;
                Record.do_truck_id = record_dto.do_truck_id;
                Record.do_truck_name = record_dto.do_truck_name;
                Record.do_truck_attn = record_dto.do_truck_attn;
                Record.do_truck_tel = record_dto.do_truck_tel;
                Record.do_truck_fax = record_dto.do_truck_fax;
                Record.do_truck_cc = record_dto.do_truck_cc;
                Record.do_pickup = record_dto.do_pickup;
                Record.do_addr1 = record_dto.do_addr1;
                Record.do_addr2 = record_dto.do_addr2;
                Record.do_addr3 = record_dto.do_addr3;
                Record.do_date = Lib.ParseDate(record_dto.do_date!);
                Record.do_time = record_dto.do_time;
                Record.do_attn = record_dto.do_attn;
                Record.do_tel = record_dto.do_tel;

                Record.do_from_id = record_dto.do_from_id;
                Record.do_from_name = record_dto.do_from_name;
                Record.do_from_addr1 = record_dto.do_from_addr1;
                Record.do_from_addr2 = record_dto.do_from_addr2;
                Record.do_from_addr3 = record_dto.do_from_addr3;
                Record.do_from_addr4 = record_dto.do_from_addr4;

                Record.do_to_id = record_dto.do_to_id;
                Record.do_to_name = record_dto.do_to_name;
                Record.do_to_addr1 = record_dto.do_to_addr1;
                Record.do_to_addr2 = record_dto.do_to_addr2;
                Record.do_to_addr3 = record_dto.do_to_addr3;
                Record.do_to_addr4 = record_dto.do_to_addr4;

                Record.do_uom1_id = record_dto.do_uom1_id;
                Record.do_desc1 = record_dto.do_desc1;
                Record.do_tot_piece1 = record_dto.do_tot_piece1;
                Record.do_wt1 = record_dto.do_wt1;
                Record.do_cbm_cft1 = record_dto.do_cbm_cft1;

                Record.do_uom2_id = record_dto.do_uom2_id;
                Record.do_desc2 = record_dto.do_desc2;
                Record.do_tot_piece2 = record_dto.do_tot_piece2;
                Record.do_wt2 = record_dto.do_wt2;
                Record.do_cbm_cft2 = record_dto.do_cbm_cft2;

                Record.do_uom3_id = record_dto.do_uom3_id;
                Record.do_desc3 = record_dto.do_desc3;
                Record.do_tot_piece3 = record_dto.do_tot_piece3;
                Record.do_wt3 = record_dto.do_wt3;
                Record.do_cbm_cft3 = record_dto.do_cbm_cft3;

                Record.do_uom4_id = record_dto.do_uom4_id;
                Record.do_desc4 = record_dto.do_desc4;
                Record.do_tot_piece4 = record_dto.do_tot_piece4;
                Record.do_wt4 = record_dto.do_wt4;
                Record.do_cbm_cft4 = record_dto.do_cbm_cft4;

                Record.do_remark_1 = record_dto.do_remark_1;
                Record.do_remark_2 = record_dto.do_remark_2;
                Record.do_remark_3 = record_dto.do_remark_3;
                Record.do_remark_4 = record_dto.do_remark_4;

                Record.do_danger_goods = record_dto.do_danger_goods;
                Record.do_terms_ship = record_dto.do_terms_ship;
                Record.do_vessel = record_dto.do_vessel;
                Record.do_voyage = record_dto.do_voyage;
                // Record.do_freight = record_dto.do_freight; // use split
                // Record.do_export_doc = record_dto.do_export_doc; // use split

                Record.do_freight = do_freight;
                Record.do_export_doc = do_export_doc; // save as list using comma

                Record.do_order_no = record_dto.do_order_no;
                Record.do_order_date = Lib.ParseDate(record_dto.do_order_date!);
                Record.do_category = record_dto.do_category;
                Record.do_is_delivery_sent = record_dto.do_is_delivery_sent;
                Record.do_delivery_date = Lib.ParseDate(record_dto.do_delivery_date!);


                if (mode == "add")
                    await context.cargo_delivery_order.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.do_id = Record.do_id;

                if (mode == "add")
                {
                    record_dto.rec_created_by = Record.rec_created_by;
                    record_dto.rec_created_date = Lib.FormatDate(Record.rec_created_date, Lib.outputDateTimeFormat);
                }
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

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_delivery_order
                    .FirstOrDefaultAsync(f => f.do_id == id);
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
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public async Task logHistory(cargo_delivery_order old_record, string mode, cargo_delivery_order_dto record_dto)
        {

            var old_record_dto = new cargo_delivery_order_dto
            {
                do_cfno = old_record.do_cfno,
                do_parent_id = old_record.do_parent_id,
                do_truck_id = old_record.do_truck_id,
                do_truck_name = old_record.do_truck_name,
                do_truck_attn = old_record.do_truck_attn,
                do_truck_tel = old_record.do_truck_tel,
                do_truck_fax = old_record.do_truck_fax,
                do_truck_cc = old_record.do_truck_cc,
                do_pickup = old_record.do_pickup,
                do_addr1 = old_record.do_addr1,
                do_addr2 = old_record.do_addr2,
                do_addr3 = old_record.do_addr3,
                do_date = Lib.FormatDate(old_record.do_date, Lib.outputDateTimeFormat),
                do_time = old_record.do_time,
                do_attn = old_record.do_attn,
                do_tel = old_record.do_tel,

                do_from_id = old_record.do_from_id,
                do_from_name = old_record.do_from_name,
                do_from_addr1 = old_record.do_from_addr1,
                do_from_addr2 = old_record.do_from_addr2,
                do_from_addr3 = old_record.do_from_addr3,
                do_from_addr4 = old_record.do_from_addr4,

                do_to_id = old_record.do_to_id,
                do_to_name = old_record.do_to_name,
                do_to_addr1 = old_record.do_to_addr1,
                do_to_addr2 = old_record.do_to_addr2,
                do_to_addr3 = old_record.do_to_addr3,
                do_to_addr4 = old_record.do_to_addr4,

                do_uom1_id = old_record.do_uom1_id,
                do_uom1_name = old_record.uom1!.param_name,
                do_desc1 = old_record.do_desc1,
                do_tot_piece1 = old_record.do_tot_piece1,
                do_wt1 = old_record.do_wt1,
                do_cbm_cft1 = old_record.do_cbm_cft1,

                do_uom2_id = old_record.do_uom2_id,
                do_uom2_name = old_record.uom2!.param_name,
                do_desc2 = old_record.do_desc2,
                do_tot_piece2 = old_record.do_tot_piece2,
                do_wt2 = old_record.do_wt2,
                do_cbm_cft2 = old_record.do_cbm_cft2,

                do_uom3_id = old_record.do_uom3_id,
                do_uom3_name = old_record.uom3!.param_name,
                do_desc3 = old_record.do_desc3,
                do_tot_piece3 = old_record.do_tot_piece3,
                do_wt3 = old_record.do_wt3,
                do_cbm_cft3 = old_record.do_cbm_cft3,

                do_uom4_id = old_record.do_uom4_id,
                do_uom4_name = old_record.uom4!.param_name,
                do_desc4 = old_record.do_desc4,
                do_tot_piece4 = old_record.do_tot_piece4,
                do_wt4 = old_record.do_wt4,
                do_cbm_cft4 = old_record.do_cbm_cft4,

                do_remark_1 = old_record.do_remark_1,
                do_remark_2 = old_record.do_remark_2,
                do_remark_3 = old_record.do_remark_3,
                do_remark_4 = old_record.do_remark_4,

                do_danger_goods = old_record.do_danger_goods,
                do_terms_ship = old_record.do_terms_ship,
                do_vessel = old_record.do_vessel,
                do_voyage = old_record.do_voyage,

                do_freight = old_record.do_freight,
                do_export_doc = old_record.do_export_doc,

                do_is_exw = CommonLib.SplitString(old_record.do_freight, 0),
                do_is_fob = CommonLib.SplitString(old_record.do_freight, 1),
                do_is_fca = CommonLib.SplitString(old_record.do_freight, 2),
                do_is_cpu = CommonLib.SplitString(old_record.do_freight, 3),
                do_is_ddu = CommonLib.SplitString(old_record.do_freight, 4),
                do_is_frt_others = CommonLib.SplitString(old_record.do_freight, 5),
                do_freight_remark = CommonLib.SplitString(old_record.do_freight, 6),

                do_is_comm_inv = CommonLib.SplitString(old_record.do_export_doc, 0),
                do_is_lc = CommonLib.SplitString(old_record.do_export_doc, 1),
                do_is_coo = CommonLib.SplitString(old_record.do_export_doc, 2),
                do_is_pl = CommonLib.SplitString(old_record.do_export_doc, 3),
                do_is_expdec = CommonLib.SplitString(old_record.do_export_doc, 4),
                do_is_exp_others = CommonLib.SplitString(old_record.do_export_doc, 5),
                do_export_doc_remark = CommonLib.SplitString(old_record.do_export_doc, 6),

                do_order_no = old_record.do_order_no,
                do_order_date = Lib.FormatDate(old_record.do_order_date, Lib.outputDateTimeFormat),
                do_category = old_record.do_category,
                do_is_delivery_sent = old_record.do_is_delivery_sent,
                do_delivery_date = Lib.FormatDate(old_record.do_delivery_date, Lib.outputDateTimeFormat)
            };

            await new LogHistorym<cargo_delivery_order_dto>(context)
                .Table("cargo_delivery_order", log_date)
                .PrimaryKey("do_id", record_dto.do_id)
                .RefNo(record_dto.do_order_no!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)

                .TrackColumn("do_truck_name", "Truck Name")
                .TrackColumn("do_truck_attn", "Truck Attn")
                .TrackColumn("do_truck_tel", "Truck Tel")
                .TrackColumn("do_truck_fax", "Truck Fax")
                .TrackColumn("do_truck_cc", "Truck CC")
                .TrackColumn("do_pickup", "Pickup")
                .TrackColumn("do_addr1", "Address 1")
                .TrackColumn("do_addr2", "Address 2")
                .TrackColumn("do_addr3", "Address 3")
                .TrackColumn("do_date", "DO Date")
                .TrackColumn("do_time", "DO Time")
                .TrackColumn("do_attn", "Attn")
                .TrackColumn("do_tel", "Tel")

                .TrackColumn("do_from_name", "From Name")
                .TrackColumn("do_from_addr1", "From Addr1")
                .TrackColumn("do_from_addr2", "From Addr2")
                .TrackColumn("do_from_addr3", "From Addr3")
                .TrackColumn("do_from_addr4", "From Addr4")

                .TrackColumn("do_to_name", "To Name")
                .TrackColumn("do_to_addr1", "To Addr1")
                .TrackColumn("do_to_addr2", "To Addr2")
                .TrackColumn("do_to_addr3", "To Addr3")
                .TrackColumn("do_to_addr4", "To Addr4")

                .TrackColumn("do_uom1_name", "UOM1")
                .TrackColumn("do_desc1", "Desc1")
                .TrackColumn("do_tot_piece1", "Pieces1")
                .TrackColumn("do_wt1", "Weight1")
                .TrackColumn("do_cbm_cft1", "CBM1")

                .TrackColumn("do_uom2_name", "UOM2")
                .TrackColumn("do_desc2", "Desc2")
                .TrackColumn("do_tot_piece2", "Pieces2")
                .TrackColumn("do_wt2", "Weight2")
                .TrackColumn("do_cbm_cft2", "CBM2")

                .TrackColumn("do_uom3_name", "UOM3")
                .TrackColumn("do_desc3", "Desc3")
                .TrackColumn("do_tot_piece3", "Pieces3")
                .TrackColumn("do_wt3", "Weight3")
                .TrackColumn("do_cbm_cft3", "CBM3")

                .TrackColumn("do_uom4_name", "UOM4")
                .TrackColumn("do_desc4", "Desc4")
                .TrackColumn("do_tot_piece4", "Pieces4")
                .TrackColumn("do_wt4", "Weight4")
                .TrackColumn("do_cbm_cft4", "CBM4")

                .TrackColumn("do_remark_1", "Remark 1")
                .TrackColumn("do_remark_2", "Remark 2")
                .TrackColumn("do_remark_3", "Remark 3")
                .TrackColumn("do_remark_4", "Remark 4")

                .TrackColumn("do_danger_goods", "Danger Goods")
                .TrackColumn("do_terms_ship", "Shipping Terms")
                .TrackColumn("do_vessel", "Vessel")
                .TrackColumn("do_voyage", "Voyage")
                .TrackColumn("do_freight", "Freight")

                .TrackColumn("do_is_exw", "Frt-EXW")
                .TrackColumn("do_is_fob", "Frt-FOB")
                .TrackColumn("do_is_fca", "Frt-FCA")
                .TrackColumn("do_is_cpu", "Frt-CPU")
                .TrackColumn("do_is_ddu", "Frt-DDU")
                .TrackColumn("do_is_frt_others", "Frt-Others")
                .TrackColumn("do_freight_remark", "Frt Remark")

                .TrackColumn("do_is_comm_inv", "Exp-Commercial Invoice")
                .TrackColumn("do_is_lc", "Exp-Copy of L/C")
                .TrackColumn("do_is_coo", "Exp Certificate of Origin")
                .TrackColumn("do_is_pl", "Exp Packing List")
                .TrackColumn("do_is_expdec", "Exp-Export Declaration")
                .TrackColumn("do_is_exp_others", "Exp-Others")
                .TrackColumn("do_export_doc_remark", "Export Doc Remark")

                .TrackColumn("do_export_doc", "Export Doc")
                .TrackColumn("do_order_no", "Order No")
                .TrackColumn("do_order_date", "Order Date")
                .TrackColumn("do_category", "Category")
                .TrackColumn("do_is_delivery_sent", "Delivery Sent")
                .TrackColumn("do_delivery_date", "Delivery Date")

                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();

        }

    }
}
