using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.table_config.UserAdmin
{
    public class mast_rightsm_config : IEntityTypeConfiguration<mast_rightsm>
    {
        public void Configure(EntityTypeBuilder<mast_rightsm> modelBuilder)
        {/*
            //Table
            modelBuilder.ToTable("mast_rightsm");
            modelBuilder.HasKey(e => e.rights_id);
                // .HasName("pk_mast_rightsm_rights_id");
            //Sequence
            modelBuilder.Property(u => u.rights_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                // .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            //Columns
            /*
            modelBuilder.Property(u => u.rights_company)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(u => u.rights_admin)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(u => u.rights_add)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(u => u.rights_edit)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(u => u.rights_view)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(u => u.rights_delete)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(u => u.rights_company)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(u => u.rights_print)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(u => u.rights_doc_upload)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(u => u.rights_doc_view)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(u => u.rights_approver)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(u => u.rights_value)
                .HasMaxLength(250)
                .IsRequired(false);
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
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.rec_branch_id, e.rights_user_id, e.rights_menu_id })
                .HasDatabaseName("uq_mast_rightsm_menu_id")
                .IsUnique();
            //Foreign Key
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_rightsm_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(e => e.rec_branch_id)
                .HasPrincipalKey(e => e.branch_id)
                .HasConstraintName("fk_mast_branchm_rec_branch_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.userbranches)
                .WithMany()
                .HasForeignKey(e => e.rights_parent_id)
                .HasPrincipalKey(e => e.ub_id)
                .HasConstraintName("fk_mast_rightsm_rights_parent_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.user)
                .WithMany()
                .HasForeignKey(e => e.rights_user_id)
                .HasPrincipalKey(e => e.user_id)
                .HasConstraintName("fk_mast_rightsm_rights_user_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.menu)
                .WithMany()
                .HasForeignKey(e => e.rights_menu_id)
                .HasPrincipalKey( e => e.menu_id)
                .HasConstraintName("fk_mast_rightsm_rights_menu_id")
                .HasPrincipalKey(e => e.menu_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
                */
        }
    }

}


