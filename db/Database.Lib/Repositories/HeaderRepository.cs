using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Database.Lib.Interfaces;


namespace Database.Lib.Repositories
{
    public class HeaderRepository : IHeaderRepository
    {
        private readonly IDictionary<string, string> _headers = new Dictionary<string, string>();

        public void init()
        {
            this._headers.Clear();
        }
        public void AddHeader(string key, string value)
        {
            if (!_headers.ContainsKey(key))
            {
                _headers[key] = value;
            }
        }

        public IDictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string>(_headers);
        }
    }

}
