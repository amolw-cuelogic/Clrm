using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IEmployeeRepository
    {
        DataSet GetEmployeeList(SearchParam searchParam);
        EmployeeVm GetMasterListForEmployees();
        Employee GetChildListForEmployees(int employeeId);
        Employee GetEmployee(int employeeId);
        void AddOrUpdateEmployee(EmployeeVm employeeVm, UserContext userContext);
        void MarkEmployeeInvalid(int employeeId, int userId);
    }
}
