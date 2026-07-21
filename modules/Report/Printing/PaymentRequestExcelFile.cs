using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.Report;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Masters.Interfaces;

namespace Report.Printing
{
    public class PaymentRequestExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<rep_payrequest_dto> Dt_List { get; set; } = new List<rep_payrequest_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string OpGroup { get; set; } = "";
        public string PayType { get; set; } = "";
        public string RequestBy { get; set; } = "";
        public string CustName { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string User_name { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private int col_count = 0; // Column count set Title border
        private int PageNumber = 0;
        private int MaxCount = 40;
        public PaymentRequestExcelFile()
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

            foreach (rep_payrequest_dto dr in Dt_List)
            {
                var LastRow = count == Dt_List.Count() - 1;
                var BL = LastRow ? "B" : "";
                if (IsPageBreak(count))
                {
                    int Rows = MaxCount - count;
                    rowIndex = WriteFooter(rowIndex, colIndex, Rows );
                    rowIndex += 1;
                    rowIndex = WriteHeader(rowIndex, colIndex);
                    count = 0;
                }

                var cp_req_date = Lib.FormatDate(Lib.ParseDate(dr.rec_created_date!), Lib.DisplayDateFormat) ?? "";
                var cp_payment_date = Lib.FormatDate(Lib.ParseDate(dr.cp_payment_date!), Lib.DisplayDateFormat) ?? "";

                excel.CellValue(rowIndex, colIndex + 0, dr.cp_slno!, excel.GetCellFormat(Border:BL));
                excel.CellValue(rowIndex, colIndex + 1, dr.rec_created_by!, excel.GetCellFormat(Border:BL));
                excel.CellValue(rowIndex, colIndex + 2, cp_req_date.ToUpper(), excel.GetCellFormat(Border:BL));
                excel.CellValue(rowIndex, colIndex + 3, dr.cp_master_no!, excel.GetCellFormat(Border:BL));
                excel.CellValue(rowIndex, colIndex + 4, dr.cp_paytype_needed!, excel.GetCellFormat(Border:BL));
                excel.CellValue(rowIndex, colIndex + 5, dr.cp_cust_name!, excel.GetCellFormat(Border:BL));
                excel.CellValue(rowIndex, colIndex + 6, dr.cp_inv_no!, excel.GetCellFormat(Border:BL));
                excel.CellValue(rowIndex, colIndex + 7, cp_payment_date.ToUpper()!, excel.GetCellFormat(Border:BL));
                excel.CellValue(rowIndex++, colIndex + 8, dr.cp_spl_notes!, excel.GetCellFormat(Border:BL));
                
                count ++;
            }
            int remainingRows = MaxCount - count;
            WriteFooter(rowIndex, colIndex, remainingRows);
            // excel.SetColumnBreak(colIndex + 7);
            excel.Save(File_Name);
        }
        private int WriteHeader(int rowIndex, int colIndex)
        {
            if (rowIndex == 0)
            {
                excel.CreateSheet("Sheet1");
                excel.PrintGridlines(true);// for no grid lines                
            }

            PageNumber ++;

            col_count = 8;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title.ToUpper() , new CellFormat { Border = "TB", Style = "B", FontSize = 10, MergeCols = col_count});
            for (int i = colIndex + 1; i < colIndex + col_count; i++)
            {
                excel.CellValue(rowIndex, i, "", new CellFormat { Border = "TB", FontSize = 10 });
            }
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FROM DATE" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SFromDate , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "STATUS", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, PayType , new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "TO DATE" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SToDate , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "REQUEST.BY", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, RequestBy , new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "GROUP" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, OpGroup , new CellFormat { Style = "B", FontSize = 10 });

            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex + 0, "REQ#", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15 ));
            excel.CellValue(rowIndex, colIndex + 1, "REQUESTED-BY", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:20 ));
            excel.CellValue(rowIndex, colIndex + 2, "REQUEST-DATE", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15 ));
            excel.CellValue(rowIndex, colIndex + 3, "REF#", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:20 ));
            excel.CellValue(rowIndex, colIndex + 4, "REQ.TYPE", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:25 ));
            excel.CellValue(rowIndex, colIndex + 5, "PAYEE", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:30 ));
            excel.CellValue(rowIndex, colIndex + 6, "A/P NO", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15 ));
            excel.CellValue(rowIndex, colIndex + 7, "PAYMENT-DATE", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15 ));
            excel.CellValue(rowIndex, colIndex + 8, "NOTES", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:30 ));
            
            rowIndex += 1;
            return rowIndex;
        }
        private int WriteFooter(int rowIndex, int colIndex, int count)
        {
            int startRow = rowIndex;
            
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