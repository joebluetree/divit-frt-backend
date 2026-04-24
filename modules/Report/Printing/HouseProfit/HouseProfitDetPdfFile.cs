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
    public class HouseProfitDetPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<rep_houseprofit_dto> Dt_List { get; set; } = new List<rep_houseprofit_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string Format { get; set; } = "";
        public string ReportType { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string Salesman { get; set; } = "";
        public string Parent { get; set; } = "";
        public string Agent { get; set; } = "";
        public string Shipper { get; set; } = "";
        public string Consignee { get; set; } = "";
        public string HandledBY { get; set; } = "";
        public string Nomination { get; set; } = "";
        public string Client_Type { get; set; } = "";
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

        private string PageSize = "";
        private int Page_Height = 0;
        private int MaxRec_Height = 0;
        private int Line_Height = 0;
        private int PageNumber = 0;
        private int Row_Width = 0;

        private ColumnFormat Col_RefNo = new();
        private ColumnFormat Col_Date = new();
        private ColumnFormat Col_BLNo = new();
        private ColumnFormat Col_HBL_Count = new();
        private ColumnFormat Col_Revenue = new();
        private ColumnFormat Col_Expense = new();
        private ColumnFormat Col_Profit = new();
        private ColumnFormat Col_CntrType = new();
        private ColumnFormat Col_20 = new();
        private ColumnFormat Col_40 = new();
        private ColumnFormat Col_40hc = new();
        private ColumnFormat Col_45 = new();
        private ColumnFormat Col_Teu = new();
        private ColumnFormat Col_Cbm = new();
        private ColumnFormat Col_Weight = new();

        private ColumnFormat Col_Agent = new();
        private ColumnFormat Col_Party_Agent = new();
        private ColumnFormat Col_Carrier = new();
        private ColumnFormat Col_Shipper = new();
        private ColumnFormat Col_Consignee = new();
        private ColumnFormat Col_BillingParty = new();

        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header



        public HouseProfitDetPdfFile()
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
        private string getPageSize ()
        {
            PageSize = "LANDSCAPE";

            // if(Format == "GENERAL" && ReportType == "MASTER") PageSize = "LANDSCAPE";
            return PageSize;
        }
        private void Writedocument()
        {
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            
            this.Page_Height = 500;
            this.Row_Width = 800;
            this.MaxRec_Height = 500;

            this.Col_RefNo = new ColumnFormat { Left = 30, Width = 70 };
            this.Col_Date = new ColumnFormat { Left = 100, Width = 70 };
            this.Col_BLNo = new ColumnFormat { Left = 170, Width = 80 };
            this.Col_Agent = new ColumnFormat { Left = 250, Width = 70 };
            this.Col_Revenue = new ColumnFormat { Left = 320, Width = 70 };
            this.Col_Expense = new ColumnFormat { Left = 390, Width = 70 };
            this.Col_Profit = new ColumnFormat { Left = 460, Width = 70 };
            this.Col_CntrType = new ColumnFormat { Left = 530, Width = 50 };
            this.Col_20 = new ColumnFormat { Left = 580, Width = 25 };
            this.Col_40 = new ColumnFormat { Left = 605, Width = 25 };
            this.Col_40hc = new ColumnFormat { Left = 630, Width = 30 };
            this.Col_45 = new ColumnFormat { Left = 660, Width = 25 };
            this.Col_Teu = new ColumnFormat { Left = 685, Width = 35 };
            this.Col_Cbm = new ColumnFormat { Left = 720, Width = 55 };
            this.Col_Weight = new ColumnFormat { Left = 775, Width = 55 };

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
            string ST = "";
            bool LastRow = false;

            Row = this.Page_Height;

            Row = WriteHeader(Row_Default, Col_Default);

            int i = 0;

            foreach (rep_houseprofit_dto dr in Dt_List)
            {
                i++;
                // printHeader = CommonLib.IsPageBreak(Row, Line_Height, MaxRec_Height);
                LastRow = i == recordCount;
                bool isTotal = dr.mbl_refno == "TOTAL" || dr.mbl_refno == "SUB TOTAL";
                BL = isTotal ? "TB" : "b";
                ST = isTotal ? "B" : "";

                BL = LastRow ? "TB": BL;
                ST = LastRow ? "B" : ST;// style bold


                // var TotalBorder = isTotal ? "TB" : "";//dd
                // var TotalStyle = isTotal ? "B" : "";
                
                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };
                float AgentHeight = 0;
                if(Format == "AGENT")   AgentHeight = pdf.MeasureWrappedTextHeight(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.mbl_agent_name!, format);
                if(Format == "SHIPPER")   AgentHeight = pdf.MeasureWrappedTextHeight(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.mbl_shipper_name!, format);
                if(Format == "CONSIGNEE")   AgentHeight = pdf.MeasureWrappedTextHeight(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.mbl_consignee_name!, format);
                if(Format == "HANDLED-BY")   AgentHeight = pdf.MeasureWrappedTextHeight(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.mbl_handled_name!, format);

                var rowHeight = new[] { AgentHeight, Line_Height}.Max();

                printHeader = CommonLib.IsPageBreak(Row, rowHeight, MaxRec_Height);
                if (printHeader)
                {
                    WriteFooter(Row, Col_Default);
                    Row = WriteHeader(Row_Default, Col_Default);
                }
                
                var mbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.mbl_ref_date!), Lib.DisplayDateFormat) ?? "";

                pdf.AddText(Row, Col_RefNo.Left, Col_RefNo.Width, rowHeight, dr.mbl_refno!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Date.Left, Col_Date.Width, rowHeight, mbl_ref_date.ToUpper()!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_BLNo.Left, Col_BLNo.Width, rowHeight, dr.mbl_no!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                if(Format == "AGENT")
                    pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.mbl_agent_name!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                if(Format == "SHIPPER")
                    pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.mbl_shipper_name!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                if(Format == "CONSIGNEE")
                    pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.mbl_consignee_name!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                if(Format == "NOMINATION")
                    pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.mbl_bltype!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                if(Format == "CLIENT TYPE")
                    pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.mbl_agent_bltype!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                if(Format == "HANDLED-BY")
                    pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.mbl_handled_name!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });

                pdf.AddText(Row, Col_Revenue.Left, Col_Revenue.Width, rowHeight, dr.mbl_inc_total!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Expense.Left, Col_Expense.Width, rowHeight, dr.mbl_exp_total!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Profit.Left, Col_Profit.Width, rowHeight, dr.mbl_revenue!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                
                pdf.AddText(Row, Col_CntrType.Left, Col_CntrType.Width, rowHeight, dr.mbl_cntr_type!, new TextFormat { Border =  BL, Style = "" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_20.Left, Col_20.Width, rowHeight, dr.mbl_20!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_40.Left, Col_40.Width, rowHeight, dr.mbl_40!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_40hc.Left, Col_40hc.Width, rowHeight, dr.mbl_40hq!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_45.Left, Col_45.Width, rowHeight, dr.mbl_45!, new TextFormat { Border =   BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Teu.Left, Col_Teu.Width, rowHeight, dr.mbl_teu!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Cbm.Left, Col_Cbm.Width, rowHeight, dr.mbl_cbm!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Weight.Left, Col_Weight.Width, rowHeight, dr.mbl_weight!, new TextFormat { Border =  BL, Style = "R" + ST, FontSize = 9, Indent = true });

                Row += rowHeight;

                // if (printHeader)
                // {
                //     WriteFooter(Row, Col_Default);
                //     Row = WriteHeader(Row_Default, Col_Default);
                // }
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
            int quaterWidth = halfWidth / 2;

            float LeftY = currentY;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "FROM DATE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SFromDate.ToUpper(), new TextFormat { Style = "B", FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "TO DATE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, SToDate.ToUpper(), new TextFormat { Style = "B", FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, Row_Width, Line_Height, "FORMAT", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Format, new TextFormat { Style = "B", FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, Row_Width, Line_Height, "REPORT TYPE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left, Col_Head_data.Width, Line_Height, ReportType, new TextFormat { Style = "B", FontSize = 10 });

            float RightY = currentY;
            var RightCol = Col + halfWidth;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "SALESMAN", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Salesman, new TextFormat { Style = "B", FontSize = 10 });
            RightY += Line_Height;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "PARENT", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Parent, new TextFormat { Style = "B", FontSize = 10 });
            if(Format == "AGENT")
            {
                RightY += Line_Height;
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "AGENT", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Agent, new TextFormat { Style = "B", FontSize = 10 });
            }
            if(Format == "SHIPPER")
            {
                RightY += Line_Height;
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "SHIPPER", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Shipper, new TextFormat { Style = "B", FontSize = 10 });
            }
            if(Format == "CONSIGNEE" || Format == "NOMINATION" || Format == "CLIENT TYPE")
            {
                RightY += Line_Height;
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "CONSIGNEE", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Consignee, new TextFormat { Style = "B", FontSize = 10 });
            }
            if(Format == "HANDLED-BY")
            {
                RightY += Line_Height;
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "HANDLED-BY", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, HandledBY, new TextFormat { Style = "B", FontSize = 10 });
            }
            if(Format == "CLIENT TYPE")
            {
                RightY += Line_Height;
                pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "CLIENT-TYPE", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
                pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Client_Type, new TextFormat { Style = "B", FontSize = 10 });
            }

            currentY = LeftY;
            currentY += Line_Height + 5;

            // Table Header

            pdf.AddText(currentY, Col_RefNo.Left, Col_RefNo.Width, Line_Height, "REF.NO", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Date.Left, Col_Date.Width, Line_Height, "REF.DATE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_BLNo.Left, Col_BLNo.Width, Line_Height, "HOUSE #", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Agent.Left, Col_Agent.Width, Line_Height, Format, new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Revenue.Left, Col_Revenue.Width, Line_Height, "REVENUE", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Expense.Left, Col_Expense.Width, Line_Height, "EXPENSE", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Profit.Left, Col_Profit.Width, Line_Height, "PROFIT", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_CntrType.Left, Col_CntrType.Width, Line_Height, "F/L", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_20.Left, Col_20.Width, Line_Height, "20", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_40.Left, Col_40.Width, Line_Height, "40", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_40hc.Left, Col_40hc.Width, Line_Height, "40HC", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_45.Left, Col_45.Width, Line_Height, "45", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Teu.Left, Col_Teu.Width, Line_Height, "TEU", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Cbm.Left, Col_Cbm.Width, Line_Height, "CBM", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            pdf.AddText(currentY, Col_Weight.Left, Col_Weight.Width, Line_Height, "WEIGHT", new TextFormat { Border = "TB", Style = "RB", FontSize = 10, Indent = true });
            currentY += Line_Height;
            return currentY;
        }
        private void WriteFooter(float rowIndex, float colIndex)
        {
            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name} ";//PAGE#: {PageNumber}
            //need to add seprate total from different type
            if (rowIndex + Line_Height < MaxRec_Height)
            {
                // rowIndex += Line_Height;
                // pdf.AddText(rowIndex, Col_Default, Row_Width, Line_Height, printInfo, new TextFormat { Border = "T", FontSize = 9 });
            }

            Row = MaxRec_Height;//for footer print details(fixed)
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, printInfo, new TextFormat { Border = "T", FontSize = 9 });
            Row += Line_Height;
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, $"PAGE#: {PageNumber}", new TextFormat { Border = "", FontSize = 9 });
        }
    }
}
