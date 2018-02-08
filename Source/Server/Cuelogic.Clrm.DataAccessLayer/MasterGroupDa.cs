using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model;
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

        public static DataSet GetIdentityGroupList(SearchParam objSearchParam)
        {
            var RecordFrom = objSearchParam.Page * objSearchParam.Show;
            var RecordTill = RecordFrom + objSearchParam.Show;
            MySqlParameter[] para = new MySqlParameter[] { new MySqlParameter() };
            var ds = DataAccessHelper.ExecuteQuery("spGetIdentityGroupList('" + objSearchParam.FilterText +
                    "','" + RecordFrom + "','" + RecordTill + "')",
                CommandType.Text, //Even though it is store procedure, Command type is text, MySql does not accepts c# command type as storeprocedure
                para);
            return ds;
        }

        public static DataSet GetIdentityGroup(int GroupId)
        {
            var ds = DataAccessHelper.ExecuteQuery("spGetIdentityGroup("+ GroupId + ")", 
                CommandType.Text, null);
            return ds;
        }

        public static DataSet GetIdentityGroupRights(int GroupId)
        {
            var ds = DataAccessHelper.ExecuteQuery("spGetIdentityGroupRights(" + GroupId+")",
                CommandType.Text, null);
            return ds;
        }

    }
}
