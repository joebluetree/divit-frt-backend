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
        public string DateType { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string ShipperName { get; set; } = "";
        public string ConsigneeName { get; set; } = "";
        public string AgentName { get; set; } = "";
        public string UserRole { get; set; } = "";
        public string handledBy { get; set; } = "";
        public string Format { get; set; } = "";
        public string CreatedBy { get; set; } = "";
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

        private ColumnFormat Col_RefNo = new();
        private ColumnFormat Col_HouseNo = new();
        private ColumnFormat Col_ShipStage = new();
        private ColumnFormat Col_Carrier = new();
        private ColumnFormat Col_Consignee = new();
        private ColumnFormat Col_BookingNo = new();
        private ColumnFormat Col_CntrType = new();
        private ColumnFormat Col_ETD = new();
        private ColumnFormat Col_ISF = new();
        private ColumnFormat Col_Mrls = new();
        private ColumnFormat Col_Hrls = new();
        private ColumnFormat Col_pl = new();
        private ColumnFormat Col_ci = new();
        private ColumnFormat Col_CarAn = new();
        private ColumnFormat Col_CRStatus = new();
        private ColumnFormat Col_FRStatus = new();
        private ColumnFormat Col_ClientPaid = new();
        private ColumnFormat Col_ETA = new();
        private ColumnFormat Col_LFD = new();
        private ColumnFormat Col_Delivery = new();
        private ColumnFormat Col_DeliveryDate = new();
       

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
                File_Display_Name = $"{Title!.ToLower()} {OpGroup!.ToLower()}";
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
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            
            this.Page_Height = 500;
            this.Row_Width = 800;
            this.MaxRec_Height = 550;

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
                LastRow = i == recordCount;
                
                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };


                float rowHeight = Line_Height;
                float HouseHT = pdf.MeasureWrappedTextHeight(Row, Col_HouseNo.Left, Col_HouseNo.Width, Line_Height, dr.mbl_houseno!, format);
                float ShipstageHT = pdf.MeasureWrappedTextHeight(Row, Col_ShipStage.Left, Col_ShipStage.Width, Line_Height, dr.mbl_shipstage!, format);
                float CarrierHT = pdf.MeasureWrappedTextHeight(Row, Col_Carrier.Left, Col_Carrier.Width, Line_Height, dr.mbl_liner_name!, format);
                float ConsigneeHT = pdf.MeasureWrappedTextHeight(Row, Col_Consignee.Left, Col_Consignee.Width, Line_Height, dr.mbl_consignee_name!, format);
                float TypeHT = pdf.MeasureWrappedTextHeight(Row, Col_CntrType.Left, Col_CntrType.Width, Line_Height, dr.mbl_cntr_type!, format);
                float MrlsHT = pdf.MeasureWrappedTextHeight(Row, Col_Mrls.Left, Col_Mrls.Width, Line_Height, dr.mbl_mstatus!, format);
                // float HrlsHT = pdf.MeasureWrappedTextHeight(Row, Col_Hrls.Left, Col_Hrls.Width, Line_Height, dr.mbl_hstatus!, format);
                float CRStatusHT = pdf.MeasureWrappedTextHeight(Row, Col_CRStatus.Left, Col_CRStatus.Width, Line_Height, dr.mbl_custom_reles_status!, format);
                float FRStatusHT = pdf.MeasureWrappedTextHeight(Row, Col_FRStatus.Left, Col_FRStatus.Width, Line_Height, dr.mbl_frt_status_name!, format);
                float ClientHT = pdf.MeasureWrappedTextHeight(Row, Col_ClientPaid.Left, Col_ClientPaid.Width, Line_Height, dr.mbl_paid_status!, format);
                float DeliveryHT = pdf.MeasureWrappedTextHeight(Row, Col_Delivery.Left, Col_Delivery.Width, Line_Height, dr.mbl_is_delivery!, format);

                rowHeight = new[] { HouseHT, ShipstageHT, CarrierHT, ConsigneeHT, TypeHT, MrlsHT, CRStatusHT, FRStatusHT, ClientHT, DeliveryHT, Line_Height}.Max();

                printHeader = CommonLib.IsPageBreak(Row, rowHeight, MaxRec_Height);
                if (printHeader)
                {
                    WriteFooter(Row, Col_Default);
                    Row = WriteHeader(Row_Default, Col_Default);
                }
                
                var mbl_etd = Lib.FormatDate(Lib.ParseDate(dr.mbl_pol_etd!), Lib.DisplayDateFormat) ?? "";
                var mbl_eta = Lib.FormatDate(Lib.ParseDate(dr.mbl_pod_eta!), Lib.DisplayDateFormat) ?? "";
                var mbl_lfd = Lib.FormatDate(Lib.ParseDate(dr.mbl_lfd!), Lib.DisplayDateFormat) ?? "";
                var mbl_delivery_date = Lib.FormatDate(Lib.ParseDate(dr.hbl_plf_eta!), Lib.DisplayDateFormat) ?? "";
                int detFontSize = 7;

                if(OpGroup == "SEA EXPORT")
                {
                    pdf.AddText(Row, Col_RefNo.Left, Col_RefNo.Width, rowHeight, dr.mbl_refno!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_HouseNo.Left, Col_HouseNo.Width, rowHeight, dr.mbl_houseno!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ShipStage.Left, Col_ShipStage.Width, rowHeight, dr.mbl_shipstage!.ToUpper(), new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_Carrier.Left, Col_Carrier.Width, rowHeight, dr.mbl_liner_name!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_Consignee.Left, Col_Consignee.Width, rowHeight, dr.mbl_consignee_name!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_CntrType.Left, Col_CntrType.Width, rowHeight, dr.mbl_cntr_type!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ETD.Left, Col_ETD.Width, rowHeight, mbl_etd.ToUpper(), new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_FRStatus.Left, Col_FRStatus.Width, rowHeight, dr.mbl_frt_status_name!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ETA.Left, Col_ETA.Width, rowHeight, mbl_eta.ToUpper()!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                }
                if(OpGroup == "SEA IMPORT")
                {
                    pdf.AddText(Row, Col_RefNo.Left, Col_RefNo.Width, rowHeight, dr.mbl_refno!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_HouseNo.Left, Col_HouseNo.Width, rowHeight, dr.mbl_houseno!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ShipStage.Left, Col_ShipStage.Width, rowHeight, dr.mbl_shipstage!.ToUpper(), new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_Carrier.Left, Col_Carrier.Width, rowHeight, dr.mbl_liner_name!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_Consignee.Left, Col_Consignee.Width, rowHeight, dr.mbl_consignee_name!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_CntrType.Left, Col_CntrType.Width, rowHeight, dr.mbl_cntr_type!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ETD.Left, Col_ETD.Width, rowHeight, mbl_etd.ToUpper(), new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_Mrls.Left, Col_Mrls.Width, rowHeight, dr.mbl_mstatus!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_CarAn.Left, Col_CarAn.Width, rowHeight, dr.mbl_is_carr_an!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_CRStatus.Left, Col_CRStatus.Width, rowHeight, dr.mbl_custom_reles_status!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_FRStatus.Left, Col_FRStatus.Width, rowHeight, dr.mbl_frt_status_name!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ClientPaid.Left, Col_ClientPaid.Width, rowHeight, dr.mbl_paid_status!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ETA.Left, Col_ETA.Width, rowHeight, mbl_eta.ToUpper()!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                }
                if(OpGroup == "AIR EXPORT")
                {
                    pdf.AddText(Row, Col_RefNo.Left, Col_RefNo.Width, rowHeight, dr.mbl_refno!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_HouseNo.Left, Col_HouseNo.Width, rowHeight, dr.mbl_houseno!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ShipStage.Left, Col_ShipStage.Width, rowHeight, dr.mbl_shipstage!.ToUpper(), new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_Carrier.Left, Col_Carrier.Width, rowHeight, dr.mbl_liner_name!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_Consignee.Left, Col_Consignee.Width, rowHeight, dr.mbl_consignee_name!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ETD.Left, Col_ETD.Width, rowHeight, mbl_etd.ToUpper(), new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ETA.Left, Col_ETA.Width, rowHeight, mbl_eta.ToUpper()!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    // pdf.AddText(Row, Col_LFD.Left, Col_LFD.Width, rowHeight, mbl_lfd.ToUpper()!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    // pdf.AddText(Row, Col_DeliveryDate.Left, Col_DeliveryDate.Width, rowHeight, mbl_delivery_date.ToUpper()!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                }
                if(OpGroup == "AIR IMPORT")
                {
                    pdf.AddText(Row, Col_RefNo.Left, Col_RefNo.Width, rowHeight, dr.mbl_refno!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_HouseNo.Left, Col_HouseNo.Width, rowHeight, dr.mbl_houseno!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ShipStage.Left, Col_ShipStage.Width, rowHeight, dr.mbl_shipstage!.ToUpper(), new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_Carrier.Left, Col_Carrier.Width, rowHeight, dr.mbl_liner_name!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_Consignee.Left, Col_Consignee.Width, rowHeight, dr.mbl_consignee_name!, new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ETD.Left, Col_ETD.Width, rowHeight, mbl_etd.ToUpper(), new TextFormat { Border = BL, Style = "" + ST, FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_pl.Left, Col_pl.Width, rowHeight, dr.mbl_is_pl!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ci.Left, Col_ci.Width, rowHeight, dr.mbl_is_ci!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_CarAn.Left, Col_CarAn.Width, rowHeight, dr.mbl_is_carr_an!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_CRStatus.Left, Col_CRStatus.Width, rowHeight, dr.mbl_custom_reles_status!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_FRStatus.Left, Col_FRStatus.Width, rowHeight, dr.mbl_frt_status_name!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ClientPaid.Left, Col_ClientPaid.Width, rowHeight, dr.mbl_paid_status!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    pdf.AddText(Row, Col_ETA.Left, Col_ETA.Width, rowHeight, mbl_eta.ToUpper()!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    // pdf.AddText(Row, Col_LFD.Left, Col_LFD.Width, rowHeight, mbl_lfd.ToUpper()!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                    // pdf.AddText(Row, Col_DeliveryDate.Left, Col_DeliveryDate.Width, rowHeight, mbl_delivery_date.ToUpper()!, new TextFormat { Border = BL, Style = "", FontSize = detFontSize, Indent = true });
                }
                
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
            pdf.AddText(currentY, Col, Row_Width, Line_Height, Title.ToUpper() + $"  -  {OpGroup}", new TextFormat { Border = "TB", Style = "B", FontSize = 10 });//+ " LIST"
            currentY += Line_Height + 5;
            int halfWidth = Row_Width / 2;
            int quaterWidth = halfWidth / 2;

            float LeftY = currentY;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "DATE TYPE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, DateType, new TextFormat { Style = "B", FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "FROM DATE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SFromDate.ToUpper(), new TextFormat { Style = "B", FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "TO DATE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SToDate.ToUpper(), new TextFormat { Style = "B", FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, Row_Width, Line_Height, "AGENT", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, AgentName, new TextFormat { Style = "B", FontSize = 10 });
            // LeftY += Line_Height;
            // pdf.AddText(LeftY, Col, Row_Width, Line_Height, "REPORT TYPE", new TextFormat { Style = "B", FontSize = 10 });
            // pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            // pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ReportType, new TextFormat { Style = "B", FontSize = 10 });

            float RightY = currentY;
            var RightCol = Col + halfWidth;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "SHIPPER", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ShipperName, new TextFormat { Style = "B", FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "CONSIGNEE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ConsigneeName, new TextFormat { Style = "B", FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, UserRole.ToUpper(), new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, handledBy, new TextFormat { Style = "B", FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "CREATED BY", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, CreatedBy, new TextFormat { Style = "B", FontSize = 10 });

            currentY = RightY >= LeftY ? RightY : LeftY;
            currentY += Line_Height + 5;

            // Table Header
            int hedFontSize = 8;

            if(OpGroup == "SEA EXPORT")
            {   
                this.Col_RefNo = new ColumnFormat { Left = 30, Width = 60 };
                this.Col_HouseNo = new ColumnFormat { Left = 90, Width = 80 };
                this.Col_ShipStage = new ColumnFormat { Left = 170, Width = 110 };
                this.Col_Carrier = new ColumnFormat { Left = 280, Width = 150 };
                this.Col_Consignee = new ColumnFormat { Left = 430, Width = 150 };
                this.Col_CntrType = new ColumnFormat { Left = 580, Width = 50 };
                this.Col_ETD = new ColumnFormat { Left = 630, Width = 60 };
                // this.Col_CarAn = new ColumnFormat { Left = 542, Width = 60 };
                // this.Col_CRStatus = new ColumnFormat { Left = 602, Width = 70 };
                this.Col_FRStatus = new ColumnFormat { Left = 690, Width = 80 };
                // this.Col_ClientPaid = new ColumnFormat { Left = 742, Width = 33 };
                this.Col_ETA = new ColumnFormat { Left = 770, Width = 60 };
                
                pdf.AddText(currentY, Col_RefNo.Left, Col_RefNo.Width, Line_Height, "REFNO", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_HouseNo.Left, Col_HouseNo.Width, Line_Height, "HOUSE#", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ShipStage.Left, Col_ShipStage.Width, Line_Height, "SHIPMENT STAGE", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_Carrier.Left, Col_Carrier.Width, Line_Height, "CARRIER", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_Consignee.Left, Col_Consignee.Width, Line_Height, "CONSIGNEE", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_CntrType.Left, Col_CntrType.Width, Line_Height, "TYPE", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ETD.Left, Col_ETD.Width, Line_Height, "ETD", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                // pdf.AddText(currentY, Col_CarAn.Left, Col_CarAn.Width, Line_Height, "CARRIER AN", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                // pdf.AddText(currentY, Col_CRStatus.Left, Col_CRStatus.Width, Line_Height, "CR-STATUS", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_FRStatus.Left, Col_FRStatus.Width, Line_Height, "FR-STATUS", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                // pdf.AddText(currentY, Col_ClientPaid.Left, Col_ClientPaid.Width, Line_Height, "PAID", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ETA.Left, Col_ETA.Width, Line_Height, "ETA", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                // pdf.AddText(currentY, Col_Delivery.Left, Col_Delivery.Width, Line_Height, "DELIVERY", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true }); //y/n
            }
            if(OpGroup == "SEA IMPORT")
            {   
                this.Col_RefNo = new ColumnFormat { Left = 30, Width = 55 };
                this.Col_HouseNo = new ColumnFormat { Left = 85, Width = 67 };
                this.Col_ShipStage = new ColumnFormat { Left = 152, Width = 75 };
                this.Col_Carrier = new ColumnFormat { Left = 227, Width = 75 };
                this.Col_Consignee = new ColumnFormat { Left = 302, Width = 75 };
                this.Col_CntrType = new ColumnFormat { Left = 377, Width = 45 };
                this.Col_ETD = new ColumnFormat { Left = 422, Width = 60 };
                this.Col_Mrls = new ColumnFormat { Left = 482, Width = 90 };
                this.Col_CarAn = new ColumnFormat { Left = 572, Width = 50 };
                this.Col_CRStatus = new ColumnFormat { Left = 622, Width = 60 };
                this.Col_FRStatus = new ColumnFormat { Left = 682, Width = 60 };
                this.Col_ClientPaid = new ColumnFormat { Left = 742, Width = 33 };
                this.Col_ETA = new ColumnFormat { Left = 775, Width = 55 };
                
                pdf.AddText(currentY, Col_RefNo.Left, Col_RefNo.Width, Line_Height, "REFNO", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_HouseNo.Left, Col_HouseNo.Width, Line_Height, "HOUSE#", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ShipStage.Left, Col_ShipStage.Width, Line_Height, "SHIPMENT STAGE", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_Carrier.Left, Col_Carrier.Width, Line_Height, "CARRIER", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_Consignee.Left, Col_Consignee.Width, Line_Height, "CONSIGNEE", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_CntrType.Left, Col_CntrType.Width, Line_Height, "TYPE", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ETD.Left, Col_ETD.Width, Line_Height, "ETD", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_Mrls.Left, Col_Mrls.Width, Line_Height, "M RLS", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_CarAn.Left, Col_CarAn.Width, Line_Height, "CARRIER-AN", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_CRStatus.Left, Col_CRStatus.Width, Line_Height, "CR-STATUS", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_FRStatus.Left, Col_FRStatus.Width, Line_Height, "FR-STATUS", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ClientPaid.Left, Col_ClientPaid.Width, Line_Height, "PAID", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ETA.Left, Col_ETA.Width, Line_Height, "ETA", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                // pdf.AddText(currentY, Col_Delivery.Left, Col_Delivery.Width, Line_Height, "DELIVERY", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true }); //y/n
            }
            if(OpGroup == "AIR EXPORT")
            {   
                this.Col_RefNo = new ColumnFormat { Left = 30, Width = 60 };
                this.Col_HouseNo = new ColumnFormat { Left = 90, Width = 90 };
                this.Col_ShipStage = new ColumnFormat { Left = 180, Width = 150 };
                this.Col_Carrier = new ColumnFormat { Left = 330, Width = 180 };
                this.Col_Consignee = new ColumnFormat { Left = 510, Width = 180};
                this.Col_ETD = new ColumnFormat { Left = 690, Width = 70};
                this.Col_ETA = new ColumnFormat { Left = 760, Width = 70 };
                // this.Col_LFD = new ColumnFormat { Left = 710, Width = 60 };
                // this.Col_DeliveryDate = new ColumnFormat { Left = 770, Width = 60 };
                
                pdf.AddText(currentY, Col_RefNo.Left, Col_RefNo.Width, Line_Height, "REFNO", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_HouseNo.Left, Col_HouseNo.Width, Line_Height, "HOUSE#", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ShipStage.Left, Col_ShipStage.Width, Line_Height, "SHIPMENT STAGE", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_Carrier.Left, Col_Carrier.Width, Line_Height, "CARRIER", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_Consignee.Left, Col_Consignee.Width, Line_Height, "CONSIGNEE", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ETD.Left, Col_ETD.Width, Line_Height, "ETD", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ETA.Left, Col_ETA.Width, Line_Height, "ETA", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                // pdf.AddText(currentY, Col_LFD.Left, Col_LFD.Width, Line_Height, "LFD", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                // pdf.AddText(currentY, Col_DeliveryDate.Left, Col_DeliveryDate.Width, Line_Height, "DELIVERY-DATE", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
            }
            if(OpGroup == "AIR IMPORT")
            {   
                this.Col_RefNo = new ColumnFormat { Left = 30, Width = 55 };
                this.Col_HouseNo = new ColumnFormat { Left = 85, Width = 70 };
                this.Col_ShipStage = new ColumnFormat { Left = 155, Width = 75 };
                this.Col_Carrier = new ColumnFormat { Left = 230, Width = 75 };
                this.Col_Consignee = new ColumnFormat { Left = 305, Width = 85 };
                this.Col_ETD = new ColumnFormat { Left = 390, Width = 60 };
                this.Col_pl = new ColumnFormat { Left = 450, Width = 40 };
                this.Col_ci = new ColumnFormat { Left = 490, Width = 40 };
                this.Col_CarAn = new ColumnFormat { Left = 530, Width = 60 };
                this.Col_CRStatus = new ColumnFormat { Left = 590, Width = 70 };
                this.Col_FRStatus = new ColumnFormat { Left = 660, Width = 70 };
                this.Col_ClientPaid = new ColumnFormat { Left = 730, Width = 50 };
                this.Col_ETA = new ColumnFormat { Left = 780, Width = 60 };
                
                pdf.AddText(currentY, Col_RefNo.Left, Col_RefNo.Width, Line_Height, "REFNO", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_HouseNo.Left, Col_HouseNo.Width, Line_Height, "HOUSE#", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ShipStage.Left, Col_ShipStage.Width, Line_Height, "SHIPMENT STAGE", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_Carrier.Left, Col_Carrier.Width, Line_Height, "CARRIER", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_Consignee.Left, Col_Consignee.Width, Line_Height, "CONSIGNEE", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ETD.Left, Col_ETD.Width, Line_Height, "ETD", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_pl.Left, Col_pl.Width, Line_Height, "PL", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ci.Left, Col_ci.Width, Line_Height, "CI", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_CarAn.Left, Col_CarAn.Width, Line_Height, "CARRIER-AN", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_CRStatus.Left, Col_CRStatus.Width, Line_Height, "CR-STATUS", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_FRStatus.Left, Col_FRStatus.Width, Line_Height, "FR-STATUS", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ClientPaid.Left, Col_ClientPaid.Width, Line_Height, "PAID", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                pdf.AddText(currentY, Col_ETA.Left, Col_ETA.Width, Line_Height, "ETA", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true });
                // pdf.AddText(currentY, Col_Delivery.Left, Col_Delivery.Width, Line_Height, "DELIVERY", new TextFormat { Border = "TB", Style = "B", FontSize = hedFontSize, Indent = true }); //y/n
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
