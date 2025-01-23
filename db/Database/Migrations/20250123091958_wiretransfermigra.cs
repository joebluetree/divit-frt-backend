using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class wiretransfermigra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mast_wiretransm_wtim_comp_id",
                table: "mast_wiretransm");

            migrationBuilder.RenameColumn(
                name: "wtim_comp_tel",
                table: "mast_wiretransm",
                newName: "wtim_cust_tel");

            migrationBuilder.RenameColumn(
                name: "wtim_comp_name",
                table: "mast_wiretransm",
                newName: "wtim_cust_name");

            migrationBuilder.RenameColumn(
                name: "wtim_comp_id",
                table: "mast_wiretransm",
                newName: "wtim_cust_id");

            migrationBuilder.RenameColumn(
                name: "wtim_comp_fax",
                table: "mast_wiretransm",
                newName: "wtim_cust_fax");

            migrationBuilder.RenameIndex(
                name: "IX_mast_wiretransm_wtim_comp_id",
                table: "mast_wiretransm",
                newName: "IX_mast_wiretransm_wtim_cust_id");

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 562, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 562, DateTimeKind.Utc).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 562, DateTimeKind.Utc).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 562, DateTimeKind.Utc).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "acc_acctm",
                keyColumn: "acc_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 562, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 561, DateTimeKind.Utc).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 561, DateTimeKind.Utc).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 561, DateTimeKind.Utc).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "acc_groupm",
                keyColumn: "grp_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 561, DateTimeKind.Utc).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_air",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 583, DateTimeKind.Utc).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_fcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 579, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "mark_qtnd_lcl",
                keyColumn: "qtnd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 575, DateTimeKind.Utc).AddTicks(3580));

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 1,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 14, 49, 57, 572, DateTimeKind.Local).AddTicks(7716), new DateTime(2025, 1, 23, 9, 19, 57, 572, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 10,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 14, 49, 57, 572, DateTimeKind.Local).AddTicks(7759), new DateTime(2025, 1, 23, 9, 19, 57, 572, DateTimeKind.Utc).AddTicks(7761) });

            migrationBuilder.UpdateData(
                table: "mark_qtnm",
                keyColumn: "qtnm_id",
                keyValue: 20,
                columns: new[] { "qtnm_date", "rec_created_date" },
                values: new object[] { new DateTime(2025, 1, 23, 14, 49, 57, 572, DateTimeKind.Local).AddTicks(7753), new DateTime(2025, 1, 23, 9, 19, 57, 572, DateTimeKind.Utc).AddTicks(7757) });

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 527, DateTimeKind.Utc).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 527, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "mast_branchm",
                keyColumn: "branch_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 527, DateTimeKind.Utc).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 522, DateTimeKind.Utc).AddTicks(9035));

            migrationBuilder.UpdateData(
                table: "mast_companym",
                keyColumn: "comp_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 522, DateTimeKind.Utc).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 553, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "mast_contactm",
                keyColumn: "cont_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 553, DateTimeKind.Utc).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "mast_customerm",
                keyColumn: "cust_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 551, DateTimeKind.Utc).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "mast_mail_serverm",
                keyColumn: "mail_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 501,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 502,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 503,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 701,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 702,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3117));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 703,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 704,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 705,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 706,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 707,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 708,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 709,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 710,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 711,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 800,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 801,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 802,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 810,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 811,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 812,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 813,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 814,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 815,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 816,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 817,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 818,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 819,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 820,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 821,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 822,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 823,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3163));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 824,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 825,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 826,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3168));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 827,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 828,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3171));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 829,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3173));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 830,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3174));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 831,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 901,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 902,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 903,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "mast_menum",
                keyColumn: "menu_id",
                keyValue: 1001,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 531, DateTimeKind.Utc).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 528, DateTimeKind.Utc).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 528, DateTimeKind.Utc).AddTicks(7289));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 528, DateTimeKind.Utc).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 528, DateTimeKind.Utc).AddTicks(7292));

            migrationBuilder.UpdateData(
                table: "mast_modulem",
                keyColumn: "module_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 528, DateTimeKind.Utc).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3943));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 4,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 5,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 6,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3978));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 7,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 8,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3982));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 9,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 10,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 11,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 12,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 13,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 14,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3994));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 15,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 16,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 17,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 18,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 19,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 20,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 21,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 22,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4023));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 23,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 24,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 25,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4028));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 26,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 27,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 28,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 29,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 30,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 31,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 32,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 33,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 34,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 35,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4077));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 36,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 37,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 38,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 39,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 40,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 41,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4095));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 42,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 43,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4101));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 44,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 45,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4106));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 46,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 47,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 48,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 49,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 50,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 51,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 52,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 54,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 55,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 56,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 57,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 58,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "mast_param",
                keyColumn: "param_id",
                keyValue: 59,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 547, DateTimeKind.Utc).AddTicks(4165));

            migrationBuilder.UpdateData(
                table: "mast_remarkd",
                keyColumn: "remd_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 556, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "mast_remarkm",
                keyColumn: "rem_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 554, DateTimeKind.Utc).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 534, DateTimeKind.Utc).AddTicks(3936));

            migrationBuilder.UpdateData(
                table: "mast_userbranches",
                keyColumn: "ub_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 534, DateTimeKind.Utc).AddTicks(3952));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 532, DateTimeKind.Utc).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 2,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 532, DateTimeKind.Utc).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "mast_userm",
                keyColumn: "user_id",
                keyValue: 3,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 532, DateTimeKind.Utc).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "mast_wiretransd",
                keyColumn: "wtid_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 560, DateTimeKind.Utc).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "mast_wiretransm",
                keyColumn: "wtim_id",
                keyValue: 1,
                columns: new[] { "rec_created_date", "wtim_date" },
                values: new object[] { new DateTime(2025, 1, 23, 9, 19, 57, 557, DateTimeKind.Utc).AddTicks(8053), new DateTime(2025, 1, 23, 14, 49, 57, 557, DateTimeKind.Local).AddTicks(8036) });

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 100,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 564, DateTimeKind.Utc).AddTicks(1666));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 102,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 564, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 103,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 564, DateTimeKind.Utc).AddTicks(1672));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 104,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 564, DateTimeKind.Utc).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "tnt_trackm",
                keyColumn: "track_id",
                keyValue: 105,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 9, 19, 57, 564, DateTimeKind.Utc).AddTicks(1675));

            migrationBuilder.AddForeignKey(
                name: "fk_mast_wiretransm_wtim_cust_id",
                table: "mast_wiretransm",
                column: "wtim_cust_id",
                principalTable: "mast_customerm",
                principalColumn: "cust_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mast_wiretransm_wtim_cust_id",
                table: "mast_wiretransm");

            migrationBuilder.RenameColumn(
                name: "wtim_cust_tel",
                table: "mast_wiretransm",
                newName: "wtim_comp_tel");

            migrationBuilder.RenameColumn(
                name: "wtim_cust_name",
                table: "mast_wiretransm",
                newName: "wtim_comp_name");

            migrationBuilder.RenameColumn(
                name: "wtim_cust_id",
                table: "mast_wiretransm",
                newName: "wtim_comp_id");

            migrationBuilder.RenameColumn(
                name: "wtim_cust_fax",
                table: "mast_wiretransm",
                newName: "wtim_comp_fax");

            migrationBuilder.RenameIndex(
                name: "IX_mast_wiretransm_wtim_cust_id",
                table: "mast_wiretransm",
                newName: "IX_mast_wiretransm_wtim_comp_id");

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

            migrationBuilder.UpdateData(
                table: "mast_wiretransd",
                keyColumn: "wtid_id",
                keyValue: 1,
                column: "rec_created_date",
                value: new DateTime(2025, 1, 23, 7, 1, 24, 959, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "mast_wiretransm",
                keyColumn: "wtim_id",
                keyValue: 1,
                columns: new[] { "rec_created_date", "wtim_date" },
                values: new object[] { new DateTime(2025, 1, 23, 7, 1, 24, 956, DateTimeKind.Utc).AddTicks(8633), new DateTime(2025, 1, 23, 12, 31, 24, 956, DateTimeKind.Local).AddTicks(8619) });

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

            migrationBuilder.AddForeignKey(
                name: "fk_mast_wiretransm_wtim_comp_id",
                table: "mast_wiretransm",
                column: "wtim_comp_id",
                principalTable: "mast_customerm",
                principalColumn: "cust_id");
        }
    }
}
