using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Database.table_config.UserAdmin
{
    public class mast_branchm_config : IEntityTypeConfiguration<mast_branchm>
    {
        public void Configure(EntityTypeBuilder<mast_branchm> modelBuilder)
        {/*
            //table and primary key
            modelBuilder.ToTable("mast_branchm");
            modelBuilder.HasKey(u => u.branch_id);
                // .HasName("pk_mast_branchm_branch_id");
            //Sequence
            modelBuilder.Property(u => u.branch_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                // .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //columns
            /*
            modelBuilder.Property(u => u.branch_code)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Property(u => u.branch_name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.branch_address1)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.branch_address2)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.branch_address3)
                .HasMaxLength(100)
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
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.branch_code })
                .HasDatabaseName("uq_mast_branchm_branch_code")
                .IsUnique();
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.branch_name })
                .HasDatabaseName("uq_mast_branchm_branch_name")
                .IsUnique();

            modelBuilder
                .HasOne(b => b.company)
                .WithMany(c => c.branches)
                .HasForeignKey(b => b.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_branchm_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
                
            // insertdata(modelBuilder);

        }

        void insertdata(EntityTypeBuilder<mast_branchm> modelBuilder)
        {
            modelBuilder.HasData(new mast_branchm
            {
                branch_id = 1,
                branch_code = "BRANCH1",
                branch_name = "BRANCH1",
                branch_address1 = "ADDRESS LINE 1",
                branch_address2 = "ADDRESS LINE 2",
                branch_address3 = "ADDRESS LINE3 3",
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
            },
            new mast_branchm
            {
                branch_id = 2,
                branch_code = "BRANCH2",
                branch_name = "BRANCH2",
                branch_address1 = "ADDRESS LINE 1",
                branch_address2 = "ADDRESS LINE 2",
                branch_address3 = "ADDRESS LINE3 3",
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
            },
            new mast_branchm
            {
                branch_id = 3,
                branch_code = "BRANCH3",
                branch_name = "BRANCH3",
                branch_address1 = "ADDRESS LINE 1",
                branch_address2 = "ADDRESS LINE 2",
                branch_address3 = "ADDRESS LINE3 3",
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
            }
            );
            */
        }
    }

}


