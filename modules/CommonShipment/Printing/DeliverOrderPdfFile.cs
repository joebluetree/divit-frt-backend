using System;
using System.Data;
using Common.DTO.CommonShipment;
using Common.DTO.SeaExport;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using DataBase.Pdf;
using iTextSharp.text.pdf.qrcode;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NPOI.HPSF;
using NPOI.SS.Formula.Functions;

namespace CommonShipment.Printing
{
    public class DeliveryOrderPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<cargo_delivery_order_dto> Dt_List { get; set; } = new List<cargo_delivery_order_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string RefNo { get; set; } = "";
        public string Agent { get; set; } = "";
        public string POR { get; set; } = "";
        public string POD { get; set; } = "";
        public string User_name { get; set; } = "";
        public string FileName { get; set; } = "";

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
        private ColumnFormat Col_Date = new();
        private ColumnFormat Col_Truck = new();
        private ColumnFormat Col_From = new();
        private ColumnFormat Col_To = new();

        public DeliveryOrderPdfFile()
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
                File_Display_Name = FileName!.ToLower();
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

            this.Col_RefNo = new ColumnFormat { Left = 30, Width =50 };
            this.Col_Date = new ColumnFormat { Left = 80, Width = 60 };
            this.Col_Truck = new ColumnFormat { Left = 140, Width = 130};
            this.Col_From = new ColumnFormat { Left = 270, Width = 130};
            this.Col_To = new ColumnFormat { Left = 400, Width = 130};

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

            foreach (cargo_delivery_order_dto dr in Dt_List)
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

                var do_ref_date = Lib.FormatDate(Lib.ParseDate(dr.do_order_date!), Lib.DisplayDateFormat);

                float RefNoHeight = pdf.MeasureWrappedTextHeight(Row, Col_RefNo.Left, Col_RefNo.Width, Line_Height, dr.do_order_no!, format);
                float DateHeight = pdf.MeasureWrappedTextHeight(Row, Col_Date.Left, Col_Date.Width, Line_Height, do_ref_date!, format);
                float TruckHeight = pdf.MeasureWrappedTextHeight(Row, Col_Truck.Left, Col_Truck.Width, Line_Height, dr.do_truck_name!, format);
                float FromHeight = pdf.MeasureWrappedTextHeight(Row, Col_From.Left, Col_From.Width, Line_Height, dr.do_from_name!, format);
                float ToHeight = pdf.MeasureWrappedTextHeight(Row, Col_To.Left, Col_To.Width, Line_Height, dr.do_to_name!, format);

                float rowHeight = new[] { RefNoHeight, DateHeight, TruckHeight, FromHeight, ToHeight}.Max();

                pdf.AddText(Row, Col_RefNo.Left, Col_RefNo.Width, rowHeight, dr.do_order_no!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Date.Left, Col_Date.Width, rowHeight, do_ref_date!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Truck.Left, Col_Truck.Width, rowHeight, dr.do_truck_name!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_From.Left, Col_From.Width, rowHeight, dr.do_from_name!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_To.Left, Col_To.Width, rowHeight, dr.do_to_name!, new TextFormat { Border = "LTR" + BL, FontSize = 9, Indent = true });
                
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
            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, ptintInfo, new TextFormat { FontSize = 10 });
            currentY += Line_Height + 5;

            // Table Header
            pdf.AddText(currentY, Col_RefNo.Left, Col_RefNo.Width, Line_Height, "REF #", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Date.Left, Col_Date.Width, Line_Height, "DATE", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Truck.Left, Col_Truck.Width, Line_Height, "TRUCKER", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_From.Left, Col_From.Width, Line_Height, "FROM", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_To.Left, Col_To.Width, Line_Height, "TO", new TextFormat { Border = "LTR", Style = "B", FontSize = 10, Indent = true });

            currentY += Line_Height;

            return currentY;
        }

    }
}
