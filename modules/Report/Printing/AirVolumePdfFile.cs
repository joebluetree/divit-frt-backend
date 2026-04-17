using System;
using System.Data;
using Common.DTO.OtherOp;
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
    public class AirVolumePdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<rep_airvolume_dto> Dt_List { get; set; } = new List<rep_airvolume_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string Format { get; set; } = "";
        public string ReportType { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string ShipType { get; set; } = "";
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

        private string PageSize = "";
        private int Page_Height = 0;
        private int MaxRec_Height = 0;
        private int Line_Height = 0;
        private int PageNumber = 0;
        private int Row_Width = 0;

        private ColumnFormat Col_Code = new();
        private ColumnFormat Col_Agent = new();
        private ColumnFormat Col_date = new();
        private ColumnFormat Col_Carrier = new();
        private ColumnFormat Col_Shipper = new();
        private ColumnFormat Col_Consignee = new();
        private ColumnFormat Col_Pcs = new();
        private ColumnFormat Col_Wt = new();
        private ColumnFormat Col_ChWt = new();

        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header



        public AirVolumePdfFile()
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
                File_Display_Name = Title!.ToLower();
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
        private string getPageSize ()
        {
            PageSize = "A4";
            if(Format == "OPERATION GROUP" && ReportType == "DETAIL")
            {
                PageSize = "LANDSCAPE";
            }
            return PageSize;
        }
        private void Writedocument()
        {
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;

            if (getPageSize() == "LANDSCAPE")
            {
                this.Page_Height = 500;
                this.Row_Width = 800;
                this.MaxRec_Height = 470;

                this.Col_Code = new ColumnFormat { Left = 30, Width = 70 };
                this.Col_date = new ColumnFormat { Left = 100, Width = 80 };
                this.Col_Agent = new ColumnFormat { Left = 180, Width = 110 };
                this.Col_Carrier = new ColumnFormat { Left = 290, Width = 110 };
                this.Col_Shipper = new ColumnFormat { Left = 400, Width = 140 };
                this.Col_Consignee = new ColumnFormat { Left = 540, Width = 140 };
                this.Col_Pcs = new ColumnFormat { Left = 680, Width = 50 };
                this.Col_Wt = new ColumnFormat { Left = 730, Width = 50 };
                this.Col_ChWt = new ColumnFormat { Left = 780, Width = 50 };

                this.Col_Column = new ColumnFormat { Left = 80, Width = 10 };// ':'
                this.Col_Head_data = new ColumnFormat { Left = 90, Width = 100 };
                
                pdf.CreateDocument(File_Name, "LANDSCAPE");
            }
            if (getPageSize() == "A4")
            {
                this.Page_Height = 800;
                this.Row_Width = 500;
                this.MaxRec_Height = 770;

                this.Col_Code = new ColumnFormat { Left = 30, Width =110 };
                this.Col_date = new ColumnFormat { Left = 140, Width = 170 };
                this.Col_Pcs = new ColumnFormat { Left = 310, Width = 70 };
                this.Col_Wt = new ColumnFormat { Left = 380, Width = 70 };
                this.Col_ChWt = new ColumnFormat { Left = 450, Width = 80 };

                this.Col_Agent = new ColumnFormat { Left = 30, Width = 350 };

                this.Col_Column = new ColumnFormat { Left = 80, Width = 10 };// ':'
                this.Col_Head_data = new ColumnFormat { Left = 90, Width = 100 };
                pdf.CreateDocument(File_Name);
            }
                
            CreateReport();
            pdf.CloseDocument();
        }

        private void CreateReport()
        {

            int recordCount = Dt_List.Count;
            bool printHeader = false;
            string BL = "";
            string ST = "";
            bool isLastTwo = false;

            Row = this.Page_Height;

            Row = WriteHeader(Row_Default, Col_Default);

            int i = 0;

            foreach (rep_airvolume_dto dr in Dt_List)
            {
                i++;
                printHeader = CommonLib.IsPageBreak(Row, Line_Height, MaxRec_Height);
                isLastTwo = (i == recordCount-1 || i == recordCount);
                bool isTotal = dr.mbl_refno == "TOTAL";
                BL = isLastTwo ? "TB" : "b";
                ST = isLastTwo ? "TB" : "";// style bold
                var TotalBorder = isTotal ? "T" : "";
                var TotalStyle = isTotal ? "B" : "";

                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };
                var mbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.mbl_ref_date!), Lib.DisplayDateFormat) ?? "";
                // Row += 3;
                
                float AgentHeight = pdf.MeasureWrappedTextHeight(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.mbl_agent_name!, format);
                float CarrierHeight = pdf.MeasureWrappedTextHeight(Row, Col_Carrier.Left, Col_Carrier.Width, Line_Height, dr.mbl_liner_name!, format);
                float ShipperHeight = pdf.MeasureWrappedTextHeight(Row, Col_Shipper.Left, Col_Shipper.Width, Line_Height, dr.mbl_shipper_name!, format);
                float ConsigneeHeight = pdf.MeasureWrappedTextHeight(Row, Col_Consignee.Left, Col_Consignee.Width, Line_Height, dr.mbl_consignee_name!, format);

                float rowHeight = Line_Height;
                if(getPageSize() == "LANDSCAPE")
                {                    
                    rowHeight = new[] { AgentHeight, CarrierHeight, ShipperHeight, ConsigneeHeight, Line_Height}.Max();
                }
                
                if (ReportType == "SUMMARY" && !isLastTwo)
                {
                    if (Format == "AGENT")
                        pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.mbl_agent_name!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                    if (Format == "OPERATION GROUP")
                        pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.mbl_mode!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                }
                if (ReportType == "DETAIL" && !isLastTwo)
                {
                    if (Format == "AGENT" && dr.IsAgentTitle == true)
                    {
                        pdf.AddText(Row, Col_Agent.Left, Row_Width, Line_Height, "AGENT  : " + dr.mbl_agent_name!, new TextFormat { Border = "T" + BL, Style = "B" + ST, FontSize = 9, Indent = true });
                    }
                    else
                    {
                        pdf.AddText(Row, Col_Code.Left, Col_Code.Width, rowHeight, dr.mbl_refno!, new TextFormat { Border = BL + TotalBorder, Style = TotalStyle, FontSize = 9, Indent = true });
                        pdf.AddText(Row, Col_date.Left, Col_date.Width, rowHeight, mbl_ref_date.ToUpper()!, new TextFormat { Border = BL + TotalBorder, FontSize = 9, Indent = true });
                    }
                }
                if (isLastTwo)
                {
                    pdf.AddText(Row, Col_Code.Left, Col_Code.Width, Line_Height, dr.mbl_agent_name!, new TextFormat { Border = BL, Style = ST, FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_date.Left, Col_date.Width, Line_Height, "", new TextFormat { Border = BL, FontSize = 9, Indent = true });       
                }
                if(getPageSize() == "LANDSCAPE")
                {
                    if(isLastTwo)
                        pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, "", new TextFormat { Border = BL + TotalBorder, Style = "" + TotalStyle + ST, FontSize = 9, Indent = true });
                    if(!isLastTwo)
                        pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.mbl_agent_name!, new TextFormat { Border = BL + TotalBorder, Style = "" + TotalStyle + ST, FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_Carrier.Left, Col_Carrier.Width, rowHeight, dr.mbl_liner_name!, new TextFormat { Border = BL + TotalBorder, Style = "" + TotalStyle + ST, FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_Shipper.Left, Col_Shipper.Width, rowHeight, dr.mbl_shipper_name!, new TextFormat { Border = BL + TotalBorder, Style = "" + TotalStyle + ST, FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_Consignee.Left, Col_Consignee.Width, rowHeight, dr.mbl_consignee_name!, new TextFormat { Border = BL + TotalBorder, Style = "" + TotalStyle + ST, FontSize = 9, Indent = true });
                }
                pdf.AddText(Row, Col_Pcs.Left, Col_Pcs.Width, rowHeight, dr.mbl_pcs!, new TextFormat { Border = BL + TotalBorder, Style = "R" + TotalStyle + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Wt.Left, Col_Wt.Width, rowHeight, dr.mbl_weight!, new TextFormat { Border = BL + TotalBorder, Style ="R" + TotalStyle + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_ChWt.Left, Col_ChWt.Width, rowHeight, dr.mbl_chwt!, new TextFormat { Border = BL + TotalBorder, Style ="R" + TotalStyle + ST, FontSize = 9, Indent = true });

                Row += rowHeight;

                if (printHeader)
                {
                    WriteFooter();
                    Row = WriteHeader(Row_Default, Col_Default);
                }
            }
            WriteFooter();
        }

        private float WriteHeader(float _Row, float _Col)
        {
            Row = _Row;
            Col = _Col;
            // var BL = "B";

            pdf.AddNewPage();
            PageNumber++;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            string ptintInfo = $"PRINTED ON : {Date} / {User_name}     PAGE#: {PageNumber}";

            float currentY = CommonLib.WriteBranchAddressPdf(Row, Col, Company_id, Branch_id, context!, pdf);

            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, Title.ToUpper(), new TextFormat { Border = "TB", Style = "B", FontSize = 10 });//+ " LIST"
            currentY += Line_Height + 5;
            int halfWidth = Row_Width / 2;

            float LeftY = currentY;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "FROM DATE", new TextFormat { FontSize = 10, Style = "B" });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10, Style = "B" });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SFromDate.ToUpper(), new TextFormat { FontSize = 10, Style = "B" });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "TO DATE", new TextFormat { FontSize = 10, Style = "B" });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10, Style = "B" });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SToDate.ToUpper(), new TextFormat { FontSize = 10, Style = "B" });

            float RightY = currentY;
            var RightCol = Col + halfWidth;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "FORMAT", new TextFormat { FontSize = 10, Style = "B" });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10, Style = "B" });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Format, new TextFormat { FontSize = 10, Style = "B" });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "REPORT TYPE", new TextFormat { FontSize = 10, Style = "B" });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10, Style = "B" });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ReportType, new TextFormat { FontSize = 10, Style = "B" });

            currentY = RightY >= LeftY ? RightY : LeftY;
            currentY += Line_Height + 5;

            // Table Header
            if (ReportType == "SUMMARY")
            {
                if (Format == "OPERATION GROUP")
                    pdf.AddText(currentY, Col_Agent.Left, Col_Agent.Width, Line_Height, "GROUP", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                if (Format == "AGENT")
                    pdf.AddText(currentY, Col_Agent.Left, Col_Agent.Width, Line_Height, "AGENT", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });

            }
            if (ReportType == "DETAIL")
            {
                pdf.AddText(currentY, Col_Code.Left, Col_Code.Width, Line_Height, "REF#", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_date.Left, Col_date.Width, Line_Height, " REF DATE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            }
            if(getPageSize() == "LANDSCAPE")
            {
                pdf.AddText(currentY, Col_Agent.Left, Col_Agent.Width, Line_Height, "AGENT", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Carrier.Left, Col_Carrier.Width, Line_Height, "CARRIER", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Shipper.Left, Col_Shipper.Width, Line_Height, "SHIPPER", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Consignee.Left, Col_Consignee.Width, Line_Height, "CONSIGNEE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            }
            pdf.AddText(currentY, Col_Pcs.Left, Col_Pcs.Width, Line_Height, "PCS", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Wt.Left, Col_Wt.Width, Line_Height, "WT", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_ChWt.Left, Col_ChWt.Width, Line_Height, "CH.WT", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });

            currentY += Line_Height;

            return currentY;
        }
        private void WriteFooter()
        {
            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name} ";//PAGE#: {PageNumber}

            Row = MaxRec_Height;//for footer print details(fixed)
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, printInfo, new TextFormat { Border = "T", FontSize = 9 });
            Row += Line_Height;
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, $"PAGE#: {PageNumber}", new TextFormat { Border = "", FontSize = 9 });
        }

    }
}
