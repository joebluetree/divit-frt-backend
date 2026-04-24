using System;
using System.Data;
using Common.DTO.OtherOp;
using Common.DTO.Report;
using Common.DTO.Tnt;
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
    public class AgentShipmentPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<rep_agentship_dto> Dt_List { get; set; } = new List<rep_agentship_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string ShipperName { get; set; } = "";
        public string ParentName { get; set; } = "";
        public string AgentName { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string ConsigneeName { get; set; } = "";
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
        private ColumnFormat Col_Refdate = new();
        private ColumnFormat Col_Agent = new();
        private ColumnFormat Col_Shipper = new();
        private ColumnFormat Col_Consignee = new();
        private ColumnFormat Col_Carrier = new();
        private ColumnFormat Col_Vessel = new();
        private ColumnFormat Col_Voyage = new();
        private ColumnFormat Col_Pol = new();
        private ColumnFormat Col_Pod = new();
        private ColumnFormat Col_MblNo = new();
        private ColumnFormat Col_HblNo = new();
        private ColumnFormat Col_CntrNo = new();
        private ColumnFormat Col_CntrType = new();
        private ColumnFormat Col_CntrSeal = new();
        
        

        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header



        public AgentShipmentPdfFile()
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
        private void Writedocument()
        {
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            this.Page_Height = 500;
            this.Row_Width = 800;
            this.MaxRec_Height = 510;
            
            if(OpGroup == "SEA EXPORT" || OpGroup == "SEA IMPORT")
            {
                this.Col_Refno = new ColumnFormat { Left = 30, Width = 60 };
                this.Col_Refdate = new ColumnFormat { Left = 90, Width = 60 };
                this.Col_Agent = new ColumnFormat { Left = 150, Width = 70 };
                this.Col_Shipper = new ColumnFormat { Left = 220, Width = 70 };
                this.Col_Consignee = new ColumnFormat { Left = 290, Width = 70 };
                this.Col_Carrier = new ColumnFormat { Left = 360, Width = 60 };
                this.Col_Vessel = new ColumnFormat { Left = 420, Width = 50 };
                this.Col_Voyage = new ColumnFormat { Left = 470, Width = 50 };
                this.Col_Pol = new ColumnFormat { Left = 520, Width = 45 };
                this.Col_Pod = new ColumnFormat { Left = 565, Width = 45 };
                this.Col_MblNo = new ColumnFormat { Left = 610, Width = 40 };
                this.Col_HblNo = new ColumnFormat { Left = 650, Width = 40 };
                this.Col_CntrNo = new ColumnFormat { Left = 690, Width = 60 };
                this.Col_CntrType = new ColumnFormat { Left = 750, Width = 40 };
                this.Col_CntrSeal = new ColumnFormat { Left = 790, Width = 40 };
            }
            if(OpGroup == "AIR EXPORT" || OpGroup == "AIR IMPORT")
            {
                this.Col_Refno = new ColumnFormat { Left = 30, Width = 60 };
                this.Col_Refdate = new ColumnFormat { Left = 90, Width = 60 };
                this.Col_Agent = new ColumnFormat { Left = 150, Width = 90 };
                this.Col_Shipper = new ColumnFormat { Left = 240, Width = 90 };
                this.Col_Consignee = new ColumnFormat { Left = 330, Width = 90 };
                this.Col_Carrier = new ColumnFormat { Left = 420, Width = 70 };
                this.Col_Vessel = new ColumnFormat { Left = 490, Width = 60 };
                this.Col_Voyage = new ColumnFormat { Left = 550, Width = 60 };
                this.Col_Pol = new ColumnFormat { Left = 610, Width = 60 };
                this.Col_Pod = new ColumnFormat { Left = 670, Width = 60 };
                this.Col_MblNo = new ColumnFormat { Left = 730, Width = 50 };
                this.Col_HblNo = new ColumnFormat { Left = 780, Width = 50 };
            }
            
            this.Col_Column = new ColumnFormat { Left = 80, Width = 10 };// ':'
            this.Col_Head_data = new ColumnFormat { Left = 90, Width = 300 };

            pdf.CreateDocument(File_Name, "LANDSCAPE");
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

            foreach (rep_agentship_dto dr in Dt_List)
            {
                i++;

                BL = i == recordCount ? "B" : "b";

                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };

                float AgentHeight = pdf.MeasureWrappedTextHeight(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.hbl_agent_name!, format);
                float ShipperHeight = pdf.MeasureWrappedTextHeight(Row, Col_Shipper.Left, Col_Shipper.Width, Line_Height, dr.hbl_shipper_name!, format);
                float ConsigneeHeight = pdf.MeasureWrappedTextHeight(Row, Col_Consignee.Left, Col_Consignee.Width, Line_Height, dr.hbl_consignee_name!, format);
                float CarrierHeight = pdf.MeasureWrappedTextHeight(Row, Col_Carrier.Left, Col_Carrier.Width, Line_Height, dr.hbl_liner_name!, format);
                float VesselHeight = pdf.MeasureWrappedTextHeight(Row, Col_Vessel.Left, Col_Vessel.Width, Line_Height, dr.hbl_vessel_name!, format);
                float VoyageHeight = pdf.MeasureWrappedTextHeight(Row, Col_Voyage.Left, Col_Voyage.Width, Line_Height, dr.hbl_voyage!, format);
                float PolHeight = pdf.MeasureWrappedTextHeight(Row, Col_Pol.Left, Col_Pol.Width, Line_Height, dr.hbl_pol_name!, format);
                float PodHeight = pdf.MeasureWrappedTextHeight(Row, Col_Pod.Left, Col_Pod.Width, Line_Height, dr.hbl_pod_name!, format);
                float SealHeight = pdf.MeasureWrappedTextHeight(Row, Col_CntrSeal.Left, Col_CntrSeal.Width, Line_Height, dr.hbl_cntr_sealno!, format);

                float rowHeight = new[] { AgentHeight, ShipperHeight, ConsigneeHeight, CarrierHeight, VesselHeight, VoyageHeight, PolHeight, PodHeight, SealHeight, Line_Height}.Max();

                printHeader = CommonLib.IsPageBreak(Row, rowHeight, MaxRec_Height);
                if (printHeader)
                {
                    WriteFooter(Row, Col_Default);
                    Row = WriteHeader(Row_Default, Col_Default);
                }
                var hbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.hbl_ref_date!), Lib.DisplayDateFormat) ?? "";

                pdf.AddText(Row, Col_Refno.Left, Col_Refno.Width, rowHeight, dr.hbl_mbl_refno!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Refdate.Left, Col_Refdate.Width, rowHeight, hbl_ref_date.ToUpper()!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.hbl_agent_name!, new TextFormat { Border = BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Shipper.Left, Col_Shipper.Width, rowHeight, dr.hbl_shipper_name!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Consignee.Left, Col_Consignee.Width, rowHeight, dr.hbl_consignee_name!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Carrier.Left, Col_Carrier.Width, rowHeight, dr.hbl_liner_name!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Vessel.Left, Col_Vessel.Width, rowHeight, dr.hbl_vessel_name!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Voyage.Left, Col_Voyage.Width, rowHeight, dr.hbl_voyage!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Pol.Left, Col_Pol.Width, rowHeight, dr.hbl_pol_name!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Pod.Left, Col_Pod.Width, rowHeight, dr.hbl_pod_name!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_MblNo.Left, Col_MblNo.Width, rowHeight, dr.hbl_mbl_no!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_HblNo.Left, Col_HblNo.Width, rowHeight, dr.hbl_houseno!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                if(OpGroup == "SEA EXPORT" || OpGroup == "SEA IMPORT")
                {
                    pdf.AddText(Row, Col_CntrNo.Left, Col_CntrNo.Width, rowHeight, dr.hbl_cntr_no!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_CntrType.Left, Col_CntrType.Width, rowHeight, dr.hbl_cntr_type_name!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_CntrSeal.Left, Col_CntrSeal.Width, rowHeight, dr.hbl_cntr_sealno!, new TextFormat { Border = BL, Style = "", FontSize = 9, Indent = true });   
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
            pdf.AddText(LeftY, Col, Row_Width, Line_Height, "PARENT", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ParentName, new TextFormat { Style = "B", FontSize = 10 });

            float RightY = currentY;
            var RightCol = Col + halfWidth;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "AGENT", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, AgentName, new TextFormat { Style = "B", FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "SHIPPER", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ShipperName, new TextFormat { Style = "B", FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "CONSIGNEE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ConsigneeName, new TextFormat { Style = "B", FontSize = 10 });

            currentY = RightY >= LeftY ? RightY : LeftY;
            currentY += Line_Height + 5;

            // Table Header
            pdf.AddText(currentY, Col_Refno.Left, Col_Refno.Width, Line_Height, "REF#", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Refdate.Left, Col_Refdate.Width, Line_Height, "REF DATE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Agent.Left, Col_Agent.Width, Line_Height, "AGENT", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Shipper.Left, Col_Shipper.Width, Line_Height, "SHIPPER", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Consignee.Left, Col_Consignee.Width, Line_Height, "CONSIGNEE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Carrier.Left, Col_Carrier.Width, Line_Height, "CARRIER", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Vessel.Left, Col_Vessel.Width, Line_Height, "VESSEL", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Voyage.Left, Col_Voyage.Width, Line_Height, "VOYAGE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Pol.Left, Col_Pol.Width, Line_Height, "POL", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Pod.Left, Col_Pod.Width, Line_Height, "POD", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_MblNo.Left, Col_MblNo.Width, Line_Height, "MBL#", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_HblNo.Left, Col_HblNo.Width, Line_Height, "HBL#", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            if(OpGroup == "SEA EXPORT" || OpGroup == "SEA IMPORT")
            {
                pdf.AddText(currentY, Col_CntrNo.Left, Col_CntrNo.Width, Line_Height, "CNTR #", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_CntrType.Left, Col_CntrType.Width, Line_Height, "VOL", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_CntrSeal.Left, Col_CntrSeal.Width, Line_Height, "SEAL NO", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
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
