using Database.Models.TnT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.fluent_config.Tnt
{
    public class tnt_tracking_data_config : IEntityTypeConfiguration<tnt_tracking_data>
    {
        public void Configure(EntityTypeBuilder<tnt_tracking_data> modelBuilder)
        {
            //Table Name
            modelBuilder.ToTable("tnt_tracking_data");
            //Primary Key
            modelBuilder.HasKey(e => e.track_id)
                .HasName("pk_tnt_tracking_data_track_id");
            //Sequence
            modelBuilder.Property(u => u.track_id)
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();

            //Columns

            
            if (DbLib.DBMS == "PGS")
            {
                modelBuilder.Property(e => e.tnt_eventCreatedDateTime)
                    .HasColumnType("timestamp")
                    .IsRequired();
                modelBuilder.Property(e => e.tnt_eventCreatedDateTime_utc)
                    .HasColumnType("timestamptz")
                    .IsRequired();
                modelBuilder.Property(e => e.tnt_eventDateTime)
                    .HasColumnType("timestamp")
                    .IsRequired();
                modelBuilder.Property(e => e.tnt_eventDateTime_utc)
                    .HasColumnType("timestamptz")
                    .IsRequired();
            }
            

            modelBuilder.Property(e => e.tnt_container)
                .HasMaxLength(100)
                .IsRequired(false);

            modelBuilder.Property(e => e.tnt_transport_mode)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.tnt_event_type)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.tnt_event_confirm_status)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.tnt_status_code)
                    .HasMaxLength(100)
                    .IsRequired(false);
            modelBuilder.Property(e => e.tnt_status_name)
                    .HasMaxLength(100)
                    .IsRequired(false);
            modelBuilder.Property(e => e.tnt_port_code)
                    .HasMaxLength(100)
                    .IsRequired(false);
            modelBuilder.Property(e => e.tnt_port_name)
                    .HasMaxLength(100)
                    .IsRequired(false);
            modelBuilder.Property(e => e.tnt_port_location)
                    .HasMaxLength(100)
                    .IsRequired(false);
            modelBuilder.Property(e => e.tnt_vessel)
                    .HasMaxLength(100)
                    .IsRequired(false);
            modelBuilder.Property(e => e.tnt_vessel_imon)
                    .HasMaxLength(100)
                    .IsRequired(false);
            modelBuilder.Property(e => e.tnt_voyage)
                    .HasMaxLength(100)
                    .IsRequired(false);
            modelBuilder.Property(e => e.tnt_row_type)
                    .HasMaxLength(30)
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
            //Foreign Key
            modelBuilder
                .HasOne(e => e.trackm)
                .WithMany( e => e.tracking_data)
                .HasForeignKey(e => e.tnt_trackm_id)
                .HasPrincipalKey(e => e.track_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.trackd)
                .WithMany( e => e.tracking_data )
                .HasForeignKey(e => e.tnt_trackd_id)
                .HasPrincipalKey(e => e.trackd_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_tracking_data_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            //unique key
        }

    }
}


