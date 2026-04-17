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
    public class ShipmentLogPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<rep_shipmentlog_dto> Dt_List { get; set; } = new List<rep_shipmentlog_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string Format { get; set; } = "";
        public string ReportType { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string Salesman { get; set; } = "";
        public string Parent { get; set; } = "";
        public string Agent { get; set; } = "";
        public string PartyName { get; set; } = "";
        public string ProfitCriteria { get; set; } = "";
        public string ProfitVal { get; set; } = "";
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

        private ColumnFormat Col_RefNo = new();
        private ColumnFormat Col_HouseNo = new();
        private ColumnFormat Col_ShipStage = new();
        private ColumnFormat Col_Carrier = new();
        private ColumnFormat Col_Consignee = new();
        private ColumnFormat Col_BookingNo = new();
        private ColumnFormat Col_CntrType = new();
        private ColumnFormat Col_ETA = new();
       

        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header



        public ShipmentLogPdfFile()
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
            PageSize = "LANDSCAPE";

            // if(Format == "GENERAL" && ReportType == "MASTER") PageSize = "LANDSCAPE";
            return PageSize;
        }
        private void Writedocument()
        {
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            
            this.Page_Height = 500;
            this.Row_Width = 800;
            this.MaxRec_Height = 500;

            // this.Col_RefNo = new ColumnFormat { Left = 30, Width = 70 };
            // this.Col_HouseNo = new ColumnFormat { Left = 100, Width = 70 };
            // this.Col_ShipStage = new ColumnFormat { Left = 170, Width = 80 };
            // this.Col_Carrier = new ColumnFormat { Left = 250, Width = 70 };
            // this.Col_BookingNo = new ColumnFormat { Left = 320, Width = 70 };
            // this.Col_Consignee = new ColumnFormat { Left = 390, Width = 70 };
            // this.Col_CntrType = new ColumnFormat { Left = 530, Width = 50 };
            // this.Col_ETA = new ColumnFormat { Left = 580, Width = 25 };


            this.Col_Column = new ColumnFormat { Left = 80, Width = 10 };// ':'
            this.Col_Head_data = new ColumnFormat { Left = 90, Width = 100 };

            pdf.CreateDocument(File_Name, "LANDSCAPE");
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

            foreach (rep_shipmentlog_dto dr in Dt_List)
            {
                i++;
                // printHeader = CommonLib.IsPageBreak(Row, Line_Height, MaxRec_Height);
                LastRow = i == recordCount;
                bool isTotal = dr.mbl_refno == "TOTAL";
                BL = isTotal ? "TB" : "b";
                ST = isTotal ? "B" : "";

                BL = LastRow ? "TB": BL;
                ST = LastRow ? "B" : ST;// style bold
                
                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };
                float AgentHeight = 0;
                float CarrierHeight = 0;
                float ShipperHeight = 0;
                float ConsigneeHeight = 0;

                float rowHeight = Line_Height;

                rowHeight = new[] { AgentHeight, CarrierHeight, ShipperHeight, ConsigneeHeight, Line_Height}.Max();

                printHeader = CommonLib.IsPageBreak(Row, rowHeight, MaxRec_Height);
                if (printHeader)
                {
                    WriteFooter(Row, Col_Default);
                    Row = WriteHeader(Row_Default, Col_Default);
                }
                
                var mbl_eta = Lib.FormatDate(Lib.ParseDate(dr.mbl_pod_eta!), Lib.DisplayDateFormat) ?? "";

                if (ReportType == "MASTER")
                {
                    pdf.AddText(Row, Col_RefNo.Left, Row_Width, Line_Height,"AGENT " + dr.mbl_agent_name!, new TextFormat { Border = "T" + BL, Style = "B" + ST, FontSize = 9, Indent = true });
                }
                pdf.AddText(Row, Col_RefNo.Left, Col_RefNo.Width, rowHeight, dr.mbl_refno!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_HouseNo.Left, Col_HouseNo.Width, rowHeight, dr.mbl_houseno!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_ShipStage.Left, Col_ShipStage.Width, rowHeight, dr.mbl_shipstage!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Carrier.Left, Col_Carrier.Width, rowHeight, dr.mbl_liner_name!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_BookingNo.Left, Col_BookingNo.Width, rowHeight, dr.mbl_liner_bookingno!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Consignee.Left, Col_Consignee.Width, rowHeight, dr.mbl_consignee_name!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_CntrType.Left, Col_CntrType.Width, rowHeight, dr.mbl_cntr_type!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_ETA.Left, Col_ETA.Width, rowHeight, mbl_eta.ToUpper(), new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                
                Row += rowHeight;
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
            int quaterWidth = halfWidth / 2;

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
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, Row_Width, Line_Height, "REPORT TYPE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ReportType, new TextFormat { Style = "B", FontSize = 10 });

            float RightY = currentY;
            var RightCol = Col + halfWidth;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "SALESMAN", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Salesman, new TextFormat { Style = "B", FontSize = 10 });
            if(Format == "AGENT")
            {
                RightY += Line_Height;
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "PARENT", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Parent, new TextFormat { Style = "B", FontSize = 10 });
                RightY += Line_Height;
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "AGENT", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Agent, new TextFormat { Style = "B", FontSize = 10 });
            }
            if(Format == "PARTY")
            {
                RightY += Line_Height;
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "PARENT", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Parent, new TextFormat { Style = "B", FontSize = 10 });
                RightY += Line_Height;
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "BILLING-PARTY", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, PartyName, new TextFormat { Style = "B", FontSize = 10 });
            }
            if(ProfitCriteria != "NIL")
            {
                RightY += Line_Height;
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "CRITERIA", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, 200, Line_Height, $"{ProfitCriteria} {ProfitVal}" , new TextFormat { Style = "B", FontSize = 10 });
                RightY += Line_Height;
            }

            currentY = LeftY;
            currentY += Line_Height + 5;

            // Table Header

            if(Format == "F1")
            {   
                this.Col_RefNo = new ColumnFormat { Left = 30, Width = 70 };
                this.Col_HouseNo = new ColumnFormat { Left = 100, Width = 70 };
                this.Col_ShipStage = new ColumnFormat { Left = 170, Width = 80 };
                this.Col_Carrier = new ColumnFormat { Left = 250, Width = 70 };
                this.Col_BookingNo = new ColumnFormat { Left = 320, Width = 70 };
                this.Col_Consignee = new ColumnFormat { Left = 390, Width = 70 };
                this.Col_CntrType = new ColumnFormat { Left = 530, Width = 50 };
                this.Col_ETA = new ColumnFormat { Left = 580, Width = 25 };
                
                pdf.AddText(currentY, Col_RefNo.Left, Col_RefNo.Width, Line_Height, "REFNO", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_HouseNo.Left, Col_HouseNo.Width, Line_Height, "HOUSE#", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_ShipStage.Left, Col_ShipStage.Width, Line_Height, "SHIPMENT-STAGE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Carrier.Left, Col_Carrier.Width, Line_Height, "CARRIER", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_BookingNo.Left, Col_BookingNo.Width, Line_Height, "BOOKING#", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Consignee.Left, Col_Consignee.Width, Line_Height, "CONSIGNEE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_CntrType.Left, Col_CntrType.Width, Line_Height, "TYPE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_ETA.Left, Col_ETA.Width, Line_Height, "ETA", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            }
            
            currentY += Line_Height;

            return currentY;
        }
        private void WriteFooter(float rowIndex, float colIndex)
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
