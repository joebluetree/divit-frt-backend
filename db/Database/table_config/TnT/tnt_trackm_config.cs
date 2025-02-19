using Database.Models.TnT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.table_config.Tnt
{
    public class tnt_trackm_config : IEntityTypeConfiguration<tnt_trackm>
    {
        public void Configure(EntityTypeBuilder<tnt_trackm> modelBuilder)
        {/*
            //Table Name
            modelBuilder.ToTable("tnt_trackm");
            //Primary Key
            modelBuilder.HasKey(e => e.track_id);
                // .HasName("pk_tnt_trackm_track_id");
            //Sequence
            modelBuilder.Property(u => u.track_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                // .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //Columns
            /*
            modelBuilder.Property(e => e.track_book_no)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.track_cntr_no)
                .HasMaxLength(11)
                .IsRequired();
            //track_last_updated_on
            if (DbLib.DBMS == "PGS")
            {
                modelBuilder.Property(e => e.track_last_updated_on)
                    .HasColumnType("timestamp");
            }

            modelBuilder.Property(e => e.track_api_type)
                .HasMaxLength(30)
                .IsRequired();
            modelBuilder.Property(e => e.track_request_id)
                .HasMaxLength(60)
                .IsRequired(false);
            modelBuilder.Property(e => e.track_pol_code)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.track_pol_name)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.track_pod_code)
                .HasMaxLength(100)
                .IsRequired(false);

            modelBuilder.Property(e => e.track_pod_name)
                .HasMaxLength(100)
                .IsRequired(false);

            modelBuilder.Property(e => e.track_pod_code)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.track_vessel_code)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.track_vessel_name)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(e => e.track_voyage)
                .HasMaxLength(100)
                .IsRequired(false);
            if (DbLib.DBMS == "PGS")
            {
                modelBuilder.Property(e => e.track_pol_etd)
                    .HasColumnType("date")
                    .IsRequired(false);
                modelBuilder.Property(e => e.track_pod_eta)
                    .HasColumnType("date")
                    .IsRequired(false);
            }
            else
            {
                modelBuilder.Property(e => e.track_pol_etd)
                    .IsRequired(false);
                modelBuilder.Property(e => e.track_pod_eta)
                    .IsRequired(false);
            }
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
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(c => c.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_tnt_trackm_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.param_carrier)
                .WithMany()
                .HasForeignKey(c => c.track_carrier_id)
                .HasPrincipalKey(e => e.param_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
                */
            //unique key
            // insertdata(modelBuilder);

        }

        void insertdata(EntityTypeBuilder<tnt_trackm> modelBuilder)
        {
            modelBuilder.HasData(
            new tnt_trackm
            {
                track_id = 100,
                track_book_no = "",
                track_cntr_no = "HLXU8787996",
                track_carrier_id = 5,
                track_api_type = "API",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "admin"

            }, new tnt_trackm
            {
                track_id = 101,
                track_book_no = "",
                track_cntr_no = "CMAU7228147",
                track_carrier_id = 4,
                track_api_type = "API",
                rec_company_id = 1,
                rec_created_by = "admin"
            }, new tnt_trackm
            {
                track_id = 102,
                track_book_no = "",
                track_cntr_no = "MAEU3417227",
                track_carrier_id = 6,
                track_api_type = "API",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "admin"

            }, new tnt_trackm
            {
                track_id = 103,
                track_book_no = "",
                track_cntr_no = "MAGU5540135",
                track_carrier_id = 10,
                track_api_type = "API-1",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "admin"
            }, new tnt_trackm
            {
                track_id = 104,
                track_book_no = "",
                track_cntr_no = "BEAU6030782",
                track_carrier_id = 13,
                track_api_type = "SHIPSGO",
                track_request_id = "4179934",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "admin"
            }, new tnt_trackm
            {
                track_id = 105,
                track_book_no = "",
                track_cntr_no = "SEGU9471335",
                track_carrier_id = 7,
                track_api_type = "SHIPSGO",
                track_request_id = "4182169",
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "admin"
            }

            );
        }

    }
}


