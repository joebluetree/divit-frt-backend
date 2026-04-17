using System;
using System.Data;
using Common.DTO.Marketing;
using Common.DTO.UserAdmin;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using DataBase.Pdf;
using iTextSharp.text.pdf.qrcode;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using NPOI.HPSF;
using NPOI.HSSF.Record;
using NPOI.SS.Formula.Functions;
using NPOI.Util;

namespace Marketing.Printing
{
    public class LclReportPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<mark_qtnd_lcl_dto> Dt_List { get; set; } = new List<mark_qtnd_lcl_dto>();
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
        private float Detail_Height = 0;
        private int Line_Height = 0;
        private int PageNumber = 0;
        private int Row_Width = 0;
        private bool IsAttachment = false;
        private int MaxRecCount = 25;
        private float MaxHeaderHeight = 0;

        private ColumnFormat Col_AccName = new();
        private ColumnFormat Col_Remk = new();
        private ColumnFormat Col_Amount = new();
        private ColumnFormat Col_total = new();
        private ColumnFormat Col_paid = new();
        private ColumnFormat Col_balance = new();


        public LclReportPdfFile()
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
            this.Page_Height = 800;
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            this.Row_Width = 500;

            this.Col_AccName = new ColumnFormat { Left = 30, Width = 200 };
            this.Col_Amount = new ColumnFormat { Left = 230, Width = 100 };
            this.Col_Remk = new ColumnFormat { Left = 330, Width = 200 };

