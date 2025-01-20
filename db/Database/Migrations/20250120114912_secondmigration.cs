using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 23, DateTimeKind.Utc).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 23, DateTimeKind.Utc).AddTicks(6756));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 23, DateTimeKind.Utc).AddTicks(6759));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 23, DateTimeKind.Utc).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 23, DateTimeKind.Utc).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 22, DateTimeKind.Utc).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 22, DateTimeKind.Utc).AddTicks(474));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 22, DateTimeKind.Utc).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 22, DateTimeKind.Utc).AddTicks(478));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 49, DateTimeKind.Utc).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 44, DateTimeKind.Utc).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 40, DateTimeKind.Utc).AddTicks(1909));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 17, 19, 12, 37, DateTimeKind.Local).AddTicks(5491), new DateTime(2025, 1, 20, 11, 49, 12, 37, DateTimeKind.Utc).AddTicks(5514) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 17, 19, 12, 37, DateTimeKind.Local).AddTicks(5522), new DateTime(2025, 1, 20, 11, 49, 12, 37, DateTimeKind.Utc).AddTicks(5523) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 20, 17, 19, 12, 37, DateTimeKind.Local).AddTicks(5517), new DateTime(2025, 1, 20, 11, 49, 12, 37, DateTimeKind.Utc).AddTicks(5519) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 2, DateTimeKind.Utc).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 2, DateTimeKind.Utc).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 2, DateTimeKind.Utc).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 11, 998, DateTimeKind.Utc).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 11, 998, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 21, DateTimeKind.Utc).AddTicks(1044));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 21, DateTimeKind.Utc).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 19, DateTimeKind.Utc).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 21, DateTimeKind.Utc).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2931));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2935));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2937));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2952));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2956));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2961));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2963));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2966));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2981));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2983));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2984));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3039));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3068));

            migrationBuilder.InsertData(
                table: "mast_menum",
                columns: new[] { "menu_id", "menu_code", "menu_module_id", "menu_name", "menu_order", "menu_param", "menu_route", "menu_submenu_id", "menu_visible", "rec_company_id", "rec_created_by", "rec_created_date", "rec_edited_by", "rec_edited_date" },
                values: new object[] { 1001, "MAIL-SERVER", 24, "Mail Server Settings", 1, "{'type':'MAIL-SERVER'}", "masters/mailservermList", null, "Y", 1, "ADMIN", new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3073), null, null });

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 3, DateTimeKind.Utc).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 3, DateTimeKind.Utc).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 3, DateTimeKind.Utc).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 3, DateTimeKind.Utc).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 3, DateTimeKind.Utc).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5197));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5206));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5255));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5257));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5268));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5272));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5320));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5294));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5313));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5326));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5333));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5338));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5340));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5348));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5356));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5358));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5433));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5438));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5441));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5457));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 17, DateTimeKind.Utc).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 8, DateTimeKind.Utc).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 8, DateTimeKind.Utc).AddTicks(687));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 6, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 6, DateTimeKind.Utc).AddTicks(6262));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 6, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 24, DateTimeKind.Utc).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 24, DateTimeKind.Utc).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 24, DateTimeKind.Utc).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 24, DateTimeKind.Utc).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 24, DateTimeKind.Utc).AddTicks(9427));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001);

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

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 7, 5, 41, 859, DateTimeKind.Utc).AddTicks(784));

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
        }
    }
}
