using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class lastmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_mast_mail_serverm_rec_company_id",
                table: "mast_mail_serverm");

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

            migrationBuilder.CreateIndex(
                name: "uq_mast_mail_serverm_mail_name",
                table: "mast_mail_serverm",
                columns: new[] { "rec_company_id", "mail_name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "uq_mast_mail_serverm_mail_name",
                table: "mast_mail_serverm");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 251, DateTimeKind.Utc).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 251, DateTimeKind.Utc).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 251, DateTimeKind.Utc).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 251, DateTimeKind.Utc).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 251, DateTimeKind.Utc).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 249, DateTimeKind.Utc).AddTicks(3117));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 249, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 249, DateTimeKind.Utc).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 249, DateTimeKind.Utc).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 277, DateTimeKind.Utc).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 272, DateTimeKind.Utc).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 262, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 14, 59, 17, 260, DateTimeKind.Local).AddTicks(5289), new DateTime(2025, 1, 21, 9, 29, 17, 260, DateTimeKind.Utc).AddTicks(5310) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 14, 59, 17, 260, DateTimeKind.Local).AddTicks(5318), new DateTime(2025, 1, 21, 9, 29, 17, 260, DateTimeKind.Utc).AddTicks(5319) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 14, 59, 17, 260, DateTimeKind.Local).AddTicks(5313), new DateTime(2025, 1, 21, 9, 29, 17, 260, DateTimeKind.Utc).AddTicks(5316) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 228, DateTimeKind.Utc).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 228, DateTimeKind.Utc).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 228, DateTimeKind.Utc).AddTicks(7977));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 225, DateTimeKind.Utc).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 225, DateTimeKind.Utc).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 248, DateTimeKind.Utc).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 248, DateTimeKind.Utc).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 247, DateTimeKind.Utc).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 245, DateTimeKind.Utc).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9685));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9704));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9773));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9783));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9812));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 231, DateTimeKind.Utc).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 229, DateTimeKind.Utc).AddTicks(6737));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 229, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 229, DateTimeKind.Utc).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 229, DateTimeKind.Utc).AddTicks(6742));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 229, DateTimeKind.Utc).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7951));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7977));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8008));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8068));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8112));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 244, DateTimeKind.Utc).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 234, DateTimeKind.Utc).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 234, DateTimeKind.Utc).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 233, DateTimeKind.Utc).AddTicks(3109));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 233, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 233, DateTimeKind.Utc).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 252, DateTimeKind.Utc).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 252, DateTimeKind.Utc).AddTicks(4324));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 252, DateTimeKind.Utc).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 252, DateTimeKind.Utc).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 9, 29, 17, 252, DateTimeKind.Utc).AddTicks(4330));

            migrationBuilder.CreateIndex(
                name: "IX_mast_mail_serverm_rec_company_id",
                table: "mast_mail_serverm",
                column: "rec_company_id");
        }
    }
}
