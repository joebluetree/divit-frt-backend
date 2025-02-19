using System;
using Database;
using Database.Models.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace database.table_config.Marketing;

    //Name : Alen Cherian
    //Date : 03/01/2025
    //Command :  Database  fluent_Configuration for Quotation Fcl.

public class mark_qtnd_fcl_config : IEntityTypeConfiguration<mark_qtnd_fcl>
{
    public void Configure(EntityTypeBuilder<mark_qtnd_fcl> modelBuilder)
    {/*
        //table and primary key
        modelBuilder.ToTable("mark_qtnd_fcl");
        modelBuilder.HasKey(u => u.qtnd_id);
            // .HasName("pk_mark_qtnd_fcl_qtnd_id");
        //Sequence
        modelBuilder.Property(u => u.qtnd_id)
            //.HasDefaultValueSql("next value for MasterSequence")
            // .HasDefaultValueSql("nextval('\"master_sequence\"')")
            .ValueGeneratedOnAdd();
        //rec_version
        modelBuilder.Property(p => p.rec_version)
            .HasDefaultValue(1)
            .IsConcurrencyToken();
        //columns
        /*
        modelBuilder.Property(u => u.qtnd_pol_id)
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_pol_name)
            .HasMaxLength(100)
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_pod_id)
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_pod_name)
            .HasMaxLength(100)
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_carrier_id)
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_carrier_name)
            .HasMaxLength(100)
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_trans_time)
            .HasMaxLength(15)
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_routing)
            .HasMaxLength(100)
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_cntr_type)
            .HasMaxLength(6)
            .IsRequired();
        modelBuilder.Property(u => u.qtnd_etd)
            .HasMaxLength(25)
            .IsRequired();
        modelBuilder.Property(u => u.qtnd_cutoff)
            .HasMaxLength(25)
            .IsRequired();
        modelBuilder.Property(u => u.qtnd_of)
            .HasColumnType("decimal(15,3)")
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_pss)
            .HasColumnType("decimal(15,3)")
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_baf)
            .HasColumnType("decimal(15,3)")
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_isps)
            .HasColumnType("decimal(15,3)")
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_haulage)
            .HasColumnType("decimal(15,3)")
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_ifs)
            .HasColumnType("decimal(15,3)")
            .IsRequired(false);
        modelBuilder.Property(u => u.qtnd_tot_amt)
            .HasColumnType("decimal(15,3)")
            .IsRequired();
        modelBuilder.Property(u => u.qtnd_order)
            .IsRequired(false);
        // modelBuilder.Property(u => u.rec_locked)
        //     .HasColumnType("char")
        //     .HasMaxLength(1)
        //     .HasDefaultValue("N")
        //     .IsRequired();
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
            .HasForeignKey(e => e.qtnd_qtnm_id)
            .HasPrincipalKey(e => e.qtnm_id)
            .HasConstraintName("fk_mark_qtnd_fcl_qtnd_qtnm_id")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        modelBuilder
            .HasOne(e => e.pol)
            .WithMany()
            .HasForeignKey(e => e.qtnd_pol_id)
            .HasPrincipalKey(e => e.param_id)
            .HasConstraintName("fk_mark_qtnd_fcl_qtnd_pol_id")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
        modelBuilder
            .HasOne(e => e.pod)
            .WithMany()
            .HasForeignKey(e => e.qtnd_pod_id)
            .HasPrincipalKey(e => e.param_id)
            .HasConstraintName("fk_mark_qtnd_fcl_qtnd_pod_id")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
        modelBuilder
            .HasOne(e => e.carrier)
            .WithMany()
            .HasForeignKey(e => e.qtnd_carrier_id)
            .HasPrincipalKey(e => e.param_id)
            .HasConstraintName("fk_mark_qtnd_fcl_qtnd_carrier_id")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
        modelBuilder
            .HasOne(e => e.company)
            .WithMany()
            .HasForeignKey(e => e.rec_company_id)
            .HasPrincipalKey(e => e.comp_id)
            .HasConstraintName("fk_mark_qtnd_fcl_rec_company_id")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        modelBuilder
            .HasOne(e => e.branch)
            .WithMany()
            .HasForeignKey(e => e.rec_branch_id)
            .HasPrincipalKey(e => e.branch_id)
            .HasConstraintName("fk_mark_qtnd_fcl_rec_branch_id")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        //insertdata(modelBuilder);
        
    }

    void insertdata(EntityTypeBuilder<mark_qtnd_fcl> modelBuilder)
    {
        modelBuilder.HasData(
        new mark_qtnd_fcl
        {
            qtnd_id = 1,
            qtnd_qtnm_id = 10,
            qtnd_pol_id = null,
            qtnd_pod_id = null,
            qtnd_carrier_id = null,
            qtnd_cntr_type = "40' ft",
            qtnd_etd = "QF-10",
            qtnd_cutoff = "ABC",
            qtnd_tot_amt = 5000,
            rec_created_by = "ADMIN",
            rec_created_date = DbLib.GetDateTime(),
            rec_company_id = 1,
            rec_branch_id = 1,
        });*/
    }
}


