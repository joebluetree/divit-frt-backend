using System;
using System.Data;
using Common.DTO.Accounts;
using Common.DTO.OtherOp;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Accounts;
using Database.Models.Cargo;
using DataBase.Pdf;
using iTextSharp.text.pdf.qrcode;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NPOI.HPSF;
using NPOI.HSSF.Record;
using NPOI.SS.Formula.Functions;
using NPOI.Util;

namespace Accounts.Printing
{
    public class InvoicePdfFile
    {
        iPdfBase pdf = null!;
        public List<filesm> FList = new List<filesm>();
        public string Report_Folder = "";
        public List<acc_invoiced_dto> Dt_List { get; set; } = new List<acc_invoiced_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string Name { get; set; } = "";
        public string InvoiceNo { get; set; } = "";
        public string InvoiceDate { get; set; } = "";
        public string InvType { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string CustAddress1 { get; set; } = "";
        public string CustAddress2 { get; set; } = ""; 
        public string CustAddress3 { get; set; } = "";
        public string CustomerReference { get; set; } = "";
        public string OurReference { get; set; } = "";
        public string InvMblNo { get; set; } = "";
        public string InvHblNo { get; set; } = "";
        public string InvPcs { get; set; } = "";
        public string InvUnit { get; set; } = "";
        public string InvLBS { get; set; } = "";
        public string InvKGS { get; set; } = "";
        public string InvShipper { get; set; } = "";
        public string InvConsignee { get; set; } = "";
        public string POL { get; set; } = "";
        public string POD { get; set; } = "";
        public string InvRemk1 { get; set; } = "";
        public string InvRemk2 { get; set; } = "";
        public string InvRemk3 { get; set; } = "";
        public string Handledby { get; set; } = "";
        public string InvTotal { get; set; } = "";
        public string InvPaid { get; set; } = "";
        public string InvCurCode { get; set; } = "";
        public string User_name { get; set; } = "";
        public string InvTerms { get; set; } = "";
        public List<cargo_container_dto> ContainerList { get; set; } = new();


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
        private int Detail_Height = 0;
        private int Line_Height = 0;
        private int PageNumber = 0;
        private int Row_Width = 0;
        private bool IsAttachment = false;

        private ColumnFormat Col_AccName = new();
        private ColumnFormat Col_Remk = new();
        private ColumnFormat Col_Amount = new();
        private ColumnFormat Col_total = new();
        private ColumnFormat Col_paid = new();
        private ColumnFormat Col_balance = new();


        public InvoicePdfFile()
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
                File_Display_Name = Name!.ToUpper();
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
            this.Detail_Height = 550;
            this.Line_Height = 15;
            this.Row_Default = 35;
            this.Col_Default = 30;
            this.Row_Width = 500;

            this.Col_AccName = new ColumnFormat { Left = 30, Width =220 };
            this.Col_Remk = new ColumnFormat { Left = 250, Width = 180 };
            this.Col_Amount = new ColumnFormat { Left = 430, Width = 100};
            this.Col_total = new ColumnFormat { Left = 380, Width = 50};
            this.Col_paid = new ColumnFormat { Left = 380, Width = 50};
            this.Col_balance = new ColumnFormat { Left = 380, Width = 50};

            pdf.CreateDocument(File_Name);
            CreateReport();
            pdf.CloseDocument();
        }
        private bool IsPageBreak(float Row, int Line_Height, int Page_Height, int detailCount)
        {
            int maxdetailCount = 14;
            bool height = (Row + Line_Height) > Page_Height;
            bool countExceeded = detailCount >= maxdetailCount;

            return height || countExceeded;
        }

