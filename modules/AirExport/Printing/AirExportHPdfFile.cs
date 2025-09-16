using System;
using System.Data;
using Common.DTO.Marketing;
using Common.DTO.Masters;
using Common.DTO.AirExport;
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

namespace AirExport.Printing
{
    public class AirExportHPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<cargo_air_exporth_dto> Dt_List { get; set; } = new List<cargo_air_exporth_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string RefNo { get; set; } = "";
        public string HouseNo { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string User_name { get; set; } = "";
        public string Hbl_type { get; set; } = "";

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

        private ColumnFormat Col_RefNo = new();
        private ColumnFormat Col_HouseNo = new();
        private ColumnFormat Col_Shipper = new();
        private ColumnFormat Col_Consignee = new();
        private ColumnFormat Col_Agent = new();
        private ColumnFormat Col_Handled = new();


        public AirExportHPdfFile()
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
                File_Display_Name = Hbl_type!.ToLower();
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

            this.Col_HouseNo = new ColumnFormat { Left = 30, Width =60 };
            this.Col_RefNo = new ColumnFormat { Left = 90, Width = 60};
            this.Col_Shipper = new ColumnFormat { Left = 150, Width = 115};
            this.Col_Consignee = new ColumnFormat { Left = 265, Width = 115};
            this.Col_Agent = new ColumnFormat { Left = 380, Width = 80};
            this.Col_Handled = new ColumnFormat { Left = 460, Width = 70};

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

            foreach (cargo_air_exporth_dto dr in Dt_List)
            {
                i++;
                printHeader = CommonLib.IsPageBreak(Row, Line_Height, Page_Height);
                BL = CommonLib.IsLastRow(i, recordCount);
                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };

                float HouseNoHeight = pdf.MeasureWrappedTextHeight(Row, Col_HouseNo.Left, Col_HouseNo.Width, Line_Height, dr.hbl_houseno!, format);
                float RefNoHeight = pdf.MeasureWrappedTextHeight(Row, Col_RefNo.Left, Col_RefNo.Width, Line_Height, dr.hbl_mbl_refno!, format);
                float ShipperHeight = pdf.MeasureWrappedTextHeight(Row, Col_Shipper.Left, Col_Shipper.Width, Line_Height, dr.hbl_shipper_name!, format);
                float ConsigneeHeight = pdf.MeasureWrappedTextHeight(Row, Col_Consignee.Left, Col_Consignee.Width, Line_Height, dr.hbl_consignee_name!, format);
                float AgentHeight = pdf.MeasureWrappedTextHeight(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.hbl_agent_name!, format);
                float handledHeight = pdf.MeasureWrappedTextHeight(Row, Col_Handled.Left, Col_Handled.Width, Line_Height, dr.hbl_handled_name!, format);

                float rowHeight = new[] { RefNoHeight, HouseNoHeight, ShipperHeight, ConsigneeHeight, AgentHeight, handledHeight }.Max();

                pdf.AddText(Row, Col_HouseNo.Left, Col_HouseNo.Width, rowHeight, dr.hbl_houseno!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_RefNo.Left, Col_RefNo.Width, rowHeight, dr.hbl_mbl_refno!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Shipper.Left, Col_Shipper.Width, rowHeight, dr.hbl_shipper_name!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Consignee.Left, Col_Consignee.Width, rowHeight, dr.hbl_consignee_name!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.hbl_agent_name!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Handled.Left, Col_Handled.Width, rowHeight, dr.hbl_handled_name!, new TextFormat { Border = "LTR" + BL, FontSize = 9, Indent = true });
                
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
            FromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat);
            ToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat);

            string ptintInfo = $"PRINTED ON : {Date} / {User_name}     PAGE#: {PageNumber}";

            float currentY = CommonLib.WriteBranchAddressPdf(Row, Col, Company_id, Branch_id, context!, pdf);

            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, Title.ToUpper() + " LIST", new TextFormat { Border = "TB", Style = "B", FontSize = 10 });
            currentY += Line_Height + 3;
            int halfWidth = Row_Width / 2; // to assign From and to date in same row
            pdf.AddText(currentY, Col, halfWidth, Line_Height, "FROM DATE : " + FromDate, new TextFormat { FontSize = 10 });
            pdf.AddText(currentY, Col + halfWidth, halfWidth, Line_Height, "TO DATE : " + ToDate, new TextFormat { FontSize = 10 });
            currentY += Line_Height;
            pdf.AddText(currentY, Col, halfWidth, Line_Height, "REF # : " + RefNo, new TextFormat { FontSize = 10 });
            pdf.AddText(currentY, Col + halfWidth, halfWidth, Line_Height, "HOUSE # : " + HouseNo, new TextFormat { FontSize = 10 });
            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, ptintInfo, new TextFormat { FontSize = 10 });
            currentY += Line_Height + 5;

            // Table Header
            pdf.AddText(currentY, Col_HouseNo.Left, Col_HouseNo.Width, Line_Height, "HOUSE #", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_RefNo.Left, Col_RefNo.Width, Line_Height, "REF #", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Shipper.Left, Col_Shipper.Width, Line_Height, "SHIPPER", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Consignee.Left, Col_Consignee.Width, Line_Height, "CONSIGNEE", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Agent.Left, Col_Agent.Width, Line_Height, "AGENT", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Handled.Left, Col_Handled.Width, Line_Height, "HANDLED BY", new TextFormat { Border = "LTR", Style = "B", FontSize = 10, Indent = true });

            currentY += Line_Height;

            return currentY;
        }

    }
}
