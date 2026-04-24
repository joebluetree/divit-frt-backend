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
    public class InvoiceIssuePdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<rep_invoiceissue_dto> Dt_List { get; set; } = new List<rep_invoiceissue_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string DateType { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string CustName { get; set; } = "";
        public string InvType { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string ParentName { get; set; } = "";
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
        private ColumnFormat Col_Invno = new();
        private ColumnFormat Col_InvDate = new();
        private ColumnFormat Col_CustName = new();
        private ColumnFormat Col_Pol = new();
        private ColumnFormat Col_Pol_country = new();
        private ColumnFormat Col_PolDate = new();
        private ColumnFormat Col_Pod = new();
        private ColumnFormat Col_Pod_country = new();
        private ColumnFormat Col_PodDate = new();
        private ColumnFormat Col_Carrier = new();
        private ColumnFormat Col_Amount = new();
        private ColumnFormat Col_CurCode = new();

        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header

        public InvoiceIssuePdfFile()
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

            this.Col_Refno = new ColumnFormat { Left = 30, Width = 70 };
            this.Col_RefDate = new ColumnFormat { Left = 100, Width = 60 };
            this.Col_Invno = new ColumnFormat { Left = 160, Width = 60 };
            this.Col_InvDate = new ColumnFormat { Left = 220, Width = 60 };
            this.Col_CustName = new ColumnFormat { Left = 280, Width = 100 };
            this.Col_Pol = new ColumnFormat { Left = 380, Width = 80 };
            // this.Col_Pol_country = new ColumnFormat { Left = 450, Width = 50 };
            this.Col_PolDate = new ColumnFormat { Left = 460, Width = 60 };
            this.Col_Pod = new ColumnFormat { Left = 520, Width = 70 };
            // this.Col_Pod_country = new ColumnFormat { Left = 620, Width = 50 };
            this.Col_PodDate = new ColumnFormat { Left = 590, Width = 60 };
            this.Col_Carrier = new ColumnFormat { Left = 650, Width = 80 };
            this.Col_Amount = new ColumnFormat { Left = 730, Width = 60 };
            this.Col_CurCode = new ColumnFormat { Left = 790, Width = 40 };

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

            Row = WriteHeader(Row_Default, Col_Default);

            int i = 0;
            foreach (rep_invoiceissue_dto dr in Dt_List)
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
                var inv_ref_date = Lib.FormatDate(Lib.ParseDate(dr.inv_ref_date!), Lib.DisplayDateFormat) ?? "";
                var inv_date = Lib.FormatDate(Lib.ParseDate(dr.inv_date!), Lib.DisplayDateFormat) ?? "";
                var inv_pol_date = Lib.FormatDate(Lib.ParseDate(dr.inv_pol_etd!), Lib.DisplayDateFormat) ?? "";
                var inv_pod_date = Lib.FormatDate(Lib.ParseDate(dr.inv_pod_eta!), Lib.DisplayDateFormat) ?? "";

                float CustNameHeight = pdf.MeasureWrappedTextHeight(Row, Col_CustName.Left, Col_CustName.Width, Line_Height, dr.inv_cust_name!, format);
                float PolHeight = pdf.MeasureWrappedTextHeight(Row, Col_Pol.Left, Col_Pol.Width, Line_Height, dr.inv_pol_name!, format);
                float PodHeight = pdf.MeasureWrappedTextHeight(Row, Col_Pod.Left, Col_Pod.Width, Line_Height, dr.inv_pod_name!, format);
                float CarrierHeight = pdf.MeasureWrappedTextHeight(Row, Col_Carrier.Left, Col_Carrier.Width, Line_Height, dr.inv_liner_name!, format);

                float rowHeight = new[] { CustNameHeight, PolHeight, PodHeight, CarrierHeight, Line_Height }.Max();

                printHeader = CommonLib.IsPageBreak(Row, Lib.StringToInteger(rowHeight.ToString()), MaxRec_Height);
                if (printHeader)
                {
                    WriteFooter();
                    Row = WriteHeader(Row_Default, Col_Default);
                }
                pdf.AddText(Row, Col_Refno.Left, Col_Refno.Width, rowHeight, dr.inv_mbl_refno!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_RefDate.Left, Col_RefDate.Width, rowHeight, inv_ref_date.ToUpper(), new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Invno.Left, Col_Invno.Width, rowHeight, dr.inv_no!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_InvDate.Left, Col_InvDate.Width, rowHeight, inv_date.ToUpper(), new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_CustName.Left, Col_CustName.Width, rowHeight, dr.inv_cust_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Pol.Left, Col_Pol.Width, rowHeight, dr.inv_pol_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                // pdf.AddText(Row, Col_Pol_country.Left, Col_Pol_country.Width, rowHeight, dr.inv_pol_country!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_PolDate.Left, Col_PolDate.Width, rowHeight, inv_pol_date.ToUpper(), new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Pod.Left, Col_Pod.Width, rowHeight, dr.inv_pod_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                // pdf.AddText(Row, Col_Pod_country.Left, Col_Pod_country.Width, rowHeight, dr.inv_pod_country!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_PodDate.Left, Col_PodDate.Width, rowHeight, inv_pod_date.ToUpper(), new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Carrier.Left, Col_Carrier.Width, rowHeight, dr.inv_liner_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Amount.Left, Col_Amount.Width, rowHeight, dr.inv_amount!, new TextFormat { Style = "R", Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_CurCode.Left, Col_CurCode.Width, rowHeight, dr.inv_cur_code!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                
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
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "DATE TYPE", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, DateType, new TextFormat { FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "FROM DATE", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SFromDate.ToUpper(), new TextFormat { FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "TO DATE", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SToDate.ToUpper(), new TextFormat { FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "GROUP", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, OpGroup, new TextFormat { FontSize = 10 });

            float RightY = currentY;
            var RightCol = Col + halfWidth;

            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "TYPE", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, InvType, new TextFormat { FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "PARENT", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ParentName, new TextFormat { FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "CUSTOMER", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, CustName, new TextFormat { FontSize = 10 });

            currentY = RightY >= LeftY ? RightY : LeftY;
            currentY += Line_Height + 5;
            pdf.AddText(currentY, Col_Refno.Left, Col_Refno.Width, Line_Height, "REF.NO", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_RefDate.Left, Col_RefDate.Width, Line_Height, "REF.DATE", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Invno.Left, Col_Invno.Width, Line_Height, "INV.NO", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_InvDate.Left, Col_InvDate.Width, Line_Height, "INV.DATE", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_CustName.Left, Col_CustName.Width, Line_Height, "CUSTOMER", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Pol.Left, Col_Pol.Width, Line_Height, "POL", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            // pdf.AddText(currentY, Col_Pol_country.Left, Col_Pol_country.Width, Line_Height, "cntr, new TextFormat { Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_PolDate.Left, Col_PolDate.Width, Line_Height, "ETD", new TextFormat {Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Pod.Left, Col_Pod.Width, Line_Height, "POD", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            // pdf.AddText(currentY, Col_Pod_country.Left, Col_Pod_country.Width, Line_Height, dr.inv_pod_country!, new TextFormat { Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_PodDate.Left, Col_PodDate.Width, Line_Height, "ETA", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Carrier.Left, Col_Carrier.Width, Line_Height, "CARRIER", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Amount.Left, Col_Amount.Width, Line_Height, "AMOUNT", new TextFormat { Style ="RB", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_CurCode.Left, Col_CurCode.Width, Line_Height, "CURRENCY", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });

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
