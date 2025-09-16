using System;
using System.Data;
using Common.DTO.AirExport;
using Common.DTO.Marketing;
using Common.DTO.Masters;
using Common.DTO.SeaExport;
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
using SixLabors.ImageSharp.PixelFormats;

namespace AirExport.Printing
{
    public class AirExportMPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<cargo_air_exportm_dto> Dt_List { get; set; } = new List<cargo_air_exportm_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string RefNo { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string User_name { get; set; } = "";
        public string Mbl_type { get; set; } = "";

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
        private ColumnFormat Col_MblNo = new();
        private ColumnFormat Col_Agent = new();
        private ColumnFormat Col_Carrier = new();
        private ColumnFormat Col_Handled = new();


        public AirExportMPdfFile()
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
                File_Display_Name = Mbl_type!.ToLower();
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

            this.Col_Code = new ColumnFormat { Left = 30, Width = 60 };
            this.Col_date = new ColumnFormat { Left = 90, Width = 60 };
            this.Col_MblNo = new ColumnFormat { Left = 150, Width = 70 };
            this.Col_Agent = new ColumnFormat { Left = 220, Width = 140 };
            this.Col_Carrier = new ColumnFormat { Left = 360, Width = 90 };
            this.Col_Handled = new ColumnFormat { Left = 450, Width = 80 };

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

            foreach (cargo_air_exportm_dto dr in Dt_List)
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

                var mbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.mbl_ref_date!), Lib.DisplayDateFormat);

                float codeHeight = pdf.MeasureWrappedTextHeight(Row, Col_Code.Left, Col_Code.Width, Line_Height, dr.mbl_refno!, format);
                float nameHeight = pdf.MeasureWrappedTextHeight(Row, Col_date.Left, Col_date.Width, Line_Height, mbl_ref_date!, format);
                float mblnoHeight = pdf.MeasureWrappedTextHeight(Row, Col_MblNo.Left, Col_MblNo.Width, Line_Height, dr.mbl_no!, format);
                float agentHeight = pdf.MeasureWrappedTextHeight(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.mbl_agent_name!, format);
                float carrierHeight = pdf.MeasureWrappedTextHeight(Row, Col_Carrier.Left, Col_Carrier.Width, Line_Height, dr.mbl_liner_name!, format);
                float handledHeight = pdf.MeasureWrappedTextHeight(Row, Col_Handled.Left, Col_Handled.Width, Line_Height, dr.mbl_handled_name!, format);

                float rowHeight = new[] { codeHeight, nameHeight, mblnoHeight, agentHeight, carrierHeight, handledHeight }.Max();

                pdf.AddText(Row, Col_Code.Left, Col_Code.Width, rowHeight, dr.mbl_refno!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_date.Left, Col_date.Width, rowHeight, mbl_ref_date!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_MblNo.Left, Col_MblNo.Width, rowHeight, dr.mbl_no!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.mbl_agent_name!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Carrier.Left, Col_Carrier.Width, rowHeight, dr.mbl_liner_name!, new TextFormat { Border = "LT" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Handled.Left, Col_Handled.Width, rowHeight, dr.mbl_handled_name!, new TextFormat { Border = "LTR" + BL, FontSize = 9, Indent = true });

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
            int halfWidth = Row_Width / 2;
            pdf.AddText(currentY, Col, halfWidth, Line_Height, "FROM DATE : " + FromDate, new TextFormat { FontSize = 10 });
            pdf.AddText(currentY, Col + halfWidth, halfWidth, Line_Height, "TO DATE : " + ToDate, new TextFormat { FontSize = 10 });
            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, "REF # : " + RefNo, new TextFormat { FontSize = 10 });
            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, ptintInfo, new TextFormat { FontSize = 10 });
            currentY += Line_Height + 5;

            // Table Header
            pdf.AddText(currentY, Col_Code.Left, Col_Code.Width, Line_Height, "REF #", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_date.Left, Col_date.Width, Line_Height, "DATE", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_MblNo.Left, Col_MblNo.Width, Line_Height, "MBL #", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Agent.Left, Col_Agent.Width, Line_Height, "MASTER AGENT", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Carrier.Left, Col_Carrier.Width, Line_Height, "CARRIER", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Handled.Left, Col_Handled.Width, Line_Height, "HANDLED BY", new TextFormat { Border = "LTR", Style = "B", FontSize = 10, Indent = true });

            currentY += Line_Height;

            return currentY;
        }

    }
}
