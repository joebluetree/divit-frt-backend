using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class qtnnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "json",
                table: "mast_settings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "mark_qtnm",
                columns: table => new
                {
                    qtnm_pkid = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    qtnm_cfno = table.Column<int>(type: "integer", nullable: false),
                    qtnm_type = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    qtnm_no = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    qtnm_to_id = table.Column<int>(type: "integer", nullable: false),
                    qtnm_to_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    qtnm_to_addr1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    qtnm_to_addr2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnm_to_addr3 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnm_to_addr4 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnm_date = table.Column<DateTime>(type: "date", nullable: false),
                    qtnm_quot_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    qtnm_valid_date = table.Column<DateTime>(type: "date", nullable: true),
                    qtnm_salesman_id = table.Column<int>(type: "integer", nullable: false),
                    qtnm_move_type = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    qtnm_commodity = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    qtnm_package = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    qtnm_kgs = table.Column<decimal>(type: "numeric(15,3)", nullable: true),
                    qtnm_lbs = table.Column<decimal>(type: "numeric(15,3)", nullable: true),
                    qtnm_cbm = table.Column<decimal>(type: "numeric(15,3)", nullable: true),
                    qtnm_cft = table.Column<decimal>(type: "numeric(15,3)", nullable: true),
                    qtnm_por_id = table.Column<int>(type: "integer", nullable: true),
                    qtnm_por_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnm_pol_id = table.Column<int>(type: "integer", nullable: true),
                    qtnm_pol_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnm_pod_id = table.Column<int>(type: "integer", nullable: true),
                    qtnm_pod_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnm_pld_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnm_plfd_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnm_trans_time = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnm_routing = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnm_amt = table.Column<decimal>(type: "numeric(15,3)", nullable: false),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "text", nullable: true),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false),
                    rec_branch_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mark_qtnm_qtnm_pkid", x => x.qtnm_pkid);
                    table.ForeignKey(
                        name: "fk_mark_qtnm_qtnm_salesman_id",
                        column: x => x.qtnm_salesman_id,
                        principalTable: "mast_param",
                        principalColumn: "param_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnm_qtnm_to_id",
                        column: x => x.qtnm_to_id,
                        principalTable: "mast_customerm",
                        principalColumn: "cust_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnm_rec_branch_id",
                        column: x => x.rec_branch_id,
                        principalTable: "mast_branchm",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 883, DateTimeKind.Utc).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 883, DateTimeKind.Utc).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 883, DateTimeKind.Utc).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 883, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 883, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 880, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 880, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 880, DateTimeKind.Utc).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 880, DateTimeKind.Utc).AddTicks(1531));

            migrationBuilder.InsertData(
                table: "mark_qtnm",
                columns: new[] { "qtnm_pkid", "qtnm_amt", "qtnm_cbm", "qtnm_cfno", "qtnm_cft", "qtnm_commodity", "qtnm_date", "qtnm_kgs", "qtnm_lbs", "qtnm_move_type", "qtnm_no", "qtnm_package", "qtnm_pld_name", "qtnm_plfd_name", "qtnm_pod_id", "qtnm_pod_name", "qtnm_pol_id", "qtnm_pol_name", "qtnm_por_id", "qtnm_por_name", "qtnm_quot_by", "qtnm_routing", "qtnm_salesman_id", "qtnm_to_addr1", "qtnm_to_addr2", "qtnm_to_addr3", "qtnm_to_addr4", "qtnm_to_id", "qtnm_to_name", "qtnm_trans_time", "qtnm_type", "qtnm_valid_date", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[] { 1, 5000m, null, 1, null, null, new DateTime(2025, 1, 1, 14, 37, 28, 895, DateTimeKind.Local).AddTicks(7433), null, null, "TRUCKING", "QL1", null, null, null, null, null, null, null, null, null, "ADMIN", null, 1, "KOCHI", null, null, null, 100, "ABC LTD KOCHI", null, "LCL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2008), 1, 1, "ADMIN", new DateTime(2025, 1, 1, 9, 7, 28, 895, DateTimeKind.Utc).AddTicks(7487), null, null, null });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 830, DateTimeKind.Utc).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 830, DateTimeKind.Utc).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 830, DateTimeKind.Utc).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 826, DateTimeKind.Utc).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 826, DateTimeKind.Utc).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 878, DateTimeKind.Utc).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 878, DateTimeKind.Utc).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 870, DateTimeKind.Utc).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(824));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(856));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(869));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(874));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(878));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(884));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 832, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 832, DateTimeKind.Utc).AddTicks(6885));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 832, DateTimeKind.Utc).AddTicks(6887));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9013));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9023));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9041));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 844, DateTimeKind.Utc).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 844, DateTimeKind.Utc).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 841, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 841, DateTimeKind.Utc).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 841, DateTimeKind.Utc).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 886, DateTimeKind.Utc).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 886, DateTimeKind.Utc).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 886, DateTimeKind.Utc).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 886, DateTimeKind.Utc).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 886, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnm_qtnm_salesman_id",
                table: "mark_qtnm",
                column: "qtnm_salesman_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnm_qtnm_to_id",
                table: "mark_qtnm",
                column: "qtnm_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnm_rec_branch_id",
                table: "mark_qtnm",
                column: "rec_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnm_rec_company_id",
                table: "mark_qtnm",
                column: "rec_company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mark_qtnm");

            migrationBuilder.AlterColumn<string>(
                name: "json",
                table: "mast_settings",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 120, DateTimeKind.Utc).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 120, DateTimeKind.Utc).AddTicks(5434));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 120, DateTimeKind.Utc).AddTicks(5436));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 120, DateTimeKind.Utc).AddTicks(5438));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 120, DateTimeKind.Utc).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 102, DateTimeKind.Utc).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 102, DateTimeKind.Utc).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 102, DateTimeKind.Utc).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 100, DateTimeKind.Utc).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 100, DateTimeKind.Utc).AddTicks(5611));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 116, DateTimeKind.Utc).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1130));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1132));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1163));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 103, DateTimeKind.Utc).AddTicks(6805));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 103, DateTimeKind.Utc).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 103, DateTimeKind.Utc).AddTicks(6809));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7461));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7488));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 110, DateTimeKind.Utc).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 110, DateTimeKind.Utc).AddTicks(2834));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 108, DateTimeKind.Utc).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 108, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 108, DateTimeKind.Utc).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 122, DateTimeKind.Utc).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 122, DateTimeKind.Utc).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 122, DateTimeKind.Utc).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 122, DateTimeKind.Utc).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2024, 12, 3, 8, 49, 22, 122, DateTimeKind.Utc).AddTicks(2508));
        }
    }
}
