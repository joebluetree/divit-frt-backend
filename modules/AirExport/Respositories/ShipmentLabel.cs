using System;
using System.Data;
using Common.Lib;
using Database.Models.Cargo;
using DataBase.Pdf;

namespace AirExport.Repositories
{
    public class ShipmentLabel
    {
        iPdfBase pdf = null!;
        public List<filesm> fList = new List<filesm>();
        public string report_folder = "";
        public DataTable Dt_List = new DataTable();
        public bool is_express_mode = false;
        private string Agent = "NEW AGENT"; //
        private string Carrier = "NEW CARRIER";
        private string pol = "NEW POL";
        private string pod = "NEW POD";
        private string Handled = "NEW HANDLED BY";
        private int ID = 0;
        private string RefNo = "NEW REFNO";


        private string File_Name = "";
        private string File_Display_Name = "";
        private string File_Type = "";
        private string folderid = "";
        private float Row = 0;
        private float Col = 0;

        public ShipmentLabel()
        {
            pdf = new TextSharpPdf();
        }

        public void Process()
        {
            try
            {
                fList = new List<filesm>();
                folderid = Guid.NewGuid().ToString().ToUpper();
                foreach (DataRow dr in Dt_List.Rows)
                {

                    Agent = dr["mbl_agent_name"].ToString()!;
                    Carrier = dr["mbl_liner_name"].ToString()!;
                    RefNo = dr["mbl_refno"].ToString()!;
                    pod = dr["mbl_pod_name"].ToString()!;
                    pol = dr["mbl_pol_name"].ToString()!;
                    Handled = dr["mbl_handled_name"].ToString()!;
                    ID = Database.Lib.Lib.StringToInteger(dr["mbl_id"].ToString()!);

                    File_Display_Name = $"{RefNo}";

                    File_Display_Name += ".pdf";

                    File_Display_Name = Database.Lib.Lib.ProperFileName(File_Display_Name);
                    File_Name = Database.Lib.Lib.GetFileName(report_folder, folderid, File_Display_Name.ToLower(), false);
                    File_Type = "PDF";
                    PrintData();
                    fList.Add(Database.Lib.Lib.AddFiles(File_Name, File_Type, File_Display_Name));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void PrintData()
        {

            pdf.CreateDocument(File_Name);
            int SlNo = 0;

            CreateFormat(35, 30, SlNo);

            pdf.CloseDocument();
        }

        private void CreateFormat(float _Row, float _Col, int _SlNo)
        {
            Row = _Row;

            float boxWidth = 250;
            float boxHeight = 25;

            // Header Title
            pdf.AddText(Row, _Col + 1, boxWidth, boxHeight, "Shipment Label", new TextFormat { _Style = "BL", _fontSize = 13 });
            Row += boxHeight;

            // ID + RefNo block
            pdf.AddText(Row, _Col + 2, boxWidth, boxHeight, $"ID: {ID}",new TextFormat { _fontSize = 9});
            Row += boxHeight;
            pdf.AddText(Row, _Col + 2, boxWidth, boxHeight, $"RefNo: {RefNo}",new TextFormat { _fontSize = 9});
            Row += boxHeight;

            // Master Agent + Carrier block
            pdf.AddText(Row, _Col + 2, boxWidth, boxHeight, $"Master Agent: {Agent}",new TextFormat { _fontSize = 9});
            Row += boxHeight;
            pdf.AddText(Row, _Col + 2, boxWidth, boxHeight, $"Carrier: {Carrier}", new TextFormat { _fontSize = 9});
            Row += boxHeight;
            pdf.AddText(Row, _Col + 2, boxWidth, boxHeight, $"Handled By: {Handled}", new TextFormat { _fontSize = 9});
            Row += boxHeight;

            // POD + POL block
            pdf.AddText(Row, _Col + 2, boxWidth, boxHeight, $"POD: {pod}", new TextFormat { _fontSize = 9});
            Row += boxHeight;
            pdf.AddText(Row, _Col + 2, boxWidth, boxHeight, $"POL: {pol}", new TextFormat { _fontSize = 9});
        }


    }
}