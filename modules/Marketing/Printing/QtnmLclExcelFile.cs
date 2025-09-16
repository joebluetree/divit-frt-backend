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

namespace Marketing.Printing
{
    public class ProcessExcelFile
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
        public string Quotepld { get; set; } = "";
        public string User_name { get; set; } = "";
        public string Qtnm_type { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";

        public ProcessExcelFile()
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
                excel.CellValue(rowIndex, colIndex, dr.qtnm_no!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 1, Lib.FormatDate(Lib.ParseDate(dr.qtnm_date!),Lib.DisplayDateFormat), new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 15});
                excel.CellValue(rowIndex, colIndex + 2, dr.qtnm_to_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 25 });
                excel.CellValue(rowIndex, colIndex + 3, "", new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 25 });
                excel.CellValue(rowIndex, colIndex + 4, dr.qtnm_quot_by!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 5, dr.qtnm_pol_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 6, dr.qtnm_pod_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 7, dr.qtnm_pld_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 8, dr.qtnm_move_type!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 12 });
                excel.CellValue(rowIndex++, colIndex + 9, dr.qtnm_commodity!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 30 });
            }
            excel.Save(File_Name);
        }

        private int WriteHeader()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int col_count = 10; // Column count to merge
            excel.CreateSheet("Sheet1");

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title + " LIST", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 100,MergeCols = 1});
            for (int i = colIndex + 1; i < colIndex + col_count; i++)
            {
                excel.CellValue(rowIndex, i, "", new CellFormat { Border = "TB", FontSize = 10, ColumnWidth = 100 });
            }
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FROM DATE:" , new CellFormat { FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 1, FromDate, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 2,"TO DATE:" , new CellFormat { FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 3, ToDate, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "QUOTE TO:" , new CellFormat { FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 1, QuoteTo, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 2, "QUOTE NO:" , new CellFormat { FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 3, QuoteNo, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "PLACE OF DELIVERY:" , new CellFormat { FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex, Quotepld, new CellFormat { FontSize = 10, ColumnWidth = 50 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "PRINTED : " + Date + " / " + User_name, new CellFormat { FontSize = 10, ColumnWidth = 100 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "QUOTE#", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 1, "DATE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 2, "QUOTE TO", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25 });
            excel.CellValue(rowIndex, colIndex + 3, "", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25 });
            excel.CellValue(rowIndex, colIndex + 4, "QUOTE BY", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 5, "POL", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 6, "POD", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 7, "PLACE OF DELIVERY", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 30 });
            excel.CellValue(rowIndex, colIndex + 8, "MOVE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 12 });
            excel.CellValue(rowIndex, colIndex + 9, "COMMODITY", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 30 });
            rowIndex += 1;
            return rowIndex;
        }

    }
}