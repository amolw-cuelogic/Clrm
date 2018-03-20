using System.Collections.Generic;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;
using System;

namespace Cuelogic.Clrm.Service
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IUserGroupRepository _userGroupRepository;
        public UserGroupService()
        {
            _userGroupRepository = new UserGroupRepository();
        }
        public List<Employee> GetEmployeeList()
        {
            var list = new List<Employee>();
            var ds = _userGroupRepository.GetEmployeeList();
            if (ds.Tables[0].Rows.Count > 0)
                list = ds.Tables[0].ToList<Employee>();
            return list;
        }

        public List<IdentityGroup> GetGroupList()
        {
            var list = new List<IdentityGroup>();
            var ds = _userGroupRepository.GetGroupList();
            if (ds.Tables[0].Rows.Count > 0)
                list = ds.Tables[0].ToList<IdentityGroup>();
            return list;
        }

        public List<Employee> GetIdentityGroupMembers(int gId)
        {
            var list = new List<Employee>();
            var ds = _userGroupRepository.GetIdentityGroupMembers(gId);
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
            _userGroupRepository.InsertGroupUsers(xmlString);
        }
    }
}
