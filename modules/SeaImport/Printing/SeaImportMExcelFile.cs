using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.Marketing;
using Common.DTO.Masters;
using Common.DTO.SeaImport;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Masters.Interfaces;

namespace SeaImport.Printing
{
    public class ProcessSeaImportMExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<cargo_sea_importm_dto> Dt_List { get; set; } = new List<cargo_sea_importm_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string RefNo { get; set; } = "";
        public string User_name { get; set; } = "";
        public string Mbl_type { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";

        public ProcessSeaImportMExcelFile()
        {
            excel = new TextExcel();
        }

        public void Process()
        {
            try
            {
                fList = new List<filesm>();
                folderid = Guid.NewGuid().ToString().ToUpper();

                File_Display_Name = Mbl_type.ToString()!.ToLower();
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

            foreach (cargo_sea_importm_dto dr in Dt_List)
            {
                var mbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.mbl_ref_date!), Lib.DisplayDateFormat) ?? "";

                excel.CellValue(rowIndex, colIndex, dr.mbl_refno!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 1, mbl_ref_date.ToUpper(), new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 2, dr.mbl_no!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 3, dr.mbl_agent_name!, new CellFormat { Border = "LTB", FontSize = 9, MergeCols = 1 });
                excel.CellValue(rowIndex, colIndex + 4, "", new CellFormat { Border = "TB", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 5, dr.mbl_liner_name!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 6, dr.mbl_cntr_type!, new CellFormat { Border = "A", FontSize = 9 });
                excel.CellValue(rowIndex++, colIndex + 7, dr.mbl_handled_name!, new CellFormat { Border = "A", FontSize = 9 });
            }
            excel.Save(File_Name);
        }

        private int WriteHeader()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int col_count = 7; // Column count to merge
            excel.CreateSheet("Sheet1");

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? ""; // convert string date into dd-mmm-yyyy fromat
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title.ToUpper() + " LIST", new CellFormat { Border = "TB", Style = "B", FontSize = 10, MergeCols = col_count});

            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FROM DATE"  , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SFromDate.ToUpper() , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "REF NO" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3,  RefNo , new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "TO DATE" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SToDate.ToUpper(), new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "PRINTED : " + Date + " / " + User_name, new CellFormat { FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "REF #", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 1, "DATE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 2, "MBL #", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 3, "MASTER AGENT", new CellFormat { Border = "LT", Style = "B", FontSize = 10, ColumnWidth = 25, MergeCols = 1 });
            excel.CellValue(rowIndex, colIndex + 4, "", new CellFormat { Border = "T", Style = "B", FontSize = 10, ColumnWidth = 25 });
            excel.CellValue(rowIndex, colIndex + 5, "CARRIER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25 });
            excel.CellValue(rowIndex, colIndex + 6, "SHIP TYPE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            excel.CellValue(rowIndex, colIndex + 7, "HANDLED BY", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            rowIndex += 1;
            return rowIndex;
        }

    }
}