using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.table_config.UserAdmin
{
    public class mast_userm_config : IEntityTypeConfiguration<mast_userm>
    {
        public void Configure(EntityTypeBuilder<mast_userm> modelBuilder)
        {/*
            //Table
            modelBuilder.ToTable("mast_userm");
            //Parimary Key
            modelBuilder.HasKey(e => e.user_id);
                // .HasName("pk_mast_userm_user_id");
            //Sequence
            modelBuilder.Property(u => u.user_id)
                .ValueGeneratedOnAdd();
            //Columns
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
                /*
            modelBuilder.Property(u => u.user_code)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Property(u => u.user_name)
                .HasMaxLength(60)
                .IsRequired();
            modelBuilder.Property(u => u.user_password)
                .HasMaxLength(20)
                .IsRequired(false);
            modelBuilder.Property(u => u.user_email)
                .HasMaxLength(60)
                .IsRequired();
            modelBuilder.Property(u => u.user_is_admin)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
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
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.user_code })
                .HasDatabaseName("uq_mast_userm_user_code")
                .IsUnique();
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.user_name })
                .HasDatabaseName("uq_mast_userm_user_name")
                .IsUnique();
            //Foreign Key
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_userm_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(e => e.rec_branch_id)
                .HasPrincipalKey(e => e.branch_id)
                .HasConstraintName("fk_mast_userm_rec_branch_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            // insertdata(modelBuilder);
        }
        public void insertdata(EntityTypeBuilder<mast_userm> modelBuilder)
        {
            modelBuilder.HasData(new mast_userm
            {
                user_id = 1,
                user_code = "ADMIN",
                user_name = "ADMIN",
                user_email = "admin@gmail.com",
                user_is_admin = "Y",
                user_password = "ADMIN",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
                rec_branch_id = 1,
            },
            new mast_userm
            {
                user_id = 2,
                user_code = "USER1",
                user_name = "USER1",
                user_email = "user1@gmail.com",
                user_is_admin = "N",
                user_password = "USER1",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
                rec_branch_id = 1,
            },
            new mast_userm
            {
                user_id = 3,
                user_code = "USER2",
                user_name = "USER2",
                user_email = "user2@gmail.com",
                user_is_admin = "N",
                user_password = "USER2",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
                rec_branch_id = 1,
            });
            */
        }
    }

}


