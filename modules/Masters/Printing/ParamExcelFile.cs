using System;
using System.Collections.Generic;
using System.Data;
using Common.Lib;
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
        public DataTable Dt_List = new DataTable();
        public string Title { get; set; } = "";

        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";

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

                File_Display_Name = Dt_List.Rows[0]["param_type"].ToString()!.ToLower();
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
            excel.CreateSheet("Sheet1");
            excel.CellValue(rowIndex++, 0, Title.ToUpper(), new CellFormat{Style = "B",Merge = 1,ColumnWidth = 55,});
            excel.CellValue(rowIndex, 0, "CODE", new CellFormat { Border = "A", ColumnWidth = 15 });
            excel.CellValue(rowIndex++, 1, "NAME", new CellFormat { Border = "A", ColumnWidth = 40 });
            foreach (DataRow dr in Dt_List.Rows)
            {
                excel.CellValue(rowIndex, 0, dr["param_code"], new CellFormat { Border = "A", ColumnWidth = 15 });
                excel.CellValue(rowIndex++, 1, dr["param_name"], new CellFormat { Border = "A", ColumnWidth = 40 });
            }
            excel.Save(File_Name);
        }

    }
}