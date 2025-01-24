using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class custchbcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cust_chb_code",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 199, DateTimeKind.Utc).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 199, DateTimeKind.Utc).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 199, DateTimeKind.Utc).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 199, DateTimeKind.Utc).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 199, DateTimeKind.Utc).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 197, DateTimeKind.Utc).AddTicks(383));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 197, DateTimeKind.Utc).AddTicks(387));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 197, DateTimeKind.Utc).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 197, DateTimeKind.Utc).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 237, DateTimeKind.Utc).AddTicks(3580));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 223, DateTimeKind.Utc).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 217, DateTimeKind.Utc).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 24, 9, 36, 36, 213, DateTimeKind.Local).AddTicks(8515), new DateTime(2025, 1, 24, 4, 6, 36, 213, DateTimeKind.Utc).AddTicks(8552) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 24, 9, 36, 36, 213, DateTimeKind.Local).AddTicks(8561), new DateTime(2025, 1, 24, 4, 6, 36, 213, DateTimeKind.Utc).AddTicks(8563) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 24, 9, 36, 36, 213, DateTimeKind.Local).AddTicks(8555), new DateTime(2025, 1, 24, 4, 6, 36, 213, DateTimeKind.Utc).AddTicks(8558) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 157, DateTimeKind.Utc).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 157, DateTimeKind.Utc).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 157, DateTimeKind.Utc).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 151, DateTimeKind.Utc).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 151, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 195, DateTimeKind.Utc).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 195, DateTimeKind.Utc).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                columns: new[] { "cust_chb_code", "rec_created_date" },
                values: new object[] { null, new DateTime(2025, 1, 24, 4, 6, 36, 192, DateTimeKind.Utc).AddTicks(1439) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(884));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(892));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(965));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(967));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(974));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(979));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(981));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(983));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(985));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(993));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 163, DateTimeKind.Utc).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 158, DateTimeKind.Utc).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 158, DateTimeKind.Utc).AddTicks(9078));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 158, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 158, DateTimeKind.Utc).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5357));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5429));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5432));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5434));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5437));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5441));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 183, DateTimeKind.Utc).AddTicks(5448));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 168, DateTimeKind.Utc).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 168, DateTimeKind.Utc).AddTicks(1686));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 165, DateTimeKind.Utc).AddTicks(5101));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 165, DateTimeKind.Utc).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 165, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 202, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 202, DateTimeKind.Utc).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 202, DateTimeKind.Utc).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 202, DateTimeKind.Utc).AddTicks(1666));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 202, DateTimeKind.Utc).AddTicks(1669));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cust_chb_code",
                table: "mast_customerm");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 783, DateTimeKind.Utc).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 783, DateTimeKind.Utc).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 783, DateTimeKind.Utc).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 783, DateTimeKind.Utc).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 783, DateTimeKind.Utc).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 779, DateTimeKind.Utc).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 779, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 779, DateTimeKind.Utc).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 779, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 829, DateTimeKind.Utc).AddTicks(378));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 820, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 810, DateTimeKind.Utc).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 14, 35, 14, 805, DateTimeKind.Local).AddTicks(9513), new DateTime(2025, 1, 23, 9, 5, 14, 805, DateTimeKind.Utc).AddTicks(9546) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 14, 35, 14, 805, DateTimeKind.Local).AddTicks(9555), new DateTime(2025, 1, 23, 9, 5, 14, 805, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 14, 35, 14, 805, DateTimeKind.Local).AddTicks(9550), new DateTime(2025, 1, 23, 9, 5, 14, 805, DateTimeKind.Utc).AddTicks(9553) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 711, DateTimeKind.Utc).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 711, DateTimeKind.Utc).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 711, DateTimeKind.Utc).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 703, DateTimeKind.Utc).AddTicks(3164));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 703, DateTimeKind.Utc).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 778, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 778, DateTimeKind.Utc).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 773, DateTimeKind.Utc).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3580));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3583));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3688));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3692));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3696));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3698));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3700));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3704));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3709));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3715));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 719, DateTimeKind.Utc).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 713, DateTimeKind.Utc).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 713, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 713, DateTimeKind.Utc).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 713, DateTimeKind.Utc).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(56));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(102));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(127));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(134));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 755, DateTimeKind.Utc).AddTicks(143));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 726, DateTimeKind.Utc).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 726, DateTimeKind.Utc).AddTicks(1466));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 722, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 722, DateTimeKind.Utc).AddTicks(6040));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 722, DateTimeKind.Utc).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 787, DateTimeKind.Utc).AddTicks(6229));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 787, DateTimeKind.Utc).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 787, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 787, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 5, 14, 787, DateTimeKind.Utc).AddTicks(6242));
        }
    }
}
