using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "master_sequence",
                startValue: 1000L);

            migrationBuilder.CreateTable(
                name: "mast_companym",
                columns: table => new
                {
                    comp_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    comp_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    comp_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    comp_address1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    comp_address2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    comp_address3 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_companym_comp_id", x => x.comp_id);
                });

            migrationBuilder.CreateTable(
                name: "mast_logm",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    log_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    log_user_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    log_table = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    log_table_id = table.Column<int>(type: "integer", nullable: false),
                    log_column = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    log_desc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    log_refno = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    log_value = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false),
                    rec_branch_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_logm_log_id", x => x.log_id);
                });

            migrationBuilder.CreateTable(
                name: "acc_groupm",
                columns: table => new
                {
                    grp_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    grp_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    grp_order = table.Column<int>(type: "integer", nullable: false),
                    grp_main_group = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_acc_groupm_grp_id", x => x.grp_id);
                    table.ForeignKey(
                        name: "fk_acc_groupm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_branchm",
                columns: table => new
                {
                    branch_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    branch_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    branch_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    branch_address1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    branch_address2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    branch_address3 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_branchm_branch_id", x => x.branch_id);
                    table.ForeignKey(
                        name: "fk_mast_branchm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_customerm",
                columns: table => new
                {
                    cust_id = table.Column<int>(type: "integer", nullable: false),
                    cust_type = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    cust_code = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    cust_short_name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    cust_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cust_display_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cust_address1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cust_address2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cust_address3 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    cust_row_type = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    cust_is_parent = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    cust_parent_id = table.Column<int>(type: "integer", nullable: true),
                    cust_credit_limit = table.Column<decimal>(type: "numeric(15,3)", nullable: false),
                    cust_est_dt = table.Column<DateTime>(type: "date", nullable: true),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_customerm_cust_id", x => x.cust_id);
                    table.ForeignKey(
                        name: "fk_mast_customerm_cust_parent_id",
                        column: x => x.cust_parent_id,
                        principalTable: "mast_customerm",
                        principalColumn: "cust_id");
                    table.ForeignKey(
                        name: "fk_mast_customerm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_modulem",
                columns: table => new
                {
                    module_id = table.Column<int>(type: "integer", nullable: false),
                    module_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    module_is_installed = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    module_order = table.Column<int>(type: "integer", nullable: false),
                    module_parent_id = table.Column<int>(type: "integer", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_modulem_module_id", x => x.module_id);
                    table.ForeignKey(
                        name: "fk_mast_modulem_module_parent_id",
                        column: x => x.module_parent_id,
                        principalTable: "mast_modulem",
                        principalColumn: "module_id");
                    table.ForeignKey(
                        name: "fk_mast_modulem_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "acc_acctm",
                columns: table => new
                {
                    acc_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    acc_code = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    acc_short_name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    acc_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    acc_type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    acc_row_type = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    acc_maincode_id = table.Column<int>(type: "integer", nullable: true),
                    acc_grp_id = table.Column<int>(type: "integer", nullable: false),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_acc_acctm_acc_id", x => x.acc_id);
                    table.ForeignKey(
                        name: "fk_mast_acctm_acc_grp_id",
                        column: x => x.acc_grp_id,
                        principalTable: "acc_groupm",
                        principalColumn: "grp_id");
                    table.ForeignKey(
                        name: "fk_mast_acctm_acc_maincode_id",
                        column: x => x.acc_maincode_id,
                        principalTable: "acc_acctm",
                        principalColumn: "acc_id");
                    table.ForeignKey(
                        name: "fk_mast_acctm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_param",
                columns: table => new
                {
                    param_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    param_type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    param_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    param_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    param_value1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    param_value2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    param_value3 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    param_value4 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    param_value5 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    param_order = table.Column<int>(type: "integer", nullable: false),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false),
                    rec_branch_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_param_param_id", x => x.param_id);
                    table.ForeignKey(
                        name: "fk_mast_param_rec_branch_id",
                        column: x => x.rec_branch_id,
                        principalTable: "mast_branchm",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "fk_mast_param_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    caption = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    remarks = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    table = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    value = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    code = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    json = table.Column<string>(type: "text", nullable: false),
                    param_id = table.Column<int>(type: "integer", nullable: true),
                    order = table.Column<int>(type: "integer", nullable: false),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false),
                    rec_branch_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_settigs_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_mast_settings_rec_branch_id",
                        column: x => x.rec_branch_id,
                        principalTable: "mast_branchm",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "fk_mast_settings_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_userm",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    user_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    user_name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    user_password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    user_email = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    user_is_admin = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false),
                    rec_branch_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_userm_user_id", x => x.user_id);
                    table.ForeignKey(
                        name: "fk_mast_userm_rec_branch_id",
                        column: x => x.rec_branch_id,
                        principalTable: "mast_branchm",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "fk_mast_userm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_menum",
                columns: table => new
                {
                    menu_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    menu_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    menu_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    menu_route = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    menu_param = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    menu_visible = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    menu_order = table.Column<int>(type: "integer", nullable: false),
                    menu_module_id = table.Column<int>(type: "integer", nullable: false),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false),
                    menu_submenu_id = table.Column<int>(type: "integer", nullable: true),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_menum_menu_id", x => x.menu_id);
                    table.ForeignKey(
                        name: "fk_mast_menum_menu_module_id",
                        column: x => x.menu_module_id,
                        principalTable: "mast_modulem",
                        principalColumn: "module_id");
                    table.ForeignKey(
                        name: "fk_mast_menum_menu_submenu_id",
                        column: x => x.menu_submenu_id,
                        principalTable: "mast_modulem",
                        principalColumn: "module_id");
                    table.ForeignKey(
                        name: "fk_mast_menum_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_contactm",
                columns: table => new
                {
                    cont_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    cont_parent_id = table.Column<int>(type: "integer", nullable: false),
                    cont_title = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    cont_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cont_designation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cont_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cont_tel = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    cont_mobile = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    cont_remarks = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    cont_country_id = table.Column<int>(type: "integer", nullable: false),
                    mast_customermcust_id = table.Column<int>(type: "integer", nullable: true),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_contactm_cont_id", x => x.cont_id);
                    table.ForeignKey(
                        name: "FK_mast_contactm_mast_customerm_mast_customermcust_id",
                        column: x => x.mast_customermcust_id,
                        principalTable: "mast_customerm",
                        principalColumn: "cust_id");
                    table.ForeignKey(
                        name: "fk_mast_contactm_cont_country_id",
                        column: x => x.cont_country_id,
                        principalTable: "mast_param",
                        principalColumn: "param_id");
                    table.ForeignKey(
                        name: "fk_mast_contactm_cont_parent_id",
                        column: x => x.cont_parent_id,
                        principalTable: "mast_customerm",
                        principalColumn: "cust_id");
                    table.ForeignKey(
                        name: "fk_mast_contactm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "tnt_trackm",
                columns: table => new
                {
                    track_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    track_book_no = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    track_cntr_no = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    track_trackd_id = table.Column<int>(type: "integer", nullable: false),
                    track_carrier_id = table.Column<int>(type: "integer", nullable: false),
                    track_last_updated_on = table.Column<DateTime>(type: "timestamp", nullable: true),
                    track_api_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    track_request_id = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    track_pol_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    track_pol_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    track_pol_etd = table.Column<DateTime>(type: "date", nullable: true),
                    track_pod_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    track_pod_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    track_pod_eta = table.Column<DateTime>(type: "date", nullable: true),
                    track_vessel_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    track_vessel_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    track_voyage = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    track_sent_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tnt_trackm_track_id", x => x.track_id);
                    table.ForeignKey(
                        name: "FK_tnt_trackm_mast_param_track_carrier_id",
                        column: x => x.track_carrier_id,
                        principalTable: "mast_param",
                        principalColumn: "param_id");
                    table.ForeignKey(
                        name: "fk_tnt_trackm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_userbranches",
                columns: table => new
                {
                    ub_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    ub_user_id = table.Column<int>(type: "integer", nullable: false),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false),
                    rec_branch_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_userbranches_ub_id", x => x.ub_id);
                    table.ForeignKey(
                        name: "fk_mast_branchm_rec_branch_id",
                        column: x => x.rec_branch_id,
                        principalTable: "mast_branchm",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "fk_mast_userbranches_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                    table.ForeignKey(
                        name: "fk_mast_userbranches_ub_user_id",
                        column: x => x.ub_user_id,
                        principalTable: "mast_userm",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tnt_trackd",
                columns: table => new
                {
                    trackd_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    trackd_trackm_id = table.Column<int>(type: "integer", nullable: false),
                    trackd_last_updated_on = table.Column<DateTime>(type: "timestamp", nullable: true),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tnt_trackd_trackd_id", x => x.trackd_id);
                    table.ForeignKey(
                        name: "FK_tnt_trackd_tnt_trackm_trackd_trackm_id",
                        column: x => x.trackd_trackm_id,
                        principalTable: "tnt_trackm",
                        principalColumn: "track_id");
                    table.ForeignKey(
                        name: "fk_mast_trackd_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.CreateTable(
                name: "mast_rightsm",
                columns: table => new
                {
                    rights_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"master_sequence\"')"),
                    rights_parent_id = table.Column<int>(type: "integer", nullable: false),
                    rights_user_id = table.Column<int>(type: "integer", nullable: false),
                    rights_menu_id = table.Column<int>(type: "integer", nullable: false),
                    rights_company = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    rights_admin = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    rights_add = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    rights_edit = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    rights_view = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    rights_delete = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    rights_print = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    rights_doc_upload = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    rights_doc_view = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    rights_approver = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    rights_value = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    rec_version = table.Column<int>(type: "integer", nullable: false),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false),
                    rec_branch_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mast_rightsm_rights_id", x => x.rights_id);
                    table.ForeignKey(
                        name: "fk_mast_branchm_rec_branch_id",
                        column: x => x.rec_branch_id,
                        principalTable: "mast_branchm",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "fk_mast_rightsm_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                    table.ForeignKey(
                        name: "fk_mast_rightsm_rights_menu_id",
                        column: x => x.rights_menu_id,
                        principalTable: "mast_menum",
                        principalColumn: "menu_id");
                    table.ForeignKey(
                        name: "fk_mast_rightsm_rights_parent_id",
                        column: x => x.rights_parent_id,
                        principalTable: "mast_userbranches",
                        principalColumn: "ub_id");
                    table.ForeignKey(
                        name: "fk_mast_rightsm_rights_user_id",
                        column: x => x.rights_user_id,
                        principalTable: "mast_userm",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tnt_tracking_data",
                columns: table => new
                {
                    track_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tnt_trackm_id = table.Column<int>(type: "integer", nullable: false),
                    tnt_trackd_id = table.Column<int>(type: "integer", nullable: false),
                    tnt_eventCreatedDateTime = table.Column<DateTime>(type: "timestamp", nullable: false),
                    tnt_eventCreatedDateTime_utc = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    tnt_eventDateTime = table.Column<DateTime>(type: "timestamp", nullable: false),
                    tnt_eventDateTime_utc = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    tnt_container = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_transport_mode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_event_type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_event_confirm_status = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_status_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_status_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_port_code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_port_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_port_location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_vessel = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_vessel_imon = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_voyage = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tnt_row_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    rec_version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    rec_locked = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    rec_created_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rec_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rec_edited_by = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rec_edited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rec_company_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tnt_tracking_data_track_id", x => x.track_id);
                    table.ForeignKey(
                        name: "FK_tnt_tracking_data_tnt_trackd_tnt_trackd_id",
                        column: x => x.tnt_trackd_id,
                        principalTable: "tnt_trackd",
                        principalColumn: "trackd_id");
                    table.ForeignKey(
                        name: "FK_tnt_tracking_data_tnt_trackm_tnt_trackm_id",
                        column: x => x.tnt_trackm_id,
                        principalTable: "tnt_trackm",
                        principalColumn: "track_id");
                    table.ForeignKey(
                        name: "fk_mast_tracking_data_rec_company_id",
                        column: x => x.rec_company_id,
                        principalTable: "mast_companym",
                        principalColumn: "comp_id");
                });

            migrationBuilder.InsertData(
                table: "mast_companym",
                columns: new[] { "comp_id", "comp_address1", "comp_address2", "comp_address3", "comp_code", "comp_name", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[,]
                {
                    { 1, "ADDRESS LINE 1", "ADDRESS LINE 2", "ADDRESS LINE3 3", "COMPANY1", "COMPANY1", "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 100, DateTimeKind.Utc).AddTicks(5608), null, null },
                    { 2, "ADDRESS LINE 1", "ADDRESS LINE 2", "ADDRESS LINE3 3", "COMPANY2", "COMPANY2", "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 100, DateTimeKind.Utc).AddTicks(5611), null, null }
                });

            migrationBuilder.InsertData(
                table: "acc_groupm",
                columns: new[] { "grp_id", "grp_main_group", "grp_name", "grp_order", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[,]
                {
                    { 1, "ASSET", "CURRENT ASSETS", 1, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(8910), null, null, "N" },
                    { 2, "LIABILITIES", "CURRENT LIABILITIES", 1, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(8912), null, null, "N" },
                    { 3, "DIRECT INCOME", "DIRECT INCOME", 1, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(8913), null, null, "N" },
                    { 4, "DIRECT EXPENSE", "DIRECT EXPENSE", 1, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(8915), null, null, "N" }
                });

            migrationBuilder.InsertData(
                table: "mast_branchm",
                columns: new[] { "branch_id", "branch_address1", "branch_address2", "branch_address3", "branch_code", "branch_name", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[,]
                {
                    { 1, "ADDRESS LINE 1", "ADDRESS LINE 2", "ADDRESS LINE3 3", "BRANCH1", "BRANCH1", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 102, DateTimeKind.Utc).AddTicks(6600), null, null, "N" },
                    { 2, "ADDRESS LINE 1", "ADDRESS LINE 2", "ADDRESS LINE3 3", "BRANCH2", "BRANCH2", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 102, DateTimeKind.Utc).AddTicks(6603), null, null, "N" },
                    { 3, "ADDRESS LINE 1", "ADDRESS LINE 2", "ADDRESS LINE3 3", "BRANCH3", "BRANCH3", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 102, DateTimeKind.Utc).AddTicks(6604), null, null, "N" }
                });

            migrationBuilder.InsertData(
                table: "mast_customerm",
                columns: new[] { "cust_id", "cust_address1", "cust_address2", "cust_address3", "cust_code", "cust_credit_limit", "cust_display_name", "cust_est_dt", "cust_is_parent", "cust_name", "cust_parent_id", "cust_row_type", "cust_short_name", "cust_type", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[] { 100, "PO BOX 12123", "LMS BUILDING", "KOCHI", "ABC", 0m, "ABC LTD", null, "Y", "ABC LTD KOCHI", null, "CUSTOMER", "ABC", "", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 116, DateTimeKind.Utc).AddTicks(3034), null, null, "N" });

            migrationBuilder.InsertData(
                table: "mast_modulem",
                columns: new[] { "module_id", "module_is_installed", "module_name", "module_order", "module_parent_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[,]
                {
                    { 20, "Y", "Accounts", 1, null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 103, DateTimeKind.Utc).AddTicks(6805), null, null },
                    { 21, "Y", "Masters", 3, null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 103, DateTimeKind.Utc).AddTicks(6807), null, null },
                    { 22, "Y", "Tracking", 4, null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 103, DateTimeKind.Utc).AddTicks(6809), null, null }
                });

            migrationBuilder.InsertData(
                table: "mast_param",
                columns: new[] { "param_id", "param_code", "param_name", "param_order", "param_type", "param_value1", "param_value2", "param_value3", "param_value4", "param_value5", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[,]
                {
                    { 1, "IN", "INDIA", 1, "COUNTRY", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7436), null, null },
                    { 2, "US", "USA", 2, "COUNTRY", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7439), null, null },
                    { 3, "KL", "KERALA", 1, "STATE", "", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7452), null, null },
                    { 4, "CMA", "CMA CHM", 1, "SEA CARRIER", "CMDU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7461), null, null },
                    { 5, "HLCU", "HAPAQ LLOYD", 2, "SEA CARRIER", "HLCU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7463), null, null },
                    { 6, "MAEU", "MAERSK", 3, "SEA CARRIER", "MAEU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7465), null, null },
                    { 7, "MSCU", "MSC", 4, "SEA CARRIER", "MSCU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7467), null, null },
                    { 8, "EGLV", "EVERGREEN", 5, "SEA CARRIER", "EGLV", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7468), null, null },
                    { 9, "HDMU", "HMM", 6, "SEA CARRIER", "HDMU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7470), null, null },
                    { 10, "YMLU", "YANG MING", 7, "SEA CARRIER", "YMLU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7472), null, null },
                    { 11, "ONEY", "OCEAN NETWORK EXPRESS", 8, "SEA CARRIER", "ONEY", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7473), null, null },
                    { 12, "OOCL", "OOCL", 9, "SEA CARRIER", "OOLU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7475), null, null },
                    { 13, "COSCO", "COSCO", 10, "SEA CARRIER", "COSU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7477), null, null },
                    { 14, "ANL", "ANL", 11, "SEA CARRIER", "ANNU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7479), null, null },
                    { 15, "APL", "APL", 12, "SEA CARRIER", "ANNU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7480), null, null },
                    { 16, "EMIRATES", "EMIRATES", 13, "SEA CARRIER", "ESPU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7482), null, null },
                    { 17, "HANJIN", "HANJIN", 14, "SEA CARRIER", "HJSC", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7483), null, null },
                    { 18, "KLINE", "KLINE", 15, "SEA CARRIER", "KKLU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7485), null, null },
                    { 19, "MOL", "MOL", 16, "SEA CARRIER", "MOLU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7487), null, null },
                    { 20, "NYK", "NYK LINE", 17, "SEA CARRIER", "NYKS", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7488), null, null },
                    { 21, "OSTI", "ORIENT STAR", 18, "SEA CARRIER", "OSTI", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7490), null, null },
                    { 22, "PAN ASIA", "PAN ASIA", 19, "SEA CARRIER", "PALU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7491), null, null },
                    { 23, "PIL", "PIL", 20, "SEA CARRIER", "PCIU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7493), null, null },
                    { 24, "PMO", "PMO", 21, "SEA CARRIER", "PMOL", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7495), null, null },
                    { 25, "ZIM", "ZIM", 22, "SEA CARRIER", "ZIMU", "", "", "", "", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 114, DateTimeKind.Utc).AddTicks(7497), null, null }
                });

            migrationBuilder.InsertData(
                table: "acc_acctm",
                columns: new[] { "acc_id", "acc_code", "acc_grp_id", "acc_maincode_id", "acc_name", "acc_row_type", "acc_short_name", "acc_type", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[,]
                {
                    { 1, "OI", 1, null, "OCEAN IMPORT", "MAIN-CODE", "OI", "NA", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 120, DateTimeKind.Utc).AddTicks(5431), null, null, "N" },
                    { 2, "OE", 1, null, "OCEAN EXPORT", "MAIN-CODE", "OE", "NA", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 120, DateTimeKind.Utc).AddTicks(5434), null, null, "N" },
                    { 3, "AR", 1, null, "AR", "MAIN-CODE", "AR", "AR", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 120, DateTimeKind.Utc).AddTicks(5436), null, null, "N" },
                    { 4, "AP", 2, null, "AP", "MAIN-CODE", "AP", "AP", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 120, DateTimeKind.Utc).AddTicks(5438), null, null, "N" }
                });

            migrationBuilder.InsertData(
                table: "mast_contactm",
                columns: new[] { "cont_id", "cont_country_id", "cont_designation", "cont_email", "cont_mobile", "cont_name", "cont_parent_id", "cont_remarks", "cont_tel", "cont_title", "mast_customermcust_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[,]
                {
                    { 1, 1, "EXECUTIVE", "joy@cargomar.in", "9947194307", "JOY", 100, null, "0484-245678", "MR", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(1300), null, null, "N" },
                    { 2, 1, "EXECUTIVE", "ajith@cargomar.in", "9917294107", "AJITH", 100, null, "0484-245678", "MR", null, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 118, DateTimeKind.Utc).AddTicks(1303), null, null, "N" }
                });

            migrationBuilder.InsertData(
                table: "mast_menum",
                columns: new[] { "menu_id", "menu_code", "menu_module_id", "menu_name", "menu_order", "menu_param", "menu_route", "menu_submenu_id", "menu_visible", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[,]
                {
                    { 501, "ACCGROUP", 20, "A/c Group", 1, "{'type':'ACCGROUP'}", "accounts/accgroupList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1104), null, null },
                    { 502, "ACCTM-MAINCODE", 20, "A/c Main Code", 2, "{'type':'MAIN-CODE'}", "accounts/acctmList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1109), null, null },
                    { 503, "ACCTM", 20, "A/c Master", 3, "{'type':'ACC-CODE'}", "accounts/acctmList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1111), null, null },
                    { 701, "COMPANY", 21, "Company Master", 1, "{'type':'COMPANY'}", "admin/companyList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1127), null, null },
                    { 702, "BRANCH", 21, "Branch Master", 2, "{'type':'BRANCH'}", "admin/branchList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1129), null, null },
                    { 703, "MODULE", 21, "Module Master", 3, "{'type':'MODULE'}", "admin/moduleList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1130), null, null },
                    { 704, "USER", 21, "User Master", 4, "{'type':'USER'}", "admin/userList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1132), null, null },
                    { 705, "MENU", 21, "Menu Master", 5, "{'type':'MENU'}", "admin/menuList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1133), null, null },
                    { 706, "RIGHTS", 21, "User Rights", 6, "{'type':'RIGHTS'}", "admin/rightsList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1135), null, null },
                    { 707, "COUNTRY", 21, "Country Master", 7, "{'type':'COUNTRY'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1151), null, null },
                    { 708, "STATE", 21, "State Master", 8, "{'type':'STATE'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1152), null, null },
                    { 709, "COMPANY-SETTINGS", 21, "Company Settings", 9, "{'type':'COMPANY-SETTINGS'}", "admin/settingsList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1154), null, null },
                    { 710, "BRANCH-SETTINGS", 21, "Branch Settings", 10, "{'type':'BRANCH-SETTINGS'}", "admin/settingsList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1155), null, null },
                    { 711, "CUSTOMER", 21, "Customer Master", 11, "{'type':'CUSTOMER'}", "masters/customerList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1157), null, null },
                    { 800, "TRACKING", 22, "Container Tracking", 1, "{'type':'TRACKING'}", "tnt/trackList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1158), null, null },
                    { 801, "SEACARRIER", 21, "Ocean Carrier", 10, "{'type':'SEA CARRIER'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1159), null, null },
                    { 802, "AIRCARRIER", 21, "Air Carrier", 10, "{'type':'AIR CARRIER'}", "masters/paramList", null, "Y", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1162), null, null },
                    { 810, "PARAM-SETTINGS", 21, "Param Settings", 11, "{'type':'PARAM-SETTINGS'}", "admin/settingsList", null, "N", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 107, DateTimeKind.Utc).AddTicks(1163), null, null }
                });

            migrationBuilder.InsertData(
                table: "mast_userm",
                columns: new[] { "user_id", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "user_code", "user_email", "user_is_admin", "user_name", "user_password" },
                values: new object[,]
                {
                    { 1, 1, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 108, DateTimeKind.Utc).AddTicks(6661), null, null, "ADMIN", "admin@gmail.com", "Y", "ADMIN", "ADMIN" },
                    { 2, 1, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 108, DateTimeKind.Utc).AddTicks(6663), null, null, "USER1", "user1@gmail.com", "N", "USER1", "USER1" },
                    { 3, 1, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 108, DateTimeKind.Utc).AddTicks(6665), null, null, "USER2", "user2@gmail.com", "N", "USER2", "USER2" }
                });

            migrationBuilder.InsertData(
                table: "tnt_trackm",
                columns: new[] { "track_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "track_api_type", "track_book_no", "track_carrier_id", "track_cntr_no", "track_last_updated_on", "track_pod_code", "track_pod_eta", "track_pod_name", "track_pol_code", "track_pol_etd", "track_pol_name", "track_request_id", "track_sent_on", "track_trackd_id", "track_vessel_code", "track_vessel_name", "track_voyage" },
                values: new object[,]
                {
                    { 100, 1, "admin", new DateTime(2024, 12, 3, 8, 49, 22, 122, DateTimeKind.Utc).AddTicks(2500), null, null, "API", "", 5, "HLXU8787996", null, null, null, null, null, null, null, null, null, 0, null, null, null },
                    { 101, 1, "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "API", "", 4, "CMAU7228147", null, null, null, null, null, null, null, null, null, 0, null, null, null },
                    { 102, 1, "admin", new DateTime(2024, 12, 3, 8, 49, 22, 122, DateTimeKind.Utc).AddTicks(2503), null, null, "API", "", 6, "MAEU3417227", null, null, null, null, null, null, null, null, null, 0, null, null, null },
                    { 103, 1, "admin", new DateTime(2024, 12, 3, 8, 49, 22, 122, DateTimeKind.Utc).AddTicks(2505), null, null, "API-1", "", 10, "MAGU5540135", null, null, null, null, null, null, null, null, null, 0, null, null, null },
                    { 104, 1, "admin", new DateTime(2024, 12, 3, 8, 49, 22, 122, DateTimeKind.Utc).AddTicks(2506), null, null, "SHIPSGO", "", 13, "BEAU6030782", null, null, null, null, null, null, null, "4179934", null, 0, null, null, null },
                    { 105, 1, "admin", new DateTime(2024, 12, 3, 8, 49, 22, 122, DateTimeKind.Utc).AddTicks(2508), null, null, "SHIPSGO", "", 7, "SEGU9471335", null, null, null, null, null, null, null, "4182169", null, 0, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "acc_acctm",
                columns: new[] { "acc_id", "acc_code", "acc_grp_id", "acc_maincode_id", "acc_name", "acc_row_type", "acc_short_name", "acc_type", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "rec_locked" },
                values: new object[] { 5, "OE", 2, 2, "OCEAN EXPORT", "ACC-CODE", "OE", "NA", 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 120, DateTimeKind.Utc).AddTicks(5439), null, null, "N" });

            migrationBuilder.InsertData(
                table: "mast_userbranches",
                columns: new[] { "ub_id", "rec_branch_id", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date", "ub_user_id" },
                values: new object[,]
                {
                    { 1, 1, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 110, DateTimeKind.Utc).AddTicks(2833), null, null, 2 },
                    { 2, 2, 1, "ADMIN", new DateTime(2024, 12, 3, 8, 49, 22, 110, DateTimeKind.Utc).AddTicks(2834), null, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_acc_acctm_acc_grp_id",
                table: "acc_acctm",
                column: "acc_grp_id");

            migrationBuilder.CreateIndex(
                name: "IX_acc_acctm_acc_maincode_id",
                table: "acc_acctm",
                column: "acc_maincode_id");

            migrationBuilder.CreateIndex(
                name: "uq_acc_acctm_acc_code",
                table: "acc_acctm",
                columns: new[] { "rec_company_id", "acc_row_type", "acc_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_acc_acctm_acc_name",
                table: "acc_acctm",
                columns: new[] { "rec_company_id", "acc_row_type", "acc_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_acc_acctm_acc_short_name",
                table: "acc_acctm",
                columns: new[] { "rec_company_id", "acc_row_type", "acc_short_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_acc_groupm_grp_name",
                table: "acc_groupm",
                columns: new[] { "rec_company_id", "grp_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_mast_branchm_branch_code",
                table: "mast_branchm",
                columns: new[] { "rec_company_id", "branch_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_mast_branchm_branch_name",
                table: "mast_branchm",
                columns: new[] { "rec_company_id", "branch_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_mast_companym_comp_code",
                table: "mast_companym",
                columns: new[] { "comp_id", "comp_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_mast_companym_comp_name",
                table: "mast_companym",
                columns: new[] { "comp_id", "comp_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mast_contactm_cont_country_id",
                table: "mast_contactm",
                column: "cont_country_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_contactm_cont_parent_id",
                table: "mast_contactm",
                column: "cont_parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_contactm_mast_customermcust_id",
                table: "mast_contactm",
                column: "mast_customermcust_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_contactm_rec_company_id",
                table: "mast_contactm",
                column: "rec_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_customerm_cust_parent_id",
                table: "mast_customerm",
                column: "cust_parent_id");

            migrationBuilder.CreateIndex(
                name: "uq_cust_customerm_cust_code",
                table: "mast_customerm",
                columns: new[] { "rec_company_id", "cust_row_type", "cust_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_cust_customerm_cust_name",
                table: "mast_customerm",
                columns: new[] { "rec_company_id", "cust_row_type", "cust_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_cust_customerm_cust_short_name",
                table: "mast_customerm",
                columns: new[] { "rec_company_id", "cust_row_type", "cust_short_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_mast_logm_log_id",
                table: "mast_logm",
                column: "log_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_menum_menu_module_id",
                table: "mast_menum",
                column: "menu_module_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_menum_menu_submenu_id",
                table: "mast_menum",
                column: "menu_submenu_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_menum_rec_company_id",
                table: "mast_menum",
                column: "rec_company_id");

            migrationBuilder.CreateIndex(
                name: "uq_mast_menum_menu_name",
                table: "mast_menum",
                columns: new[] { "menu_id", "menu_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mast_modulem_module_parent_id",
                table: "mast_modulem",
                column: "module_parent_id");

            migrationBuilder.CreateIndex(
                name: "uq_mast_modulem_rec_company_id_module_name",
                table: "mast_modulem",
                columns: new[] { "rec_company_id", "module_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mast_param_rec_branch_id",
                table: "mast_param",
                column: "rec_branch_id");

            migrationBuilder.CreateIndex(
                name: "uq_mast_param_param_code",
                table: "mast_param",
                columns: new[] { "rec_company_id", "param_type", "param_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_mast_param_param_name",
                table: "mast_param",
                columns: new[] { "rec_company_id", "param_type", "param_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mast_rightsm_rec_branch_id",
                table: "mast_rightsm",
                column: "rec_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_rightsm_rights_menu_id",
                table: "mast_rightsm",
                column: "rights_menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_rightsm_rights_parent_id",
                table: "mast_rightsm",
                column: "rights_parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_rightsm_rights_user_id",
                table: "mast_rightsm",
                column: "rights_user_id");

            migrationBuilder.CreateIndex(
                name: "uq_mast_rightsm_menu_id",
                table: "mast_rightsm",
                columns: new[] { "rec_company_id", "rec_branch_id", "rights_user_id", "rights_menu_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mast_settings_rec_branch_id",
                table: "mast_settings",
                column: "rec_branch_id");

            migrationBuilder.CreateIndex(
                name: "uq_mast_settings_rec_company_id_branch_id_param_id_caption",
                table: "mast_settings",
                columns: new[] { "rec_company_id", "rec_branch_id", "param_id", "caption" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mast_userbranches_rec_branch_id",
                table: "mast_userbranches",
                column: "rec_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_mast_userbranches_ub_user_id",
                table: "mast_userbranches",
                column: "ub_user_id");

            migrationBuilder.CreateIndex(
                name: "uq_mast_userbranches_branch",
                table: "mast_userbranches",
                columns: new[] { "rec_company_id", "ub_user_id", "rec_branch_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mast_userm_rec_branch_id",
                table: "mast_userm",
                column: "rec_branch_id");

            migrationBuilder.CreateIndex(
                name: "uq_mast_userm_user_code",
                table: "mast_userm",
                columns: new[] { "rec_company_id", "user_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uq_mast_userm_user_name",
                table: "mast_userm",
                columns: new[] { "rec_company_id", "user_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tnt_trackd_rec_company_id",
                table: "tnt_trackd",
                column: "rec_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tnt_trackd_trackd_trackm_id",
                table: "tnt_trackd",
                column: "trackd_trackm_id");

            migrationBuilder.CreateIndex(
                name: "IX_tnt_tracking_data_rec_company_id",
                table: "tnt_tracking_data",
                column: "rec_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tnt_tracking_data_tnt_trackd_id",
                table: "tnt_tracking_data",
                column: "tnt_trackd_id");

            migrationBuilder.CreateIndex(
                name: "IX_tnt_tracking_data_tnt_trackm_id",
                table: "tnt_tracking_data",
                column: "tnt_trackm_id");

            migrationBuilder.CreateIndex(
                name: "IX_tnt_trackm_rec_company_id",
                table: "tnt_trackm",
                column: "rec_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tnt_trackm_track_carrier_id",
                table: "tnt_trackm",
                column: "track_carrier_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acc_acctm");

            migrationBuilder.DropTable(
                name: "mast_contactm");

            migrationBuilder.DropTable(
                name: "mast_logm");

            migrationBuilder.DropTable(
                name: "mast_rightsm");

            migrationBuilder.DropTable(
                name: "mast_settings");

            migrationBuilder.DropTable(
                name: "tnt_tracking_data");

            migrationBuilder.DropTable(
                name: "acc_groupm");

            migrationBuilder.DropTable(
                name: "mast_customerm");

            migrationBuilder.DropTable(
                name: "mast_menum");

            migrationBuilder.DropTable(
                name: "mast_userbranches");

            migrationBuilder.DropTable(
                name: "tnt_trackd");

            migrationBuilder.DropTable(
                name: "mast_modulem");

            migrationBuilder.DropTable(
                name: "mast_userm");

            migrationBuilder.DropTable(
                name: "tnt_trackm");

            migrationBuilder.DropTable(
                name: "mast_param");

            migrationBuilder.DropTable(
                name: "mast_branchm");

            migrationBuilder.DropTable(
                name: "mast_companym");

            migrationBuilder.DropSequence(
                name: "master_sequence");
        }
    }
}
