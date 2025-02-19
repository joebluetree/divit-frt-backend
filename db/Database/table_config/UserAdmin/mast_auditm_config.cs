using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.table_config.UserAdmin
{
    public class mast_auditm_config : IEntityTypeConfiguration<mast_auditm>
    {
        public void Configure(EntityTypeBuilder<mast_auditm> modelBuilder)
        {/*
            //Table
            modelBuilder.ToTable("mast_logm");
            modelBuilder.HasKey(e => e.log_id);
                // .HasName("pk_mast_logm_log_id");

            //Sequence
            modelBuilder.Property(u => u.log_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                // .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            //Columns
            /*
            modelBuilder.Property(u => u.log_date)
                .IsRequired();

            modelBuilder.Property(u => u.log_table)
                .HasMaxLength(60)
                .IsRequired();
            modelBuilder.Property(u => u.log_table_id)
                .IsRequired();
            modelBuilder.Property(u => u.log_user_code)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Property(u => u.log_column)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.log_desc)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.log_refno)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.log_value)
                .HasMaxLength(500)
                .IsRequired();

            //index
            modelBuilder.HasIndex(e => new { e.log_id })
                .HasDatabaseName("uq_mast_logm_log_id")
                .IsUnique(false);
                */
        }

    }

}


