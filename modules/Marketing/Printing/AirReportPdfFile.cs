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
    public class AirReportPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
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
        public string QtnmCommodity { get; set; } = "";
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
        private int MaxRecCount = 6;
        private float MaxHeaderHeight = 0;

        private ColumnFormat Col_PolName = new();
        private ColumnFormat Col_PodName = new();
        private ColumnFormat Col_CarrierName = new();
        private ColumnFormat Col_TransTime = new();
        private ColumnFormat Col_Min = new();
        private ColumnFormat Col_45K = new();
        private ColumnFormat Col_100K = new();
        private ColumnFormat Col_300K = new();
        private ColumnFormat Col_500K = new();
        private ColumnFormat Col_1000K = new();
        private ColumnFormat Col_FSC = new();
        private ColumnFormat Col_WAR = new();
        private ColumnFormat Col_SFC = new();
        private ColumnFormat Col_HAC = new();

        public AirReportPdfFile()
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
            // for landscape H-500 & W-800
            // for portrait H-800 & W-500
            this.Page_Height = 500;
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            this.Row_Width = 800;
            this.Detail_Height = 500;

            this.Col_PolName = new ColumnFormat { Left = 30, Width = 110 };
            this.Col_PodName = new ColumnFormat { Left = 140, Width = 110 };
            this.Col_CarrierName = new ColumnFormat { Left = 250, Width = 100 };
            this.Col_TransTime = new ColumnFormat { Left = 350, Width = 70 };
            this.Col_Min = new ColumnFormat { Left = 420, Width = 50 };//20
            this.Col_45K = new ColumnFormat { Left = 470, Width = 40 };
            this.Col_100K = new ColumnFormat { Left = 510, Width = 40 };
            this.Col_300K = new ColumnFormat { Left = 550, Width = 40 };
            this.Col_500K = new ColumnFormat { Left = 590, Width = 40 };
            this.Col_1000K = new ColumnFormat { Left = 630, Width = 40 };
            this.Col_FSC = new ColumnFormat { Left = 670, Width = 40 };
            this.Col_WAR = new ColumnFormat { Left = 710, Width = 40 };
            this.Col_SFC = new ColumnFormat { Left = 750, Width = 40 };
            this.Col_HAC = new ColumnFormat { Left = 790, Width = 40 };
            /// need modification

            pdf.CreateDocument(File_Name,"LANDSCAPE");
            CreateReport();
            pdf.CloseDocument();
        }
        private bool IsPageBreak(float Row, float Page_Height, int detailCount, float rowHeight, int MaxCount)// Line_Height,
        {
            bool height = (Row + rowHeight) > Page_Height;
            bool countExceeded = detailCount >= MaxCount;

            return height || countExceeded;
        }

        private void CreateReport()
        {

            int recordCount = Dt_List.Count;
            bool printHeader = false;
            string BL = "";

            Row = this.Page_Height;

            Row = WriteHeader(Row_Default, Col_Default);
            
            // this.Detail_Height = MaxHeaderHeight + (MaxRecCount*(Line_Height*2));//minimum 2*line_height
            int i = 0;
            int detailCount = 0;
            float lastRowHeight = 0;

            foreach (mark_qtnd_air_dto dr in Dt_List)
            {
                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };

                float PolNameHeight = pdf.MeasureWrappedTextHeight(Row, Col_PolName.Left, Col_PolName.Width, Line_Height, dr.qtnd_pol_name!, format);
                float PodNameHeight = pdf.MeasureWrappedTextHeight(Row, Col_PodName.Left, Col_PodName.Width, Line_Height, dr.qtnd_pod_name!, format);
                float RoutingHeight = pdf.MeasureWrappedTextHeight(Row, Col_PodName.Left, Col_PodName.Width, Line_Height, dr.qtnd_routing!, format) + PodNameHeight;
                float CarrierHeight = pdf.MeasureWrappedTextHeight(Row, Col_CarrierName.Left, Col_CarrierName.Width, Line_Height, dr.qtnd_carrier_name!, format);
                float ETDHeight = pdf.MeasureWrappedTextHeight(Row, Col_CarrierName.Left, Col_CarrierName.Width, Line_Height, dr.qtnd_etd!, format) + CarrierHeight;
                float TransitTimeHeight = pdf.MeasureWrappedTextHeight(Row, Col_TransTime.Left, Col_TransTime.Width, Line_Height, dr.qtnd_trans_time!, format);

                float rowHeight = Line_Height * 2;// min row hight
                rowHeight = new[] { PolNameHeight, PodNameHeight, RoutingHeight, CarrierHeight, ETDHeight, TransitTimeHeight, rowHeight }.Max();
                
                i++;
                printHeader = IsPageBreak(Row, Detail_Height, detailCount, rowHeight, MaxRecCount);
                BL = CommonLib.IsLastRow(i, recordCount);
                BL = printHeader ? "B" : BL;

                if (printHeader)
                {
                    WriteFooter(Row, Col_Default);
                    Row = WriteHeader(Row_Default, Col_Default);

                    detailCount = 0;
                }

                pdf.AddText(Row, Col_PolName.Left, Col_PolName.Width, rowHeight, dr.qtnd_pol_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_PodName.Left, Col_PodName.Width, rowHeight, dr.qtnd_pod_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row + PodNameHeight, Col_PodName.Left, Col_PodName.Width, rowHeight, dr.qtnd_routing!, new TextFormat {  FontSize = 9, Indent = true });//Border = BL,
                pdf.AddText(Row, Col_CarrierName.Left, Col_CarrierName.Width, rowHeight, dr.qtnd_carrier_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row + CarrierHeight, Col_CarrierName.Left, Col_CarrierName.Width, rowHeight, dr.qtnd_etd!, new TextFormat { FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_TransTime.Left, Col_TransTime.Width, rowHeight, dr.qtnd_trans_time!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Min.Left, Col_Min.Width, rowHeight, dr.qtnd_min!, new TextFormat { Border = "B" , FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_45K.Left, Col_45K.Width, rowHeight, dr.qtnd_45k!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_100K.Left, Col_100K.Width, rowHeight, dr.qtnd_100k!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_300K.Left, Col_300K.Width, rowHeight, dr.qtnd_300k!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_500K.Left, Col_500K.Width, rowHeight, dr.qtnd_500k!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_1000K.Left, Col_1000K.Width, rowHeight, dr.qtnd_1000k!, new TextFormat { Border = "B" , FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_FSC.Left, Col_FSC.Width, rowHeight, dr.qtnd_fsc!, new TextFormat { Border = "B" , FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_WAR.Left, Col_WAR.Width, rowHeight, dr.qtnd_war!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_SFC.Left, Col_SFC.Width, rowHeight, dr.qtnd_sfc!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_HAC.Left, Col_HAC.Width, rowHeight, dr.qtnd_hac!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                if(!Lib.IsBlank(BL))
                    pdf.AddText(Row, Col_PolName.Left, Row_Width, rowHeight, "", new TextFormat { Border = BL, FontSize = 9, Indent = true });//Style = "R",

                if (recordCount > i)
                {
                    Row += rowHeight;
                }
                lastRowHeight = rowHeight;
                detailCount++;
            }
            Row = FooterPadding(Row, lastRowHeight);
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
            pdf.AddText(_currentY, Col, halfWidth, Line_Height, "", new TextFormat { Border = "L", FontSize = 10 });
            pdf.AddText(_currentY, Col + (valueWidth / 2), halfWidth, Line_Height, CustAttn, new TextFormat { FontSize = 10 });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col, halfWidth, Line_Height, "", new TextFormat { Border = "LB", FontSize = 10 });
            pdf.AddText(_currentY, Col + (valueWidth / 2), halfWidth, Line_Height, "", new TextFormat { FontSize = 10 });

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
            pdf.AddText(_currentY, rightColX, valueWidth, Line_Height, "Type of Move ", new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, QtnmMoveType, new TextFormat { Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, valueWidth, Line_Height, "Commodity ", new TextFormat { Border = "LTB", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX + valueWidth, valueWidth, Line_Height, QtnmCommodity, new TextFormat { Border = "LTRB", FontSize = 10, Indent = true });

            currentY = _currentY + 10;

            // pdf.AddText(currentY, Col, Row_Width, Line_Height, "", new TextFormat { Border = "B",FontSize = 10 });
            currentY += Line_Height + 10;
            if (!IsAttachment)
            {
                var RowHeight = Line_Height * 2;

                pdf.AddText(currentY, Col_PolName.Left, Col_PolName.Width, RowHeight, "ORIGIN", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_PodName.Left, Col_PodName.Width, RowHeight, "DESTINATION", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY + Line_Height, Col_PodName.Left, Col_PodName.Width, RowHeight, "ROUTING", new TextFormat { Border = "", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_CarrierName.Left, Col_CarrierName.Width, RowHeight, "CARRIER", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY + Line_Height, Col_CarrierName.Left, Col_CarrierName.Width, RowHeight, "ETD", new TextFormat { Border = "", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_TransTime.Left, Col_TransTime.Width, RowHeight, "T/T", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Min.Left, Col_Min.Width, RowHeight, "MINIMUM", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_45K.Left, Col_45K.Width, RowHeight, "+45K", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_100K.Left, Col_100K.Width, RowHeight, "+100K", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_300K.Left, Col_300K.Width, RowHeight, "+300K", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_500K.Left, Col_500K.Width, RowHeight, "+500K", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_1000K.Left, Col_1000K.Width, RowHeight, "+1000K", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_FSC.Left, Col_FSC.Width, RowHeight, "FSC", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_WAR.Left, Col_WAR.Width, RowHeight, "WAR", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_SFC.Left, Col_SFC.Width, RowHeight, "SFC", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_HAC.Left, Col_HAC.Width, RowHeight, "HAC", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Default, Row_Width, RowHeight, "", new TextFormat { Border = "B", FontSize = 10});
                currentY += RowHeight;

            }

            MaxHeaderHeight = currentY;
            return currentY;
        }
        private void WriteFooter(float _Row, float _Col)
        {
            Row = _Row;
            Col = _Col;

            Row = 500;//for footer print details(fixed)

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
                if (count > 12)
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
        private float FooterPadding(float currentY, float lastRowHeight)
        {
            int totalRemarks = RemkList.Count;
            float maxFooter = 500;
            bool PrintAttachment = false;
            float remainingHeight = maxFooter - currentY + lastRowHeight;

            currentY += lastRowHeight;

            pdf.AddText(currentY,Col_Default,Row_Width,Line_Height,"REMARKS",new TextFormat { Style = "B", Border = "B", FontSize = 10 });

            currentY += Line_Height;

            int remkCount = 0;
            int i = 0;

            foreach (var remk in RemkList)
            {
                i++;

                PrintAttachment = IsPageBreak(currentY, maxFooter, remkCount, Line_Height, 12);
                // var BL = i == totalRemarks - 1? "B" : "";
                var BL = CommonLib.IsLastRow(i, totalRemarks);
                BL = PrintAttachment ? "B" : BL;
                if (!PrintAttachment)
                {
                    pdf.AddText(currentY,Col_Default,Row_Width,Line_Height,remk.remk_desc!,new TextFormat {Border="" + BL, FontSize = 10 });

                    currentY += Line_Height;
                    remkCount++;    
                }
                else
                {
                    IsAttachment = true;
                    RemkList = RemkList.Skip(remkCount).ToList();
                    return currentY;
                }
            }

            return currentY;
        }
        private float FillBlankRow(float currentY, int rows)
        {
            for (int i = 0; i < rows; i++)
                currentY += Line_Height;

            return currentY;
        }
    }
}
