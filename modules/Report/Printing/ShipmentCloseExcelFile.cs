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
    public class ShipmentCloseExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<rep_shipmentclose_dto> Dt_List { get; set; } = new List<rep_shipmentclose_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string OpGroup { get; set; } = "";
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
        public ShipmentCloseExcelFile()
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

            foreach (rep_shipmentclose_dto dr in Dt_List)
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

                var mbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.mbl_ref_date!), Lib.DisplayDateFormat) ?? "";
                var hbl_er_date = Lib.FormatDate(Lib.ParseDate(dr.hbl_empty_ret_date!), Lib.DisplayDateFormat) ?? "";
                var hbl_pickup_date = Lib.FormatDate(Lib.ParseDate(dr.hbl_pickup_date!), Lib.DisplayDateFormat) ?? "";

                excel.CellValue(rowIndex, colIndex, dr.mbl_refno!, excel.GetCellFormat(Border:BL));
                excel.CellValue(rowIndex, colIndex + 1, mbl_ref_date.ToUpper(), excel.GetCellFormat(Border:BL));
                excel.CellValue(rowIndex, colIndex + 2, dr.rec_locked!, excel.GetCellFormat(Border:BL));
                if(OpGroup == "SEA IMPORT")
                {
                    excel.CellValue(rowIndex, colIndex + 3, dr.mbl_bl_req!, excel.GetCellFormat(Border:BL));
                    excel.CellValue(rowIndex, colIndex + 4, dr.mbl_cntr_type!, excel.GetCellFormat(Border:BL));
                    excel.CellValue(rowIndex, colIndex + 5, hbl_er_date.ToUpper()!, excel.GetCellFormat(Border:BL));
                    excel.CellValue(rowIndex, colIndex + 6, hbl_pickup_date.ToUpper()!, excel.GetCellFormat(Border:BL));
                    excel.CellValue(rowIndex, colIndex + 7, dr.mbl_profit_req!, excel.GetCellFormat(Border:BL));
                    excel.CellValue(rowIndex, colIndex + 8, dr.mbl_loss_approved!, excel.GetCellFormat(Border:BL));
                    excel.CellValue(rowIndex, colIndex + 9, dr.mbl_loss_memo!, excel.GetCellFormat(Border:BL));
                    excel.CellValue(rowIndex++, colIndex + 10, dr.mbl_revenue!, excel.GetCellFormat(Border:BL, Halign:"R"));
                }
                else
                {
                    excel.CellValue(rowIndex, colIndex + 3, dr.mbl_profit_req!, excel.GetCellFormat(Border:BL));
                    excel.CellValue(rowIndex, colIndex + 4, dr.mbl_loss_approved!, excel.GetCellFormat(Border:BL));
                    excel.CellValue(rowIndex, colIndex + 5, dr.mbl_loss_memo!, excel.GetCellFormat(Border:BL));
                    excel.CellValue(rowIndex++, colIndex + 6, dr.mbl_revenue!, excel.GetCellFormat(Border:BL, Halign:"R"));   
                }
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

            col_count = OpGroup == "SEA IMPORT" ? 10 : 6;

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
            excel.CellValue(rowIndex, colIndex + 2, "GROUP", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, OpGroup , new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "TO DATE" , new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SToDate , new CellFormat { Style = "B", FontSize = 10 });

            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex + 0, "REF#", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15 ));
            excel.CellValue(rowIndex, colIndex + 1, "REF-DATE", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15 ));
            excel.CellValue(rowIndex, colIndex + 2, "LOCK", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:10 ));
            if(OpGroup == "SEA IMPORT")
            {
                excel.CellValue(rowIndex, colIndex + 3, "BL-STATUS", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:25 ));
                excel.CellValue(rowIndex, colIndex + 4, "SHIPMENT", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:10 ));
                excel.CellValue(rowIndex, colIndex + 5, "E.RET-DATE", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15 ));
                excel.CellValue(rowIndex, colIndex + 6, "PICKUP-DATE", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15 ));
                excel.CellValue(rowIndex, colIndex + 7, "PROFIT-MET", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:10 ));
                excel.CellValue(rowIndex, colIndex + 8, "LOSS-APPROVED", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15 ));
                excel.CellValue(rowIndex, colIndex + 9, "MEMO", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:30 ));
                excel.CellValue(rowIndex, colIndex + 10, "PROFIT", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:20, Halign:"R" ));
            }
            else
            {
                excel.CellValue(rowIndex, colIndex + 3, "PROFIT-MET", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:10 ));
                excel.CellValue(rowIndex, colIndex + 4, "LOSS-APPROVED", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:15 ));
                excel.CellValue(rowIndex, colIndex + 5, "MEMO", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:30 ));
                excel.CellValue(rowIndex, colIndex + 6, "PROFIT", excel.GetCellFormat( Border:"TB", Style:"B", FontSize:10, ColumnWidth:20, Halign:"R" ));
            }
            
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