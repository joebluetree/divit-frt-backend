using System.Runtime.InteropServices;
using Database.Models.Accounts;
using Database.Models.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//Name : Sourav V
//Created Date : 03/01/2025
//Remark : this file defines schema,relationship, constraint and initial seed data of mark_qtnm

namespace Database.table_config.Marketing
{
    public class mark_qtnm_config : IEntityTypeConfiguration<mark_qtnm>
    { 
        public void Configure(EntityTypeBuilder<mark_qtnm> modelBuilder)
        {/*
            //table and primary key
            modelBuilder.ToTable("mark_qtnm");
            modelBuilder.HasKey(u => u.qtnm_id);
                // .HasName("pk_mark_qtnm_qtnm_id")
            //Sequence
            modelBuilder.Property(u => u.qtnm_id)
                //.HasDefaultValueSql("next value for MasterSequence")
                // .HasDefaultValueSql("nextval('\"master_sequence\"')")
                .ValueGeneratedOnAdd();
            //rec_version
            modelBuilder.Property(p => p.rec_version)
                .HasDefaultValue(1)
                .IsConcurrencyToken();
            //columns
            /*
            modelBuilder.Property(u => u.qtnm_cfno)
                .IsRequired();
            modelBuilder.Property(u => u.qtnm_type)
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Property(u => u.qtnm_no)
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Property(u => u.qtnm_to_name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.qtnm_to_addr1)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Property(u => u.qtnm_to_addr2)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_to_addr3)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_to_addr4)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_date)
                .HasColumnType("date")
                .IsRequired();
            modelBuilder.Property(u => u.qtnm_quot_by)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Property(u => u.qtnm_valid_date)
                .HasColumnType("date")
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_move_type)
                .HasMaxLength(10)
                .IsRequired();
            modelBuilder.Property(u => u.qtnm_commodity)
                .HasMaxLength(30)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_package)
                .HasMaxLength(10)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_kgs)
                .HasColumnType("decimal(15,3)")
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_lbs)
                .HasColumnType("decimal(15,3)")
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_cbm)
                .HasColumnType("decimal(15,3)")
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_cft)
                .HasColumnType("decimal(15,3)")
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_por_id)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_por_name)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_pol_id)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_pol_name)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_pod_id)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_pod_name)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_pld_name)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_plfd_name)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_trans_time)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_routing)
                .HasMaxLength(100)
                .IsRequired(false);
            modelBuilder.Property(u => u.qtnm_amt)
                .HasColumnType("decimal(15,3)")
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

            modelBuilder
                .HasOne(e => e.customer)
                .WithMany()
                .HasForeignKey(e => e.qtnm_to_id)
                .HasPrincipalKey(e => e.cust_id)
                .HasConstraintName("fk_mark_qtnm_qtnm_to_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.salesman)
                .WithMany()
                .HasForeignKey(e => e.qtnm_salesman_id)
                .HasPrincipalKey(e => e.param_id)
                .HasConstraintName("fk_mark_qtnm_qtnm_salesman_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.por)
                .WithMany()
                .HasForeignKey(e => e.qtnm_por_id)
                .HasPrincipalKey(e => e.param_id)
                .HasConstraintName("fk_mark_qtnm_qtnm_por_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
            modelBuilder
                .HasOne(e => e.pol)
                .WithMany()
                .HasForeignKey(e => e.qtnm_pol_id)
                .HasPrincipalKey(e => e.param_id)
                .HasConstraintName("fk_mark_qtnm_qtnm_pol_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
            modelBuilder
                .HasOne(e => e.pod)
                .WithMany()
                .HasForeignKey(e => e.qtnm_pod_id)
                .HasPrincipalKey(e => e.param_id)
                .HasConstraintName("fk_mark_qtnm_qtnm_pod_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
            modelBuilder
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .HasConstraintName("fk_mark_qtnm_rec_company_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(e => e.rec_branch_id)
                .HasPrincipalKey(e => e.branch_id)
                .HasConstraintName("fk_mark_qtnm_rec_branch_id")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            
            
            
            // insertdata(modelBuilder);
        }

        void insertdata(EntityTypeBuilder<mark_qtnm> modelBuilder)
        {
            modelBuilder.HasData(
            new mark_qtnm
            {
                qtnm_id = 1,
                qtnm_cfno = 1,
                qtnm_type = "LCL",
                qtnm_no = "QL-1",
                qtnm_to_id = 100,
                qtnm_to_name = "ABC LTD KOCHI",
                qtnm_to_addr1 = "KOCHI",
                qtnm_date = DateTime.Now,
                qtnm_quot_by = "ADMIN",
                qtnm_valid_date = new DateTime(2025-05-12),
                qtnm_salesman_id = 1,
                qtnm_move_type = "TRUCKING",
                qtnm_por_id = null,
                qtnm_pol_id = null,
                qtnm_pod_id = null,
                qtnm_amt = 5000,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
                rec_branch_id =1,
            },new mark_qtnm
            {
                qtnm_id = 20,
                qtnm_cfno = 20,
                qtnm_type = "AIR",
                qtnm_no = "QA-20",
                qtnm_to_id = 100,
                qtnm_to_name = "ABC LTD KOCHI",
                qtnm_to_addr1 = "KOCHI",
                qtnm_date = DateTime.Now,
                qtnm_quot_by = "ADMIN",
                qtnm_valid_date = new DateTime(2025-05-12),
                qtnm_salesman_id = 1,
                qtnm_move_type = "TRUCKING",
                qtnm_amt = 0,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
                rec_branch_id =1,
            },new mark_qtnm
            {
                qtnm_id = 10,
                qtnm_cfno = 10,
                qtnm_type = "FCL",
                qtnm_no = "QF-10",
                qtnm_to_id = 100,
                qtnm_to_name = "ABC LTD KOCHI",
                qtnm_to_addr1 = "KOCHI",
                qtnm_date = DateTime.Now,
                qtnm_quot_by = "ADMIN",
                qtnm_valid_date = new DateTime(2025-05-12),
                qtnm_salesman_id = 1,
                qtnm_move_type = "TRUCKING",
                qtnm_amt = 0,
                rec_created_by = "ADMIN",
                rec_created_date = DbLib.GetDateTime(),
                rec_company_id = 1,
                rec_branch_id =1,
            });*/
        }
    }

}

