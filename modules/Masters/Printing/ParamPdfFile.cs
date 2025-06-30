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
using NPOI.SS.Formula.Functions;

namespace Masters.Printing
{
    public class ParamPdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<mast_param_dto> Dt_List { get; set; } = new List<mast_param_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string Name { get; set; } = "";
        public string User_name { get; set; } = "";
        public string Param_type { get; set; } = "";

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

        public ParamPdfFile()
        {
            pdf = new TextSharpPdf();
            context = _context;

        }


        public void Process()
        {
            try
            {
                fList = new List<filesm>();
                Folderid = Guid.NewGuid().ToString().ToUpper();
                File_Display_Name = Param_type!.ToLower();
                File_Display_Name += ".pdf";
                File_Display_Name = Database.Lib.Lib.ProperFileName(File_Display_Name);
                File_Name = Database.Lib.Lib.GetFileName(report_folder, Folderid, File_Display_Name, false);
                File_Type = "PDF";
                fList.Add(Database.Lib.Lib.AddFiles(File_Name, File_Type, File_Display_Name));


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

            for (int i = 0; i < recordCount; i++)
            {

                var dr = Dt_List[i];

                printHeader = CommonLib.PageHeaderCheck(Row, Line_Height, Page_Height);
                BL = CommonLib.GetBottomLine(i, recordCount);

                pdf.AddText(Row, Col, 60, Line_Height, dr.param_code!, new TextFormat { _Border ="LT" + BL, _fontSize = 9, _indent = true });
                pdf.AddText(Row, Col + 60, 490, Line_Height, dr.param_name!,new TextFormat { _Border ="LTR" + BL, _fontSize = 9, _indent = true });
                Row += Line_Height;

                if (printHeader)
                    Row = WriteHeader(Row_Default, Col_Default);

            }
        }

        private float WriteHeader(float _Row, float _Col)
        {
            Row = _Row;
            Col = _Col;

            int rowwidth = 550;

            pdf.AddNewPage();

            var getDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(getDate, Lib.DisplayDateFormat);

            float currentY = CommonLib.WriteBranchAddress(Row, Col, Company_id, Branch_id, context!, pdf);

            currentY += Line_Height;
            pdf.AddText(currentY, Col, rowwidth, Line_Height, Title.ToUpper(), new TextFormat { _Border = "TB", _Style = "B", _fontSize = 12 });
            currentY += Line_Height + 3;
            pdf.AddText(currentY, Col, rowwidth, Line_Height, "NAME    : " + Name,new TextFormat { _fontSize = 10 });
            currentY += Line_Height;
            pdf.AddText(currentY, Col, rowwidth, Line_Height, "PRINTED : " + Date + " / " + User_name,new TextFormat { _fontSize = 10 });
            currentY += 5 + Line_Height;

            // Table Header
            pdf.AddText(currentY, Col, 60, Line_Height, "CODE", new TextFormat { _Border = "LT", _Style = "B", _fontSize = 9, _indent = true });
            pdf.AddText(currentY, Col + 60, 490, Line_Height, "NAME", new TextFormat { _Border = "LRT", _Style = "B", _fontSize = 9,  _indent = true});
            currentY += Line_Height;

            // indent  ture/false

            return currentY;
        }

    }
}
