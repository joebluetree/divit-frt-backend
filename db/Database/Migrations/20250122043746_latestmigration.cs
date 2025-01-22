using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class latestmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mast_remarkm",
                columns: table => new
                {
                    rem_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    rem_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "text", nullable: true),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_remarkm_rem_id", x => x.rem_id);
                    table.ForeignKey(
                        name: "fk_mast_remarkm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_remarkd",
                columns: table => new
                {
                    remd_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    remd_remarkm_id = table.Column<int>(type: "integer", nullable: false),
                    remd_desc1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    remd_order = table.Column<int>(type: "integer", nullable: true),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "text", nullable: true),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_remarkd_remd_id", x => x.remd_id);
                    table.ForeignKey(
                        name: "fk_mast_remarkd_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                    table.ForeignKey(
                        name: "fk_mast_remarkd_remd_remarkm_id",
                        column: x => x.remd_remarkm_id,
                        principalTable: "mast_remarkm",
                        principalColumn: "rem_id");
                });

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 722, DateTimeKind.Utc).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 722, DateTimeKind.Utc).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 722, DateTimeKind.Utc).AddTicks(7369));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 722, DateTimeKind.Utc).AddTicks(7371));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 722, DateTimeKind.Utc).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 721, DateTimeKind.Utc).AddTicks(348));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 721, DateTimeKind.Utc).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 721, DateTimeKind.Utc).AddTicks(352));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 721, DateTimeKind.Utc).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 746, DateTimeKind.Utc).AddTicks(8328));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 740, DateTimeKind.Utc).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 734, DateTimeKind.Utc).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 22, 10, 7, 45, 732, DateTimeKind.Local).AddTicks(2550), new DateTime(2025, 1, 22, 4, 37, 45, 732, DateTimeKind.Utc).AddTicks(2573) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 22, 10, 7, 45, 732, DateTimeKind.Local).AddTicks(2581), new DateTime(2025, 1, 22, 4, 37, 45, 732, DateTimeKind.Utc).AddTicks(2583) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 22, 10, 7, 45, 732, DateTimeKind.Local).AddTicks(2577), new DateTime(2025, 1, 22, 4, 37, 45, 732, DateTimeKind.Utc).AddTicks(2579) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 693, DateTimeKind.Utc).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 693, DateTimeKind.Utc).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 693, DateTimeKind.Utc).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 689, DateTimeKind.Utc).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 689, DateTimeKind.Utc).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 719, DateTimeKind.Utc).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 719, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 717, DateTimeKind.Utc).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(735));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(739));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(744));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(748));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(753));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(798));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(801));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(805));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(812));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(814));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(842));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(846));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 697, DateTimeKind.Utc).AddTicks(852));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 694, DateTimeKind.Utc).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 694, DateTimeKind.Utc).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 694, DateTimeKind.Utc).AddTicks(6576));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 694, DateTimeKind.Utc).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 694, DateTimeKind.Utc).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(139));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(237));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(256));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(260));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(307));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(338));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(344));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(346));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(353));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(362));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(372));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(374));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(394));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(403));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(407));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 715, DateTimeKind.Utc).AddTicks(398));

            migrationBuilder.InsertData(
                table: "mast_remarkm",
                columns: new[] { "rem_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked", "rem_name" },
                values: new object[] { 1, 1, "ADMIN", new DateTime(2025, 1, 22, 4, 37, 45, 719, DateTimeKind.Utc).AddTicks(8529), null, null, null, "Quotation Fcl" });

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 699, DateTimeKind.Utc).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 699, DateTimeKind.Utc).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 698, DateTimeKind.Utc).AddTicks(3987));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 698, DateTimeKind.Utc).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 698, DateTimeKind.Utc).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 723, DateTimeKind.Utc).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 723, DateTimeKind.Utc).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 723, DateTimeKind.Utc).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 723, DateTimeKind.Utc).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 723, DateTimeKind.Utc).AddTicks(9992));

            migrationBuilder.InsertData(
                table: "mast_remarkd",
                columns: new[] { "remd_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked", "remd_desc1", "remd_order", "remd_remarkm_id" },
                values: new object[] { 1, 1, "ADMIN", new DateTime(2025, 1, 22, 4, 37, 45, 720, DateTimeKind.Utc).AddTicks(4232), null, null, null, "Quotation Fcl", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_mast_remarkd_rec_company_id",
                table: "mast_remarkd",
                column: "rec_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_remarkd_remd_remarkm_id",
                table: "mast_remarkd",
                column: "remd_remarkm_id");

            migrationBuilder.CreateIndex(
                name: "uq_mast_remarkm_rem_name",
                table: "mast_remarkm",
                columns: new[] { "rec_company_id", "rem_name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mast_remarkd");

            migrationBuilder.DropTable(
                name: "mast_remarkm");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 915, DateTimeKind.Utc).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 915, DateTimeKind.Utc).AddTicks(3280));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 915, DateTimeKind.Utc).AddTicks(3283));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 915, DateTimeKind.Utc).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 915, DateTimeKind.Utc).AddTicks(3288));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 912, DateTimeKind.Utc).AddTicks(8882));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 912, DateTimeKind.Utc).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 912, DateTimeKind.Utc).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 912, DateTimeKind.Utc).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 944, DateTimeKind.Utc).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 939, DateTimeKind.Utc).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 934, DateTimeKind.Utc).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 16, 33, 26, 931, DateTimeKind.Local).AddTicks(2469), new DateTime(2025, 1, 21, 11, 3, 26, 931, DateTimeKind.Utc).AddTicks(2496) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 16, 33, 26, 931, DateTimeKind.Local).AddTicks(2504), new DateTime(2025, 1, 21, 11, 3, 26, 931, DateTimeKind.Utc).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 16, 33, 26, 931, DateTimeKind.Local).AddTicks(2500), new DateTime(2025, 1, 21, 11, 3, 26, 931, DateTimeKind.Utc).AddTicks(2502) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 880, DateTimeKind.Utc).AddTicks(874));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 880, DateTimeKind.Utc).AddTicks(878));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 880, DateTimeKind.Utc).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 875, DateTimeKind.Utc).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 875, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 911, DateTimeKind.Utc).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 911, DateTimeKind.Utc).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 908, DateTimeKind.Utc).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 905, DateTimeKind.Utc).AddTicks(4325));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2266));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2339));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 883, DateTimeKind.Utc).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 880, DateTimeKind.Utc).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 880, DateTimeKind.Utc).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 880, DateTimeKind.Utc).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 880, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 880, DateTimeKind.Utc).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(5989));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(5992));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6063));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6108));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6157));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6171));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6210));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6213));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6221));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 904, DateTimeKind.Utc).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 885, DateTimeKind.Utc).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 885, DateTimeKind.Utc).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 884, DateTimeKind.Utc).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 884, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 884, DateTimeKind.Utc).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 917, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 917, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 918, DateTimeKind.Utc).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 918, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 11, 3, 26, 918, DateTimeKind.Utc).AddTicks(6));
        }
    }
}
