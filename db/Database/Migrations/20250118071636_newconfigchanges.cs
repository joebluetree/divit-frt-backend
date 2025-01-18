using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class newconfigchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "mast_param",
                columns: new[] { "param_id", "param_code", "param_name", "param_order", "param_type", "param_value1", "param_value2", "param_value3", "param_value4", "param_value5", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[,]
                {
                    { 28, "CMA", "CMA CHM", 1, "AIR-PORT", "CMDU", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9842), null, null },
                    { 29, "ZIM", "ZIM", 2, "AIR-PORT", "ZIMU", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9844), null, null },
                    { 30, "101", "LOCAL CREDITORS", 1, "CUSTOMER-GROUP", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9848), null, null },
                    { 31, "102", "LOCAL DEBTORS", 2, "CUSTOMER-GROUP", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9849), null, null },
                    { 32, "101", "ACCOUNTANT SERVICE FEE", 1, "INVOICE-DESCRIPTION", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9853), null, null },
                    { 33, "102", "ADMIN FEE", 2, "INVOICE-DESCRIPTION", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9855), null, null },
                    { 34, "ASTORIA", "ASTORIA", 1, "CHQ-FORMAT", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9859), null, null },
                    { 35, "COLLECT", "COLLECT", 1, "FREIGHT-STATUS", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9869), null, null },
                    { 36, "PREPAID", "PREPAID", 2, "FREIGHT-STATUS", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9871), null, null },
                    { 37, "FREEHAND", "FREEHAND", 1, "NOMINATION", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9875), null, null },
                    { 38, "MUTUAL", "MUTUAL", 2, "NOMINATION", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9876), null, null },
                    { 39, "20FR", "20' FR", 1, "CONTAINER-TYPE", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9882), null, null },
                    { 40, "40FR", "40' FR", 2, "CONTAINER-TYPE", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9884), null, null },
                    { 41, "CFS/CFS", "CFS/CFS", 1, "CARGO-MOVEMENT", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9888), null, null },
                    { 42, "DOOR/DOOR", "DOOR/DOOR", 2, "CARGO-MOVEMENT", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9890), null, null },
                    { 43, "FOR REMITTANCE", "FOR REMITTANCE", 1, "CONTACT-GROUP", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9894), null, null },
                    { 44, "NA", "NA", 2, "CONTACT-GROUP", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9930), null, null },
                    { 45, "DEFAULT", "DEFAULT FORMAT", 1, "HAWB-FORMAT", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9936), null, null },
                    { 46, "MOTHERLINES", "MOTHERLINES BLANK", 1, "HBL-FORMAT", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9939), null, null },
                    { 47, "MLINES-DRAFT", "MOTHERLINES DRAFT", 2, "HBL-FORMAT", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9941), null, null },
                    { 48, "DEFAULT", "DEFAULT FORMAT", 1, "COO-FORMAT", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9945), null, null },
                    { 49, "101", "CONTAINER LOADED ON BOARD", 1, "CNTR-MOVE-STATUS", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9949), null, null },
                    { 50, "102", "CONTAINER TRANSSHIPPED", 2, "CNTR-MOVE-STATUS", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9952), null, null },
                    { 51, "101", "CONTAINER IS DEVANNING", 1, "SHIP-MOVE-STATUS", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9956), null, null },
                    { 52, "102", "SHIPMENT ON TRANSIT", 2, "SHIP-MOVE-STATUS", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9958), null, null },
                    { 53, "101", "SHIPMENT ARRIVED", 1, "AIR-SHIP-MOVE-STATUS", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9962), null, null },
                    { 54, "EMPLOYEE", "EMPLOYEE", 1, "BUDGET-TYPE", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9968), null, null },
                    { 55, "MARKETING", "MARKETING", 2, "BUDGET-TYPE", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9970), null, null },
                    { 56, "ACCOUNTING FORM", "ACCOUNTING FORM", 1, "FORM-CATEGORY", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9974), null, null },
                    { 57, "APPLICATION", "APPLICATION", 2, "FORM-CATEGORY", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9976), null, null },
                    { 58, "101", "UNIT MASTER 1", 1, "UNIT-MASTER", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2025, 1, 18, 7, 16, 35, 941, DateTimeKind.Utc).AddTicks(9980), null, null }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58);

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
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6420));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6472));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6478));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6485));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 560, DateTimeKind.Utc).AddTicks(6490));

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

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 7, 2, 6, 577, DateTimeKind.Utc).AddTicks(6812));

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
    }
}
