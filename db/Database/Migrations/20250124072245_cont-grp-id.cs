using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class contgrpid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cont_group_id",
                table: "mast_contactm",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 487, DateTimeKind.Utc).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 487, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 487, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 487, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 487, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 483, DateTimeKind.Utc).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 483, DateTimeKind.Utc).AddTicks(9827));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 483, DateTimeKind.Utc).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 483, DateTimeKind.Utc).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 535, DateTimeKind.Utc).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 527, DateTimeKind.Utc).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 519, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 24, 12, 52, 44, 506, DateTimeKind.Local).AddTicks(8150), new DateTime(2025, 1, 24, 7, 22, 44, 506, DateTimeKind.Utc).AddTicks(8181) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 24, 12, 52, 44, 506, DateTimeKind.Local).AddTicks(8190), new DateTime(2025, 1, 24, 7, 22, 44, 506, DateTimeKind.Utc).AddTicks(8192) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 24, 12, 52, 44, 506, DateTimeKind.Local).AddTicks(8186), new DateTime(2025, 1, 24, 7, 22, 44, 506, DateTimeKind.Utc).AddTicks(8188) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 421, DateTimeKind.Utc).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 421, DateTimeKind.Utc).AddTicks(306));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 421, DateTimeKind.Utc).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 413, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 413, DateTimeKind.Utc).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                columns: new[] { "cont_group_id", "rec_created_date" },
                values: new object[] { null, new DateTime(2025, 1, 24, 7, 22, 44, 482, DateTimeKind.Utc).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                columns: new[] { "cont_group_id", "rec_created_date" },
                values: new object[] { null, new DateTime(2025, 1, 24, 7, 22, 44, 482, DateTimeKind.Utc).AddTicks(4941) });

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 477, DateTimeKind.Utc).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9264));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9281));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 427, DateTimeKind.Utc).AddTicks(9379));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 422, DateTimeKind.Utc).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 422, DateTimeKind.Utc).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 422, DateTimeKind.Utc).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 422, DateTimeKind.Utc).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3545));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3552));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3579));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3585));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3588));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3592));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3595));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3607));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3609));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3614));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3627));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3634));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 461, DateTimeKind.Utc).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 434, DateTimeKind.Utc).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 434, DateTimeKind.Utc).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 431, DateTimeKind.Utc).AddTicks(625));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 431, DateTimeKind.Utc).AddTicks(630));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 431, DateTimeKind.Utc).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 490, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 490, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 490, DateTimeKind.Utc).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 490, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 7, 22, 44, 490, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.CreateIndex(
                name: "IX_mast_contactm_cont_group_id",
                table: "mast_contactm",
                column: "cont_group_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mast_contactm_cont_group_id",
                table: "mast_contactm",
                column: "cont_group_id",
                principalTable: "mast_param",
                principalColumn: "param_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mast_contactm_cont_group_id",
                table: "mast_contactm");

            migrationBuilder.DropIndex(
                name: "IX_mast_contactm_cont_group_id",
                table: "mast_contactm");

            migrationBuilder.DropColumn(
                name: "cont_group_id",
                table: "mast_contactm");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 361, DateTimeKind.Utc).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 361, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 361, DateTimeKind.Utc).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 361, DateTimeKind.Utc).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 361, DateTimeKind.Utc).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 357, DateTimeKind.Utc).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 357, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 357, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 357, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 413, DateTimeKind.Utc).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 405, DateTimeKind.Utc).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 386, DateTimeKind.Utc).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 24, 12, 25, 5, 381, DateTimeKind.Local).AddTicks(8376), new DateTime(2025, 1, 24, 6, 55, 5, 381, DateTimeKind.Utc).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 24, 12, 25, 5, 381, DateTimeKind.Local).AddTicks(8419), new DateTime(2025, 1, 24, 6, 55, 5, 381, DateTimeKind.Utc).AddTicks(8421) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 24, 12, 25, 5, 381, DateTimeKind.Local).AddTicks(8414), new DateTime(2025, 1, 24, 6, 55, 5, 381, DateTimeKind.Utc).AddTicks(8417) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 294, DateTimeKind.Utc).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 294, DateTimeKind.Utc).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 294, DateTimeKind.Utc).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 286, DateTimeKind.Utc).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 286, DateTimeKind.Utc).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 356, DateTimeKind.Utc).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 356, DateTimeKind.Utc).AddTicks(1433));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 352, DateTimeKind.Utc).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8439));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8445));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8454));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 296, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 296, DateTimeKind.Utc).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 296, DateTimeKind.Utc).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 296, DateTimeKind.Utc).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5801));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5851));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5859));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5861));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5873));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 335, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 307, DateTimeKind.Utc).AddTicks(9704));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 307, DateTimeKind.Utc).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 304, DateTimeKind.Utc).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 304, DateTimeKind.Utc).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 304, DateTimeKind.Utc).AddTicks(7911));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 364, DateTimeKind.Utc).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 364, DateTimeKind.Utc).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 364, DateTimeKind.Utc).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 364, DateTimeKind.Utc).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 6, 55, 5, 364, DateTimeKind.Utc).AddTicks(2668));
        }
    }
}
