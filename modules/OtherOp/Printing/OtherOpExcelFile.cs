using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.Marketing;
using Common.DTO.Masters;
using Common.DTO.OtherOp;
using Common.DTO.SeaExport;
using Common.DTO.SeaImport;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Masters.Interfaces;

namespace SeaExport.Printing
{
    public class ProcessOtherOpExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<cargo_otherop_dto> Dt_List { get; set; } = new List<cargo_otherop_dto>();
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

        public ProcessOtherOpExcelFile()
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

            foreach (cargo_otherop_dto dr in Dt_List)
            {
                excel.CellValue(rowIndex, colIndex, dr.oth_refno!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 9 });
                excel.CellValue(rowIndex, colIndex + 1, Lib.FormatDate(Lib.ParseDate(dr.oth_ref_date!), Lib.DisplayDateFormat), new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 11 });
                excel.CellValue(rowIndex, colIndex + 2, dr.oth_mbl_no!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 3, dr.oth_agent_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 50 });
                excel.CellValue(rowIndex, colIndex + 4, dr.oth_liner_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 25 });
                excel.CellValue(rowIndex, colIndex + 5, dr.oth_pol_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 6, Lib.FormatDate(Lib.ParseDate(dr.oth_pol_etd!), Lib.DisplayDateFormat), new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 11});
                excel.CellValue(rowIndex, colIndex + 7, dr.oth_pod_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 8, Lib.FormatDate(Lib.ParseDate(dr.oth_pod_eta!), Lib.DisplayDateFormat), new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 11});
                excel.CellValue(rowIndex++, colIndex + 9, dr.oth_handled_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 10 });
            }
            excel.Save(File_Name);
        }

        private int WriteHeader()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int col_count = 1; // Column count to merge
            excel.CreateSheet("Sheet1");

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            FromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat); // convert string date into dd-mmm-yyyy fromat
            ToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat);

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title, new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 100, Merge = col_count });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FROM    :" + FromDate , new CellFormat { FontSize = 10, ColumnWidth = 100, Merge = col_count });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "TO       :"+ ToDate , new CellFormat { FontSize = 10, ColumnWidth = 100, Merge = col_count });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "REF NO    :" + RefNo, new CellFormat { FontSize = 10, ColumnWidth = 100, Merge = col_count });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "PRINTED : " + Date + " / " + User_name, new CellFormat { FontSize = 10, ColumnWidth = 100, Merge = col_count });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "REF #", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 9 });
            excel.CellValue(rowIndex, colIndex + 1, "DATE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 11 });
            excel.CellValue(rowIndex, colIndex + 2, "MBL #", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 15 });
            excel.CellValue(rowIndex, colIndex + 3, "MASTER AGENT", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 50 });
            excel.CellValue(rowIndex, colIndex + 4, "CARRIER", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 25 });
            excel.CellValue(rowIndex, colIndex + 5, "POL", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 6, "ETD", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 11 });
            excel.CellValue(rowIndex, colIndex + 7, "POD", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 8, "ETA", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 11 });
            excel.CellValue(rowIndex, colIndex + 9, "HANDLED", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 10 });
            rowIndex += 1;
            return rowIndex;
        }

    }
}