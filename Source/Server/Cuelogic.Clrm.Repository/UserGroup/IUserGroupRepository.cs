using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.UserGroup
{
    public interface IUserGroupRepository
    {
        List<IdentityGroup> GetGroupList();
        List<Employee> GetEmployeeList(string employeeName);
        List<Employee> GetIdentityGroupMembers(int gId);
        void InsertGroupUsers(List<IdentityEmployeeGroup> identityEmployeeGroup, UserContext userContext);
    }
}
