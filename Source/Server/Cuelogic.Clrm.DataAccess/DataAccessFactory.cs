using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cuelogic.Clrm.Common.AppConstants;
using static Cuelogic.Clrm.Common.CustomException;

namespace Cuelogic.Clrm.DataAccess
{
    public class DataAccessFactory
    {
        public static IDataAccess GetDataAccess()
        {
            IDataAccess dataAccess = null;
            var databaseType = AppUtillity.GetTargetDatabase();
            switch (databaseType)
            {
                case DatabaseType.MySql:
                    dataAccess = new MySqlDataAccess();
                    break;
                default:
                    throw new ClientWarning(CustomError.NoConcreteImplementation);
            }
            return dataAccess;
        }

    }
}
