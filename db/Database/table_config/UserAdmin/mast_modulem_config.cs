using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.InteropServices;


namespace Database.table_config.UserAdmin
{

    public class module_config : IEntityTypeConfiguration<mast_modulem>
    {
        public void Configure(EntityTypeBuilder<mast_modulem> modelBuilder)
        {/*
            //Table Name
            modelBuilder.ToTable("mast_modulem");
            //Primary Key
            modelBuilder.HasKey(e => e.module_id);
                // .HasName("pk_mast_modulem_module_id");
            //Sequence
            modelBuilder.Property(u => u.module_id)
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //Columns
            /*
            modelBuilder.Property(e => e.module_name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(e => e.module_is_installed)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
            modelBuilder.Property(e => e.module_parent_id)
                .IsRequired(false);
            modelBuilder.Property(e => e.module_order)
                .IsRequired();

            modelBuilder.Property(u => u.rec_locked)
                .HasColumnType("char")
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
            //unique key
            modelBuilder.HasIndex(e => new { e.rec_company_id, e.module_name })
                .HasDatabaseName("uq_mast_modulem_rec_company_id_module_name")
                .IsUnique();
            //Foreign Key
            modelBuilder
                .HasOne(e => e.module)
                .WithMany()
                .HasForeignKey(e => e.module_parent_id)
                .HasPrincipalKey(e => e.module_id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_mast_modulem_module_parent_id")
                .IsRequired(false);
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(c => c.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mast_modulem_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
                */
            // insertdata(modelBuilder);
        }

        void insertdata(EntityTypeBuilder<mast_modulem> modelBuilder)
        {
            modelBuilder.HasData(
            new mast_modulem
            {
                module_id = 20,
                module_name = "Accounts",
                module_is_installed = "Y",
                module_order = 1,
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_modulem
            {
                module_id = 21,
                module_name = "Masters",
                module_is_installed = "Y",
                module_order = 3,
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_modulem
            {
                module_id = 22,
                module_name = "Tracking",
                module_is_installed = "Y",
                module_order = 4,
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_modulem
            {
                module_id = 23,
                module_name = "Marketing",
                module_is_installed = "Y",
                module_order = 2,
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            },
            new mast_modulem //create settings module
            {
                module_id = 24,
                module_name = "Settings",
                module_is_installed = "Y",
                module_order = 5,
                rec_company_id = 1,
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            }
            );
        }

    }
}


