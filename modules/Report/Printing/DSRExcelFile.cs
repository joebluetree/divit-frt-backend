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
    public class DSRExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<rep_dsr_dto> Dt_List { get; set; } = new List<rep_dsr_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string DateType { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string HblFormat { get; set; } = "";
        public string ParentName { get; set; } = "";
        public string ShipperName { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string ConsigneeName { get; set; } = "";
        public string User_name { get; set; } = "";
        public bool IsImport { get; set; } = false;


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private int col_count = 0; // Column Total count
        private int PageNumber = 0;

        public DSRExcelFile()
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

            foreach (rep_dsr_dto dr in Dt_List)
            {
                count++;

                var BL = CommonLib.IsLastRow(count, Dt_List.Count());

                var hbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.hbl_ref_date!), Lib.DisplayDateFormat) ?? "";
                var hbl_eta = Lib.FormatDate(Lib.ParseDate(dr.hbl_pod_eta!), Lib.DisplayDateFormat) ?? "";
                var hbl_etd = Lib.FormatDate(Lib.ParseDate(dr.hbl_pol_etd!), Lib.DisplayDateFormat) ?? "";

                excel.CellValue(rowIndex, colIndex + 0, dr.hbl_mbl_refno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 1, hbl_ref_date.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 2, dr.hbl_liner_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 3, dr.hbl_mbl_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 4, dr.hbl_cntr_list!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 5, dr.hbl_pol_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 6, dr.hbl_pod_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 7, hbl_etd.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 8, hbl_eta.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 9, dr.hbl_houseno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 10, dr.hbl_shipper_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 11, dr.hbl_consignee_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 12, dr.hbl_inv_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 13, dr.hbl_inv_date!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                excel.CellValue(rowIndex, colIndex + 14, dr.hbl_inv_amt!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, HAlign="R", VAlign="T" });
                if(IsImport)
                {
                    excel.CellValue(rowIndex, colIndex + 15, dr.hbl_book_slno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                    excel.CellValue(rowIndex, colIndex + 16, dr.hbl_pono!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                    excel.CellValue(rowIndex, colIndex + 17, dr.hbl_invoiceno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                    excel.CellValue(rowIndex, colIndex + 18, dr.hbl_incoterm!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, VAlign="T" });
                }
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

            IsImport = OpGroup == "SEA IMPORT" || OpGroup == "AIR IMPORT";

            col_count = IsImport ? 18 : 14;
            
            excel.CellValue(rowIndex, colIndex, Title.ToUpper()!, new CellFormat { Border = "TB", Style = "B", ColumnWidth = 15, FontSize = 10, MergeCols = col_count });
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex, "DATE TYPE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, DateType, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "PARENT", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, ParentName, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FROM DATE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SFromDate, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "SHIPPER", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, ShipperName, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "TO DATE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SToDate, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "CONSIGNEE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, ConsigneeName, new CellFormat { Style = "B", FontSize = 10 });

            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex + 0, "REF#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 1, "REF DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 2, "CARRIER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 3, "BL#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 4, "CONTAINER#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 5, "POL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 6, "POD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 7, "ETD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 8, "ETA", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 9, "HOUSE#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 10, "SHIPPER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
            excel.CellValue(rowIndex, colIndex + 11, "CONSIGNEE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
            excel.CellValue(rowIndex, colIndex + 12, "AR.INV#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 13, "AR.INV.DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 14, "AR.INV.AMT", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign="R", ColumnWidth = 15 });
            if(IsImport)
            {
                excel.CellValue(rowIndex, colIndex + 15, "BOOKING#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 16, "PO#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 17, "INVOICE#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 18, "INCOTERM", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            }
            rowIndex += 1;
            return rowIndex;
        }
    }
}