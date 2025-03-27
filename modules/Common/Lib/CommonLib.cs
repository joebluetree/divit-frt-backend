using Common.DTO;
using Database.Lib;
using Database.Models;
using Database.Lib.Interfaces;
using Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;


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
        public static decimal? UpdateTeuValue(string cntr_type_name)
        {
            decimal teu = 0;
            if (cntr_type_name == "20")
            {
                teu = 1.0m;
            }
            if (cntr_type_name == "45")
            {
                teu = 2.5m;
            }
            if (cntr_type_name == "40")
            {
                teu = 2.0m;
                if (cntr_type_name == "HC")
                {
                    teu = 2.25m;
                }
            }
            if (cntr_type_name == "LCL")
            {
                teu = 0;
            }
            return teu;
        }
        public static async Task SaveMasterSummary(AppDbContext _context, int mbl_id)//,cargo_sea_exporth_dto record_dto
        {
            context = _context;

            var houseList = context.cargo_housem
                .Where(h => h.hbl_mbl_id == mbl_id)
                .ToList();

            int houseCount = houseList.Count;
            int ShipperCount = houseList
                .Where(h => h.hbl_mbl_id == mbl_id)
                .Select(h => h.hbl_shipper_name)
                .Distinct() //only unique count. needed
                .Count();
            int ConsigneeCount = houseList
                .Where(h => h.hbl_mbl_id == mbl_id)
                .Select(h => h.hbl_consignee_name)
                .Distinct()
                .Count();

            var master_Record = context.cargo_masterm
                .Where(m => m.mbl_id == mbl_id)
                .FirstOrDefault();

            if (master_Record != null)
            {
                master_Record.mbl_house_tot = houseCount;
                master_Record.mbl_shipper_tot = ShipperCount;
                master_Record.mbl_consignee_tot = ConsigneeCount;
                await context.SaveChangesAsync();
            }
        }
        public static async Task UpdateHouseShipmentStage(AppDbContext context, int mbl_id, int? newShipmentStageId)
        {
            // Get all houses under that master
            var houseList = await context.cargo_housem
                .Where(h => h.hbl_mbl_id == mbl_id)
                .ToListAsync();

            if (houseList.Any())
            {
                foreach (var house in houseList)
                {
                    house.hbl_shipment_stage_id = newShipmentStageId;
                }

                await context.SaveChangesAsync();
            }
        }
        public static bool IsValidContainerNumber(string cntr_no)
        {
            if (string.IsNullOrWhiteSpace(cntr_no))
                return false;

            return Regex.IsMatch(cntr_no, @"^[A-Z]{4}\d{7}$");
        }

    }

}
