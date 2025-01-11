using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class newdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mark_qtnd_fcl",
                columns: table => new
                {
                    qtnd_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    qtnd_qtnm_id = table.Column<int>(type: "integer", nullable: false),
                    qtnd_pol_id = table.Column<int>(type: "integer", nullable: true),
                    qtnd_pol_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnd_pod_id = table.Column<int>(type: "integer", nullable: true),
                    qtnd_pod_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnd_carrier_id = table.Column<int>(type: "integer", nullable: true),
                    qtnd_carrier_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnd_trans_time = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnd_routing = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    qtnd_cntr_type = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    qtnd_etd = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    qtnd_cutoff = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    qtnd_of = table.Column<decimal>(type: "numeric(15,3)", nullable: true),
                    qtnd_pss = table.Column<decimal>(type: "numeric(15,3)", nullable: true),
                    qtnd_baf = table.Column<decimal>(type: "numeric(15,3)", nullable: true),
                    qtnd_isps = table.Column<decimal>(type: "numeric(15,3)", nullable: true),
                    qtnd_haulage = table.Column<decimal>(type: "numeric(15,3)", nullable: true),
                    qtnd_ifs = table.Column<decimal>(type: "numeric(15,3)", nullable: true),
                    qtnd_tot_amt = table.Column<decimal>(type: "numeric(15,3)", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: true),
                    mark_qtnmqtnm_id = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("pk_mark_qtnd_fcl_qtnd_id", x => x.qtnd_id);
                    table.ForeignKey(
                        name: "FK_mark_qtnd_fcl_mark_qtnm_mark_qtnmqtnm_id",
                        column: x => x.mark_qtnmqtnm_id,
                        principalTable: "mark_qtnm",
                        principalColumn: "qtnm_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_fcl_qtnd_carrier_id",
                        column: x => x.qtnd_carrier_id,
                        principalTable: "mast_param",
                        principalColumn: "param_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_fcl_qtnd_pod_id",
                        column: x => x.qtnd_pod_id,
                        principalTable: "mast_param",
                        principalColumn: "param_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_fcl_qtnd_pol_id",
                        column: x => x.qtnd_pol_id,
                        principalTable: "mast_param",
                        principalColumn: "param_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_fcl_qtnd_qtnm_id",
                        column: x => x.qtnd_qtnm_id,
                        principalTable: "mark_qtnm",
                        principalColumn: "qtnm_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_fcl_rec_branch_id",
                        column: x => x.rec_branch_id,
                        principalTable: "mast_branchm",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_fcl_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 908, DateTimeKind.Utc).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 908, DateTimeKind.Utc).AddTicks(8225));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 908, DateTimeKind.Utc).AddTicks(8227));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 908, DateTimeKind.Utc).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 908, DateTimeKind.Utc).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 906, DateTimeKind.Utc).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 906, DateTimeKind.Utc).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 906, DateTimeKind.Utc).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 906, DateTimeKind.Utc).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 922, DateTimeKind.Utc).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 11, 9, 18, 39, 919, DateTimeKind.Local).AddTicks(3380), new DateTime(2025, 1, 11, 3, 48, 39, 919, DateTimeKind.Utc).AddTicks(3404) });

            migrationBuilder.InsertData(
                table: "mark_qtnm",
                columns: new[] { "qtnm_id", "qtnm_amt", "qtnm_cbm", "qtnm_cfno", "qtnm_cft", "qtnm_commodity", "qtnm_date", "qtnm_kgs", "qtnm_lbs", "qtnm_move_type", "qtnm_no", "qtnm_package", "qtnm_pld_name", "qtnm_plfd_name", "qtnm_pod_id", "qtnm_pod_name", "qtnm_pol_id", "qtnm_pol_name", "qtnm_por_id", "qtnm_por_name", "qtnm_quot_by", "qtnm_routing", "qtnm_salesman_id", "qtnm_to_addr1", "qtnm_to_addr2", "qtnm_to_addr3", "qtnm_to_addr4", "qtnm_to_id", "qtnm_to_name", "qtnm_trans_time", "qtnm_type", "qtnm_valid_date", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[] { 10, 5000m, null, 10, null, null, new DateTime(2025, 1, 11, 9, 18, 39, 919, DateTimeKind.Local).AddTicks(3408), null, null, "TRUCKING", "QF-10", null, null, null, null, null, null, null, null, null, "ADMIN", null, 1, "KOCHI", null, null, null, 100, "ABC LTD KOCHI", null, "FCL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2008), 1, 1, "ADMIN", new DateTime(2025, 1, 11, 3, 48, 39, 919, DateTimeKind.Utc).AddTicks(3411), null, null, null });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 869, DateTimeKind.Utc).AddTicks(5574));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 869, DateTimeKind.Utc).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 869, DateTimeKind.Utc).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 866, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 866, DateTimeKind.Utc).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 906, DateTimeKind.Utc).AddTicks(478));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 906, DateTimeKind.Utc).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 903, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2094));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 873, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 870, DateTimeKind.Utc).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 870, DateTimeKind.Utc).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 870, DateTimeKind.Utc).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(460));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(464));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(467));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(477));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 901, DateTimeKind.Utc).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 877, DateTimeKind.Utc).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 877, DateTimeKind.Utc).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 875, DateTimeKind.Utc).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 875, DateTimeKind.Utc).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 875, DateTimeKind.Utc).AddTicks(5538));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 910, DateTimeKind.Utc).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 910, DateTimeKind.Utc).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 910, DateTimeKind.Utc).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 910, DateTimeKind.Utc).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 11, 3, 48, 39, 910, DateTimeKind.Utc).AddTicks(3492));

            migrationBuilder.InsertData(
                table: "mark_qtnd_fcl",
                columns: new[] { "qtnd_id", "mark_qtnmqtnm_id", "order", "qtnd_baf", "qtnd_carrier_id", "qtnd_carrier_name", "qtnd_cntr_type", "qtnd_cutoff", "qtnd_etd", "qtnd_haulage", "qtnd_ifs", "qtnd_isps", "qtnd_of", "qtnd_pod_id", "qtnd_pod_name", "qtnd_pol_id", "qtnd_pol_name", "qtnd_pss", "qtnd_qtnm_id", "qtnd_routing", "qtnd_tot_amt", "qtnd_trans_time", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[] { 1, null, null, null, null, null, "40' ft", "ABC", "QF-10", null, null, null, null, null, null, null, null, null, 10, null, 5000m, null, 1, 1, "ADMIN", new DateTime(2025, 1, 11, 3, 48, 39, 927, DateTimeKind.Utc).AddTicks(1696), null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_fcl_mark_qtnmqtnm_id",
                table: "mark_qtnd_fcl",
                column: "mark_qtnmqtnm_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_fcl_qtnd_carrier_id",
                table: "mark_qtnd_fcl",
                column: "qtnd_carrier_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_fcl_qtnd_pod_id",
                table: "mark_qtnd_fcl",
                column: "qtnd_pod_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_fcl_qtnd_pol_id",
                table: "mark_qtnd_fcl",
                column: "qtnd_pol_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_fcl_qtnd_qtnm_id",
                table: "mark_qtnd_fcl",
                column: "qtnd_qtnm_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_fcl_rec_branch_id",
                table: "mark_qtnd_fcl",
                column: "rec_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_fcl_rec_company_id",
                table: "mark_qtnd_fcl",
                column: "rec_company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mark_qtnd_fcl");

            migrationBuilder.DeleteData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10);

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
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 8, 12, 47, 56, 147, DateTimeKind.Local).AddTicks(1460), new DateTime(2025, 1, 8, 7, 17, 56, 147, DateTimeKind.Utc).AddTicks(1510) });

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
        }
    }
}
