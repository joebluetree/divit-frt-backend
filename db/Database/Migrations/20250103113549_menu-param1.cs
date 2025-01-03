using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class menuparam1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 708, DateTimeKind.Utc).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 708, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 708, DateTimeKind.Utc).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 708, DateTimeKind.Utc).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 708, DateTimeKind.Utc).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 704, DateTimeKind.Utc).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 704, DateTimeKind.Utc).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 704, DateTimeKind.Utc).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 704, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_pkid",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 740, DateTimeKind.Utc).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_pkid",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 3, 17, 5, 48, 735, DateTimeKind.Local).AddTicks(4010), new DateTime(2025, 1, 3, 11, 35, 48, 735, DateTimeKind.Utc).AddTicks(4076) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 661, DateTimeKind.Utc).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 661, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 661, DateTimeKind.Utc).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 654, DateTimeKind.Utc).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 654, DateTimeKind.Utc).AddTicks(6137));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 702, DateTimeKind.Utc).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 702, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 697, DateTimeKind.Utc).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7578));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7582));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7623));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7625));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                columns: new[] { "menu_name", "menu_route", "menu_visible", "rec_created_date" },
                values: new object[] { "Salesman", "masters/paramList", "Y", new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7660) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                columns: new[] { "menu_name", "menu_route", "menu_visible", "rec_created_date" },
                values: new object[] { "Sea port", "masters/paramList", "Y", new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7664) });

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 663, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 663, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 663, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 693, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 676, DateTimeKind.Utc).AddTicks(6828));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 676, DateTimeKind.Utc).AddTicks(6831));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 673, DateTimeKind.Utc).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 673, DateTimeKind.Utc).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 673, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 711, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 711, DateTimeKind.Utc).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 711, DateTimeKind.Utc).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 711, DateTimeKind.Utc).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 711, DateTimeKind.Utc).AddTicks(9608));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 983, DateTimeKind.Utc).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 983, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 983, DateTimeKind.Utc).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 983, DateTimeKind.Utc).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 983, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 979, DateTimeKind.Utc).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 979, DateTimeKind.Utc).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 979, DateTimeKind.Utc).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 979, DateTimeKind.Utc).AddTicks(9920));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_pkid",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 36, 4, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_pkid",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 3, 16, 26, 35, 999, DateTimeKind.Local).AddTicks(5494), new DateTime(2025, 1, 3, 10, 56, 35, 999, DateTimeKind.Utc).AddTicks(5552) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 944, DateTimeKind.Utc).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 944, DateTimeKind.Utc).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 944, DateTimeKind.Utc).AddTicks(2757));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 938, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 938, DateTimeKind.Utc).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 978, DateTimeKind.Utc).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 978, DateTimeKind.Utc).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 975, DateTimeKind.Utc).AddTicks(2924));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7318));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7320));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                columns: new[] { "menu_name", "menu_route", "menu_visible", "rec_created_date" },
                values: new object[] { "SALESMAN", "master/paramList", "N", new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7443) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                columns: new[] { "menu_name", "menu_route", "menu_visible", "rec_created_date" },
                values: new object[] { "SEA PORT", "master/paramList", "N", new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7445) });

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 946, DateTimeKind.Utc).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 946, DateTimeKind.Utc).AddTicks(3255));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 946, DateTimeKind.Utc).AddTicks(3257));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3483));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3507));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3514));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3519));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3521));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 971, DateTimeKind.Utc).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 957, DateTimeKind.Utc).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 957, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 954, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 954, DateTimeKind.Utc).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 954, DateTimeKind.Utc).AddTicks(6667));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 986, DateTimeKind.Utc).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 986, DateTimeKind.Utc).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 986, DateTimeKind.Utc).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 986, DateTimeKind.Utc).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 10, 56, 35, 986, DateTimeKind.Utc).AddTicks(4563));
        }
    }
}
