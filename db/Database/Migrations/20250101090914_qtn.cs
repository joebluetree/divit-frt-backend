using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class qtn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 204, DateTimeKind.Utc).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 204, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 204, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 204, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 204, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 201, DateTimeKind.Utc).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 201, DateTimeKind.Utc).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 201, DateTimeKind.Utc).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 201, DateTimeKind.Utc).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_pkid",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 1, 14, 39, 13, 223, DateTimeKind.Local).AddTicks(1099), new DateTime(2025, 1, 1, 9, 9, 13, 223, DateTimeKind.Utc).AddTicks(1153) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 157, DateTimeKind.Utc).AddTicks(1921));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 157, DateTimeKind.Utc).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 157, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 150, DateTimeKind.Utc).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 150, DateTimeKind.Utc).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 199, DateTimeKind.Utc).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 199, DateTimeKind.Utc).AddTicks(3478));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 195, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7904));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7954));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 165, DateTimeKind.Utc).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 159, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 159, DateTimeKind.Utc).AddTicks(6666));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 159, DateTimeKind.Utc).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(419));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(424));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(426));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(430));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(432));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 190, DateTimeKind.Utc).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 173, DateTimeKind.Utc).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 173, DateTimeKind.Utc).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 169, DateTimeKind.Utc).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 169, DateTimeKind.Utc).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 169, DateTimeKind.Utc).AddTicks(6456));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 208, DateTimeKind.Utc).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 208, DateTimeKind.Utc).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 208, DateTimeKind.Utc).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 208, DateTimeKind.Utc).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 9, 13, 208, DateTimeKind.Utc).AddTicks(2360));

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnm_qtnm_pod_id",
                table: "mark_qtnm",
                column: "qtnm_pod_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnm_qtnm_pol_id",
                table: "mark_qtnm",
                column: "qtnm_pol_id");

            migrationBuilder.CreateIndex(
                name: "IX_mark_qtnm_qtnm_por_id",
                table: "mark_qtnm",
                column: "qtnm_por_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mark_qtnm_qtnm_pod_id",
                table: "mark_qtnm",
                column: "qtnm_pod_id",
                principalTable: "mast_param",
                principalColumn: "param_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mark_qtnm_qtnm_pol_id",
                table: "mark_qtnm",
                column: "qtnm_pol_id",
                principalTable: "mast_param",
                principalColumn: "param_id");

            migrationBuilder.AddForeignKey(
                name: "fk_mark_qtnm_qtnm_por_id",
                table: "mark_qtnm",
                column: "qtnm_por_id",
                principalTable: "mast_param",
                principalColumn: "param_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mark_qtnm_qtnm_pod_id",
                table: "mark_qtnm");

            migrationBuilder.DropForeignKey(
                name: "fk_mark_qtnm_qtnm_pol_id",
                table: "mark_qtnm");

            migrationBuilder.DropForeignKey(
                name: "fk_mark_qtnm_qtnm_por_id",
                table: "mark_qtnm");

            migrationBuilder.DropIndex(
                name: "IX_mark_qtnm_qtnm_pod_id",
                table: "mark_qtnm");

            migrationBuilder.DropIndex(
                name: "IX_mark_qtnm_qtnm_pol_id",
                table: "mark_qtnm");

            migrationBuilder.DropIndex(
                name: "IX_mark_qtnm_qtnm_por_id",
                table: "mark_qtnm");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 883, DateTimeKind.Utc).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 883, DateTimeKind.Utc).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 883, DateTimeKind.Utc).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 883, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 883, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 880, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 880, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 880, DateTimeKind.Utc).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 880, DateTimeKind.Utc).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_pkid",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 1, 14, 37, 28, 895, DateTimeKind.Local).AddTicks(7433), new DateTime(2025, 1, 1, 9, 7, 28, 895, DateTimeKind.Utc).AddTicks(7487) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 830, DateTimeKind.Utc).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 830, DateTimeKind.Utc).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 830, DateTimeKind.Utc).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 826, DateTimeKind.Utc).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 826, DateTimeKind.Utc).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 878, DateTimeKind.Utc).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 878, DateTimeKind.Utc).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 870, DateTimeKind.Utc).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(824));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(856));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(869));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(874));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(878));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 838, DateTimeKind.Utc).AddTicks(884));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 832, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 832, DateTimeKind.Utc).AddTicks(6885));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 832, DateTimeKind.Utc).AddTicks(6887));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9013));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9023));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9041));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 853, DateTimeKind.Utc).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 844, DateTimeKind.Utc).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 844, DateTimeKind.Utc).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 841, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 841, DateTimeKind.Utc).AddTicks(212));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 841, DateTimeKind.Utc).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 886, DateTimeKind.Utc).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 886, DateTimeKind.Utc).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 886, DateTimeKind.Utc).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 886, DateTimeKind.Utc).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 1, 9, 7, 28, 886, DateTimeKind.Utc).AddTicks(4553));
        }
    }
}
