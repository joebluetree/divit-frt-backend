using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class thirdmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 682, DateTimeKind.Utc).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 682, DateTimeKind.Utc).AddTicks(7179));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 682, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 682, DateTimeKind.Utc).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 682, DateTimeKind.Utc).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 681, DateTimeKind.Utc).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 681, DateTimeKind.Utc).AddTicks(2466));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 681, DateTimeKind.Utc).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 681, DateTimeKind.Utc).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 706, DateTimeKind.Utc).AddTicks(6908));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 697, DateTimeKind.Utc).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 693, DateTimeKind.Utc).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 10, 17, 14, 691, DateTimeKind.Local).AddTicks(4624), new DateTime(2025, 1, 21, 4, 47, 14, 691, DateTimeKind.Utc).AddTicks(4645) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 10, 17, 14, 691, DateTimeKind.Local).AddTicks(4652), new DateTime(2025, 1, 21, 4, 47, 14, 691, DateTimeKind.Utc).AddTicks(4654) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 21, 10, 17, 14, 691, DateTimeKind.Local).AddTicks(4648), new DateTime(2025, 1, 21, 4, 47, 14, 691, DateTimeKind.Utc).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 661, DateTimeKind.Utc).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 661, DateTimeKind.Utc).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 661, DateTimeKind.Utc).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 658, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 658, DateTimeKind.Utc).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 680, DateTimeKind.Utc).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 680, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 678, DateTimeKind.Utc).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 680, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7596));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7612));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7615));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7622));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7625));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7632));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7635));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7637));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 664, DateTimeKind.Utc).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 662, DateTimeKind.Utc).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 662, DateTimeKind.Utc).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 662, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 662, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 662, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8827));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8835));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8837));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8839));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8843));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8852));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8959));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8967));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8974));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8993));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 676, DateTimeKind.Utc).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 667, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 667, DateTimeKind.Utc).AddTicks(2983));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 666, DateTimeKind.Utc).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 666, DateTimeKind.Utc).AddTicks(60));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 666, DateTimeKind.Utc).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 683, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 683, DateTimeKind.Utc).AddTicks(8488));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 683, DateTimeKind.Utc).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 683, DateTimeKind.Utc).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 21, 4, 47, 14, 683, DateTimeKind.Utc).AddTicks(8493));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 20, 11, 49, 12, 5, DateTimeKind.Utc).AddTicks(3073));

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
    }
}
