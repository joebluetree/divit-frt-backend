using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Lib.Interfaces
{
    public interface IHeaderRepository
    {
        void init();

        void AddHeader(string key, string value);
        IDictionary<string, string> GetHeaders();
    }
}
