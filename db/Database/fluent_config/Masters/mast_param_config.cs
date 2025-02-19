using Database.Models.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.fluent_config.Masters
{
    public class mast_param_config : IEntityTypeConfiguration<mast_param>
    {
        public void Configure(EntityTypeBuilder<mast_param> modelBuilder)
        {/*
            //Table
            modelBuilder.ToTable("mast_param");
            //Primary Key
            modelBuilder.HasKey(e => e.param_id)
                .HasName("pk_mast_param_param_id");
            //Sequence
            modelBuilder.Property(u => u.param_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //Columns
            modelBuilder.Property(e => e.param_type)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(e => e.param_code)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Property(e => e.param_name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(e => e.param_value1)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.param_value2)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.param_value3)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.param_value4)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.param_value5)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.param_order)
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
            //unique
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.param_type, e.param_code })
                .HasDatabaseName("uq_mast_param_param_code")
                .IsUnique();
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.param_type, e.param_name })
                .HasDatabaseName("uq_mast_param_param_name")
                .IsUnique();

            //Foreign Key
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_param_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(e => e.rec_branch_id)
                .HasPrincipalKey(e => e.branch_id)
                .HasConstraintName("fk_mast_param_rec_branch_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
                
            insertDataCountry(modelBuilder);
            insertDataState(modelBuilder);
            insertDataSeaCarrier(modelBuilder);
            insertDataAirPort(modelBuilder);
            insertDataCustomerGrp(modelBuilder);
            insertDataInvoiceDesc(modelBuilder);
            insertDataCheckFormat(modelBuilder);
            insertDataCurrency(modelBuilder);
            insertDataFreightStatus(modelBuilder);
            insertDataNominationStatus(modelBuilder);
            insertDataContainerType(modelBuilder);
            insertDataCargoMovement(modelBuilder);
            insertDataContactGrp(modelBuilder);
            insertDataHawbFormat(modelBuilder);
            insertDataHblFormat(modelBuilder);
            insertDataCooFormat(modelBuilder);
            insertDataContainerTracking(modelBuilder);
            insertDataOceanShipMove(modelBuilder);
            insertDataAirShipMovement(modelBuilder);
            insertDataBudgetType(modelBuilder);
            insertDataFormCategory(modelBuilder);
            insertDataUnitMaster(modelBuilder);
        }

        void insertDataCountry(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 1,
                param_type = "COUNTRY",
                param_code = "IN",
                param_name = "INDIA",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 2,
                param_type = "COUNTRY",
                param_code = "US",
                param_name = "USA",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }
        void insertDataState(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 3,
                param_type = "STATE",
                param_code = "KL",
                param_name = "KERALA",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataSeaCarrier(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 4,
                param_type = "SEA CARRIER",
                param_code = "CMA",
                param_name = "CMA CHM",
                param_value1 = "CMDU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 5,
                param_type = "SEA CARRIER",
                param_code = "HLCU",
                param_name = "HAPAQ LLOYD",
                param_value1 = "HLCU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 6,
                param_type = "SEA CARRIER",
                param_code = "MAEU",
                param_name = "MAERSK",
                param_value1 = "MAEU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 3,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 7,
                param_type = "SEA CARRIER",
                param_code = "MSCU",
                param_name = "MSC",
                param_value1 = "MSCU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 4,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 8,
                param_type = "SEA CARRIER",
                param_code = "EGLV",
                param_name = "EVERGREEN",
                param_value1 = "EGLV",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 5,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 9,
                param_type = "SEA CARRIER",
                param_code = "HDMU",
                param_name = "HMM",
                param_value1 = "HDMU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 6,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 10,
                param_type = "SEA CARRIER",
                param_code = "YMLU",
                param_name = "YANG MING",
                param_value1 = "YMLU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 7,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 11,
                param_type = "SEA CARRIER",
                param_code = "ONEY",
                param_name = "OCEAN NETWORK EXPRESS",
                param_value1 = "ONEY",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 8,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 12,
                param_type = "SEA CARRIER",
                param_code = "OOCL",
                param_name = "OOCL",
                param_value1 = "OOLU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 9,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 13,
                param_type = "SEA CARRIER",
                param_code = "COSCO",
                param_name = "COSCO",
                param_value1 = "COSU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 10,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 14,
                param_type = "SEA CARRIER",
                param_code = "ANL",
                param_name = "ANL",
                param_value1 = "ANNU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 11,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 15,
                param_type = "SEA CARRIER",
                param_code = "APL",
                param_name = "APL",
                param_value1 = "ANNU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 12,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 16,
                param_type = "SEA CARRIER",
                param_code = "EMIRATES",
                param_name = "EMIRATES",
                param_value1 = "ESPU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 13,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 17,
                param_type = "SEA CARRIER",
                param_code = "HANJIN",
                param_name = "HANJIN",
                param_value1 = "HJSC",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 14,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 18,
                param_type = "SEA CARRIER",
                param_code = "KLINE",
                param_name = "KLINE",
                param_value1 = "KKLU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 15,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1

            }, new mast_param
            {
                param_id = 19,
                param_type = "SEA CARRIER",
                param_code = "MOL",
                param_name = "MOL",
                param_value1 = "MOLU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 16,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 20,
                param_type = "SEA CARRIER",
                param_code = "NYK",
                param_name = "NYK LINE",
                param_value1 = "NYKS",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 17,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 21,
                param_type = "SEA CARRIER",
                param_code = "OSTI",
                param_name = "ORIENT STAR",
                param_value1 = "OSTI",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 18,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 22,
                param_type = "SEA CARRIER",
                param_code = "PAN ASIA",
                param_name = "PAN ASIA",
                param_value1 = "PALU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 19,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 23,
                param_type = "SEA CARRIER",
                param_code = "PIL",
                param_name = "PIL",
                param_value1 = "PCIU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 20,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 24,
                param_type = "SEA CARRIER",
                param_code = "PMO",
                param_name = "PMO",
                param_value1 = "PMOL",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 21,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 25,
                param_type = "SEA CARRIER",
                param_code = "ZIM",
                param_name = "ZIM",
                param_value1 = "ZIMU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 22,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }
            );
        }
        void insertDataCurrency(EntityTypeBuilder<mast_param> modelBuilder)    //CURRENCY ADDED TO THE PARAMLIST
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 26,
                param_type = "CURRENCY",
                param_code = "INR",
                param_name = "INDIAN RUPEE",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 27,
                param_type = "CURRENCY",
                param_code = "USD",
                param_name = "US DOLLAR",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataAirPort(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 28,
                param_type = "AIR-PORT",
                param_code = "CMA",
                param_name = "CMA CHM",
                param_value1 = "CMDU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 29,
                param_type = "AIR-PORT",
                param_code = "ZIM",
                param_name = "ZIM",
                param_value1 = "ZIMU",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataCustomerGrp(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 30,
                param_type = "CUSTOMER-GROUP",
                param_code = "101",
                param_name = "LOCAL CREDITORS",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 31,
                param_type = "CUSTOMER-GROUP",
                param_code = "102",
                param_name = "LOCAL DEBTORS",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataInvoiceDesc(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 32,
                param_type = "INVOICE-DESCRIPTION",
                param_code = "101",
                param_name = "ACCOUNTANT SERVICE FEE",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 33,
                param_type = "INVOICE-DESCRIPTION",
                param_code = "102",
                param_name = "ADMIN FEE",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataCheckFormat(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 34,
                param_type = "CHQ-FORMAT",
                param_code = "ASTORIA",
                param_name = "ASTORIA",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataFreightStatus(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 35,
                param_type = "FREIGHT-STATUS",
                param_code = "COLLECT",
                param_name = "COLLECT",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 36,
                param_type = "FREIGHT-STATUS",
                param_code = "PREPAID",
                param_name = "PREPAID",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataNominationStatus(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 37,
                param_type = "NOMINATION",
                param_code = "FREEHAND",
                param_name = "FREEHAND",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 38,
                param_type = "NOMINATION",
                param_code = "MUTUAL",
                param_name = "MUTUAL",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataContainerType(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 39,
                param_type = "CONTAINER-TYPE",
                param_code = "20FR",
                param_name = "20' FR",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 40,
                param_type = "CONTAINER-TYPE",
                param_code = "40FR",
                param_name = "40' FR",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }
        void insertDataCargoMovement(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 41,
                param_type = "CARGO-MOVEMENT",
                param_code = "CFS/CFS",
                param_name = "CFS/CFS",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 42,
                param_type = "CARGO-MOVEMENT",
                param_code = "DOOR/DOOR",
                param_name = "DOOR/DOOR",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }
        void insertDataContactGrp(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 43,
                param_type = "CONTACT-GROUP",
                param_code = "FOR REMITTANCE",
                param_name = "FOR REMITTANCE",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 44,
                param_type = "CONTACT-GROUP",
                param_code = "NA",
                param_name = "NA",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataHawbFormat(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 45,
                param_type = "HAWB-FORMAT",
                param_code = "DEFAULT",
                param_name = "DEFAULT FORMAT",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataHblFormat(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 46,
                param_type = "HBL-FORMAT",
                param_code = "MOTHERLINES",
                param_name = "MOTHERLINES BLANK",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 47,
                param_type = "HBL-FORMAT",
                param_code = "MLINES-DRAFT",
                param_name = "MOTHERLINES DRAFT",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataCooFormat(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 48,
                param_type = "COO-FORMAT",
                param_code = "DEFAULT",
                param_name = "DEFAULT FORMAT",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataContainerTracking(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 49,
                param_type = "CNTR-MOVE-STATUS",
                param_code = "101",
                param_name = "CONTAINER LOADED ON BOARD",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 50,
                param_type = "CNTR-MOVE-STATUS",
                param_code = "102",
                param_name = "CONTAINER TRANSSHIPPED",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataOceanShipMove(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 51,
                param_type = "SHIP-MOVE-STATUS",
                param_code = "101",
                param_name = "CONTAINER IS DEVANNING",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 52,
                param_type = "SHIP-MOVE-STATUS",
                param_code = "102",
                param_name = "SHIPMENT ON TRANSIT",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataBudgetType(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 54,
                param_type = "BUDGET-TYPE",
                param_code = "EMPLOYEE",
                param_name = "EMPLOYEE",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 55,
                param_type = "BUDGET-TYPE",
                param_code = "MARKETING",
                param_name = "MARKETING",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataFormCategory(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 56,
                param_type = "FORM-CATEGORY",
                param_code = "ACCOUNTING FORM",
                param_name = "ACCOUNTING FORM",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_param
            {
                param_id = 57,
                param_type = "FORM-CATEGORY",
                param_code = "APPLICATION",
                param_name = "APPLICATION",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }

        void insertDataUnitMaster(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 58,
                param_type = "UNIT-MASTER",
                param_code = "101",
                param_name = "UNIT MASTER 1",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        }
        void insertDataAirShipMovement(EntityTypeBuilder<mast_param> modelBuilder)
        {
            modelBuilder.HasData(new mast_param
            {
                param_id = 59,
                param_type = "AIR-MOVE-STATUS",
                param_code = "101",
                param_name = "SHIPMENT ARRIVED",
                param_value1 = "",
                param_value2 = "",
                param_value3 = "",
                param_value4 = "",
                param_value5 = "",
                param_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            });
        */}
    }
}


