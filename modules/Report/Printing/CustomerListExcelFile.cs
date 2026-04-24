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
    public class CustomerListExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<rep_customerlist_dto> Dt_List { get; set; } = new List<rep_customerlist_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string CustName { get; set; } = "";
        public string CustType { get; set; } = "";
        public string CustFormat { get; set; } = "";
        public bool IsStandard { get; set; } = false;
        public bool IsCredit { get; set; } = false;
        public string User_name { get; set; } = "";
    

        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private int col_count = 13; // Column count set Title border
        private int PageNumber = 0;

        public CustomerListExcelFile()
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
        private void CreateExcelData()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int count = 0;
            IsStandard = CustFormat == "STANDARD";
            IsCredit = CustFormat == "CREDIT/SPECIAL ACCOUNT";
            
            rowIndex = WriteHeader(rowIndex, colIndex);

            foreach (rep_customerlist_dto dr in Dt_List)
            {
                excel.CellValue(rowIndex, colIndex + 0, Lib.FormatDate(Lib.ParseDate(dr.rec_created_date!), Lib.DisplayDateFormat).ToUpper(), new CellFormat { Border = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 1, dr.cust_name!, new CellFormat { Border = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 2, dr.cust_address1!, new CellFormat { Border = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 4, dr.cust_address2!, new CellFormat { Border = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 5, dr.cust_address3!, new CellFormat { Border = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 6, dr.cust_type!, new CellFormat { Border = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 7, dr.cust_contact!, new CellFormat { Border = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 8, dr.cust_tel!, new CellFormat { Border = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 9, dr.cust_mobile!, new CellFormat { Border = "", FontSize = 9 });
                excel.CellValue(rowIndex, colIndex + 10, dr.cust_email!, new CellFormat { Border = "", FontSize = 9 });
                if (IsStandard)
                {
                    excel.CellValue(rowIndex, colIndex + 11, dr.cust_city!, new CellFormat { Border = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 12, dr.cust_state_name!, new CellFormat { Border = "", FontSize = 9 });
                    excel.CellValue(rowIndex ++, colIndex + 13, dr.cust_country_name!, new CellFormat { Border = "", FontSize = 9 });
                }
                if (IsCredit)
                {
                    excel.CellValue(rowIndex, colIndex + 11, dr.cust_is_splacc!, new CellFormat { Border = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 12, dr.cust_days!, new CellFormat { Border = "", FontSize = 9 });
                    excel.CellValue(rowIndex ++, colIndex + 13, dr.cust_splacc_memo!, new CellFormat { Border = "", FontSize = 9 });
                }
                count ++;
            }

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

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? ""; // convert string date into dd-mmm-yyyy fromat
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, Title.ToUpper() , new CellFormat { Border = "TB", Style = "B", ColumnWidth = 10, FontSize = 11, MergeCols = col_count});
            rowIndex += 1;

            SetDefaultColumWidth( rowIndex, colIndex);// set column width after title

            excel.CellValue(rowIndex, colIndex, "FROM DATE :" , new CellFormat { Style = "B", FontSize = 10});
            excel.CellValue(rowIndex, colIndex + 1, SFromDate.ToUpper() , new CellFormat { Style = "B", FontSize = 10});
            excel.CellValue(rowIndex, colIndex + 2, "NAME :", new CellFormat { Style = "B", FontSize = 10});
            excel.CellValue(rowIndex, colIndex + 3, CustName , new CellFormat { Style = "B", FontSize = 10});
            rowIndex += 1;
            
            excel.CellValue(rowIndex, colIndex + 0, "TO DATE :", new CellFormat { Style = "B", FontSize = 10});
            excel.CellValue(rowIndex, colIndex + 1, SToDate.ToUpper() , new CellFormat { Style = "B", FontSize = 10});
            if (IsStandard)
            {
                excel.CellValue(rowIndex, colIndex + 2, "CATOGERY :" , new CellFormat { Style = "B", FontSize = 10});
                excel.CellValue(rowIndex, colIndex + 3, CustType , new CellFormat { Style = "B", FontSize = 10});
            }
            if (IsCredit)
            {
                excel.CellValue(rowIndex, colIndex + 2, "FORMAT :" , new CellFormat { Style = "B", FontSize = 10});
                excel.CellValue(rowIndex, colIndex + 3, CustFormat , new CellFormat { Style = "B", FontSize = 10});
            }
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex + 0, "DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, "NAME", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 2, "ADDRESS1", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, "ADDRESS2", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 5, "ADDRESS3", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 6, "CATEGORY", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 7, "CONTACT", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 8, "TEL", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 9, "MOBILE", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 10, "EMAIL", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            if (IsStandard)
            {
                excel.CellValue(rowIndex, colIndex + 11, "CITY", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
                excel.CellValue(rowIndex, colIndex + 12, "STATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
                excel.CellValue(rowIndex, colIndex + 13, "COUNTRY", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            }
            if (IsCredit)
            {
                excel.CellValue(rowIndex, colIndex + 11, "CREDIT/SPECIAL.A/C", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
                excel.CellValue(rowIndex, colIndex + 12, "CREDIT DAYS", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
                excel.CellValue(rowIndex, colIndex + 13, "MEMO", new CellFormat { Border = "TB", Style = "B", FontSize = 10 });
            }

 
            rowIndex += 1;
            return rowIndex;
        }
        private void SetDefaultColumWidth(int rowIndex, int colIndex)
        {
            excel.CellValue(rowIndex, colIndex + 0, "", new CellFormat { ColumnWidth = 10 }); //var A = 0;//A
            excel.CellValue(rowIndex, colIndex + 1, "", new CellFormat { ColumnWidth = 40 }); //var B = 1;//B
            excel.CellValue(rowIndex, colIndex + 2, "", new CellFormat { ColumnWidth = 10 }); //var C = 2;//C
            excel.CellValue(rowIndex, colIndex + 3, "", new CellFormat { ColumnWidth = 30 }); //var D = 3;//D
            excel.CellValue(rowIndex, colIndex + 4, "", new CellFormat { ColumnWidth = 40 }); //var E = 4;//E
            excel.CellValue(rowIndex, colIndex + 5, "", new CellFormat { ColumnWidth = 40 }); //var F = 5;//F
            excel.CellValue(rowIndex, colIndex + 6, "", new CellFormat { ColumnWidth = 10 }); //var G = 6;//G
            excel.CellValue(rowIndex, colIndex + 7, "", new CellFormat { ColumnWidth = 15 }); //var H = 7;//H
            excel.CellValue(rowIndex, colIndex + 8, "", new CellFormat { ColumnWidth = 12 }); //var I = 8;//I
            excel.CellValue(rowIndex, colIndex + 9, "", new CellFormat { ColumnWidth = 12 }); //var J = 9;//J
            excel.CellValue(rowIndex, colIndex + 10, "", new CellFormat { ColumnWidth = 20 }); //var K = 10;//K
            excel.CellValue(rowIndex, colIndex + 11, "", new CellFormat { ColumnWidth = 15 }); //var L = 11;//L
            excel.CellValue(rowIndex, colIndex + 12, "", new CellFormat { ColumnWidth = 15 }); //var M = 12;//M
            excel.CellValue(rowIndex, colIndex + 13, "", new CellFormat { ColumnWidth = 20 }); //var N = 13;//N
        }
    }
}