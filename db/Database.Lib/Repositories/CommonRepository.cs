using Microsoft.EntityFrameworkCore;
using Database.Lib.Interfaces;

using System.Reflection.Metadata.Ecma335;
using Database.Models.TnT;
using Database.Models.UserAdmin;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.JsonPatch.Helpers;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql;
using System.Xml.Linq;
using Database.Models.Masters;


namespace Database.Lib.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly AppDbContext context;
        public CommonRepository(AppDbContext _context)
        {
            this.context = _context;
        }
        public async Task<Dictionary<string, object>> GetListAsync(Dictionary<string, object> data)
        {
            try
            {
                Dictionary<string, object> RetData = new Dictionary<string, object>();

                int comp_id = 0;
                var search_string = "";
                var table = "";

                if (data.ContainsKey("company_id"))
                    comp_id = int.Parse(data["company_id"].ToString()!);
                if (data.ContainsKey("search_string"))
                    search_string = data["search_string"].ToString();
                if (data.ContainsKey("table"))
                    table = data["table"].ToString();

                //if (data["table"].ToString() == "modulem" )
                //  RetData = await getModuleRecords(data, comp_id, search_string);

                ILov mObj = (ILov)Lib.createObject("Database.Lib.Repositories.Lov_" + table!.ToLower());
                RetData = await mObj.getRecordsAsync(context, data, comp_id, search_string!);


                return RetData;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }


        public async Task<long> GetSequenceAsync(string name)
        {
            string seqName = "";
            if (name.ToUpper() == "MASTER")
                seqName = "master_sequence";

            // Define the SQL query to get the next value from the sequence
            string sql = $"SELECT nextval('{seqName}')";

            // Create a connection and command to execute the query
            using (var connection = context.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    var retValue = await command.ExecuteScalarAsync();

                    return (long)(retValue ?? 0); // Cast result to long and handle null
                }
            }
        }

        public int _GetSequenceAsync1(string name)
        {
            string seqName = "";
            if (name.ToUpper() == "MASTER")
                seqName = "mastersequence";


            /*
                var p = new SqlParameter("@result", System.Data.SqlDbType.Int);
                p.Direction = System.Data.ParameterDirection.Output;
                string sql = "SET @result = NEXT VALUE FOR " + seqName;
                context.Database.ExecuteSqlRaw(sql, p);
                var nextVal = (int)p.Value;
            */

            //string sql = $"SELECT nextval(public.\"{seqName}\")";
            string sql = $"SELECT nextval('{seqName}') AS Value";

            // Extract and return the value
            return 0;


        }


        public async Task<DataContainer> GetParamSettings(int id, string caption = "")
        {
            try
            {
                IQueryable<mast_settings> query = context.mast_settings;
                query = query.Where(f => f.param_id == id);
                if (caption != "")
                    query = query.Where(f => f.caption == caption);

                var records = await query.ToListAsync();

                DataContainer dc = new DataContainer();
                foreach (mast_settings record in records)
                {
                    dc = dc.Set(record.caption!, record.value!);
                }

                return dc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataContainer> GetCompanySettings(int id, string caption = "")
        {
            try
            {
                IQueryable<mast_settings> query = context.mast_settings;
                query = query.Where(f => f.category == "COMPANY-SETTINGS" && f.rec_company_id == id);
                if (caption != "")
                    query = query.Where(f => f.caption == caption);

                var records = await query.ToListAsync();

                DataContainer dc = new DataContainer();
                foreach (mast_settings record in records)
                {
                    dc = dc.Set(record.caption!, record.value!);
                }

                return dc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataContainer> GetBranchSettings(int id, string caption = "")
        {
            try
            {
                IQueryable<mast_settings> query = context.mast_settings;
                query = query.Where(f => f.category == "BRANCH-SETTINGS" && f.rec_company_id == id);
                if (caption != "")
                    query = query.Where(f => f.caption == caption);

                var records = await query.ToListAsync();

                DataContainer dc = new DataContainer();
                foreach (mast_settings record in records)
                {
                    dc = dc.Set(record.caption!, record.value!);
                }

                return dc;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<mast_customerm> GetCustomerAsync(int id)
        {
            try
            {
                IQueryable<mast_customerm> query = context.mast_customerm;
                query = query.Where(f => f.cust_id == id);

                var Record = await query.Select(e => new mast_customerm
                {
                    cust_id = e.cust_id,
                    cust_code = e.cust_code,
                    cust_name = e.cust_name,
                    cust_address1 = e.cust_address1,
                    cust_address2 = e.cust_address2,
                    cust_address3 = e.cust_address3,
                    cust_contact = e.cust_contact,
                    cust_tel = e.cust_tel,
                    cust_fax = e.cust_fax,
                    cust_email = e.cust_email,
                    cust_nomination = e.cust_nomination,
                    cust_is_parent = e.cust_is_parent,
                    cust_chb_id = e.cust_chb_id,
                    rec_company_id = e.rec_company_id
                }).FirstOrDefaultAsync();

                return Record!;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message.ToString());
            }
        }




    }




    //End Class
}

