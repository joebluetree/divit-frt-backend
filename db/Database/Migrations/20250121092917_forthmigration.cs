using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class forthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "mail_is_spa",
                table: "mast_mail_serverm",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 251, DateTimeKind.Utc).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 251, DateTimeKind.Utc).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 251, DateTimeKind.Utc).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 251, DateTimeKind.Utc).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 251, DateTimeKind.Utc).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 249, DateTimeKind.Utc).AddTicks(3117));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 249, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 249, DateTimeKind.Utc).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 249, DateTimeKind.Utc).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 277, DateTimeKind.Utc).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 272, DateTimeKind.Utc).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 262, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 14, 59, 17, 260, DateTimeKind.Local).AddTicks(5289), new DateTime(2025, 1, 21, 9, 29, 17, 260, DateTimeKind.Utc).AddTicks(5310) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 14, 59, 17, 260, DateTimeKind.Local).AddTicks(5318), new DateTime(2025, 1, 21, 9, 29, 17, 260, DateTimeKind.Utc).AddTicks(5319) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 14, 59, 17, 260, DateTimeKind.Local).AddTicks(5313), new DateTime(2025, 1, 21, 9, 29, 17, 260, DateTimeKind.Utc).AddTicks(5316) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 228, DateTimeKind.Utc).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 228, DateTimeKind.Utc).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 228, DateTimeKind.Utc).AddTicks(7977));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 225, DateTimeKind.Utc).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 225, DateTimeKind.Utc).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 248, DateTimeKind.Utc).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 248, DateTimeKind.Utc).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 247, DateTimeKind.Utc).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 245, DateTimeKind.Utc).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9685));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9704));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9773));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9783));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9812));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                columns: new[] { "menu_route", "rec_created_date" },
                values: new object[] { "admin/mailservermList", new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9856) });

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 229, DateTimeKind.Utc).AddTicks(6737));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 229, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 229, DateTimeKind.Utc).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 229, DateTimeKind.Utc).AddTicks(6742));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 229, DateTimeKind.Utc).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7951));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7977));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8008));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8068));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8112));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 234, DateTimeKind.Utc).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 234, DateTimeKind.Utc).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 233, DateTimeKind.Utc).AddTicks(3109));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 233, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 233, DateTimeKind.Utc).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 252, DateTimeKind.Utc).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 252, DateTimeKind.Utc).AddTicks(4324));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 252, DateTimeKind.Utc).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 252, DateTimeKind.Utc).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 252, DateTimeKind.Utc).AddTicks(4330));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "mail_is_spa",
                table: "mast_mail_serverm",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 682, DateTimeKind.Utc).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 682, DateTimeKind.Utc).AddTicks(7179));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 682, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 682, DateTimeKind.Utc).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 682, DateTimeKind.Utc).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 681, DateTimeKind.Utc).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 681, DateTimeKind.Utc).AddTicks(2466));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 681, DateTimeKind.Utc).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 681, DateTimeKind.Utc).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 706, DateTimeKind.Utc).AddTicks(6908));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 697, DateTimeKind.Utc).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 693, DateTimeKind.Utc).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 10, 17, 14, 691, DateTimeKind.Local).AddTicks(4624), new DateTime(2025, 1, 21, 4, 47, 14, 691, DateTimeKind.Utc).AddTicks(4645) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 10, 17, 14, 691, DateTimeKind.Local).AddTicks(4652), new DateTime(2025, 1, 21, 4, 47, 14, 691, DateTimeKind.Utc).AddTicks(4654) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 10, 17, 14, 691, DateTimeKind.Local).AddTicks(4648), new DateTime(2025, 1, 21, 4, 47, 14, 691, DateTimeKind.Utc).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 661, DateTimeKind.Utc).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 661, DateTimeKind.Utc).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 661, DateTimeKind.Utc).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 658, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 658, DateTimeKind.Utc).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 680, DateTimeKind.Utc).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 680, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 678, DateTimeKind.Utc).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 680, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7596));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7612));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7615));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7622));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7625));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7632));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7635));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7637));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                columns: new[] { "menu_route", "rec_created_date" },
                values: new object[] { "masters/mailservermList", new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7670) });

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 662, DateTimeKind.Utc).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 662, DateTimeKind.Utc).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 662, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 662, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 662, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8827));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8835));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8837));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8839));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8843));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8852));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8959));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8967));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8974));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8993));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 667, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 667, DateTimeKind.Utc).AddTicks(2983));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 666, DateTimeKind.Utc).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 666, DateTimeKind.Utc).AddTicks(60));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 666, DateTimeKind.Utc).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 683, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 683, DateTimeKind.Utc).AddTicks(8488));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 683, DateTimeKind.Utc).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 683, DateTimeKind.Utc).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 683, DateTimeKind.Utc).AddTicks(8493));
        }
    }
}
