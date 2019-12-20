using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace StakeCamp
{
    static class GirlCampDBConfiguration
    {
        private readonly static string dbConnectionString;
        private readonly static string dbProviderName;
        static GirlCampDBConfiguration()
        {
            dbConnectionString = ConfigurationManager.ConnectionStrings["girlsCampConnectionString3"].ConnectionString;
            dbProviderName = ConfigurationManager.ConnectionStrings["girlsCampConnectionString3"].ProviderName;
              
        }

        public static string DbConnectionString
        {
            get
            {
                return dbConnectionString;
            }
        }

        public static string DbProviderName
        {
            get
            {
                return dbProviderName;
            }
        }
    }
}
