using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Api.Tests.DataAccess
{
    public class CommonDataAccess
    {
        public static int GetAllocationFirstRowId()
        {
            var query = "SELECT Id FROM CuelogicResourceManagement.Allocation limit 0,1";
            var ds = DataAccessHelper.ExecuteQuery(query);
            var id = ds.Tables[0].ToId();
            return id;
        }
    }
}
