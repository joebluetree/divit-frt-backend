using Database.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database.fluent_config.Accounts
{
    public class acc_groupm_config : IEntityTypeConfiguration<acc_groupm>
    {
        public void Configure(EntityTypeBuilder<acc_groupm> modelBuilder)
        {/*
            //table and primary key
            modelBuilder.ToTable("acc_groupm");
            modelBuilder.HasKey(u => u.grp_id)
                .HasName("pk_acc_groupm_grp_id");
            //sequence
            modelBuilder.Property(u => u.grp_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //columns
            modelBuilder.Property(u => u.grp_name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.grp_main_group)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Property(e => e.grp_order)
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
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.grp_name })
                .HasDatabaseName("uq_acc_groupm_grp_name")
                .IsUnique();
            //Foreign Key
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_acc_groupm_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            insertdata(modelBuilder);
        }

        void insertdata(EntityTypeBuilder<acc_groupm> modelBuilder)
        {
            modelBuilder.HasData(
            new acc_groupm
            {
                grp_id = 1,
                grp_name = "CURRENT ASSETS",
                grp_order = 1,
                grp_main_group = "ASSET",
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
            },
            new acc_groupm
            {
                grp_id = 2,
                grp_name = "CURRENT LIABILITIES",
                grp_order = 1,
                grp_main_group = "LIABILITIES",
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
            },
            new acc_groupm
            {
                grp_id = 3,
                grp_name = "DIRECT INCOME",
                grp_order = 1,
                grp_main_group = "DIRECT INCOME",
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
            },
            new acc_groupm
            {
                grp_id = 4,
                grp_name = "DIRECT EXPENSE",
                grp_order = 1,
                grp_main_group = "DIRECT EXPENSE",
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
            }

            );*/
        }
    }

}


