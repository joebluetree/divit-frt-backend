
using Microsoft.EntityFrameworkCore;
namespace Database.Lib.Repositories
{
    public class Lov_modulem : ILov
    {
        public async Task<Dictionary<string, object>> getRecordsAsync(AppDbContext context, Dictionary<string, object> data, int comp_id = 0, string search_string = "")
        {
            Dictionary<string, object> RetData = new Dictionary<string, object>();

            var query = from rec in context.mast_modulem
                        where rec.rec_company_id == comp_id  
                        && rec.module_parent_id == null
                        select new
                        {
                            rec.module_id,
                            rec.module_name,
                            rec.module_parent_id,
                            rec.module_is_installed,
                            rec.module_order,
                            rec.rec_company_id
                        };

            if (search_string != "" && search_string != null)
                query = query.Where(w => w.module_name.ToUpper().Contains(search_string.ToUpper()));

            query = query
                .OrderBy(c => c.module_name);

            var Records = await query
                .ToListAsync();

            RetData.Add("records", Records);

            return RetData;
        }
    }


    public class Lov_submenu : ILov
    {
        public async Task<Dictionary<string, object>> getRecordsAsync(AppDbContext context, Dictionary<string, object> data, int comp_id = 0, string search_string = "")
        {
            Dictionary<string, object> RetData = new Dictionary<string, object>();

            var query = from rec in context.mast_modulem
                        where rec.rec_company_id == comp_id
                        && rec.module_parent_id != null
                        select new 
                        {
                            rec.module_id,
                            rec.module_name,
                            rec.module_parent_id,
                            module_parent_name = rec.module.module_name,
                            rec.module_is_installed,
                            rec.module_order,
                            rec.rec_company_id
                        };

            if (search_string != "" && search_string != null)
                query = query.Where(w => w.module_name.Contains(search_string.ToUpper()));

            query = query
                .OrderBy(c => c.module_name);

            var Records = await query
                .ToListAsync();

            RetData.Add("records", Records);

            return RetData;
        }
    }


    public class Lov_branchm : ILov
    {
        public async Task<Dictionary<string, object>> getRecordsAsync(AppDbContext context, Dictionary<string, object> data, int comp_id = 0, string search_string = "")
        {
            Dictionary<string, object> RetData = new Dictionary<string, object>();

            var query = from rec in context.mast_branchm
                        where rec.rec_company_id == comp_id
                        select new
                        {
                            rec.branch_id,
                            rec.branch_code,
                            rec.branch_name,
                            rec.rec_company_id
                        };

            if (search_string != "" && search_string != null)
                query = query.Where(w => w.branch_name.Contains(search_string.ToUpper()));

            query = query
                .OrderBy(c => c.branch_name);

            var Records = await query
                .ToListAsync();

            RetData.Add("records", Records);

            return RetData;
        }
    }
    public class Lov_userm : ILov
    {
        public async Task<Dictionary<string, object>> getRecordsAsync(AppDbContext context, Dictionary<string, object> data, int comp_id = 0, string search_string = "")
        {
            Dictionary<string, object> RetData = new Dictionary<string, object>();

            var query = from rec in context.mast_userm
                        where rec.rec_company_id == comp_id
                        select new
                        {
                            rec.user_id,
                            rec.user_code,
                            rec.user_name,
                            rec.rec_company_id
                        };

            if (search_string != "" && search_string != null)
                query = query.Where(w => w.user_name.Contains(search_string.ToUpper()));

            query = query
                .OrderBy(c => c.user_name);

            var Records = await query
                .ToListAsync();

            RetData.Add("records", Records);

            return RetData;
        }
    }

    public class Lov_accgroupm : ILov
    {
        public async Task<Dictionary<string, object>> getRecordsAsync(AppDbContext context, Dictionary<string, object> data, int comp_id = 0, string search_string = "")
        {
            Dictionary<string, object> RetData = new Dictionary<string, object>();

            var query = from rec in context.acc_groupm
                        where rec.rec_company_id == comp_id
                        select new
                        {
                            rec.grp_id,
                            rec.grp_name,
                            rec.grp_main_group,
                            rec.rec_company_id
                        };

            if (search_string != "" && search_string != null)
                query = query.Where(w => w.grp_name.Contains(search_string.ToUpper()));

            query = query
                .OrderBy(c => c.grp_name);

            var Records = await query
                .ToListAsync();

            RetData.Add("records", Records);

            return RetData;
        }
    }

