using System;
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
    //Date : 09/04/2025
    //Command :  Create Repository for the Follow Up.
    //version 1.0
    //version 2.0 : Added parent type (cf_mode)

    public class FollowUpRepository : IFollowUpRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditLog auditLog;
        private DateTime log_date;



        public FollowUpRepository(AppDbContext _context, IAuditLog _auditLog)
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


                // var hbl_houseno = "";
                var company_id = 0;
                var branch_id = 0;


                // if (data.ContainsKey("hbl_houseno"))
                //     hbl_houseno = data["hbl_houseno"].ToString();


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

                IQueryable<cargo_followup> query = context.cargo_followup;
                query = query.Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id);


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
                    .OrderBy(c => c.cf_followup_date)
                    .Skip(StartRow)
                    .Take(_page.pageSize);

                var Records = await query.Select(e => new cargo_followup_dto
                {
                    cf_id = e.cf_id,
                    cf_mbl_id = e.cf_mbl_id,
                    cf_mbl_refno = e.master!.mbl_refno,
                    cf_mode = e.cf_mode,
                    cf_assigned_id = e.cf_assigned_id,
                    cf_assigned_name = e.assigned!.user_name,
                    cf_followup_date = Lib.FormatDate(e.cf_followup_date, Lib.outputDateFormat),
                    cf_remarks = e.cf_remarks,

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

        public async Task<cargo_followup_dto?> GetRecordAsync(int id, string parent_type)
        {
            try
            {
                IQueryable<cargo_followup> query = context.cargo_followup;

                query = query.Where(f => f.cf_id == id && f.cf_mode == parent_type);


                var Record = await query.Select(e => new cargo_followup_dto
                {

                    cf_id = e.cf_id,
                    cf_mbl_id = e.cf_mbl_id,
                    cf_mbl_refno = e.master!.mbl_refno,
                    cf_mbl_ref_date = Lib.FormatDate(e.master!.mbl_ref_date, Lib.outputDateFormat),
                    cf_mode = e.cf_mode,
                    cf_user_id = e.cf_user_id,
                    cf_user_name = e.user!.user_name,
                    cf_remarks = e.cf_remarks,
                    cf_followup_date = Lib.FormatDate(e.cf_followup_date, Lib.outputDateFormat),
                    cf_assigned_id = e.cf_assigned_id,
                    cf_assigned_name = e.assigned!.user_name,
                    cf_handled_id = e.master.mbl_handled_id,
                    cf_handled_name = e.master.handledby!.param_name,

                    rec_version = e.rec_version,
                    rec_company_id = e.rec_company_id,
                    rec_branch_id = e.rec_branch_id,
                    rec_created_by = e.rec_created_by,
                    rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                    rec_edited_by = e.rec_edited_by,
                    rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                }).FirstOrDefaultAsync();

                if (Record == null)
                    throw new Exception("No Record Found");
                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }



        public async Task<cargo_followup_dto?> GetDefaultDataAsync(int id)
        {
            try
            {
                var query = context.cargo_masterm
                    .Where(f => f.mbl_id == id);

                var Record = await query
                    .Select(e => new cargo_followup_dto
                    {
                        cf_mbl_id = e.mbl_id,
                        cf_mbl_refno = e.mbl_refno,
                        cf_mode = e.mbl_mode,
                        cf_mbl_ref_date = Lib.FormatDate(e.mbl_ref_date, Lib.outputDateFormat),
                        cf_handled_id = e.mbl_handled_id,
                        cf_handled_name = e.handledby!.param_name,
                        rec_branch_id = e.rec_branch_id,
                        rec_company_id = e.rec_company_id,
                    })
                    .FirstOrDefaultAsync();


                return Record;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public async Task<List<cargo_followup_dto>> GetDetailsAsync(int id, string parent_type)
        {
            var query = from e in context.cargo_followup
                        .Where(e => e.cf_mbl_id == id && e.cf_mode == parent_type)
                        .OrderBy(e => e.cf_followup_date)
                        select (new cargo_followup_dto
                        {
                            cf_id = e.cf_id,
                            cf_mbl_id = e.cf_mbl_id,
                            cf_mbl_refno = e.master!.mbl_refno,
                            cf_mode = e.cf_mode,
                            cf_mbl_ref_date = Lib.FormatDate(e.master.mbl_ref_date, Lib.outputDateFormat),
                            cf_user_id = e.cf_user_id,
                            cf_user_name = e.user!.user_name,
                            cf_remarks = e.cf_remarks,
                            cf_followup_date = Lib.FormatDate(e.cf_followup_date, Lib.outputDateFormat),
                            cf_assigned_id = e.cf_assigned_id,
                            cf_assigned_name = e.assigned!.user_name,
                            cf_handled_id = e.master.mbl_handled_id,
                            cf_handled_name = e.master.handledby!.param_name,

                            rec_version = e.rec_version,
                            rec_branch_id = e.rec_branch_id,
                            rec_company_id = e.rec_company_id,
                            rec_created_by = e.rec_created_by,
                            rec_created_date = Lib.FormatDate(e.rec_created_date, Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Lib.FormatDate(e.rec_edited_date, Lib.outputDateTimeFormat),
                        });

            var records = await query.ToListAsync();
            return records;
        }

        public async Task<cargo_followup_dto> SaveAsync(int id, string mode, cargo_followup_dto record_dto)
        {
            try
            {
                log_date = DbLib.GetDateTime();

                context.Database.BeginTransaction();
                cargo_followup_dto _Record = await SaveParentAsync(id, mode, record_dto);
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

        private Boolean AllValid(string mode, cargo_followup_dto record_dto, ref string error)
        {
            Boolean bRet = true;

            string str = "";

            if (str != "")
            {
                error = error + str;
                bRet = false;
            }
            return bRet;
        }

        public async Task<cargo_followup_dto> SaveParentAsync(int id, string mode, cargo_followup_dto record_dto)
        {
            cargo_followup? Record;
            string error = "";
            try
            {
                if (record_dto == null)
                    throw new Exception("No Data Found");

                if (!AllValid(mode, record_dto, ref error))
                    throw new Exception(error);

                if (mode == "add")
                {

                    Record = new cargo_followup();  //Assigning the values to the database elements
                    Record.cf_mbl_id = record_dto.cf_mbl_id;
                    Record.cf_user_id = record_dto.cf_user_id;
                    Record.cf_assigned_id = record_dto.cf_assigned_id;
                    Record.cf_mode = record_dto.cf_mode;

                    Record.rec_company_id = record_dto.rec_company_id;
                    Record.rec_branch_id = record_dto.rec_branch_id;
                    Record.rec_created_by = record_dto.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    //code retrives the data from cargo_housem table in database
                    Record = await context.cargo_followup
                        .Include(c => c.master)
                        .Include(c => c.assigned)
                        .Include(c => c.user)
                        .Where(f => f.cf_id == id)
                        .FirstOrDefaultAsync();

                    if (Record == null)
                        throw new Exception("Record Not Found");

                    //concurency checking code by using rec_version
                    context.Entry(Record).Property(p => p.rec_version).OriginalValue = record_dto.rec_version;
                    Record.rec_version++;
                    Record.rec_edited_by = record_dto.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                // //Mode is edit, Then Check the LogHistory.
                if (mode == "edit")
                    await logHistory(Record, record_dto);

                //Save values to the database from dto.
                Record.cf_followup_date = Lib.ParseDate(record_dto.cf_followup_date!);
                Record.cf_remarks = record_dto.cf_remarks;

                if (mode == "add")
                    await context.cargo_followup.AddAsync(Record);

                //Save changes to database
                context.SaveChanges();
                //After the save return values to the dto from database table.
                record_dto.cf_id = Record.cf_id;
                record_dto.cf_user_id = Record.cf_user_id;
                record_dto.cf_mbl_id = Record.cf_mbl_id;
                record_dto.cf_assigned_id = Record.cf_assigned_id;

                record_dto.rec_version = Record.rec_version;

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

                return record_dto;
            }
            catch (Exception)
            {
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
                var _Record = await context.cargo_followup
                    .Where(f => f.cf_id == id)
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

        public async Task logHistory(cargo_followup old_record, cargo_followup_dto record_dto)
        {

            var old_record_dto = new cargo_followup_dto
            {
                cf_id = old_record.cf_id,
                cf_mbl_id = old_record.cf_mbl_id,
                cf_mbl_refno = old_record.master!.mbl_refno,
                cf_mode = old_record.cf_mode,
                cf_mbl_ref_date = Lib.FormatDate(old_record.master!.mbl_ref_date, Lib.outputDateFormat),
                cf_user_name = old_record.user!.user_name,
                cf_remarks = old_record.cf_remarks,
                cf_assigned_name = old_record.assigned!.user_name, //handled
                cf_followup_date = Lib.FormatDate(old_record.cf_followup_date, Lib.outputDateFormat),

            };

            await new LogHistorym<cargo_followup_dto>(context)
                .Table("cargo_followup", log_date)
                .PrimaryKey("cf_mbl_id", record_dto.cf_mbl_id)
                .RefNo(record_dto.cf_mbl_refno!)
                .SetCompanyInfo(record_dto.rec_version, record_dto.rec_company_id, record_dto.rec_branch_id, record_dto.rec_created_by!)
                .TrackColumn("cf_mode", "Masters Mode")
                .TrackColumn("cf_mbl_refno", "Masters Ref No")
                .TrackColumn("cf_mbl_ref_date", "Ref Date")
                .TrackColumn("cf_user_name", "User Name")
                .TrackColumn("cf_remarks", "Notes")
                .TrackColumn("cf_assigned_name", "Asssigned To")
                .TrackColumn("cf_followup_date", "Follow up date")
                .SetRecord(old_record_dto, record_dto)
                .LogChangesAsync();
        }


    }

}