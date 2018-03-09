using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.UserGroup;
using Cuelogic.Clrm.Common;

namespace Cuelogic.Clrm.Service.UserGroup
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IUserGroupRepository _userGroupRepository;
        public UserGroupService()
        {
            _userGroupRepository = new UserGroupRepository();
        }
        public List<Employee> GetEmployeeList(string employeeName)
        {
            var data = _userGroupRepository.GetEmployeeList(employeeName);
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
