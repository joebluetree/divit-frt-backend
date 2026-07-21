using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.Marketing;
using Common.DTO.Masters;
using Common.DTO.OtherOp;
using Common.DTO.Report;
using Common.DTO.SeaExport;
using Common.DTO.SeaImport;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Masters.Interfaces;
using NPOI.SS.Formula.Functions;

namespace Report.Printing
{
    public class ApprovalReportExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<rep_approvedd_dto> Dt_List { get; set; } = new List<rep_approvedd_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string DateType { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string RequestBy { get; set; } = "";
        public string ReportType { get; set; } = "";
        public string Type { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string Reference { get; set; } = "";
        public string User_name { get; set; } = "";
        public bool IsImport { get; set; } = false;


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private int col_count = 0; // Column Total count
        private int PageNumber = 0;

        public ApprovalReportExcelFile()
        {
            excel = new TextExcel();
        }

        public void Process()
        {
            try
            {
                fList = new List<filesm>();
                folderid = Guid.NewGuid().ToString().ToUpper();

                File_Display_Name = Title.ToString()!.ToLower();
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
            int count = 0;
            rowIndex = WriteHeader(rowIndex, colIndex);

            foreach (rep_approvedd_dto dr in Dt_List)
            {
                count++;

                var BL = CommonLib.IsLastRow(count, Dt_List.Count());

                var ca_date = Lib.FormatDate(Lib.ParseDate(dr.ca_date!), Lib.DisplayDateFormat) ?? "";
                var cad_approved_date = Lib.FormatDate(Lib.ParseDate(dr.cad_approved_date!), Lib.DisplayDateFormat) ?? "";
                var ca_etd = Lib.FormatDate(Lib.ParseDate(dr.ca_payment_recvd_date!), Lib.DisplayDateFormat) ?? "";

                excel.CellValue(rowIndex, colIndex + 0, dr.ca_req_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 1, dr.ca_type!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T", WrapText = true });
                excel.CellValue(rowIndex, colIndex + 2, dr.ca_ref_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 3, dr.ca_hbl_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T", WrapText = true });
                excel.CellValue(rowIndex, colIndex + 4, dr.ca_consignee_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 5, dr.ca_inv_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 6, dr.ca_inv_cust!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 7, dr.ca_inv_amt!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T", HAlign="R" });
                excel.CellValue(rowIndex, colIndex + 8, dr.cad_approvedby_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T", WrapText = true });
                excel.CellValue(rowIndex, colIndex + 9, cad_approved_date.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 10, dr.cad_is_approved!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 11, dr.ca_remarks!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T", WrapText = true });

                rowIndex ++;
                
            }

            excel.SetColumnBreak(colIndex + 4);
            excel.Save(File_Name);
        }

        private int WriteHeader(int rowIndex, int colIndex)
        {
            if (rowIndex == 0)
            {
                excel.CreateSheet("Sheet1");
                excel.PrintGridlines(true);// for grid lines On/Off
            }

            PageNumber++;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;

            col_count = 11;
            var UserRole = ReportType == "APPROVAL REQ REPORT"? "REQUEST.BY" : "APPROVED.BY";

            excel.CellValue(rowIndex, colIndex, Title.ToUpper()!, new CellFormat { Border = "TB", Style = "B", ColumnWidth = 15, FontSize = 10, MergeCols = col_count });
            rowIndex += 1;

            // excel.CellValue(rowIndex, colIndex, "DATE TYPE", new CellFormat { Style = "B", FontSize = 10 });
            // excel.CellValue(rowIndex, colIndex + 1, DateType, new CellFormat { Style = "B", FontSize = 10 });
            // excel.CellValue(rowIndex, colIndex + 3, "TYPE", new CellFormat { Style = "B", FontSize = 10 });
            // excel.CellValue(rowIndex, colIndex + 4, InvType, new CellFormat { Style = "B", FontSize = 10 });
            // rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FROM DATE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SFromDate, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "TYPE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, Type, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "TO DATE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SToDate, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "REFERENCE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, Reference, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "GROUP", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, OpGroup, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, UserRole, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, RequestBy, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex + 0, "REQ #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 1, "TYPE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
            excel.CellValue(rowIndex, colIndex + 2, "REF.NO", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 3, "HOUSE.NO", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 4, "CONSIGNEE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
            excel.CellValue(rowIndex, colIndex + 5, "INV.NO", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 6, "CUSTOMER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
            excel.CellValue(rowIndex, colIndex + 7, "AMOUNT", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15, HAlign="R" });
            excel.CellValue(rowIndex, colIndex + 8, "APPROVED.BY", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 9, "APPROVED DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 10, "STATUS", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 25,});
            excel.CellValue(rowIndex, colIndex + 11, "REMARKS", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });

            rowIndex += 1;
            return rowIndex;
        }
    }
}