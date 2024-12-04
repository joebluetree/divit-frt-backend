using Database.Models.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.fluent_config.Masters
{
   public class mast_custmerm_config : IEntityTypeConfiguration<mast_customerm>
    { 
        public void Configure(EntityTypeBuilder<mast_customerm> modelBuilder)
        {
            //table and primary key
            modelBuilder.ToTable("mast_customerm");
            modelBuilder.HasKey(u => u.cust_id)
                .HasName("pk_mast_customerm_cust_id");
            //Sequence
            modelBuilder.Property(u => u.cust_id)
                .ValueGeneratedNever();
            //Columns
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            modelBuilder.Property(u => u.cust_type)
                .HasMaxLength(25)
                .IsRequired();
            modelBuilder.Property(u => u.cust_code)
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Property(u => u.cust_short_name)
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Property(u => u.cust_name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Property(u => u.cust_display_name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Property(u => u.cust_address1)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Property(u => u.cust_address2)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Property(u => u.cust_address3)
                .HasMaxLength(100)
                .IsRequired(false);

            modelBuilder.Property(u => u.cust_row_type)
                .HasMaxLength(10)
                .IsRequired();
            modelBuilder.Property(u => u.cust_is_parent)
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(e => e.cust_parent_id)
                .IsRequired(false);
            modelBuilder.Property(e => e.cust_credit_limit)
                .HasColumnType("decimal(15,3)");

            modelBuilder.Property(u => u.cust_est_dt)
                .HasColumnType("date")
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
            //unique
            modelBuilder.HasIndex(e => new { e.rec_company_id,e.cust_row_type, e.cust_code })
                .HasDatabaseName("uq_cust_customerm_cust_code")
                .IsUnique();
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.cust_row_type, e.cust_short_name })
                .HasDatabaseName("uq_cust_customerm_cust_short_name")
                .IsUnique();
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.cust_row_type, e.cust_name })
                .HasDatabaseName("uq_cust_customerm_cust_name")
                .IsUnique();
            //Foreign Key
            modelBuilder
                .HasOne(e => e.customer)
                .WithMany()
                .HasForeignKey(e => e.cust_parent_id)
                .HasPrincipalKey(e => e.cust_id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_mast_customerm_cust_parent_id")
                .IsRequired(false);
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_customerm_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
            insertdata(modelBuilder);
        }

        void insertdata(EntityTypeBuilder<mast_customerm> modelBuilder)
        {
           modelBuilder.HasData(
           new mast_customerm
           {
               cust_id = 100,
               cust_type = "",
               cust_code = "ABC",
               cust_short_name = "ABC",
               cust_name = "ABC LTD KOCHI",
               cust_display_name ="ABC LTD",
               cust_address1 = "PO BOX 12123",
               cust_address2 = "LMS BUILDING",
               cust_address3 = "KOCHI",
               cust_row_type = "CUSTOMER",
               cust_is_parent = "Y",
               cust_parent_id = null,
               cust_credit_limit = 0,
               rec_locked = "N",
               rec_created_by = "ADMIN",
               rec_created_date = DbLib.GetDateTime(),
               rec_company_id = 1

           }
           );
        }
    }
}


