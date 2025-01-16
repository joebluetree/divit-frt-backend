using System.Runtime.InteropServices;
using Database.Models.Accounts;
using Database.Models.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//Name : Sourav V
//Created Date : 10/01/2025
//Remark : this file defines schema,relationship, constraint and initial seed data of mark_qtnm

namespace Database.fluent_config.Marketing
{
    public class mark_qtnd_air_config : IEntityTypeConfiguration<mark_qtnd_air>
    { 
        public void Configure(EntityTypeBuilder<mark_qtnd_air> modelBuilder)
        {
            //table and primary key
            modelBuilder.ToTable("mark_qtnd_air");
            modelBuilder.HasKey(u => u.qtnd_id)
                .HasName("pk_mark_qtnd_air_qtnd_id");
            //Sequence
            modelBuilder.Property(u => u.qtnd_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //columns
            modelBuilder.Property(u => u.qtnd_pol_name)
                .HasMaxLength(50)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_pod_name)
                .HasMaxLength(50)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_carrier_name)
                .HasMaxLength(50)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_trans_time)
                .HasMaxLength(30)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_routing)
                .HasMaxLength(30)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_etd)
                .HasMaxLength(50)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_min)
                .HasMaxLength(50)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_45k)
                .HasMaxLength(20)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_100k)
                .HasMaxLength(20)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_300k)
                .HasMaxLength(20)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_500k)
                .HasMaxLength(20)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_1000k)
                .HasMaxLength(20)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_fsc)
                .HasMaxLength(20)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_war)
                .HasMaxLength(20)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_sfc)
                .HasMaxLength(20)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_hac)
                .HasMaxLength(20)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_order)
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
            // unique 
            // Foreign Key
            modelBuilder
                .HasOne(e => e.qtnm)
                .WithMany()
                .HasForeignKey(e => e.qtnd_qtnm_id)
                .HasPrincipalKey(e => e.qtnm_id)
                .HasConstraintName("fk_mark_qtnd_air_qtnd_qtnm_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.pol)
                .WithMany()
                .HasForeignKey(e => e.qtnd_pol_id)
                .HasPrincipalKey(e => e.param_id)
                .HasConstraintName("fk_mark_qtnd_air_qtnd_pol_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
            modelBuilder
                .HasOne(e => e.pod)
                .WithMany()
                .HasForeignKey(e => e.qtnd_pod_id)
                .HasPrincipalKey(e => e.param_id)
                .HasConstraintName("fk_mark_qtnd_air_qtnd_pod_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
            modelBuilder
                .HasOne(e => e.carrier)
                .WithMany()
                .HasForeignKey(e => e.qtnd_carrier_id)
                .HasPrincipalKey(e => e.param_id)
                .HasConstraintName("fk_mark_qtnd_air_qtnd_carrier_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mark_qtnd_air_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(e => e.rec_branch_id)
                .HasPrincipalKey(e => e.branch_id)
                .HasConstraintName("fk_mark_qtnd_air_rec_branch_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            insertdata(modelBuilder);
        }

        void insertdata(EntityTypeBuilder<mark_qtnd_air> modelBuilder)
        {
            modelBuilder.HasData(
            new mark_qtnd_air
            {
                qtnd_id = 1,
                qtnd_qtnm_id = 20,
                qtnd_pod_id = 1005,
                qtnd_pod_name = "AABENRAA, DENMARK",
                qtnd_45k = "1.5/kg",
                qtnd_order = 1,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
                rec_branch_id =1,
            });
        }
    }
}

