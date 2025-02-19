using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.fluent_config.UserAdmin
{
    public class mast_userbranches_config : IEntityTypeConfiguration<mast_userbranches>
    {
        public void Configure(EntityTypeBuilder<mast_userbranches> modelBuilder)
        {/*
            //Table
            modelBuilder.ToTable("mast_userbranches");
            //Parimary Key
            modelBuilder.HasKey(e => e.ub_id)
                .HasName("pk_mast_userbranches_ub_id");
            //Sequence
            modelBuilder.Property(u => u.ub_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //Columns
            modelBuilder.Property(u => u.ub_user_id)
                .IsRequired();
            modelBuilder.Property(u => u.rec_company_id)
                .IsRequired();
            modelBuilder.Property(u => u.rec_branch_id)
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
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.ub_user_id, e.rec_branch_id })
                .HasDatabaseName("uq_mast_userbranches_branch")
                .IsUnique();
            //Foreign Key
            modelBuilder
                .HasOne(e => e.user)
                .WithMany(e => e.userbranches)
                .HasForeignKey(e => e.ub_user_id)
                .HasPrincipalKey( e => e.user_id)
                .HasConstraintName("fk_mast_userbranches_ub_user_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_userbranches_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(e => e.rec_branch_id)
                .HasPrincipalKey( e => e.branch_id)
                .HasConstraintName("fk_mast_branchm_rec_branch_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            insertdata(modelBuilder);
        }
        public void insertdata(EntityTypeBuilder<mast_userbranches> modelBuilder)
        {
            modelBuilder.HasData(new mast_userbranches
            {
                ub_id = 1,
                ub_user_id = 2,
                rec_branch_id = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
            },
            new mast_userbranches
            {
                ub_id = 2,
                ub_user_id = 2,
                rec_branch_id = 2,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
            }
            );
            */
        }
    }

}


