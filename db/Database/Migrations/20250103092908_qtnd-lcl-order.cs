using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class qtndlclorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "qtnd_order",
                table: "mark_qtnd_lcl",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "qtnd_order", "rec_created_date" },
                values: new object[] { 1, new DateTime(2025, 1, 3, 9, 29, 7, 731, DateTimeKind.Utc).AddTicks(4173) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "qtnd_order",
                table: "mark_qtnd_lcl");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 363, DateTimeKind.Utc).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 363, DateTimeKind.Utc).AddTicks(5053));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 363, DateTimeKind.Utc).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 363, DateTimeKind.Utc).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 363, DateTimeKind.Utc).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 359, DateTimeKind.Utc).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 359, DateTimeKind.Utc).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 359, DateTimeKind.Utc).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 359, DateTimeKind.Utc).AddTicks(2905));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_pkid",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 386, DateTimeKind.Utc).AddTicks(8736));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_pkid",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 3, 9, 53, 49, 382, DateTimeKind.Local).AddTicks(1865), new DateTime(2025, 1, 3, 4, 23, 49, 382, DateTimeKind.Utc).AddTicks(1926) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 320, DateTimeKind.Utc).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 320, DateTimeKind.Utc).AddTicks(4528));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 320, DateTimeKind.Utc).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 314, DateTimeKind.Utc).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 314, DateTimeKind.Utc).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 357, DateTimeKind.Utc).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 357, DateTimeKind.Utc).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 353, DateTimeKind.Utc).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6103));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6137));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6152));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6157));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6165));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 328, DateTimeKind.Utc).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 322, DateTimeKind.Utc).AddTicks(6612));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 322, DateTimeKind.Utc).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 322, DateTimeKind.Utc).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4711));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 349, DateTimeKind.Utc).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 335, DateTimeKind.Utc).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 335, DateTimeKind.Utc).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 331, DateTimeKind.Utc).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 331, DateTimeKind.Utc).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 331, DateTimeKind.Utc).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 366, DateTimeKind.Utc).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 366, DateTimeKind.Utc).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 366, DateTimeKind.Utc).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 366, DateTimeKind.Utc).AddTicks(5126));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 4, 23, 49, 366, DateTimeKind.Utc).AddTicks(5128));
        }
    }
}
