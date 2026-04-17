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
    public class SeaVolumeExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<rep_seavolume_dto> Dt_List { get; set; } = new List<rep_seavolume_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string Format { get; set; } = "";
        public string ReportType { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string ShipType { get; set; } = "";
        public string User_name { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private int col_count = 0; // Column Total count
        private int PageNumber = 0;
        // private int MaxCount = 38;

        public SeaVolumeExcelFile()
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
        // private bool IsPageBreak(int count)
        // {
        //     bool rec = false;
        //     if (count == MaxCount)
        //         rec = true;
        //     return rec;
        // }
        private void CreateExcelData()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int count = 0;
            rowIndex = WriteHeader(rowIndex, colIndex);

            foreach (rep_seavolume_dto dr in Dt_List)
            {
                count ++;
                var LastRow = count == Dt_List.Count();
                bool isTotal = dr.mbl_refno == "TOTAL";
                var BL = LastRow ? "TB" : "";//D
                var ST = LastRow ? "B" : "";// style bold
                var TotalBorder = isTotal ? "TB" : "";
                var TotalStyle = isTotal ? "B" : "";
                
                // if (IsPageBreak(count))
                // {
                //     int Rows = MaxCount - count;
                //     rowIndex = WriteFooter(rowIndex, colIndex, Rows );           //unremark if footer details needed
                //     rowIndex += 1;
                //     rowIndex = WriteHeader(rowIndex, colIndex);
                //     count = 0;
                // }
                if(dr.IsAgentTitle == false)
                {
                    if (ReportType == "SUMMARY" && !LastRow)
                    {
                        if (Format == "AGENT")
                            excel.CellValue(rowIndex, colIndex + 0, dr.mbl_agent_name!, new CellFormat { Border = "", FontSize = 9, WrapText = true });
                        if (Format == "OPERATION GROUP")
                            excel.CellValue(rowIndex, colIndex + 0, dr.mbl_mode!, new CellFormat { Border = "", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 1, dr.mbl_20!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 2, dr.mbl_40!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 3, dr.mbl_40hq!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 4, dr.mbl_45!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 5, dr.mbl_teu!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex++, colIndex + 6, dr.mbl_cbm!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                    }
                    if (ReportType == "DETAIL" && !LastRow)
                    {
                        var mbl_date = Lib.FormatDate(Lib.ParseDate(dr.mbl_ref_date!), Lib.DisplayDateFormat) ?? "";
                        excel.CellValue(rowIndex, colIndex + 0, dr.mbl_refno!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 1, mbl_date.ToUpper(), new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 2, dr.mbl_agent_name!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, WrapText = true });
                        excel.CellValue(rowIndex, colIndex + 3, dr.mbl_liner_name!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, WrapText = true });
                        excel.CellValue(rowIndex, colIndex + 4, dr.mbl_shipper_name!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, WrapText = true });
                        excel.CellValue(rowIndex, colIndex + 5, dr.mbl_consignee_name!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, WrapText = true });
                        excel.CellValue(rowIndex, colIndex + 6, dr.mbl_cntr_type!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 7, dr.mbl_20!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 8, dr.mbl_40!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 9, dr.mbl_40hq!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 10, dr.mbl_45!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 11, dr.mbl_teu!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex++, colIndex + 12, dr.mbl_cbm!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                    }
                    if (ReportType == "SUMMARY" && LastRow)
                    {
                        excel.CellValue(rowIndex, colIndex + 0, dr.mbl_agent_name!, new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 1, dr.mbl_20!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 2, dr.mbl_40!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 3, dr.mbl_40hq!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 4, dr.mbl_45!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 5, dr.mbl_teu!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex++, colIndex + 6, dr.mbl_cbm!, new CellFormat { Border = TotalBorder + BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                    }
                    if (ReportType == "DETAIL" && LastRow)
                    {
                        excel.CellValue(rowIndex, colIndex + 0, dr.mbl_agent_name!, new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 1, "", new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 2, "", new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 3, "", new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 4, "", new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 5, "", new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 6, "", new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 7, dr.mbl_20!, new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 8, dr.mbl_40!, new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 9, dr.mbl_40hq!, new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 10, dr.mbl_45!, new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex, colIndex + 11, dr.mbl_teu!, new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                        excel.CellValue(rowIndex++, colIndex + 12, dr.mbl_cbm!, new CellFormat { Border = BL, Style= TotalStyle + ST, FontSize = 9, HAlign = "R" });
                    }
                }
            }
            // int remainingRows = MaxCount - count;
            // WriteFooter(rowIndex, colIndex, remainingRows);          //unremark if footer details needed
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

            PageNumber ++;
            col_count = ReportType == "DETAIL" ? 12 : 6;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title.ToUpper()!, new CellFormat { Border = "TB", Style = "B", ColumnWidth = 15 ,FontSize = 10,  MergeCols = col_count});
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex, "FROM DATE" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SFromDate , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "REPORT TYPE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, ReportType, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "TO DATE" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SToDate , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "SHIPMENT", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, ShipType , new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FORMAT" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, Format , new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            if(ReportType == "SUMMARY")
            {
                if (Format == "OPERATION GROUP")
                    excel.CellValue(rowIndex, colIndex + 0, "GROUP", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15});
                if (Format == "AGENT")
                   excel.CellValue(rowIndex, colIndex + 0, "AGENT", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 1, "20", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 2, "40", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 3, "40HC", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 4, "45", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 5, "TEU", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 6, "CBM", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
            }
            if (ReportType == "DETAIL")
            {
                excel.CellValue(rowIndex, colIndex + 0, "REF#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 1, "REF DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 2, "AGENT", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 3, "CARRIER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 4, "SHIPPER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 5, "CONSIGNEE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 6, "TYPE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 7, "20", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 8, "40", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 9, "40HC", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 10, "45", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 11, "TEU", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 12, "CBM", new CellFormat { Border = "TB", Style = "B", FontSize = 10, HAlign = "R", ColumnWidth = 10 });
            }


            rowIndex += 1;
            return rowIndex;
        }
        private int WriteFooter(int rowIndex, int colIndex, int count)
        {
            int startRow = rowIndex;

            rowIndex = FillBlankRows(rowIndex,colIndex,count);
            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name}";

            excel.CellValue(rowIndex, colIndex, printInfo, new CellFormat { Border = "T", FontSize = 9, MergeCols = col_count });
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex, $"PAGE#: {PageNumber}", new CellFormat { FontSize = 9, WrapText = true, MergeCols = 4 });
            rowIndex += 1;
            excel.SetRowBreak(rowIndex);

            return rowIndex;
        }
        private int FillBlankRows(int rowIndex, int colIndex, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                excel.CellValue(rowIndex, colIndex, "", new CellFormat { FontSize = 9 });
                rowIndex++;
            }
            return rowIndex;
        }
    }
}