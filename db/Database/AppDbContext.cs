using Microsoft.EntityFrameworkCore;
using Database.Models.UserAdmin;
using Database.Models.Masters;
using Database.Models.Accounts;
using Database.Models.TnT;
using Database.Models.Marketing;

using Database.fluent_config.Masters;
using Database.fluent_config.Accounts;
using Database.fluent_config.UserAdmin;
using Database.fluent_config.Tnt;
using Database.fluent_config.Marketing;


namespace Database
{

    // visual studio commands
    //update-database 0 // Remove database migration
    //remove-migration // Remove migration from code

    //add-migration "migration name" //Add/Track Migration
    //update-database // Apply Changes to database

    //drop-database // Remove database

    // dotnet migration commands
    //dotnet ef migrations add MigrationName
    //dotnet ef database update
    //dotnet ef migrations remove
    //dotnet ef migrations script

    //install efcore cli
    //dotnet tool install --global dotnet-ef
    //dotnet tool update --global dotnet-ef
    //dotnet tool list --global

    // testing - joy-branch
    
    //dotnet ef migrations add qtn --project db/database --startup-project webapicore


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<mast_userm> mast_userm { get; set; } = null!;
        public DbSet<mast_modulem> mast_modulem { get; set; } = null!;
        public DbSet<mast_menum> mast_menum { get; set; } = null!;
        public DbSet<mast_auditm> mast_auditm { get; set; } = null!;
        public DbSet<mast_companym> mast_companym { get; set; } = null!;
        public DbSet<mast_branchm> mast_branchm { get; set; } = null!;
        public DbSet<mast_userbranches> mast_userBranches { get; set; } = null!;
        public DbSet<mast_rightsm> mast_rightsm { get; set; } = null!;
        public DbSet<mast_settings> mast_settings { get; set; } = null!;

        //Masters
        public DbSet<mast_param> mast_param { get; set; } = null!;
        public DbSet<mast_customerm> mast_customerm { get; set; } = null!;
        public DbSet<mast_contactm> mast_contactm { get; set; } = null!;

        //Marketing
        public DbSet<mark_qtnm> mark_qtnm { get; set; } = null!;
        public DbSet<mark_qtnd_lcl> mark_qtnd_lcl { get; set; } = null!;

        //Accounts
        public DbSet<acc_groupm> acc_groupm { get; set; } = null!;
        public DbSet<acc_acctm> acc_acctm { get; set; } = null!;

        //TnT
        public DbSet<tnt_tracking_data> tnt_tracking_data { get; set; } = null!;
        public DbSet<tnt_trackm> tnt_trackm { get; set; } = null!;
        public DbSet<tnt_trackd> tnt_trackd { get; set; } = null!;




        //Add Tables to DbSet  and add config entries in CrateMasterTables Function
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            optionsBuilder
            .EnableSensitiveDataLogging()
            .LogTo(message => Debug.WriteLine(" Log : " + message));
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.HasSequence<int>("master_sequence")
                .StartsAt(1000)
                .IncrementsBy(1);

            /*
            CreateRelation_BaseTables(modelBuilder);
            CreateRelation_MasterTables(modelBuilder);
            CreateRelation_AcctmTables(modelBuilder);
            CreateRelation_TnTTables(modelBuilder);
            */


