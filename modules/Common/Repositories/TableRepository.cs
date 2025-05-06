using Microsoft.EntityFrameworkCore;
using Database;
using Common.Interfaces;
using System.Linq.Expressions;

namespace Common.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly AppDbContext context;

        private List<string>  files = new List<string>();
        public TableRepository(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        public async Task CreateTablesAsync()
        {
            try
            {
                string rootPath = AppContext.BaseDirectory;
                AddFiles();
                await ExecuteScriptAsync(rootPath);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }

        private async Task ExecuteScriptAsync( string rootPath )
        {
            string sqlScript = "";
            try {
            string fname = "";
            
            foreach (var fileName in files)
            {
                fname = System.IO.Path.Combine(rootPath, "scripts", fileName);
                if (!File.Exists(fname))
                    continue;
                sqlScript = await File.ReadAllTextAsync(fname);
                await context.Database.ExecuteSqlRawAsync(sqlScript);
            }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }            

        }
        private void AddFiles()
        {
            files = new List<string>();
            files.Add("UserAdmin\\mast_sequence.txt");
            files.Add("UserAdmin\\mast_companym.txt");
            files.Add("UserAdmin\\mast_branchm.txt");
            files.Add("UserAdmin\\mast_modulem.txt");
            files.Add("UserAdmin\\mast_menum.txt");
            files.Add("UserAdmin\\mast_userm.txt");
            files.Add("UserAdmin\\mast_auditm.txt");
            files.Add("UserAdmin\\mast_userbranches.txt");
            files.Add("UserAdmin\\mast_rightsm.txt");
            files.Add("UserAdmin\\mast_settings.txt");
            files.Add("UserAdmin\\mast_history.txt");

            files.Add("Masters\\mast_param.txt");
            files.Add("Masters\\mast_param_air-carrier.txt");
            files.Add("Masters\\mast_param_air-move-status.txt");
            files.Add("Masters\\mast_param_air-port.txt");
            files.Add("Masters\\mast_param_budget-type.txt");
            files.Add("Masters\\mast_param_cargo-movement.txt");
            files.Add("Masters\\mast_param_chq-format.txt");
            files.Add("Masters\\mast_param_cntr-move-status.txt");
            files.Add("Masters\\mast_param_contact_group.txt");
            files.Add("Masters\\mast_param_container-type.txt");
            files.Add("Masters\\mast_param_coo-format.txt");
            files.Add("Masters\\mast_param_country.txt");
            files.Add("Masters\\mast_param_currency.txt");
            files.Add("Masters\\mast_param_customer-group.txt");
            files.Add("Masters\\mast_param_form-category.txt");
            files.Add("Masters\\mast_param_freight-status.txt");
            files.Add("Masters\\mast_param_hawb-format.txt");
            files.Add("Masters\\mast_param_hbl-format.txt");
            files.Add("Masters\\mast_param_invoice-description.txt");
            files.Add("Masters\\mast_param_nomination.txt");
            files.Add("Masters\\mast_param_salesman.txt");
            files.Add("Masters\\mast_param_sea-carrier.txt");
            files.Add("Masters\\mast_param_vessel.txt");
            files.Add("Masters\\mast_param_shipterms.txt");
            files.Add("Masters\\mast_param_shipstage-oe.txt");
            files.Add("Masters\\mast_param_sea-port.txt");
            files.Add("Masters\\mast_param_ship-move-status.txt");
            files.Add("Masters\\mast_param_state.txt");
            files.Add("Masters\\mast_param_unit-master.txt");
            files.Add("Masters\\mast_param_incoterm.txt");
            files.Add("Masters\\mast_param_mbl-status.txt");
            files.Add("Masters\\mast_param_paid-status.txt");
            files.Add("Masters\\mast_param_telex-release.txt");
            files.Add("Masters\\mast_param_memo-remarks.txt");
            files.Add("Masters\\mast_param_followup.txt");
            files.Add("Masters\\mast_param_newid.txt");
            files.Add("UserAdmin\\mast_mail_serverm.txt");

            files.Add("Masters\\mast_custmerm.txt");
            files.Add("Masters\\mast_contactm.txt");
            files.Add("Masters\\mast_remarkm.txt");
            files.Add("Masters\\mast_remarkd.txt");
            files.Add("Masters\\mast_wiretransm.txt");
            files.Add("Masters\\mast_wiretransd.txt");

            files.Add("Accounts\\acc_groupm.txt");
            files.Add("Accounts\\acc_acctm.txt");

            files.Add("Marketing\\mark_qtnm.txt");
            files.Add("Marketing\\mark_qtnd_lcl.txt");
            files.Add("Marketing\\mark_qtnd_fcl.txt");
            files.Add("Marketing\\mark_qtnd_air.txt");

            files.Add("Cargo\\cargo_masterm.txt");
            files.Add("Cargo\\cargo_housem.txt");
            files.Add("Cargo\\cargo_container.txt");
            files.Add("Cargo\\cargo_desc.txt");

            files.Add("TnT\\tnt_trackm.txt");
            files.Add("TnT\\tnt_trackd.txt");
            files.Add("TnT\\tnt_tracking_data.txt");

            files.Add("CommonShipment\\cargo_memo.txt");
            files.Add("CommomShipment\\cargo_followup.txt");
            files.Add("CommomShipment\\cargo_slip.txt");
            
        }
    }
}