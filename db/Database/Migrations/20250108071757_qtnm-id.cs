using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class qtnmid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mark_qtnd_lcl_mark_qtnm_mark_qtnmqtnm_pkid",
                table: "mark_qtnd_lcl");

            migrationBuilder.RenameColumn(
                name: "qtnm_pkid",
                table: "mark_qtnm",
                newName: "qtnm_id");

            migrationBuilder.RenameColumn(
                name: "qtnd_qtnm_pkid",
                table: "mark_qtnd_lcl",
                newName: "qtnd_qtnm_id");

            migrationBuilder.RenameColumn(
                name: "mark_qtnmqtnm_pkid",
                table: "mark_qtnd_lcl",
                newName: "mark_qtnmqtnm_id");

            migrationBuilder.RenameColumn(
                name: "qtnd_pkid",
                table: "mark_qtnd_lcl",
                newName: "qtnd_id");

            migrationBuilder.RenameIndex(
                name: "IX_mark_qtnd_lcl_qtnd_qtnm_pkid",
                table: "mark_qtnd_lcl",
                newName: "IX_mark_qtnd_lcl_qtnd_qtnm_id");

            migrationBuilder.RenameIndex(
                name: "IX_mark_qtnd_lcl_mark_qtnmqtnm_pkid",
                table: "mark_qtnd_lcl",
                newName: "IX_mark_qtnd_lcl_mark_qtnmqtnm_id");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 128, DateTimeKind.Utc).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 128, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 129, DateTimeKind.Utc).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 129, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 129, DateTimeKind.Utc).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 125, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 125, DateTimeKind.Utc).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 125, DateTimeKind.Utc).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 125, DateTimeKind.Utc).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 151, DateTimeKind.Utc).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "qtnm_no", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 8, 12, 47, 56, 147, DateTimeKind.Local).AddTicks(1460), "QL-1", new DateTime(2025, 1, 8, 7, 17, 56, 147, DateTimeKind.Utc).AddTicks(1510) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 80, DateTimeKind.Utc).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 80, DateTimeKind.Utc).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 80, DateTimeKind.Utc).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 53, DateTimeKind.Utc).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 53, DateTimeKind.Utc).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 123, DateTimeKind.Utc).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 123, DateTimeKind.Utc).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 120, DateTimeKind.Utc).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(166));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(174));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(183));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(185));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(187));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 84, DateTimeKind.Utc).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 84, DateTimeKind.Utc).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 84, DateTimeKind.Utc).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7318));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7359));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7446));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 100, DateTimeKind.Utc).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 100, DateTimeKind.Utc).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 97, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 97, DateTimeKind.Utc).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 97, DateTimeKind.Utc).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 132, DateTimeKind.Utc).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 132, DateTimeKind.Utc).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 132, DateTimeKind.Utc).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 132, DateTimeKind.Utc).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 132, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.AddForeignKey(
                name: "FK_mark_qtnd_lcl_mark_qtnm_mark_qtnmqtnm_id",
                table: "mark_qtnd_lcl",
                column: "mark_qtnmqtnm_id",
                principalTable: "mark_qtnm",
                principalColumn: "qtnm_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mark_qtnd_lcl_mark_qtnm_mark_qtnmqtnm_id",
                table: "mark_qtnd_lcl");

            migrationBuilder.RenameColumn(
                name: "qtnm_id",
                table: "mark_qtnm",
                newName: "qtnm_pkid");

            migrationBuilder.RenameColumn(
                name: "qtnd_qtnm_id",
                table: "mark_qtnd_lcl",
                newName: "qtnd_qtnm_pkid");

            migrationBuilder.RenameColumn(
                name: "mark_qtnmqtnm_id",
                table: "mark_qtnd_lcl",
                newName: "mark_qtnmqtnm_pkid");

            migrationBuilder.RenameColumn(
                name: "qtnd_id",
                table: "mark_qtnd_lcl",
                newName: "qtnd_pkid");

            migrationBuilder.RenameIndex(
                name: "IX_mark_qtnd_lcl_qtnd_qtnm_id",
                table: "mark_qtnd_lcl",
                newName: "IX_mark_qtnd_lcl_qtnd_qtnm_pkid");

            migrationBuilder.RenameIndex(
                name: "IX_mark_qtnd_lcl_mark_qtnmqtnm_id",
                table: "mark_qtnd_lcl",
                newName: "IX_mark_qtnd_lcl_mark_qtnmqtnm_pkid");

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
                columns: new[] { "qtnm_date", "qtnm_no", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 3, 17, 5, 48, 735, DateTimeKind.Local).AddTicks(4010), "QL1", new DateTime(2025, 1, 3, 11, 35, 48, 735, DateTimeKind.Utc).AddTicks(4076) });

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
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 3, 11, 35, 48, 669, DateTimeKind.Utc).AddTicks(7664));

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

            migrationBuilder.AddForeignKey(
                name: "FK_mark_qtnd_lcl_mark_qtnm_mark_qtnmqtnm_pkid",
                table: "mark_qtnd_lcl",
                column: "mark_qtnmqtnm_pkid",
                principalTable: "mark_qtnm",
                principalColumn: "qtnm_pkid");
        }
    }
}
