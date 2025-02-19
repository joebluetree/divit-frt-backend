using Common.DTO.Accounts;
using Database.Lib;
using Database.Models.Accounts;
using Database.Lib.Interfaces;
using Database;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication;
using Database.Lib;

namespace Common.Lib.Accounts
{
    public static class AcctmLib
    {
        private static AppDbContext? context;

        public static async Task<acc_acctm_dto> SaveAsync(AppDbContext _context, string mode, acc_acctm_dto Record_DTO)
        {
            acc_acctm Record;
            try
            {
                context = _context;

                if (Record_DTO == null)
                    throw new Exception("No Data Found To Save");

                AllValid(mode, Record_DTO);

                if (mode == "add")
                {
                    Record = new acc_acctm();
                    Record.rec_company_id = Record_DTO.rec_company_id;
                    Record.rec_created_by = Record_DTO.rec_created_by;
                    Record.rec_created_date = DbLib.GetDateTime();
                    Record.rec_locked = "N";
                }
                else
                {
                    Record = await context.acc_acctm
                        .Where(f => f.acc_id == Record_DTO.acc_id)
                        .FirstOrDefaultAsync() ?? new acc_acctm();

                    //context.Entry(Record).Property(p => p.rec_version).OriginalValue = Record_DTO.rec_version;
                    Record.rec_edited_by = Record_DTO.rec_created_by;
                    Record.rec_edited_date = DbLib.GetDateTime();
                }
                // if (mode == "edit")
                //     await logHistory(Record, Record_DTO);

                Record.acc_code = Record_DTO.acc_code;
                Record.acc_short_name = Record_DTO.acc_short_name;
                Record.acc_name = Record_DTO.acc_name;
                Record.acc_type = Record_DTO.acc_type;
                Record.acc_grp_id = Record_DTO.acc_grp_id;
                Record.acc_row_type = Record_DTO.acc_row_type;


                if (Record_DTO.acc_row_type == "MAIN-CODE")
                {
                    Record.acc_maincode_id = null;
                }
                if (Record_DTO.acc_row_type == "ACC-CODE")
                {
                    if (Record_DTO.acc_maincode_id == null)
                        Record.acc_maincode_id = Record_DTO.acc_id == 0 ? null : Record_DTO.acc_id;
                    else
                        Record.acc_maincode_id = Record_DTO.acc_maincode_id;
                }


                if (mode == "add")
                {
                    await context.acc_acctm.AddAsync(Record);
                }

                if (Record_DTO.acc_row_type == "ACC-CODE")
                {
                    if (Record_DTO.acc_maincode_id == null)
                    {
                        Record.acc_maincode_id = Record.acc_id;
                    }
                }
                await context.SaveChangesAsync();
                Record_DTO.acc_id = Record.acc_id;
                Record_DTO.rec_version = Record.rec_version;
                // Database.Lib.Lib.AssignDates2DTO(Record_DTO.acc_id, mode, Record, Record_DTO);
                Record_DTO.rec_created_by = Record.rec_created_by;
                Record_DTO.rec_created_date = Database.Lib.Lib.FormatDate(Record.rec_created_date, Database.Lib.Lib.outputDateTimeFormat);
                if (Record_DTO.acc_id != 0)
                {
                    Record_DTO.rec_edited_by = Record.rec_edited_by;
                    Record_DTO.rec_edited_date = Database.Lib.Lib.FormatDate(Record.rec_edited_date, Database.Lib.Lib.outputDateTimeFormat);
                }

                return Record_DTO;
            }
            catch (Exception Ex)
            {
                Database.Lib.Lib.getErrorMessage(Ex, "uq", "acc_name", "Name Duplication");
                Database.Lib.Lib.getErrorMessage(Ex, "fk", "acc_maincode_id", "Invalid Main Code");
                throw;
            }
        }

        private static Boolean AllValid(string mode, acc_acctm_dto Record_DTO)
        {
            Boolean bRet = true;
            if (Record_DTO.acc_name == "")
            {
                throw new Exception("Invalid Name");
            }
            return bRet;
        }



    }
}