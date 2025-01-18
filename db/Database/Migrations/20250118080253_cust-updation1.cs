using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class custupdation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cust_display_name",
                table: "mast_customerm");

            migrationBuilder.AlterColumn<string>(
                name: "cust_short_name",
                table: "mast_customerm",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "cust_name",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "cust_code",
                table: "mast_customerm",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "cust_address2",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "cust_city",
                table: "mast_customerm",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_contact",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cust_country_id",
                table: "mast_customerm",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_country_name",
                table: "mast_customerm",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_email",
                table: "mast_customerm",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_fax",
                table: "mast_customerm",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cust_handled_id",
                table: "mast_customerm",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_handled_name",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_location",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_mobile",
                table: "mast_customerm",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_official_name",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_refer_by",
                table: "mast_customerm",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cust_salesman_id",
                table: "mast_customerm",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_salesman_name",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cust_state_id",
                table: "mast_customerm",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_state_name",
                table: "mast_customerm",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_tel",
                table: "mast_customerm",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_title",
                table: "mast_customerm",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_web",
                table: "mast_customerm",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_zip_code",
                table: "mast_customerm",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 350, DateTimeKind.Utc).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 350, DateTimeKind.Utc).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 350, DateTimeKind.Utc).AddTicks(3439));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 350, DateTimeKind.Utc).AddTicks(3441));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 350, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 347, DateTimeKind.Utc).AddTicks(997));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 347, DateTimeKind.Utc).AddTicks(1000));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 347, DateTimeKind.Utc).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 347, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 387, DateTimeKind.Utc).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 379, DateTimeKind.Utc).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 371, DateTimeKind.Utc).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 13, 32, 52, 367, DateTimeKind.Local).AddTicks(5376), new DateTime(2025, 1, 18, 8, 2, 52, 367, DateTimeKind.Utc).AddTicks(5403) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 13, 32, 52, 367, DateTimeKind.Local).AddTicks(5411), new DateTime(2025, 1, 18, 8, 2, 52, 367, DateTimeKind.Utc).AddTicks(5413) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 18, 13, 32, 52, 367, DateTimeKind.Local).AddTicks(5407), new DateTime(2025, 1, 18, 8, 2, 52, 367, DateTimeKind.Utc).AddTicks(5409) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 289, DateTimeKind.Utc).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 289, DateTimeKind.Utc).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 289, DateTimeKind.Utc).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 282, DateTimeKind.Utc).AddTicks(1298));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 282, DateTimeKind.Utc).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 345, DateTimeKind.Utc).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 345, DateTimeKind.Utc).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                columns: new[] { "cust_city", "cust_contact", "cust_country_id", "cust_country_name", "cust_email", "cust_fax", "cust_handled_id", "cust_handled_name", "cust_location", "cust_mobile", "cust_official_name", "cust_refer_by", "cust_salesman_id", "cust_salesman_name", "cust_state_id", "cust_state_name", "cust_tel", "cust_title", "cust_web", "cust_zip_code", "rec_created_date" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, "ABC LTD KOCHI", null, null, null, null, null, null, null, null, null, new DateTime(2025, 1, 18, 8, 2, 52, 342, DateTimeKind.Utc).AddTicks(4035) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(355));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(384));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(393));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(394));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(396));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(398));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(402));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(404));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(416));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 297, DateTimeKind.Utc).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 291, DateTimeKind.Utc).AddTicks(7191));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 291, DateTimeKind.Utc).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 291, DateTimeKind.Utc).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 291, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7318));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7393));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7397));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 330, DateTimeKind.Utc).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 303, DateTimeKind.Utc).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 303, DateTimeKind.Utc).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 299, DateTimeKind.Utc).AddTicks(9904));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 299, DateTimeKind.Utc).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 299, DateTimeKind.Utc).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 352, DateTimeKind.Utc).AddTicks(9153));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 352, DateTimeKind.Utc).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 352, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 352, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 18, 8, 2, 52, 352, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.CreateIndex(
                name: "IX_mast_customerm_cust_country_id",
                table: "mast_customerm",
                column: "cust_country_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_customerm_cust_handled_id",
                table: "mast_customerm",
                column: "cust_handled_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_customerm_cust_salesman_id",
                table: "mast_customerm",
                column: "cust_salesman_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_customerm_cust_state_id",
                table: "mast_customerm",
                column: "cust_state_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cust_customerm_cust_country_id",
                table: "mast_customerm",
                column: "cust_country_id",
                principalTable: "mast_param",
                principalColumn: "param_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cust_customerm_cust_handled_id",
                table: "mast_customerm",
                column: "cust_handled_id",
                principalTable: "mast_param",
                principalColumn: "param_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cust_customerm_cust_salesman_id",
                table: "mast_customerm",
                column: "cust_salesman_id",
                principalTable: "mast_param",
                principalColumn: "param_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cust_customerm_cust_state_id",
                table: "mast_customerm",
                column: "cust_state_id",
                principalTable: "mast_param",
                principalColumn: "param_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cust_customerm_cust_country_id",
                table: "mast_customerm");

            migrationBuilder.DropForeignKey(
                name: "fk_cust_customerm_cust_handled_id",
                table: "mast_customerm");

            migrationBuilder.DropForeignKey(
                name: "fk_cust_customerm_cust_salesman_id",
                table: "mast_customerm");

            migrationBuilder.DropForeignKey(
                name: "fk_cust_customerm_cust_state_id",
                table: "mast_customerm");

            migrationBuilder.DropIndex(
                name: "IX_mast_customerm_cust_country_id",
                table: "mast_customerm");

            migrationBuilder.DropIndex(
                name: "IX_mast_customerm_cust_handled_id",
                table: "mast_customerm");

            migrationBuilder.DropIndex(
                name: "IX_mast_customerm_cust_salesman_id",
                table: "mast_customerm");

            migrationBuilder.DropIndex(
                name: "IX_mast_customerm_cust_state_id",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_city",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_contact",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_country_id",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_country_name",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_email",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_fax",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_handled_id",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_handled_name",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_location",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_mobile",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_official_name",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_refer_by",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_salesman_id",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_salesman_name",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_state_id",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_state_name",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_tel",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_title",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_web",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_zip_code",
                table: "mast_customerm");

            migrationBuilder.AlterColumn<string>(
                name: "cust_short_name",
                table: "mast_customerm",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_name",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_code",
                table: "mast_customerm",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cust_address2",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_display_name",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 641, DateTimeKind.Utc).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 641, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 641, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 641, DateTimeKind.Utc).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 641, DateTimeKind.Utc).AddTicks(1635));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 636, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 636, DateTimeKind.Utc).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 636, DateTimeKind.Utc).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 636, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 685, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 676, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 667, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 17, 14, 24, 6, 661, DateTimeKind.Local).AddTicks(9049), new DateTime(2025, 1, 17, 8, 54, 6, 661, DateTimeKind.Utc).AddTicks(9081) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 17, 14, 24, 6, 661, DateTimeKind.Local).AddTicks(9141), new DateTime(2025, 1, 17, 8, 54, 6, 661, DateTimeKind.Utc).AddTicks(9143) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 17, 14, 24, 6, 661, DateTimeKind.Local).AddTicks(9134), new DateTime(2025, 1, 17, 8, 54, 6, 661, DateTimeKind.Utc).AddTicks(9139) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 590, DateTimeKind.Utc).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 590, DateTimeKind.Utc).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 590, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 581, DateTimeKind.Utc).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 581, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 634, DateTimeKind.Utc).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 634, DateTimeKind.Utc).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                columns: new[] { "cust_display_name", "rec_created_date" },
                values: new object[] { "ABC LTD", new DateTime(2025, 1, 17, 8, 54, 6, 631, DateTimeKind.Utc).AddTicks(23) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 597, DateTimeKind.Utc).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 592, DateTimeKind.Utc).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 592, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 592, DateTimeKind.Utc).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 592, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4062));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4067));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4069));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4078));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 626, DateTimeKind.Utc).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 604, DateTimeKind.Utc).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 604, DateTimeKind.Utc).AddTicks(9212));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 601, DateTimeKind.Utc).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 601, DateTimeKind.Utc).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 601, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 644, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 644, DateTimeKind.Utc).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 644, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 644, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 17, 8, 54, 6, 644, DateTimeKind.Utc).AddTicks(4487));
        }
    }
}
