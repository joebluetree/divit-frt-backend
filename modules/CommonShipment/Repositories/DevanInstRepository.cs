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
using Database.Models.CommonShipment;
using Common.DTO.CommonShipment;

//Name : Sourav V
//Created Date : 24/06/2025
//Remark : this file defines functions like Save, Delete, getList and getRecords which save/retrieve data
//version v1- 25/06/2025: added full repository

namespace CommonShipment.Repositories
{
    public class DevanInstRepository : IDevanInstRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;

        public DevanInstRepository(AppDbContext _context, IAuditLog _auditLog)
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

                IQueryable<cargo_devan_inst> query = context.cargo_devan_inst;

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
                    .OrderBy(c => c.di_id)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_devan_inst_dto
                {
                    di_id = e.di_id,
                    di_parent_id = e.di_parent_id,
                    di_parent_type = e.di_parent_type,
                    di_request_to_id = e.di_request_to_id,
                    di_request_to_name = e.di_request_to_name,
                    di_cargo_loc_id = e.di_cargo_loc_id,
                    di_cargo_loc_name = e.di_cargo_loc_name,

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
        public async Task<cargo_devan_inst_dto?> GetRecordAsync(int id)
        {
            try
            {
                IQueryable<cargo_devan_inst> query = context.cargo_devan_inst;
                //.Include(e => e.customer);

                query = query.Where(f => f.di_parent_id == id);

                var Record = await query.Select(e => new cargo_devan_inst_dto
                {
                    di_id = e.di_id,
                    di_parent_id = e.di_parent_id,
                    di_parent_type = e.di_parent_type,
                    di_refno = e.di_refno,
                    di_request_to_id = e.di_request_to_id,
                    di_request_to_code = e.request!.cust_code,
                    di_request_to_name = e.di_request_to_name,
                    di_request_to_add1 = e.di_request_to_add1,
                    di_request_to_add2 = e.di_request_to_add2,
                    di_request_to_add3 = e.di_request_to_add3,
                    di_request_to_add4 = e.di_request_to_add4,

                    di_cargo_loc_id = e.di_cargo_loc_id,
                    di_cargo_loc_code = e.cargoloc!.cust_code,
                    di_cargo_loc_name = e.di_cargo_loc_name,
                    di_cargo_loc_add1 = e.di_cargo_loc_add1,
                    di_cargo_loc_add2 = e.di_cargo_loc_add2,
                    di_cargo_loc_add3 = e.di_cargo_loc_add3,
                    di_cargo_loc_add4 = e.di_cargo_loc_add4,

                    di_remark1 = e.di_remark1,
                    di_remark2 = e.di_remark2,
                    di_remark3 = e.di_remark3,
                    di_is_devan_sent = e.di_is_devan_sent,
                    di_devan_date = Lib.FormatDate(e.di_devan_date, Lib.outputDateFormat),
                    rec_version = e.rec_version,

                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                {
                    Record = new cargo_devan_inst_dto { di_id = 0 };
                }

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        public async Task<cargo_devan_inst_dto> GetDefaultData(int id, string parent_type)
        {
            try
            {
                cargo_devan_inst_dto? Record = null;

                if (parent_type == "SEA IMPORT")
                {
                    // Load from cargo master(sea import) table
                    Record = await context.cargo_masterm
                        .Where(f => f.mbl_id == id && f.mbl_mode == parent_type)
                        .Select(e => new cargo_devan_inst_dto
                        {
                            di_parent_id = e.mbl_id,
                            di_refno = e.mbl_refno,
                            rec_branch_id = e.rec_branch_id,
                            rec_company_id = e.rec_company_id,
                        }).FirstOrDefaultAsync();
                }
                if (parent_type == "SEA IMPORT H")
                {
                    // Load from cargo house(sea import) table
                    Record = await context.cargo_housem
                        .Where(f => f.hbl_id == id && f.hbl_mode == "SEA IMPORT")
                        .Select(e => new cargo_devan_inst_dto
                        {
                            di_parent_id = e.hbl_id,
                            di_refno = e.hbl_houseno,
                            rec_branch_id = e.rec_branch_id,
                            rec_company_id = e.rec_company_id,
                        }).FirstOrDefaultAsync();
                }

                if (Record == null)
                    throw new Exception("No Data Found");

                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }
        private Boolean AllValid(string mode, cargo_devan_inst_dto record_dto, ref string error)
        {
            Boolean bRet = true;
            string str = "";

            if (Lib.IsBlank(record_dto.di_request_to_name))
                str += "Request To Cannot Be Blank!";
            if (Lib.IsBlank(record_dto.di_cargo_loc_name))
                str += "Cargo Location Cannot Be Blank!";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }

            return bRet;
        }

        public async Task<cargo_devan_inst_dto> SaveAsync(int id, string mode, cargo_devan_inst_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_devan_inst_dto _Record = await SaveParentAsync(id, mode, record_dto);
                // await CommonLib.SavediSummary(this.context, record_dto.di_parent_id, record_dto.di_parent_type);
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

        public async Task<cargo_devan_inst_dto> SaveParentAsync(int id, string mode, cargo_devan_inst_dto record_dto)
        {
            cargo_devan_inst? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {

                    Record = new cargo_devan_inst();

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";

                    Record.di_parent_type = record_dto.di_parent_type;
                }
                else
                {
                    Record = await context.cargo_devan_inst
                        .Include(c => c.cargoloc)
                        .Include(c => c.request)
                        .Where(f => f.di_id == id)
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

                Record.di_parent_id = record_dto.di_parent_id;
                Record.di_refno = record_dto.di_refno;
                Record.di_request_to_id = record_dto.di_request_to_id;
                Record.di_request_to_name = record_dto.di_request_to_name;
                Record.di_request_to_add1 = record_dto.di_request_to_add1;
                Record.di_request_to_add2 = record_dto.di_request_to_add2;
                Record.di_request_to_add3 = record_dto.di_request_to_add3;
                Record.di_request_to_add4 = record_dto.di_request_to_add4;
                Record.di_cargo_loc_id = record_dto.di_cargo_loc_id;
                Record.di_cargo_loc_name = record_dto.di_cargo_loc_name;
                Record.di_cargo_loc_add1 = record_dto.di_cargo_loc_add1;
                Record.di_cargo_loc_add2 = record_dto.di_cargo_loc_add2;
                Record.di_cargo_loc_add3 = record_dto.di_cargo_loc_add3;
                Record.di_cargo_loc_add4 = record_dto.di_cargo_loc_add4;
                Record.di_remark1 = record_dto.di_remark1;
                Record.di_remark2 = record_dto.di_remark2;
                Record.di_remark3 = record_dto.di_remark3;
                Record.di_is_devan_sent = record_dto.di_is_devan_sent;
                Record.di_devan_date = Lib.ParseDateOnly(record_dto.di_devan_date!);

                if (mode == "add")
                    await context.cargo_devan_inst.AddAsync(Record);

                await context.SaveChangesAsync();

                record_dto.di_id = Record.di_id;

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

        public async Task<Dictionary<string, object>> DeleteAsync(int id)
        {
            try
            {
                context.Database.BeginTransaction();

                Dictionary<string, object> RetData = new Dictionary<string, object>();
                RetData.Add("id", id);
                var _Record = await context.cargo_devan_inst
                    .FirstOrDefaultAsync(f => f.di_id == id);
                if (_Record == null)
                {
                    RetData.Add("status", false);
                    RetData.Add("message", "No Record Found");
                }
                else
                {
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
        public async Task logHistory(cargo_devan_inst old_record, string mode, cargo_devan_inst_dto record_dto)
        {
            var old_record_dto = new cargo_devan_inst_dto
            {
                di_id = old_record.di_id,
                di_parent_id = old_record.di_parent_id,
                di_parent_type = old_record.di_parent_type,
                di_request_to_id = old_record.di_request_to_id,
                di_request_to_name = old_record.di_request_to_name,
                di_request_to_add1 = old_record.di_request_to_add1,
                di_request_to_add2 = old_record.di_request_to_add2,
                di_request_to_add3 = old_record.di_request_to_add3,
                di_request_to_add4 = old_record.di_request_to_add4,

                di_cargo_loc_id = old_record.di_cargo_loc_id,
                di_cargo_loc_name = old_record.di_cargo_loc_name,
                di_cargo_loc_add1 = old_record.di_cargo_loc_add1,
                di_cargo_loc_add2 = old_record.di_cargo_loc_add2,
                di_cargo_loc_add3 = old_record.di_cargo_loc_add3,
                di_cargo_loc_add4 = old_record.di_cargo_loc_add4,

                di_remark1 = old_record.di_remark1,
                di_remark2 = old_record.di_remark2,
                di_remark3 = old_record.di_remark3,
                di_is_devan_sent = old_record.di_is_devan_sent,
                di_devan_date = Lib.FormatDate(old_record.di_devan_date, Lib.outputDateFormat),
            };

            await new LogHistorym<cargo_devan_inst_dto>(context)
                .Table("cargo_devan_inst", log_date)
                .PrimaryKey("di_parent_id", record_dto.di_parent_id)
                .RefNo(record_dto.di_parent_type!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)

                .TrackColumn("di_request_to_name", "Request To Name")
                .TrackColumn("di_request_to_add1", "Request To Addr1")
                .TrackColumn("di_request_to_add2", "Request To Addr2")
                .TrackColumn("di_request_to_add3", "Request To Addr3")
                .TrackColumn("di_request_to_add4", "Request To Addr4")

                .TrackColumn("di_cargo_loc_name", "Cargo Location Name")
                .TrackColumn("di_cargo_loc_add1", "Cargo Location Addr1")
                .TrackColumn("di_cargo_loc_add2", "Cargo Location Addr2")
                .TrackColumn("di_cargo_loc_add3", "Cargo Location Addr3")
                .TrackColumn("di_cargo_loc_add4", "Cargo Location Addr4")

                .TrackColumn("di_remark1", "Remark 1")
                .TrackColumn("di_remark2", "Remark 2")
                .TrackColumn("di_remark3", "Remark 3")
                .TrackColumn("di_is_devan_sent", "Devan Sent?")
                .TrackColumn("di_devan_date", "Devan Date")

                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }

    }
}
