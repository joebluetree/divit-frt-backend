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
        public static async Task SaveMasterSummary(AppDbContext _context, int? mbl_id)//,cargo_sea_exporth_dto record_dto
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
        public static async Task UpdateHouseShipmentStage(AppDbContext _context, int mbl_id, int? newShipmentStageId)
        {
            context = _context;
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
            return Regex.IsMatch(cntr_no, @"^[A-Z]{4}\d{7}$");
        }


        public static string SplitString(string? data, int iPos, char SplitChar = ',')
        {
            string str = "";

            if (!Database.Lib.Lib.IsBlank(data))
            {
                string[] words = data!.Split(SplitChar);
                if (words.Length > iPos)
                {
                    str = words[iPos];
                }
            }

            return str;
        }

        public static async Task DeleteFollowUp(AppDbContext _context, int id)
        {
            context = _context;

            var followup = await context.cargo_followup
                .Where(c => c.cf_mbl_id == id).ToListAsync();
            if (followup.Any())
            {
                context.cargo_followup.RemoveRange(followup);
            }
        }

        public static async Task DeleteDeliveryOrder(AppDbContext _context, int id)
        {
            context = _context;

            var _deliveryOrders = await context.cargo_delivery_order
                .Where(c => c.do_parent_id == id).ToListAsync();

            if (_deliveryOrders.Any())
            {
                context.cargo_delivery_order.RemoveRange(_deliveryOrders);
            }
        }
        public static async Task DeleteDesc(AppDbContext _context, int id)
        {
            context = _context;

            var descriptions = await context.cargo_desc
                .Where(c => c.desc_parent_id == id).ToListAsync();

            if (descriptions.Any())
            {
                context.cargo_desc.RemoveRange(descriptions);
            }
        }


        public static async Task DeleteMessengerSlip(AppDbContext _context, int id)
        {
            context = _context;

            var MessengerSlip = await context.cargo_slip
                .Where(c => c.cs_mbl_id == id).ToListAsync();
            if (MessengerSlip.Any())
            {
                context.cargo_slip.RemoveRange(MessengerSlip);
            }
        }


        public static async Task DeleteHouses(AppDbContext _context, int id)
        {
            context = _context;

            // Get all house IDs under the given mbl_id
            var houses = await context.cargo_housem
                .Where(c => c.hbl_mbl_id == id)
                .ToListAsync();

            var houseid = houses.Select(c => c.hbl_id).ToList();

            if (houseid.Any())
            {


                await DeleteDesc(context, id);

                // Delete cargo_housem records by creating stub entities

                context.cargo_housem.RemoveRange(houses);
                // Save all changes
                await context.SaveChangesAsync();
            }
        }


        public static async Task DeleteContainer(AppDbContext _context, int id)
        {
            context = _context;

            var containers = await context.cargo_container
                .Where(c => c.cntr_hbl_id == id || c.cntr_mbl_id == id).ToListAsync();

            if (containers.Any())
            {
                context.cargo_container.RemoveRange(containers);
            }
        }
        public static async Task DeleteMemo(AppDbContext _context, int id)
        {
            context = _context;

            var _Memo = await context.cargo_memo
                .Where(c => c.memo_parent_id == id).ToListAsync();

            if (_Memo.Any())
            {
                context.cargo_memo.RemoveRange(_Memo);
            }
        }

        public static async Task SaveDocsSummary(AppDbContext _context, int? parent_id, string? parent_type)
        {
            context = _context;
            if (parent_type == "AIR IMPORT" || parent_type == "AIR EXPORT" || parent_type == "OTHERS" || parent_type == "SEA EXPORT" || parent_type == "SEA IMPORT")
            {
                await UpdateOperationsDocCount(context, parent_id, parent_type);
            }
            if (parent_type == "CUSTOMER")
            {
                await UpdateCustomerDocCount(context, parent_id, parent_type);
            }
            if (parent_type == "LCL"||parent_type == "FCL"||parent_type == "AIR")
            {
                await UpdateQtnmDocCount(context, parent_id, parent_type);
            }
        }

        public static async Task UpdateOperationsDocCount(AppDbContext _context, int? parent_id, string? parent_type)
        {
            context = _context;
            int FilesCount = 0;
            FilesCount = context.mast_fileupload
                .Count(f => f.files_parent_id == parent_id && f.files_parent_type == parent_type && f.files_status == "N");

            var master_Record = context.cargo_masterm
                .Where(m => m.mbl_id == parent_id && m.mbl_mode == parent_type)
                .FirstOrDefault();

            if (master_Record != null)
            {
                master_Record.rec_files_count = FilesCount;
                master_Record.rec_files_attached = "Y";
                await context.SaveChangesAsync();
            }
        }

        public static async Task UpdateCustomerDocCount(AppDbContext _context, int? parent_id, string? parent_type)
        {
            context = _context;
            int FilesCount = 0;
            FilesCount = context.mast_fileupload
                .Count(f => f.files_parent_id == parent_id && f.files_parent_type == parent_type && f.files_status == "N");

            var master_Record = context.mast_customerm
                .FirstOrDefault(m => m.cust_id == parent_id && m.cust_row_type == parent_type);


            if (master_Record != null)
            {
                master_Record.rec_files_count = FilesCount;
                master_Record.rec_files_attached = "Y";
                await context.SaveChangesAsync();
            }
        }
        public static async Task UpdateQtnmDocCount(AppDbContext _context, int? parent_id, string? parent_type)
        {
            context = _context;
            int FilesCount = 0;
            FilesCount = context.mast_fileupload
                .Count(f => f.files_parent_id == parent_id && f.files_parent_type == parent_type && f.files_status == "N");

            var master_Record = context.mark_qtnm
                .Where(m => m.qtnm_id == parent_id && m.qtnm_type == parent_type)
                .FirstOrDefault();

            if (master_Record != null)
            {
                master_Record.rec_files_count = FilesCount;
                master_Record.rec_files_attached = "Y";
                await context.SaveChangesAsync();
            }
        }

    }

}