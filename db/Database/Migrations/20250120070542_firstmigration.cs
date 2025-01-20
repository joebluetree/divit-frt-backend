using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mast_mail_serverm",
                columns: table => new
                {
                    mail_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    mail_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    mail_smtp_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    mail_smtp_port = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    mail_is_ssl = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    mail_is_auth = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    mail_is_spa = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    mail_bulk_tot = table.Column<int>(type: "integer", nullable: true),
                    mail_bulk_sub = table.Column<int>(type: "integer", nullable: true),
                    mail_smtp_username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    mail_smtp_pwd = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("pk_mast_mail_serverm_mail_id", x => x.mail_id);
                    table.ForeignKey(
                        name: "fk_mast_mail_serverm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 861, DateTimeKind.Utc).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 861, DateTimeKind.Utc).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 861, DateTimeKind.Utc).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 861, DateTimeKind.Utc).AddTicks(3621));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 861, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 859, DateTimeKind.Utc).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 859, DateTimeKind.Utc).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 859, DateTimeKind.Utc).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 859, DateTimeKind.Utc).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 881, DateTimeKind.Utc).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 876, DateTimeKind.Utc).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 872, DateTimeKind.Utc).AddTicks(9041));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 35, 41, 870, DateTimeKind.Local).AddTicks(7888), new DateTime(2025, 1, 20, 7, 5, 41, 870, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 35, 41, 870, DateTimeKind.Local).AddTicks(7917), new DateTime(2025, 1, 20, 7, 5, 41, 870, DateTimeKind.Utc).AddTicks(7919) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 35, 41, 870, DateTimeKind.Local).AddTicks(7913), new DateTime(2025, 1, 20, 7, 5, 41, 870, DateTimeKind.Utc).AddTicks(7915) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 839, DateTimeKind.Utc).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 839, DateTimeKind.Utc).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 839, DateTimeKind.Utc).AddTicks(5233));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 835, DateTimeKind.Utc).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 835, DateTimeKind.Utc).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 858, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 858, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 857, DateTimeKind.Utc).AddTicks(2093));

            migrationBuilder.InsertData(
                table: "mast_mail_serverm",
                columns: new[] { "mail_id", "mail_bulk_sub", "mail_bulk_tot", "mail_is_auth", "mail_is_spa", "mail_is_ssl", "mail_name", "mail_smtp_name", "mail_smtp_port", "mail_smtp_pwd", "mail_smtp_username", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[] { 1, 10, 500, "Y", "Y", "Y", "Oracle", "DB", "123", "123", "Oracle", 1, "ADMIN", new DateTime(2025, 1, 20, 7, 5, 41, 859, DateTimeKind.Utc).AddTicks(784), null, null, null });

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 842, DateTimeKind.Utc).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 840, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 840, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 840, DateTimeKind.Utc).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 840, DateTimeKind.Utc).AddTicks(3794));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 840, DateTimeKind.Utc).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2334));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2347));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2383));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2392));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 855, DateTimeKind.Utc).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 845, DateTimeKind.Utc).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 845, DateTimeKind.Utc).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 843, DateTimeKind.Utc).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 843, DateTimeKind.Utc).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 843, DateTimeKind.Utc).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 862, DateTimeKind.Utc).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 862, DateTimeKind.Utc).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 862, DateTimeKind.Utc).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 862, DateTimeKind.Utc).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 862, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.CreateIndex(
                name: "IX_mast_mail_serverm_rec_company_id",
                table: "mast_mail_serverm",
                column: "rec_company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mast_mail_serverm");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 533, DateTimeKind.Utc).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 533, DateTimeKind.Utc).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 533, DateTimeKind.Utc).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 533, DateTimeKind.Utc).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 533, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 531, DateTimeKind.Utc).AddTicks(474));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 531, DateTimeKind.Utc).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 531, DateTimeKind.Utc).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 531, DateTimeKind.Utc).AddTicks(483));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 565, DateTimeKind.Utc).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 560, DateTimeKind.Utc).AddTicks(9744));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 556, DateTimeKind.Utc).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 9, 3, 553, DateTimeKind.Local).AddTicks(9711), new DateTime(2025, 1, 20, 6, 39, 3, 553, DateTimeKind.Utc).AddTicks(9732) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 9, 3, 553, DateTimeKind.Local).AddTicks(9740), new DateTime(2025, 1, 20, 6, 39, 3, 553, DateTimeKind.Utc).AddTicks(9742) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 12, 9, 3, 553, DateTimeKind.Local).AddTicks(9736), new DateTime(2025, 1, 20, 6, 39, 3, 553, DateTimeKind.Utc).AddTicks(9738) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 503, DateTimeKind.Utc).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 503, DateTimeKind.Utc).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 503, DateTimeKind.Utc).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 497, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 497, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 530, DateTimeKind.Utc).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 530, DateTimeKind.Utc).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 528, DateTimeKind.Utc).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5254));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5285));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5297));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5301));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5305));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5311));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5313));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5320));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5323));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5325));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5327));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5329));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5333));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5335));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5337));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5341));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5382));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 508, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 504, DateTimeKind.Utc).AddTicks(6584));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 504, DateTimeKind.Utc).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 504, DateTimeKind.Utc).AddTicks(6591));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 504, DateTimeKind.Utc).AddTicks(6593));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 504, DateTimeKind.Utc).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6354));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6369));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6386));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6491));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6496));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6498));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6504));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6519));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 526, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 513, DateTimeKind.Utc).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 513, DateTimeKind.Utc).AddTicks(585));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 510, DateTimeKind.Utc).AddTicks(6808));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 510, DateTimeKind.Utc).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 510, DateTimeKind.Utc).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 536, DateTimeKind.Utc).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 536, DateTimeKind.Utc).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 536, DateTimeKind.Utc).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 536, DateTimeKind.Utc).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 6, 39, 3, 536, DateTimeKind.Utc).AddTicks(1386));
        }
    }
}
