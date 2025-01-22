using Database;
using Database.Models.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace database.fluent_config.Masters;

public class mast_remarkm_config : IEntityTypeConfiguration<mast_remarkm>
{
    public void Configure(EntityTypeBuilder<mast_remarkm> modelBuilder)
    {
        //table and primary key
        modelBuilder.ToTable("mast_remarkm");
        modelBuilder.HasKey(u => u.rem_id)
            .HasName("pk_mast_remarkm_rem_id");
        //Sequence
        modelBuilder.Property(u => u.rem_id)
            //.HasDefaultValueSql("next value for MasterSequence")
            .HasDefaultValueSql("nextval('\"master_sequence\"')")
            .ValueGeneratedOnAdd();
        //Columns
        modelBuilder.Property(p => p.rec_version)
            .HasDefaultValue(1)
            .IsConcurrencyToken();
        modelBuilder.Property(u => u.rem_name)
            .HasMaxLength(100)
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
        modelBuilder.HasIndex(e => new { e.rec_company_id, e.rem_name })
            .HasDatabaseName("uq_mast_remarkm_rem_name")
            .IsUnique();
        //Foreign Key
        modelBuilder
            .HasOne(e => e.company)
            .WithMany()
            .HasForeignKey(e => e.rec_company_id)
            .HasPrincipalKey(e => e.comp_id)
            .HasConstraintName("fk_mast_remarkm_rec_company_id")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        insertdata(modelBuilder);
    }
    void insertdata(EntityTypeBuilder<mast_remarkm> modelBuilder)
    {
        modelBuilder.HasData(
        new mast_remarkm
        {
            rem_id = 1,
            rem_name = "Quotation Fcl",
            rec_created_by = "ADMIN",
            rec_created_date = DbLib.GetDateTime(),
            rec_company_id = 1
        }
        );
    }

}
