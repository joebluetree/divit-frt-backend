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
        public string DateType { get; set; } = "";
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
                excel.CellValue(rowIndex, colIndex, dr.cust_code!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 1, dr.cust_name!, new CellFormat { Border = "LTB", FontSize = 9, MergeCols = 1 });
                excel.CellValue(rowIndex, colIndex + 2, "", new CellFormat { Border = "TB", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 3, dr.cust_parent_name!, new CellFormat { Border = "LTB", FontSize = 9, MergeCols = 1 });
                excel.CellValue(rowIndex, colIndex + 4, "", new CellFormat { Border = "TB", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 5, dr.cust_address1!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 6, dr.cust_address2!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 7, dr.cust_address3!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 8, dr.rec_created_by!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 9, dr.cust_type!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 10, dr.cust_is_shipper!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 11, dr.cust_is_consignee!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 12, dr.cust_is_importer!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 13, dr.cust_is_exporter!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 14, dr.cust_is_cha!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 15, dr.cust_is_forwarder!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 16, dr.cust_is_oagent!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 17, dr.cust_is_acarrier!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 18, dr.cust_is_scarrier!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 19, dr.cust_is_trucker!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 20, dr.cust_is_warehouse!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 21, dr.cust_is_sterminal!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 22, dr.cust_is_aterminal!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 23, dr.cust_is_shipvendor!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 24, dr.cust_is_gvendor!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 25, dr.cust_is_employee!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 26, dr.cust_is_contract!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 27, dr.cust_is_miscell!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 28, dr.cust_is_tbd!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 29, dr.cust_is_bank!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 30, dr.cust_nomination!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex++, colIndex + 31, dr.cust_contact!, new CellFormat { Border = "A", FontSize = 9 });

            }
            excel.Save(File_Name);
        }

        private int WriteHeader()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int col_count = 32;
            excel.CreateSheet("Sheet1");

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? ""; // convert string date into dd-mmm-yyyy fromat
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title.ToUpper() + " LIST", new CellFormat { Border = "TB", Style = "B", FontSize = 10, MergeCols = 1 });
            for (int i = colIndex + 1; i < colIndex + col_count; i++)
            {
                excel.CellValue(rowIndex, i, "", new CellFormat { Border = "TB", FontSize = 10 });
            }
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "DATE TYPE", new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, DateType.ToUpper(), new CellFormat { FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FROM DATE", new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SFromDate.ToUpper(), new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "CREATED-BY", new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, CreatedBy, new CellFormat { FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "TO DATE", new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SToDate.ToUpper(), new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "EDITED-BY", new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, EditedBy, new CellFormat { FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "CODE", new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, CustCode, new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "FIRM-CODE", new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, FirmCode, new CellFormat { FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "NAME", new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, Name, new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "IS-BLACK-ACCOUNT", new CellFormat { FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, IsBlackAcc, new CellFormat { FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "PRINTED : " + Date + " / " + User_name, new CellFormat { FontSize = 10, MergeCols = 1 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "CODE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25 });
            excel.CellValue(rowIndex, colIndex + 1, "NAME", new CellFormat { Border = "LT", Style = "B", FontSize = 10, ColumnWidth = 25, MergeCols = 1 });
            excel.CellValue(rowIndex, colIndex + 2, "", new CellFormat { Border = "T", Style = "B", FontSize = 10, ColumnWidth = 25 });
            excel.CellValue(rowIndex, colIndex + 3, "PARENT", new CellFormat { Border = "LT", Style = "B", FontSize = 10, ColumnWidth = 25, MergeCols = 1 });
            excel.CellValue(rowIndex, colIndex + 4, "", new CellFormat { Border = "T", FontSize = 10, ColumnWidth = 25 });
            excel.CellValue(rowIndex, colIndex + 5, "ADDRESS 1", new CellFormat { Border = "LT", Style = "B", FontSize = 10, ColumnWidth = 40 });
            excel.CellValue(rowIndex, colIndex + 6, "ADDRESS 2", new CellFormat { Border = "LT", Style = "B", FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 7, "ADDRESS 3", new CellFormat { Border = "LT", Style = "B", FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 8, "CREATED-BY", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 9, "TYPE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 8 });
            excel.CellValue(rowIndex, colIndex + 10, "SHIPPER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 11, "CONSIGNEE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 12, "IMPORTER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 13, "EXPORTER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 14, "CHA", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 15, "FORWARDER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 16, "O-AGENT", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 17, "A-CARRIER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 18, "S-CARRIER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 19, "TRUCKER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 20, "WAREHOUSE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 21, "S-TERMINAL", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 22, "A-TERMINAL", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 23, "SHIP-VENDOR", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 14 });
            excel.CellValue(rowIndex, colIndex + 24, "G-VENDOR", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 25, "EMPLOYEE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 26, "CONTRACT", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 27, "MISCELL", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 28, "TBD", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 29, "BANK", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 30, "CLIENT-TYPE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 31, "CONTACT", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            rowIndex += 1;
            return rowIndex;
        }

    }
}