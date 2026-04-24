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
    public class OpHandlePdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<rep_ophandle_dto> Dt_List { get; set; } = new List<rep_ophandle_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string OpGroup { get; set; } = "";
        public string Type { get; set; } = "";
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
        private int MaxRec_Height = 0;
        private int Line_Height = 0;
        private int PageNumber = 0;
        private int Row_Width = 0;
        
        private int Total_Master = 0;
        private int Total_House = 0;

        private ColumnFormat Col_Code = new();
        private ColumnFormat Col_date = new();
        private ColumnFormat Col_Handled = new();
        private ColumnFormat Col_Agent = new();
        private ColumnFormat Col_SHandled = new();
        private ColumnFormat Col_SMaster = new();
        private ColumnFormat Col_SHouse = new();
        
        private ColumnFormat Col_Column = new();// for ':' in header datas
        private ColumnFormat Col_Head_data = new();// for start and width of data part in header
        


        public OpHandlePdfFile()
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
            this.Page_Height = 800;
            this.MaxRec_Height = 770;
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            this.Row_Width = 500;

            this.Col_Code = new ColumnFormat { Left = 30, Width =65 };
            this.Col_date = new ColumnFormat { Left = 95, Width = 65 };
            this.Col_Handled = new ColumnFormat { Left = 160, Width = 90};
            this.Col_Agent = new ColumnFormat { Left = 250, Width = 280};

            // for SUMMARY
            this.Col_SHandled = new ColumnFormat { Left = 30, Width =200 };
            this.Col_SMaster = new ColumnFormat { Left = 230, Width = 150 };
            this.Col_SHouse = new ColumnFormat { Left = 380, Width = 150};

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
            string BL = "";
            string ST = "";

            Row = this.Page_Height;

            Row = WriteHeader(Row_Default, Col_Default);


            int i = 0;

            foreach (rep_ophandle_dto dr in Dt_List)
            {
                i++;
                printHeader = CommonLib.IsPageBreak(Row, Line_Height, MaxRec_Height);
                BL = i == recordCount ? "T" : "";
                ST = i == recordCount ? "B" : "";
                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };
                if(OpGroup == "SUMMARY")
                {
                    pdf.AddText(Row, Col_SHandled.Left, Col_SHandled.Width, Line_Height, dr.ophandle_handled_name!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_SMaster.Left, Col_SMaster.Width, Line_Height, dr.ophandle_master_count!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_SHouse.Left, Col_SHouse.Width, Line_Height, dr.ophandle_house_count!, new TextFormat { Border = "" + BL, Style = "" + ST, FontSize = 9, Indent = true });                    
                    Total_Master += dr.ophandle_master_count ?? 0;
                    Total_House += dr.ophandle_house_count ?? 0;
                    Row += Line_Height;
                }
                else
                {
                    var ophandle_ref_date = Lib.FormatDate(Lib.ParseDate(dr.ophandle_ref_date!), Lib.DisplayDateFormat) ?? "";

                    float codeHeight = pdf.MeasureWrappedTextHeight(Row, Col_Code.Left, Col_Code.Width, Line_Height, dr.ophandle_refno!, format);
                    float nameHeight = pdf.MeasureWrappedTextHeight(Row, Col_date.Left, Col_date.Width, Line_Height, ophandle_ref_date!, format);
                    float HandledbyHeight = pdf.MeasureWrappedTextHeight(Row, Col_Handled.Left, Col_Handled.Width, Line_Height, dr.ophandle_handled_name!, format);
                    float agentHeight = pdf.MeasureWrappedTextHeight(Row, Col_Agent.Left, Col_Agent.Width, Line_Height, dr.ophandle_agent_name!, format);

                    float rowHeight = new[] { codeHeight, nameHeight, HandledbyHeight, agentHeight}.Max();

                    pdf.AddText(Row, Col_Code.Left, Col_Code.Width, rowHeight, dr.ophandle_refno!, new TextFormat { Border = "" , FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_date.Left, Col_date.Width, rowHeight, ophandle_ref_date.ToUpper()!, new TextFormat { Border = "" , FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_Handled.Left, Col_Handled.Width, rowHeight, dr.ophandle_handled_name!, new TextFormat { Border = "" , FontSize = 9, Indent = true });
                    pdf.AddText(Row, Col_Agent.Left, Col_Agent.Width, rowHeight, dr.ophandle_agent_name!, new TextFormat { Border = "", FontSize = 9, Indent = true });
                
                    Row += rowHeight;
                }

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
            pdf.AddText(LeftY, Col + Col_Head_data.Left , Col_Head_data.Width , Line_Height, SFromDate.ToUpper(), new TextFormat { Style = "B", FontSize = 10 });
            LeftY += Line_Height;
            pdf.AddText(LeftY, Col, halfWidth, Line_Height, "TO DATE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(LeftY, Col + Col_Head_data.Left , Col_Head_data.Width , Line_Height, SToDate.ToUpper(), new TextFormat { Style = "B", FontSize = 10 });
            
            float RightY = currentY;
            var RightCol = Col + halfWidth;
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "TYPE", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, Type, new TextFormat { Style = "B", FontSize = 10 });
            
            RightY += Line_Height;
            
            pdf.AddText(RightY, RightCol, Row_Width, Line_Height, "GROUP", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Column.Left, Col_Column.Width, Line_Height, ":", new TextFormat { Style = "B", FontSize = 10 });
            pdf.AddText(RightY, RightCol + Col_Head_data.Left, Col_Head_data.Width, Line_Height, OpGroup, new TextFormat { Style = "B", FontSize = 10 });
            
            currentY = RightY;
            currentY += Line_Height + 5;

            // Table Header
            if(OpGroup == "SUMMARY")
            {
                pdf.AddText(currentY, Col_SHandled.Left, Col_SHandled.Width, Line_Height, "HANDLED BY", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_SMaster.Left, Col_SMaster.Width, Line_Height, "MASTER HANDLED", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_SHouse.Left, Col_SHouse.Width, Line_Height, "HOUSE HANDLED", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
            }
            else
            {
                pdf.AddText(currentY, Col_Code.Left, Col_Code.Width, Line_Height, "REF#", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_date.Left, Col_date.Width, Line_Height, "DATE", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Handled.Left, Col_Handled.Width, Line_Height, "HANDLED BY", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Agent.Left, Col_Agent.Width, Line_Height, "MASTER AGENT", new TextFormat { Border = "TB", Style = "B", FontSize = 10, Indent = true });    
            }
            
            currentY += Line_Height;

            return currentY;
        }
        private void WriteFooter(float rowIndex, float colIndex)
        {
            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name} ";//PAGE#: {PageNumber}
            // if(OpGroup == "SUMMARY")
            // {
            //     pdf.AddText(rowIndex, Col_SHandled.Left, Col_SHandled.Width, Line_Height, "TOTAL", new TextFormat { Border="T", Style = "B", FontSize = 9 });
            //     pdf.AddText(rowIndex, Col_SMaster.Left, Col_SMaster.Width, Line_Height, Total_Master, new TextFormat { Border="T", Style = "B", FontSize = 9 });
            //     pdf.AddText(rowIndex, Col_SHouse.Left, Col_SHouse.Width, Line_Height, Total_House, new TextFormat { Border="T", Style = "B", FontSize = 9 });
            // }

            Row = MaxRec_Height;//for footer print details(fixed)
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, printInfo, new TextFormat { Border="T", FontSize = 9 });
            Row += Line_Height;
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, $"PAGE#: {PageNumber}", new TextFormat { Border="", FontSize = 9 });
        }

    }
}
