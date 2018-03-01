using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Common
{
    public interface ICommonService
    {
        Employee GetEmployeeByEmail(string emailId);

        EmployeeVm GetEmployeeById(int employeeId);

        void Save(EmployeeVm employeeVm, UserContext userContext);
        string GetEmployeeAllocationList(int employeeId);

        List<IdentityGroupRight> GetEmployeeRights(int employeeId);
    }
}
