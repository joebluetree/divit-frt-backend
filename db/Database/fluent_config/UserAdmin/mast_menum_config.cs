using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.fluent_config.UserAdmin
{
    public class mast_menum_config : IEntityTypeConfiguration<mast_menum>
    {
        public void Configure(EntityTypeBuilder<mast_menum> modelBuilder)
        {
            //Table
            modelBuilder.ToTable("mast_menum");
            //Primary Key
            modelBuilder.HasKey(e => e.menu_id)
                .HasName("pk_mast_menum_menu_id");
            //Sequence
            modelBuilder.Property(u => u.menu_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();


            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //Column
            modelBuilder.Property(e => e.menu_code)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Property(e => e.menu_name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(e => e.menu_route)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(e => e.menu_param)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.menu_visible)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(e => e.menu_submenu_id)
                .IsRequired(false);
            modelBuilder.Property(e => e.menu_order)
                .IsRequired();
            modelBuilder.Property(u => u.rec_locked)
                .HasColumnType("char")
                .HasMaxLength(1)
                .HasDefaultValue("N")
                .IsRequired();
            modelBuilder.Property(u => u.rec_created_by)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Property(u => u.rec_created_date)
                .IsRequired();

            modelBuilder.Property(u => u.rec_edited_by)
                .HasMaxLength(20)
                .IsRequired(false);
            modelBuilder.Property(u => u.rec_edited_date)
                .IsRequired(false);
            //unique key
            modelBuilder.HasIndex(e => new { e.menu_id, e.menu_name })
                .HasDatabaseName("uq_mast_menum_menu_name")
                .IsUnique(true);
            //Foreign Key
            modelBuilder
                .HasOne(e => e.module)
                .WithMany(e => e.menus)
                .HasForeignKey(e => e.menu_module_id)
                .HasPrincipalKey(e => e.module_id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_mast_menum_menu_module_id")
                .IsRequired();
            modelBuilder
                .HasOne(e => e.submenu)
                .WithMany()
                .HasForeignKey(e => e.menu_submenu_id)
                .HasPrincipalKey(e => e.module_id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_mast_menum_menu_submenu_id")
                .IsRequired(false);
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(c => c.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_menum_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();


            insertdata_Accounts(modelBuilder);
            insertdata_Masters(modelBuilder);
        }


        void insertdata_Accounts(EntityTypeBuilder<mast_menum> modelBuilder)
        {
            modelBuilder.HasData(
            new mast_menum
            {
                menu_id = 501,
                menu_module_id = 20,
                menu_order = 1,
                menu_code = "ACCGROUP",
                menu_name = "A/c Group",
                menu_route = "accounts/accgroupList",
                menu_param = "{'type':'ACCGROUP'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 502,
                menu_module_id = 20,
                menu_order = 2,
                menu_code = "ACCTM-MAINCODE",
                menu_name = "A/c Main Code",
                menu_route = "accounts/acctmList",
                menu_param = "{'type':'MAIN-CODE'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 503,
                menu_module_id = 20,
                menu_order = 3,
                menu_code = "ACCTM",
                menu_name = "A/c Master",
                menu_route = "accounts/acctmList",
                menu_param = "{'type':'ACC-CODE'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            }
            );
        }


        void insertdata_Masters(EntityTypeBuilder<mast_menum> modelBuilder)
        {
            modelBuilder.HasData(
            new mast_menum
            {
                menu_id = 701,
                menu_module_id = 21,
                menu_order = 1,
                menu_code = "COMPANY",
                menu_name = "Company Master",
                menu_route = "admin/companyList",
                menu_param = "{'type':'COMPANY'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 702,
                menu_module_id = 21,
                menu_order = 2,
                menu_code = "BRANCH",
                menu_name = "Branch Master",
                menu_route = "admin/branchList",
                menu_param = "{'type':'BRANCH'}",
                menu_visible = "Y",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 703,
                menu_module_id = 21,
                menu_order = 3,
                menu_code = "MODULE",
                menu_name = "Module Master",
                menu_route = "admin/moduleList",
                menu_param = "{'type':'MODULE'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 704,
                menu_module_id = 21,
                menu_order = 4,
                menu_code = "USER",
                menu_name = "User Master",
                menu_route = "admin/userList",
                menu_param = "{'type':'USER'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 705,
                menu_module_id = 21,
                menu_order = 5,
                menu_code = "MENU",
                menu_name = "Menu Master",
                menu_route = "admin/menuList",
                menu_param = "{'type':'MENU'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 706,
                menu_module_id = 21,
                menu_order = 6,
                menu_code = "RIGHTS",
                menu_name = "User Rights",
                menu_route = "admin/rightsList",
                menu_param = "{'type':'RIGHTS'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 707,
                menu_module_id = 21,
                menu_order = 7,
                menu_code = "COUNTRY",
                menu_name = "Country Master",
                menu_route = "masters/paramList",
                menu_param = "{'type':'COUNTRY'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 708,
                menu_module_id = 21,
                menu_order = 8,
                menu_code = "STATE",
                menu_name = "State Master",
                menu_route = "masters/paramList",
                menu_param = "{'type':'STATE'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 709,
                menu_module_id = 21,
                menu_order = 9,
                menu_code = "COMPANY-SETTINGS",
                menu_name = "Company Settings",
                menu_route = "admin/settingsList",
                menu_param = "{'type':'COMPANY-SETTINGS'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 710,
                menu_module_id = 21,
                menu_order = 10,
                menu_code = "BRANCH-SETTINGS",
                menu_name = "Branch Settings",
                menu_route = "admin/settingsList",
                menu_param = "{'type':'BRANCH-SETTINGS'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"

            },
            new mast_menum
            {
                menu_id = 711,
                menu_module_id = 21,
                menu_order = 11,
                menu_code = "CUSTOMER",
                menu_name = "Customer Master",
                menu_route = "masters/customerList",
                menu_param = "{'type':'CUSTOMER'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 800,
                menu_module_id = 22,
                menu_order = 1,
                menu_code = "TRACKING",
                menu_name = "Container Tracking",
                menu_route = "tnt/trackList",
                menu_param = "{'type':'TRACKING'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 801,
                menu_module_id = 21,
                menu_order = 10,
                menu_code = "SEACARRIER",
                menu_name = "Ocean Carrier",
                menu_route = "masters/paramList",
                menu_param = "{'type':'SEA CARRIER'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 802,
                menu_module_id = 21,
                menu_order = 10,
                menu_code = "AIRCARRIER",
                menu_name = "Air Carrier",
                menu_route = "masters/paramList",
                menu_param = "{'type':'AIR CARRIER'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 810,
                menu_module_id = 21,
                menu_order = 11,
                menu_code = "PARAM-SETTINGS",
                menu_name = "Param Settings",
                menu_route = "admin/settingsList",
                menu_param = "{'type':'PARAM-SETTINGS'}",
                menu_visible = "N",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 811,
                menu_module_id = 21,
                menu_order = 12,
                menu_code = "SALESMAN",
                menu_name = "Salesman",
                menu_route = "masters/paramList",
                menu_param = "{'type':'SALESMAN'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 812,
                menu_module_id = 21,
                menu_order = 13,
                menu_code = "SEA-PORT",
                menu_name = "Sea port",
                menu_route = "masters/paramList",
                menu_param = "{'type':'SEA-PORT'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            }
            );
        }


    }
}


