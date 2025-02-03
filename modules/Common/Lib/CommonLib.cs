using Common.DTO;
using Database.Lib;
using Database.Models;
using Database.Lib.Interfaces;
using Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

//Name : Sourav V
//Created Date : 29/01/2025
//Remark : this file defines common functions which is used in multiple repositories

namespace Common.Lib
{
    public static class CommonLib
    {
        private static AppDbContext? context;

        public static Dictionary<string, object> GetBranchsettings(AppDbContext _context, int company_id, int? branch_id, Dictionary<string, object?> caption)
        {
            context = _context;

            Dictionary<string, object> result = new Dictionary<string, object>();

            var captionKeys = caption.Keys.ToList();  // Get the keys for efficient DB query

            var settings = context.mast_settings
                .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.category == "BRANCH-SETTINGS" && captionKeys.Contains(i.caption!))
                .ToList();

            foreach (var rec in settings)
            {
                
                if (rec.@type == "INT")
                {
                    int.TryParse(rec.value!.ToString(), out int intValue);
                    result[rec.caption!] = intValue; 
                }
                if (rec.@type == "STRING")
                {
                    result[rec.caption!] = rec.value!.ToString();
                }

            }

            return result;
        }
    }
}