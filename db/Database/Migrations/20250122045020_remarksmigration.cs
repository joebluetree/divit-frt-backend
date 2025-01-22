using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class remarksmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mast_remarkmrem_id",
                table: "mast_remarkd",
                type: "integer",
                nullable: true);

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
                columns: new[] { "mast_remarkmrem_id", "rec_created_date" },
                values: new object[] { null, new DateTime(2025, 1, 22, 4, 50, 19, 573, DateTimeKind.Utc).AddTicks(2855) });

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

            migrationBuilder.CreateIndex(
                name: "IX_mast_remarkd_mast_remarkmrem_id",
                table: "mast_remarkd",
                column: "mast_remarkmrem_id");

            migrationBuilder.AddForeignKey(
                name: "FK_mast_remarkd_mast_remarkm_mast_remarkmrem_id",
                table: "mast_remarkd",
                column: "mast_remarkmrem_id",
                principalTable: "mast_remarkm",
                principalColumn: "rem_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mast_remarkd_mast_remarkm_mast_remarkmrem_id",
                table: "mast_remarkd");

            migrationBuilder.DropIndex(
                name: "IX_mast_remarkd_mast_remarkmrem_id",
                table: "mast_remarkd");

            migrationBuilder.DropColumn(
                name: "mast_remarkmrem_id",
                table: "mast_remarkd");

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

            migrationBuilder.UpdateData(
                table: "mast_remarkd",
                keyColumn: "remd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 720, DateTimeKind.Utc).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "mast_remarkm",
                keyColumn: "rem_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 22, 4, 37, 45, 719, DateTimeKind.Utc).AddTicks(8529));

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
        }
    }
}