        private void CreateReport()
        {

            int recordCount = Dt_List.Count;
            bool printHeader = false;
            string BL = "";

            Row = this.Page_Height;

            Row = WriteHeader(Row_Default, Col_Default);

            int i = 0;
            int detailCount = 0;

            foreach (acc_invoiced_dto dr in Dt_List)
            {
                i++;
                printHeader = IsPageBreak(Row, Line_Height, Detail_Height,detailCount);
                BL = CommonLib.IsLastRow(i, recordCount);

                var format = new TextFormat
                {
                    FontSize = 9,
                    Style = "J",
                    Indent = true
                };
                if (printHeader)
                {
                    WriteFooter(Row, Col_Default, detailCount);
                    Row = WriteHeader(Row_Default, Col_Default);                        

                    detailCount = 0;
                }

                float AccNameHeight = pdf.MeasureWrappedTextHeight(Row, Col_AccName.Left, Col_AccName.Width, Line_Height, dr.invd_acc_name!, format);
                float RemkHeight = pdf.MeasureWrappedTextHeight(Row, Col_Remk.Left, Col_Remk.Width, Line_Height, dr.invd_remarks!, format);
                float AmountHeight = pdf.MeasureWrappedTextHeight(Row, Col_Amount.Left, Col_Amount.Width, Line_Height, dr.invd_total!, format);

                float rowHeight = new[] { AccNameHeight, RemkHeight, AmountHeight }.Max();//RemkHeight,
               
                pdf.AddText(Row, Col_AccName.Left, Col_AccName.Width, rowHeight, dr.invd_acc_name!, new TextFormat { Border = "T" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Remk.Left, Col_Remk.Width, rowHeight, dr.invd_remarks!, new TextFormat { Border = "T" + BL, FontSize = 9, Indent = true });
                pdf.AddText(Row, Col_Amount.Left, Col_Amount.Width, rowHeight, dr.invd_total!, new TextFormat { Border = "LT" + BL, Style="R", FontSize = 9, Indent = true });
                
                if(recordCount>i)
                    Row += rowHeight;

                detailCount++;
            }
            
            WriteFooter(Row, Col_Default, detailCount);
            if (ContainerList.Count > 4)
            {
                IsAttachment = true;
                WriteAttachment(Row_Default, Col_Default);
            }

        }

        private float WriteHeader(float _Row, float _Col)
        {
            Row = _Row;
            Col = _Col;
            var Title = "";
            var custLabel = "";


            pdf.AddNewPage();
            PageNumber++;

            if(InvType == "A/R")
            {
                Title = "INVOICE";
                custLabel = "BILL TO";
            }
            if(InvType == "A/P")
            {
                Title = "CREDIT NOTE";
                custLabel = "PAY TO";
            }

            float currentY = CommonLib.WriteBranchAddressPdf(Row, Col, Company_id, Branch_id, context!, pdf);

            currentY += Line_Height;
            pdf.AddText(currentY, Col, Row_Width, Line_Height, Title.ToUpper() , new TextFormat { Border = "TB", Style = "CB", FontSize = 10 });
            currentY += Line_Height + 5;
            
            int halfWidth = Row_Width / 2;
            int valueWidth = halfWidth / 2;
            float rightColX = Col + halfWidth;

            float _currentY = currentY;
            
            
            pdf.AddText(_currentY, Col, valueWidth, Line_Height, custLabel , new TextFormat { FontSize = 10 });
            pdf.AddText(_currentY, Col + (valueWidth/2), valueWidth, Line_Height, CustomerName, new TextFormat { FontSize = 10 });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col + (valueWidth/2), valueWidth, Line_Height, CustAddress1, new TextFormat { FontSize = 10 });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col + (valueWidth/2), valueWidth, Line_Height, CustAddress2, new TextFormat { FontSize = 10 });
            _currentY += Line_Height;
            pdf.AddText(_currentY, Col + (valueWidth/2), valueWidth, Line_Height, CustAddress3, new TextFormat { FontSize = 10 });
            
