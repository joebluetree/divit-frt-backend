using Database;
using Database.Models.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.table_config.Masters;

public class mast_wiretransm_config : IEntityTypeConfiguration<mast_wiretransm>
{
    public void Configure(EntityTypeBuilder<mast_wiretransm> modelBuilder)
    {
        // //table and primary key
        // modelBuilder.ToTable("mast_wiretransm");
        // modelBuilder.HasKey(u => u.wtim_id);
        //    // .HasName("pk_mast_wiretransm_wtim_id");
        // //Sequence
        // modelBuilder.Property(u => u.wtim_id)
        //     //.HasDefaultValueSql("next value for MasterSequence")
        //     //.HasDefaultValueSql("nextval('\"master_sequence\"')")
        //     .ValueGeneratedOnAdd();
        // //Columns
        // modelBuilder.Property(p => p.rec_version)
        //     .HasDefaultValue(1)
        //     .IsConcurrencyToken();
        // // modelBuilder.Property(u => u.wtim_slno)
        // //         .IsRequired();
        // // modelBuilder.Property(u => u.wtim_refno)
        // //     .HasMaxLength(50)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_to_name)
        // //     .HasMaxLength(100)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_cust_name)
        // //     .HasMaxLength(100)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_cust_fax)
        // //     .HasMaxLength(100)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_cust_tel)
        // //     .HasMaxLength(100)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_acc_no)
        // //     .HasMaxLength(100)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_req_type)
        // //     .HasMaxLength(100)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_from_name)
        // //     .HasMaxLength(100)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_date)
        // //     .HasColumnType("date")
        // //     .IsRequired();
        // // modelBuilder.Property(u => u.wtim_sender_ref)
        // //     .HasMaxLength(100)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_your_ref)
        // //     .HasMaxLength(100)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_is_urgent)
        // //     .HasMaxLength(10)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_is_review)
        // //     .HasMaxLength(10)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_is_comment)
        // //     .HasMaxLength(10)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_is_reply)
        // //     .HasMaxLength(10)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_is_recycle)
        // //     .HasMaxLength(10)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.wtim_remarks)
        // //     .HasMaxLength(100)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.rec_created_by)
        // //     .HasMaxLength(20)
        // //     .IsRequired();
        // // modelBuilder.Property(u => u.rec_created_date)
        // //     .IsRequired();
        // // modelBuilder.Property(u => u.rec_edited_by)
        // //     .HasMaxLength(20)
        // //     .IsRequired(false);
        // // modelBuilder.Property(u => u.rec_edited_date)
        // //     .IsRequired(false);
        // // //unique

        // // //Foreign Key
        // // modelBuilder
        // //     .HasOne(e => e.customer)
        // //     .WithMany()
        // //     .HasForeignKey(e => e.wtim_cust_id)
        // //     .HasPrincipalKey(e => e.cust_id)
        // //     .HasConstraintName("fk_mast_wiretransm_wtim_cust_id")
        // //     .OnDelete(DeleteBehavior.NoAction)
        // //     .IsRequired();
        // // modelBuilder
        // //     .HasOne(e => e.company)
        // //     .WithMany()
        // //     .HasForeignKey(e => e.rec_company_id)
        // //     .HasPrincipalKey(e => e.comp_id)
        // //     .HasConstraintName("fk_mast_wiretransm_rec_company_id")
        // //     .OnDelete(DeleteBehavior.NoAction)
        // //     .IsRequired();
        // // modelBuilder
        // //     .HasOne(e => e.branch)
        // //     .WithMany()
        // //     .HasForeignKey(e => e.rec_branch_id)
        // //     .HasPrincipalKey(e => e.branch_id)
        // //     .HasConstraintName("fk_mast_wiretransm_rec_branch_id")
        // //     .OnDelete(DeleteBehavior.NoAction)
        // //     .IsRequired();
        // // // insertdata(modelBuilder);
    }
    void insertdata(EntityTypeBuilder<mast_wiretransm> modelBuilder)
    {
        modelBuilder.HasData(
        new mast_wiretransm
        {
            wtim_id = 1,
            wtim_slno = 1,
            wtim_refno = "WT-1",
            wtim_to_name = "WT-1",
            wtim_cust_id = 100,
            wtim_date = DateTime.Now,
            rec_created_by = "ADMIN",
            rec_created_date = DbLib.GetDateTime(),
            rec_company_id = 1,
            rec_branch_id =1,
        }
        );
    }

}

