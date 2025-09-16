using System;
using Database.Lib;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Masters.Interfaces
{
    public interface IExcelBase
    {
        void CreateSheet(string sheetName);
        void CellValue(int rowIndex, int colIndex, object data, CellFormat? options = null);
        void AutoSizeColumns(int columnCount);
        void AutoSizeColumn(int columnNumber);
        void Save(string filePath);
    }
    public class CellFormat
    {
        public string Style { get; set; } = "";     // e.g., "B", "I", "U"
        public string FontName { get; set; } = "Calibri";
        public int FontSize { get; set; } = 10;
        public string HAlign { get; set; } = "L";    // L=Left, R=Right, C=Center, J=Justify for Horizontal Alignment
        public string VAlign { get; set; } = "C";    // T=Top, B=Bottom, C=Center, J=Justify for Vertical Alignment
        public string Border { get; set; } = "";       // e.g., "A", "LR", "TB"
        public int Merge { get; set; } = -1;
        public bool WrapText { get; set; } = false;
        public string Case { get; set; } = "U";      // "U" = UPPER, "L" = lower, "" = original
        public int? ColumnWidth { get; set; }           // Optional: width in characters
        public int MergeCols { get; set; } = 0; // How many additional columns to merge (default 0 = no merge)
        public int MergeRows { get; set; } = 0; // How many additional rows to merge (default 0 = no merge)

    }

    public class TextExcel : IExcelBase
    {
        private IWorkbook workbook;
        private ISheet sheet;
        private ICellStyle style;

        public TextExcel()
        {
            workbook = new XSSFWorkbook();
        }

        public void CreateSheet(string sheetName)
        {
            sheet = workbook.CreateSheet(sheetName);
        }

        public void AutoSizeColumns(int columnCount)
        {
            for (int i = 0; i < columnCount; i++)
            {
                AutoSizeColumn(i);
            }
        }

        public void AutoSizeColumn(int columnNumber)
        {
            sheet.AutoSizeColumn(columnNumber);
        }

        public void Save(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
        }

        public void CellValue(int rowIndex, int colIndex, object data, CellFormat? options = null)
        {
            options ??= new CellFormat();

            string rawValue = data?.ToString() ?? "";
            string value = rawValue;

            // Apply Text Case
            if (!Lib.IsBlank(options.Case))
            {
                string textCase = options.Case?.ToUpper() ?? "";
                if (textCase == "U") value = value.ToUpper();
                if (textCase == "L") value = value.ToLower();
            }

            // Prepare row and cell
            IRow row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            ICell cell = row.CreateCell(colIndex);

            // Create and configure font
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = (short)options.FontSize;
            font.FontName = options.FontName;

            if (!Lib.IsBlank(options.Style))
            {
                string fontStyle = options.Style?.ToUpper() ?? "";
                if (fontStyle.Contains("B")) font.IsBold = true;
                if (fontStyle.Contains("I")) font.IsItalic = true;
                if (fontStyle.Contains("U")) font.Underline = FontUnderlineType.Single;
            }
            // Create and configure cell style
            style = workbook.CreateCellStyle();
            style.SetFont(font);
            if (options.WrapText == true)
            {
                style.WrapText = true;

            }
            // Alignment
            if (!Lib.IsBlank(options.HAlign))
            {
                string align = options.HAlign?.ToUpper() ?? "L";
                if (align == "C") style.Alignment = HorizontalAlignment.Center;
                if (align == "R") style.Alignment = HorizontalAlignment.Right;
                if (align == "J") style.Alignment = HorizontalAlignment.Justify;
                if (align != "C" && align != "R" && align != "J") style.Alignment = HorizontalAlignment.Left;
            }
            if (!Lib.IsBlank(options.VAlign))
            {
                string align = options.VAlign?.ToUpper() ?? "C";
                if (align == "T") style.VerticalAlignment = VerticalAlignment.Top;
                if (align == "B") style.VerticalAlignment = VerticalAlignment.Bottom;
                if (align == "J") style.VerticalAlignment = VerticalAlignment.Justify;
                if (align != "T" && align != "B" && align != "J") style.VerticalAlignment = VerticalAlignment.Center;

            }
            // Borders
            if (!Lib.IsBlank(options.Border))
            {
                string border = options.Border?.ToUpper() ?? "";
                if (border.Contains("A") || border.Contains("L")) style.BorderLeft = BorderStyle.Thin;
                if (border.Contains("A") || border.Contains("R")) style.BorderRight = BorderStyle.Thin;
                if (border.Contains("A") || border.Contains("T")) style.BorderTop = BorderStyle.Thin;
                if (border.Contains("A") || border.Contains("B")) style.BorderBottom = BorderStyle.Thin;
            }
            // Set column width if specified
            if (options.ColumnWidth.HasValue)
            {
                sheet.SetColumnWidth(colIndex, options.ColumnWidth.Value * 256); // NPOI expects width in 1/256th character units
            }

            // Apply final style
            cell.CellStyle = style;
            int spanCols = options.MergeCols;
            int spanRows = options.MergeRows;
            if (spanCols > 0 || spanRows > 0)
            {
                int endRow = rowIndex + spanRows;
                int endCol = colIndex + spanCols;

                // Apply style to all cells in the range
                for (int r = rowIndex; r <= endRow; r++)
                {
                    IRow mergeRow = sheet.GetRow(r) ?? sheet.CreateRow(r);
                    for (int c = colIndex; c <= endCol; c++)
                    {
                        ICell targetCell = mergeRow.GetCell(c) ?? mergeRow.CreateCell(c);
                        targetCell.CellStyle = style;

                        // Only the top-left cell gets the value
                        if (r == rowIndex && c == colIndex)
                            targetCell.SetCellValue(value);
                        else
                            targetCell.SetCellValue("");
                    }
                }
                if (endCol > colIndex)
                {
                    // Merge region
                    sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(rowIndex, endRow, colIndex, endCol));
                }
            }
            // if (options.Merge >= 0)
            // {
            //     int endCol = options.Merge > colIndex ? options.Merge : colIndex;
            //     for (int i = colIndex; i <= endCol; i++)
            //     {
            //         ICell targetCell = row.GetCell(i) ?? row.CreateCell(i);
            //         targetCell.CellStyle = style;

            //         // Only first cell holds the value
            //         if (i == colIndex)
            //             targetCell.SetCellValue(value);
            //         else
            //             targetCell.SetCellValue("");
            //     }

            // Merge if applicable
            // if (endCol > colIndex)
            // {
            //     sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(rowIndex, rowIndex, colIndex, options.Merge));
            // }
        // }
            if (options.Merge < 0)
            {
                cell.SetCellValue(value);
            }
        }


    }
}
