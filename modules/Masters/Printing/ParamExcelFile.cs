using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.Masters;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Masters.Interfaces;

namespace Masters.Printing
{
    public class ProcessExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<mast_param_dto> Dt_List { get; set; } = new List<mast_param_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string Name { get; set; } = "";
        public string User_name { get; set; } = "";
        public string Param_type { get; set; } = "";


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

                File_Display_Name = Param_type.ToString()!.ToLower();
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

            foreach (mast_param_dto dr in Dt_List)
            {
                excel.CellValue(rowIndex, colIndex, dr.param_code!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 20 });
                excel.CellValue(rowIndex++, colIndex + 1, dr.param_name!, new CellFormat { Border = "A", FontSize = 9, ColumnWidth = 60 });
            }
            excel.Save(File_Name);
        }

        private int WriteHeader()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int col_count = 1;
            excel.CreateSheet("Sheet1");

            var getDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(getDate, Lib.DisplayDateFormat);

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title, new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 80, Merge = col_count });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "Name    :" + Name, new CellFormat { FontSize = 10, ColumnWidth = 80, Merge = 1 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "PRINTED : " + Date + " / " + User_name, new CellFormat { FontSize = 10, ColumnWidth = 80, Merge = col_count });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "CODE", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 20 });
            excel.CellValue(rowIndex, colIndex + 1, "NAME", new CellFormat { Border = "A", Style = "B", FontSize = 10, ColumnWidth = 60 });
            rowIndex += 1;
            return rowIndex;
        }

    }
}