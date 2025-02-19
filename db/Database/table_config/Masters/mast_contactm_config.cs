using Database.Models.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.table_config.Masters
{
   public class mast_contactm_config : IEntityTypeConfiguration<mast_contactm>
    { 
        public void Configure(EntityTypeBuilder<mast_contactm> modelBuilder)
        {/*
            //table and primary key
            modelBuilder.ToTable("mast_contactm");
            modelBuilder.HasKey(u => u.cont_id);
                //.HasName("pk_mast_contactm_cont_id");
            //Sequence
            modelBuilder.Property(u => u.cont_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                //.HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //Columns
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();

            // modelBuilder.Property(e => e.cont_parent_id)
            //     .IsRequired();

            // modelBuilder.Property(u => u.cont_title)
            //     .HasMaxLength(10)
            //     .IsRequired();
            // modelBuilder.Property(u => u.cont_name)
            //     .HasMaxLength(100)
            //     .IsRequired();
            // modelBuilder.Property(u => u.cont_group_id)
            //     .IsRequired(false);
            // modelBuilder.Property(u => u.cont_designation)
            //     .HasMaxLength(100)
            //     .IsRequired();
            // modelBuilder.Property(u => u.cont_email)
            //     .HasMaxLength(100)
            //     .IsRequired();
            // modelBuilder.Property(u => u.cont_tel)
            //     .HasMaxLength(100)
            //     .IsRequired(false);
            // modelBuilder.Property(u => u.cont_mobile)
            //     .HasMaxLength(100)
            //     .IsRequired(false);
            // modelBuilder.Property(u => u.cont_remarks)
            //     .HasMaxLength(100)
            //     .IsRequired(false);
            // modelBuilder.Property(u => u.cont_country_id)
            //     .IsRequired();
            // modelBuilder.Property(u => u.rec_locked)
            //     .HasColumnType("char")
            //     .HasMaxLength(1)
            //     .HasDefaultValue("N")
            //     .IsRequired();
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
            //     .HasOne(e => e.customer)
            //     .WithMany()
            //     .HasForeignKey(e => e.cont_parent_id)
            //     .HasPrincipalKey(e => e.cust_id)
            //     .HasConstraintName("fk_mast_contactm_cont_parent_id")
            //     .OnDelete(DeleteBehavior.NoAction)
            //     .IsRequired();
            // modelBuilder
            //     .HasOne(e => e.country)
            //     .WithMany()
            //     .HasForeignKey(e => e.cont_country_id)
            //     .HasPrincipalKey(e => e.param_id)
            //     .HasConstraintName("fk_mast_contactm_cont_country_id")
            //     .OnDelete(DeleteBehavior.NoAction)
            //     .IsRequired();
            // modelBuilder
            //     .HasOne(e => e.contgroup)
            //     .WithMany()
            //     .HasForeignKey(e => e.cont_group_id)
            //     .HasPrincipalKey(e => e.param_id)
            //     .HasConstraintName("fk_mast_contactm_cont_group_id")
            //     .OnDelete(DeleteBehavior.NoAction)
            //     .IsRequired(false);
            // modelBuilder
            //     .HasOne(e => e.company)
            //     .WithMany()
            //     .HasForeignKey(e => e.rec_company_id)
            //     .HasPrincipalKey(e => e.comp_id)
            //     .HasConstraintName("fk_mast_contactm_rec_company_id")
            //     .OnDelete(DeleteBehavior.NoAction)
            //     .IsRequired();
            // // insertdata(modelBuilder);
        }

        void insertdata(EntityTypeBuilder<mast_contactm> modelBuilder)
        {
            modelBuilder.HasData(
            new mast_contactm
            {
                cont_id = 1,
                cont_parent_id = 100,
                cont_title = "MR",
                cont_name = "JOY",
                cont_designation = "EXECUTIVE",
                cont_email = "joy@cargomar.in",
                cont_tel = "0484-245678",
                cont_mobile = "9947194307",
                cont_country_id = 1,

                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }, new mast_contactm
            {
                cont_id = 2,
                cont_parent_id = 100,
                cont_title = "MR",
                cont_name = "AJITH",
                cont_designation = "EXECUTIVE",
                cont_email = "ajith@cargomar.in",
                cont_tel = "0484-245678",
                cont_mobile = "9917294107",
                cont_country_id = 1,
                rec_locked = "N",
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1
            }
            );
*/
        }
    }
}


