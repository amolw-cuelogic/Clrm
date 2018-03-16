using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface IUserGroupService
    {
        List<IdentityGroup> GetGroupList();
        List<Employee> GetEmployeeList();
        List<Employee> GetIdentityGroupMembers(int gId);
        void InsertGroupUsers(List<IdentityEmployeeGroup> identityEmployeeGroup, UserContext userContext);
    }
}
