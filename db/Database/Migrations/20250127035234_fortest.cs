using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class fortest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 51, DateTimeKind.Utc).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 51, DateTimeKind.Utc).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 51, DateTimeKind.Utc).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 51, DateTimeKind.Utc).AddTicks(393));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 51, DateTimeKind.Utc).AddTicks(395));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 49, DateTimeKind.Utc).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 49, DateTimeKind.Utc).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 49, DateTimeKind.Utc).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 49, DateTimeKind.Utc).AddTicks(3477));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 70, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 66, DateTimeKind.Utc).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 62, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 27, 9, 22, 34, 60, DateTimeKind.Local).AddTicks(5114), new DateTime(2025, 1, 27, 3, 52, 34, 60, DateTimeKind.Utc).AddTicks(5136) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 27, 9, 22, 34, 60, DateTimeKind.Local).AddTicks(5169), new DateTime(2025, 1, 27, 3, 52, 34, 60, DateTimeKind.Utc).AddTicks(5171) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 27, 9, 22, 34, 60, DateTimeKind.Local).AddTicks(5140), new DateTime(2025, 1, 27, 3, 52, 34, 60, DateTimeKind.Utc).AddTicks(5142) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 7, DateTimeKind.Utc).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 7, DateTimeKind.Utc).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 7, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 2, DateTimeKind.Utc).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 2, DateTimeKind.Utc).AddTicks(8835));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 42, DateTimeKind.Utc).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 42, DateTimeKind.Utc).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 40, DateTimeKind.Utc).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1363));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1377));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1389));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1391));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1396));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1411));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 832,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 833,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 11, DateTimeKind.Utc).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 8, DateTimeKind.Utc).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 8, DateTimeKind.Utc).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 8, DateTimeKind.Utc).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 8, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 8, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5024));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5038));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5044));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5056));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5131));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5153));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5202));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5204));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5247));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 28, DateTimeKind.Utc).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "mast_remarkd",
                keyColumn: "remd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 44, DateTimeKind.Utc).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "mast_remarkm",
                keyColumn: "rem_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 43, DateTimeKind.Utc).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 14, DateTimeKind.Utc).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 14, DateTimeKind.Utc).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 12, DateTimeKind.Utc).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 12, DateTimeKind.Utc).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 12, DateTimeKind.Utc).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "mast_wiretransd",
                keyColumn: "wtid_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 48, DateTimeKind.Utc).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "mast_wiretransm",
                keyColumn: "wtim_id",
                keyValue: 1,
                columns: new[] { "rec_created_date", "wtim_date" },
                values: new object[] { new DateTime(2025, 1, 27, 3, 52, 34, 45, DateTimeKind.Utc).AddTicks(7890), new DateTime(2025, 1, 27, 9, 22, 34, 45, DateTimeKind.Local).AddTicks(7873) });

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 52, DateTimeKind.Utc).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 52, DateTimeKind.Utc).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 52, DateTimeKind.Utc).AddTicks(5301));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 52, DateTimeKind.Utc).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 52, 34, 52, DateTimeKind.Utc).AddTicks(5304));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 472, DateTimeKind.Utc).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 472, DateTimeKind.Utc).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 472, DateTimeKind.Utc).AddTicks(5232));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 472, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 472, DateTimeKind.Utc).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 470, DateTimeKind.Utc).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 470, DateTimeKind.Utc).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 470, DateTimeKind.Utc).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 470, DateTimeKind.Utc).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 492, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 488, DateTimeKind.Utc).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 484, DateTimeKind.Utc).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 27, 9, 19, 49, 481, DateTimeKind.Local).AddTicks(9544), new DateTime(2025, 1, 27, 3, 49, 49, 481, DateTimeKind.Utc).AddTicks(9562) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 27, 9, 19, 49, 481, DateTimeKind.Local).AddTicks(9570), new DateTime(2025, 1, 27, 3, 49, 49, 481, DateTimeKind.Utc).AddTicks(9571) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 27, 9, 19, 49, 481, DateTimeKind.Local).AddTicks(9565), new DateTime(2025, 1, 27, 3, 49, 49, 481, DateTimeKind.Utc).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 429, DateTimeKind.Utc).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 429, DateTimeKind.Utc).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 429, DateTimeKind.Utc).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 425, DateTimeKind.Utc).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 425, DateTimeKind.Utc).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 464, DateTimeKind.Utc).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 464, DateTimeKind.Utc).AddTicks(3989));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 461, DateTimeKind.Utc).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3348));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3393));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3395));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3397));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3399));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3402));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3411));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3413));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3444));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3449));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3452));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3454));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3455));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3457));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 832,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3458));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 833,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3460));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 433, DateTimeKind.Utc).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 430, DateTimeKind.Utc).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 430, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 430, DateTimeKind.Utc).AddTicks(7446));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 430, DateTimeKind.Utc).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 430, DateTimeKind.Utc).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4416));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4528));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 450, DateTimeKind.Utc).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "mast_remarkd",
                keyColumn: "remd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 465, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "mast_remarkm",
                keyColumn: "rem_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 464, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 436, DateTimeKind.Utc).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 436, DateTimeKind.Utc).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 434, DateTimeKind.Utc).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 434, DateTimeKind.Utc).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 434, DateTimeKind.Utc).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "mast_wiretransd",
                keyColumn: "wtid_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 470, DateTimeKind.Utc).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "mast_wiretransm",
                keyColumn: "wtim_id",
                keyValue: 1,
                columns: new[] { "rec_created_date", "wtim_date" },
                values: new object[] { new DateTime(2025, 1, 27, 3, 49, 49, 467, DateTimeKind.Utc).AddTicks(4949), new DateTime(2025, 1, 27, 9, 19, 49, 467, DateTimeKind.Local).AddTicks(4933) });

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 473, DateTimeKind.Utc).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 473, DateTimeKind.Utc).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 473, DateTimeKind.Utc).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 473, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 27, 3, 49, 49, 473, DateTimeKind.Utc).AddTicks(8082));
        }
    }
}
