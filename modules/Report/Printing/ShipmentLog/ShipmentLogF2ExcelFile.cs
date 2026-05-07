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
    public class ShipmentLogF2ExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<rep_shipmentlog_dto> Dt_List { get; set; } = new List<rep_shipmentlog_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string DateType { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string ShipperName { get; set; } = "";
        public string ConsigneeName { get; set; } = "";
        public string AgentName { get; set; } = "";
        public string UserRole { get; set; } = "";
        public string handledBy { get; set; } = "";
        public string Format { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public string User_name { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private int col_count = 0; // Column Total count
        private int PageNumber = 0;
        // private int MaxCount = 38;

        public ShipmentLogF2ExcelFile()
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
        private CellFormat GetFormat(int ColumnWidth = 0, int FontSize = 9,string Style = "",string Border = "",string valign = "T")
        {
            return new CellFormat
            {
                WrapText = true,
                Border = Border,
                Style = Style,
                FontSize = FontSize,
                VAlign = valign,
                ColumnWidth = ColumnWidth ==0 ? null:ColumnWidth,
            };
        }
        private void CreateExcelData()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int count = 0;
            rowIndex = WriteHeader(rowIndex, colIndex);

            foreach (rep_shipmentlog_dto dr in Dt_List)
            {
                count++;

                var mbl_etd = Lib.FormatDate(Lib.ParseDate(dr.mbl_pol_etd!), Lib.DisplayDateFormat) ?? "";
                var mbl_eta = Lib.FormatDate(Lib.ParseDate(dr.mbl_pod_eta!), Lib.DisplayDateFormat) ?? "";
                var hbl_plf_eta = Lib.FormatDate(Lib.ParseDate(dr.hbl_plf_eta!), Lib.DisplayDateFormat) ?? "";

                excel.CellValue(rowIndex, colIndex + 0, dr.mbl_refno!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 1, dr.mbl_houseno!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 2, dr.mbl_shipstage!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 3, dr.mbl_liner_name!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 4, dr.mbl_liner_bookingno!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 5, dr.mbl_consignee_name!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 6, dr.mbl_cntr_type!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 7, mbl_etd!.ToUpper(), GetFormat());
                excel.CellValue(rowIndex, colIndex + 8, dr.mbl_isf_no!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 9, dr.mbl_mstatus!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 10, dr.mbl_hstatus!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 11, dr.mbl_is_pl!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 12, dr.mbl_is_ci!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 13, dr.mbl_is_carr_an!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 14, dr.mbl_custom_reles_status!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 15, dr.mbl_frt_status_name!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 16, dr.mbl_paid_status!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 17, mbl_eta!.ToUpper(), GetFormat());
                excel.CellValue(rowIndex, colIndex + 18, dr.mbl_is_delivery!, GetFormat());
                excel.CellValue(rowIndex++, colIndex + 19, hbl_plf_eta!.ToUpper(), GetFormat());
    
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
            col_count = 19;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, $"{Title.ToUpper()!} - {OpGroup}", new CellFormat { Border = "TB", Style = "B", ColumnWidth = 15, FontSize = 10, MergeCols = col_count });
            rowIndex += 1;

            var Lrow = rowIndex;
            
            excel.CellValue(Lrow, colIndex + 0, "DATE TYPE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(Lrow, colIndex + 1, DateType, new CellFormat { Style = "B", FontSize = 10 });
            Lrow += 1;
            excel.CellValue(Lrow, colIndex, "FROM DATE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(Lrow, colIndex + 1, SFromDate.ToUpper(), new CellFormat { Style = "B", FontSize = 10 });
            Lrow += 1;
            excel.CellValue(Lrow, colIndex, "TO DATE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(Lrow, colIndex + 1, SToDate.ToUpper(), new CellFormat { Style = "B", FontSize = 10 });
            Lrow += 1;
            excel.CellValue(Lrow, colIndex, "SHIPPER", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(Lrow, colIndex + 1, ShipperName, new CellFormat { Style = "B", FontSize = 10 });
            Lrow += 1;
            excel.CellValue(Lrow, colIndex, "CONSIGNEE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(Lrow, colIndex + 1, ConsigneeName, new CellFormat { Style = "B", FontSize = 10 });

            var Rrow = rowIndex;

            excel.CellValue(Rrow, colIndex + 2, "AGENT", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(Rrow, colIndex + 3, AgentName, new CellFormat { Style = "B", FontSize = 10 });
            Rrow += 1;
            excel.CellValue(Rrow, colIndex + 2, UserRole.ToUpper(), new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(Rrow, colIndex + 3, handledBy, new CellFormat { Style = "B", FontSize = 10 });
            Rrow += 1;
            excel.CellValue(Rrow, colIndex + 2, "CREATED BY", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(Rrow, colIndex + 3, CreatedBy, new CellFormat { Style = "B", FontSize = 10 });

            rowIndex = new[] { Rrow, Lrow}.Max();

            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex + 0, "REFNO", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 20));
            excel.CellValue(rowIndex, colIndex + 1, "MASTER/HOUSE #", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 20));
            excel.CellValue(rowIndex, colIndex + 2, "SHIPMENT STAGE", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 25));
            excel.CellValue(rowIndex, colIndex + 3, "CARRIER", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 30));
            excel.CellValue(rowIndex, colIndex + 4, "BOOKING #", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 20));
            excel.CellValue(rowIndex, colIndex + 5, "CONSIGNEE", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 35));
            excel.CellValue(rowIndex, colIndex + 6, "TYPE", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 15));
            excel.CellValue(rowIndex, colIndex + 7, "ETD", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 15));
            excel.CellValue(rowIndex, colIndex + 8, "ISF", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 20));
            excel.CellValue(rowIndex, colIndex + 9, "M RLS", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 30));
            excel.CellValue(rowIndex, colIndex + 10, "H RLS", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 30));
            excel.CellValue(rowIndex, colIndex + 11, "PL", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 8));
            excel.CellValue(rowIndex, colIndex + 12, "CI", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 8));
            excel.CellValue(rowIndex, colIndex + 13, "CARRIER AN", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 12));
            excel.CellValue(rowIndex, colIndex + 14, "CUSTOM RELEASE STATUS", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 25));
            excel.CellValue(rowIndex, colIndex + 15, "FREIGHT RELEASE STATUS", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 25));
            excel.CellValue(rowIndex, colIndex + 16, "CLIENT PAID", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 25));
            excel.CellValue(rowIndex, colIndex + 17, "ETA", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 15));
            excel.CellValue(rowIndex, colIndex + 18, "DELIVERY", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 12));
            excel.CellValue(rowIndex, colIndex + 19, "DELIVERY DATE", GetFormat(Border: "TB", Style: "B", FontSize: 10, ColumnWidth: 15));

            rowIndex += 1;
            return rowIndex;
        }
    }
}