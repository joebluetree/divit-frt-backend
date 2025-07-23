using System;
using System.Data;
using Common.DTO.Marketing;
using Common.DTO.Masters;
using Common.Lib;
using Common.UserAdmin.DTO;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using DataBase.Pdf;
using iTextSharp.text.pdf.qrcode;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NPOI.HPSF;
using NPOI.SS.Formula.Functions;

namespace Marketing.Printing
{
    public class QtnmLclPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<mark_qtnm_dto> Dt_List { get; set; } = new List<mark_qtnm_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string Name { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string QuoteTo { get; set; } = "";
        public string QuoteNo { get; set; } = "";
        public string Quotepld { get; set; } = "";
        public string User_name { get; set; } = "";
        public string Qtnm_type { get; set; } = "";

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
        private int Line_Height = 0;
        private int PageNumber = 0;
        private int Row_Width = 0;

        private ColumnFormat Col_Code = new();
        private ColumnFormat Col_date = new();
        private ColumnFormat Col_QuoteTo = new();
        private ColumnFormat Col_QuoteBy = new();
        private ColumnFormat Col_Pld = new();
        private ColumnFormat Col_Pod = new();
        private ColumnFormat Col_Move = new();
        private ColumnFormat Col_Commodity = new();


        public QtnmLclPdfFile()
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
                File_Display_Name = Qtnm_type!.ToLower();
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
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            this.Row_Width = 500;

            this.Col_Code = new ColumnFormat { Left = 30, Width =62 };
            this.Col_date = new ColumnFormat { Left = 92, Width = 58 };
            this.Col_QuoteTo = new ColumnFormat { Left = 150, Width = 82};
            this.Col_QuoteBy = new ColumnFormat { Left = 232, Width = 60};
            this.Col_Pld = new ColumnFormat { Left = 292, Width = 98};
            this.Col_Move = new ColumnFormat { Left = 390, Width = 62};
            this.Col_Commodity = new ColumnFormat { Left = 452, Width = 78};

            pdf.CreateDocument(File_Name);
            CreateReport();
            pdf.CloseDocument();
        }

        private void CreateReport()
        {

            int recordCount = Dt_List.Count;
            bool printHeader = false;
            string BL = "";

            Row = this.Page_Height;

            Row = WriteHeader(Row_Default, Col_Default);


            int i = 0;

            foreach (mark_qtnm_dto dr in Dt_List)
            {
                i++;
                printHeader = CommonLib.IsPageBreak(Row, Line_Height, Page_Height);
                BL = CommonLib.IsLastRow(i, recordCount);
                var qtnm_date = Lib.FormatDate(Lib.ParseDate(dr.qtnm_date!), Lib.DisplayDateFormat);
                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };

                float CodeHeight = pdf.MeasureWrappedTextHeight(Row, Col_Code.Left, Col_Code.Width, Line_Height, dr.qtnm_no!, format);
                float dateHeight = pdf.MeasureWrappedTextHeight(Row, Col_date.Left, Col_date.Width, Line_Height, qtnm_date!, format);
                float QuoteToHeight = pdf.MeasureWrappedTextHeight(Row, Col_QuoteTo.Left, Col_QuoteTo.Width, Line_Height, dr.qtnm_to_name!, format);
                float QuoteByHeight = pdf.MeasureWrappedTextHeight(Row, Col_QuoteBy.Left, Col_QuoteBy.Width, Line_Height, dr.qtnm_quot_by!, format);
                float PldHeight = pdf.MeasureWrappedTextHeight(Row, Col_Pld.Left, Col_Pld.Width, Line_Height, dr.qtnm_pld_name!, format);
                float MoveHeight = pdf.MeasureWrappedTextHeight(Row, Col_Move.Left, Col_Move.Width, Line_Height, dr.qtnm_move_type!, format);
                float CommodityHeight = pdf.MeasureWrappedTextHeight(Row, Col_Commodity.Left, Col_Commodity.Width, Line_Height, dr.qtnm_commodity!, format);                

                float rowHeight = new[] { CodeHeight, dateHeight, QuoteToHeight, QuoteByHeight, PldHeight, MoveHeight, CommodityHeight }.Max();
                
                pdf.AddText(Row, Col_Code.Left, Col_Code.Width, rowHeight, dr.qtnm_no!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_date.Left, Col_date.Width, rowHeight, qtnm_date!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_QuoteTo.Left, Col_QuoteTo.Width, rowHeight, dr.qtnm_to_name!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_QuoteBy.Left, Col_QuoteBy.Width, rowHeight, dr.qtnm_quot_by!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Pld.Left, Col_Pld.Width, rowHeight, dr.qtnm_pld_name!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Move.Left, Col_Move.Width, rowHeight, dr.qtnm_move_type!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Commodity.Left, Col_Commodity.Width, rowHeight, dr.qtnm_commodity!, new TextFormat { Border = "LTR" + BL, FontSize = 9, Indent = true });
                
                Row += rowHeight;

                if (printHeader)
                    Row = WriteHeader(Row_Default, Col_Default);
            }
        }

        private float WriteHeader(float _Row, float _Col)
        {
            Row = _Row;
            Col = _Col;

            pdf.AddNewPage();
            PageNumber++;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            string ptintInfo = $"PRINTED ON : {Date} / {User_name}     PAGE#: {PageNumber}";

            float currentY = CommonLib.WriteBranchAddressPdf(Row, Col, Company_id, Branch_id, context!, pdf);

            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, Title.ToUpper() + " LIST", new TextFormat { Border = "TB", Style = "B", FontSize = 10 });
            currentY += Line_Height + 3;
            int halfWidth = Row_Width / 2; // to assign From and to date in same row
            pdf.AddText(currentY, Col, halfWidth, Line_Height, "FROM DATE: " + FromDate, new TextFormat { FontSize = 10 });
            pdf.AddText(currentY, Col + halfWidth, halfWidth, Line_Height, "TO DATE: " + ToDate, new TextFormat { FontSize = 10 });
            currentY += Line_Height;

            pdf.AddText(currentY, Col, halfWidth, Line_Height, "QUOTE TO: " + QuoteTo, new TextFormat { FontSize = 10 });
            pdf.AddText(currentY, Col + halfWidth, halfWidth, Line_Height, "QUOTE NO: " + QuoteNo, new TextFormat { FontSize = 10 });
            currentY += Line_Height;
            
            pdf.AddText(currentY, Col, Row_Width, Line_Height, "PLACE OF DELIVERY: " + Quotepld, new TextFormat { FontSize = 10 });
            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, ptintInfo, new TextFormat { FontSize = 10 });
            currentY += Line_Height + 5;

            // Table Header
            pdf.AddText(currentY, Col_Code.Left, Col_Code.Width, Line_Height, "QUOTE#", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_date.Left, Col_date.Width, Line_Height, "DATE", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_QuoteTo.Left, Col_QuoteTo.Width, Line_Height, "QUOTE TO", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_QuoteBy.Left, Col_QuoteBy.Width, Line_Height, "QUOTE BY", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Pld.Left, Col_Pld.Width, Line_Height, "PLACE.DELIVERY", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Move.Left, Col_Move.Width, Line_Height, "MOVE", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Commodity.Left, Col_Commodity.Width, Line_Height, "COMMODITY", new TextFormat { Border = "LTR", Style = "B", FontSize = 10, Indent = true });

            currentY += Line_Height;

            return currentY;
        }

    }
}
