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
            insertdata_Marketing(modelBuilder);
            insertdata_Settings(modelBuilder);
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
                menu_order = 12,
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
                menu_order = 13,
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
                menu_order = 14,
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
                menu_order = 15,
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
                menu_order = 16,
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
                menu_order = 17,
                menu_code = "SEA-PORT",
                menu_name = "Sea port",
                menu_route = "masters/paramList",
                menu_param = "{'type':'SEA-PORT'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },

            new mast_menum       //AIR-PORT Added to master
            {
                menu_id = 813,
                menu_module_id = 21,
                menu_order = 18,
                menu_code = "AIR-PORT",
                menu_name = "Air port",
                menu_route = "masters/paramList",
                menu_param = "{'type':'AIR-PORT'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum       //CUSTOMER-GROUP Added to master
            {
                menu_id = 814,
                menu_module_id = 21,
                menu_order = 19,
                menu_code = "CUSTOMER-GROUP",
                menu_name = "Customer Group",
                menu_route = "masters/paramList",
                menu_param = "{'type':'CUSTOMER-GROUP'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum       //INVOICE-DESCRIPTION Added to master
            {
                menu_id = 815,
                menu_module_id = 21,
                menu_order = 20,
                menu_code = "INVOICE-DESCRIPTION",
                menu_name = "Invoice Description",
                menu_route = "masters/paramList",
                menu_param = "{'type':'INVOICE-DESCRIPTION'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum       //CHQ-FORMAT Added to master
            {
                menu_id = 816,
                menu_module_id = 21,
                menu_order = 21,
                menu_code = "CHQ-FORMAT",
                menu_name = "Check Format",
                menu_route = "masters/paramList",
                menu_param = "{'type':'CHQ-FORMAT'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //Currency Added to Master Module
            {
                menu_id = 817,
                menu_module_id = 21,
                menu_order = 22,
                menu_code = "CURRENCY",
                menu_name = "Currency Master",
                menu_route = "masters/paramList",
                menu_param = "{'type':'CURRENCY'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //Freight Status Added to Master Module
            {
                menu_id = 818,
                menu_module_id = 21,
                menu_order = 23,
                menu_code = "FREIGHT-STATUS",
                menu_name = "Freight Status",
                menu_route = "masters/paramList",
                menu_param = "{'type':'FREIGHT-STATUS'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //Nomination Status Added to Master Module
            {
                menu_id = 819,
                menu_module_id = 21,
                menu_order = 24,
                menu_code = "NOMINATION",
                menu_name = "Nomination Status",
                menu_route = "masters/paramList",
                menu_param = "{'type':'NOMINATION'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //CONTAINER TYPE Added to Master Module
            {
                menu_id = 820,
                menu_module_id = 21,
                menu_order = 25,
                menu_code = "CONTAINER-TYPE",
                menu_name = "Container Type",
                menu_route = "masters/paramList",
                menu_param = "{'type':'CONTAINER-TYPE'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //CARGO MOVEMENT Added to Master Module
            {
                menu_id = 821,
                menu_module_id = 21,
                menu_order = 26,
                menu_code = "CARGO-MOVEMENT",
                menu_name = "Cargo Movement",
                menu_route = "masters/paramList",
                menu_param = "{'type':'CARGO-MOVEMENT'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //CONTACT-GROUP Added to Master Module
            {
                menu_id = 822,
                menu_module_id = 21,
                menu_order = 27,
                menu_code = "CONTACT-GROUP",
                menu_name = "Contact Group",
                menu_route = "masters/paramList",
                menu_param = "{'type':'CONTACT-GROUP'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //HAWB-FORMAT Added to Master Module
            {
                menu_id = 823,
                menu_module_id = 21,
                menu_order = 28,
                menu_code = "HAWB-FORMAT",
                menu_name = "HAWB Format",
                menu_route = "masters/paramList",
                menu_param = "{'type':'HAWB-FORMAT'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //HBL-FORMAT Added to Master Module
            {
                menu_id = 824,
                menu_module_id = 21,
                menu_order = 29,
                menu_code = "HBL-FORMAT",
                menu_name = "HBL Format",
                menu_route = "masters/paramList",
                menu_param = "{'type':'HBL-FORMAT'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //COO-FORMAT Added to Master Module
            {
                menu_id = 825,
                menu_module_id = 21,
                menu_order = 30,
                menu_code = "COO-FORMAT",
                menu_name = "COO Format",
                menu_route = "masters/paramList",
                menu_param = "{'type':'COO-FORMAT'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //CNTR-MOVE-STATUS Added to Master Module
            {
                menu_id = 826,
                menu_module_id = 21,
                menu_order = 31,
                menu_code = "CNTR-MOVE-STATUS",
                menu_name = "Container Tracking Events",
                menu_route = "masters/paramList",
                menu_param = "{'type':'CNTR-MOVE-STATUS'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //SHIP-MOVE-STATUS Added to Master Module
            {
                menu_id = 827,
                menu_module_id = 21,
                menu_order = 32,
                menu_code = "SHIP-MOVE-STATUS",
                menu_name = "Ocean Shipment Tracking Events",
                menu_route = "masters/paramList",
                menu_param = "{'type':'SHIP-MOVE-STATUS'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //AIR-SHIP-MOVE-STATUS Added to Master Module
            {
                menu_id = 828,
                menu_module_id = 21,
                menu_order = 33,
                menu_code = "AIR-MOVE-STATUS",
                menu_name = "Air Shipment Tracking Events",
                menu_route = "masters/paramList",
                menu_param = "{'type':'AIR-MOVE-STATUS'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //BUDGET-TYPE Added to Master Module
            {
                menu_id = 829,
                menu_module_id = 21,
                menu_order = 34,
                menu_code = "BUDGET-TYPE",
                menu_name = "Budget Category",
                menu_route = "masters/paramList",
                menu_param = "{'type':'BUDGET-TYPE'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //FORM-CATEGORY Added to Master Module
            {
                menu_id = 830,
                menu_module_id = 21,
                menu_order = 35,
                menu_code = "FORM-CATEGORY",
                menu_name = "Form Category",
                menu_route = "masters/paramList",
                menu_param = "{'type':'FORM-CATEGORY'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //UNIT-MASTER Added to Master Module
            {
                menu_id = 831,
                menu_module_id = 21,
                menu_order = 36,
                menu_code = "UNIT-MASTER",
                menu_name = "Unit Master",
                menu_route = "masters/paramList",
                menu_param = "{'type':'UNIT-MASTER'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //Wire Transfer Added to Master Module
            {
                menu_id = 832,
                menu_module_id = 21,
                menu_order = 37,
                menu_code = "WIRETRANSM",
                menu_name = "Wire Transfer Instruction",
                menu_route = "masters/wiretransmList",
                menu_param = "{'type':'WIRETRANSM'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum     //Wire Transfer Added to Master Module
            {
                menu_id = 833,
                menu_module_id = 21,
                menu_order = 38,
                menu_code = "REMARKS",
                menu_name = "Remarks",
                menu_route = "masters/remarkList",
                menu_param = "{'type':'REMARKS'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            }
            );
        }
        void insertdata_Marketing(EntityTypeBuilder<mast_menum> modelBuilder)
        {
            modelBuilder.HasData(
            new mast_menum
            {
                menu_id = 901,
                menu_module_id = 23,
                menu_order = 1,
                menu_code = "QUOTATIONS-LCL",
                menu_name = "Quotations Lcl & Local",
                menu_route = "marketing/qtnmlclList",
                menu_param = "{'type':'QUOTATIONS-LCL'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 902,
                menu_module_id = 23,
                menu_order = 2,
                menu_code = "QUOTATIONS-FCL",
                menu_name = "Quotations Fcl",
                menu_route = "marketing/qtnmfclList",
                menu_param = "{'type':'QUOTATIONS-FCL'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_menum
            {
                menu_id = 903,
                menu_module_id = 23,
                menu_order = 3,
                menu_code = "QUOTATIONS-AIR",
                menu_name = "Quotations Air",
                menu_route = "marketing/qtnmairList",
                menu_param = "{'type':'QUOTATIONS-AIR'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            }
            );
        }

        void insertdata_Settings(EntityTypeBuilder<mast_menum> modelBuilder)
        {
            modelBuilder.HasData(
            new mast_menum
            {
                menu_id = 1001,
                menu_module_id = 24,
                menu_order = 1,
                menu_code = "MAIL-SERVER",
                menu_name = "Mail Server Settings",
                menu_route = "admin/mailservermList",
                menu_param = "{'type':'MAIL-SERVER'}",
                menu_visible = "Y",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            }
            );
        }

    }
}


