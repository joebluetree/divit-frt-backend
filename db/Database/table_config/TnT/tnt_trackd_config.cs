using Database.Models.TnT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.table_config.Tnt
{
    public class tnt_trackd_config : IEntityTypeConfiguration<tnt_trackd>
    {
        public void Configure(EntityTypeBuilder<tnt_trackd> modelBuilder)
        {
            //Table Name
            modelBuilder.ToTable("tnt_trackd");
            //Primary Key
            modelBuilder.HasKey(e => e.trackd_id)
                .HasName("pk_tnt_trackd_trackd_id");
            //Sequence
            modelBuilder.Property(u => u.trackd_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();

            //trackd_last_updated_on
            if (DbLib.DBMS == "PGS")
            {
                modelBuilder.Property(e => e.trackd_last_updated_on)
                    .HasColumnType("timestamp");
            }

            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //Columns
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
            //Foreign Key
            modelBuilder
                .HasOne(e => e.trackm)
                .WithMany(e => e.trackd)
                .HasForeignKey(c => c.trackd_trackm_id)
                .HasPrincipalKey(e => e.track_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(c => c.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_trackd_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //unique key
        }


    }
}


