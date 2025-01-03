using System.Runtime.InteropServices;
using Database.Models.Accounts;
using Database.Models.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database.fluent_config.Marketing
{
    public class mark_qtnd_lcl_config : IEntityTypeConfiguration<mark_qtnd_lcl>
    { 
        public void Configure(EntityTypeBuilder<mark_qtnd_lcl> modelBuilder)
        {
            //table and primary key
            modelBuilder.ToTable("mark_qtnd_lcl");
            modelBuilder.HasKey(u => u.qtnd_pkid)
                .HasName("pk_mark_qtnd_lcl_qtnd_pkid");
            //Sequence
            modelBuilder.Property(u => u.qtnd_pkid)
                //.HasDefaultValueSql("next value for MasterSequence")
                .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //columns
            modelBuilder.Property(u => u.qtnd_acc_name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Property(u => u.qtnd_amt)
                .HasColumnType("decimal(15,3)")
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnd_per)
                .HasMaxLength(100)
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
            // unique //lklklk
            // modelBuilder.HasIndex(e => new { e.rec_company_id,e.acc_row_type, e.acc_code })
            //     .HasDatabaseName("uq_acc_acctm_acc_code")            
            //     .IsUnique();
            // Foreign Key
            modelBuilder
                .HasOne(e => e.qtnm)
                .WithMany()
                .HasForeignKey(e => e.qtnd_qtnm_pkid)
                .HasPrincipalKey(e => e.qtnm_pkid)
                .HasConstraintName("fk_mark_qtnd_lcl_qtnm_pkid")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.acctm)
                .WithMany()
                .HasForeignKey(e => e.qtnd_acc_id)
                .HasPrincipalKey(e => e.acc_id)
                .HasConstraintName("fk_mark_qtnd_lcl_qtnd_acc_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mark_qtnd_lcl_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(e => e.rec_branch_id)
                .HasPrincipalKey(e => e.branch_id)
                .HasConstraintName("fk_mark_qtnd_lcl_rec_branch_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            insertdata(modelBuilder);
        }

        void insertdata(EntityTypeBuilder<mark_qtnd_lcl> modelBuilder)
        {
            modelBuilder.HasData(
            new mark_qtnd_lcl
            {
                qtnd_pkid = 1,
                qtnd_qtnm_pkid = 1,
                qtnd_acc_id = 1,
                qtnd_acc_name = "OCEAN IMPORT",
                qtnd_amt = 100,
                qtnd_per = "koc-mum",
                qtnd_order = 1,
                
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
                rec_branch_id =1,
            });
        }
    }

}

