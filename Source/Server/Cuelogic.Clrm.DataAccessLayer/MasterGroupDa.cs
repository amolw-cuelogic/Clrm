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
            var ds = DataAccessHelper.ExecuteQuery("spGetIdentityGroupList",
                CommandType.Text, //Even though it is store procedure, Command type is text, MySql does not accepts c# command type as storeprocedure
                null);
            return ds;
        }
    }
}
