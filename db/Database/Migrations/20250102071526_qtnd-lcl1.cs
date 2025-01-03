using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class qtndlcl1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "qtnd_per",
                table: "mark_qtnd_lcl",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "qtnd_amt",
                table: "mark_qtnd_lcl",
                type: "numeric(15,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(15,3)");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 583, DateTimeKind.Utc).AddTicks(1001));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 583, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 583, DateTimeKind.Utc).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 583, DateTimeKind.Utc).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 583, DateTimeKind.Utc).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 579, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 579, DateTimeKind.Utc).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 579, DateTimeKind.Utc).AddTicks(4283));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 579, DateTimeKind.Utc).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_pkid",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 605, DateTimeKind.Utc).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_pkid",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 2, 12, 45, 25, 600, DateTimeKind.Local).AddTicks(7087), new DateTime(2025, 1, 2, 7, 15, 25, 600, DateTimeKind.Utc).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 537, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 537, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 537, DateTimeKind.Utc).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 526, DateTimeKind.Utc).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 526, DateTimeKind.Utc).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 578, DateTimeKind.Utc).AddTicks(468));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 578, DateTimeKind.Utc).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 574, DateTimeKind.Utc).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6621));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6631));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 549, DateTimeKind.Utc).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 540, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 540, DateTimeKind.Utc).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 540, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5713));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5745));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5768));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5795));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 570, DateTimeKind.Utc).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 556, DateTimeKind.Utc).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 556, DateTimeKind.Utc).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 552, DateTimeKind.Utc).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 552, DateTimeKind.Utc).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 552, DateTimeKind.Utc).AddTicks(9400));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 585, DateTimeKind.Utc).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 585, DateTimeKind.Utc).AddTicks(8961));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 585, DateTimeKind.Utc).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 585, DateTimeKind.Utc).AddTicks(8965));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 15, 25, 585, DateTimeKind.Utc).AddTicks(8967));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "qtnd_per",
                table: "mark_qtnd_lcl",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "qtnd_amt",
                table: "mark_qtnd_lcl",
                type: "numeric(15,3)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(15,3)",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_pkid",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 2, 7, 8, 52, 459, DateTimeKind.Utc).AddTicks(8669));

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
        }
    }
}
