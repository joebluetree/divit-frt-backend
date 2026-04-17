
using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.Marketing;
using Common.DTO.UserAdmin;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Database.Models.UserAdmin;
using Masters.Interfaces;
using Newtonsoft.Json.Linq;
using NPOI.HSSF.Record;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;

namespace Marketing.Printing
{
    public class AirReportExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<mark_qtnd_air_dto> Dt_List { get; set; } = new List<mark_qtnd_air_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string Name { get; set; } = "";
        public string User_name { get; set; } = "";
        public string QtnmType { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string CustAddress1 { get; set; } = "";
        public string CustAddress2 { get; set; } = "";
        public string CustAddress3 { get; set; } = "";
        public string CustAttn { get; set; } = "";
        public string QuoteNo { get; set; } = "";
        public string QuoteDate { get; set; } = "";
        public string QuoteBy { get; set; } = "";
        public string QtnmSalesman { get; set; } = "";
        public string QtnmValidDate { get; set; } = "";
        public string QtnmMoveType { get; set; } = "";
        public string QtnmPOR { get; set; } = "";
        public string QtnmPOL { get; set; } = "";
        public string QtnmPOD { get; set; } = "";
        public string QtnmPLD { get; set; } = "";
        public string QtnmPLFD { get; set; } = "";
        public string QtnmCommodity { get; set; } = "";
        public string QtnmPackage { get; set; } = "";
        public string QtnmKGS { get; set; } = "";
        public string QtnmLBS { get; set; } = "";
        public string QtnmCBM { get; set; } = "";
        public string QtnmCFT { get; set; } = "";
        public string QtnmTransTime { get; set; } = "";
        public string QtnmRouting { get; set; } = "";
        public string QtnmCurCode { get; set; } = "";

        public List<gen_remarkm_dto> RemkList { get; set; } = new();

        public bool NextPage { get; set; } = false;
        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private bool IsAttachment = false;
        private int MaxCount = 4;
        private int RemkMaxCount = 12;
        private int col_count = 14;

        public AirReportExcelFile()
        {
            excel = new TextExcel();
        }

        public void Process()
        {
            try
            {
                fList = new List<filesm>();
                folderid = Guid.NewGuid().ToString().ToUpper();

                File_Display_Name = Name.ToString()!.ToUpper();
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
        private bool IsPageBreak(int count, float TotalRowHeight)
        {
            float defaultRowHeight = 15f; // Excel default (points)
            float maxAllowedHeight = MaxCount * defaultRowHeight;

            return count >= MaxCount || TotalRowHeight >= maxAllowedHeight;
        }

        private void CreateExcelData()
        {
            int rowIndex = 0;
            int colIndex = 0;
            string BL = "";
            var recordCount = Dt_List.Count;
            int i = 0;
            int count = 0;
            float totalRowHeight = 0;
            
            rowIndex = WriteHeader(rowIndex, colIndex);

            foreach (mark_qtnd_air_dto dr in Dt_List)
            {
                i++;
                BL = CommonLib.IsLastRow(i, recordCount);
                BL = count == MaxCount - 1 ? "B" : BL;
                if (IsPageBreak(count, totalRowHeight))
                {
                    NextPage = true;
                    rowIndex = WriteFooter(rowIndex, colIndex);
                    rowIndex += 1;
                    rowIndex = WriteHeader(rowIndex, colIndex);
                    count = 0;
                    totalRowHeight = 0;
                }
                NextPage = false;
                excel.CellValue(rowIndex, colIndex, dr.qtnd_pol_name!, new CellFormat { Border = "T", FontSize = 9, WrapText = true, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 1, "", new CellFormat { Border = "T", FontSize = 9, WrapText = true, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 2, dr.qtnd_pod_name!, new CellFormat { Border = "T", FontSize = 9, WrapText = true, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 3, dr.qtnd_carrier_name!, new CellFormat { Border = "T", FontSize = 9, WrapText = true, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 4, dr.qtnd_trans_time!, new CellFormat { Border = "T", FontSize = 9, WrapText = true, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 5, dr.qtnd_min!, new CellFormat { Border = "T", FontSize = 9, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 6, dr.qtnd_45k!, new CellFormat { Border = "T", FontSize = 9, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 7, dr.qtnd_100k!, new CellFormat { Border = "T", FontSize = 9, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 8, dr.qtnd_300k!, new CellFormat { Border = "T", FontSize = 9, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 9, dr.qtnd_500k!, new CellFormat { Border = "T", FontSize = 9, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 10, dr.qtnd_1000k!, new CellFormat { Border = "T", FontSize = 9, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 11, dr.qtnd_fsc!, new CellFormat { Border = "T", FontSize = 9, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 12, dr.qtnd_war!, new CellFormat { Border = "T", FontSize = 9, VAlign = "J"});
                excel.CellValue(rowIndex, colIndex + 13, dr.qtnd_sfc!, new CellFormat { Border = "T", FontSize = 9, VAlign = "J"});
                excel.CellValue(rowIndex++, colIndex + 14, dr.qtnd_hac!, new CellFormat { Border = "T", FontSize = 9, VAlign = "J"});

                count++;
                excel.CellValue(rowIndex, colIndex + 2, dr.qtnd_routing!, new CellFormat { Border = "B", FontSize = 9, WrapText = true, VAlign = "J"});//Border = BL,
                excel.CellValue(rowIndex++, colIndex + 3, dr.qtnd_etd!, new CellFormat { Border = "B", FontSize = 9, WrapText = true, VAlign = "J"});
                if(!Lib.IsBlank(BL))
                    excel.CellValue(rowIndex, colIndex , "", new CellFormat { Border = "T", FontSize = 9, MergeCols = col_count});
            }
            rowIndex = FooterPadding(rowIndex, colIndex, count);
            rowIndex = WriteFooter(rowIndex, colIndex);
            if (IsAttachment)
            {
                rowIndex += 1;
                WriteAttachment(rowIndex, colIndex);
            }

            excel.SetColumnBreak(colIndex + col_count);// mac possible column
            excel.Save(File_Name);
        }

        private int WriteHeader(int rowIndex, int colIndex)
        {
            if (rowIndex == 0)
                excel.CreateSheet("Sheet1");
            excel.PrintGridlines(false);// for no grid lines

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title, new CellFormat { Border = "TB", Style = "B", HAlign = "C", FontSize = 11, MergeCols = col_count });
            rowIndex += 2;
            excel.CellValue(rowIndex, colIndex, "QUOTE NO.", new CellFormat { Style = "B", FontSize = 11, ColumnWidth = 14 });
            excel.CellValue(rowIndex, colIndex + 1, ":", new CellFormat { Style = "B", FontSize = 11 });
            excel.CellValue(rowIndex, colIndex + 2, QuoteNo, new CellFormat { Style = "B", FontSize = 11 });
            rowIndex += 2;

            var leftRow = rowIndex;
            excel.CellValue(leftRow, colIndex + 0, "TO", new CellFormat { Style = "B", Border = "T", FontSize = 10 });
            excel.CellValue(leftRow, colIndex + 1, ":", new CellFormat { Style = "B", Border = "T", FontSize = 10 });
            excel.CellValue(leftRow, colIndex + 2, CustomerName, new CellFormat { Border = "T", FontSize = 10, MergeCols = 3 });
            leftRow += 1;
            excel.CellValue(leftRow, colIndex + 2, CustAddress1, new CellFormat { FontSize = 10 });
            leftRow += 1;
            excel.CellValue(leftRow, colIndex + 2, CustAddress2, new CellFormat { FontSize = 10 });
            leftRow += 1;
            excel.CellValue(leftRow, colIndex + 2, CustAddress3, new CellFormat { FontSize = 10 });
            leftRow += 1;
            excel.CellValue(leftRow, colIndex + 2, "", new CellFormat { FontSize = 10 });
            leftRow += 1;
            excel.CellValue(leftRow, colIndex + 0, "", new CellFormat { Border = "B", FontSize = 10 });
            excel.CellValue(leftRow, colIndex + 1, "", new CellFormat { Border = "B", FontSize = 10 });
            excel.CellValue(leftRow++, colIndex + 2, CustAttn, new CellFormat { Border = "B", FontSize = 10, MergeCols = 3 });

            var rightRow = rowIndex;

            excel.CellValue(rightRow, colIndex + 6, "Date", new CellFormat { Border = "LT", FontSize = 10, MergeCols = 1 });
            excel.CellValue(rightRow, colIndex + 8, QuoteDate, new CellFormat { Border = "LTR", FontSize = 10, MergeCols = 6 });
            rightRow += 1;
            excel.CellValue(rightRow, colIndex + 6, "Quote By", new CellFormat { Border = "LT", FontSize = 10, MergeCols = 1 });
            excel.CellValue(rightRow, colIndex + 8, QuoteBy, new CellFormat { Border = "LTR", FontSize = 10, MergeCols = 6 });
            rightRow += 1;
            excel.CellValue(rightRow, colIndex + 6, "Sales Rep.", new CellFormat { Border = "LT", FontSize = 10, MergeCols = 1 });
            excel.CellValue(rightRow, colIndex + 8, QtnmSalesman, new CellFormat { Border = "LTR", FontSize = 10, MergeCols = 6 });
            rightRow += 1;
            excel.CellValue(rightRow, colIndex + 6, "Validity", new CellFormat { Border = "LT", FontSize = 10, MergeCols = 1 });
            excel.CellValue(rightRow, colIndex + 8, QtnmValidDate, new CellFormat { Border = "LTR", FontSize = 10, MergeCols = 6 });
            rightRow += 1;
            excel.CellValue(rightRow, colIndex + 6, "Type Of Move", new CellFormat { Border = "LT", FontSize = 10, MergeCols = 1 });
            excel.CellValue(rightRow, colIndex + 8, QtnmMoveType, new CellFormat { Border = "LTR", FontSize = 10, MergeCols = 6 });
            rightRow += 1;
            excel.CellValue(rightRow, colIndex + 6, "Commodity", new CellFormat { Border = "LTB", FontSize = 10, MergeCols = 1 });
            excel.CellValue(rightRow, colIndex + 8, QtnmCommodity, new CellFormat { Border = "LTRB", FontSize = 10, MergeCols = 6 });
            rightRow += 1;
            rowIndex = rightRow;

            if (!IsAttachment)
            {
                // rowIndex += 1;
                excel.CellValue(rowIndex, colIndex,"ORIGIN", new CellFormat { Style = "B", FontSize = 10, ColumnWidth = 14 });
                excel.CellValue(rowIndex, colIndex + 1,"", new CellFormat { Style = "B", FontSize = 10, ColumnWidth = 2 });
                excel.CellValue(rowIndex, colIndex + 2, "DESTINATION", new CellFormat { Style = "B", FontSize = 10, ColumnWidth = 24 });
                excel.CellValue(rowIndex, colIndex + 3, "CARRIER", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 24 });
                excel.CellValue(rowIndex, colIndex + 4, "T/T", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 14 });
                excel.CellValue(rowIndex, colIndex + 5, "MINIMUM", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 10 });
                excel.CellValue(rowIndex, colIndex + 6, "+45K", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 8 });
                excel.CellValue(rowIndex, colIndex + 7, "+100K", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 8 });
                excel.CellValue(rowIndex, colIndex + 8, "+300K", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 8 });
                excel.CellValue(rowIndex, colIndex + 9, "+500K", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 8 });
                excel.CellValue(rowIndex, colIndex + 10, "+1000k", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 8 });
                excel.CellValue(rowIndex, colIndex + 11, "FSC", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 8 });
                excel.CellValue(rowIndex, colIndex + 12, "WAR", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 8 });
                excel.CellValue(rowIndex, colIndex + 13, "SFC", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 8 });
                excel.CellValue(rowIndex, colIndex + 14, "HAC", new CellFormat { Style = "B", FontSize = 10 , ColumnWidth = 8 });

                rowIndex++;
                excel.CellValue(rowIndex, colIndex + 2, "ROUTING", new CellFormat { Style = "B", FontSize = 10});
                excel.CellValue(rowIndex++, colIndex + 3, "ETD",     new CellFormat { Style = "B", FontSize = 10 });
            }

            // rowIndex += 1;

            return rowIndex;
        }

        private int FooterPadding(int rowIndex, int colIndex, int detailCount)
        {
            int totalRemarks = RemkList.Count;

            int remainingRows = RemkMaxCount - detailCount * 2; // in details 1 entry min 2 rows

            if (remainingRows < 2 || totalRemarks == 0)
            {
                IsAttachment = totalRemarks > 0;
                return FillBlankRows(rowIndex, colIndex, remainingRows);
            }
            
            if (remainingRows == 2 && totalRemarks > 0)
            {
                IsAttachment = true;
                return FillBlankRows(rowIndex, colIndex, remainingRows);
            }

            // excel.CellValue(rowIndex, colIndex, "", new CellFormat { FontSize = 9 });
            rowIndex++;
            remainingRows--;

            excel.CellValue(rowIndex,colIndex,"REMARKS",new CellFormat { Style = "B", Border = "TB", FontSize = 9, MergeCols = col_count });
            rowIndex++;
            remainingRows--;

            int addedRemark = 0;

            for (int i = 0; i < totalRemarks && remainingRows > 0; i++)
            {
                excel.CellValue(rowIndex,colIndex,RemkList[i].remk_desc!,new CellFormat { FontSize = 9, MergeCols = col_count });
                rowIndex++;
                remainingRows--;
                addedRemark++;
            }

            if (addedRemark < totalRemarks)
            {
                IsAttachment = true;
                RemkList = RemkList.Skip(addedRemark).ToList();
            }

            return FillBlankRows(rowIndex, colIndex, remainingRows);
        }

        private int WriteFooter(int rowIndex, int colIndex)
        {
            int startRow = rowIndex;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            var footerTerms1 = "";
            var footerTerms2 = "";
            var Terms1 = CommonLib.GetBranchsettings(context!, Company_id, Branch_id, "TERMS AND SERVICE 1");
            var Terms2 = CommonLib.GetBranchsettings(context!, Company_id, Branch_id, "TERMS AND SERVICE 2");
            if (Terms1.ContainsKey("TERMS AND SERVICE 1"))
                footerTerms1 = Terms1["TERMS AND SERVICE 1"].ToString()!;
            if (Terms2.ContainsKey("TERMS AND SERVICE 2"))
                footerTerms2 = Terms2["TERMS AND SERVICE 2"].ToString()!;

            var FooterText = footerTerms1 + footerTerms2;

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name}";

            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, printInfo, new CellFormat { Border = "T", FontSize = 9, MergeCols = col_count });
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex, FooterText, new CellFormat { FontSize = 6, WrapText = true, MergeCols = 4 });
            rowIndex += 1;
            excel.SetRowBreak(rowIndex);

            return rowIndex;
        } 
        private void WriteAttachment(int rowIndex, int colIndex)
        {
            var count = 0;

            rowIndex = WriteHeader(rowIndex, colIndex);

            // rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "REMARKS", new CellFormat { Style = "B", Border = "TB", FontSize = 9, MergeCols = col_count });
            rowIndex += 1;

            foreach (var c in RemkList)
            {
                excel.CellValue(rowIndex, colIndex, c.remk_desc!, new CellFormat { FontSize = 10 });//, RowHeight = 17 
                rowIndex++;
                count++;
                if (count > 10)
                {
                    rowIndex = FillBlankRows(rowIndex, colIndex, count);
                    rowIndex += 2;                                                                  // to balance attachment with header footer
                    rowIndex = WriteFooter(rowIndex, colIndex);
                    rowIndex++;
                    rowIndex = WriteHeader(rowIndex, colIndex);
                    excel.CellValue(rowIndex, colIndex, "REMARKS", new CellFormat { Style = "B", Border = "TB", FontSize = 9, MergeCols = col_count });
                    rowIndex += 1;
                    count = 0;
                }
            }
            rowIndex = FillBlankRows(rowIndex, colIndex, count);
            rowIndex += 1;
            rowIndex = WriteFooter(rowIndex, colIndex);
            rowIndex++;
        }
        private int FillBlankRows(int rowIndex, int colIndex, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                rowIndex++;
            }
            return rowIndex;
        }
    }
}