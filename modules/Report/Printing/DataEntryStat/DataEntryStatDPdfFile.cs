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
    public class DataEntryStatDPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<rep_dataentrystat_dto> Dt_List { get; set; } = new List<rep_dataentrystat_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string OpGroup { get; set; } = "";
        public string Category { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
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

        private ColumnFormat Col_Type = new();
        private ColumnFormat Col_RefNo = new();
        private ColumnFormat Col_RefDate = new();
        private ColumnFormat Col_MblNo = new();
        private ColumnFormat Col_HblNo = new();
        private ColumnFormat Col_CreatedBy = new();

        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header
        


        public DataEntryStatDPdfFile()
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

            this.Col_Type = new ColumnFormat { Left = 30, Width = 70 };
            this.Col_RefNo = new ColumnFormat { Left = 100, Width = 70 };
            this.Col_RefDate = new ColumnFormat { Left = 170, Width = 65};
            this.Col_MblNo = new ColumnFormat { Left = 235, Width = 90 };
            this.Col_HblNo = new ColumnFormat { Left = 325, Width = 130 };
            this.Col_CreatedBy = new ColumnFormat { Left = 455, Width = 75 };

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

            foreach (rep_dataentrystat_dto dr in Dt_List)
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


                var mbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.mbl_ref_date!), Lib.DisplayDateFormat) ?? "";

                float HouseNoeight = pdf.MeasureWrappedTextHeight(Row, Col_HblNo.Left, Col_HblNo.Width, Line_Height, dr.mbl_house_nos!, format);

                float rowHeight = new[] { HouseNoeight, Line_Height}.Max();

                pdf.AddText(Row, Col_Type.Left, Col_Type.Width, rowHeight, dr.mbl_mode!, format);
                pdf.AddText(Row, Col_RefNo.Left, Col_RefNo.Width, rowHeight, dr.mbl_refno!, format);
                pdf.AddText(Row, Col_RefDate.Left, Col_RefDate.Width, rowHeight, mbl_ref_date!, format);
                pdf.AddText(Row, Col_MblNo.Left, Col_MblNo.Width, rowHeight, dr.mbl_no!, format);
                pdf.AddText(Row, Col_HblNo.Left, Col_HblNo.Width, rowHeight, dr.mbl_house_nos!, format);
                pdf.AddText(Row, Col_CreatedBy.Left, Col_CreatedBy.Width, rowHeight, dr.rec_created_by!, format);

                Row += rowHeight;

                if (printHeader && i != Dt_List.Count())
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
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            string ptintInfo = $"PRINTED ON : {Date} / {User_name}     PAGE#: {PageNumber}";

            float currentY = CommonLib.WriteBranchAddressPdf(Row, Col, Company_id, Branch_id, context!, pdf);

            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, Title.ToUpper() , new TextFormat { Border = "TB", Style = "B", FontSize = 10 });//+ " LIST"
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
            pdf.AddText(LeftY, Col, Row_Width, Line_Height, "GROUP", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, OpGroup, new TextFormat { Style = "B", FontSize = 10 });

            float RightY = currentY;
            var RightCol = Col + halfWidth;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "CATEGORY", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Category, new TextFormat { Style = "B", FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "CREATED BY", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, CreatedBy, new TextFormat { Style = "B", FontSize = 10 });

            currentY = RightY >= LeftY ? RightY : LeftY;

            currentY += Line_Height + 5;
        
            pdf.AddText(currentY, Col_Type.Left, Col_Type.Width, Line_Height, "GROUP", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_RefNo.Left, Col_RefNo.Width, Line_Height, "REF#", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_RefDate.Left, Col_RefDate.Width, Line_Height, "REF-DATE", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_MblNo.Left, Col_MblNo.Width, Line_Height, "MASTER#", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_HblNo.Left, Col_HblNo.Width, Line_Height, "HOUSE#", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_CreatedBy.Left, Col_CreatedBy.Width, Line_Height, "CREATED-BY", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            
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
