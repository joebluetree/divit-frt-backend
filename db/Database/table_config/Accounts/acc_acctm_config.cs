using Database.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database.table_config.Accounts
{
    public class acc_acctm_config : IEntityTypeConfiguration<acc_acctm>
    { 
        public void Configure(EntityTypeBuilder<acc_acctm> modelBuilder)
        {
            //table and primary key
            modelBuilder.ToTable("acc_acctm");
            modelBuilder.HasKey(u => u.acc_id)
                .HasName("pk_acc_acctm_acc_id");
            //Sequence
            modelBuilder.Property(u => u.acc_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //columns
            modelBuilder.Property(u => u.acc_code)
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Property(u => u.acc_short_name)
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Property(u => u.acc_name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.acc_type)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.acc_row_type)
                .HasMaxLength(10)
                .IsRequired();
            modelBuilder.Property(e => e.acc_maincode_id)
                .IsRequired(false);
            modelBuilder.Property(e => e.acc_grp_id)
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
            modelBuilder.HasIndex(e => new { e.rec_company_id,e.acc_row_type, e.acc_code })
                .HasDatabaseName("uq_acc_acctm_acc_code")
                .IsUnique();
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.acc_row_type, e.acc_short_name })
                .HasDatabaseName("uq_acc_acctm_acc_short_name")
                .IsUnique();
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.acc_row_type, e.acc_name })
                .HasDatabaseName("uq_acc_acctm_acc_name")
                .IsUnique();
            //Foreign Key
            modelBuilder
                .HasOne(e => e.acctm)
                .WithMany()
                .HasForeignKey(e => e.acc_maincode_id)
                .HasPrincipalKey(e => e.acc_id)
                .HasConstraintName("fk_mast_acctm_acc_maincode_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
            modelBuilder
                .HasOne(e => e.acc_groupm)
                .WithMany()
                .HasForeignKey(e => e.acc_grp_id)
                .HasPrincipalKey(e => e.grp_id)
                .HasConstraintName("fk_mast_acctm_acc_grp_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_acctm_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            //insertdata(modelBuilder);
        }

        void insertdata(EntityTypeBuilder<acc_acctm> modelBuilder)
        {
            modelBuilder.HasData(
            new acc_acctm
            {
                acc_id = 1,
                acc_code = "OI",
                acc_short_name = "OI",
                acc_name = "OCEAN IMPORT",
                acc_type = "NA",
                acc_row_type = "MAIN-CODE",
                acc_maincode_id = null,
                acc_grp_id = 1,
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            },
            new acc_acctm
            {
                acc_id = 2,
                acc_code = "OE",
                acc_short_name = "OE",
                acc_name = "OCEAN EXPORT",
                acc_type = "NA",
                acc_row_type = "MAIN-CODE",
                acc_maincode_id = null,
                acc_grp_id = 1,
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            },
            new acc_acctm
            {
                acc_id = 3,
                acc_code = "AR",
                acc_short_name = "AR",
                acc_name = "AR",
                acc_type = "AR",
                acc_row_type = "MAIN-CODE",
                acc_maincode_id = null,
                acc_grp_id = 1,
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            },
            new acc_acctm
            {
                acc_id = 4,
                acc_code = "AP",
                acc_short_name = "AP",
                acc_name = "AP",
                acc_type = "AP",
                acc_row_type = "MAIN-CODE",
                acc_maincode_id = null,
                acc_grp_id = 2,
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            },
            new acc_acctm
            {
                acc_id = 5,
                acc_code = "OE",
                acc_short_name = "OE",
                acc_name = "OCEAN EXPORT",
                acc_type = "NA",
                acc_row_type = "ACC-CODE",
                acc_maincode_id = 2,
                acc_grp_id = 2,
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }

            );
        }
    }

}


