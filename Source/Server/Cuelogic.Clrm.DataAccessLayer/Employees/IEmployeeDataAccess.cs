using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.Employees
{
    public interface IEmployeeDataAccess
    {
        DataSet GetEmployeeList(SearchParam searchParam);

        DataSet GetMasterListForEmployees();

        DataSet GetEmployee(int employeeId);

        void UpdateEmployee(Employee employee);
    }
}
