using Database.Models.Masters;
using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.fluent_config.UserAdmin
{
   public class mast_mail_serverm_config : IEntityTypeConfiguration<mast_mail_serverm>
    { 
        public void Configure(EntityTypeBuilder<mast_mail_serverm> modelBuilder)
        {
            // //table and primary key
            // modelBuilder.ToTable("mast_mail_serverm");
            // modelBuilder.HasKey(u => u.mail_id)
            //     .HasName("pk_mast_mail_serverm_mail_id");
            // //Sequence
            // modelBuilder.Property(u => u.mail_id)
            // //.HasDefaultValueSql("next value for MasterSequence")
            //     .HasDefaultValueSql("nextval('\"master_sequence\"')")
            //     .ValueGeneratedOnAdd();
            // //Columns
            // modelBuilder.Property(p => p.rec_version)
            //     .HasDefaultValue(1)
            //     .IsConcurrencyToken();
            // modelBuilder.Property(u => u.mail_name)
            //     .HasMaxLength(100)
            //     .IsRequired(false);
            // modelBuilder.Property(u => u.mail_smtp_name)
            //     .HasMaxLength(100)
            //     .IsRequired(false);
            // modelBuilder.Property(u => u.mail_smtp_port)
            //     .HasMaxLength(15)
            //     .IsRequired(false);
            // modelBuilder.Property(u => u.mail_is_ssl)
            //     .HasMaxLength(10)
            //     .IsRequired(false);
            // modelBuilder.Property(u => u.mail_is_auth)
            //     .HasMaxLength(10)
            //     .IsRequired(false);
            // modelBuilder.Property(u => u.mail_is_spa)
            //     .HasMaxLength(10)
            //     .IsRequired(false);
            // modelBuilder.Property(e => e.mail_bulk_tot)
            //     .IsRequired(false);
            // modelBuilder.Property(e => e.mail_bulk_sub)
            //     .IsRequired(false);
            // modelBuilder.Property(u => u.mail_smtp_username)
            //     .HasMaxLength(100)
            //     .IsRequired(false);
            // modelBuilder.Property(u => u.mail_smtp_pwd)
            //     .HasMaxLength(100)
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
            // modelBuilder.HasIndex(e => new { e.rec_company_id, e.mail_name })
            //     .HasDatabaseName("uq_mast_mail_serverm_mail_name")
            //     .IsUnique();
            // //Foreign Key
            // modelBuilder
            //     .HasOne(e => e.company)
            //     .WithMany()
            //     .HasForeignKey(e => e.rec_company_id)
            //     .HasPrincipalKey(e => e.comp_id)
            //     .HasConstraintName("fk_mast_mail_serverm_rec_company_id")
            //     .OnDelete(DeleteBehavior.NoAction)
            //    .IsRequired();
            // insertdata(modelBuilder);
        }

        void insertdata(EntityTypeBuilder<mast_mail_serverm> modelBuilder)
        {
           modelBuilder.HasData(
           new mast_mail_serverm
           {
               mail_id = 1,
               mail_name = "Oracle",
               mail_smtp_name ="DB",
               mail_smtp_port = "123",
               mail_is_ssl = "Y",
               mail_is_auth = "Y",
               mail_is_spa = "Y",
               mail_bulk_tot = 500,
               mail_bulk_sub = 10,
               mail_smtp_username ="Oracle",
               mail_smtp_pwd = "123",
               rec_created_by = "ADMIN",
               rec_created_date = DbLib.GetDateTime(),
               rec_company_id = 1
           }
           );
        }
    }
}


