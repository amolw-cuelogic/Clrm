using System.Collections.Generic;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess;
using System.Data;
using Cuelogic.Clrm.Model.CommonModel;

namespace Cuelogic.Clrm.Repository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly IDataAccess _dataAccess;

        public UserGroupRepository()
        {
            _dataAccess = new MySqlDataAccess();

        }
        public DataSet GetEmployeeList()
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.UserGroup_GetEmployees;
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetGroupList()
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.UserGroup_GetIdentityGroup;
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetIdentityGroupMembers(int gId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.UserGroup_GetIdentityGroupMembers;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@gId", Value= gId },
            });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void InsertGroupUsers(string xmlString)
        {
            
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.UserGroup_InsertGroupUser;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@xmlText", Value= xmlString },
            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }
    }
}
