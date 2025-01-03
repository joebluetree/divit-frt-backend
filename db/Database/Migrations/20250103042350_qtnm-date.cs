using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class qtnmdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 583, DateTimeKind.Utc).AddTicks(1001));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 583, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 583, DateTimeKind.Utc).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 583, DateTimeKind.Utc).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 583, DateTimeKind.Utc).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 579, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 579, DateTimeKind.Utc).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 579, DateTimeKind.Utc).AddTicks(4283));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 579, DateTimeKind.Utc).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_pkid",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 605, DateTimeKind.Utc).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_pkid",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 2, 12, 45, 25, 600, DateTimeKind.Local).AddTicks(7087), new DateTime(2025, 1, 2, 7, 15, 25, 600, DateTimeKind.Utc).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 537, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 537, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 537, DateTimeKind.Utc).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 526, DateTimeKind.Utc).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 526, DateTimeKind.Utc).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 578, DateTimeKind.Utc).AddTicks(468));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 578, DateTimeKind.Utc).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 574, DateTimeKind.Utc).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6621));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6631));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 540, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 540, DateTimeKind.Utc).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 540, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5713));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5745));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5768));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5795));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 556, DateTimeKind.Utc).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 556, DateTimeKind.Utc).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 552, DateTimeKind.Utc).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 552, DateTimeKind.Utc).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 552, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 585, DateTimeKind.Utc).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 585, DateTimeKind.Utc).AddTicks(8961));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 585, DateTimeKind.Utc).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 585, DateTimeKind.Utc).AddTicks(8965));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 585, DateTimeKind.Utc).AddTicks(8967));
        }
    }
}
