using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class menucontactgroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cust_title",
                table: "mast_customerm",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_designation",
                table: "mast_customerm",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);

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
                columns: new[] { "cust_designation", "rec_created_date" },
                values: new object[] { null, new DateTime(2025, 1, 24, 6, 55, 5, 352, DateTimeKind.Utc).AddTicks(1302) });

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

            migrationBuilder.InsertData(
                table: "mast_menum",
                columns: new[] { "menu_id", "menu_code", "menu_module_id", "menu_name", "menu_order", "menu_param", "menu_route", "menu_submenu_id", "menu_visible", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[] { 813, "CONTACT-GROUP", 21, "Contact Group", 14, "{'type':'CONTACT-GROUP'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 24, 6, 55, 5, 301, DateTimeKind.Utc).AddTicks(8461), null, null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813);

            migrationBuilder.DropColumn(
                name: "cust_designation",
                table: "mast_customerm");

            migrationBuilder.AlterColumn<string>(
                name: "cust_title",
                table: "mast_customerm",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

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
                column: "rec_created_date",
                value: new DateTime(2025, 1, 24, 4, 6, 36, 192, DateTimeKind.Utc).AddTicks(1439));

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
    }
}
