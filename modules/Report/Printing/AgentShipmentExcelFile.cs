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
    public class AgentShipmentExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<rep_agentship_dto> Dt_List { get; set; } = new List<rep_agentship_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string ShipperName { get; set; } = "";
        public string ParentName { get; set; } = "";
        public string AgentName { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string ConsigneeName { get; set; } = "";
        public string User_name { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private int col_count = 19; // Column Total count
        private int PageNumber = 0;

        public AgentShipmentExcelFile()
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

            foreach (rep_agentship_dto dr in Dt_List)
            {
                count++;
                // var BL = count == Dt_List.Count() ? "B" : "";
                var BL = CommonLib.IsLastRow(count, Dt_List.Count());

                var hbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.hbl_ref_date!), Lib.DisplayDateFormat) ?? "";
                var hbl_eta = Lib.FormatDate(Lib.ParseDate(dr.hbl_pod_eta!), Lib.DisplayDateFormat) ?? "";
                var hbl_etd = Lib.FormatDate(Lib.ParseDate(dr.hbl_pol_etd!), Lib.DisplayDateFormat) ?? "";

                excel.CellValue(rowIndex, colIndex + 0, dr.hbl_mbl_refno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 1, hbl_ref_date.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 2, dr.hbl_agent_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                excel.CellValue(rowIndex, colIndex + 3, dr.hbl_shipper_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                excel.CellValue(rowIndex, colIndex + 4, dr.hbl_consignee_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                excel.CellValue(rowIndex, colIndex + 5, dr.hbl_liner_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                excel.CellValue(rowIndex, colIndex + 6, dr.hbl_vessel_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                excel.CellValue(rowIndex, colIndex + 7, dr.hbl_voyage!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 8, dr.hbl_pol_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 9, dr.hbl_pod_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 10, hbl_etd.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 11, hbl_eta.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 12, dr.hbl_mbl_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 13, dr.hbl_houseno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 14, dr.hbl_cntr_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 15, dr.hbl_cntr_type_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 16, dr.hbl_cntr_sealno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 17, dr.cntr_discharge_date!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 18, dr.cntr_pick_date!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                excel.CellValue(rowIndex++, colIndex + 19, dr.cntr_return_date!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
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

            PageNumber++;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title.ToUpper()!, new CellFormat { Border = "TB", Style = "B", ColumnWidth = 15, FontSize = 10, MergeCols = col_count });
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex, "FROM DATE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SFromDate, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "AGENT", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, AgentName, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "TO DATE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SToDate, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "SHIPPER", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, ShipperName, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "PARENT", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, ParentName, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "CONSIGNEE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, ConsigneeName, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex + 0, "REF#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 1, "REF DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 2, "AGENT", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
            excel.CellValue(rowIndex, colIndex + 3, "SHIPPER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
            excel.CellValue(rowIndex, colIndex + 4, "CONSIGNEE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
            excel.CellValue(rowIndex, colIndex + 5, "CARRIER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
            excel.CellValue(rowIndex, colIndex + 6, "VESSEL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 7, "VOYAGE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 8, "POL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 9, "POD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 10, "ETD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 11, "ETA", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 12, "MBL#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 13, "HBL#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 14, "CNTR #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 15, "VOL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 8 });
            excel.CellValue(rowIndex, colIndex + 16, "SEAL NO", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 17, "DISCHARGE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 18, "PICKUP", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 19, "EMPTY.RETURN", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });

            rowIndex += 1;
            return rowIndex;
        }
        private int WriteFooter(int rowIndex, int colIndex, int count)
        {
            int startRow = rowIndex;

            rowIndex = FillBlankRows(rowIndex, colIndex, count);
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