using System.Collections.Generic;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;

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
            var data = _userGroupRepository.GetEmployeeList();
            return data;
        }

        public List<IdentityGroup> GetGroupList()
        {
            var data = _userGroupRepository.GetGroupList();
            return data;
        }

        public List<Employee> GetIdentityGroupMembers(int gId)
        {
            var data = _userGroupRepository.GetIdentityGroupMembers(gId);
            return data;
        }

        public void InsertGroupUsers(List<IdentityEmployeeGroup> identityEmployeeGroup, UserContext userContext)
        {
            _userGroupRepository.InsertGroupUsers(identityEmployeeGroup, userContext);
        }
    }
}
