using System;
using System.Data;
using Common.DTO.Masters;
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

namespace Masters.Printing
{
    public class CustomermPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<mast_customerm_dto> Dt_List { get; set; } = new List<mast_customerm_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string Name { get; set; } = "";
        public string User_name { get; set; } = "";
        public string Cust_type { get; set; } = "";
        public string DateType { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public string EditedBy { get; set; } = "";
        public string CustCode { get; set; } = "";
        public string FirmCode { get; set; } = "";
        public string IsBlackAcc { get; set; } = "";

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
        private ColumnFormat Col_Name = new();
        private ColumnFormat Col_Parent = new();
        private ColumnFormat Col_CreatedBy = new();
        private ColumnFormat Col_CustType = new();
        private ColumnFormat Col_ClientType = new();
        private ColumnFormat Col_Contact = new();


        public CustomermPdfFile()
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
                File_Display_Name = Cust_type!.ToLower();
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

            this.Col_Code = new ColumnFormat { Left = 30, Width = 40 };
            this.Col_Name = new ColumnFormat { Left = 70, Width = 110 };
            this.Col_Parent = new ColumnFormat { Left = 180, Width = 110 };
            this.Col_CreatedBy = new ColumnFormat { Left = 290, Width = 70 };
            this.Col_CustType = new ColumnFormat { Left = 360, Width = 35 };
            this.Col_ClientType = new ColumnFormat { Left = 395, Width = 70 };
            this.Col_Contact = new ColumnFormat { Left = 465, Width = 65 };
            
        
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

            foreach (mast_customerm_dto dr in Dt_List)
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

                float codeHeight = pdf.MeasureWrappedTextHeight(Row, Col_Code.Left, Col_Code.Width, Line_Height, dr.cust_code!, format);
                float nameHeight = pdf.MeasureWrappedTextHeight(Row, Col_Name.Left, Col_Name.Width, Line_Height, dr.cust_name!, format);
                float parentHeight = pdf.MeasureWrappedTextHeight(Row, Col_Parent.Left, Col_Parent.Width, Line_Height, dr.cust_parent_name!, format);
                float createdByHeight = pdf.MeasureWrappedTextHeight(Row, Col_CreatedBy.Left, Col_CreatedBy.Width, Line_Height, dr.rec_created_by!, format);
                float custtypeHeight = pdf.MeasureWrappedTextHeight(Row, Col_CustType.Left, Col_CustType.Width, Line_Height, dr.cust_type!, format);
                float ClientTypeHeight = pdf.MeasureWrappedTextHeight(Row, Col_ClientType.Left, Col_ClientType.Width, Line_Height, dr.cust_nomination!, format);
                float contactHeight = pdf.MeasureWrappedTextHeight(Row, Col_Contact.Left, Col_Contact.Width, Line_Height, dr.cust_contact!, format);

                // Step 2: Determine max height for the row
                float rowHeight = new[] { codeHeight, nameHeight, parentHeight, createdByHeight ,custtypeHeight ,ClientTypeHeight, contactHeight}.Max();

                pdf.AddText(Row, Col_Code.Left, Col_Code.Width, rowHeight, dr.cust_code!, new TextFormat { Border = "LT" + BL, Style = "J", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Name.Left, Col_Name.Width, rowHeight, dr.cust_name!, new TextFormat { Border = "LT" + BL, Style = "J", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Parent.Left, Col_Parent.Width, rowHeight, dr.cust_parent_name!, new TextFormat { Border = "LT" + BL, Style = "J", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_CreatedBy.Left, Col_CreatedBy.Width, rowHeight, dr.rec_created_by!, new TextFormat { Border = "LT" + BL, Style = "J", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_CustType.Left, Col_CustType.Width, rowHeight, dr.cust_type!, new TextFormat { Border = "LT" + BL, Style = "J", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_ClientType.Left, Col_ClientType.Width, rowHeight, dr.cust_nomination!, new TextFormat { Border = "LT" + BL, Style = "J", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Contact.Left, Col_Contact.Width, rowHeight, dr.cust_contact!, new TextFormat { Border = "LTR" + BL, Style = "J", FontSize = 9, Indent = true });

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
            pdf.AddText(currentY, Col, halfWidth, Line_Height, "FROM DATE: " + FromDate, new TextFormat { FontSize = 10 });
            pdf.AddText(currentY, Col + halfWidth, halfWidth, Line_Height, "TO DATE: " + ToDate, new TextFormat { FontSize = 10 });
            currentY += Line_Height;

            pdf.AddText(currentY, Col, halfWidth, Line_Height, "CODE: " + CustCode, new TextFormat { FontSize = 10 });
            pdf.AddText(currentY, Col + halfWidth, halfWidth, Line_Height, "NAME: " + Name, new TextFormat { FontSize = 10 });
            currentY += Line_Height;

            pdf.AddText(currentY, Col, halfWidth, Line_Height, "CREATED-BY: " + CreatedBy, new TextFormat { FontSize = 10 });
            pdf.AddText(currentY, Col + halfWidth, halfWidth, Line_Height, "EDITED-BY: " + EditedBy, new TextFormat { FontSize = 10 });
            currentY += Line_Height;

            pdf.AddText(currentY, Col, halfWidth, Line_Height, "FIRM-CODE: " + FirmCode, new TextFormat { FontSize = 10 });
            pdf.AddText(currentY, Col + halfWidth, halfWidth, Line_Height, "IS-BLACK-ACCOUNT: " + IsBlackAcc, new TextFormat { FontSize = 10 });
            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, ptintInfo, new TextFormat { FontSize = 10 });
            currentY += Line_Height + 5;

            // Table Header
            pdf.AddText(currentY, Col_Code.Left, Col_Code.Width, Line_Height, "CODE", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Name.Left, Col_Name.Width, Line_Height, "NAME", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Parent.Left, Col_Parent.Width, Line_Height, "PARENT", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_CreatedBy.Left, Col_CreatedBy.Width, Line_Height, "CREATED-BY", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_CustType.Left, Col_CustType.Width, Line_Height, "TYPE", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_ClientType.Left, Col_ClientType.Width, Line_Height, "CLIENT-TYPE", new TextFormat { Border = "LT", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Contact.Left, Col_Contact.Width, Line_Height, "CONTACT", new TextFormat { Border = "LTR", Style = "B", FontSize = 10, Indent = true });
            currentY += Line_Height;

            return currentY;
        }

    }
}
