using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class qtndlcl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mark_qtnd_lcl",
                columns: table => new
                {
                    qtnd_pkid = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    qtnd_qtnm_pkid = table.Column<int>(type: "integer", nullable: false),
                    qtnd_acc_id = table.Column<int>(type: "integer", nullable: false),
                    qtnd_acc_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    qtnd_amt = table.Column<decimal>(type: "numeric(15,3)", nullable: false),
                    qtnd_per = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    mark_qtnmqtnm_pkid = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("pk_mark_qtnd_lcl_qtnd_pkid", x => x.qtnd_pkid);
                    table.ForeignKey(
                        name: "FK_mark_qtnd_lcl_mark_qtnm_mark_qtnmqtnm_pkid",
                        column: x => x.mark_qtnmqtnm_pkid,
                        principalTable: "mark_qtnm",
                        principalColumn: "qtnm_pkid");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_lcl_qtnd_acc_id",
                        column: x => x.qtnd_acc_id,
                        principalTable: "acc_acctm",
                        principalColumn: "acc_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_lcl_qtnm_pkid",
                        column: x => x.qtnd_qtnm_pkid,
                        principalTable: "mark_qtnm",
                        principalColumn: "qtnm_pkid");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_lcl_rec_branch_id",
                        column: x => x.rec_branch_id,
                        principalTable: "mast_branchm",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "fk_mark_qtnd_lcl_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 437, DateTimeKind.Utc).AddTicks(3701));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 437, DateTimeKind.Utc).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 437, DateTimeKind.Utc).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 437, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 437, DateTimeKind.Utc).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 433, DateTimeKind.Utc).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 433, DateTimeKind.Utc).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 433, DateTimeKind.Utc).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 433, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.InsertData(
                table: "mark_qtnd_lcl",
                columns: new[] { "qtnd_pkid", "mark_qtnmqtnm_pkid", "qtnd_acc_id", "qtnd_acc_name", "qtnd_amt", "qtnd_per", "qtnd_qtnm_pkid", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[] { 1, null, 1, "OCEAN IMPORT", 100m, "koc-mum", 1, 1, 1, "ADMIN", new DateTime(2025, 1, 2, 7, 8, 52, 459, DateTimeKind.Utc).AddTicks(8669), null, null, null });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_pkid",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 2, 12, 38, 52, 454, DateTimeKind.Local).AddTicks(7087), new DateTime(2025, 1, 2, 7, 8, 52, 454, DateTimeKind.Utc).AddTicks(7146) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 394, DateTimeKind.Utc).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 394, DateTimeKind.Utc).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 394, DateTimeKind.Utc).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 388, DateTimeKind.Utc).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 388, DateTimeKind.Utc).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 431, DateTimeKind.Utc).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 431, DateTimeKind.Utc).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 428, DateTimeKind.Utc).AddTicks(3865));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6908));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6959));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6965));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6976));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 402, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 397, DateTimeKind.Utc).AddTicks(444));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 397, DateTimeKind.Utc).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 397, DateTimeKind.Utc).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7911));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7928));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 423, DateTimeKind.Utc).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 409, DateTimeKind.Utc).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 409, DateTimeKind.Utc).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 405, DateTimeKind.Utc).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 405, DateTimeKind.Utc).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 405, DateTimeKind.Utc).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 440, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 440, DateTimeKind.Utc).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 440, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 440, DateTimeKind.Utc).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 440, DateTimeKind.Utc).AddTicks(5185));

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_lcl_mark_qtnmqtnm_pkid",
                table: "mark_qtnd_lcl",
                column: "mark_qtnmqtnm_pkid");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_lcl_qtnd_acc_id",
                table: "mark_qtnd_lcl",
                column: "qtnd_acc_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_lcl_qtnd_qtnm_pkid",
                table: "mark_qtnd_lcl",
                column: "qtnd_qtnm_pkid");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_lcl_rec_branch_id",
                table: "mark_qtnd_lcl",
                column: "rec_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnd_lcl_rec_company_id",
                table: "mark_qtnd_lcl",
                column: "rec_company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mark_qtnd_lcl");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 204, DateTimeKind.Utc).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 204, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 204, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 204, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 204, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 201, DateTimeKind.Utc).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 201, DateTimeKind.Utc).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 201, DateTimeKind.Utc).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 201, DateTimeKind.Utc).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_pkid",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 1, 14, 39, 13, 223, DateTimeKind.Local).AddTicks(1099), new DateTime(2025, 1, 1, 9, 9, 13, 223, DateTimeKind.Utc).AddTicks(1153) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 157, DateTimeKind.Utc).AddTicks(1921));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 157, DateTimeKind.Utc).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 157, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 150, DateTimeKind.Utc).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 150, DateTimeKind.Utc).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 199, DateTimeKind.Utc).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 199, DateTimeKind.Utc).AddTicks(3478));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 195, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7904));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7954));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 159, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 159, DateTimeKind.Utc).AddTicks(6666));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 159, DateTimeKind.Utc).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(419));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(424));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(426));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(430));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(432));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 173, DateTimeKind.Utc).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 173, DateTimeKind.Utc).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 169, DateTimeKind.Utc).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 169, DateTimeKind.Utc).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 169, DateTimeKind.Utc).AddTicks(6456));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 208, DateTimeKind.Utc).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 208, DateTimeKind.Utc).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 208, DateTimeKind.Utc).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 208, DateTimeKind.Utc).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 208, DateTimeKind.Utc).AddTicks(2360));
        }
    }
}
