using System;
using System.Data;
using Common.DTO.CommonShipment;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using DataBase.Pdf;
using iTextSharp.text.pdf.qrcode;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NPOI.HPSF;
using NPOI.HSSF.Record;
using NPOI.SS.Formula.Functions;
using NPOI.Util;

//Name : Sourav V
//Created Date : 14/02/2026
//Remark : this file defines functions for printing pdf

namespace CommonShipment.Printing
{
    public class ProfitReportPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<cargo_profit_dto> Dt_List { get; set; } = new List<cargo_profit_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string Name { get; set; } = "";
        public string InvMblNo { get; set; } = "";
        public string InvRefno { get; set; } = "";
        public string POL { get; set; } = "";
        public string POD { get; set; } = "";
        public decimal WT { get; set; } = 0;
        public decimal CHWT { get; set; } = 0;
        public decimal CBM { get; set; } = 0;
        public string User_name { get; set; } = "";
        public string ReportType { get; set; } = "";
        public string UnitType { get; set; } = "";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string Folderid = "";
        private string Date = "";
        private float Row = 0;
        private float Col = 0;

        private float Row_Default = 0;
        private float Col_Default = 0;
        private readonly AppDbContext _context = null!;


        private int Page_Height = 0;
        private int Detail_Height = 0;
        private int Line_Height = 0;
        private int PageNumber = 0;
        private int Row_Width = 0;
        private bool IsAttachment = false;

        private ColumnFormat Col_Date = new();
        private ColumnFormat Col_InvNo = new();
        private ColumnFormat Col_HblNo = new();
        private ColumnFormat Col_WT = new();
        private ColumnFormat Col_CBM = new(); // or CHWT both same width
        private ColumnFormat Col_CustName = new();
        private ColumnFormat Col_Inc = new();
        private ColumnFormat Col_Exp = new();
        private ColumnFormat Col_Profit = new();

        private ColumnFormat Col_label = new();
        private ColumnFormat Col_Column = new();
        private ColumnFormat Col_Head_data = new();


        public ProfitReportPdfFile()
        {
            pdf = new TextSharpPdf();
            context = _context;

        }


