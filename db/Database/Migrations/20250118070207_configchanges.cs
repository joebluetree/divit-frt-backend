using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class configchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 585, DateTimeKind.Utc).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 585, DateTimeKind.Utc).AddTicks(5005));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 585, DateTimeKind.Utc).AddTicks(5008));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 585, DateTimeKind.Utc).AddTicks(5010));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 585, DateTimeKind.Utc).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 583, DateTimeKind.Utc).AddTicks(4106));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 583, DateTimeKind.Utc).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 583, DateTimeKind.Utc).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 583, DateTimeKind.Utc).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 612, DateTimeKind.Utc).AddTicks(6495));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 607, DateTimeKind.Utc).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 602, DateTimeKind.Utc).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 12, 32, 6, 598, DateTimeKind.Local).AddTicks(5955), new DateTime(2025, 1, 18, 7, 2, 6, 598, DateTimeKind.Utc).AddTicks(5991) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 12, 32, 6, 598, DateTimeKind.Local).AddTicks(6001), new DateTime(2025, 1, 18, 7, 2, 6, 598, DateTimeKind.Utc).AddTicks(6003) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 12, 32, 6, 598, DateTimeKind.Local).AddTicks(5996), new DateTime(2025, 1, 18, 7, 2, 6, 598, DateTimeKind.Utc).AddTicks(5998) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 556, DateTimeKind.Utc).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 556, DateTimeKind.Utc).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 556, DateTimeKind.Utc).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 551, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 551, DateTimeKind.Utc).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 582, DateTimeKind.Utc).AddTicks(5801));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 582, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 580, DateTimeKind.Utc).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6369));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6402));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6405));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 12, new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6415) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 13, new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6418) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 14, new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 15, new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6421) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 16, new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6423) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 17, new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6425) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.InsertData(
                table: "mast_menum",
                columns: new[] { "menu_id", "menu_code", "menu_module_id", "menu_name", "menu_order", "menu_param", "menu_route", "menu_submenu_id", "menu_visible", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[,]
                {
                    { 813, "AIR-PORT", 21, "Air port", 18, "{'type':'AIR-PORT'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6430), null, null },
                    { 814, "CUSTOMER-GROUP", 21, "Customer Group", 19, "{'type':'CUSTOMER-GROUP'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6432), null, null },
                    { 815, "INVOICE-DESCRIPTION", 21, "Invoice Description", 20, "{'type':'INVOICE-DESCRIPTION'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6434), null, null },
                    { 816, "CHQ-FORMAT", 21, "Check Format", 21, "{'type':'CHQ-FORMAT'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6436), null, null },
                    { 817, "CURRENCY", 21, "Currency Master", 22, "{'type':'CURRENCY'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6437), null, null },
                    { 818, "FREIGHT-STATUS", 21, "Freight Status", 23, "{'type':'FREIGHT-STATUS'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6439), null, null },
                    { 819, "NOMINATION", 21, "Nomination Status", 24, "{'type':'NOMINATION'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6469), null, null },
                    { 820, "CONTAINER-TYPE", 21, "Container Type", 25, "{'type':'CONTAINER-TYPE'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6471), null, null },
                    { 821, "CARGO-MOVEMENT", 21, "Cargo Movement", 26, "{'type':'CARGO-MOVEMENT'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6472), null, null },
                    { 822, "CONTACT-GROUP", 21, "Contact Group", 27, "{'type':'CONTACT-GROUP'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6474), null, null },
                    { 823, "HAWB-FORMAT", 21, "HAWB Format", 28, "{'type':'HAWB-FORMAT'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6476), null, null },
                    { 824, "HBL-FORMAT", 21, "HBL Format", 29, "{'type':'HBL-FORMAT'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6478), null, null },
                    { 825, "COO-FORMAT", 21, "COO Format", 30, "{'type':'COO-FORMAT'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6479), null, null },
                    { 826, "CNTR-MOVE-STATUS", 21, "Container Tracking Events", 31, "{'type':'CNTR-MOVE-STATUS'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6481), null, null },
                    { 827, "SHIP-MOVE-STATUS", 21, "Ocean Shipment Tracking Events", 32, "{'type':'SHIP-MOVE-STATUS'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6483), null, null },
                    { 828, "AIR-SHIP-MOVE-STATUS", 21, "Air Shipment Tracking Events", 33, "{'type':'AIR-SHIP-MOVE-STATUS'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6485), null, null },
                    { 829, "BUDGET-TYPE", 21, "Budget Category", 34, "{'type':'BUDGET-TYPE'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6486), null, null },
                    { 830, "FORM-CATEGORY", 21, "Form Category", 35, "{'type':'FORM-CATEGORY'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6488), null, null },
                    { 831, "UNIT-MASTER", 21, "Unit Master", 36, "{'type':'UNIT-MASTER'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6490), null, null }
                });

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 557, DateTimeKind.Utc).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 557, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 557, DateTimeKind.Utc).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 557, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6756));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6758));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6776));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6794));

            migrationBuilder.InsertData(
                table: "mast_param",
                columns: new[] { "param_id", "param_code", "param_name", "param_order", "param_type", "param_value1", "param_value2", "param_value3", "param_value4", "param_value5", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[,]
                {
                    { 26, "INR", "INDIAN RUPEE", 1, "CURRENCY", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6810), null, null },
                    { 27, "USD", "US DOLLAR", 2, "CURRENCY", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6812), null, null }
                });

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 564, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 564, DateTimeKind.Utc).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 562, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 562, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 562, DateTimeKind.Utc).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 587, DateTimeKind.Utc).AddTicks(1314));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 587, DateTimeKind.Utc).AddTicks(1319));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 587, DateTimeKind.Utc).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 587, DateTimeKind.Utc).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 587, DateTimeKind.Utc).AddTicks(1326));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 641, DateTimeKind.Utc).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 641, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 641, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 641, DateTimeKind.Utc).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 641, DateTimeKind.Utc).AddTicks(1635));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 636, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 636, DateTimeKind.Utc).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 636, DateTimeKind.Utc).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 636, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 685, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 676, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 667, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 17, 14, 24, 6, 661, DateTimeKind.Local).AddTicks(9049), new DateTime(2025, 1, 17, 8, 54, 6, 661, DateTimeKind.Utc).AddTicks(9081) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 17, 14, 24, 6, 661, DateTimeKind.Local).AddTicks(9141), new DateTime(2025, 1, 17, 8, 54, 6, 661, DateTimeKind.Utc).AddTicks(9143) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 17, 14, 24, 6, 661, DateTimeKind.Local).AddTicks(9134), new DateTime(2025, 1, 17, 8, 54, 6, 661, DateTimeKind.Utc).AddTicks(9139) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 590, DateTimeKind.Utc).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 590, DateTimeKind.Utc).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 590, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 581, DateTimeKind.Utc).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 581, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 634, DateTimeKind.Utc).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 634, DateTimeKind.Utc).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 631, DateTimeKind.Utc).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 1, new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8174) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 10, new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8176) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 10, new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8178) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 11, new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8181) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 12, new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8183) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                columns: new[] { "menu_order", "rec_created_date" },
                values: new object[] { 13, new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 592, DateTimeKind.Utc).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 592, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 592, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 592, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4062));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4067));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4069));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4078));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 604, DateTimeKind.Utc).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 604, DateTimeKind.Utc).AddTicks(9212));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 601, DateTimeKind.Utc).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 601, DateTimeKind.Utc).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 601, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 644, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 644, DateTimeKind.Utc).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 644, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 644, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 644, DateTimeKind.Utc).AddTicks(4487));
        }
    }
}
