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
    public class CustomerListPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<rep_customerlist_dto> Dt_List { get; set; } = new List<rep_customerlist_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string CustName { get; set; } = "";
        public string CustType { get; set; } = "";
        public string CustFormat { get; set; } = "";
        public bool IsStandard { get; set; } = false;
        public bool IsCredit { get; set; } = false;
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

        private ColumnFormat Col_Date = new();
        private ColumnFormat Col_Name = new();
        private ColumnFormat Col_Address1 = new();
        private ColumnFormat Col_Address2 = new();
        private ColumnFormat Col_Address3 = new();
        private ColumnFormat Col_Category = new();
        private ColumnFormat Col_Contact = new();
        private ColumnFormat Col_Tel = new();
        private ColumnFormat Col_Mobile = new();
        private ColumnFormat Col_City = new();
        private ColumnFormat Col_State = new();
        private ColumnFormat Col_Country = new();

        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header

        public CustomerListPdfFile()
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
            this.Page_Height = 500;
            this.MaxRec_Height = 500;
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            this.Row_Width = 800;

            this.Col_Date = new ColumnFormat { Left = 30, Width = 60 };
            this.Col_Name = new ColumnFormat { Left = 90, Width = 120 };
            this.Col_Address1 = new ColumnFormat { Left = 210, Width = 200 };
            this.Col_Category = new ColumnFormat { Left = 410, Width = 60 };
            this.Col_Contact = new ColumnFormat { Left = 470, Width = 80 };
            this.Col_Tel = new ColumnFormat { Left = 550, Width = 60 };//120
            this.Col_Mobile = new ColumnFormat { Left = 610, Width = 60 };
            this.Col_City = new ColumnFormat { Left = 670, Width = 50 };
            this.Col_State = new ColumnFormat { Left = 720, Width = 60 };
            this.Col_Country = new ColumnFormat { Left = 780, Width = 50 };

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

            Row = this.Page_Height;

            IsStandard = CustFormat == "STANDARD";
            IsCredit = CustFormat == "CREDIT/SPECIAL ACCOUNT";

            Row = WriteHeader(Row_Default, Col_Default);

            int i = 0;
            foreach (rep_customerlist_dto dr in Dt_List)
            {
                i++;
                // printHeader = CommonLib.IsPageBreak(Row, Line_Height, MaxRec_Height);
                BL = CommonLib.IsLastRow(i, recordCount);
                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };
                var cust_created_date = Lib.FormatDate(Lib.ParseDate(dr.rec_created_date!), Lib.DisplayDateFormat).ToUpper();

                float nameHeight = pdf.MeasureWrappedTextHeight(Row, Col_Name.Left, Col_Name.Width, Line_Height, dr.cust_official_name!, format);
                float Add1Height = pdf.MeasureWrappedTextHeight(Row, Col_Address1.Left, Col_Address1.Width, Line_Height, dr.cust_address1!, format);
                float Add2Height = pdf.MeasureWrappedTextHeight(Row, Col_Address1.Left, Col_Address1.Width, Line_Height, dr.cust_address2!, format);
                float Add3Height = pdf.MeasureWrappedTextHeight(Row, Col_Address1.Left, Col_Address1.Width, Line_Height, dr.cust_address3!, format);

                float rowHeight = new[] { nameHeight, Add1Height + Add2Height + Add3Height }.Max();

                printHeader = CommonLib.IsPageBreak(Row, Lib.StringToInteger(rowHeight.ToString()), MaxRec_Height);
                if (printHeader)
                {
                    WriteFooter();
                    Row = WriteHeader(Row_Default, Col_Default);
                }
                pdf.AddText(Row, Col_Date.Left, Col_Date.Width, rowHeight, cust_created_date!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Name.Left, Col_Name.Width, rowHeight, dr.cust_official_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Address1.Left, Col_Address1.Width, Add1Height, dr.cust_address1!, new TextFormat { Border = "", FontSize = 9, Indent = true });
                var AddRow = Row;
                pdf.AddText(AddRow += Add1Height, Col_Address1.Left, Col_Address1.Width, Add2Height, dr.cust_address2!, new TextFormat { Border = "", FontSize = 9, Indent = true });
                pdf.AddText(AddRow + Add2Height, Col_Address1.Left, Col_Address1.Width, Add3Height, dr.cust_address3!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Category.Left, Col_Category.Width, rowHeight, dr.cust_type!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Contact.Left, Col_Contact.Width, rowHeight, dr.cust_contact!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Tel.Left, Col_Tel.Width, rowHeight, dr.cust_tel!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Mobile.Left, Col_Mobile.Width, rowHeight, dr.cust_mobile!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                if (IsStandard)
                {
                    pdf.AddText(Row, Col_City.Left, Col_City.Width, rowHeight, dr.cust_city!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_State.Left, Col_State.Width, rowHeight, dr.cust_state_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_Country.Left, Col_Country.Width, rowHeight, dr.cust_country_code!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                }
                if (IsCredit)
                {
                    pdf.AddText(Row, Col_City.Left, Col_City.Width, rowHeight, dr.cust_is_splacc!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_State.Left, Col_State.Width, rowHeight, dr.cust_days!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_Country.Left, Col_Country.Width, rowHeight, dr.cust_splacc_memo!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                }
                Row += rowHeight;
            }
            WriteFooter();
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
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "FROM DATE", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SFromDate.ToUpper(), new TextFormat { FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "TO DATE", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SToDate.ToUpper(), new TextFormat { FontSize = 10 });

            float RightY = currentY;
            var RightCol = Col + halfWidth;
            if (IsStandard)
            {
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "CATEGORY", new TextFormat { FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, CustType, new TextFormat { FontSize = 10 });
            }
            if (IsCredit)
            {
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "FORMAT", new TextFormat { FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, CustFormat, new TextFormat { FontSize = 10 });
            }
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "NAME", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, CustName, new TextFormat { FontSize = 10 });

            currentY = RightY;
            currentY += Line_Height + 5;

            pdf.AddText(currentY, Col_Date.Left, Col_Date.Width, Line_Height, "DATE", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_Name.Left, Col_Name.Width, Line_Height, "OFFICIAL NAME", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_Address1.Left, Col_Address1.Width, Line_Height, "ADDRESS", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_Category.Left, Col_Category.Width, Line_Height, "CATEGORY", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_Contact.Left, Col_Contact.Width, Line_Height, "CONTACT", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_Tel.Left, Col_Tel.Width, Line_Height, "TELEPHONE", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            pdf.AddText(currentY, Col_Mobile.Left, Col_Mobile.Width, Line_Height, "MOBILE", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            if (IsStandard)
            {
                pdf.AddText(currentY, Col_City.Left, Col_City.Width, Line_Height, "CITY", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
                pdf.AddText(currentY, Col_State.Left, Col_State.Width, Line_Height, "STATE", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
                pdf.AddText(currentY, Col_Country.Left, Col_Country.Width, Line_Height, "COUNTRY", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            }
            if (IsCredit)
            {
                pdf.AddText(currentY, Col_City.Left, Col_City.Width, Line_Height, "	CREDIT/SPL. A/C", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
                pdf.AddText(currentY, Col_State.Left, Col_State.Width, Line_Height, "CREDIT DAYS", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
                pdf.AddText(currentY, Col_Country.Left, Col_Country.Width, Line_Height, "MEMO", new TextFormat { Border = "TB", Style = "B", FontSize = 9, Indent = true });
            }


            currentY += Line_Height;

            return currentY;
        }
        private void WriteFooter()
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
