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
    public class ShipmentLogANPendingExcelFile
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
        public string IsHandledbyWise { get; set; } = "";
        public string User_name { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private int col_count = 0; // Column Total count
        private int PageNumber = 0;
        // private int MaxCount = 38;

        public ShipmentLogANPendingExcelFile()
        {
            excel = new TextExcel();
        }

        public void Process()
        {
            try
            {
                fList = new List<filesm>();
                folderid = Guid.NewGuid().ToString().ToUpper();

                File_Display_Name = Title.ToString()!;
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
            if (IsHandledbyWise == "Y")
            {
                var groupedData = Dt_List
                    .GroupBy(g => Lib.IsBlank(g.mbl_handled_name) ? "OTHERS" : g.mbl_handled_name);

                foreach (var group in groupedData)
                {
                    CreateSheetData(group.Key!, group.ToList());
                }
            }
            else
            {
                CreateSheetData("Sheet1", Dt_List);
            }

            excel.Save(File_Name);
        }
        private void CreateSheetData(string sheetName, List<rep_shipmentlog_dto> data)
        {
            int rowIndex = 0;
            int colIndex = 0;
            int count = 0;

            rowIndex = WriteHeader(rowIndex, colIndex, sheetName);

            foreach (rep_shipmentlog_dto dr in data)
            {
                count++;

                var mbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.mbl_ref_date!), Lib.DisplayDateFormat) ?? "";
                var mbl_eta = Lib.FormatDate(Lib.ParseDate(dr.mbl_pod_eta!), Lib.DisplayDateFormat) ?? "";

                excel.CellValue(rowIndex, colIndex + 0, dr.mbl_handled_name!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 1, dr.mbl_shipstage!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 2, dr.mbl_refno!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 3, mbl_ref_date!.ToUpper(), GetFormat());
                excel.CellValue(rowIndex, colIndex + 4, dr.mbl_no!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 5, dr.mbl_houseno!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 6, dr.mbl_liner_name!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 7, dr.mbl_agent_name!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 8, dr.mbl_shipper_name!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 9, dr.mbl_consignee_name!, GetFormat());
                excel.CellValue(rowIndex, colIndex + 10, mbl_eta!.ToUpper(), GetFormat());
                excel.CellValue(rowIndex, colIndex + 11, dr.mbl_bo_status!, GetFormat());
                excel.CellValue(rowIndex++, colIndex + 12, dr.mbl_bo_attended_code!, GetFormat());
            }

            // excel.SetColumnBreak(colIndex + 17);
        }

        private int WriteHeader(int rowIndex, int colIndex, string sheetName)
        {
            if (rowIndex == 0)
            {
                excel.CreateSheet(sheetName);
                excel.PrintGridlines(true);// for grid lines On/Off
            }

            PageNumber++;
            col_count = 17;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, $"{Title.ToUpper()!} - {OpGroup}", new CellFormat { Border = "TB", Style = "B", ColumnWidth = 15, FontSize = 10, MergeCols = col_count });
            rowIndex += 1;

            var Lrow = rowIndex;
            
            excel.CellValue(Lrow, colIndex + 0, "DATE TYPE", GetFormat( Style:"B", FontSize:10 ) );
            excel.CellValue(Lrow, colIndex + 1, DateType, GetFormat( Style:"B", FontSize:10 ) );
            Lrow += 1;
            excel.CellValue(Lrow, colIndex, "FROM DATE", GetFormat( Style:"B", FontSize:10 ) );
            excel.CellValue(Lrow, colIndex + 1, SFromDate.ToUpper(), GetFormat( Style:"B", FontSize:10 ) );
            Lrow += 1;
            excel.CellValue(Lrow, colIndex, "TO DATE", GetFormat( Style:"B", FontSize:10 ) );
            excel.CellValue(Lrow, colIndex + 1, SToDate.ToUpper(), GetFormat( Style:"B", FontSize:10 ) );
            Lrow += 1;
            excel.CellValue(Lrow, colIndex, "SHIPPER", GetFormat( Style:"B", FontSize:10 ) );
            excel.CellValue(Lrow, colIndex + 1, ShipperName, GetFormat( Style:"B", FontSize:10 ) );
            Lrow += 1;
            excel.CellValue(Lrow, colIndex, "CONSIGNEE", GetFormat( Style:"B", FontSize:10 ) );
            excel.CellValue(Lrow, colIndex + 1, ConsigneeName, GetFormat( Style:"B", FontSize:10 ) );

            var Rrow = rowIndex;

            excel.CellValue(Rrow, colIndex + 2, "AGENT", GetFormat( Style:"B", FontSize:10 ) );
            excel.CellValue(Rrow, colIndex + 3, AgentName, GetFormat( Style:"B", FontSize:10 ) );
            Rrow += 1;
            excel.CellValue(Rrow, colIndex + 2, UserRole.ToUpper(), GetFormat( Style:"B", FontSize:10 ) );
            excel.CellValue(Rrow, colIndex + 3, handledBy, GetFormat( Style:"B", FontSize:10 ) );
            Rrow += 1;
            excel.CellValue(Rrow, colIndex + 2, "CREATED BY", GetFormat( Style:"B", FontSize:10 ) );
            excel.CellValue(Rrow, colIndex + 3, CreatedBy,  GetFormat( Style:"B", FontSize:10 ) );

            rowIndex = new[] { Rrow, Lrow}.Max();

            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex + 0, "HANDLED.BY", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:18));
            excel.CellValue(rowIndex, colIndex + 1, "SHIPMENT STAGE", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:30));
            excel.CellValue(rowIndex, colIndex + 2, "REF#", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15));
            excel.CellValue(rowIndex, colIndex + 3, "REF-DATE", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15));
            excel.CellValue(rowIndex, colIndex + 4, "MASTER #", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:20));
            excel.CellValue(rowIndex, colIndex + 5, "HOUSE #", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:20));
            excel.CellValue(rowIndex, colIndex + 6, "CARRIER", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:30));
            excel.CellValue(rowIndex, colIndex + 7, "AGENT", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:30));
            excel.CellValue(rowIndex, colIndex + 8, "SHIPPER", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:35));
            excel.CellValue(rowIndex, colIndex + 9, "CONSIGNEE", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:35));
            excel.CellValue(rowIndex, colIndex + 10, "ETA", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15));
            excel.CellValue(rowIndex, colIndex + 11, "STATUS", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15));
            excel.CellValue(rowIndex, colIndex + 12, "STATUS BY", GetFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15));

            rowIndex += 1;
            return rowIndex;
        }
    }
}