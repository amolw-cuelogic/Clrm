using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IUserGroupRepository
    {
        List<IdentityGroup> GetGroupList();
        List<Employee> GetEmployeeList();
        List<Employee> GetIdentityGroupMembers(int gId);
        void InsertGroupUsers(List<IdentityEmployeeGroup> identityEmployeeGroup, UserContext userContext);
    }
}
