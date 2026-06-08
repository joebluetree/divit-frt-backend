using System;
using System.Data;
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
    public class PendingARPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<rep_pendingar_dto> Dt_List { get; set; } = new List<rep_pendingar_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string OpGroup { get; set; } = "";
        public string BLType { get; set; } = "";
        public string HandledBy { get; set; } = "";
        public string HiddenRec { get; set; } = "";
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
        private ColumnFormat Col_RefDate = new();
        private ColumnFormat Col_Houseno = new();
        
        private ColumnFormat Col_Shipment = new();
        private ColumnFormat Col_ETA = new();
        private ColumnFormat Col_Remarks = new();
        
        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header
        


        public PendingARPdfFile()
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
                File_Display_Name = Title!;
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
            this.MaxRec_Height = 770;
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            this.Row_Width = 500;

            this.Col_Refno = new ColumnFormat { Left = 30, Width = 70 };
            this.Col_RefDate = new ColumnFormat { Left = 100, Width = 70};
            this.Col_Houseno = new ColumnFormat { Left = 170, Width = 80 };
            this.Col_Shipment = new ColumnFormat { Left = 250, Width = 70 };
            this.Col_ETA = new ColumnFormat { Left = 320, Width = 70};
            this.Col_Remarks = new ColumnFormat { Left = 390, Width = 140 };

            this.Col_Column = new ColumnFormat { Left = 80, Width = 10 };// ':'
            this.Col_Head_data = new ColumnFormat { Left = 90, Width = 100 };

            pdf.CreateDocument(File_Name);
            CreateReport();
            pdf.CloseDocument();
        }

        private void CreateReport()
        {

            int recordCount = Dt_List.Count;
            bool printHeader = false;

            Row = this.Page_Height;

            Row = WriteHeader(Row_Default, Col_Default);


            int i = 0;

            foreach (rep_pendingar_dto dr in Dt_List)
            {
                i++;
                printHeader = CommonLib.IsPageBreak(Row, Line_Height, MaxRec_Height);

                var format = new TextFormat
                {
                    Border = "b",
                    FontSize = 8,
                    Style = "",
                    Indent = true
                };


                var ref_date = Lib.FormatDate(Lib.ParseDate(dr.mbl_ref_date!), Lib.DisplayDateFormat) ?? "";
                var mbl_pod_eta = Lib.FormatDate(Lib.ParseDate(dr.mbl_pod_eta!), Lib.DisplayDateFormat) ?? "";

                float RefNoHeight = pdf.MeasureWrappedTextHeight(Row, Col_Refno.Left, Col_Refno.Width, Line_Height, dr.mbl_refno!, format);

                float rowHeight = new[] { RefNoHeight, Line_Height}.Max();

                pdf.AddText(Row, Col_Refno.Left, Col_Refno.Width, rowHeight, dr.mbl_refno!, format);
                pdf.AddText(Row, Col_RefDate.Left, Col_RefDate.Width, rowHeight, ref_date.ToUpper()!, format);
                pdf.AddText(Row, Col_Houseno.Left, Col_Houseno.Width, rowHeight, dr.mbl_houseno!, format);
                pdf.AddText(Row, Col_Shipment.Left, Col_Shipment.Width, rowHeight, dr.mbl_bltype!, format);
                pdf.AddText(Row, Col_ETA.Left, Col_ETA.Width, rowHeight, mbl_pod_eta.ToUpper()!, format);
                pdf.AddText(Row, Col_Remarks.Left, Col_Remarks.Width, rowHeight, dr.mbl_remarks!, format);
            
                Row += rowHeight;
                

                if (printHeader)
                {
                    WriteFooter(Row, Col_Default);
                    Row = WriteHeader(Row_Default, Col_Default);                    
                }
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

            string ptintInfo = $"PRINTED ON : {Date} / {User_name}     PAGE#: {PageNumber}";

            float currentY = CommonLib.WriteBranchAddressPdf(Row, Col, Company_id, Branch_id, context!, pdf);

            currentY += Line_Height;
            var hiddenMessage = HiddenRec == "Y" ? " (HIDDEN RECORD)" : "";
            pdf.AddText(currentY, Col, Row_Width, Line_Height, Title.ToUpper() + hiddenMessage , new TextFormat { Border = "TB", Style = "B", FontSize = 10 });//+ " LIST"
            currentY += Line_Height + 5;
            int halfWidth = Row_Width / 2; 
           
            float LeftY = currentY;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "GROUP", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left , Col_Head_data.Width , Line_Height, OpGroup, new TextFormat { Style = "B", FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "SHIPMENT", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left , Col_Head_data.Width , Line_Height, BLType, new TextFormat { Style = "B", FontSize = 10 });
            
            float RightY = currentY;
            var RightCol = Col + halfWidth;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "HANDLED-BY", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, HandledBy, new TextFormat { Style = "B", FontSize = 10 });
            
            currentY = RightY > LeftY ? RightY : LeftY;
            currentY += Line_Height + 5;
        
            pdf.AddText(currentY, Col_Refno.Left, Col_Refno.Width, Line_Height, "REF#", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_RefDate.Left, Col_RefDate.Width, Line_Height, "REF-DATE", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_Houseno.Left, Col_Houseno.Width, Line_Height, "HOUSE", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_Shipment.Left, Col_Shipment.Width, Line_Height, "SHIPMENT", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_ETA.Left, Col_ETA.Width, Line_Height, "ETA", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_Remarks.Left, Col_Remarks.Width, Line_Height, "REMARKS", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            
            currentY += Line_Height;

            return currentY;
        }
        private void WriteFooter(float rowIndex, float colIndex)
        {
            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name} ";//PAGE#: {PageNumber}

            Row = MaxRec_Height;//for footer print details(fixed)
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, printInfo, new TextFormat { Border="T", FontSize = 9 });
            Row += Line_Height;
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, $"PAGE#: {PageNumber}", new TextFormat { Border="", FontSize = 9 });
        }

    }
}
