using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface ICommonRepository
    {
        Employee GetEmployeeDetails(string emailId);
        string GetEmployeeAllocationList(int employeeId);
        List<IdentityGroupRight> GetGroupRights(int employeeId);
        void LogLoginTime(int employeeId);
    }
}
