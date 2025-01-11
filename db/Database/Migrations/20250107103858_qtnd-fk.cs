using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class qtndfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mark_qtnd_lcl_qtnm_pkid",
                table: "mark_qtnd_lcl");

            migrationBuilder.AlterColumn<string>(
                name: "qtnd_acc_name",
                table: "mark_qtnd_lcl",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 474, DateTimeKind.Utc).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 474, DateTimeKind.Utc).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 474, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 474, DateTimeKind.Utc).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 474, DateTimeKind.Utc).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 446, DateTimeKind.Utc).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 446, DateTimeKind.Utc).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 446, DateTimeKind.Utc).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 446, DateTimeKind.Utc).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_pkid",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 500, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_pkid",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 7, 16, 8, 57, 494, DateTimeKind.Local).AddTicks(7838), new DateTime(2025, 1, 7, 10, 38, 57, 494, DateTimeKind.Utc).AddTicks(7909) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 188, DateTimeKind.Utc).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 188, DateTimeKind.Utc).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 188, DateTimeKind.Utc).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 178, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 178, DateTimeKind.Utc).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 444, DateTimeKind.Utc).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 444, DateTimeKind.Utc).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 439, DateTimeKind.Utc).AddTicks(8135));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2458));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 196, DateTimeKind.Utc).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 190, DateTimeKind.Utc).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 190, DateTimeKind.Utc).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 190, DateTimeKind.Utc).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6426));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6428));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6442));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6456));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 433, DateTimeKind.Utc).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 394, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 394, DateTimeKind.Utc).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 199, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 199, DateTimeKind.Utc).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 199, DateTimeKind.Utc).AddTicks(6176));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 478, DateTimeKind.Utc).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 478, DateTimeKind.Utc).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 478, DateTimeKind.Utc).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 478, DateTimeKind.Utc).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 7, 10, 38, 57, 478, DateTimeKind.Utc).AddTicks(3060));

            migrationBuilder.AddForeignKey(
                name: "fk_mark_qtnd_lcl_qtnd_qtnm_pkid",
                table: "mark_qtnd_lcl",
                column: "qtnd_qtnm_pkid",
                principalTable: "mark_qtnm",
                principalColumn: "qtnm_pkid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mark_qtnd_lcl_qtnd_qtnm_pkid",
                table: "mark_qtnd_lcl");

            migrationBuilder.AlterColumn<string>(
                name: "qtnd_acc_name",
                table: "mark_qtnd_lcl",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

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
                name: "fk_mark_qtnd_lcl_qtnm_pkid",
                table: "mark_qtnd_lcl",
                column: "qtnd_qtnm_pkid",
                principalTable: "mark_qtnm",
                principalColumn: "qtnm_pkid");
        }
    }
}
