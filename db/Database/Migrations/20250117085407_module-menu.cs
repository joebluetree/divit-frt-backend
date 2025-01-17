using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class modulemenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8230));

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

            migrationBuilder.InsertData(
                table: "mast_modulem",
                columns: new[] { "module_id", "module_is_installed", "module_name", "module_order", "module_parent_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[] { 23, "Y", "Marketing", 2, null, 1, "ADMIN", new DateTime(2025, 1, 17, 8, 54, 6, 592, DateTimeKind.Utc).AddTicks(2780), null, null });

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

            migrationBuilder.InsertData(
                table: "mast_menum",
                columns: new[] { "menu_id", "menu_code", "menu_module_id", "menu_name", "menu_order", "menu_param", "menu_route", "menu_submenu_id", "menu_visible", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[,]
                {
                    { 901, "QUOTATIONS-LCL", 23, "Quotations Lcl & Local", 1, "{'type':'QUOTATIONS-LCL'}", "marketing/qtnmlclList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8256), null, null },
                    { 902, "QUOTATIONS-FCL", 23, "Quotations Fcl", 2, "{'type':'QUOTATIONS-FCL'}", "marketing/qtnmfclList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8258), null, null },
                    { 903, "QUOTATIONS-AIR", 23, "Quotations Air", 3, "{'type':'QUOTATIONS-AIR'}", "marketing/qtnmairList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8260), null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903);

            migrationBuilder.DeleteData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 21, DateTimeKind.Utc).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 21, DateTimeKind.Utc).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 21, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 21, DateTimeKind.Utc).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 21, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 17, DateTimeKind.Utc).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 17, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 17, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 17, DateTimeKind.Utc).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 62, DateTimeKind.Utc).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 53, DateTimeKind.Utc).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 45, DateTimeKind.Utc).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 17, 14, 10, 36, 40, DateTimeKind.Local).AddTicks(5139), new DateTime(2025, 1, 17, 8, 40, 36, 40, DateTimeKind.Utc).AddTicks(5168) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 17, 14, 10, 36, 40, DateTimeKind.Local).AddTicks(5219), new DateTime(2025, 1, 17, 8, 40, 36, 40, DateTimeKind.Utc).AddTicks(5221) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 17, 14, 10, 36, 40, DateTimeKind.Local).AddTicks(5213), new DateTime(2025, 1, 17, 8, 40, 36, 40, DateTimeKind.Utc).AddTicks(5217) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 965, DateTimeKind.Utc).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 965, DateTimeKind.Utc).AddTicks(5773));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 965, DateTimeKind.Utc).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 956, DateTimeKind.Utc).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 956, DateTimeKind.Utc).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 16, DateTimeKind.Utc).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 16, DateTimeKind.Utc).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 9, DateTimeKind.Utc).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 973, DateTimeKind.Utc).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 967, DateTimeKind.Utc).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 967, DateTimeKind.Utc).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 967, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1844));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 4, DateTimeKind.Utc).AddTicks(1859));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 981, DateTimeKind.Utc).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 981, DateTimeKind.Utc).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 977, DateTimeKind.Utc).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 977, DateTimeKind.Utc).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 35, 977, DateTimeKind.Utc).AddTicks(132));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 23, DateTimeKind.Utc).AddTicks(9358));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 23, DateTimeKind.Utc).AddTicks(9362));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 23, DateTimeKind.Utc).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 23, DateTimeKind.Utc).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 40, 36, 23, DateTimeKind.Utc).AddTicks(9367));
        }
    }
}
