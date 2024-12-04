namespace Database.Lib
{
    public static partial class AuditColumns
    {
        public static Dictionary<string, string> modulem = new Dictionary<string, string>()
        {
            { "module_name", "module name"},
            { "module_is_installed", "module is installed"},
            { "module_order", "module order"},
        };
        public static Dictionary<string, string> companym = new Dictionary<string, string>()
        {
            { "comp_code", "company code"},
            { "comp_name", "company name"},
            { "comp_address1", "company address1"},
            { "comp_address2", "company address3"},
            { "comp_address3", "company address4"},
        };
        public static Dictionary<string, string> branchm = new Dictionary<string, string>()
        {
            { "branch_code", "branch code"},
            { "branch_name", "branch name"},
            { "branch_address1", "branch address1"},
            { "branch_address2", "branch address3"},
            { "branch_address3", "branch address4"},
        };
        public static Dictionary<string, string> menum = new Dictionary<string, string>()
        {
            { "menu_name", "menu name"},
            { "menu_route", "menu route"},
            { "menu_visible", "menu visible"},
            { "menu_order", "menu order"},
            { "menu_module_id", "module id"},
            { "menu_module_name", "module name"},
        };
        public static Dictionary<string, string> param = new Dictionary<string, string>()
        {
            { "param_code", "code"},
            { "param_name", "name"},
            { "param_order", "order"},
        };
        public static Dictionary<string, string> userm = new Dictionary<string, string>()
        {
            { "user_code", "code"},
            { "user_name", "name"},
            { "user_email", "email"},
        };
        public static Dictionary<string, string> acc_groupm = new Dictionary<string, string>()
        {
            { "grp_name", "name"},
            { "grp_type", "type"},
            { "grp_order", "order"},
        };
        public static Dictionary<string, string> acc_acctm = new Dictionary<string, string>()
        {
            { "acc_name", "name"},
        };
        public static Dictionary<string, string> settings = new Dictionary<string, string>()
        {
            { "value", "value"},
        };
        public static Dictionary<string, string> customerm = new Dictionary<string, string>()
        {
            { "cust_code", "code"},
            { "cust_short_name", "shor_name"},
            { "cust_name", "name"},
            { "cust_display_name", "dispaly_name"},
        };
    }

}

