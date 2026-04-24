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
    public class SeaVolumePdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<rep_seavolume_dto> Dt_List { get; set; } = new List<rep_seavolume_dto>();
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
        private ColumnFormat Col_Type = new();
        private ColumnFormat Col_20 = new();
        private ColumnFormat Col_40 = new();
        private ColumnFormat Col_40hc = new();
        private ColumnFormat Col_45 = new();
        private ColumnFormat Col_Teu = new();
        private ColumnFormat Col_Cbm = new();
        private ColumnFormat Col_Carrier = new();
        private ColumnFormat Col_Shipper = new();
        private ColumnFormat Col_Consignee = new();

        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header



        public SeaVolumePdfFile()
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
                this.MaxRec_Height = 480;

                this.Col_Code = new ColumnFormat { Left = 30, Width = 60 };
                this.Col_date = new ColumnFormat { Left = 90, Width = 60 };
                this.Col_Agent = new ColumnFormat { Left = 150, Width = 105 };
                this.Col_Type = new ColumnFormat { Left = 255, Width = 60 };
                this.Col_Carrier = new ColumnFormat { Left = 315, Width = 100 };
                this.Col_Shipper = new ColumnFormat { Left = 415, Width = 105 };
                this.Col_Consignee = new ColumnFormat { Left = 520, Width = 105 };
                this.Col_20 = new ColumnFormat { Left = 625, Width = 30 };
                this.Col_40 = new ColumnFormat { Left = 655, Width = 30 };
                this.Col_40hc = new ColumnFormat { Left = 685, Width = 35 };
                this.Col_45 = new ColumnFormat { Left = 720, Width = 30 };
                this.Col_Teu = new ColumnFormat { Left = 750, Width = 40 };
                this.Col_Cbm = new ColumnFormat { Left = 790, Width = 40 };
                
                pdf.CreateDocument(File_Name, "LANDSCAPE");
            }
            if (getPageSize() == "A4")
            {
                this.Page_Height = 800;
                this.Row_Width = 500;
                this.MaxRec_Height = 770;

                this.Col_Code = new ColumnFormat { Left = 30, Width = 80 };
                this.Col_date = new ColumnFormat { Left = 110, Width = 80 };
                this.Col_Type = new ColumnFormat { Left = 190, Width = 55 };
                this.Col_20 = new ColumnFormat { Left = 245, Width = 45 };
                this.Col_40 = new ColumnFormat { Left = 290, Width = 45 };
                this.Col_40hc = new ColumnFormat { Left = 335, Width = 50 };
                this.Col_45 = new ColumnFormat { Left = 385, Width = 45 };
                this.Col_Teu = new ColumnFormat { Left = 430, Width = 50 };
                this.Col_Cbm = new ColumnFormat { Left = 480, Width = 50 };

                this.Col_Agent = new ColumnFormat { Left = 30, Width = 215 };

                pdf.CreateDocument(File_Name);
            }


            this.Col_Column = new ColumnFormat { Left = 80, Width = 10 };// ':'
            this.Col_Head_data = new ColumnFormat { Left = 90, Width = 100 };

            // pdf.CreateDocument(File_Name);
            CreateReport();
            pdf.CloseDocument();
        }

        private void CreateReport()
        {

            int recordCount = Dt_List.Count;
            bool printHeader = false;
            string BL = "";
            string ST = "";
            bool LastRow = false;

            Row = this.Page_Height;

            Row = WriteHeader(Row_Default, Col_Default);

            int i = 0;

            foreach (rep_seavolume_dto dr in Dt_List)
            {
                i++;
                // printHeader = CommonLib.IsPageBreak(Row, Line_Height, MaxRec_Height);
                LastRow = i == recordCount;
                bool isTotal = dr.mbl_refno == "TOTAL";
                BL = LastRow ? "TB": "b";
                ST = LastRow ? "B" : "";// style bold
                var TotalBorder = isTotal ? "T" : "";
                var TotalStyle = isTotal ? "B" : "";
                
                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };
                
                float AgentHeight = pdf.MeasureWrappedTextHeight(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.mbl_agent_name!, format);
                float CarrierHeight = pdf.MeasureWrappedTextHeight(Row, Col_Carrier.Left, Col_Carrier.Width, Line_Height, dr.mbl_liner_name!, format);
                float ShipperHeight = pdf.MeasureWrappedTextHeight(Row, Col_Shipper.Left, Col_Shipper.Width, Line_Height, dr.mbl_shipper_name!, format);
                float ConsigneeHeight = pdf.MeasureWrappedTextHeight(Row, Col_Consignee.Left, Col_Consignee.Width, Line_Height, dr.mbl_consignee_name!, format);

                float rowHeight = Line_Height;
                if(getPageSize() == "LANDSCAPE")
                {                    
                    rowHeight = new[] { AgentHeight, CarrierHeight, ShipperHeight, ConsigneeHeight, Line_Height}.Max();
                }
                
                printHeader = CommonLib.IsPageBreak(Row, rowHeight, MaxRec_Height);
                if (printHeader)
                {
                    WriteFooter(Row, Col_Default);
                    Row = WriteHeader(Row_Default, Col_Default);
                }

                if (ReportType == "SUMMARY" && !LastRow)
                {
                    if (Format == "AGENT")
                        pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.mbl_agent_name!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                    if (Format == "OPERATION GROUP")
                        pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.mbl_mode!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                }
                if (ReportType == "DETAIL" && !LastRow)
                {
                    var mbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.mbl_ref_date!), Lib.DisplayDateFormat) ?? "";

                    if (Format == "AGENT" && dr.IsAgentTitle == true)
                    {
                        pdf.AddText(Row, Col_Agent.Left, Row_Width, Line_Height, "AGENT  : " + dr.mbl_agent_name!, new TextFormat { Border = "T" + BL, Style = "B" + ST, FontSize = 9, Indent = true });
                    }
                    else
                    {
                        pdf.AddText(Row, Col_Code.Left, Col_Code.Width, rowHeight, dr.mbl_refno!, new TextFormat { Border = BL + TotalBorder, Style = TotalStyle, FontSize = 9, Indent = true });
                        pdf.AddText(Row, Col_date.Left, Col_date.Width, rowHeight, mbl_ref_date.ToUpper()!, new TextFormat { Border = BL + TotalBorder, FontSize = 9, Indent = true });
                        pdf.AddText(Row, Col_Type.Left, Col_Type.Width, rowHeight, dr.mbl_cntr_type!, new TextFormat { Border = BL + TotalBorder, FontSize = 9, Indent = true });                            
                    }
                }
                if (LastRow)
                {
                    pdf.AddText(Row, Col_Code.Left, Col_Code.Width, Line_Height, dr.mbl_agent_name!, new TextFormat { Border = "" + BL, Style = "B",FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_date.Left, Col_date.Width, Line_Height, "", new TextFormat { Border = "" + BL, FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_Type.Left, Col_Type.Width, Line_Height, "", new TextFormat { Border = "" + BL, FontSize = 9, Indent = true });
                }
                if(getPageSize() == "LANDSCAPE")
                {
                    if(LastRow)
                        pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, "", new TextFormat { Border = BL + TotalBorder, Style = "" + TotalStyle + ST, FontSize = 9, Indent = true });
                    if(!LastRow)
                        pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.mbl_agent_name!, new TextFormat { Border = BL + TotalBorder, Style = "" + TotalStyle + ST, FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_Carrier.Left, Col_Carrier.Width, rowHeight, dr.mbl_liner_name!, new TextFormat { Border = BL + TotalBorder, Style = "" + TotalStyle + ST, FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_Shipper.Left, Col_Shipper.Width, rowHeight, dr.mbl_shipper_name!, new TextFormat { Border = BL + TotalBorder, Style = "" + TotalStyle + ST, FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_Consignee.Left, Col_Consignee.Width, rowHeight, dr.mbl_consignee_name!, new TextFormat { Border = BL + TotalBorder, Style = "" + TotalStyle + ST, FontSize = 9, Indent = true });
                }
                pdf.AddText(Row, Col_20.Left, Col_20.Width, rowHeight, dr.mbl_20!, new TextFormat { Border =  BL + TotalBorder, Style = "R" + TotalStyle + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_40.Left, Col_40.Width, rowHeight, dr.mbl_40!, new TextFormat { Border =  BL + TotalBorder, Style = "R" + TotalStyle + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_40hc.Left, Col_40hc.Width, rowHeight, dr.mbl_40hq!, new TextFormat { Border =  BL + TotalBorder, Style = "R" + TotalStyle + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_45.Left, Col_45.Width, rowHeight, dr.mbl_45!, new TextFormat { Border =   BL + TotalBorder, Style = "R" + TotalStyle + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Teu.Left, Col_Teu.Width, rowHeight, dr.mbl_teu!, new TextFormat { Border =  BL + TotalBorder, Style = "R" + TotalStyle + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Cbm.Left, Col_Cbm.Width, rowHeight, dr.mbl_cbm!, new TextFormat { Border =  BL + TotalBorder, Style = "R" + TotalStyle + ST, FontSize = 9, Indent = true });

                Row += rowHeight;

                // if (printHeader)
                // {
                //     WriteFooter(Row, Col_Default);
                //     Row = WriteHeader(Row_Default, Col_Default);
                // }
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
            pdf.AddText(currentY, Col, Row_Width, Line_Height, Title.ToUpper(), new TextFormat { Border = "TB", Style = "B", FontSize = 10 });//+ " LIST"
            currentY += Line_Height + 5;
            int halfWidth = Row_Width / 2;

            float LeftY = currentY;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "FROM DATE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SFromDate.ToUpper(), new TextFormat { Style = "B", FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "TO DATE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SToDate.ToUpper(), new TextFormat { Style = "B", FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, Row_Width, Line_Height, "FORMAT", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Format, new TextFormat { Style = "B", FontSize = 10 });

            float RightY = currentY;
            var RightCol = Col + halfWidth;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "REPORT TYPE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ReportType, new TextFormat { Style = "B", FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "SHIPMENT", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ShipType, new TextFormat { Style = "B", FontSize = 10 });

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
                pdf.AddText(currentY, Col_Type.Left, Col_Type.Width, Line_Height, "TYPE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            }
            if(getPageSize() == "LANDSCAPE")
            {
                pdf.AddText(currentY, Col_Agent.Left, Col_Agent.Width, Line_Height, "AGENT", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Carrier.Left, Col_Carrier.Width, Line_Height, "CARRIER", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Shipper.Left, Col_Shipper.Width, Line_Height, "SHIPPER", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Consignee.Left, Col_Consignee.Width, Line_Height, "CONSIGNEE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            }
            pdf.AddText(currentY, Col_20.Left, Col_20.Width, Line_Height, "20", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_40.Left, Col_40.Width, Line_Height, "40", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_40hc.Left, Col_40hc.Width, Line_Height, "40HC", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_45.Left, Col_45.Width, Line_Height, "45", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Teu.Left, Col_Teu.Width, Line_Height, "TEU", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Cbm.Left, Col_Cbm.Width, Line_Height, "CBM", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });

            currentY += Line_Height;

            return currentY;
        }
        private void WriteFooter(float rowIndex, float colIndex)
        {
            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name} ";//PAGE#: {PageNumber}
            //need to add seprate total from different type
            if (rowIndex + Line_Height < MaxRec_Height)
            {
                // rowIndex += Line_Height;
                // pdf.AddText(rowIndex, Col_Default, Row_Width, Line_Height, printInfo, new TextFormat { Border = "T", FontSize = 9 });
            }

            Row = MaxRec_Height;//for footer print details(fixed)
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, printInfo, new TextFormat { Border = "T", FontSize = 9 });
            Row += Line_Height;
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, $"PAGE#: {PageNumber}", new TextFormat { Border = "", FontSize = 9 });
        }

    }
}
