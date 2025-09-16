using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.AirImport;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Masters.Interfaces;

namespace AirImport.Printing
{
    public class ProcessAirImportHExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<cargo_air_importh_dto> Dt_List { get; set; } = new List<cargo_air_importh_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string HouseNo { get; set; } = "";
        public string User_name { get; set; } = "";
        public string Hbl_type { get; set; } = "";
        public string ETD { get; set; } = "";
        public string ETA { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";

        public ProcessAirImportHExcelFile()
        {
            excel = new TextExcel();
        }

        public void Process()
        {
            try
            {
                fList = new List<filesm>();
                folderid = Guid.NewGuid().ToString().ToUpper();

                File_Display_Name = Hbl_type.ToString()!.ToLower();
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

            foreach (cargo_air_importh_dto dr in Dt_List)
            {
                ETA = Lib.FormatDate(Lib.ParseDate(dr.hbl_plf_eta!), Lib.DisplayDateFormat);

                excel.CellValue(rowIndex, colIndex, dr.hbl_houseno!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 15});
                excel.CellValue(rowIndex, colIndex + 1, dr.hbl_mbl_refno!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 2, dr.hbl_shipper_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 25, MergeCols = 1 });
                excel.CellValue(rowIndex, colIndex + 3, "", new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 25 });
                excel.CellValue(rowIndex, colIndex + 4, dr.hbl_consignee_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 25, MergeCols = 1 });
                excel.CellValue(rowIndex, colIndex + 5, "", new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 25 });
                excel.CellValue(rowIndex, colIndex + 6, dr.hbl_agent_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 25, MergeCols = 1});
                excel.CellValue(rowIndex, colIndex + 7, "", new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 25 });
                excel.CellValue(rowIndex++, colIndex + 8, dr.hbl_handled_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 15 });
            }
            excel.Save(File_Name);
        }

        private int WriteHeader()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int col_count = 9; // Column count to merge
            excel.CreateSheet("Sheet1");

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            FromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat); // convert string date into dd-mmm-yyyy fromat
            ToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat);

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title + " LIST", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 100,MergeCols = 1});
            for (int i = colIndex + 1; i < colIndex + col_count; i++)
            {
                excel.CellValue(rowIndex, i, "", new CellFormat { Border = "TB", FontSize = 10, ColumnWidth = 100 });
            }
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FROM DATE :"  , new CellFormat { FontSize = 10, ColumnWidth = 80 });
            excel.CellValue(rowIndex, colIndex + 1, FromDate , new CellFormat { FontSize = 10, ColumnWidth = 80 });
            excel.CellValue(rowIndex, colIndex + 2, "TO DATE :" , new CellFormat { FontSize = 10, ColumnWidth = 80 });
            excel.CellValue(rowIndex, colIndex + 3, ToDate , new CellFormat { FontSize = 10, ColumnWidth = 80 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "HOUSE #:" , new CellFormat { FontSize = 10, ColumnWidth = 80 });
            excel.CellValue(rowIndex, colIndex + 1, HouseNo, new CellFormat { FontSize = 10, ColumnWidth = 80 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "PRINTED : " + Date + " / " + User_name, new CellFormat { FontSize = 10, ColumnWidth = 80 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "HOUSE #", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 1, "REF #", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15});
            excel.CellValue(rowIndex, colIndex + 2, "SHIPPER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25, MergeCols = 1});
            excel.CellValue(rowIndex, colIndex + 3, "", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25});
            excel.CellValue(rowIndex, colIndex + 4, "CONSIGNEE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25, MergeCols = 1});
            excel.CellValue(rowIndex, colIndex + 5, "", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25});
            excel.CellValue(rowIndex, colIndex + 6, "AGENT", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25, MergeCols = 1 });
            excel.CellValue(rowIndex, colIndex + 7, "", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25});
            excel.CellValue(rowIndex, colIndex + 8, "HANDLED BY", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15});
            rowIndex += 1;
            return rowIndex;
        }
    }
}