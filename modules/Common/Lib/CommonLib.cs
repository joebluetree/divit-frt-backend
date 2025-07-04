using Common.DTO;
using Database.Lib;
using Database.Models;
using Database.Lib.Interfaces;
using Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using Common.DTO.UserAdmin;
using Common.DTO.Common;
using Database.Models.UserAdmin;
using Common.DTO.Marketing;
using System.Data;
using System.Reflection;
using Microsoft.AspNetCore.StaticFiles;
using DataBase.Pdf;
using Common.UserAdmin.DTO;
using Masters.Interfaces;

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
            if (parent_type == "QUOTATION-LCL" || parent_type == "QUOTATION-FCL" || parent_type == "QUOTATION-AIR")
            {
                await UpdateQtnmDocCount(context, parent_id, parent_type);
            }
            if (IsMemoType(parent_type!))
            {
                await UpdateMemoDocCount(context, parent_id, parent_type);
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
        public static async Task UpdateMemoDocCount(AppDbContext _context, int? parent_id, string? parent_type)
        {
            context = _context;
            int FilesCount = 0;
            FilesCount = context.mast_fileupload
                .Count(f => f.files_parent_id == parent_id && f.files_parent_type == parent_type && f.files_status == "N");

            var master_Record = context.cargo_memo
                .FirstOrDefault(m => m.memo_id == parent_id && m.memo_parent_type == parent_type);


            if (master_Record != null)
            {
                // master_Record.rec_files_count = FilesCount;
                master_Record.rec_files_attached = "Y";
                await context.SaveChangesAsync();
            }
        }
        public static async Task SaveMemoSummary(AppDbContext context, int? parent_id, string? parent_type)
        {
            int memoCount = context.cargo_memo
                .Count(f => f.memo_parent_id == parent_id && f.memo_parent_type == parent_type);


            string? Memo_type = GetMemoType(parent_type);

            // Determine where to save the memo count and mapped type
            if (parent_type == "SEAIMP-CNTR-MEMO" || parent_type == "AIRIMP-CNTR-MEMO" || parent_type == "SEAEXP-CNTR-MEMO" || parent_type == "AIREXP-CNTR-MEMO" || parent_type == "OTH-CNTR-MEMO")
            {

                var masterRecord = context.cargo_masterm
                    .FirstOrDefault(m => m.mbl_id == parent_id && m.mbl_mode == Memo_type);

                if (masterRecord != null)
                {
                    masterRecord.rec_memo_count = memoCount;
                    masterRecord.rec_memo_attached = (memoCount > 0) ? "Y" : "N";
                    await context.SaveChangesAsync();
                }
            }
            if (parent_type == "SEAIMP-SHIP-MEMO" || parent_type == "AIRIMP-SHIP-MEMO")
            {
                var houseRecord = context.cargo_housem
                    .FirstOrDefault(h => h.hbl_id == parent_id && h.hbl_mode == Memo_type);

                if (houseRecord != null)
                {
                    houseRecord.rec_memo_count = memoCount;
                    houseRecord.rec_memo_attached = (memoCount > 0) ? "Y" : "N";
                    await context.SaveChangesAsync();
                }
            }
        }
        private static string? GetMemoType(string? parent_type)
        {
            string? result = null;

            if (parent_type == "SEAIMP-CNTR-MEMO" || parent_type == "SEAIMP-SHIP-MEMO")
                result = "SEA IMPORT";
            if (parent_type == "AIRIMP-CNTR-MEMO" || parent_type == "AIRIMP-SHIP-MEMO")
                result = "AIR IMPORT";
            if (parent_type == "SEAEXP-CNTR-MEMO")
                result = "SEA EXPORT";
            if (parent_type == "AIREXP-CNTR-MEMO")
                result = "AIR EXPORT";
            if (parent_type == "OTH-CNTR-MEMO")
                result = "OTHERS";

            return result;
        }
        private static bool IsMemoType(string parentType)
        {
            var memoTypes = new List<string>
            {
                "OTH-CNTR-MEMO",
                "SEAIMP-CNTR-MEMO",
                "SEAIMP-SHIP-MEMO",
                "AIREXP-CNTR-MEMO",
                "SEAEXP-CNTR-MEMO",
                "AIRIMP-CNTR-MEMO",
                "AIRIMP-SHIP-MEMO",
            };

            return memoTypes.Contains(parentType);
        }
        public static async Task<List<gen_remarkm_dto>> GetRemarksDetailsAsync(AppDbContext _context, int? parent_id, string? parent_type)
        {
            context = _context;
            var query = from e in context.gen_remarkm
                        .Where(e => e.remk_parent_id == parent_id && e.remk_parent_type == parent_type)
                        .OrderBy(o => o.remk_order)
                        select (new gen_remarkm_dto
                        {
                            remk_id = e.remk_id,
                            remk_parent_id = e.remk_parent_id,
                            remk_parent_type = e.remk_parent_type,
                            remk_desc = e.remk_desc,
                            remk_order = e.remk_order,

                            rec_company_id = e.rec_company_id,
                            rec_branch_id = e.rec_branch_id,
                            rec_created_by = e.rec_created_by,
                            rec_created_date = Database.Lib.Lib.FormatDate(e.rec_created_date, Database.Lib.Lib.outputDateTimeFormat),
                            rec_edited_by = e.rec_edited_by,
                            rec_edited_date = Database.Lib.Lib.FormatDate(e.rec_edited_date, Database.Lib.Lib.outputDateTimeFormat),
                        });
            var records = await query.ToListAsync();
            return records;
        }

        public static async Task<mark_qtnm_dto> SaveMarketingRemarksAsync(AppDbContext _context, int? id, string? parent_type, string mode, mark_qtnm_dto record_dto)
        {
            context = _context;
            gen_remarkm? record;
            List<gen_remarkm_dto> records_dto;
            List<gen_remarkm> records;
            try
            {
                records_dto = record_dto.remk_remarks!;
                records = await context.gen_remarkm
                    .Where(w => w.remk_parent_id == id && w.remk_parent_type == parent_type)
                    .ToListAsync();
                int nextorder = 1;

                // if (mode == "edit")
                //     await logHistoryDetail(records, record_dto);


                foreach (var existing_record in records)
                {
                    var rec = records_dto.Find(f => f.remk_id == existing_record.remk_id);
                    if (rec == null)
                        context.gen_remarkm.Remove(existing_record);
                }

                //Add or Edit Records 
                foreach (var rec in records_dto)
                {
                    if (rec.remk_id == 0)
                    {
                        record = new gen_remarkm();
                        record.rec_company_id = record_dto.rec_company_id;
                        record.rec_branch_id = record_dto.rec_branch_id;
                        record.rec_created_by = record_dto.rec_created_by;
                        record.rec_created_date = DbLib.GetDateTime();
                        record.remk_parent_id = id;
                        record.remk_parent_type = parent_type;
                    }
                    else
                    {
                        record = records.Find(f => f.remk_id == rec.remk_id);
                        if (record == null)
                            throw new Exception("Detail Record Not Found " + rec.remk_id.ToString());
                        record.rec_version++;
                        record.rec_edited_by = record_dto.rec_created_by;
                        record.rec_edited_date = DbLib.GetDateTime();
                    }
                    record.remk_desc = rec.remk_desc;
                    record.remk_order = nextorder++;
                    if (rec.remk_id == 0)
                        await context.gen_remarkm.AddAsync(record);
                }
                context.SaveChanges();
                return record_dto;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        public static async Task SaveGenMemoSummary(AppDbContext _context, int? parent_id, string? parent_type)
        {
            context = _context;
            if (parent_type == "CUSTOMER-MEMO" || parent_type == "CUSTOMER-SOP"|| parent_type == "CUSTOMER-QTNM"|| parent_type == "CUSTOMER-ACC")
            {
                await UpdateCustomerMemoCount(context, parent_id, parent_type);
            }
        }
        public static async Task UpdateCustomerMemoCount(AppDbContext _context, int? parent_id, string? parent_type)
        {
            context = _context;

            int custMemoCount = context.gen_remarkm
                .Count(f => f.remk_parent_id == parent_id && f.remk_parent_type == parent_type);

            var customer_Record = context.mast_customerm
                .Where(m => m.cust_id == parent_id)// cust_id always unique and type only customer
                .FirstOrDefault();

            if (customer_Record != null)
            {
                if (parent_type == "CUSTOMER-MEMO")
                {
                    customer_Record.rec_memo_attached = (custMemoCount > 0) ? "Y" : "N";
                }
                if (parent_type == "CUSTOMER-SOP")
                {
                    customer_Record.rec_sop_attached = (custMemoCount > 0) ? "Y" : "N";
                }
                if (parent_type == "CUSTOMER-QTNM")
                {
                    customer_Record.rec_qtnm_attached = (custMemoCount > 0) ? "Y" : "N";
                }
                if (parent_type == "CUSTOMER-ACC")
                {
                    customer_Record.rec_acc_attached = (custMemoCount > 0) ? "Y" : "N";
                }

                await context.SaveChangesAsync();
            }
        }


        public static async Task<FileDownloadResult_Dto> GetFileAsync(string filePath)
        {
            if (Database.Lib.Lib.IsBlank(filePath) || !System.IO.File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            var record = new FileDownloadResult_Dto
            {
                FileStream = memory,
                ContentType = GetContentType(filePath),
                FileName = Path.GetFileName(filePath),
                FileType = Path.GetExtension(filePath)?.TrimStart('.'), // e.g., "pdf", "jpg"
            };
            return record;
        }

        public static string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        public static string GetSubFolderFromDate()
        {
            DateTime? parsedDate = DbLib.GetDateTime();
            if (parsedDate == null)
                throw new Exception("Creation date is required");

            string subFolder = parsedDate.Value.ToString("yyyy-MMM").ToLower();
            return subFolder;
        }

        public static address_details_dto GetCompanyAddress(AppDbContext dbContext, int companyId)
        {
            context = dbContext;

            var record = context.mast_companym
                .Where(w => w.comp_id == companyId)
                .Select(e => new address_details_dto
                {
                    Name = e.comp_name,
                    Address1 = e.comp_address1,
                    Address2 = e.comp_address2,
                    Address3 = e.comp_address3,
                })
                .FirstOrDefault();

            return record!;

        }

        public static address_details_dto GetBranchAddress(AppDbContext dbContext, int companyId, int branchId)
        {
            context = dbContext;

            var record = context.mast_branchm
                .Where(w => w.branch_id == branchId && w.rec_company_id == companyId)
                .Select(e => new address_details_dto
                {
                    Name = e.branch_name,
                    Address1 = e.branch_address1,
                    Address2 = e.branch_address2,
                    Address3 = e.branch_address3,
                })
                .FirstOrDefault();
            return record!;
        }

        public static float WriteBranchAddressPdf(float startY, float colX, int Company_id, int Branch_id, AppDbContext _context, iPdfBase pdf)
        {
            context = _context;

            int lineHeight = 15;
            int rowWidth = 500;
            float currentY = startY;

            var Address = GetBranchAddress(_context, Company_id, Branch_id); //

            if (Address == null)
                throw new Exception($"Address not found !");

            pdf.AddText(currentY, colX, rowWidth, lineHeight, Address!.Name ?? "", new TextFormat { Style = "B", FontSize = 15 });
            currentY += lineHeight;

            if (!Database.Lib.Lib.IsBlank(Address!.Address1))
            {
                pdf.AddText(currentY, colX, rowWidth, lineHeight, Address.Address1!, new TextFormat { FontSize = 10 });
                currentY += lineHeight;
            }
            if (!Database.Lib.Lib.IsBlank(Address!.Address2))
            {
                pdf.AddText(currentY, colX, rowWidth, lineHeight, Address.Address2!, new TextFormat { FontSize = 10 });
                currentY += lineHeight;
            }
            if (!Database.Lib.Lib.IsBlank(Address!.Address3))
            {
                pdf.AddText(currentY, colX, rowWidth, lineHeight, Address.Address3!, new TextFormat { FontSize = 10 });
                currentY += 5;
            }

            return currentY;
        }

        public static int WriteBranchAddressExcel(int rowIndex, int colIndex, int col_count, int Company_id, int Branch_id, AppDbContext _context, IExcelBase excel)
        {
            context = _context;

            var Address = GetBranchAddress(_context, Company_id, Branch_id);

            if (Address == null)
                throw new Exception($"Address not found !");

            excel.CellValue(rowIndex, colIndex, Address.Name!, new CellFormat { Style = "B", FontSize = 15, ColumnWidth = 80, Merge = col_count });
            rowIndex += 1;

            if (!Database.Lib.Lib.IsBlank(Address!.Address1))
            {
                excel.CellValue(rowIndex, colIndex, Address.Address1!, new CellFormat { FontSize = 10, ColumnWidth = 80, Merge = col_count });
                rowIndex += 1;
            }
            if (!Database.Lib.Lib.IsBlank(Address!.Address2))
            {
                excel.CellValue(rowIndex, colIndex, Address.Address2!, new CellFormat { FontSize = 10, ColumnWidth = 80, Merge = col_count });
                rowIndex += 1;
            }
            if (!Database.Lib.Lib.IsBlank(Address!.Address3))
            {
                excel.CellValue(rowIndex, colIndex, Address.Address3!, new CellFormat { FontSize = 10, ColumnWidth = 80, Merge = col_count });
            }

            return rowIndex;
        }

        public static bool IsPageBreak(float Row, int Line_Height, int Page_Height)
        {
            bool rec = false;
            if ((Row + Line_Height) >= Page_Height)
                rec = true;
            return rec;
        }

        public static string IsLastRow(int currentIndex, int recordCount)
        {
            string bottomLine = "";
            if (currentIndex == recordCount)
                bottomLine = "B";
            return bottomLine;
        }

    }

}