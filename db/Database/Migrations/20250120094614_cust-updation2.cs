using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class custupdation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cust_is_acarrier",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_aterminal",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_bank",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_cha",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_consignee",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_contract",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_employee",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_exporter",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_forwarder",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_gvendor",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_importer",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_miscell",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_oagent",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_scarrier",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_shipper",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_shipvendor",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_sterminal",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_tbd",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_trucker",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_warehouse",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 308, DateTimeKind.Utc).AddTicks(9113));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 308, DateTimeKind.Utc).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 308, DateTimeKind.Utc).AddTicks(9121));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 308, DateTimeKind.Utc).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 308, DateTimeKind.Utc).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 305, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 305, DateTimeKind.Utc).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 305, DateTimeKind.Utc).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 305, DateTimeKind.Utc).AddTicks(3283));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 349, DateTimeKind.Utc).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 341, DateTimeKind.Utc).AddTicks(925));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 332, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 15, 16, 13, 328, DateTimeKind.Local).AddTicks(1492), new DateTime(2025, 1, 20, 9, 46, 13, 328, DateTimeKind.Utc).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 15, 16, 13, 328, DateTimeKind.Local).AddTicks(1529), new DateTime(2025, 1, 20, 9, 46, 13, 328, DateTimeKind.Utc).AddTicks(1534) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 15, 16, 13, 328, DateTimeKind.Local).AddTicks(1524), new DateTime(2025, 1, 20, 9, 46, 13, 328, DateTimeKind.Utc).AddTicks(1527) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 247, DateTimeKind.Utc).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 247, DateTimeKind.Utc).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 247, DateTimeKind.Utc).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 239, DateTimeKind.Utc).AddTicks(5245));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 239, DateTimeKind.Utc).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 303, DateTimeKind.Utc).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 303, DateTimeKind.Utc).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                columns: new[] { "cust_is_acarrier", "cust_is_aterminal", "cust_is_bank", "cust_is_cha", "cust_is_consignee", "cust_is_contract", "cust_is_employee", "cust_is_exporter", "cust_is_forwarder", "cust_is_gvendor", "cust_is_importer", "cust_is_miscell", "cust_is_oagent", "cust_is_scarrier", "cust_is_shipper", "cust_is_shipvendor", "cust_is_sterminal", "cust_is_tbd", "cust_is_trucker", "cust_is_warehouse", "rec_created_date" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, new DateTime(2025, 1, 20, 9, 46, 13, 299, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7673));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 254, DateTimeKind.Utc).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 249, DateTimeKind.Utc).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 249, DateTimeKind.Utc).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 249, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 249, DateTimeKind.Utc).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5131));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5134));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5144));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5153));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5233));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 286, DateTimeKind.Utc).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 261, DateTimeKind.Utc).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 261, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 258, DateTimeKind.Utc).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 258, DateTimeKind.Utc).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 258, DateTimeKind.Utc).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 311, DateTimeKind.Utc).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 311, DateTimeKind.Utc).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 311, DateTimeKind.Utc).AddTicks(6612));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 311, DateTimeKind.Utc).AddTicks(6614));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 311, DateTimeKind.Utc).AddTicks(6616));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cust_is_acarrier",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_aterminal",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_bank",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_cha",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_consignee",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_contract",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_employee",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_exporter",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_forwarder",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_gvendor",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_importer",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_miscell",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_oagent",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_scarrier",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_shipper",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_shipvendor",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_sterminal",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_tbd",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_trucker",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_warehouse",
                table: "mast_customerm");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 981, DateTimeKind.Utc).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 981, DateTimeKind.Utc).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 981, DateTimeKind.Utc).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 981, DateTimeKind.Utc).AddTicks(8141));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 981, DateTimeKind.Utc).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 978, DateTimeKind.Utc).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 978, DateTimeKind.Utc).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 978, DateTimeKind.Utc).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 978, DateTimeKind.Utc).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 36, 23, DateTimeKind.Utc).AddTicks(2859));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 36, 14, DateTimeKind.Utc).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 36, 6, DateTimeKind.Utc).AddTicks(6475));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 11, 30, 36, 2, DateTimeKind.Local).AddTicks(1347), new DateTime(2025, 1, 20, 6, 0, 36, 2, DateTimeKind.Utc).AddTicks(1377) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 11, 30, 36, 2, DateTimeKind.Local).AddTicks(1385), new DateTime(2025, 1, 20, 6, 0, 36, 2, DateTimeKind.Utc).AddTicks(1387) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 11, 30, 36, 2, DateTimeKind.Local).AddTicks(1381), new DateTime(2025, 1, 20, 6, 0, 36, 2, DateTimeKind.Utc).AddTicks(1383) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 923, DateTimeKind.Utc).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 923, DateTimeKind.Utc).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 923, DateTimeKind.Utc).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 914, DateTimeKind.Utc).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 914, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 976, DateTimeKind.Utc).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 976, DateTimeKind.Utc).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 973, DateTimeKind.Utc).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5171));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5232));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5238));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 930, DateTimeKind.Utc).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 925, DateTimeKind.Utc).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 925, DateTimeKind.Utc).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 925, DateTimeKind.Utc).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 925, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9518));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 961, DateTimeKind.Utc).AddTicks(9527));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 937, DateTimeKind.Utc).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 937, DateTimeKind.Utc).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 934, DateTimeKind.Utc).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 934, DateTimeKind.Utc).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 934, DateTimeKind.Utc).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 985, DateTimeKind.Utc).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 985, DateTimeKind.Utc).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 985, DateTimeKind.Utc).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 985, DateTimeKind.Utc).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 0, 35, 985, DateTimeKind.Utc).AddTicks(3826));
        }
    }
}
