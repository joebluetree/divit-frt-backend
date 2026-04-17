using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.CommonShipment;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Masters.Interfaces;
using NPOI.HSSF.Record;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;
using SixLabors.ImageSharp.Processing;

namespace CommonShipment.Printing
{
    public class ProfitReportExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<cargo_profit_dto> Dt_List { get; set; } = new List<cargo_profit_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string Name { get; set; } = "";
        public string InvMblNo { get; set; } = "";
        public string InvRefno { get; set; } = "";
        public string POL { get; set; } = "";
        public string POD { get; set; } = "";
        public decimal WT { get; set; } = 0;
        public decimal CHWT { get; set; } = 0;
        public decimal CBM { get; set; } = 0;
        public string ReportType { get; set; } = "";
        public string UnitType { get; set; } = "";
        public string User_name = "";
        public bool NextPage { get; set; } = false;

        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private bool IsAttachment = false;
        private int MaxCount = 14;
        private int col_count = 8;

        public ProfitReportExcelFile()
        {
            excel = new TextExcel();
        }

        public void Process()
        {
            try
            {
                fList = new List<filesm>();
                folderid = Guid.NewGuid().ToString().ToUpper();

                File_Display_Name = Name.ToString()!.ToUpper();
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
        private bool IsPageBreak(int count)
        {
            bool rec = false;
            if (count == MaxCount)
                rec = true;
            return rec;
        }

        private void CreateExcelData()
        {
            int rowIndex = 0;
            int colIndex = 0;
            string BL = "";
            bool isLastTwo = false;

            var recordCount = Dt_List.Count;
            int i = 0;
            int count = 0;
            rowIndex = WriteHeader(rowIndex, colIndex);

            foreach (cargo_profit_dto dr in Dt_List)
            {
                i++;
                BL = CommonLib.IsLastRow(i, recordCount);
                BL = count == MaxCount - 1 ? "B" : BL;
                isLastTwo = (i == recordCount-1 || i == recordCount); // last 2 line is always Summary( Total/ Profit)
                var ST = isLastTwo ? "B" : "";

                if (IsPageBreak(count))
                {
                    NextPage = true;
                    rowIndex = WriteFooter(rowIndex, colIndex, count);
                    rowIndex += 1;
                    excel.SetRowBreak(rowIndex);
                    rowIndex += 1;
                    rowIndex = WriteHeader(rowIndex, colIndex);
                    count = 0;
                }
                NextPage = false;
                var inv_date = Lib.FormatDate(Lib.ParseDate(dr.inv_date!), Lib.DisplayDateFormat) ?? "";
                excel.CellValue(rowIndex, colIndex + 0, inv_date.ToUpper(), new CellFormat { Border = "T" + BL, Style = "" + ST, FontSize = 9, VAlign = "T" });
                if(ReportType == "INVOICE WISE")
                    excel.CellValue(rowIndex, colIndex + 1, dr.inv_no!, new CellFormat { Border = "T" + BL, Style = "" + ST, FontSize = 9, VAlign = "T" });
                if(ReportType == "HOUSE WISE")
                    excel.CellValue(rowIndex, colIndex + 1, dr.inv_mbl_refno!, new CellFormat { Border = "T" + BL, Style = "" + ST, FontSize = 9, VAlign = "T" });
                excel.CellValue(rowIndex, colIndex + 2, dr.inv_houseno!, new CellFormat { Border = "T" + BL, Style = "" + ST, FontSize = 9, VAlign = "T" });
                excel.CellValue(rowIndex, colIndex + 3, dr.inv_wt!, new CellFormat { Border = "T" + BL, Style = "" + ST, FontSize = 9, VAlign = "T" });
                excel.CellValue(rowIndex, colIndex + 4, dr.inv_cbm!, new CellFormat { Border = "T" + BL, Style = "" + ST, FontSize = 9, VAlign = "T" });
                excel.CellValue(rowIndex, colIndex + 5, dr.inv_cust_name!, new CellFormat { Border = "T" + BL, Style = "" + ST, FontSize = 9, WrapText = true, VAlign = "T" });
                excel.CellValue(rowIndex, colIndex + 6, dr.inv_inc_total!, new CellFormat { Border = "T" + BL, Style = "" + ST, FontSize = 9, HAlign = "R", VAlign = "T" });
                excel.CellValue(rowIndex, colIndex + 7, dr.inv_exp_total!, new CellFormat { Border = "T" + BL, Style = "" + ST, FontSize = 9, HAlign = "R", VAlign = "T" });
                excel.CellValue(rowIndex++, colIndex + 8, dr.inv_profit!, new CellFormat { Border = "T" + BL, Style = "" + ST, FontSize = 9, HAlign = "R", VAlign = "T" });
                count++;

            }
            rowIndex = WriteFooter(rowIndex, colIndex, count);
            rowIndex += 1;
            excel.SetRowBreak(rowIndex);

            excel.SetColumnBreak(colIndex + 7);// mac possible column
            excel.Save(File_Name);
        }

        private int WriteHeader(int rowIndex, int colIndex)
        {
            
            if (rowIndex == 0)
            {
                excel.CreateSheet("Sheet1");
            }

            excel.PrintGridlines(false);

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex, Title.ToUpper(), new CellFormat { Border = "TB", Style = "B", HAlign = "C", FontSize = 11, ColumnWidth = 12, MergeCols = col_count });
            rowIndex += 1;

            var leftRow = rowIndex;
            if (!IsAttachment)
            {
                excel.CellValue(leftRow, colIndex + 0, "REF #", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 1, $":{InvRefno}", new CellFormat {Style="B", FontSize = 10 });
                leftRow += 1;

                excel.CellValue(leftRow, colIndex + 0, "MASTER", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 1, $":{InvMblNo}", new CellFormat { Style="B", FontSize = 10 });
                leftRow += 1;

                excel.CellValue(leftRow, colIndex + 0, "POL", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 1, $":{POL}", new CellFormat { Style="B", FontSize = 10 });
                leftRow += 1;

                excel.CellValue(leftRow, colIndex + 0, "POD", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 1, $":{POD}", new CellFormat { Style="B", FontSize = 10 });

                var rightRow = rowIndex;

                excel.CellValue(rightRow, colIndex + 4, "TYPE", new CellFormat { Style="B", FontSize = 10 });
                if(ReportType == "INVOICE WISE")
                    excel.CellValue(rightRow, colIndex + 5, $":{ReportType}", new CellFormat { Style="B", FontSize = 10 });
                if(ReportType == "HOUSE WISE")
                    excel.CellValue(rightRow, colIndex + 5, $":{ReportType} ({UnitType})", new CellFormat { Style="B", FontSize = 10 });
                rightRow += 1;

                excel.CellValue(rightRow, colIndex + 4, "WT", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(rightRow, colIndex + 5, $":{WT}", new CellFormat { Style="B", FontSize = 10 });
                rightRow += 1;

                excel.CellValue(rightRow, colIndex + 4, "CH.WT", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(rightRow, colIndex + 5, $":{CHWT}", new CellFormat { Style="B", FontSize = 10 });
                rightRow += 1;

                excel.CellValue(rightRow, colIndex + 4, "CBM", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(rightRow, colIndex + 5, $":{CBM}", new CellFormat { Style="B", FontSize = 10 });

                rowIndex = leftRow;
                rowIndex += 1;
                excel.CellValue(rowIndex, colIndex, "", new CellFormat { Border = "TB", FontSize = 10, MergeCols = col_count });

                rowIndex += 1;
                excel.CellValue(rowIndex, colIndex + 0, "DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 12 });
                if(ReportType == "INVOICE WISE")
                    excel.CellValue(rowIndex, colIndex + 1, "INVOICE NO", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                if(ReportType == "HOUSE WISE")
                    excel.CellValue(rowIndex, colIndex + 1, "REF NO", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 2, "HOUSE NO", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 3, "WEIGHT", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 4, "CBM", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 5, "CUSTOMER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 40 });
                excel.CellValue(rowIndex, colIndex + 6, "REVENUE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15, HAlign = "R" });
                excel.CellValue(rowIndex, colIndex + 7, "EXPENSE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15, HAlign = "R" });
                excel.CellValue(rowIndex, colIndex + 8, "PROFIT", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15, HAlign = "R" });
                rowIndex += 1;
            }
            return rowIndex;
        }
        private int WriteFooter(int rowIndex, int colIndex, int detailCount)
        {
            int startRow = rowIndex;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            int rowsToFill = MaxCount - detailCount;
            rowIndex += rowsToFill;

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name}";

            excel.CellValue(rowIndex, colIndex, printInfo, new CellFormat { Border = "T", FontSize = 9, MergeCols = col_count });
            rowIndex += 1;

            return rowIndex;
        }
    }
}