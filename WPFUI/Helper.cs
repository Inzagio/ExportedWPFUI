using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI
{
    public class Helper
    {
        public static string CnnVal(string UsersDB)
        {
            return ConfigurationManager.ConnectionStrings[UsersDB].ConnectionString;
        }
    }
}
