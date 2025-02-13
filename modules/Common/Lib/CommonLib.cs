using Common.DTO;
using Database.Lib;
using Database.Models;
using Database.Lib.Interfaces;
using Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Microsoft.VisualBasic;



//Name : Sourav V
//Created Date : 29/01/2025
//Remark : this file defines common functions which is used in multiple repositories

namespace Common.Lib
{
    public static class CommonLib
    {
        private static AppDbContext? context;
        public static Dictionary<string, object> GetBranchsettings(AppDbContext _context, int company_id, int? branch_id, string? caption)
        {
            context = _context;

            Dictionary<string, object?> result = new Dictionary<string, object?>();

            var captionKeys = caption!
                .Split(',')
                .ToList();

            foreach (var key in captionKeys)
            {
                result[key] = null;  // Default value is null
            }


            var settings = context.mast_settings
                .Where(i => i.rec_company_id == company_id &&
                            i.rec_branch_id == branch_id &&
                            i.category == "BRANCH-SETTINGS" &&
                            captionKeys.Contains(i.caption!))  // Only fetch the settings that match the provided captions
                .ToList();

            foreach (var rec in settings)
            {
                if (rec.@type == "INT")
                {
                    result[rec.caption!] = Database.Lib.Lib.StringToInteger(rec.value!.ToString());
                }
                else if (rec.@type == "STRING")
                {
                    result[rec.caption!] = rec.value!.ToString();
                }
            }

            return result!;

        }

        public static DateTime? ParseDateTimestamp(string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
                return null;
            DateTime parsedDate = DateTime.Parse(dateString);
            return DateTime.SpecifyKind(parsedDate, DateTimeKind.Utc);
        }

    }
}
