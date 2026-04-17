using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.Accounts;
using Common.DTO.OtherOp;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Masters.Interfaces;
using NPOI.HSSF.Record;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;

namespace Marketing.Printing
{
    public class ProcessInvExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<acc_invoiced_dto> Dt_List { get; set; } = new List<acc_invoiced_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string Name { get; set; } = "";
        public string InvoiceNo { get; set; } = "";
        public string InvoiceDate { get; set; } = "";
        public string InvType { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string CustAddress1 { get; set; } = "";
        public string CustAddress2 { get; set; } = "";
        public string CustAddress3 { get; set; } = "";
        public string CustomerReference { get; set; } = "";
        public string OurReference { get; set; } = "";
        public string InvMblNo { get; set; } = "";
        public string InvHblNo { get; set; } = "";
        public string InvPcs { get; set; } = "";
        public string InvUnit { get; set; } = "";
        public string InvLBS { get; set; } = "";
        public string InvKGS { get; set; } = "";
        public string InvShipper { get; set; } = "";
        public string InvConsignee { get; set; } = "";
        public string POL { get; set; } = "";
        public string POD { get; set; } = "";
        public string InvRemk1 { get; set; } = "";
        public string InvRemk2 { get; set; } = "";
        public string InvRemk3 { get; set; } = "";
        public string Handledby { get; set; } = "";
        public string InvTotal { get; set; } = "";
        public string InvPaid { get; set; } = "";
        public string InvCurCode { get; set; } = "";
        public string User_name { get; set; } = "";
        public string InvTerms1 { get; set; } = "";
        public string InvTerms2 { get; set; } = "";
        public bool NextPage { get; set; } = false;
        public List<cargo_container_dto> ContainerList { get; set; } = new();


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private bool IsAttachment = false;
        private int MaxCount = 14;

        public ProcessInvExcelFile()
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
            string BL = "";
            var recordCount = Dt_List.Count;
            int i = 0;
            int count = 0;
            rowIndex = WriteHeader(rowIndex, colIndex);

            foreach (acc_invoiced_dto dr in Dt_List)
            {
                i++;
                BL = CommonLib.IsLastRow(i, recordCount);
                BL = count == MaxCount - 1 ? "B" : BL;
                if (IsPageBreak(count))
                {
                    NextPage = true;
                    rowIndex = WriteDetailSummary(rowIndex, colIndex, count);
                    rowIndex = WriteFooter(rowIndex, colIndex);
                    rowIndex += 1;
                    excel.SetRowBreak(rowIndex);
                    rowIndex += 1;
                    rowIndex = WriteHeader(rowIndex, colIndex);
                    count = 0;
                }
                NextPage = false;
                excel.CellValue(rowIndex, colIndex, dr.invd_acc_name!, new CellFormat { Border = "T" + BL, FontSize = 9, MergeCols = 2});//, RowHeight = 20
                excel.CellValue(rowIndex, colIndex + 3, dr.invd_remarks!, new CellFormat { Border = "T" + BL, FontSize = 9, MergeCols = 3});//, RowHeight = 20 
                excel.CellValue(rowIndex++, colIndex + 7, dr.invd_total!, new CellFormat { Border = "LT" + BL, FontSize = 9, HAlign = "R"});//, RowHeight = 20 
                count++;

            }
            rowIndex = WriteDetailSummary(rowIndex, colIndex, count);
            rowIndex = WriteFooter(rowIndex, colIndex);
            rowIndex += 1;
            excel.SetRowBreak(rowIndex);

            if (ContainerList.Count > 4)
            {
                IsAttachment = true;
                rowIndex += 1;
                WriteAttachment(rowIndex, colIndex);
            }

            excel.SetColumnBreak(colIndex + 7);// mac possible column
            excel.Save(File_Name);
        }

        private int WriteHeader(int rowIndex, int colIndex)
        {
            var custLabel = "";
            int col_count = 7;
            
            if (rowIndex == 0)
            {
                excel.CreateSheet("Sheet1");
            }
                
            excel.PrintGridlines(false);// for no grid lines


            if (InvType == "A/R")
            {
                Title = "INVOICE";
                custLabel = "BILL TO";
            }
            if (InvType == "A/P")
            {
                Title = "CREDIT NOTE";
                custLabel = "PAY TO";
            }

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex, Title, new CellFormat { Border = "TB", Style = "B", HAlign = "C", FontSize = 11, ColumnWidth = 12, MergeCols = col_count });
            rowIndex += 1;

