using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Employees
{
    public interface IEmployeeRepository
    {
        DataSet GetEmployeeList(SearchParam searchParam);
        EmployeeVm GetMasterListForEmployees();
        Employee GetEmployee(int employeeId);
    }
}
