using Microsoft.EntityFrameworkCore;
using Database.Models.UserAdmin;
using Database.Models.Masters;
using Database.Models.Accounts;
using Database.Models.TnT;
using Database.Models.Marketing;
using Database.Models.Cargo;

namespace Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<mast_userm> mast_userm { get; set; } = null!;
        public DbSet<mast_modulem> mast_modulem { get; set; } = null!;
        public DbSet<mast_menum> mast_menum { get; set; } = null!;
        public DbSet<mast_auditm> mast_auditm { get; set; } = null!;

        public DbSet<mast_history> mast_history { get; set; } = null!;

        public DbSet<mast_companym> mast_companym { get; set; } = null!;
        public DbSet<mast_branchm> mast_branchm { get; set; } = null!;
        public DbSet<mast_userbranches> mast_userbranches { get; set; } = null!;
        public DbSet<mast_rightsm> mast_rightsm { get; set; } = null!;
        public DbSet<mast_settings> mast_settings { get; set; } = null!;
        public DbSet<mast_mail_serverm> mast_mail_serverm { get; set; } = null!;

        //Masters
        public DbSet<mast_param> mast_param { get; set; } = null!;
        public DbSet<mast_customerm> mast_customerm { get; set; } = null!;
        public DbSet<mast_contactm> mast_contactm { get; set; } = null!;
        public DbSet<mast_remarkm> mast_remarkm { get; set; } = null!;
        public DbSet<mast_remarkd> mast_remarkd { get; set; } = null!;
        public DbSet<mast_wiretransm> mast_wiretransm { get; set; } = null!;
        public DbSet<mast_wiretransd> mast_wiretransd { get; set; } = null!;


        //Marketing
        public DbSet<mark_qtnm> mark_qtnm { get; set; } = null!;
        public DbSet<mark_qtnd_lcl> mark_qtnd_lcl { get; set; } = null!;
        public DbSet<mark_qtnd_fcl> mark_qtnd_fcl { get; set; } = null!;
        public DbSet<mark_qtnd_air> mark_qtnd_air { get; set; } = null!;

        //Accounts
        public DbSet<cargo_masterm> cargo_masterm { get; set; } = null!;
        public DbSet<cargo_housem> cargo_housem { get; set; } = null!;

        //Accounts
        public DbSet<acc_groupm> acc_groupm { get; set; } = null!;
        public DbSet<acc_acctm> acc_acctm { get; set; } = null!;

        //TnT
        public DbSet<tnt_tracking_data> tnt_tracking_data { get; set; } = null!;
        public DbSet<tnt_trackm> tnt_trackm { get; set; } = null!;
        public DbSet<tnt_trackd> tnt_trackd { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("master_sequence")
                .StartsAt(1000)
                .IncrementsBy(1);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}