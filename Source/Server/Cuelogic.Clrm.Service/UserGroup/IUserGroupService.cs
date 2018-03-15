using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.UserGroup
{
    public interface IUserGroupService
    {
        List<IdentityGroup> GetGroupList();
        List<Employee> GetEmployeeList();
        List<Employee> GetIdentityGroupMembers(int gId);
        void InsertGroupUsers(List<IdentityEmployeeGroup> identityEmployeeGroup, UserContext userContext);
    }
}