            _currentY = currentY;
            pdf.AddText(_currentY, rightColX, valueWidth, Line_Height, "INVOICE NO ", new TextFormat { Border = "LT",FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX+ valueWidth, valueWidth, Line_Height, InvoiceNo, new TextFormat { Border = "LTR",FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, valueWidth, Line_Height, "INVOICE DATE " , new TextFormat {Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX+ valueWidth, valueWidth, Line_Height, InvoiceDate, new TextFormat {Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, valueWidth, Line_Height, "YOUR REFERENCE " , new TextFormat { Border = "LT", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX+ valueWidth , valueWidth, Line_Height, CustomerReference, new TextFormat { Border = "LTR", FontSize = 10, Indent = true });
            _currentY += Line_Height;
            pdf.AddText(_currentY, rightColX, valueWidth, Line_Height, "OUR REFERENCE " , new TextFormat {Border = "LTB", FontSize = 10, Indent = true });
            pdf.AddText(_currentY, rightColX+ valueWidth, valueWidth, Line_Height, OurReference, new TextFormat {Border = "LTRB", FontSize = 10, Indent = true });

            // currentY += _currentY + Line_Height;
            currentY += Line_Height * 4 + 5;
            pdf.AddText(currentY, Col, Row_Width, Line_Height,"", new TextFormat { Border = "T", FontSize = 10 });
            currentY += 5;
            if(!IsAttachment)
            {
                _currentY = currentY;
                pdf.AddText(_currentY, Col, halfWidth, Line_Height, "MBL NO : " + InvMblNo, new TextFormat { Border = "", FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, Col, halfWidth, Line_Height, "HBL NO : " + InvHblNo, new TextFormat { FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, Col, halfWidth, Line_Height, "PIECE : " + InvPcs + " "+InvUnit, new TextFormat { FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, Col, halfWidth, Line_Height, "WEIGHT : " + InvLBS + " LBS / "+InvKGS+ " KGS", new TextFormat { FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, Col, halfWidth, Line_Height, "SHIPPER : " + InvShipper, new TextFormat { FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, Col, halfWidth, Line_Height, "CONSIGNEE : " + InvConsignee, new TextFormat { FontSize = 10 });

                _currentY = currentY;
                pdf.AddText(_currentY, rightColX, halfWidth, Line_Height, "PORT OF LOADING : " + POL, new TextFormat { Border = "", FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, rightColX, halfWidth, Line_Height, "PORT OF UNLOADING : " + POD, new TextFormat { FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, rightColX, halfWidth, Line_Height, "CONTAINER #: ", new TextFormat { FontSize = 10 });
                if (ContainerList.Count > 4)
                {
                    pdf.AddText(_currentY, rightColX + 70, halfWidth, Line_Height, " SEE ATTACHED LIST", new TextFormat {Style="B", FontSize = 10 });
                }
                else
                {
                    foreach (var c in ContainerList)
                    {
                        pdf.AddText(_currentY, rightColX+ 75, Row_Width, Line_Height, c.cntr_no!, new TextFormat { FontSize = 10 });
                        pdf.AddText(_currentY, rightColX + 150, Row_Width, Line_Height, c.cntr_type_name!, new TextFormat { FontSize = 10 });
                        
                        _currentY += Line_Height;
                    }
                }
                
                currentY += Line_Height*6;

                pdf.AddText(currentY, Col, Row_Width, Line_Height, "", new TextFormat { Border = "B",FontSize = 10 });
                currentY += Line_Height + 5;

                pdf.AddText(currentY, Col_AccName.Left, Col_AccName.Width, Line_Height, "DESCRIPTION OF CHARGES", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Remk.Left, Col_Remk.Width, Line_Height, "", new TextFormat { Border = "T", Style = "B", FontSize = 10, Indent = true });
                pdf.AddText(currentY, Col_Amount.Left, Col_Amount.Width, Line_Height, "AMOUNT", new TextFormat { Border = "LT", Style = "RB", FontSize = 10, Indent = true });
                currentY += Line_Height;
            }

            return currentY;
        }
        private void WriteFooter(float _Row, float _Col, int detailCount)
        {
            Row = _Row; 
            Col = _Col;

            float currentY = 0;
            
            int halfWidth = Row_Width / 2;
            int valueWidth = halfWidth / 2;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);

            var footerTerms1 = "";
            var footerTerms2 = "";
            var Terms1 = CommonLib.GetBranchsettings(context!, Company_id, Branch_id, "TERMS AND SERVICE 1");
            var Terms2 = CommonLib.GetBranchsettings(context!, Company_id, Branch_id, "TERMS AND SERVICE 2");
                if (Terms1.ContainsKey("TERMS AND SERVICE 1"))
                    footerTerms1 = Terms1["TERMS AND SERVICE 1"].ToString()!;
                if (Terms2.ContainsKey("TERMS AND SERVICE 2"))
                    footerTerms2 = Terms2["TERMS AND SERVICE 2"].ToString()!;
            
            var FooterText = footerTerms1 + footerTerms2;

            string printInfo = $"PRINTED ON : {Date}  BY  {User_name} ";//PAGE#: {PageNumber}

            if(!IsAttachment){
                pdf.DrawVLine(Row, Detail_Height, Col_total.Left + Col_total.Width);

                if (!IsPageBreak(Row, Line_Height, Detail_Height, detailCount))
                {
                    Row = Detail_Height;
                    decimal InvBalance = decimal.Parse(InvTotal) - decimal.Parse(InvPaid);
                    pdf.AddText(Row, Col_Default, Row_Width, Line_Height, "", new TextFormat { Border = "T", FontSize = 10 });
                    pdf.AddText(Row, Col_total.Left, Col_total.Width, Line_Height, "TOTAL ", new TextFormat { FontSize = 10, Style = "B" });
                    pdf.AddText(Row, Col_total.Left + Col_total.Width, Col_Amount.Width, Line_Height, InvTotal, new TextFormat { Border = "L", FontSize = 10, Style = "RB" });
                    Row += Line_Height;
                    pdf.AddText(Row, Col_paid.Left, Col_paid.Width, Line_Height, "PAID ", new TextFormat { FontSize = 10, Style = "B" });
                    pdf.AddText(Row, Col_paid.Left + Col_paid.Width, Col_Amount.Width, Line_Height, InvPaid, new TextFormat { Border = "L", FontSize = 10, Style = "RB" });
                    Row += Line_Height;
                    pdf.AddText(Row, Col_balance.Left, Col_balance.Width, Line_Height, $"BALANCE {InvCurCode}", new TextFormat { FontSize = 10, Style = "B" });
                    pdf.AddText(Row, Col_balance.Left + Col_balance.Width, Col_Amount.Width, Line_Height, InvBalance , new TextFormat { Border = "L", FontSize = 10, Style = "RB" });
                    pdf.AddText(Row, Col_Default, Row_Width, Line_Height, "", new TextFormat { Border = "B", FontSize = 10 });
                }
                else
                {
                    // If we need to continue the footer on the next page
                    pdf.AddText(Row, Col_Default, Row_Width, Line_Height, "", new TextFormat { Border = "T", FontSize = 10 });
                    pdf.AddText(Row, Col_Remk.Left, Col_Remk.Width, Line_Height, "CONTINUE ON NEXT PAGE", new TextFormat { Style = "B", FontSize = 10 });
                    Row += Line_Height * 2;
                    pdf.DrawVLine(_Row, Row + Line_Height, Col_total.Left + Col_total.Width);
                    pdf.AddText(Row, Col_Default, Row_Width, Line_Height, "", new TextFormat { Border = "B", FontSize = 10 });
                }
            Row += Line_Height + 3;
                pdf.AddText(Row, Col_Default, Row_Width, Line_Height, "", new TextFormat { Border="T", FontSize = 10 });//border try horizontal line
            
                Row += Line_Height;

                pdf.AddText(Row, Col, valueWidth, Line_Height, "REMARK : " , new TextFormat { FontSize = 10 });
                pdf.AddText(Row, Col + (valueWidth/2), valueWidth, Line_Height, InvRemk1, new TextFormat { FontSize = 10 });
                Row += Line_Height;
                pdf.AddText(Row, Col + (valueWidth/2), valueWidth, Line_Height, InvRemk2, new TextFormat { FontSize = 10 });
                Row += Line_Height;
                pdf.AddText(Row, Col + (valueWidth/2), valueWidth, Line_Height, InvRemk3, new TextFormat { FontSize = 10 });
                Row += Line_Height;
                var _currentY = Row;
                if(InvType == "A/R")
                {
                    _currentY = Row + Line_Height;
                    var Address = CommonLib.GetBranchAddress(context!, Company_id, Branch_id);

                    if (Address == null)
                        throw new Exception($"Address not found !");
                    
                    pdf.AddText(_currentY, Col, valueWidth, Line_Height, "REMIT TO : " , new TextFormat { FontSize = 10 });
                    pdf.AddText(_currentY, Col + (valueWidth/2), valueWidth, Line_Height, Address!.Name ?? "", new TextFormat { Style = "B", FontSize = 10 });
                    _currentY += Line_Height;

                    if (!Lib.IsBlank(Address!.Address1))
                    {
                        pdf.AddText(_currentY, Col + (valueWidth/2), valueWidth, Line_Height, Address.Address1!, new TextFormat { Style = "B", FontSize = 10 });
                        _currentY += Line_Height;
                    }
                    if (!Lib.IsBlank(Address!.Address2))
                    {
                        pdf.AddText(_currentY, Col + (valueWidth/2), valueWidth, Line_Height, Address.Address2!, new TextFormat { Style = "B", FontSize = 10 });
                        _currentY += Line_Height;
                    }
                    if (!Lib.IsBlank(Address!.Address3))
                    {
                        pdf.AddText(_currentY, Col + (valueWidth/2), valueWidth, Line_Height, Address.Address3!, new TextFormat { Style = "B", FontSize = 10 });
                        _currentY += Line_Height;
                    }
                }
                currentY = _currentY;
                _currentY = Row + Line_Height;
                pdf.AddText(_currentY, Col + halfWidth + valueWidth, halfWidth, Line_Height, "Thank you for Your Partronage " , new TextFormat { Style = "B", FontSize = 10 });
                _currentY += Line_Height;
                pdf.AddText(_currentY, Col + halfWidth + valueWidth, halfWidth, Line_Height, "Handled By : " + Handledby , new TextFormat { FontSize = 10 });

                Row = currentY + Line_Height;
                
                if(InvType == "A/R")
                { 
                    pdf.AddText(Row, Col, halfWidth, Line_Height, "TERMS : PAYABLE UPON RECEIPT IN " + InvCurCode , new TextFormat { Style = "B", FontSize = 10 });
                }
                if(InvType == "A/P")
                { 
                    InvTerms = "Please confirm the above amount within 7 days from the invoice date.Anything after will be considered as final confirmation.";
                    float TermsHeight = pdf.MeasureWrappedTextHeight(Row, Col_Default, 350, Line_Height, InvTerms!, new TextFormat{Style = "J",Indent = true});
                    pdf.AddText(Row, Col, halfWidth, Line_Height, "TERMS : PAYABLE IN "+ InvCurCode , new TextFormat { Style = "B", FontSize = 10 });
                    Row += 30;
                    pdf.AddText(Row, Col, 350, TermsHeight, InvTerms , new TextFormat { Style = "B", FontSize = 10 });
                }
            }
            Row = 775;//for footer print details(fixed)
            pdf.AddText(Row, Col_Default, Row_Width, Line_Height, printInfo, new TextFormat { Border="T", FontSize = 9 });
            Row += Line_Height;

            float TextHeight = pdf.MeasureWrappedTextHeight(Row, Col_Default, 400, Line_Height, FooterText!, new TextFormat{Style = "J",Indent = true});
            pdf.AddText(Row, Col_Default, 400, TextHeight, FooterText, new TextFormat { Border="", FontSize = 6 });
            
            // return currentY;
        }
        private void WriteAttachment(float _Row, float _Col)
        {
            Row = _Row;
            Col = _Col;
            int count = 0;

            pdf.AddNewPage();
            PageNumber++;

            float currentY = WriteHeader(_Row, _Col);
            
            pdf.AddText(currentY, Col, Row_Width, Line_Height, "CONTAINER # ", new TextFormat { Border = "B",FontSize = 10 });
            currentY += Line_Height;
            foreach (var c in ContainerList)
            {
                pdf.AddText(currentY, Col, Row_Width, Line_Height, c.cntr_no!, new TextFormat { FontSize = 10 });
                pdf.AddText(currentY, Col + 80, Row_Width, Line_Height, c.cntr_type_name!, new TextFormat { FontSize = 10 });
                
                currentY += Line_Height;
                count++;
                if (count > 30)
                {
                    WriteFooter(currentY, _Col, count);
                    currentY += Line_Height;

                    pdf.AddNewPage();
                    PageNumber++;
                    currentY = WriteHeader(_Row, _Col);
                    pdf.AddText(currentY, Col, Row_Width, Line_Height, "CONTAINER # ", new TextFormat { Border = "B",FontSize = 10 });
                    currentY += Line_Height;
                    
                    count = 0;
                }
                
            }

            currentY += Line_Height;

            WriteFooter(currentY, _Col, count);
        }

    }
}
