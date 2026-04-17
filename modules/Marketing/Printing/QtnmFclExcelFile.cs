using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.Marketing;
using Common.DTO.Masters;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Masters.Interfaces;
using Microsoft.AspNetCore.Components.Web;

namespace Marketing.Printing
{
    public class ProcessFclExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<mark_qtnm_dto> Dt_List { get; set; } = new List<mark_qtnm_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string Name { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string QuoteTo { get; set; } = "";
        public string QuoteNo { get; set; } = "";
        public string User_name { get; set; } = "";
        public string Qtnm_type { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";

        public ProcessFclExcelFile()
        {
            excel = new TextExcel();
        }

        public void Process()
        {
            try
            {
                fList = new List<filesm>();
                folderid = Guid.NewGuid().ToString().ToUpper();

                File_Display_Name = Qtnm_type.ToString()!.ToLower();
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

            foreach (mark_qtnm_dto dr in Dt_List)
            {
                var qtnm_date = Lib.FormatDate(Lib.ParseDate(dr.qtnm_date!),Lib.DisplayDateFormat);

                excel.CellValue(rowIndex, colIndex, dr.qtnm_no!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 1, qtnm_date.ToUpper(), new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 2, dr.qtnm_to_name!, new CellFormat { Border = "LTB", FontSize = 9, MergeCols = 1 });
                excel.CellValue(rowIndex, colIndex + 3, "", new CellFormat { Border = "TB", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 4, dr.qtnm_quot_by!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 5, dr.qtnm_move_type!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex++, colIndex + 6, dr.qtnm_commodity!, new CellFormat { Border = "A", FontSize = 9 });
            }
            excel.Save(File_Name);
        }

        private int WriteHeader()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int col_count = 6; // Column count to merge
            excel.CreateSheet("Sheet1");

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title.ToUpper() + " LIST", new CellFormat { Border = "TB", Style = "B", FontSize = 10, MergeCols = 1});
            for (int i = colIndex + 1; i < colIndex + col_count; i++)
            {
                excel.CellValue(rowIndex, i, "", new CellFormat { Border = "TB", FontSize = 10 });
            }
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex + 0, "FROM DATE" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SFromDate.ToUpper(), new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "QUOTE TO" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, QuoteTo, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex + 0, "TO DATE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SToDate.ToUpper(), new CellFormat { Style = "B", FontSize = 10 });;
            excel.CellValue(rowIndex, colIndex + 2, "QUOTE NO", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, QuoteNo, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "PRINTED : " + Date + " / " + User_name, new CellFormat { FontSize = 10});
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "QUOTE#", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 1, "DATE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 2, "QUOTE TO", new CellFormat { Border = "LT", Style = "B", FontSize = 10, ColumnWidth = 50, MergeCols = 1 });
            excel.CellValue(rowIndex, colIndex + 3, "", new CellFormat { Border = "T", Style = "B", FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 4, "QUOTE BY", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 5, "MOVE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 6, "COMMODITY", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 20 });
            rowIndex += 1;
            return rowIndex;
        }

    }
}