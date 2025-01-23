using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class custupdation3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "cust_bond_expdt",
                table: "mast_customerm",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_bond_no",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_bond_yn",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_branch",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_brokers",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_chb_address1",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_chb_address2",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_chb_address3",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_chb_contact",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_chb_email",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_chb_fax",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_chb_group",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cust_chb_id",
                table: "mast_customerm",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_chb_name",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_chb_tel",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_criteria",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_ctpat_no",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_cur_code",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cust_days",
                table: "mast_customerm",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_einirsno",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_firm_code",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_actual_vendor",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_blackacc",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_ctpat",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_is_splacc",
                table: "mast_customerm",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_marketing_mail",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "cust_min_profit",
                table: "mast_customerm",
                type: "numeric(15,3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_nomination",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_poa_customs_yn",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_poa_isf_yn",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_priority",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_protected",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_punch_from",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cust_splacc_memo",
                table: "mast_customerm",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 915, DateTimeKind.Utc).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 915, DateTimeKind.Utc).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 915, DateTimeKind.Utc).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 915, DateTimeKind.Utc).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 915, DateTimeKind.Utc).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 912, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 912, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 912, DateTimeKind.Utc).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 912, DateTimeKind.Utc).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 956, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 948, DateTimeKind.Utc).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 940, DateTimeKind.Utc).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 13, 57, 20, 935, DateTimeKind.Local).AddTicks(6530), new DateTime(2025, 1, 23, 8, 27, 20, 935, DateTimeKind.Utc).AddTicks(6612) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 13, 57, 20, 935, DateTimeKind.Local).AddTicks(6621), new DateTime(2025, 1, 23, 8, 27, 20, 935, DateTimeKind.Utc).AddTicks(6623) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 13, 57, 20, 935, DateTimeKind.Local).AddTicks(6616), new DateTime(2025, 1, 23, 8, 27, 20, 935, DateTimeKind.Utc).AddTicks(6619) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 846, DateTimeKind.Utc).AddTicks(2563));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 846, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 846, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 838, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 838, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 910, DateTimeKind.Utc).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 910, DateTimeKind.Utc).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                columns: new[] { "cust_bond_expdt", "cust_bond_no", "cust_bond_yn", "cust_branch", "cust_brokers", "cust_chb_address1", "cust_chb_address2", "cust_chb_address3", "cust_chb_contact", "cust_chb_email", "cust_chb_fax", "cust_chb_group", "cust_chb_id", "cust_chb_name", "cust_chb_tel", "cust_criteria", "cust_ctpat_no", "cust_cur_code", "cust_days", "cust_einirsno", "cust_firm_code", "cust_is_actual_vendor", "cust_is_blackacc", "cust_is_ctpat", "cust_is_splacc", "cust_marketing_mail", "cust_min_profit", "cust_nomination", "cust_poa_customs_yn", "cust_poa_isf_yn", "cust_priority", "cust_protected", "cust_punch_from", "cust_splacc_memo", "rec_created_date" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, new DateTime(2025, 1, 23, 8, 27, 20, 904, DateTimeKind.Utc).AddTicks(6738) });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4234));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4239));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4269));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4271));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4286));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4333));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4336));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 853, DateTimeKind.Utc).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 848, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 848, DateTimeKind.Utc).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 848, DateTimeKind.Utc).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 848, DateTimeKind.Utc).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6168));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6225));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6228));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6262));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 887, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 860, DateTimeKind.Utc).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 860, DateTimeKind.Utc).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 857, DateTimeKind.Utc).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 857, DateTimeKind.Utc).AddTicks(322));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 857, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 918, DateTimeKind.Utc).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 918, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 918, DateTimeKind.Utc).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 918, DateTimeKind.Utc).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 8, 27, 20, 918, DateTimeKind.Utc).AddTicks(8766));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cust_bond_expdt",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_bond_no",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_bond_yn",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_branch",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_brokers",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_chb_address1",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_chb_address2",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_chb_address3",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_chb_contact",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_chb_email",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_chb_fax",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_chb_group",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_chb_id",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_chb_name",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_chb_tel",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_criteria",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_ctpat_no",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_cur_code",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_days",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_einirsno",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_firm_code",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_actual_vendor",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_blackacc",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_ctpat",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_is_splacc",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_marketing_mail",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_min_profit",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_nomination",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_poa_customs_yn",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_poa_isf_yn",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_priority",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_protected",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_punch_from",
                table: "mast_customerm");

            migrationBuilder.DropColumn(
                name: "cust_splacc_memo",
                table: "mast_customerm");

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
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 9, 46, 13, 299, DateTimeKind.Utc).AddTicks(4800));

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
    }
}
