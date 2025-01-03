using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class menuparam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "mast_menum",
                columns: new[] { "menu_id", "menu_code", "menu_module_id", "menu_name", "menu_order", "menu_param", "menu_route", "menu_submenu_id", "menu_visible", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[,]
                {
                    { 811, "SALESMAN", 21, "SALESMAN", 12, "{'type':'SALESMAN'}", "master/paramList", null, "N", 1, "ADMIN", new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7443), null, null },
                    { 812, "SEA-PORT", 21, "SEA PORT", 13, "{'type':'SEA-PORT'}", "master/paramList", null, "N", 1, "ADMIN", new DateTime(2025, 1, 3, 10, 56, 35, 951, DateTimeKind.Utc).AddTicks(7445), null, null }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811);

            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 710, DateTimeKind.Utc).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 710, DateTimeKind.Utc).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 710, DateTimeKind.Utc).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 710, DateTimeKind.Utc).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 710, DateTimeKind.Utc).AddTicks(9101));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 706, DateTimeKind.Utc).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 706, DateTimeKind.Utc).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 706, DateTimeKind.Utc).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 706, DateTimeKind.Utc).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_pkid",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 731, DateTimeKind.Utc).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_pkid",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 3, 14, 59, 7, 727, DateTimeKind.Local).AddTicks(301), new DateTime(2025, 1, 3, 9, 29, 7, 727, DateTimeKind.Utc).AddTicks(354) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 668, DateTimeKind.Utc).AddTicks(5504));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 668, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 668, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 662, DateTimeKind.Utc).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 662, DateTimeKind.Utc).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 705, DateTimeKind.Utc).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 705, DateTimeKind.Utc).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 702, DateTimeKind.Utc).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5149));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5202));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5204));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5206));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 675, DateTimeKind.Utc).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 670, DateTimeKind.Utc).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 670, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 670, DateTimeKind.Utc).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 697, DateTimeKind.Utc).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 681, DateTimeKind.Utc).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 681, DateTimeKind.Utc).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 678, DateTimeKind.Utc).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 678, DateTimeKind.Utc).AddTicks(3545));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 678, DateTimeKind.Utc).AddTicks(3547));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 713, DateTimeKind.Utc).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 713, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 713, DateTimeKind.Utc).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 713, DateTimeKind.Utc).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 9, 29, 7, 713, DateTimeKind.Utc).AddTicks(7306));
        }
    }
}
