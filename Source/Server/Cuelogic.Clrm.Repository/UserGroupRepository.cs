using System;
using System.Collections.Generic;
using System.Linq;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess.MySql;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Repository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly IUserGroupDataAccess _userGroupDataAcces;

        public UserGroupRepository()
        {
            var databaseType = AppUtillity.GetTargetDatabase();
            if (databaseType == DatabaseType.MySql)
                _userGroupDataAcces = new UserGroupDataAccessMySql();
            else
                throw new Exception(CustomError.DbConcreteImplementation);

        }
        public List<Employee> GetEmployeeList()
        {
            var ds = _userGroupDataAcces.GetEmployeeList();
            List<Employee> list = new List<Employee>();
            if (ds.Tables[0].Rows.Count > 0)
                list = ds.Tables[0].ToList<Employee>();
            return list;
        }

        public List<IdentityGroup> GetGroupList()
        {
            var ds = _userGroupDataAcces.GetGroupList();
            List<IdentityGroup> list = new List<IdentityGroup>();
            if (ds.Tables[0].Rows.Count > 0)
                list = ds.Tables[0].ToList<IdentityGroup>();
            return list;
        }

        public List<Employee> GetIdentityGroupMembers(int gId)
        {
            var ds = _userGroupDataAcces.GetIdentityGroupMembers(gId);
            List<Employee> list = new List<Employee>();
            if (ds.Tables[0].Rows.Count > 0)
                list = ds.Tables[0].ToList<Employee>();
            return list;
        }

        public void InsertGroupUsers(List<IdentityEmployeeGroup> identityEmployeeGroup, UserContext userContext)
        {
            foreach (var item in identityEmployeeGroup)
            {
                item.CreatedBy = userContext.UserId;
                item.UpdatedBy = userContext.UserId;
                item.CreatedOn = DateTime.Now.ToMySqlDateString();
                item.UpdatedOn = DateTime.Now.ToMySqlDateString();
            }
            var xmlString = Helper.ObjectToXml(identityEmployeeGroup);
            _userGroupDataAcces.InsertGroupUsers(xmlString);
        }
    }
}