            pdf.CreateDocument(File_Name);
            CreateReport();
            pdf.CloseDocument();
        }
        private bool IsPageBreak(float Row, int Line_Height, float Page_Height, int detailCount)
        {
            bool height = (Row + Line_Height) > Page_Height;
            bool countExceeded = detailCount >= MaxRecCount;

            return height || countExceeded;
        }

        private void CreateReport()
        {

            int recordCount = Dt_List.Count;
            bool printHeader = false;
            string BL = "";

            Row = this.Page_Height;

            Row = WriteHeader(Row_Default, Col_Default);
            
            this.Detail_Height = MaxHeaderHeight + (MaxRecCount*Line_Height);//740;
            int i = 0;
            int detailCount = 0;

            foreach (mark_qtnd_lcl_dto dr in Dt_List)
            {
                i++;
                printHeader = IsPageBreak(Row, Line_Height, Detail_Height, detailCount);
                BL = CommonLib.IsLastRow(i, recordCount);
                BL = i == MaxRecCount ? "B" : BL;

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

                float AccNameHeight = pdf.MeasureWrappedTextHeight(Row, Col_AccName.Left, Col_AccName.Width, Line_Height, dr.qtnd_acc_name!, format);
                float RemkHeight = pdf.MeasureWrappedTextHeight(Row, Col_Remk.Left, Col_Remk.Width, Line_Height, dr.qtnd_acc_code!, format);
                float AmountHeight = pdf.MeasureWrappedTextHeight(Row, Col_Amount.Left, Col_Amount.Width, Line_Height, dr.qtnd_amt!, format);

                float rowHeight = new[] { AccNameHeight, RemkHeight, AmountHeight }.Max();//RemkHeight,

                pdf.AddText(Row, Col_AccName.Left, Col_AccName.Width, rowHeight, dr.qtnd_acc_name!, new TextFormat { Border = "T" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Amount.Left, Col_Amount.Width, rowHeight, dr.qtnd_amt!, new TextFormat { Border = "T" + BL, Style = "R", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Remk.Left, Col_Remk.Width, rowHeight, dr.qtnd_per!, new TextFormat { Border = "T" + BL, FontSize = 9, Indent = true });

                if (recordCount > i)
                    Row += rowHeight;

                detailCount++;
            }
            Row = FooterPadding(Row, detailCount);
            WriteFooter(Row, Col_Default);
            if (IsAttachment)
            {
                WriteAttachment(Row_Default, Col_Default);
            }

        }

        private float WriteHeader(float _Row, float _Col)
        {
            Row = _Row;
            Col = _Col;

            pdf.AddNewPage();
            PageNumber++;

            float currentY = CommonLib.WriteBranchAddressPdf(Row, Col, Company_id, Branch_id, context!, pdf);

            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, Title.ToUpper(), new TextFormat { Border = "TB", Style = "CB", FontSize = 11 });
            currentY += Line_Height + 10;

            int halfWidth = Row_Width / 2;
            int valueWidth = halfWidth / 2;
            float rightColX = Col + halfWidth;


            pdf.AddText(currentY, Col, halfWidth, Line_Height, $"QUOTE NO. : {QuoteNo}", new TextFormat { Style = "B", FontSize = 11 });
            // pdf.AddText(currentY, Col + (valueWidth/2), valueWidth, Line_Height, QuoteNo, new TextFormat { Style = "B", FontSize = 10 });            

            currentY += Line_Height + 10;
            float _currentY = currentY;


            pdf.AddText(_currentY, Col, halfWidth, Line_Height, "To :", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, Col + (valueWidth / 2), valueWidth, Line_Height, CustomerName, new TextFormat { FontSize = 10 });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col, valueWidth, Line_Height, "", new TextFormat { Border = "L", FontSize = 10 });
            pdf.AddText(_currentY, Col + (valueWidth / 2), valueWidth, Line_Height, CustAddress1, new TextFormat { FontSize = 10 });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col, valueWidth, Line_Height, "", new TextFormat { Border = "L", FontSize = 10 });
            pdf.AddText(_currentY, Col + (valueWidth / 2), valueWidth, Line_Height, CustAddress2, new TextFormat { FontSize = 10 });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col, valueWidth, Line_Height, "", new TextFormat { Border = "L", FontSize = 10 });
            pdf.AddText(_currentY, Col + (valueWidth / 2), valueWidth, Line_Height, CustAddress3, new TextFormat { FontSize = 10 });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col, halfWidth, Line_Height, "", new TextFormat { Border = "LB", FontSize = 10 });
            pdf.AddText(_currentY, Col + (valueWidth / 2), halfWidth, Line_Height, CustAttn, new TextFormat { FontSize = 10 });
            _currentY += Line_Height;

            _currentY = currentY;
            pdf.AddText(_currentY, rightColX, valueWidth, Line_Height, "Date ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, QuoteDate, new TextFormat { Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, valueWidth, Line_Height, "Quote By ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, QuoteBy, new TextFormat { Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, valueWidth, Line_Height, "Sales Rep. ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, QtnmSalesman, new TextFormat { Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, valueWidth, Line_Height, "Validity ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, QtnmValidDate, new TextFormat { Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, valueWidth, Line_Height, "Type of Move ", new TextFormat { Border = "LTB", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, QtnmMoveType, new TextFormat { Border = "LTRB", FontSize = 10, Indent = true });
            _currentY += Line_Height;

            currentY = _currentY + 10;

            _currentY = currentY;
            pdf.AddText(_currentY, Col, halfWidth, Line_Height, "Place of Receipt ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, Col + valueWidth, halfWidth, Line_Height, QtnmPOR, new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col, halfWidth, Line_Height, "Place of Loading ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, Col + valueWidth, halfWidth, Line_Height, QtnmPOL, new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col, halfWidth, Line_Height, "Port of Discharge ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, Col + valueWidth, halfWidth, Line_Height, QtnmPOD, new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col, halfWidth, Line_Height, "Place of Delivery ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, Col + valueWidth, halfWidth, Line_Height, QtnmPLD, new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col, halfWidth, Line_Height, "Final Destination ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, Col + valueWidth, halfWidth, Line_Height, QtnmPLFD, new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col, halfWidth, Line_Height, "", new TextFormat { Border = "LTB", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, Col + valueWidth, halfWidth, Line_Height, "", new TextFormat { Border = "LTB", FontSize = 10, Indent = true });
            _currentY += Line_Height;

            _currentY = currentY;
            pdf.AddText(_currentY, rightColX, halfWidth, Line_Height, "Commodity ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, QtnmCommodity, new TextFormat { Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, halfWidth, Line_Height, "Packages ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, QtnmPackage, new TextFormat { Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, halfWidth, Line_Height, "Weight ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, $"{QtnmKGS} Kgs      {QtnmLBS} Lbs", new TextFormat { Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, halfWidth, Line_Height, "Volume ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, $"{QtnmCBM} CBM      {QtnmLBS} CFT", new TextFormat { Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, halfWidth, Line_Height, "Transit Time ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, QtnmTransTime, new TextFormat { Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, halfWidth, Line_Height, "Routing ", new TextFormat { Border = "LTB", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, QtnmRouting, new TextFormat { Border = "LTRB", FontSize = 10, Indent = true });
            _currentY += Line_Height;

            currentY = _currentY;

            // pdf.AddText(currentY, Col, Row_Width, Line_Height, "", new TextFormat { Border = "B",FontSize = 10 });
            currentY += Line_Height + 10;
            if (!IsAttachment)
            {
                pdf.AddText(currentY, Col_AccName.Left, Col_AccName.Width, Line_Height, "DESCRIPTION", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Amount.Left, Col_Amount.Width, Line_Height, $"AMOUNT ({QtnmCurCode})", new TextFormat { Border = "T", Style = "RB", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Remk.Left, Col_Remk.Width, Line_Height, "PER", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                currentY += Line_Height;
            }
            MaxHeaderHeight = currentY;
            return currentY;
        }
        private void WriteFooter(float _Row, float _Col)
        {
            Row = _Row;
            Col = _Col;

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

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name} PAGE#: {PageNumber}";//

            Row = 775;//for footer print details(fixed)
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, printInfo, new TextFormat { Border = "T", FontSize = 9 });
            Row += Line_Height;

            float TextHeight = pdf.MeasureWrappedTextHeight(Row, Col_Default, 400, Line_Height, FooterText!, new TextFormat { Style = "J", Indent = true });
            pdf.AddText(Row, Col_Default, 400, TextHeight, FooterText, new TextFormat { Border = "", FontSize = 6 });

            // return currentY;
        }
        private void WriteAttachment(float _Row, float _Col)
        {
            Row = _Row;
            Col = _Col;
            int count = 0;

            float currentY = WriteHeader(_Row, _Col);

            pdf.AddText(currentY, Col, Row_Width, Line_Height, "REMARKS", new TextFormat { Border = "B", Style = "B", FontSize = 10 });
            currentY += Line_Height;
            foreach (var c in RemkList)
            {
                pdf.AddText(currentY, Col, Row_Width, Line_Height, c.remk_desc!, new TextFormat { FontSize = 10 });

                currentY += Line_Height;
                count++;
                if (count > MaxRecCount)
                {
                    WriteFooter(currentY, _Col);
                    currentY += Line_Height;

                    pdf.AddNewPage();
                    PageNumber++;
                    currentY = WriteHeader(_Row, _Col);
                    pdf.AddText(currentY, Col, Row_Width, Line_Height, "REMARKS", new TextFormat { Border = "B", Style = "B", FontSize = 10 });
                    currentY += Line_Height;

                    count = 0;
                }
            }

            currentY += Line_Height;

            WriteFooter(currentY, _Col);
        }
        private float FooterPadding(float currentY, int detailCount)
        {
            int totalRemarks = RemkList.Count;
            int remainingRows = MaxRecCount - detailCount;

            if (remainingRows < 2 || totalRemarks == 0)
            {
                IsAttachment = totalRemarks > 0;
                return FillBlankRow(currentY, remainingRows);
            }

            currentY += Line_Height;
            remainingRows--;

            currentY += Line_Height;
            pdf.AddText(currentY,Col_Default,Row_Width,Line_Height,"REMARKS",new TextFormat { Style = "B", Border = "TB", FontSize = 9 });

            currentY += Line_Height;
            remainingRows--;

            int writtenRemarks = 0;

            for (int i = 0; i < totalRemarks && remainingRows > 0; i++)
            {
                // float h = pdf.MeasureWrappedTextHeight(currentY,Col_Default,Row_Width,Line_Height,RemkList[i].remk_desc!,new TextFormat { FontSize = 9 });

                pdf.AddText(currentY,Col_Default,Row_Width,Line_Height,RemkList[i].remk_desc!,new TextFormat { FontSize = 9 });

                currentY += Line_Height;
                remainingRows--;
                writtenRemarks++;
            }

            if (writtenRemarks < totalRemarks)
            {
                IsAttachment = true;
                RemkList = RemkList.Skip(writtenRemarks).ToList();
            }

            return FillBlankRow(currentY, remainingRows);
        }
        private float FillBlankRow(float currentY, int rows)
        {
            for (int i = 0; i < rows; i++)
                currentY += Line_Height;

            return currentY;
        }
    }
}
