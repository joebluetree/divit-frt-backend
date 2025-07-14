using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.Masters;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Masters.Interfaces;

namespace Masters.Printing
{
    public class ProcessCustomerExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<mast_customerm_dto> Dt_List { get; set; } = new List<mast_customerm_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string Name { get; set; } = "";
        public string User_name { get; set; } = "";
        public string Cust_type { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public string EditedBy { get; set; } = "";
        public string CustCode { get; set; } = "";
        public string FirmCode { get; set; } = "";
        public string IsBlackAcc { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";

        public ProcessCustomerExcelFile()
        {
            excel = new TextExcel();
        }

        public void Process()
        {
            try
            {
                fList = new List<filesm>();
                folderid = Guid.NewGuid().ToString().ToUpper();

                File_Display_Name = Cust_type.ToString()!.ToLower();
                File_Display_Name += ".xlsx";
                File_Display_Name = Lib.ProperFileName(File_Display_Name);
                File_Name = Lib.GetFileName(report_folder, folderid, File_Display_Name, false);
                File_Type = "EXCEL";

                CreateExcelData();

                fList.Add(Lib.AddFiles(File_Name, File_Type, File_Display_Name));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void CreateExcelData()
        {
            int rowIndex = 0;
            int colIndex = 0;

            rowIndex = WriteHeader();

            foreach (mast_customerm_dto dr in Dt_List)
            {
                excel.CellValue(rowIndex, colIndex, dr.cust_code!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 25 });
                excel.CellValue(rowIndex, colIndex + 1, dr.cust_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 50 });
                excel.CellValue(rowIndex, colIndex + 2, dr.cust_parent_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 50 });
                excel.CellValue(rowIndex, colIndex + 3, dr.cust_address1!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 40 });
                excel.CellValue(rowIndex, colIndex + 4, dr.cust_address2!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 50 });
                excel.CellValue(rowIndex, colIndex + 5, dr.cust_address3!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 60 });
                excel.CellValue(rowIndex, colIndex + 6, dr.rec_created_by!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 7, dr.cust_type!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 8 });
                excel.CellValue(rowIndex, colIndex + 8, dr.cust_is_shipper!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 9, dr.cust_is_consignee!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 10, dr.cust_is_importer!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 11, dr.cust_is_exporter!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 12, dr.cust_is_cha!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 13, dr.cust_is_forwarder!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 12 });
                excel.CellValue(rowIndex, colIndex + 14, dr.cust_is_oagent!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 15, dr.cust_is_acarrier!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 16, dr.cust_is_scarrier!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 17, dr.cust_is_trucker!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 18, dr.cust_is_warehouse!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 12 });
                excel.CellValue(rowIndex, colIndex + 19, dr.cust_is_sterminal!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 12 });
                excel.CellValue(rowIndex, colIndex + 20, dr.cust_is_aterminal!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 12 });
                excel.CellValue(rowIndex, colIndex + 21, dr.cust_is_shipvendor!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 14 });
                excel.CellValue(rowIndex, colIndex + 22, dr.cust_is_gvendor!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 23, dr.cust_is_employee!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 24, dr.cust_is_contract!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 25, dr.cust_is_miscell!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 26, dr.cust_is_tbd!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 27, dr.cust_is_bank!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 28, dr.cust_nomination!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 15 });
                excel.CellValue(rowIndex++, colIndex + 29, dr.cust_contact!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 15});

            }
            excel.Save(File_Name);
        }

        private int WriteHeader()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int col_count = 1;
            excel.CreateSheet("Sheet1");

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title, new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 100, Merge = col_count });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FROM DATE: " + FromDate, new CellFormat { FontSize = 10, ColumnWidth = 50 });//, Merge = 0
            // rowIndex += 1;
            excel.CellValue(rowIndex, colIndex + 1, "TO DATE: " + ToDate, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex,   "CODE: " + CustCode, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            // rowIndex += 1;
            excel.CellValue(rowIndex, colIndex + 1,"NAME: " + Name, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "CREATED-BY: " + CreatedBy, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            // rowIndex += 1;
            excel.CellValue(rowIndex, colIndex + 1, "EDITED-BY: " + EditedBy, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            rowIndex += 1; 
            excel.CellValue(rowIndex, colIndex, "FIRM-CODE: " + FirmCode, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            // rowIndex += 1;
            excel.CellValue(rowIndex, colIndex + 1, "IS-BLACK-ACCOUNT: " + IsBlackAcc, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "PRINTED : " + Date + " / " + User_name, new CellFormat { FontSize = 10, ColumnWidth = 50, Merge = col_count });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "CODE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25 });
            excel.CellValue(rowIndex, colIndex + 1, "NAME", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 2, "PARENT", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 3, "ADDRESS 1", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 40 });
            excel.CellValue(rowIndex, colIndex + 4, "ADDRESS 2", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 5, "ADDRESS 3", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 60 });
            excel.CellValue(rowIndex, colIndex + 6, "CREATED-BY", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 7, "TYPE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 8 });
            excel.CellValue(rowIndex, colIndex + 8, "SHIPPER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 9, "CONSIGNEE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 10, "IMPORTER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 11, "EXPORTER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 12, "CHA", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 13, "FORWARDER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 14, "O-AGENT", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 15, "A-CARRIER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 16, "S-CARRIER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 17, "TRUCKER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 18, "WAREHOUSE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 19, "S-TERMINAL", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 20, "A-TERMINAL", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 21, "SHIP-VENDOR", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 14 });
            excel.CellValue(rowIndex, colIndex + 22, "G-VENDOR", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 23, "EMPLOYEE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 24, "CONTRACT", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 25, "MISCELL", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 26, "TBD", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 27, "BANK", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 28, "CLIENT-TYPE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15});
            excel.CellValue(rowIndex, colIndex + 29, "CONTACT", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15});
            rowIndex += 1;
            return rowIndex;
        }

    }
}