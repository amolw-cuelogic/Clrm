using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.Model.CommonModel;
using MySql.Data.MySqlClient;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.MySql
{
    public class UserGroupDataAccessMySql : IUserGroupDataAccess
    {
        public DataSet GetEmployeeList()
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.UserGroup_GetEmployees;
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand());
            return ds;
        }

        public DataSet GetGroupList()
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.UserGroup_GetIdentityGroup;
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand());
            return ds;
        }

        public DataSet GetIdentityGroupMembers(int gId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.UserGroup_GetIdentityGroupMembers;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@gId", gId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public void InsertGroupUsers(string xmlString)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.UserGroup_InsertGroupUser;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmlText", xmlString)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
        }
    }
}
