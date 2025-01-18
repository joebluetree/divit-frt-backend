using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class newdatachanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 53);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 166, DateTimeKind.Utc).AddTicks(6884));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 166, DateTimeKind.Utc).AddTicks(6888));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 166, DateTimeKind.Utc).AddTicks(6891));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 166, DateTimeKind.Utc).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 166, DateTimeKind.Utc).AddTicks(6895));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 164, DateTimeKind.Utc).AddTicks(6123));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 164, DateTimeKind.Utc).AddTicks(6126));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 164, DateTimeKind.Utc).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 164, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 185, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 181, DateTimeKind.Utc).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 178, DateTimeKind.Utc).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 13, 4, 38, 176, DateTimeKind.Local).AddTicks(2175), new DateTime(2025, 1, 18, 7, 34, 38, 176, DateTimeKind.Utc).AddTicks(2196) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 13, 4, 38, 176, DateTimeKind.Local).AddTicks(2203), new DateTime(2025, 1, 18, 7, 34, 38, 176, DateTimeKind.Utc).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 13, 4, 38, 176, DateTimeKind.Local).AddTicks(2199), new DateTime(2025, 1, 18, 7, 34, 38, 176, DateTimeKind.Utc).AddTicks(2201) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 146, DateTimeKind.Utc).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 146, DateTimeKind.Utc).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 146, DateTimeKind.Utc).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 143, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 143, DateTimeKind.Utc).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 163, DateTimeKind.Utc).AddTicks(8109));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 163, DateTimeKind.Utc).AddTicks(8112));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 162, DateTimeKind.Utc).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4788));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4793));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4794));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 149, DateTimeKind.Utc).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 147, DateTimeKind.Utc).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 147, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 147, DateTimeKind.Utc).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 147, DateTimeKind.Utc).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6052));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6063));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6124));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6180));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6185));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6211));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6213));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6217));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6220));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6229));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.InsertData(
                table: "mast_param",
                columns: new[] { "param_id", "param_code", "param_name", "param_order", "param_type", "param_value1", "param_value2", "param_value3", "param_value4", "param_value5", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[] { 59, "101", "SHIPMENT ARRIVED", 1, "AIR-SHIP-MOVE-STATUS", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 34, 38, 160, DateTimeKind.Utc).AddTicks(6224), null, null });

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 151, DateTimeKind.Utc).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 151, DateTimeKind.Utc).AddTicks(9665));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 150, DateTimeKind.Utc).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 150, DateTimeKind.Utc).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 150, DateTimeKind.Utc).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 167, DateTimeKind.Utc).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 167, DateTimeKind.Utc).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 167, DateTimeKind.Utc).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 167, DateTimeKind.Utc).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 34, 38, 167, DateTimeKind.Utc).AddTicks(9365));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 948, DateTimeKind.Utc).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 948, DateTimeKind.Utc).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 948, DateTimeKind.Utc).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 948, DateTimeKind.Utc).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 948, DateTimeKind.Utc).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 946, DateTimeKind.Utc).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 946, DateTimeKind.Utc).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 946, DateTimeKind.Utc).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 946, DateTimeKind.Utc).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 972, DateTimeKind.Utc).AddTicks(5597));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 967, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 962, DateTimeKind.Utc).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 12, 46, 35, 960, DateTimeKind.Local).AddTicks(3446), new DateTime(2025, 1, 18, 7, 16, 35, 960, DateTimeKind.Utc).AddTicks(3468) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 12, 46, 35, 960, DateTimeKind.Local).AddTicks(3476), new DateTime(2025, 1, 18, 7, 16, 35, 960, DateTimeKind.Utc).AddTicks(3478) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 12, 46, 35, 960, DateTimeKind.Local).AddTicks(3471), new DateTime(2025, 1, 18, 7, 16, 35, 960, DateTimeKind.Utc).AddTicks(3474) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 917, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 917, DateTimeKind.Utc).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 917, DateTimeKind.Utc).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 914, DateTimeKind.Utc).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 914, DateTimeKind.Utc).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 946, DateTimeKind.Utc).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 946, DateTimeKind.Utc).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 944, DateTimeKind.Utc).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7668));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7690));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 926, DateTimeKind.Utc).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 918, DateTimeKind.Utc).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 918, DateTimeKind.Utc).AddTicks(5963));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 918, DateTimeKind.Utc).AddTicks(5964));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 918, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9809));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9811));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9827));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9849));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9882));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9884));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9939));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9958));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9980));

            migrationBuilder.InsertData(
                table: "mast_param",
                columns: new[] { "param_id", "param_code", "param_name", "param_order", "param_type", "param_value1", "param_value2", "param_value3", "param_value4", "param_value5", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[] { 53, "101", "SHIPMENT ARRIVED", 1, "AIR-SHIP-MOVE-STATUS", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9962), null, null });

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 931, DateTimeKind.Utc).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 931, DateTimeKind.Utc).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 929, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 929, DateTimeKind.Utc).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 929, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 950, DateTimeKind.Utc).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 950, DateTimeKind.Utc).AddTicks(5857));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 950, DateTimeKind.Utc).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 950, DateTimeKind.Utc).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 16, 35, 950, DateTimeKind.Utc).AddTicks(5889));
        }
    }
}
