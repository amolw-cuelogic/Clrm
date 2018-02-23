using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Employees
{
    public interface IEmployeeService
    {
        string GetList(SearchParam searchParam);
        EmployeeVm GetItem(int employeeId);
        void Save(EmployeeVm employeeVm, UserContext userCtx);
        void Delete(int employeeId);
    }
}
