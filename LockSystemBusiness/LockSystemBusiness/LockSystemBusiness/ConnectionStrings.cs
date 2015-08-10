using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LockSystemBusiness
{
    public static class ConnectionStrings
    {
        public static string MySqlConnectionString()
        {
            return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MyBusinessCnn"].ConnectionString;
        }
    }
}