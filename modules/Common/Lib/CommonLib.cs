using Common.DTO;
using Database.Lib;
using Database.Models;
using Database.Lib.Interfaces;
using Database;
using Microsoft.EntityFrameworkCore;

//Name : Sourav V
//Created Date : 29/01/2025
//Remark : this file defines common functions which is used in multiple repositories

namespace Common.Lib
{
    public static class CommonLib
    {
        private static AppDbContext? context;
        public static Dictionary<string,string> GetBranchsettings( AppDbContext _context, int company_id, int? branch_id, string? caption)       
        {
            context = _context;

            var result = context.mast_settings
            .Where(i => i.rec_company_id == company_id && i.rec_branch_id == branch_id && i.category == "BRANCH-SETTINGS" && caption!.Contains(i.caption!))
            .ToDictionary( e => e.caption!,  e => e.value!);

            return result;
        }
    }
}