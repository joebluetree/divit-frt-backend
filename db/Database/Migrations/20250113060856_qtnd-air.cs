using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class qtndair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mark_qtnd_air",
                columns: table => new
                {
                    qtnd_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    qtnd_qtnm_id = table.Column<int>(type: "integer", nullable: false),
                    qtnd_pol_id = table.Column<int>(type: "integer", nullable: true),
                    qtnd_pol_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    qtnd_pod_id = table.Column<int>(type: "integer", nullable: true),
                    qtnd_pod_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    qtnd_carrier_id = table.Column<int>(type: "integer", nullable: true),
                    qtnd_carrier_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    qtnd_trans_time = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    qtnd_routing = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    qtnd_etd = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    qtnd_min = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    qtnd_45k = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    qtnd_100k = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    qtnd_300k = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    qtnd_500k = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    qtnd_1000k = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    qtnd_fsc = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    qtnd_war = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    qtnd_sfc = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    qtnd_hac = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    qtnd_order = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("pk_mark_qtnd_air_qtnd_id", x => x.qtnd_id);
                    table.ForeignKey(
                        name: "FK_mark_qtnd_air_mark_qtnm_mark_qtnmqtnm_id",
                        column: x => x.mark_qtnmqtnm_id,
                        principalTable: "mark_qtnm",
                        principalColumn: "qtnm_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_air_qtnd_carrier_id",
                        column: x => x.qtnd_carrier_id,
                        principalTable: "mast_param",
                        principalColumn: "param_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_air_qtnd_pod_id",
                        column: x => x.qtnd_pod_id,
                        principalTable: "mast_param",
                        principalColumn: "param_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_air_qtnd_pol_id",
                        column: x => x.qtnd_pol_id,
                        principalTable: "mast_param",
                        principalColumn: "param_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_air_qtnd_qtnm_id",
                        column: x => x.qtnd_qtnm_id,
                        principalTable: "mark_qtnm",
                        principalColumn: "qtnm_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_air_rec_branch_id",
                        column: x => x.rec_branch_id,
                        principalTable: "mast_branchm",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_air_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 683, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 683, DateTimeKind.Utc).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 683, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 683, DateTimeKind.Utc).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 683, DateTimeKind.Utc).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 678, DateTimeKind.Utc).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 678, DateTimeKind.Utc).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 678, DateTimeKind.Utc).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 678, DateTimeKind.Utc).AddTicks(8301));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 715, DateTimeKind.Utc).AddTicks(6582));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 13, 11, 38, 55, 711, DateTimeKind.Local).AddTicks(898), new DateTime(2025, 1, 13, 6, 8, 55, 711, DateTimeKind.Utc).AddTicks(924) });

            migrationBuilder.InsertData(
                table: "mark_qtnm",
                columns: new[] { "qtnm_id", "qtnm_amt", "qtnm_cbm", "qtnm_cfno", "qtnm_cft", "qtnm_commodity", "qtnm_date", "qtnm_kgs", "qtnm_lbs", "qtnm_move_type", "qtnm_no", "qtnm_package", "qtnm_pld_name", "qtnm_plfd_name", "qtnm_pod_id", "qtnm_pod_name", "qtnm_pol_id", "qtnm_pol_name", "qtnm_por_id", "qtnm_por_name", "qtnm_quot_by", "qtnm_routing", "qtnm_salesman_id", "qtnm_to_addr1", "qtnm_to_addr2", "qtnm_to_addr3", "qtnm_to_addr4", "qtnm_to_id", "qtnm_to_name", "qtnm_trans_time", "qtnm_type", "qtnm_valid_date", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[] { 20, 0m, null, 20, null, null, new DateTime(2025, 1, 13, 11, 38, 55, 711, DateTimeKind.Local).AddTicks(928), null, null, "DDU", "QA-20", null, null, null, null, null, null, null, null, null, "ADMIN", null, 1, "KOCHI", null, null, null, 100, "ABC LTD KOCHI", null, "AIR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2008), 1, 1, "ADMIN", new DateTime(2025, 1, 13, 6, 8, 55, 711, DateTimeKind.Utc).AddTicks(933), null, null, null });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 625, DateTimeKind.Utc).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 625, DateTimeKind.Utc).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 625, DateTimeKind.Utc).AddTicks(4308));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 617, DateTimeKind.Utc).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 617, DateTimeKind.Utc).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 677, DateTimeKind.Utc).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 677, DateTimeKind.Utc).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 672, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 633, DateTimeKind.Utc).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 627, DateTimeKind.Utc).AddTicks(8602));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 627, DateTimeKind.Utc).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 627, DateTimeKind.Utc).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 663, DateTimeKind.Utc).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 641, DateTimeKind.Utc).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 641, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 636, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 636, DateTimeKind.Utc).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 636, DateTimeKind.Utc).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 691, DateTimeKind.Utc).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 691, DateTimeKind.Utc).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 691, DateTimeKind.Utc).AddTicks(9669));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 691, DateTimeKind.Utc).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 13, 6, 8, 55, 691, DateTimeKind.Utc).AddTicks(9673));

            migrationBuilder.InsertData(
                table: "mark_qtnd_air",
                columns: new[] { "qtnd_id", "mark_qtnmqtnm_id", "qtnd_1000k", "qtnd_100k", "qtnd_300k", "qtnd_45k", "qtnd_500k", "qtnd_carrier_id", "qtnd_carrier_name", "qtnd_etd", "qtnd_fsc", "qtnd_hac", "qtnd_min", "qtnd_order", "qtnd_pod_id", "qtnd_pod_name", "qtnd_pol_id", "qtnd_pol_name", "qtnd_qtnm_id", "qtnd_routing", "qtnd_sfc", "qtnd_trans_time", "qtnd_war", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[] { 1, null, null, null, null, "1.5/kg", null, null, null, null, null, null, null, 1, 1005, "AABENRAA, DENMARK", null, null, 20, null, null, null, null, 1, 1, "ADMIN", new DateTime(2025, 1, 13, 6, 8, 55, 728, DateTimeKind.Utc).AddTicks(1881), null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_air_mark_qtnmqtnm_id",
                table: "mark_qtnd_air",
                column: "mark_qtnmqtnm_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_air_qtnd_carrier_id",
                table: "mark_qtnd_air",
                column: "qtnd_carrier_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_air_qtnd_pod_id",
                table: "mark_qtnd_air",
                column: "qtnd_pod_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_air_qtnd_pol_id",
                table: "mark_qtnd_air",
                column: "qtnd_pol_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_air_qtnd_qtnm_id",
                table: "mark_qtnd_air",
                column: "qtnd_qtnm_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_air_rec_branch_id",
                table: "mark_qtnd_air",
                column: "rec_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_air_rec_company_id",
                table: "mark_qtnd_air",
                column: "rec_company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mark_qtnd_air");

            migrationBuilder.DeleteData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 992, DateTimeKind.Utc).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 992, DateTimeKind.Utc).AddTicks(5432));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 992, DateTimeKind.Utc).AddTicks(5435));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 992, DateTimeKind.Utc).AddTicks(5437));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 992, DateTimeKind.Utc).AddTicks(5440));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 986, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 986, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 986, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 986, DateTimeKind.Utc).AddTicks(7441));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 6, 14, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 9, 12, 14, 6, 9, DateTimeKind.Local).AddTicks(3681), new DateTime(2025, 1, 9, 6, 44, 6, 9, DateTimeKind.Utc).AddTicks(4134) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 951, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 951, DateTimeKind.Utc).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 951, DateTimeKind.Utc).AddTicks(4399));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 945, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 945, DateTimeKind.Utc).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 985, DateTimeKind.Utc).AddTicks(3171));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 985, DateTimeKind.Utc).AddTicks(3176));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 981, DateTimeKind.Utc).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5101));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5112));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5115));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5119));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5126));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 958, DateTimeKind.Utc).AddTicks(5128));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 953, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 953, DateTimeKind.Utc).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 953, DateTimeKind.Utc).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9052));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9088));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 977, DateTimeKind.Utc).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 964, DateTimeKind.Utc).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 964, DateTimeKind.Utc).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 961, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 961, DateTimeKind.Utc).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 961, DateTimeKind.Utc).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 995, DateTimeKind.Utc).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 995, DateTimeKind.Utc).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 995, DateTimeKind.Utc).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 995, DateTimeKind.Utc).AddTicks(3419));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 9, 6, 44, 5, 995, DateTimeKind.Utc).AddTicks(3421));
        }
    }
}
