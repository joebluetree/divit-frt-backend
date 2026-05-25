using System;
using System.Data;
using Common.DTO.Report;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using DataBase.Pdf;
using iTextSharp.text.pdf.qrcode;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NPOI.HPSF;
using NPOI.SS.Formula.Functions;

namespace Report.Printing
{
    public class ShipmentClosePdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
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
        private string Folderid = "";
        private string Date = "";
        private float Row = 0;
        private float Col = 0;

        private float Row_Default = 0;
        private float Col_Default = 0;
        private readonly AppDbContext _context = null!;


        private int Page_Height = 0;
        private int MaxRec_Height = 0;
        private int Line_Height = 0;
        private int PageNumber = 0;
        private int Row_Width = 0;

        private ColumnFormat Col_Refno = new();
        private ColumnFormat Col_RefDate = new();
        private ColumnFormat Col_Lock = new();
        private ColumnFormat Col_ProfitMet = new();
        private ColumnFormat Col_LossApprv = new();
        private ColumnFormat Col_Memo = new();
        private ColumnFormat Col_Profit = new();
        
        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header
        


        public ShipmentClosePdfFile()
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
                File_Display_Name = Title!;
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
            this.Page_Height = 800;
            this.MaxRec_Height = 770;
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            this.Row_Width = 500;

            this.Col_Refno = new ColumnFormat { Left = 30, Width = 65 };
            this.Col_RefDate = new ColumnFormat { Left = 95, Width = 60};
            this.Col_Lock = new ColumnFormat { Left = 155, Width = 45 };
            this.Col_ProfitMet = new ColumnFormat { Left = 200, Width = 70};
            this.Col_LossApprv = new ColumnFormat { Left = 270, Width = 90 };
            this.Col_Memo = new ColumnFormat { Left = 360, Width = 110 };
            this.Col_Profit = new ColumnFormat { Left = 470, Width = 60};

            this.Col_Column = new ColumnFormat { Left = 80, Width = 10 };// ':'
            this.Col_Head_data = new ColumnFormat { Left = 90, Width = 100 };

            pdf.CreateDocument(File_Name);
            CreateReport();
            pdf.CloseDocument();
        }

        private void CreateReport()
        {

            int recordCount = Dt_List.Count;
            bool printHeader = false;

            Row = this.Page_Height;

            Row = WriteHeader(Row_Default, Col_Default);


            int i = 0;

            foreach (rep_shipmentclose_dto dr in Dt_List)
            {
                i++;
                printHeader = CommonLib.IsPageBreak(Row, Line_Height, MaxRec_Height);

                var format = new TextFormat
                {
                    Border = "b",
                    FontSize = 9,
                    Style = "",
                    Indent = true
                };


                var mbl_date = Lib.FormatDate(Lib.ParseDate(dr.mbl_ref_date!), Lib.DisplayDateFormat) ?? "";

                float RefNoHeight = pdf.MeasureWrappedTextHeight(Row, Col_Refno.Left, Col_Refno.Width, Line_Height, dr.mbl_refno!, format);
                // float HousenoHeight = pdf.MeasureWrappedTextHeight(Row, Col_Houseno.Left, Col_Houseno.Width, Line_Height, dr.mbl_houseno!, format);
                float InvNoHeight = pdf.MeasureWrappedTextHeight(Row, Col_Memo.Left, Col_Memo.Width, Line_Height, dr.mbl_loss_memo!, format);

                float rowHeight = new[] { RefNoHeight, InvNoHeight}.Max();

                pdf.AddText(Row, Col_Refno.Left, Col_Refno.Width, rowHeight, dr.mbl_refno!, format);
                pdf.AddText(Row, Col_RefDate.Left, Col_RefDate.Width, rowHeight, mbl_date.ToUpper()!, format);
                pdf.AddText(Row, Col_Lock.Left, Col_Lock.Width, rowHeight, dr.rec_locked!, format);
                pdf.AddText(Row, Col_ProfitMet.Left, Col_ProfitMet.Width, rowHeight, dr.mbl_profit_req!, format);
                pdf.AddText(Row, Col_LossApprv.Left, Col_LossApprv.Width, rowHeight, dr.mbl_loss_approved!, format);
                pdf.AddText(Row, Col_Memo.Left, Col_Memo.Width, rowHeight, dr.mbl_loss_memo!, format);
                pdf.AddText(Row, Col_Profit.Left, Col_Profit.Width, rowHeight, dr.mbl_revenue!, new TextFormat { Border = "b", FontSize = 8, Style = "R", Indent = true });

                Row += rowHeight;

                if (printHeader)
                {
                    WriteFooter(Row, Col_Default);
                    Row = WriteHeader(Row_Default, Col_Default);                    
                }
            }
            WriteFooter(Row, Col_Default);
        }

        private float WriteHeader(float _Row, float _Col)
        {
            Row = _Row;
            Col = _Col;

            pdf.AddNewPage();
            PageNumber++;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            string ptintInfo = $"PRINTED ON : {Date} / {User_name}     PAGE#: {PageNumber}";

            float currentY = CommonLib.WriteBranchAddressPdf(Row, Col, Company_id, Branch_id, context!, pdf);

            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, Title.ToUpper() , new TextFormat { Border = "TB", Style = "B", FontSize = 10 });//+ " LIST"
            currentY += Line_Height + 5;
            int halfWidth = Row_Width / 2; 
           
            float LeftY = currentY;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "FROM DATE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left , Col_Head_data.Width , Line_Height, SFromDate.ToUpper(), new TextFormat { Style = "B", FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "TO DATE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left , Col_Head_data.Width , Line_Height, SToDate.ToUpper(), new TextFormat { Style = "B", FontSize = 10 });
            
            float RightY = currentY;
            var RightCol = Col + halfWidth;
            
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "GROUP", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, OpGroup, new TextFormat { Style = "B", FontSize = 10 });
            
            currentY = RightY > LeftY ? RightY : LeftY;
            currentY += Line_Height + 5;
        
            pdf.AddText(currentY, Col_Refno.Left, Col_Refno.Width, Line_Height, "REF#", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_RefDate.Left, Col_RefDate.Width, Line_Height, "REF-DATE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Lock.Left, Col_Lock.Width, Line_Height, "LOCK", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_ProfitMet.Left, Col_ProfitMet.Width, Line_Height, "PROFIT-MET", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_LossApprv.Left, Col_LossApprv.Width, Line_Height, "LOSS-APPROVED", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Memo.Left, Col_Memo.Width, Line_Height, "MEMO", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Profit.Left, Col_Profit.Width, Line_Height, "PROFIT", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            
            currentY += Line_Height;

            return currentY;
        }
        private void WriteFooter(float rowIndex, float colIndex)
        {
            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name} ";//PAGE#: {PageNumber}

            Row = MaxRec_Height;//for footer print details(fixed)
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, printInfo, new TextFormat { Border="T", FontSize = 9 });
            Row += Line_Height;
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, $"PAGE#: {PageNumber}", new TextFormat { Border="", FontSize = 9 });
        }

    }
}