    public class Lov_acctm_maincode : ILov
    {
        public async Task<Dictionary<string, object>> getRecordsAsync(AppDbContext context, Dictionary<string, object> data, int comp_id = 0, string search_string = "")
        {
            Dictionary<string, object> RetData = new Dictionary<string, object>();

            var query = from rec in context.acc_acctm
                        where (rec.rec_company_id == comp_id && rec.acc_row_type == "MAIN-CODE")
                        select new
                        {
                            rec.acc_id,
                            rec.acc_code,
                            rec.acc_name,
                            rec.rec_company_id
                        };

            if (search_string != "" && search_string != null)
                query = query.Where(w => w.acc_name.Contains(search_string.ToUpper()) || w.acc_code.Contains(search_string.ToUpper()));

            query = query
                .OrderBy(c => c.acc_name);

            var Records = await query
                .ToListAsync();

            RetData.Add("records", Records);

            return RetData;
        }
    }

    public class Lov_acctm : ILov
    {
        public async Task<Dictionary<string, object>> getRecordsAsync(AppDbContext context, Dictionary<string, object> data, int comp_id = 0, string search_string = "")
        {
            Dictionary<string, object> RetData = new Dictionary<string, object>();

            var query = from rec in context.acc_acctm
                        where (rec.rec_company_id == comp_id && rec.acc_row_type == "ACC-CODE")
                        select new
                        {
                            rec.acc_id,
                            rec.acc_code,
                            rec.acc_name,
                            rec.rec_company_id
                        };

            if (search_string != "" && search_string != null)
                query = query.Where(w => w.acc_name.Contains(search_string.ToUpper()) || w.acc_code.Contains(search_string.ToUpper()));

            query = query
                .OrderBy(c => c.acc_name);

            var Records = await query
                .ToListAsync();

            RetData.Add("records", Records);

            return RetData;
        }
    }

    public class Lov_customerm : ILov
    {
        public async Task<Dictionary<string, object>> getRecordsAsync(AppDbContext context, Dictionary<string, object> data, int comp_id = 0, string search_string = "")
        {
            Dictionary<string, object> RetData = new Dictionary<string, object>();

            

            var query = from rec in context.mast_customerm
                        where (rec.rec_company_id == comp_id && rec.cust_row_type == "CUSTOMER")
                        select new
                        {
                            rec.cust_id,
                            rec.cust_code,
                            rec.cust_name,
                            rec.cust_address1,
                            rec.cust_address2,
                            rec.cust_address3,
                            rec.cust_contact,
                            rec.cust_tel,
                            rec.cust_fax,
                            rec.cust_email,
                            rec.cust_nomination,
                            rec.cust_is_parent,
                            rec.rec_company_id
                        };

            if (search_string != "" && search_string != null)
                query = query.Where(w => w.cust_name.Contains(search_string.ToUpper()) || w.cust_code.Contains(search_string.ToUpper()));

            /*
            if(  data.ContainsKey("cust_is_parent"))
            {
                var cust_is_parent = data["cust_is_parent"].ToString();
                query = query.Where(w => w.cust_is_parent == cust_is_parent);
            }
            */
            query = query
                .OrderBy(c => c.cust_name);

            var Records = await query
                .ToListAsync();

            RetData.Add("records", Records);

            return RetData;
        }
    }


    public class Lov_param : ILov
    {
        public async Task<Dictionary<string, object>> getRecordsAsync(AppDbContext context, Dictionary<string, object> data, int comp_id = 0, string search_string = "")
        {
            Dictionary<string, object> RetData = new Dictionary<string, object>();

            string subtable = "";

            if (data.ContainsKey("subtable"))
                subtable = data["subtable"].ToString().ToUpper();

            var query = from rec in context.mast_param
                        where rec.rec_company_id == comp_id && rec.param_type == subtable
                        select new
                        {
                            rec.param_id,
                            rec.param_code,
                            rec.param_name
                        };



            if (search_string != "" && search_string != null)
                query = query.Where(w => w.param_code.Contains(search_string.ToUpper()) || w.param_name.Contains(search_string.ToUpper()));

            query = query
                .OrderBy(c => c.param_name);

            var Records = await query
                .ToListAsync();

            RetData.Add("records", Records);

            return RetData;
        }
    }




}

