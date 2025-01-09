using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class lovaddaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mark_qtnd_lcl_qtnd_qtnm_pkid",
                table: "mark_qtnd_lcl");

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

            migrationBuilder.AddForeignKey(
                name: "fk_mark_qtnd_lcl_qtnm_pkid",
                table: "mark_qtnd_lcl",
                column: "qtnd_qtnm_id",
                principalTable: "mark_qtnm",
                principalColumn: "qtnm_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mark_qtnd_lcl_qtnm_pkid",
                table: "mark_qtnd_lcl");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 128, DateTimeKind.Utc).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 128, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 129, DateTimeKind.Utc).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 129, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 129, DateTimeKind.Utc).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 125, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 125, DateTimeKind.Utc).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 125, DateTimeKind.Utc).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 125, DateTimeKind.Utc).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 151, DateTimeKind.Utc).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 8, 12, 47, 56, 147, DateTimeKind.Local).AddTicks(1460), new DateTime(2025, 1, 8, 7, 17, 56, 147, DateTimeKind.Utc).AddTicks(1510) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 80, DateTimeKind.Utc).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 80, DateTimeKind.Utc).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 80, DateTimeKind.Utc).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 53, DateTimeKind.Utc).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 53, DateTimeKind.Utc).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 123, DateTimeKind.Utc).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 123, DateTimeKind.Utc).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 120, DateTimeKind.Utc).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(166));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(174));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(183));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(185));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 93, DateTimeKind.Utc).AddTicks(187));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 84, DateTimeKind.Utc).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 84, DateTimeKind.Utc).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 84, DateTimeKind.Utc).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7318));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7359));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7446));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 115, DateTimeKind.Utc).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 100, DateTimeKind.Utc).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 100, DateTimeKind.Utc).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 97, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 97, DateTimeKind.Utc).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 97, DateTimeKind.Utc).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 132, DateTimeKind.Utc).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 132, DateTimeKind.Utc).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 132, DateTimeKind.Utc).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 132, DateTimeKind.Utc).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 8, 7, 17, 56, 132, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.AddForeignKey(
                name: "fk_mark_qtnd_lcl_qtnd_qtnm_pkid",
                table: "mark_qtnd_lcl",
                column: "qtnd_qtnm_id",
                principalTable: "mark_qtnm",
                principalColumn: "qtnm_id");
        }
    }
}
