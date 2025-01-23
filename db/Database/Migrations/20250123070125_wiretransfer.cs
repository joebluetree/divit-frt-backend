using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class wiretransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mast_wiretransm",
                columns: table => new
                {
                    wtim_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    wtim_slno = table.Column<int>(type: "integer", nullable: false),
                    wtim_refno = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    wtim_to_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    wtim_comp_id = table.Column<int>(type: "integer", nullable: false),
                    wtim_comp_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    wtim_comp_fax = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    wtim_comp_tel = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    wtim_acc_no = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    wtim_req_type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    wtim_from_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    wtim_date = table.Column<DateTime>(type: "date", nullable: false),
                    wtim_sender_ref = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    wtim_your_ref = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    wtim_is_urgent = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    wtim_is_review = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    wtim_is_comment = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    wtim_is_reply = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    wtim_is_recycle = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    wtim_remarks = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("pk_mast_wiretransm_wtim_id", x => x.wtim_id);
                    table.ForeignKey(
                        name: "fk_mast_wiretransm_rec_branch_id",
                        column: x => x.rec_branch_id,
                        principalTable: "mast_branchm",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "fk_mast_wiretransm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                    table.ForeignKey(
                        name: "fk_mast_wiretransm_wtim_comp_id",
                        column: x => x.wtim_comp_id,
                        principalTable: "mast_customerm",
                        principalColumn: "cust_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_wiretransd",
                columns: table => new
                {
                    wtid_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    wtid_wtim_id = table.Column<int>(type: "integer", nullable: false),
                    wtid_benef_id = table.Column<int>(type: "integer", nullable: true),
                    wtid_benef_ref = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    wtid_bank_id = table.Column<int>(type: "integer", nullable: true),
                    wtid_trns_amt = table.Column<decimal>(type: "numeric(15,3)", nullable: false),
                    wtid_order = table.Column<int>(type: "integer", nullable: false),
                    mast_wiretransmwtim_id = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("pk_mast_wiretransd_wtid_id", x => x.wtid_id);
                    table.ForeignKey(
                        name: "FK_mast_wiretransd_mast_wiretransm_mast_wiretransmwtim_id",
                        column: x => x.mast_wiretransmwtim_id,
                        principalTable: "mast_wiretransm",
                        principalColumn: "wtim_id");
                    table.ForeignKey(
                        name: "fk_mast_wiretransd_rec_branch_id",
                        column: x => x.rec_branch_id,
                        principalTable: "mast_branchm",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "fk_mast_wiretransd_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                    table.ForeignKey(
                        name: "fk_mast_wiretransd_wtid_bank_id",
                        column: x => x.wtid_bank_id,
                        principalTable: "mast_customerm",
                        principalColumn: "cust_id");
                    table.ForeignKey(
                        name: "fk_mast_wiretransd_wtid_benef_id",
                        column: x => x.wtid_benef_id,
                        principalTable: "mast_customerm",
                        principalColumn: "cust_id");
                    table.ForeignKey(
                        name: "fk_mast_wiretransd_wtid_wtim_id",
                        column: x => x.wtid_wtim_id,
                        principalTable: "mast_wiretransm",
                        principalColumn: "wtim_id");
                });

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 962, DateTimeKind.Utc).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 962, DateTimeKind.Utc).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 962, DateTimeKind.Utc).AddTicks(6935));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 962, DateTimeKind.Utc).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 962, DateTimeKind.Utc).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 960, DateTimeKind.Utc).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 960, DateTimeKind.Utc).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 960, DateTimeKind.Utc).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 960, DateTimeKind.Utc).AddTicks(7176));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 987, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 981, DateTimeKind.Utc).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 976, DateTimeKind.Utc).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 12, 31, 24, 974, DateTimeKind.Local).AddTicks(2571), new DateTime(2025, 1, 23, 7, 1, 24, 974, DateTimeKind.Utc).AddTicks(2625) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 12, 31, 24, 974, DateTimeKind.Local).AddTicks(2633), new DateTime(2025, 1, 23, 7, 1, 24, 974, DateTimeKind.Utc).AddTicks(2634) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 12, 31, 24, 974, DateTimeKind.Local).AddTicks(2629), new DateTime(2025, 1, 23, 7, 1, 24, 974, DateTimeKind.Utc).AddTicks(2631) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 927, DateTimeKind.Utc).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 927, DateTimeKind.Utc).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 927, DateTimeKind.Utc).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 920, DateTimeKind.Utc).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 920, DateTimeKind.Utc).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 953, DateTimeKind.Utc).AddTicks(649));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 953, DateTimeKind.Utc).AddTicks(653));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 951, DateTimeKind.Utc).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 947, DateTimeKind.Utc).AddTicks(3774));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1733));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1735));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1737));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1738));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1740));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1742));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1751));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1754));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1803));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1805));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1809));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1828));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 931, DateTimeKind.Utc).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 928, DateTimeKind.Utc).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 928, DateTimeKind.Utc).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 928, DateTimeKind.Utc).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 928, DateTimeKind.Utc).AddTicks(3206));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 928, DateTimeKind.Utc).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9548));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9571));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9579));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9581));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9585));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9587));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9601));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9638));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9646));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9695));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9699));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9705));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9712));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9738));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 946, DateTimeKind.Utc).AddTicks(9742));

            migrationBuilder.UpdateData(
                table: "mast_remarkd",
                keyColumn: "remd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 954, DateTimeKind.Utc).AddTicks(9579));

            migrationBuilder.UpdateData(
                table: "mast_remarkm",
                keyColumn: "rem_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 953, DateTimeKind.Utc).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 934, DateTimeKind.Utc).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 934, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 932, DateTimeKind.Utc).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 932, DateTimeKind.Utc).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 932, DateTimeKind.Utc).AddTicks(8624));

            migrationBuilder.InsertData(
                table: "mast_wiretransm",
                columns: new[] { "wtim_id", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked", "wtim_acc_no", "wtim_comp_fax", "wtim_comp_id", "wtim_comp_name", "wtim_comp_tel", "wtim_date", "wtim_from_name", "wtim_is_comment", "wtim_is_recycle", "wtim_is_reply", "wtim_is_review", "wtim_is_urgent", "wtim_refno", "wtim_remarks", "wtim_req_type", "wtim_sender_ref", "wtim_slno", "wtim_to_name", "wtim_your_ref" },
                values: new object[] { 1, 1, 1, "ADMIN", new DateTime(2025, 1, 23, 7, 1, 24, 956, DateTimeKind.Utc).AddTicks(8633), null, null, null, null, null, 100, null, null, new DateTime(2025, 1, 23, 12, 31, 24, 956, DateTimeKind.Local).AddTicks(8619), null, null, null, null, null, null, "WT-1", null, null, null, 1, "WT-1", null });

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 964, DateTimeKind.Utc).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 964, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 964, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 964, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 964, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.InsertData(
                table: "mast_wiretransd",
                columns: new[] { "wtid_id", "mast_wiretransmwtim_id", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked", "wtid_bank_id", "wtid_benef_id", "wtid_benef_ref", "wtid_order", "wtid_trns_amt", "wtid_wtim_id" },
                values: new object[] { 1, null, 1, 1, "ADMIN", new DateTime(2025, 1, 23, 7, 1, 24, 959, DateTimeKind.Utc).AddTicks(9751), null, null, null, 100, 100, "New test ref", 1, 5000m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_mast_wiretransd_mast_wiretransmwtim_id",
                table: "mast_wiretransd",
                column: "mast_wiretransmwtim_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_wiretransd_rec_branch_id",
                table: "mast_wiretransd",
                column: "rec_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_wiretransd_rec_company_id",
                table: "mast_wiretransd",
                column: "rec_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_wiretransd_wtid_bank_id",
                table: "mast_wiretransd",
                column: "wtid_bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_wiretransd_wtid_benef_id",
                table: "mast_wiretransd",
                column: "wtid_benef_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_wiretransd_wtid_wtim_id",
                table: "mast_wiretransd",
                column: "wtid_wtim_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_wiretransm_rec_branch_id",
                table: "mast_wiretransm",
                column: "rec_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_wiretransm_rec_company_id",
                table: "mast_wiretransm",
                column: "rec_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_wiretransm_wtim_comp_id",
                table: "mast_wiretransm",
                column: "wtim_comp_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mast_wiretransd");

            migrationBuilder.DropTable(
                name: "mast_wiretransm");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 575, DateTimeKind.Utc).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 575, DateTimeKind.Utc).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 575, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 575, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 575, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 573, DateTimeKind.Utc).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 573, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 573, DateTimeKind.Utc).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 573, DateTimeKind.Utc).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 602, DateTimeKind.Utc).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 597, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 592, DateTimeKind.Utc).AddTicks(9371));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 22, 10, 20, 19, 589, DateTimeKind.Local).AddTicks(6312), new DateTime(2025, 1, 22, 4, 50, 19, 589, DateTimeKind.Utc).AddTicks(6339) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 22, 10, 20, 19, 589, DateTimeKind.Local).AddTicks(6349), new DateTime(2025, 1, 22, 4, 50, 19, 589, DateTimeKind.Utc).AddTicks(6351) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 22, 10, 20, 19, 589, DateTimeKind.Local).AddTicks(6343), new DateTime(2025, 1, 22, 4, 50, 19, 589, DateTimeKind.Utc).AddTicks(6347) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 552, DateTimeKind.Utc).AddTicks(6517));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 552, DateTimeKind.Utc).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 552, DateTimeKind.Utc).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 548, DateTimeKind.Utc).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 548, DateTimeKind.Utc).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 571, DateTimeKind.Utc).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 571, DateTimeKind.Utc).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 570, DateTimeKind.Utc).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 568, DateTimeKind.Utc).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8033));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8068));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8082));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8085));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8097));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8105));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8109));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8112));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 555, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 553, DateTimeKind.Utc).AddTicks(5168));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 553, DateTimeKind.Utc).AddTicks(5171));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 553, DateTimeKind.Utc).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 553, DateTimeKind.Utc).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 553, DateTimeKind.Utc).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8947));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8961));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8965));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8968));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9021));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9035));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9052));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9078));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9098));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9103));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 567, DateTimeKind.Utc).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "mast_remarkd",
                keyColumn: "remd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 573, DateTimeKind.Utc).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "mast_remarkm",
                keyColumn: "rem_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 572, DateTimeKind.Utc).AddTicks(3185));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 558, DateTimeKind.Utc).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 558, DateTimeKind.Utc).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 557, DateTimeKind.Utc).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 557, DateTimeKind.Utc).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 557, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 576, DateTimeKind.Utc).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 576, DateTimeKind.Utc).AddTicks(7610));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 576, DateTimeKind.Utc).AddTicks(7612));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 576, DateTimeKind.Utc).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 50, 19, 576, DateTimeKind.Utc).AddTicks(7615));
        }
    }
}
