using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class menu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 521, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 521, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 521, DateTimeKind.Utc).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 521, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 521, DateTimeKind.Utc).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 518, DateTimeKind.Utc).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 518, DateTimeKind.Utc).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 518, DateTimeKind.Utc).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 518, DateTimeKind.Utc).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 544, DateTimeKind.Utc).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 540, DateTimeKind.Utc).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 536, DateTimeKind.Utc).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 25, 10, 53, 45, 533, DateTimeKind.Local).AddTicks(9974), new DateTime(2025, 1, 25, 5, 23, 45, 533, DateTimeKind.Utc).AddTicks(9999) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 25, 10, 53, 45, 534, DateTimeKind.Local).AddTicks(7), new DateTime(2025, 1, 25, 5, 23, 45, 534, DateTimeKind.Utc).AddTicks(9) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 25, 10, 53, 45, 534, DateTimeKind.Local).AddTicks(2), new DateTime(2025, 1, 25, 5, 23, 45, 534, DateTimeKind.Utc).AddTicks(5) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 485, DateTimeKind.Utc).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 485, DateTimeKind.Utc).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 485, DateTimeKind.Utc).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 478, DateTimeKind.Utc).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 478, DateTimeKind.Utc).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 510, DateTimeKind.Utc).AddTicks(5811));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 510, DateTimeKind.Utc).AddTicks(5816));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 508, DateTimeKind.Utc).AddTicks(5733));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 505, DateTimeKind.Utc).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5911));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5977));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5986));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5992));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6025));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.InsertData(
                table: "mast_menum",
                columns: new[] { "menu_id", "menu_code", "menu_module_id", "menu_name", "menu_order", "menu_param", "menu_route", "menu_submenu_id", "menu_visible", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[,]
                {
                    { 832, "WIRETRANSM", 21, "Wire Transfer Instruction", 37, "{'type':'WIRETRANSM'}", "masters/wiretransmList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6033), null, null },
                    { 833, "REMARKS", 21, "Remarks", 38, "{'type':'REMARKS'}", "masters/remarkList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 25, 5, 23, 45, 490, DateTimeKind.Utc).AddTicks(6035), null, null }
                });

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 486, DateTimeKind.Utc).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 486, DateTimeKind.Utc).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 486, DateTimeKind.Utc).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 486, DateTimeKind.Utc).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 486, DateTimeKind.Utc).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8281));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8289));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8301));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8309));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8320));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8399));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8439));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8451));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8455));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8479));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 504, DateTimeKind.Utc).AddTicks(8445));

            migrationBuilder.UpdateData(
                table: "mast_remarkd",
                keyColumn: "remd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 512, DateTimeKind.Utc).AddTicks(4866));

            migrationBuilder.UpdateData(
                table: "mast_remarkm",
                keyColumn: "rem_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 511, DateTimeKind.Utc).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 493, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 493, DateTimeKind.Utc).AddTicks(5511));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 492, DateTimeKind.Utc).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 492, DateTimeKind.Utc).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 492, DateTimeKind.Utc).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "mast_wiretransd",
                keyColumn: "wtid_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 517, DateTimeKind.Utc).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "mast_wiretransm",
                keyColumn: "wtim_id",
                keyValue: 1,
                columns: new[] { "rec_created_date", "wtim_date" },
                values: new object[] { new DateTime(2025, 1, 25, 5, 23, 45, 514, DateTimeKind.Utc).AddTicks(763), new DateTime(2025, 1, 25, 10, 53, 45, 514, DateTimeKind.Local).AddTicks(746) });

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 523, DateTimeKind.Utc).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 523, DateTimeKind.Utc).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 523, DateTimeKind.Utc).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 523, DateTimeKind.Utc).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 25, 5, 23, 45, 523, DateTimeKind.Utc).AddTicks(8279));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 832);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 833);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 562, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 562, DateTimeKind.Utc).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 562, DateTimeKind.Utc).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 562, DateTimeKind.Utc).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 562, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 561, DateTimeKind.Utc).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 561, DateTimeKind.Utc).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 561, DateTimeKind.Utc).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 561, DateTimeKind.Utc).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 583, DateTimeKind.Utc).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 579, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 575, DateTimeKind.Utc).AddTicks(3580));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 14, 49, 57, 572, DateTimeKind.Local).AddTicks(7716), new DateTime(2025, 1, 23, 9, 19, 57, 572, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 14, 49, 57, 572, DateTimeKind.Local).AddTicks(7759), new DateTime(2025, 1, 23, 9, 19, 57, 572, DateTimeKind.Utc).AddTicks(7761) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 14, 49, 57, 572, DateTimeKind.Local).AddTicks(7753), new DateTime(2025, 1, 23, 9, 19, 57, 572, DateTimeKind.Utc).AddTicks(7757) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 527, DateTimeKind.Utc).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 527, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 527, DateTimeKind.Utc).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 522, DateTimeKind.Utc).AddTicks(9035));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 522, DateTimeKind.Utc).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 553, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 553, DateTimeKind.Utc).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 551, DateTimeKind.Utc).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3117));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3163));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3168));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3171));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3173));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3174));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 528, DateTimeKind.Utc).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 528, DateTimeKind.Utc).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 528, DateTimeKind.Utc).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 528, DateTimeKind.Utc).AddTicks(7292));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 528, DateTimeKind.Utc).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3943));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3978));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3982));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3994));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4023));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4028));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4077));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4101));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4106));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4165));

            migrationBuilder.UpdateData(
                table: "mast_remarkd",
                keyColumn: "remd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 556, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "mast_remarkm",
                keyColumn: "rem_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 554, DateTimeKind.Utc).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 534, DateTimeKind.Utc).AddTicks(3936));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 534, DateTimeKind.Utc).AddTicks(3952));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 532, DateTimeKind.Utc).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 532, DateTimeKind.Utc).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 532, DateTimeKind.Utc).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "mast_wiretransd",
                keyColumn: "wtid_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 560, DateTimeKind.Utc).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "mast_wiretransm",
                keyColumn: "wtim_id",
                keyValue: 1,
                columns: new[] { "rec_created_date", "wtim_date" },
                values: new object[] { new DateTime(2025, 1, 23, 9, 19, 57, 557, DateTimeKind.Utc).AddTicks(8053), new DateTime(2025, 1, 23, 14, 49, 57, 557, DateTimeKind.Local).AddTicks(8036) });

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 564, DateTimeKind.Utc).AddTicks(1666));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 564, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 564, DateTimeKind.Utc).AddTicks(1672));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 564, DateTimeKind.Utc).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 564, DateTimeKind.Utc).AddTicks(1675));
        }
    }
}