            SetDefaultColumnWidths( rowIndex, 0);

            var leftRow = rowIndex + 1;
            excel.CellValue(leftRow, colIndex + 0, custLabel, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(leftRow, colIndex + 1, ":", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(leftRow, colIndex + 2, CustomerName, new CellFormat { FontSize = 10 });
            leftRow += 1;
            excel.CellValue(leftRow, colIndex + 2, CustAddress1, new CellFormat { FontSize = 10 });//ColumnWidth = 35
            leftRow += 1;
            excel.CellValue(leftRow, colIndex + 2, CustAddress2, new CellFormat { FontSize = 10 });//ColumnWidth = 20
            leftRow += 1;
            excel.CellValue(leftRow++, colIndex + 2, CustAddress3, new CellFormat { FontSize = 10 });

            var rightRow = rowIndex + 2;

            excel.CellValue(rightRow, colIndex + 5, "INVOICE NO", new CellFormat { Border = "LT", FontSize = 10, HAlign="R"});
            excel.CellValue(rightRow, colIndex + 6, "", new CellFormat { Border = "T", FontSize = 10 });
            excel.CellValue(rightRow, colIndex + 7, InvoiceNo, new CellFormat { Border = "LTR", FontSize = 10 });
            rightRow += 1;
            excel.CellValue(rightRow, colIndex + 5, "INVOICE DATE", new CellFormat { Border = "LT", FontSize = 10, HAlign="R"});
            excel.CellValue(rightRow, colIndex + 6, "", new CellFormat { Border = "T", FontSize = 10 });
            excel.CellValue(rightRow, colIndex + 7, InvoiceDate, new CellFormat { Border = "LTR", FontSize = 10 });
            rightRow += 1;
            excel.CellValue(rightRow, colIndex + 5, "YOUR REFERENCE", new CellFormat { Border = "LT", FontSize = 10, HAlign="R"});
            excel.CellValue(rightRow, colIndex + 6, "", new CellFormat { Border = "T", FontSize = 10 });
            excel.CellValue(rightRow, colIndex + 7, CustomerReference, new CellFormat { Border = "LTR", FontSize = 10, });
            rightRow += 1;
            excel.CellValue(rightRow, colIndex + 5, "OUR REFERENCE", new CellFormat { Border = "LTB", FontSize = 10, HAlign="R"});
            excel.CellValue(rightRow, colIndex + 6, "", new CellFormat { Border = "TB", FontSize = 10 });
            excel.CellValue(rightRow, colIndex + 7, OurReference, new CellFormat { Border = "LTRB", FontSize = 10 });
            rightRow += 1;
            // excel.SetRowHeight(rightRow, 10);
            excel.CellValue(rightRow, colIndex, "", new CellFormat { Border = "B", FontSize = 10, MergeCols = 7 });
            rightRow += 1;
            // excel.SetRowHeight(rightRow, 10);
            rightRow += 1;
            rowIndex = rightRow;

            leftRow = rowIndex;
            if (!IsAttachment)
            {
                excel.CellValue(leftRow, colIndex + 0, "MBL NO", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 1, ":", new CellFormat { FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 2, InvMblNo, new CellFormat { FontSize = 10 });
                leftRow += 1;

                excel.CellValue(leftRow, colIndex + 0, "HBL NO", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 1, ":", new CellFormat { FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 2, InvHblNo, new CellFormat { FontSize = 10 });
                leftRow += 1;

                excel.CellValue(leftRow, colIndex + 0, "PIECE", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 1, ":", new CellFormat { FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 2, $"{InvPcs} {InvUnit}", new CellFormat { FontSize = 10 });
                leftRow += 1;

                excel.CellValue(leftRow, colIndex + 0, "WEIGHT", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 1, ":", new CellFormat { FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 2, $"{InvLBS} LBS / {InvKGS} KGS", new CellFormat { FontSize = 10 });
                leftRow += 1;

                excel.CellValue(leftRow, colIndex + 0, "SHIPPER", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 1, ":", new CellFormat { FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 2, InvShipper, new CellFormat { FontSize = 10 });
                leftRow += 1;

                excel.CellValue(leftRow, colIndex + 0, "CONSIGNEE", new CellFormat { Style="B", FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 1, ":", new CellFormat { FontSize = 10 });
                excel.CellValue(leftRow, colIndex + 2, InvConsignee, new CellFormat { FontSize = 10 });

                leftRow += 1;
                // var temp = leftRow;
                rightRow = rowIndex;

                excel.CellValue(rightRow, colIndex + 5, "LOAD PORT", new CellFormat { Style="B", FontSize = 10, HAlign="R"});
                excel.CellValue(rightRow, colIndex + 6, ":", new CellFormat { FontSize = 10 });
                excel.CellValue(rightRow, colIndex + 7, POL, new CellFormat { FontSize = 10 });
                rightRow += 1;

                excel.CellValue(rightRow, colIndex + 5, "DISCHARGE PORT", new CellFormat { Style="B", FontSize = 10, HAlign="R"});
                excel.CellValue(rightRow, colIndex + 6, ":", new CellFormat { FontSize = 10 });
                excel.CellValue(rightRow, colIndex + 7, POD, new CellFormat { FontSize = 10 });
                rightRow += 1;

                excel.CellValue(rightRow, colIndex + 5, "CONTAINER #", new CellFormat { Style="B", FontSize = 10, HAlign="R"});
                excel.CellValue(rightRow, colIndex + 6, ":", new CellFormat { FontSize = 10 });

                if (ContainerList.Count > 4)
                {
                    excel.CellValue(rightRow, colIndex + 7, "SEE ATTACHED LIST", new CellFormat { Style = "B", FontSize = 10 });
                    rightRow++;
                }
                else
                {
                    foreach (var c in ContainerList)
                    {
                        string line = $"{c.cntr_no}     {c.cntr_type_name}";
                        excel.CellValue(rightRow, colIndex + 7, line, new CellFormat { FontSize = 10 });
                        rightRow++;
                    }
                }
                rowIndex = leftRow;
                rowIndex += 1;
                excel.CellValue(rowIndex, colIndex, "", new CellFormat { Border = "TB", FontSize = 10, MergeCols = 7 });
                // excel.SetRowHeight(rowIndex, 10);
                rowIndex += 1;
                excel.CellValue(rowIndex, colIndex, "DESCRIPTION OF CHARGES", new CellFormat { Border = "T", Style = "B", FontSize = 10, MergeCols = 6, RowHeight = 20 });
                excel.CellValue(rowIndex, colIndex + 7, "AMOUNT", new CellFormat { Border = "LT", Style = "B", FontSize = 10, HAlign = "R", RowHeight = 20 });
                rowIndex += 1;
            }
            return rowIndex;
        }

        private int WriteDetailSummary(int rowIndex, int colIndex, int detailCount)
        {
            decimal InvBalance = decimal.Parse(InvTotal) - decimal.Parse(InvPaid);
            
            int rowsToFill = MaxCount - detailCount;

            if (rowsToFill > 0)
            {
                for (int i = 1; i <= rowsToFill; i++)
                {
                    var BL = i == rowsToFill ? "B" : "";
                    excel.CellValue(rowIndex, colIndex, "", new CellFormat { Border = "" + BL, FontSize = 9, MergeCols = 2 });//, RowHeight = 20
                    excel.CellValue(rowIndex, colIndex + 3, "", new CellFormat { Border = "" + BL, FontSize = 9, MergeCols = 3});
                    excel.CellValue(rowIndex, colIndex + 7, "", new CellFormat { Border = "L" + BL, FontSize = 9, HAlign = "R"});
                    rowIndex += 1;
                }
            }

            if (NextPage)
            {
                // rowIndex += 25;
                excel.CellValue(rowIndex, colIndex + 5, "CONTINUE ON NEXT PAGE", new CellFormat { Style = "B", FontSize = 10, HAlign = "R" });
                excel.CellValue(rowIndex, colIndex + 7, "", new CellFormat { Border = "L", FontSize = 10, HAlign = "R" });
                rowIndex += 1;
                excel.CellValue(rowIndex, colIndex + 7, "", new CellFormat { Border = "L", FontSize = 10, HAlign = "R" });
                rowIndex += 1;
                excel.CellValue(rowIndex, colIndex + 7, "", new CellFormat { Border = "L", FontSize = 10, HAlign = "R" });
                rowIndex += 1;
            }
            else
            {
                // rowIndex += 25;
                excel.CellValue(rowIndex, colIndex + 5, "TOTAL", new CellFormat { Style = "B", FontSize = 10, HAlign = "R" });
                excel.CellValue(rowIndex, colIndex + 7, InvTotal.ToString(), new CellFormat { Style = "B", Border = "L", FontSize = 10, HAlign = "R" });
                rowIndex += 1;

                excel.CellValue(rowIndex, colIndex + 5, "PAID", new CellFormat { Style = "B", FontSize = 10, HAlign = "R" });
                excel.CellValue(rowIndex, colIndex + 7, InvPaid.ToString(), new CellFormat { Style = "B", Border = "L", FontSize = 10, HAlign = "R" });
                rowIndex += 1;

                excel.CellValue(rowIndex, colIndex + 5, $"BALANCE ({InvCurCode})", new CellFormat { Style = "B", FontSize = 10, HAlign = "R" });
                excel.CellValue(rowIndex, colIndex + 7, InvBalance.ToString() , new CellFormat { Style = "B", Border = "L", FontSize = 10, HAlign = "R" });
                rowIndex += 1;
            }

            // Add a top border after this section
            excel.CellValue(rowIndex, colIndex, "", new CellFormat { Border = "TB", MergeCols = 7 });//RowHeight = 10,
            rowIndex += 1;

            return rowIndex;
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

            if (!IsAttachment)
            {
                excel.CellValue(rowIndex, colIndex, "", new CellFormat { FontSize = 10});//, RowHeight = 10
                rowIndex += 1;
                excel.CellValue(rowIndex, colIndex, "REMARK", new CellFormat { FontSize = 10, Style = "B" });
                excel.CellValue(rowIndex, colIndex + 1, ":", new CellFormat { FontSize = 10, Style = "B" });
                excel.CellValue(rowIndex, colIndex + 2, InvRemk1, new CellFormat { FontSize = 10 });
                rowIndex += 1;

                excel.CellValue(rowIndex, colIndex + 2, InvRemk2, new CellFormat { FontSize = 10 });
                rowIndex += 1;

                excel.CellValue(rowIndex, colIndex + 2, InvRemk3, new CellFormat { FontSize = 10 });
                rowIndex += 1;
                // excel.CellValue(rowIndex, colIndex, "", new CellFormat { FontSize = 10, RowHeight = 10});
                // excel.SetRowHeight(rowIndex, 10);
                rowIndex += 1;
                var CurrentRow = rowIndex;

                if (InvType == "A/R")
                {
                    var Address = CommonLib.GetBranchAddress(context!, Company_id, Branch_id);
                    if (Address == null)
                        throw new Exception("Address not found!");

                    excel.CellValue(CurrentRow, colIndex, "REMIT TO", new CellFormat { FontSize = 10, Style = "B" });
                    excel.CellValue(CurrentRow, colIndex + 1, ":", new CellFormat { FontSize = 10, Style = "B" });
                    excel.CellValue(CurrentRow, colIndex + 2, Address!.Name!, new CellFormat { FontSize = 10, Style = "B" });
                    CurrentRow += 1;

                    if (!Lib.IsBlank(Address.Address1))
                    {
                        excel.CellValue(CurrentRow, colIndex + 2, Address.Address1!, new CellFormat { FontSize = 10 });
                        CurrentRow += 1;
                    }
                    if (!Lib.IsBlank(Address.Address2))
                    {
                        excel.CellValue(CurrentRow, colIndex + 2, Address.Address2!, new CellFormat { FontSize = 10 });
                        CurrentRow += 1;
                    }
                    if (!Lib.IsBlank(Address.Address3))
                    {
                        excel.CellValue(CurrentRow, colIndex + 2, Address.Address3!, new CellFormat { FontSize = 10 });
                        CurrentRow += 1;
                    }
                }

                excel.CellValue(rowIndex, colIndex + 7, "Thank you for Your Patronage", new CellFormat { Style = "B", FontSize = 10 });
                rowIndex += 1;

                excel.CellValue(rowIndex, colIndex + 7, "Handled By : " + Handledby, new CellFormat { FontSize = 10 });
                rowIndex += 1;

                if (InvType == "A/R")
                {
                    excel.CellValue(rowIndex, colIndex, "", new CellFormat { FontSize = 10});//,RowHeight = 10
                    CurrentRow += 1;
                    excel.CellValue(CurrentRow, colIndex, "TERMS", new CellFormat { Style = "B", FontSize = 10 });//: 
                    excel.CellValue(CurrentRow, colIndex + 1, ":", new CellFormat { Style = "B", FontSize = 10 });
                    excel.CellValue(CurrentRow, colIndex + 2, "PAYABLE UPON RECEIPT IN " + InvCurCode, new CellFormat { Style = "B", FontSize = 10 });
                    rowIndex = CurrentRow + 1;
                }
                else if (InvType == "A/P")
                {
                    InvTerms1 = "Please confirm the above amount within 7 days from the invoice date.";
                    InvTerms2 = "Anything after will be considered as final confirmation.";

                    excel.CellValue(CurrentRow, colIndex, "TERMS", new CellFormat { Style = "B", FontSize = 10 });//: 
                    excel.CellValue(CurrentRow, colIndex + 1, ":", new CellFormat { Style = "B", FontSize = 10 });
                    excel.CellValue(CurrentRow, colIndex + 2, "PAYABLE IN " + InvCurCode, new CellFormat { Style = "B", FontSize = 10 });
                    CurrentRow += 2;
                    // excel.SetRowHeight(CurrentRow, 10);
                    excel.CellValue(CurrentRow, colIndex, InvTerms1, new CellFormat { FontSize = 9, Style = "B", });
                    CurrentRow += 1;
                    excel.CellValue(CurrentRow, colIndex, InvTerms2, new CellFormat { FontSize = 9, Style = "B", });
                    rowIndex += 4;
                }
                // excel.SetRowHeight(rowIndex, 10);
                rowIndex += 1;
            }
            excel.CellValue(rowIndex, colIndex, printInfo, new CellFormat { Border = "T", FontSize = 9, MergeCols = 7 });
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex, FooterText, new CellFormat { FontSize = 6, WrapText = true, MergeCols = 4 });
            // rowIndex += 1;

            return rowIndex;
        }
        private int AttachmentFooterPadding(int rowIndex, int colIndex, int count)
        {
            int PAGE_HEIGHT = MaxCount + 24;// adjust to match your detail page height(24 rows are )
            int rowsToFill = PAGE_HEIGHT - count;

            for (int i = 0; i < rowsToFill; i++)
            {
                excel.CellValue(rowIndex, colIndex, "",new CellFormat { FontSize = 9});//, RowHeight = 17
                rowIndex++;
            }

            return rowIndex;
        }
        private void WriteAttachment(int rowIndex, int colIndex)
        {
            var count = 0;

            rowIndex = WriteHeader(rowIndex, colIndex);

            excel.CellValue(rowIndex, colIndex, "CONTAINER #", new CellFormat { Style ="B", Border = "TB", FontSize = 9, MergeCols = 7, RowHeight = 20 });
            rowIndex += 1;
            
            foreach (var c in ContainerList)
            {
                excel.CellValue(rowIndex, colIndex, c.cntr_no!, new CellFormat { FontSize = 10});//, RowHeight = 17 
                excel.CellValue(rowIndex, colIndex + 2, c.cntr_type_name!, new CellFormat { FontSize = 10 });//, RowHeight = 17
                rowIndex++;
                count++;
                if(count > 38)
                {
                    rowIndex = AttachmentFooterPadding(rowIndex, colIndex, count);
                    rowIndex = WriteFooter(rowIndex, colIndex);
                    rowIndex++;
                    excel.SetRowBreak(rowIndex);
                    rowIndex++;
                    rowIndex = WriteHeader(rowIndex, colIndex);
                    excel.CellValue(rowIndex, colIndex, "CONTAINER #", new CellFormat { Style ="B", Border = "TB", FontSize = 9, MergeCols = 7, RowHeight = 20 });
                    rowIndex += 1;
                    count = 0;
                }
            }
            rowIndex = AttachmentFooterPadding(rowIndex, colIndex, count);
            rowIndex = WriteFooter(rowIndex, colIndex);
            rowIndex++;
        }
        private void SetDefaultColumnWidths(int rowIndex, int colIndex)
        {
            // excel.CellValue(rowIndex, colIndex, "", new CellFormat { ColumnWidth = 12 }); //var A = 0;//A
            excel.CellValue(rowIndex, colIndex + 1, "", new CellFormat { ColumnWidth = 2 }); //var B = 1;//B
            excel.CellValue(rowIndex, colIndex + 2, "", new CellFormat { ColumnWidth = 30 }); //var C = 2;//C
            excel.CellValue(rowIndex, colIndex + 3, "", new CellFormat { ColumnWidth = 17 }); //var D = 3;//D
            excel.CellValue(rowIndex, colIndex + 4, "", new CellFormat { ColumnWidth = 15 }); //var E = 4;//E
            excel.CellValue(rowIndex, colIndex + 5, "", new CellFormat { ColumnWidth = 15 }); //var F = 5;//F
            excel.CellValue(rowIndex, colIndex + 6, "", new CellFormat { ColumnWidth = 2 }); //var G = 6;//G
            excel.CellValue(rowIndex, colIndex + 7, "", new CellFormat { ColumnWidth = 30 }); //var H = 7;//H
        }
    }
}