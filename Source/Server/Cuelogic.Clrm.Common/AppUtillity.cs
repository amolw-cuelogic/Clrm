using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Common
{
    public class AppUtillity
    {
        private static string databaseType = null;
        public static string GetTargetDatabase()
        {
            if (string.IsNullOrEmpty(databaseType))
                databaseType = ConfigurationManager.AppSettings[AppConstants.TargetDatabase];
            return databaseType;
        }
    }
}
