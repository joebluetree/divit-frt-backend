using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.fluent_config.UserAdmin
{

    public class mast_settings_config : IEntityTypeConfiguration<mast_settings>
    {
        public void Configure(EntityTypeBuilder<mast_settings> modelBuilder)
        {

            //Table Name
            modelBuilder.ToTable("mast_settings");
            //Primary Key
            modelBuilder.HasKey(e => e.id)
                .HasName("pk_mast_settigs_id");
            //Sequence
            modelBuilder.Property(e => e.id)
                //.HasDefaultValueSql("next value for MasterSequence")
                .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //Columns
            modelBuilder.Property(e => e.caption)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Property(e => e.remarks)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(e => e.category)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Property(e => e.type)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Property(e => e.table)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(e => e.value)
                .HasMaxLength(1500)
                .IsRequired();
            modelBuilder.Property(e => e.code)
                .HasMaxLength(250)
                .IsRequired(false);
            modelBuilder.Property(e => e.name)
                .HasMaxLength(250)
                .IsRequired(false);
            modelBuilder.Property(e => e.param_id)
                .IsRequired(false);
            modelBuilder.Property(e => e.order)
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
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.rec_branch_id, e.param_id, e.caption })
                .HasDatabaseName("uq_mast_settings_rec_company_id_branch_id_param_id_caption")
                .HasFilter(null)
                .IsUnique();
            //Foreign Key
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(c => c.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_settings_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(c => c.rec_branch_id)
                .HasPrincipalKey(e => e.branch_id)
                .HasConstraintName("fk_mast_settings_rec_branch_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

        }

    }
}


