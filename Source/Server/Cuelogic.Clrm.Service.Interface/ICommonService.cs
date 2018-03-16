using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface ICommonService
    {
        Employee GetEmployeeByEmail(string emailId);

        EmployeeVm GetEmployeeById(int employeeId);

        void Save(EmployeeVm employeeVm, UserContext userContext);
        string GetEmployeeAllocationList(int employeeId);

        List<IdentityGroupRight> GetEmployeeRights(int employeeId);
        void LogLoginTime(int employeeId);
    }
}
