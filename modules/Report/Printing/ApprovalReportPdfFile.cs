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
    public class ApprovalReportPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<rep_approvedd_dto> Dt_List { get; set; } = new List<rep_approvedd_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string DateType { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string RequestBy { get; set; } = "";
        public string Type { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string Reference { get; set; } = "";
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

        private ColumnFormat Col_ReqNo = new();
        private ColumnFormat Col_Type = new();
        private ColumnFormat Col_RefNo = new();
        private ColumnFormat Col_HblNo = new();
        private ColumnFormat Col_Consignee = new();
        private ColumnFormat Col_InvNo = new();
        private ColumnFormat Col_Inv_Cust = new();
        private ColumnFormat Col_Inv_Amt = new();
        private ColumnFormat Col_Approve = new();
        private ColumnFormat Col_ApproveBy = new();
        private ColumnFormat Col_Approve_Date = new();
        private ColumnFormat Col_Status = new();
        private ColumnFormat Col_Remarks = new();
        private ColumnFormat Col_CurCode = new();

        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header

        public ApprovalReportPdfFile()
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

            this.Col_ReqNo = new ColumnFormat { Left = 30, Width = 60 };
            this.Col_Type = new ColumnFormat { Left = 90, Width = 60 };
            this.Col_RefNo = new ColumnFormat { Left = 150, Width = 50 };
            this.Col_HblNo = new ColumnFormat { Left = 200, Width = 50 };
            this.Col_Consignee = new ColumnFormat { Left = 250, Width = 80 };
            this.Col_InvNo = new ColumnFormat { Left = 330, Width = 80 };
            this.Col_Inv_Cust = new ColumnFormat { Left = 410, Width = 80 };
            this.Col_Inv_Amt = new ColumnFormat { Left = 490, Width = 60 };
            // this.Col_Approve = new ColumnFormat { Left = 520, Width = 70 };
            this.Col_ApproveBy = new ColumnFormat { Left = 550, Width = 50 };
            this.Col_Approve_Date = new ColumnFormat { Left = 600, Width = 60 };
            this.Col_Status = new ColumnFormat { Left = 660, Width = 70 };
            this.Col_Remarks = new ColumnFormat { Left = 730, Width = 60 };
            // this.Col_CurCode = new ColumnFormat { Left = 790, Width = 40 };

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
            foreach (rep_approvedd_dto dr in Dt_List)
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
                var cad_approved_date = Lib.FormatDate(Lib.ParseDate(dr.cad_approved_date!), Lib.DisplayDateFormat) ?? "";
                var ca_date = Lib.FormatDate(Lib.ParseDate(dr.ca_date!), Lib.DisplayDateFormat) ?? "";

                float ConsigneeHeight = pdf.MeasureWrappedTextHeight(Row, Col_Consignee.Left, Col_Consignee.Width, Line_Height, dr.ca_consignee_name!, format);
                float InvCustHeight = pdf.MeasureWrappedTextHeight(Row, Col_InvNo.Left, Col_InvNo.Width, Line_Height, dr.ca_inv_cust!, format);
                float PodHeight = pdf.MeasureWrappedTextHeight(Row, Col_Approve.Left, Col_Approve.Width, Line_Height, dr.ca_remarks!, format);
                float CarrierHeight = pdf.MeasureWrappedTextHeight(Row, Col_Status.Left, Col_Status.Width, Line_Height, dr.cad_status!, format);

                float rowHeight = new[] { ConsigneeHeight, InvCustHeight, PodHeight, CarrierHeight, Line_Height }.Max();

                printHeader = CommonLib.IsPageBreak(Row, Lib.StringToInteger(rowHeight.ToString()), MaxRec_Height);
                if (printHeader)
                {
                    WriteFooter();
                    Row = WriteHeader(Row_Default, Col_Default);
                }
                pdf.AddText(Row, Col_ReqNo.Left, Col_ReqNo.Width, rowHeight, dr.ca_req_no!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Type.Left, Col_Type.Width, rowHeight, dr.ca_type!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_RefNo.Left, Col_RefNo.Width, rowHeight, dr.ca_ref_no!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_HblNo.Left, Col_HblNo.Width, rowHeight, dr.ca_hbl_no!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Consignee.Left, Col_Consignee.Width, rowHeight, dr.ca_consignee_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_InvNo.Left, Col_InvNo.Width, rowHeight, dr.ca_inv_no!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Inv_Cust.Left, Col_Inv_Cust.Width, rowHeight, dr.ca_inv_cust!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Inv_Amt.Left, Col_Inv_Amt.Width, rowHeight, dr.ca_inv_amt!, new TextFormat { Border = "B", FontSize = 9, Indent = true, Style="R" });
                // pdf.AddText(Row, Col_Approve.Left, Col_Approve.Width, rowHeight, dr.ca_Approve_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_ApproveBy.Left, Col_ApproveBy.Width, rowHeight, dr.cad_approvedby_name!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Approve_Date.Left, Col_Approve_Date.Width, rowHeight, cad_approved_date.ToUpper(), new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Status.Left, Col_Status.Width, rowHeight, dr.cad_status!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Remarks.Left, Col_Remarks.Width, rowHeight, dr.ca_remarks!, new TextFormat { Style = "R", Border = "B", FontSize = 9, Indent = true });
                // pdf.AddText(Row, Col_CurCode.Left, Col_CurCode.Width, rowHeight, dr.ca_cur_code!, new TextFormat { Border = "B", FontSize = 9, Indent = true });
                
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
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "GROUP", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, OpGroup, new TextFormat { FontSize = 10 });
            // LeftY += Line_Height;
            // pdf.AddText(LeftY, Col, halfWidth, Line_Height, "TYPE", new TextFormat { FontSize = 10 });
            // pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            // pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Type, new TextFormat { FontSize = 10 });

            float RightY = currentY;
            var RightCol = Col + halfWidth;

            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "TYPE", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Type, new TextFormat { FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "REFERENCE", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Reference, new TextFormat { FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "REQUEST.BY", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, RequestBy, new TextFormat { FontSize = 10 });

            currentY = RightY >= LeftY ? RightY : LeftY;
            currentY += Line_Height + 5;
            pdf.AddText(currentY, Col_ReqNo.Left, Col_ReqNo.Width, Line_Height, "REQUEST#", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Type.Left, Col_Type.Width, Line_Height, "TYPE", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_RefNo.Left, Col_RefNo.Width, Line_Height, "REF.NO", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_HblNo.Left, Col_HblNo.Width, Line_Height, "HOUSE#", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Consignee.Left, Col_Consignee.Width, Line_Height, "Consignee", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_InvNo.Left, Col_InvNo.Width, Line_Height, "INV.NO", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Inv_Cust.Left, Col_Inv_Cust.Width, Line_Height, "CUSTOMER", new TextFormat { Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Inv_Amt.Left, Col_Inv_Amt.Width, Line_Height, "AMOUNT", new TextFormat {Style ="B", Border = "TB", FontSize = 10, Indent = true });
            // pdf.AddText(currentY, Col_Approve.Left, Col_Approve.Width, Line_Height, "APPR", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_ApproveBy.Left, Col_ApproveBy.Width, Line_Height, "APPROVED.BY", new TextFormat { Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Approve_Date.Left, Col_Approve_Date.Width, Line_Height, "APPROVED DATE", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Status.Left, Col_Status.Width, Line_Height, "STATUS", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Remarks.Left, Col_Remarks.Width, Line_Height, "REMARKS", new TextFormat { Style ="RB", Border = "TB", FontSize = 10, Indent = true });
            // pdf.AddText(currentY, Col_CurCode.Left, Col_CurCode.Width, Line_Height, "CURRENCY", new TextFormat { Style ="B", Border = "TB", FontSize = 10, Indent = true });

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