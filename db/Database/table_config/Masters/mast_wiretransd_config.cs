using Database;
using Database.Models.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.table_config.Masters;

public class mast_wiretransd_config : IEntityTypeConfiguration<mast_wiretransd>
{
    public void Configure(EntityTypeBuilder<mast_wiretransd> modelBuilder)
    {
    //     //table and primary key
    //     modelBuilder.ToTable("mast_wiretransd");
    //     modelBuilder.HasKey(u => u.wtid_id);
    //         //.HasName("pk_mast_wiretransd_wtid_id");
    //     //Sequence
    //     modelBuilder.Property(u => u.wtid_id)
    //         //.HasDefaultValueSql("next value for MasterSequence")
    //         //.HasDefaultValueSql("nextval('\"master_sequence\"')")
    //         .ValueGeneratedOnAdd();
    //     //Columns
    //     modelBuilder.Property(p => p.rec_version)
    //         .HasDefaultValue(1)
    //         .IsConcurrencyToken();
    // //     modelBuilder.Property(u => u.wtid_benef_ref)
    // //         .HasMaxLength(100)
    // //         .IsRequired(false);
    // //     modelBuilder.Property(u => u.wtid_trns_amt)
    // //         .HasColumnType("decimal(15,3)")
    // //         .IsRequired();
    // //     modelBuilder.Property(u => u.wtid_order)
    // //         .IsRequired();
    // //     modelBuilder.Property(u => u.rec_created_by)
    // //         .HasMaxLength(20)
    // //         .IsRequired();
    // //     modelBuilder.Property(u => u.rec_created_date)
    // //         .IsRequired();
    // //     modelBuilder.Property(u => u.rec_edited_by)
    // //         .HasMaxLength(20)
    // //         .IsRequired(false);
    // //     modelBuilder.Property(u => u.rec_edited_date)
    // //         .IsRequired(false);
    // //     //unique
    // //     // modelBuilder.HasIndex(e => new { e.rec_company_id, e.wtim_to_name })
    // //     //     .HasDatabaseName("uq_mast_wiretransm_wtim_to_name")
    // //     //     .IsUnique();
    // //     //Foreign Key
    // //     modelBuilder
    // //         .HasOne(e => e.wtim)
    // //         .WithMany()
    // //         .HasForeignKey(e => e.wtid_wtim_id)
    // //         .HasPrincipalKey(e => e.wtim_id)
    // //         .HasConstraintName("fk_mast_wiretransd_wtid_wtim_id")
    // //         .OnDelete(DeleteBehavior.NoAction)
    // //         .IsRequired(false);
    // //     modelBuilder
    // //         .HasOne(e => e.benef)
    // //         .WithMany()
    // //         .HasForeignKey(e => e.wtid_benef_id)
    // //         .HasPrincipalKey(e => e.cust_id)
    // //         .HasConstraintName("fk_mast_wiretransd_wtid_benef_id")
    // //         .OnDelete(DeleteBehavior.NoAction)
    // //         .IsRequired(false);
    // //     modelBuilder
    // //         .HasOne(e => e.bank)
    // //         .WithMany()
    // //         .HasForeignKey(e => e.wtid_bank_id)
    // //         .HasPrincipalKey(e => e.cust_id)
    // //         .HasConstraintName("fk_mast_wiretransd_wtid_bank_id")
    // //         .OnDelete(DeleteBehavior.NoAction)
    // //         .IsRequired(false);
    // //     modelBuilder
    // //         .HasOne(e => e.company)
    // //         .WithMany()
    // //         .HasForeignKey(e => e.rec_company_id)
    // //         .HasPrincipalKey(e => e.comp_id)
    // //         .HasConstraintName("fk_mast_wiretransd_rec_company_id")
    // //         .OnDelete(DeleteBehavior.NoAction)
    // //         .IsRequired();
    // //     modelBuilder
    // //         .HasOne(e => e.branch)
    // //         .WithMany()
    // //         .HasForeignKey(e => e.rec_branch_id)
    // //         .HasPrincipalKey(e => e.branch_id)
    // //         .HasConstraintName("fk_mast_wiretransd_rec_branch_id")
    // //         .OnDelete(DeleteBehavior.NoAction)
    // //         .IsRequired();
    // //     // insertdata(modelBuilder);
    }
    void insertdata(EntityTypeBuilder<mast_wiretransd> modelBuilder)
    {
        modelBuilder.HasData(
        new mast_wiretransd
        {
            wtid_id = 1,
            wtid_wtim_id = 1,
            wtid_benef_id = 100,
            wtid_benef_ref = "New test ref",
            wtid_bank_id = 100,
            wtid_trns_amt = 5000,
            wtid_order = 1,
            rec_created_by = "ADMIN",
            rec_created_date = DbLib.GetDateTime(),
            rec_company_id = 1,
            rec_branch_id = 1,
        }
        );
    }

}

