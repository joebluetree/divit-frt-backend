using System;
using System.Collections.Generic;
using System.Data;
using Common.DTO.Marketing;
using Common.DTO.Masters;
using Common.DTO.OtherOp;
using Common.DTO.Report;
using Common.DTO.SeaExport;
using Common.DTO.SeaImport;
using Common.Lib;
using Database;
using Database.Lib;
using Database.Models.Cargo;
using Masters.Interfaces;
using NPOI.SS.Formula.Functions;

namespace Report.Printing
{
    public class ConsigneeShipmentExcelFile
    {
        IExcelBase excel = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public List<rep_consigneeship_dto> Dt_List { get; set; } = new List<rep_consigneeship_dto>();
        public string Title { get; set; } = "";
        public int Company_id { get; set; }
        public int Branch_id { get; set; }
        public AppDbContext? context { get; set; }
        public string DateType { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string HblFormat { get; set; } = "";
        public string ParentName { get; set; } = "";
        public string BlType { get; set; } = "";
        public string OpGroup { get; set; } = "";
        public string ConsigneeName { get; set; } = "";
        public string User_name { get; set; } = "";
        public bool IsSeaImp { get; set; } = false;
        public bool IsSeaExp { get; set; } = false;
        public bool IsAirImp { get; set; } = false;
        public bool IsAirExp { get; set; } = false;


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private string Date = "";
        private int col_count = 0; // Column Total count
        private int PageNumber = 0;

        public ConsigneeShipmentExcelFile()
        {
            excel = new TextExcel();
        }

        public void Process()
        {
            try
            {
                fList = new List<filesm>();
                folderid = Guid.NewGuid().ToString().ToUpper();

                File_Display_Name = Title.ToString()!.ToLower();
                File_Display_Name += ".xlsx";
                File_Display_Name = Lib.ProperFileName(File_Display_Name);
                File_Name = Lib.GetFileName(report_folder, folderid, File_Display_Name, false);
                File_Type = "EXCEL";

                CreateExcelData();

                fList.Add(Lib.AddFiles(File_Name, File_Type, File_Display_Name));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        private void CreateExcelData()
        {
            int rowIndex = 0;
            int colIndex = 0;
            int count = 0;
            rowIndex = WriteHeader(rowIndex, colIndex);

            foreach (rep_consigneeship_dto dr in Dt_List)
            {
                count++;

                var BL = CommonLib.IsLastRow(count, Dt_List.Count());

                var hbl_ref_date = Lib.FormatDate(Lib.ParseDate(dr.hbl_ref_date!), Lib.DisplayDateFormat) ?? "";
                var hbl_eta = Lib.FormatDate(Lib.ParseDate(dr.hbl_pod_eta!), Lib.DisplayDateFormat) ?? "";
                var hbl_etd = Lib.FormatDate(Lib.ParseDate(dr.hbl_pol_etd!), Lib.DisplayDateFormat) ?? "";
                var hbl_delv_date = Lib.FormatDate(Lib.ParseDate(dr.hbl_delivery_date!), Lib.DisplayDateFormat) ?? "";
                var hbl_lfd = Lib.FormatDate(Lib.ParseDate(dr.cntr_lfd!), Lib.DisplayDateFormat) ?? "";
                
                if(HblFormat == "SHIPMENT STATUS REPORT" && BlType == "MASTER WISE")
                {
                    excel.CellValue(rowIndex, colIndex + 0, dr.hbl_mbl_refno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 1, hbl_ref_date.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 2, dr.hbl_pol_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 3, dr.hbl_pod_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    if(IsSeaExp || IsSeaImp)
                        excel.CellValue(rowIndex, colIndex + 4, dr.hbl_cntr_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    if(IsAirExp || IsAirImp)
                        excel.CellValue(rowIndex, colIndex + 4, dr.hbl_mbl_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 5, dr.hbl_shipper_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex, colIndex + 6, dr.hbl_consignee_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex, colIndex + 7, hbl_etd.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 8, hbl_eta.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    if(IsSeaExp)
                    {
                        excel.CellValue(rowIndex, colIndex + 9, dr.hbl_vessel_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                        excel.CellValue(rowIndex++, colIndex + 10, dr.hbl_voyage!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    }
                    if(IsSeaImp)
                    {
                        excel.CellValue(rowIndex, colIndex + 9, hbl_lfd.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 10, dr.cntr_pick_status!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 11, dr.cntr_pick_date!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 12, dr.hbl_vessel_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                        excel.CellValue(rowIndex, colIndex + 13, dr.hbl_voyage!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex++, colIndex + 14, dr.hbl_an_sent!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9});
                    }
                    if(IsAirImp)
                    {
                        excel.CellValue(rowIndex++, colIndex + 9, dr.hbl_an_sent!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    }
                }
                if(HblFormat == "CONSIGNEE SHIPMENT REPORT" && BlType == "MASTER WISE")
                {
                    excel.CellValue(rowIndex, colIndex + 0, dr.hbl_mbl_refno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 1, hbl_ref_date.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    if(IsSeaExp)
                        excel.CellValue(rowIndex, colIndex + 2, dr.hbl_cntr_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    if(IsAirExp)
                        excel.CellValue(rowIndex, colIndex + 2, dr.hbl_mbl_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 3, dr.hbl_shipper_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex, colIndex + 4, dr.hbl_consignee_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex, colIndex + 5, dr.hbl_pol_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex, colIndex + 6, hbl_etd, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 7, dr.hbl_pod_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex ++, colIndex + 8, hbl_eta, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                }

                if(HblFormat == "SHIPMENT STATUS REPORT" && BlType == "HOUSE WISE")
                {
                    excel.CellValue(rowIndex, colIndex + 0, dr.hbl_mbl_refno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 1, hbl_ref_date.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 2, dr.hbl_pol_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 3, dr.hbl_pod_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 4, dr.hbl_houseno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    if(IsSeaExp || IsSeaImp)
                        excel.CellValue(rowIndex, colIndex + 5, dr.hbl_cntr_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    if(IsAirExp || IsAirImp)
                        excel.CellValue(rowIndex, colIndex + 5, dr.hbl_mbl_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 6, dr.hbl_packages!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 7, dr.hbl_shipper_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex, colIndex + 8, dr.hbl_consignee_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex, colIndex + 9, hbl_etd.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 10, hbl_eta.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 11, hbl_delv_date.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    if(IsSeaExp)
                    {
                        excel.CellValue(rowIndex, colIndex + 12, dr.hbl_vessel_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                        excel.CellValue(rowIndex, colIndex + 13, dr.hbl_voyage!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex++, colIndex + 14, dr.hbl_remarks!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    }
                    if(IsSeaImp)
                    {
                        excel.CellValue(rowIndex, colIndex + 12, dr.hbl_location_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 13, dr.hbl_pono!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 14, hbl_lfd.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 15, dr.cntr_pick_status!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 16, dr.cntr_pick_date!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 17, dr.hbl_vessel_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                        excel.CellValue(rowIndex, colIndex + 18, dr.hbl_voyage!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 19, dr.hbl_an_sent!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                        excel.CellValue(rowIndex++, colIndex + 20, dr.hbl_remarks!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    }
                    if(IsAirExp)
                    {
                        excel.CellValue(rowIndex, colIndex + 12, dr.hbl_remarks!, new CellFormat { Border = "TB", Style = "B", FontSize = 9, WrapText = true });
                    }
                    if(IsAirImp)
                    {
                        excel.CellValue(rowIndex, colIndex + 12, dr.hbl_location_name!, new CellFormat { Border = "TB", Style = "B", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 13, dr.hbl_pono!, new CellFormat { Border = "TB", Style = "B", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 14, dr.cntr_lfd!, new CellFormat { Border = "TB", Style = "B", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 15, dr.hbl_an_sent!, new CellFormat { Border = "TB", Style = "B", FontSize = 9 });
                        excel.CellValue(rowIndex, colIndex + 16, dr.hbl_remarks!, new CellFormat { Border = "TB", Style = "B", FontSize = 9, WrapText = true });
                    }
                }
                if(HblFormat == "CONSIGNEE SHIPMENT REPORT" && BlType == "HOUSE WISE")
                {
                    excel.CellValue(rowIndex, colIndex + 0, dr.hbl_mbl_refno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 1, hbl_ref_date.ToUpper(), new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 2, dr.hbl_houseno!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    if(IsSeaExp)
                        excel.CellValue(rowIndex, colIndex + 3, dr.hbl_cntr_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    if(IsAirExp)
                        excel.CellValue(rowIndex, colIndex + 3, dr.hbl_mbl_no!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 4, dr.hbl_shipper_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex, colIndex + 5, dr.hbl_consignee_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex, colIndex + 6, dr.hbl_weight!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 7, dr.hbl_pol_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex, colIndex + 8, hbl_etd, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                    excel.CellValue(rowIndex, colIndex + 9, dr.hbl_pod_name!, new CellFormat { Border = "" + BL, Style = "", FontSize = 9, WrapText = true });
                    excel.CellValue(rowIndex ++, colIndex + 10, hbl_eta, new CellFormat { Border = "" + BL, Style = "", FontSize = 9 });
                }
            }

            excel.SetColumnBreak(colIndex + 4);
            excel.Save(File_Name);
        }

        private int WriteHeader(int rowIndex, int colIndex)
        {
            if (rowIndex == 0)
            {
                excel.CreateSheet("Sheet1");
                excel.PrintGridlines(true);// for grid lines On/Off
            }

            PageNumber++;

            var currentDate = DbLib.GetDateTime();
            Date = Lib.FormatDate(currentDate, Lib.DisplayDateTimeFormat);
            var SFromDate = Lib.FormatDate(Lib.ParseDate(FromDate), Lib.DisplayDateFormat) ?? "";
            var SToDate = Lib.FormatDate(Lib.ParseDate(ToDate), Lib.DisplayDateFormat) ?? "";

            rowIndex = CommonLib.WriteBranchAddressExcel(rowIndex, colIndex, col_count, Company_id, Branch_id, context!, excel);
            rowIndex += 1;
 
            IsSeaExp = OpGroup == "SEA EXPORT" ;
            IsSeaImp = OpGroup == "SEA IMPORT" ;
            IsAirExp = OpGroup == "AIR EXPORT" ;
            IsAirImp = OpGroup == "AIR IMPORT" ;

            if(HblFormat == "SHIPMENT STATUS REPORT" && BlType == "MASTER WISE")
            {
                if(IsSeaExp) col_count = 10;
                if(IsSeaImp) col_count = 14;
                if(IsAirExp) col_count = 8;
                if(IsAirImp) col_count = 9;
            }
            if(HblFormat == "SHIPMENT STATUS REPORT" && BlType == "HOUSE WISE")
            {
                if(IsSeaExp) col_count = 14;
                if(IsSeaImp) col_count = 20;
                if(IsAirExp) col_count = 12;
                if(IsAirImp) col_count = 16;
            }
            if(HblFormat == "CONSIGNEE SHIPMENT REPORT")
            {
                if(BlType == "MASTER WISE") col_count = 8;
                if(BlType == "HOUSE WISE") col_count = 10;
            }

            excel.CellValue(rowIndex, colIndex, Title.ToUpper()!, new CellFormat { Border = "TB", Style = "B", ColumnWidth = 15, FontSize = 10, MergeCols = col_count });
            rowIndex += 1;

            excel.CellValue(rowIndex, colIndex, "DATE TYPE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, DateType, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "CONSIGNEE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, ConsigneeName, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "FROM DATE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SFromDate, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "TYPE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, BlType, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "TO DATE", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, SToDate, new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 3, "FORMAT", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 4, HblFormat, new CellFormat { Style = "B", FontSize = 10 });
            rowIndex += 1;
            excel.CellValue(rowIndex, colIndex, "PARENT", new CellFormat { Style = "B", FontSize = 10 });
            excel.CellValue(rowIndex, colIndex + 1, ParentName, new CellFormat { Style = "B", FontSize = 10 });

            rowIndex += 1;

            if(HblFormat == "SHIPMENT STATUS REPORT" && BlType == "MASTER WISE")
            {
                excel.CellValue(rowIndex, colIndex + 0, "REF#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 1, "REF DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 2, "ORIGIN", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 3, "DESTINATION", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                if(IsSeaExp || IsSeaImp)
                    excel.CellValue(rowIndex, colIndex + 4, "CONTAINER #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                if(IsAirExp || IsAirImp)
                    excel.CellValue(rowIndex, colIndex + 4, "AWB #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 5, "SHIPPER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 6, "CONSIGNEE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 7, "ETD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 8, "ETA", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                
                if(IsSeaExp)
                {
                    excel.CellValue(rowIndex, colIndex + 9, "VESSEL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                    excel.CellValue(rowIndex, colIndex + 10, "VOYAGE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                }
                if(IsSeaImp)
                {
                    excel.CellValue(rowIndex, colIndex + 9, "LFD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 10 });
                    excel.CellValue(rowIndex, colIndex + 10, "CNTR P/U STATUS", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                    excel.CellValue(rowIndex, colIndex + 11, "CNTR P/U DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                    excel.CellValue(rowIndex, colIndex + 12, "VESSEL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                    excel.CellValue(rowIndex, colIndex + 13, "VOYAGE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                    excel.CellValue(rowIndex, colIndex + 14, "ARRIVAL NOTICE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                }
                if(IsAirImp)
                {
                    excel.CellValue(rowIndex, colIndex + 9, "ARRIVAL NOTICE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                }
            }
            if(HblFormat == "CONSIGNEE SHIPMENT REPORT" && BlType == "MASTER WISE" )
            {
                excel.CellValue(rowIndex, colIndex + 0, "REF#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 1, "REF DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                if(IsSeaExp || IsSeaImp)
                    excel.CellValue(rowIndex, colIndex + 2, "CONTAINER #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                if(IsAirExp || IsAirImp)
                    excel.CellValue(rowIndex, colIndex + 2, "AWB #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 3, "SHIPPER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 4, "CONSIGNEE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 5, "POL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 6, "ETD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 7, "POD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 8, "ETA", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            }
            
            if(HblFormat == "SHIPMENT STATUS REPORT" && BlType == "HOUSE WISE")
            {
                excel.CellValue(rowIndex, colIndex + 0, "REF#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 1, "REF DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 2, "ORIGIN", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 3, "DESTINATION", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 4, "B/L NO", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                if(IsSeaExp || IsSeaImp)
                    excel.CellValue(rowIndex, colIndex + 5, "CONTAINER #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                if(IsAirExp || IsAirImp)
                    excel.CellValue(rowIndex, colIndex + 5, "AWB #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 6, "PCS", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 7, "SHIPPER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 8, "CONSIGNEE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 9, "ETD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 10, "ETA", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 11, "DELIVERY DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                
                if(IsSeaExp)
                {
                    excel.CellValue(rowIndex, colIndex + 12, "VESSEL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                    excel.CellValue(rowIndex, colIndex + 13, "VOYAGE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                    excel.CellValue(rowIndex, colIndex + 14, "REMARKS", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 25 });
                }
                if(IsSeaImp)
                {
                    excel.CellValue(rowIndex, colIndex + 12, "TERMINAL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                    excel.CellValue(rowIndex, colIndex + 13, "PO #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                    excel.CellValue(rowIndex, colIndex + 14, "LFD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 10 });
                    excel.CellValue(rowIndex, colIndex + 15, "CNTR P/U STATUS", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                    excel.CellValue(rowIndex, colIndex + 16, "CNTR P/U DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                    excel.CellValue(rowIndex, colIndex + 17, "VESSEL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                    excel.CellValue(rowIndex, colIndex + 18, "VOYAGE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                    excel.CellValue(rowIndex, colIndex + 19, "ARRIVAL NOTICE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                    excel.CellValue(rowIndex, colIndex + 20, "REMARKS", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 25 });
                }
                if(IsAirExp)
                {
                    excel.CellValue(rowIndex, colIndex + 12, "REMARKS", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 25 });
                }
                if(IsAirImp)
                {
                    excel.CellValue(rowIndex, colIndex + 12, "TERMINAL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                    excel.CellValue(rowIndex, colIndex + 13, "PO #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                    excel.CellValue(rowIndex, colIndex + 14, "LFD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 10 });
                    excel.CellValue(rowIndex, colIndex + 15, "ARRIVAL NOTICE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                    excel.CellValue(rowIndex, colIndex + 16, "REMARKS", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 25 });
                }
            }
            if(HblFormat == "CONSIGNEE SHIPMENT REPORT" && BlType == "HOUSE WISE" )
            {
                excel.CellValue(rowIndex, colIndex + 0, "REF#", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 1, "REF DATE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 2, "B/L NO", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                if(IsSeaExp || IsSeaImp)
                    excel.CellValue(rowIndex, colIndex + 3, "CONTAINER #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                if(IsAirExp || IsAirImp)
                    excel.CellValue(rowIndex, colIndex + 3, "AWB #", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 4, "SHIPPER", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 5, "CONSIGNEE", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 6, "WEIGHT", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 30 });
                excel.CellValue(rowIndex, colIndex + 7, "POL", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 8, "ETD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
                excel.CellValue(rowIndex, colIndex + 9, "POD", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 20 });
                excel.CellValue(rowIndex, colIndex + 10, "ETA", new CellFormat { Border = "TB", Style = "B", FontSize = 10, ColumnWidth = 15 });
            }
            rowIndex += 1;
            return rowIndex;
        }
    }
}