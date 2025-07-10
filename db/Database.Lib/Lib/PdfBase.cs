using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DataBase.Pdf
{
    public interface iPdfBase
    {

        void CreateDocument(string _fileName, string _PageSize = "A4", float _Width = 0, float _Height = 0);
        void AddText(float _nRow, float _nCol, float _rowWidth, float _rowHeight, object _Data, TextFormat? options = null);
        void AddNewPage();
        void CloseDocument();
        void DrawHLine(float _Row, float _Col1, float _Col2);
        void DrawVLine(float _Row1, float _Row2, float _Col);
        void DrawBox(float _Row1, float _Col1, float _Row2, float _Col2);
        void AddImage(string _imagePath, float _Row, float _Col, float _newWidth = 0, float _newHeight = 0);
        void AddBarcode(float _Row, float _Col, string _sValue, float _newWidth = 0, float _newHeight = 0);
        void AddQRcode(float _Row, float _Col, string _sValue, float _newWidth = 0, float _newHeight = 0);
        float MeasureWrappedTextHeight(float Row, float Col, float ColWidth, float Line_Height, object Data, TextFormat? options = null);
    }

    public class TextFormat
    {
        public string Border { get; set; } = "";
        public string Style { get; set; } = "";     // e.g., "B", "I", "U"
        public string FontName { get; set; } = "Calibri";
        public int FontSize { get; set; } = 10;
        public bool Indent { get; set; } = false;

    }

    public class ColumnFormat
    {
        public float Left { get; set; } = 0;
        public float Width { get; set; } = 0;
    }

    public class TextSharpPdf : iPdfBase
    {
        public string Error = "";
        public string File_Name = "";
        PdfWriter writer;
        Document doc;
        private float Page_Height = 842;
        private float Page_Width = 595;
        private string PageSize;

        public TextSharpPdf() //
        {
            Page_Height = 0;
            Page_Width = 0;
        }

        public void CreateDocument(string _fileName, string _PageSize = "A4", float _Width = 0, float _Height = 0)
        {
            PageSize = _PageSize;
            if (_Width > 0)
                Page_Width = _Width;
            if (_Height > 0)
                Page_Height = _Height;

            File_Name = _fileName;
            if (File_Name == "")
                return;

            doc = new Document();
            writer = PdfWriter.GetInstance(doc, new FileStream(File_Name, FileMode.Create));
            doc.Open();
            AddNewPage();
        }

        public void AddNewPage()
        {
            doc.NewPage();
            if (PageSize == "A4")
            {
                doc.SetPageSize(iTextSharp.text.PageSize.A4);
                Page_Height = iTextSharp.text.PageSize.A4.Height;
                Page_Width = iTextSharp.text.PageSize.A4.Width;
            }
            else
            {
                iTextSharp.text.Rectangle _size = new iTextSharp.text.Rectangle(Page_Width, Page_Height);
                doc.SetPageSize(_size);
            }
        }

        public void AddText(float _Row, float _Col, float _rowWidth, float _rowHeight, object _Data, TextFormat? options = null)
        {
            string textToAdd = "";
            float padding = 0f;

            if (_Data == null)
                textToAdd = "";
            else
                textToAdd = _Data.ToString()!;

            if (options!.FontName == "")
                options.FontName = "Calibri";

            PdfContentByte pcb = writer.DirectContent;

            int sAlign = Element.ALIGN_LEFT;
            if (options.Style.IndexOf("C") >= 0)
                sAlign = Element.ALIGN_CENTER;
            if (options.Style.IndexOf("R") >= 0)
                sAlign = Element.ALIGN_RIGHT;
            if (options.Style.IndexOf("J") >= 0)
                sAlign = Element.ALIGN_JUSTIFIED;

            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(_Col, (Page_Height - _Row - _rowHeight), _Col + _rowWidth, (Page_Height - _Row)); //changed these rowHeight position
            if (options.Border.IndexOf("A") >= 0)
            {
                rect.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                rect.BorderWidth = 0.1f;
                rect.BorderColor = BaseColor.BLACK;
            }
            if (options.Border.IndexOf("L") >= 0)
            {
                rect.BorderWidthLeft = 0.1f;
                rect.BorderColorLeft = BaseColor.BLACK;
            }
            if (options.Border.IndexOf("B") >= 0)
            {
                rect.BorderWidthBottom = 0.1f;
                rect.BorderColorBottom = BaseColor.BLACK;
            }
            if (options.Border.IndexOf("R") >= 0)
            {
                rect.BorderWidthRight = 0.1f;
                rect.BorderColorRight = BaseColor.BLACK;
            }
            if (options.Border.IndexOf("T") >= 0)
            {
                rect.BorderWidthTop = 0.1f;
                rect.BorderColorTop = BaseColor.BLACK;
            }


            if (options.Indent)
            {
                padding = 2f;
            }

            pcb.Rectangle(rect);
            pcb.Stroke();

            ColumnText ct = new ColumnText(pcb);
            ct.SetSimpleColumn(new Phrase(textToAdd, GetFont(options.FontName, options.FontSize, options.Style)), rect.Left + padding, rect.Bottom + padding, rect.Right - padding, rect.Top, 12, sAlign);
            ct.Go();
            //ColumnText.ShowTextAligned(pbover, sAlign, new Phrase(textToAdd, font), nCol + 1, (_pageHt - nRow) + 1, 0); 
        }

        public float MeasureWrappedTextHeight(float Row, float Col, float ColWidth, float Line_Height, object Data, TextFormat? options = null)
        {
            string textToAdd = "";

            if (Data == null)
                textToAdd = "";
            else
                textToAdd = Data.ToString()!;
            textToAdd = textToAdd.TrimEnd();

            if (string.IsNullOrEmpty(textToAdd)) return Line_Height;
            if (ColWidth <= 0) return 0;

            Font font = GetFont(options!.FontName, options.FontSize, options.Style);
            BaseFont baseFont = font.BaseFont;
            float textWidth = baseFont.GetWidthPoint(textToAdd, font.Size);

            // Buffer logic
            float buffer = 3f;
            if (textWidth >= ColWidth)
                ColWidth += buffer;

            Phrase phrase = new Phrase(textToAdd, font);

            float colLeft = Col;
            float colRight = Col + ColWidth;
            float colTop = Page_Height - Row; // Page_Height - Y (row) gives top Y
            float colBottom = 0;

            ColumnText ct = new ColumnText(null);
            ct.SetSimpleColumn(phrase, colLeft, colBottom, colRight, colTop, Line_Height, GetAlignment(options.Style));

            int status = ct.Go(true);
            float usedHeight = (colTop - ct.YLine);

            if ((status & ColumnText.NO_MORE_TEXT) == 0)
                usedHeight += Line_Height;

            float ColHeight = Math.Max(usedHeight, Line_Height);
            return ColHeight;
        }


        private int GetAlignment(string style)
        {
            int sAlign = Element.ALIGN_LEFT;

            style = style?.ToUpper() ?? "";

            if (style.Contains("C"))
                sAlign = Element.ALIGN_CENTER;
            if (style.Contains("R"))
                sAlign = Element.ALIGN_RIGHT;
            if (style.Contains("J"))
                sAlign = Element.ALIGN_JUSTIFIED;

            return sAlign;
        }



        public void CloseDocument()
        {
            doc.Close();
            writer.Close();
        }

        public void DrawHLine(float _Row, float _Col1, float _Col2)
        {
            PdfContentByte pcb = writer.DirectContent;
            pcb.SetLineWidth(0.1f);
            pcb.MoveTo(_Col1, Page_Height - _Row);
            pcb.LineTo(_Col2, Page_Height - _Row);
            pcb.Stroke();
        }

        public void DrawVLine(float _Row1, float _Row2, float _Col)
        {
            PdfContentByte pcb = writer.DirectContent;
            pcb.SetLineWidth(0.1f);
            pcb.MoveTo(_Col, Page_Height - _Row1);
            pcb.LineTo(_Col, Page_Height - _Row2);
            pcb.Stroke();
        }

        public void DrawBox(float _Row1, float _Col1, float _Row2, float _Col2)
        {
            PdfContentByte pcb = writer.DirectContent;
            pcb.SetLineWidth(0.1f);
            pcb.Rectangle(_Col1, Page_Height - _Row1, _Col2 - _Col1, (Page_Height - _Row2) - (Page_Height - _Row1));
            pcb.Stroke();
        }

        public void AddImage(string _imagePath, float _Row, float _Col, float _newWidth = 0, float _newHeight = 0)
        {
            try
            {
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(_imagePath);

                // Set the absolute position of the image on the page and scale it
                img.SetAbsolutePosition(_Col, Page_Height - _Row);
                if (_newWidth > 0 && _newHeight > 0)
                    img.ScaleToFit(_newWidth, _newHeight);
                // Add the image to the document
                doc.Add(img);
            }
            catch (Exception ex)
            {
                Error = ex.Message.ToString();
            }
        }

        public void AddBarcode(float _Row, float _Col, string _sValue, float _newWidth = 0, float _newHeight = 0)
        {
            try
            {
                Barcode128 barcode = new Barcode128();
                barcode.Code = _sValue;
                barcode.StartStopText = false;

                // Generate the barcode image as an iTextSharp Image
                iTextSharp.text.Image barcodeImage = barcode.CreateImageWithBarcode(writer.DirectContent, null, null);
                barcodeImage.SetAbsolutePosition(_Col + 25, Page_Height - _Row);
                if (_newWidth > 0 && _newHeight > 0)
                    barcodeImage.ScaleToFit(_newWidth, _newHeight);
                // Add the barcode image to the document
                doc.Add(barcodeImage);
            }
            catch (Exception ex)
            {
                Error = ex.Message.ToString();
            }
        }

        public void AddQRcode(float _Row, float _Col, string _sValue, float _newWidth = 0, float _newHeight = 0)
        {
            try
            { // Generate the QR code image
                BarcodeQRCode qrCode = new BarcodeQRCode(_sValue, 1, 1, null);
                iTextSharp.text.Image qrCodeImage = qrCode.GetImage();
                qrCodeImage.SetAbsolutePosition(_Col + 25, Page_Height - _Row);
                if (_newWidth > 0 && _newHeight > 0)
                    qrCodeImage.ScaleToFit(_newWidth, _newHeight);
                doc.Add(qrCodeImage);
            }
            catch (Exception ex)
            {
                Error = ex.Message.ToString();
            }
        }

        //Old Font Code

        // public iTextSharp.text.Font GetFont(string _fontName, float _fontSize, string _Style)
        // {
        //     iTextSharp.text.Font iFont = new iTextSharp.text.Font();
        //     if (_fontName == "LIBREBARCODE39")
        //     {
        //         string fontPath = "C:\\Reports\\Images\\LibreBarcode39-Regular.ttf";
        //         //fontPath = "C:\\Reports\\Images\\LibreBarcode39-Regular.ttf";
        //         fontPath = "C:\\Users\\Admin\\AppData\\Local\\Microsoft\\Windows\\Fonts\\LibreBarcode39-Regular.ttf";
        //         // Register your custom font C:\Users\Admin\AppData\Local\Microsoft\Windows\Fonts
        //         BaseFont customBaseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //         iFont = new iTextSharp.text.Font(customBaseFont, _fontSize);
        //     }
        //     else
        //     {
        //         iFont.Size = _fontSize;
        //         iFont.SetFamily(_fontName);
        //     }


        //     if (_Style.IndexOf("B") >= 0)
        //         iFont.SetStyle(iTextSharp.text.Font.BOLD);
        //     if (_Style.IndexOf("I") >= 0)
        //         iFont.SetStyle(iTextSharp.text.Font.ITALIC);
        //     if (_Style.IndexOf("U") >= 0)
        //         iFont.SetStyle(iTextSharp.text.Font.UNDERLINE);
        //     if (_Style.IndexOf("S") >= 0)
        //         iFont.SetStyle(iTextSharp.text.Font.STRIKETHRU);

        //     return iFont;
        // }

        //New Code for GetFont

        public iTextSharp.text.Font GetFont(string _fontName, float _fontSize, string _Style)
        {
            iTextSharp.text.Font iFont;

            if (!string.IsNullOrEmpty(_fontName) && _fontName.ToUpper() == "LIBREBARCODE39")
            {
                // Custom barcode font path
                string fontPath = "C:\\Users\\Admin\\AppData\\Local\\Microsoft\\Windows\\Fonts\\LibreBarcode39-Regular.ttf";
                BaseFont customBaseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iFont = new iTextSharp.text.Font(customBaseFont, _fontSize);
            }
            else
            {
                // Try to get a system font using FontFactory
                int fontStyle = iTextSharp.text.Font.NORMAL;

                if (_Style.IndexOf("B") >= 0) fontStyle |= iTextSharp.text.Font.BOLD;
                if (_Style.IndexOf("I") >= 0) fontStyle |= iTextSharp.text.Font.ITALIC;
                if (_Style.IndexOf("U") >= 0) fontStyle |= iTextSharp.text.Font.UNDERLINE;
                if (_Style.IndexOf("S") >= 0) fontStyle |= iTextSharp.text.Font.STRIKETHRU;

                iFont = FontFactory.GetFont(_fontName, BaseFont.CP1252, _fontSize, fontStyle);

                // Fallback if font is not found or BaseFont is null
                if (iFont == null || iFont.BaseFont == null)
                {
                    BaseFont fallbackBaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iFont = new iTextSharp.text.Font(fallbackBaseFont, _fontSize, fontStyle);
                }
            }

            return iFont;
        }

    }
}
