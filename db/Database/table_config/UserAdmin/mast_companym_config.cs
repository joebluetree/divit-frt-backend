using Database.Models.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.table_config.UserAdmin
{
    public class mast_companym_config : IEntityTypeConfiguration<mast_companym>
    {
        public void Configure(EntityTypeBuilder<mast_companym> modelBuilder)
        {
            //table and primary key
            modelBuilder.ToTable("mast_companym");
            modelBuilder.HasKey(u => u.comp_id)
                .HasName("pk_mast_companym_comp_id");
            //Sequence
            modelBuilder.Property(u => u.comp_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //columns
            modelBuilder.Property(u => u.comp_code)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Property(u => u.comp_name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.comp_address1)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.comp_address2)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.comp_address3)
                .HasMaxLength(100)
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
            //unique key
            modelBuilder.HasIndex(e => new { e.comp_id, e.comp_code })
                .HasDatabaseName("uq_mast_companym_comp_code")
                .IsUnique();
            modelBuilder.HasIndex(e => new { e.comp_id, e.comp_name })
                .HasDatabaseName("uq_mast_companym_comp_name")
                .IsUnique();

            // insertdata(modelBuilder);
        }

        void insertdata(EntityTypeBuilder<mast_companym> modelBuilder)
        {
            modelBuilder.HasData(new mast_companym
            {
                comp_id = 1,
                comp_code = "COMPANY1",
                comp_name = "COMPANY1",
                comp_address1 = "ADDRESS LINE 1",
                comp_address2 = "ADDRESS LINE 2",
                comp_address3 = "ADDRESS LINE3 3",
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            }, new mast_companym
            {
                comp_id = 2,
                comp_code = "COMPANY2",
                comp_name = "COMPANY2",
                comp_address1 = "ADDRESS LINE 1",
                comp_address2 = "ADDRESS LINE 2",
                comp_address3 = "ADDRESS LINE3 3",
                rec_created_date = DbLib.GetDateTime(),
                rec_created_by = "ADMIN"
            });

        }


    }

}


