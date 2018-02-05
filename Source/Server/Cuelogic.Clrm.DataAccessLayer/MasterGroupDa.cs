using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer
{
    public class MasterGroupDa
    {

        public static DataSet GetIdentityGroupList()
        {
            MySqlParameter[] para = new MySqlParameter[] { new MySqlParameter() };
            var ds = DataAccessHelper.ExecuteQuery(
                "select * from IdentityGroup",
                CommandType.Text,
                null);
            return ds;
        }
    }
}