            CreateTables(modelBuilder);
            CreateMasterTables(modelBuilder);
            CreateAcctmTables(modelBuilder);
            CreateTnTTables(modelBuilder);
            CreateMarketingTables(modelBuilder);


        }


        private void CreateRelation_BaseTables(ModelBuilder modelBuilder)
        {
            //Branch
            modelBuilder.Entity<mast_companym>()
                .HasKey(e => e.comp_id);
            modelBuilder.Entity<mast_branchm>()
                .HasKey(e => e.branch_id);
            modelBuilder.Entity<mast_branchm>()
                .HasOne(b => b.company)
                .WithMany(c => c.branches)
                .HasForeignKey(b => b.rec_company_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //Module
            modelBuilder.Entity<mast_modulem>()
                .HasKey(e => e.module_id);

            modelBuilder.Entity<mast_modulem>()
                .Property(p => p.rec_version)

                .IsConcurrencyToken();


            modelBuilder.Entity<mast_modulem>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(c => c.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<mast_modulem>()
                .HasOne(e => e.module)
                .WithMany()
                .HasForeignKey(e => e.module_parent_id)
                .HasPrincipalKey(e => e.module_id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_mast_modulem_module_parent_id")
                .IsRequired(false);
            //Menum
            modelBuilder.Entity<mast_menum>()
                .HasKey(e => e.menu_id);
            modelBuilder.Entity<mast_menum>()
                .HasOne(e => e.module)
                .WithMany(e => e.menus)
                .HasForeignKey(e => e.menu_module_id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_mast_menum_menu_module_id")
                .IsRequired();
            modelBuilder.Entity<mast_menum>()
                .HasOne(e => e.submenu)
                .WithMany()
                .HasForeignKey(e => e.menu_submenu_id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_mast_menum_menu_submenu_id")
                .IsRequired(false);
            modelBuilder.Entity<mast_menum>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(c => c.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            //Userm
            modelBuilder.Entity<mast_userm>()
                .HasKey(e => e.user_id);
            modelBuilder.Entity<mast_userm>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<mast_userm>()
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(e => e.rec_branch_id)
                .HasPrincipalKey(e => e.branch_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            //Auditm
            modelBuilder.Entity<mast_auditm>()
                .HasKey(e => e.log_id);
            //UserBranches
            modelBuilder.Entity<mast_userbranches>()
                .HasKey(e => e.ub_id);
            modelBuilder.Entity<mast_userbranches>()
                .HasOne(e => e.user)
                .WithMany(e => e.userbranches)
                .HasForeignKey(e => e.ub_user_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<mast_userbranches>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<mast_userbranches>()
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(e => e.rec_branch_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            //User Rights
            modelBuilder.Entity<mast_rightsm>()
                .HasKey(e => e.rights_id);
            modelBuilder.Entity<mast_rightsm>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<mast_rightsm>()
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(e => e.rec_branch_id)
                .HasPrincipalKey(e => e.branch_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<mast_rightsm>()
                .HasOne(e => e.userbranches)
                .WithMany()
                .HasForeignKey(e => e.rights_parent_id)
                .HasPrincipalKey(e => e.ub_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<mast_rightsm>()
                .HasOne(e => e.user)
                .WithMany()
                .HasForeignKey(e => e.rights_user_id)
                .HasPrincipalKey(e => e.user_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<mast_rightsm>()
                .HasOne(e => e.menu)
                .WithMany()
                .HasForeignKey(e => e.rights_menu_id)
                .HasPrincipalKey(e => e.menu_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            //Settings
            modelBuilder.Entity<mast_settings>()
                .HasKey(e => e.id);
            modelBuilder.Entity<mast_settings>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(c => c.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<mast_settings>()
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(c => c.rec_branch_id)
                .HasPrincipalKey(e => e.branch_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
        private void CreateRelation_MasterTables(ModelBuilder modelBuilder)
        {
            //Param
            modelBuilder.Entity<mast_param>()
                .HasKey(e => e.param_id);
            modelBuilder.Entity<mast_param>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<mast_param>()
                .HasOne(e => e.branch)
                .WithMany()
                .HasForeignKey(e => e.rec_branch_id)
                .HasPrincipalKey(e => e.branch_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
            //Customerm
            modelBuilder.Entity<mast_customerm>()
                .HasKey(e => e.cust_id);
            modelBuilder.Entity<mast_customerm>()
                .HasOne(e => e.customer)
                .WithMany()
                .HasForeignKey(e => e.cust_parent_id)
                .HasPrincipalKey(e => e.cust_id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_mast_customerm_cust_parent_id")
                .IsRequired(false);
            modelBuilder.Entity<mast_customerm>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_mast_customerm_rec_company_id")
                .IsRequired();
            //modelBuilder.ApplyConfiguration(new mast_param_config());
            //modelBuilder.ApplyConfiguration(new mast_custmerm_config());
        }
        private void CreateRelation_AcctmTables(ModelBuilder modelBuilder)
        {
            //acc_groupm
            modelBuilder.Entity<acc_groupm>()
                .HasKey(e => e.grp_id);
            modelBuilder.Entity<acc_groupm>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            //acc_acctm
            modelBuilder.Entity<acc_acctm>()
                .HasKey(e => e.acc_id);
            modelBuilder.Entity<acc_acctm>()
                .HasOne(e => e.acctm)
                .WithMany()
                .HasForeignKey(e => e.acc_maincode_id)
                .HasPrincipalKey(e => e.acc_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
            modelBuilder.Entity<acc_acctm>()
                .HasOne(e => e.acc_groupm)
                .WithMany()
                .HasForeignKey(e => e.acc_grp_id)
                .HasPrincipalKey(e => e.grp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<acc_acctm>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //modelBuilder.ApplyConfiguration(new acc_groupm_config());
            //modelBuilder.ApplyConfiguration(new acc_acctm_config());
        }
        private void CreateRelation_TnTTables(ModelBuilder modelBuilder)
        {
            //tnt_trackm
            modelBuilder.Entity<tnt_trackm>()
                .HasKey(e => e.track_id);
            modelBuilder.Entity<tnt_trackm>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(c => c.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<tnt_trackm>()
                .HasOne(e => e.param_carrier)
                .WithMany()
                .HasForeignKey(c => c.track_carrier_id)
                .HasPrincipalKey(e => e.param_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            //tnt_trackd
            modelBuilder.Entity<tnt_trackd>()
                .HasKey(e => e.trackd_id);
            modelBuilder.Entity<tnt_trackd>()
                .HasOne(e => e.trackm)
                .WithMany(e => e.trackd)
                .HasForeignKey(c => c.trackd_trackm_id)
                .HasPrincipalKey(e => e.track_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<tnt_trackd>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(c => c.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            //tnt_tracking_data
            modelBuilder.Entity<tnt_tracking_data>()
                .HasKey(e => e.track_id);
            modelBuilder.Entity<tnt_tracking_data>()
                .HasOne(e => e.trackm)
                .WithMany(e => e.tracking_data)
                .HasForeignKey(e => e.tnt_trackm_id)
                .HasPrincipalKey(e => e.track_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<tnt_tracking_data>()
                .HasOne(e => e.trackd)
                .WithMany(e => e.tracking_data)
                .HasForeignKey(e => e.tnt_trackd_id)
                .HasPrincipalKey(e => e.trackd_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<tnt_tracking_data>()
                .HasOne(e => e.company)
                .WithMany()
                .HasForeignKey(e => e.rec_company_id)
                .HasPrincipalKey(e => e.comp_id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            //modelBuilder.ApplyConfiguration(new tnt_trackm_config());
            //modelBuilder.ApplyConfiguration(new tnt_trackd_config());
            //modelBuilder.ApplyConfiguration(new tnt_tracking_data_config());
        }


        private void CreateTables(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new mast_companym_config());
            modelBuilder.ApplyConfiguration(new mast_branchm_config());
            modelBuilder.ApplyConfiguration(new module_config());
            modelBuilder.ApplyConfiguration(new mast_menum_config());
            modelBuilder.ApplyConfiguration(new mast_userm_config());
            modelBuilder.ApplyConfiguration(new mast_auditm_config());
            modelBuilder.ApplyConfiguration(new mast_userbranches_config());
            modelBuilder.ApplyConfiguration(new mast_rightsm_config());
            modelBuilder.ApplyConfiguration(new mast_settings_config());
            modelBuilder.ApplyConfiguration(new mast_param_config());
        }
 
        private void CreateMasterTables(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new mast_custmerm_config());
            modelBuilder.ApplyConfiguration(new mast_contactm_config());
        }
        private void CreateMarketingTables(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new mark_qtnm_config());
            modelBuilder.ApplyConfiguration(new mark_qtnd_lcl_config());
        }
        private void CreateAcctmTables(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new acc_groupm_config());
            modelBuilder.ApplyConfiguration(new acc_acctm_config());
        }
        private void CreateTnTTables(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new tnt_trackm_config());
            modelBuilder.ApplyConfiguration(new tnt_trackd_config());
            modelBuilder.ApplyConfiguration(new tnt_tracking_data_config());
        }

    }


}