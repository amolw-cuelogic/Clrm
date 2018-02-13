using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
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
            var ds = DataAccessHelper.ExecuteQuery("spGetIdentityGroupList('" + objSearchParam.FilterText +
                    "','" + RecordFrom + "','" + RecordTill + "')");
            return ds;
        }

        public static DataSet GetIdentityGroup(int GroupId)
        {
            var ds = DataAccessHelper.ExecuteQuery("spGetIdentityGroup(" + GroupId + ")");
            return ds;
        }

        public static DataSet GetIdentityGroupRights(int GroupId)
        {
            var ds = DataAccessHelper.ExecuteQuery("spGetIdentityGroupRights(" + GroupId + ")");
            return ds;
        }

        public static void UpdateIdentityGroup(IdentityGroup ObjIdentityGroup)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = "spUpdateIdentityGroup";

            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                new MySqlParameter("@GroupId", ObjIdentityGroup.Id),
                new MySqlParameter("@grpn", ObjIdentityGroup.GroupName),
                new MySqlParameter("@groupdesc", ObjIdentityGroup.GroupDescription),
                new MySqlParameter("@valid", ObjIdentityGroup.IsValid),
                new MySqlParameter("@updatedby", ObjIdentityGroup.UpdatedBy),
                new MySqlParameter("@updatedon", ObjIdentityGroup.UpdatedOn)
            };
            
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

    }
}
