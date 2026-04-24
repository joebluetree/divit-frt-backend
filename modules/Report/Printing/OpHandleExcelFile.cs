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

namespace Report.Printing
{
    public class ProcessOpHandleExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<rep_ophandle_dto> Dt_List { get; set; } = new List<rep_ophandle_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string Type { get; set; } = "";
        public string User_name { get; set; } = "";
        public string OpGroup { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private int col_count = 3; // Column count set Title border
        private int PageNumber = 0;
        private int MaxCount = 40;
        private int Total_Master = 0;
        private int Total_House = 0;
        public ProcessOpHandleExcelFile()
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
        private bool IsPageBreak(int count)
        {
            bool rec = false;
            if (count == MaxCount)
                rec = true;
            return rec;
        }
        private void CreateExcelData()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int count = 0;
            rowIndex = WriteHeader(rowIndex, colIndex);

            foreach (rep_ophandle_dto dr in Dt_List)
            {
                if (IsPageBreak(count))
                {
                    int Rows = MaxCount - count;
                    rowIndex = WriteFooter(rowIndex, colIndex, Rows );
                    rowIndex += 1;
                    rowIndex = WriteHeader(rowIndex, colIndex);
                    count = 0;
                }
                if(OpGroup == "SUMMARY")
                {
                    excel.CellValue(rowIndex, colIndex, dr.ophandle_handled_name!, new CellFormat { Border = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 2, dr.ophandle_master_count!, new CellFormat { Border = "", FontSize = 9 });
                    excel.CellValue(rowIndex++, colIndex + 3, dr.ophandle_house_count!, new CellFormat { Border = "", FontSize = 9 });
                    Total_Master += dr.ophandle_master_count ?? 0;
                    Total_House += dr.ophandle_house_count ?? 0;                  
                }
                else
                {
                    var ophandle_date = Lib.FormatDate(Lib.ParseDate(dr.ophandle_ref_date!), Lib.DisplayDateFormat) ?? "";

                    excel.CellValue(rowIndex, colIndex, dr.ophandle_refno!, new CellFormat { Border = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 1, ophandle_date.ToUpper(), new CellFormat { Border = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 2, dr.ophandle_handled_name!, new CellFormat { Border = "", FontSize = 9 });
                    excel.CellValue(rowIndex++, colIndex + 3, dr.ophandle_agent_name!, new CellFormat { Border = "", FontSize = 9 });
                }
                count ++;
            }
            int remainingRows = MaxCount - count;
            WriteFooter(rowIndex, colIndex, remainingRows);
            excel.SetColumnBreak(colIndex + 4);
            excel.Save(File_Name);
        }

        private int WriteHeader(int rowIndex, int colIndex)
        {
            if (rowIndex == 0)
            {
                excel.CreateSheet("Sheet1");
                excel.PrintGridlines(false);// for no grid lines                
            }

            PageNumber ++;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title , new CellFormat { Border = "TB", Style = "B", FontSize = 10, MergeCols = col_count});
            for (int i = colIndex + 1; i < colIndex + col_count; i++)
            {
                excel.CellValue(rowIndex, i, "", new CellFormat { Border = "TB", FontSize = 10 });
            }
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FROM DATE" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SFromDate , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "TYPE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, Type , new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "TO DATE" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SToDate , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "GROUP", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, OpGroup , new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            if(OpGroup == "SUMMARY")
            {
                excel.CellValue(rowIndex, colIndex + 0, "HANDLED BY", new CellFormat { Border = "T", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 1, "", new CellFormat { Border = "T", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 2, "MASTER HANDLED", new CellFormat { Border = "T", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 3, "HOUSE HANDLED", new CellFormat { Border = "T", Style = "B", FontSize = 10, ColumnWidth = 30 });
            }
            if(OpGroup != "SUMMARY")//if(OpGroup == "MASTER" || OpGroup == "HOUSE")
            {
                excel.CellValue(rowIndex, colIndex + 0, "REF #", new CellFormat { Border = "T", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 1, "DATE", new CellFormat { Border = "T", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 2, "HANDLED BY", new CellFormat { Border = "T", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 3, "MASTER AGENT", new CellFormat { Border = "T", Style = "B", FontSize = 10, ColumnWidth = 50 });
            }
            rowIndex += 1;
            return rowIndex;
        }
        private int WriteFooter(int rowIndex, int colIndex, int count)
        {
            int startRow = rowIndex;

            if(OpGroup == "SUMMARY")
            {
                excel.CellValue(rowIndex, colIndex + 0, "TOTAL", new CellFormat { Border = "T", Style = "B", FontSize = 10 });
                excel.CellValue(rowIndex, colIndex + 1, "", new CellFormat { Border = "T", Style = "B", FontSize = 10 });
                excel.CellValue(rowIndex, colIndex + 2, Total_Master, new CellFormat { Border = "T", Style = "B", FontSize = 10 });
                excel.CellValue(rowIndex ++, colIndex + 3, Total_House, new CellFormat { Border = "T", Style = "B", FontSize = 10 });
                count -= 1;// add 1 row for summary
            }
            rowIndex = FillBlankRows(rowIndex,colIndex,count);
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