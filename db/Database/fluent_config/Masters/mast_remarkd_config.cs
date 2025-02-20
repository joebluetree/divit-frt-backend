using Database;
using Database.Models.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace database.fluent_config.Masters;

public class mast_remarkd_config : IEntityTypeConfiguration<mast_remarkd>
{
    public void Configure(EntityTypeBuilder<mast_remarkd> modelBuilder)
    {
        //table and primary key
        // modelBuilder.ToTable("mast_remarkd");
        // modelBuilder.HasKey(u => u.remd_id)
        //     .HasName("pk_mast_remarkd_remd_id");
        // //Sequence
        // modelBuilder.Property(u => u.remd_id)
        //     //.HasDefaultValueSql("next value for MasterSequence")
        //     .HasDefaultValueSql("nextval('\"master_sequence\"')")
        //     .ValueGeneratedOnAdd();
        // //Columns
        // modelBuilder.Property(p => p.rec_version)
        //     .HasDefaultValue(1)
        //     .IsConcurrencyToken();
        // modelBuilder.Property(u => u.remd_desc1)
        //     .HasMaxLength(100)
        //     .IsRequired(false);
        // modelBuilder.Property(u => u.remd_order)
        //     .IsRequired(false);
        // modelBuilder.Property(u => u.rec_created_by)
        //     .HasMaxLength(20)
        //     .IsRequired();
        // modelBuilder.Property(u => u.rec_created_date)
        //     .IsRequired();
        // modelBuilder.Property(u => u.rec_edited_by)
        //     .HasMaxLength(20)
        //     .IsRequired(false);
        // modelBuilder.Property(u => u.rec_edited_date)
        //     .IsRequired(false);
        // //unique
        // //Foreign Key
        // modelBuilder
        //     .HasOne(e => e.remarkm)
        //     .WithMany()
        //     .HasForeignKey(e => e.remd_remarkm_id)
        //     .HasPrincipalKey(e => e.rem_id)
        //     .HasConstraintName("fk_mast_remarkd_remd_remarkm_id")
        //     .OnDelete(DeleteBehavior.NoAction)
        //     .IsRequired();
        // modelBuilder
        //     .HasOne(e => e.company)
        //     .WithMany()
        //     .HasForeignKey(e => e.rec_company_id)
        //     .HasPrincipalKey(e => e.comp_id)
        //     .HasConstraintName("fk_mast_remarkd_rec_company_id")
        //     .OnDelete(DeleteBehavior.NoAction)
        //     .IsRequired();
        // insertdata(modelBuilder);
    }
    void insertdata(EntityTypeBuilder<mast_remarkd> modelBuilder)
    {
        modelBuilder.HasData(
        new mast_remarkd
        {
            remd_id = 1,
            remd_remarkm_id = 1,
            remd_desc1 = "Quotation Fcl",
            rec_created_by = "ADMIN",
            rec_created_date = DbLib.GetDateTime(),
            rec_company_id = 1
        }
        );
    }

}