        public void Process()
        {
            try
            {
                FList = new List<filesm>();
                Folderid = Guid.NewGuid().ToString().ToUpper();
                File_Display_Name = Name!.ToUpper();
                File_Display_Name += ".pdf";
                File_Display_Name = Database.Lib.Lib.ProperFileName(File_Display_Name);
                File_Name = Database.Lib.Lib.GetFileName(Report_Folder, Folderid, File_Display_Name, false);
                File_Type = "PDF";
                FList.Add(Database.Lib.Lib.AddFiles(File_Name, File_Type, File_Display_Name));


                Writedocument();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void Writedocument()
        {
            this.Page_Height = 500;
            this.Detail_Height = 480;
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            this.Row_Width = 800;

            this.Col_Date = new ColumnFormat { Left = 30, Width = 70 };
            this.Col_InvNo = new ColumnFormat { Left = 100, Width = 70 };
            this.Col_HblNo = new ColumnFormat { Left = 170, Width = 90};
            this.Col_WT = new ColumnFormat { Left = 260, Width = 60};
            this.Col_CBM = new ColumnFormat { Left = 320, Width = 60};
            this.Col_CustName = new ColumnFormat { Left = 380, Width = 240};
            this.Col_Inc = new ColumnFormat { Left = 620, Width = 70};
            this.Col_Exp = new ColumnFormat { Left = 690, Width = 70};
            this.Col_Profit = new ColumnFormat { Left = 760, Width = 70};
            
            this.Col_label = new ColumnFormat { Left = 30, Width = 50 };// ':'
            this.Col_Column = new ColumnFormat { Left = 80, Width = 10 };// ':'
            this.Col_Head_data = new ColumnFormat { Left = 90, Width = 200 };

            pdf.CreateDocument(File_Name, "LANDSCAPE");
            CreateReport();
            pdf.CloseDocument();
        }
        private bool IsPageBreak(float Row, int Line_Height, int Page_Height, int detailCount)
        {
            int maxdetailCount = 14;
            bool height = (Row + Line_Height) > Page_Height;
            bool countExceeded = detailCount >= maxdetailCount;

            return height || countExceeded;
        }

        private void CreateReport()
        {

            int recordCount = Dt_List.Count;
            bool printHeader = false;
            string BL = "";
            bool isLastTwo = false;

            Row = this.Page_Height;

            Row = WriteHeader(Row_Default, Col_Default);

            int i = 0;
            int detailCount = 0;

            foreach (cargo_profit_dto dr in Dt_List)
            {
                i++;
                printHeader = IsPageBreak(Row, Line_Height, Detail_Height,detailCount);
                isLastTwo = (i == recordCount-1 || i == recordCount); // last 2 line is always Summary( Total/ Profit)
                BL = isLastTwo ? "TB" : "b";
                var ST = isLastTwo ? "B" : "";

                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };
                if (printHeader)
                {
                    WriteFooter(Row, Col_Default);
                    Row = WriteHeader(Row_Default, Col_Default);                        

                    detailCount = 0;
                }
                var inv_date = Lib.FormatDate(Lib.ParseDate(dr.inv_date!), Lib.DisplayDateFormat) ?? "";

                float CustNameHeight = pdf.MeasureWrappedTextHeight(Row, Col_CustName.Left, Col_CustName.Width, Line_Height, dr.inv_cust_name!, format);
                float HouseNoHeight = pdf.MeasureWrappedTextHeight(Row, Col_HblNo.Left, Col_HblNo.Width, Line_Height, dr.inv_houseno!, format);

                float rowHeight = new[] { CustNameHeight, HouseNoHeight }.Max();//RemkHeight,
               
                pdf.AddText(Row, Col_Date.Left, Col_Date.Width, rowHeight, inv_date.ToUpper(), new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                if(ReportType == "INVOICE WISE")
                    pdf.AddText(Row, Col_InvNo.Left, Col_InvNo.Width, rowHeight, dr.inv_no!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                if(ReportType == "HOUSE WISE")
                    pdf.AddText(Row, Col_InvNo.Left, Col_InvNo.Width, rowHeight, dr.inv_mbl_refno!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_HblNo.Left, Col_HblNo.Width, rowHeight, dr.inv_houseno!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_WT.Left, Col_WT.Width, rowHeight, dr.inv_wt!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_CBM.Left, Col_CBM.Width, rowHeight, dr.inv_cbm!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_CustName.Left, Col_CustName.Width, rowHeight, dr.inv_cust_name!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Inc.Left, Col_Inc.Width, rowHeight, dr.inv_inc_total!, new TextFormat { Border = "" + BL, Style = "R" + ST,FontSize = 9 });
                pdf.AddText(Row, Col_Exp.Left, Col_Exp.Width, rowHeight, dr.inv_exp_total!, new TextFormat { Border = "" + BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Profit.Left, Col_Profit.Width, rowHeight, dr.inv_profit!, new TextFormat { Border = "" + BL, Style = "R" +ST, FontSize = 9, Indent = true });
                
                if(recordCount>i)
                    Row += rowHeight;

                detailCount++;
            }

            WriteFooter(Row, Col_Default);

        }

        private float WriteHeader(float _Row, float _Col)
        {
            Row = _Row;
            Col = _Col;

            pdf.AddNewPage();
            PageNumber++;

            float currentY = CommonLib.WriteBranchAddressPdf(Row, Col, Company_id, Branch_id, context!, pdf);

            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, Title.ToUpper() , new TextFormat { Border = "TB", Style = "CB", FontSize = 10 });
            currentY += Line_Height + 5;
            
            int halfWidth = Row_Width / 2;
            int valueWidth = halfWidth / 2;
            float rightColX = Col + halfWidth + 50;

            float _currentY = currentY;
        
            if(!IsAttachment)
            {
                _currentY = currentY;
                pdf.AddText(_currentY, Col, Col_label.Width , Line_Height, "REF #", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, InvRefno, new TextFormat { Style = "B", FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, Col, Col_label.Width , Line_Height, "MASTER", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, InvMblNo, new TextFormat { Style = "B", FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, Col, Col_label.Width , Line_Height, "POL", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, POL, new TextFormat { Style = "B", FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, Col, Col_label.Width , Line_Height, "POD", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, POD, new TextFormat { Style = "B", FontSize = 10 });

                _currentY = currentY;
                pdf.AddText(_currentY, rightColX, Col_label.Width, Line_Height, "TYPE", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, rightColX + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                if(ReportType == "INVOICE WISE")
                    pdf.AddText(_currentY, rightColX + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ReportType, new TextFormat { Style = "B", FontSize = 10 });
                if(ReportType == "HOUSE WISE")
                    pdf.AddText(_currentY, rightColX + Col_Head_data.Left, Col_Head_data.Width, Line_Height,  $"{ReportType} ({UnitType})", new TextFormat { Style = "B", FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, rightColX, Col_label.Width, Line_Height, "WT", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, rightColX + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, rightColX + Col_Head_data.Left, Col_Head_data.Width, Line_Height, WT, new TextFormat { Style = "B", FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, rightColX, Col_label.Width, Line_Height, "CH.WT", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, rightColX + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, rightColX + Col_Head_data.Left, Col_Head_data.Width, Line_Height, CHWT, new TextFormat { Style = "B", FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, rightColX, Col_label.Width, Line_Height, "CBM", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, rightColX + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(_currentY, rightColX + Col_Head_data.Left, Col_Head_data.Width, Line_Height, CBM, new TextFormat { Style = "B", FontSize = 10 });
                
                currentY += Line_Height * 3;

                pdf.AddText(currentY, Col, Row_Width, Line_Height, "", new TextFormat { Border = "B",FontSize = 10 });
                currentY += Line_Height + 5;

                pdf.AddText(currentY, Col_Date.Left, Col_Date.Width, Line_Height, "DATE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                if(ReportType == "INVOICE WISE")
                    pdf.AddText(currentY, Col_InvNo.Left, Col_InvNo.Width, Line_Height, "INVOICE #", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                if(ReportType == "HOUSE WISE")
                    pdf.AddText(currentY, Col_InvNo.Left, Col_InvNo.Width, Line_Height, "REF #", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_HblNo.Left, Col_HblNo.Width, Line_Height, "HOUSE NO", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_WT.Left, Col_WT.Width, Line_Height, "WEIGHT", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_CBM.Left, Col_CBM.Width, Line_Height, "CBM", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_CustName.Left, Col_CustName.Width, Line_Height, "CUSTOMER", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Inc.Left, Col_Inc.Width, Line_Height, "REVENUE", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Exp.Left, Col_Exp.Width, Line_Height, "EXPENSE", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Profit.Left, Col_Profit.Width, Line_Height, "PROFIT", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });

                currentY += Line_Height;
            }

            return currentY;
        }
        private void WriteFooter(float _Row, float _Col)
        {
            Row = _Row; 
            Col = _Col;
            
            int halfWidth = Row_Width / 2;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name}";//

            
            Row = 485;//for footer print details(fixed)
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, printInfo, new TextFormat { Border="T", FontSize = 9 });
            pdf.AddText(Row + Line_Height, Col_Default, Row_Width, Line_Height,$"PAGE#: {PageNumber}" , new TextFormat { Border="", FontSize = 9 });
            Row += Line_Height;
            
            // return currentY;
        }
    }
}
