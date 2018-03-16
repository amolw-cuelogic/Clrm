using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface IEmployeeService
    {
        string GetList(SearchParam searchParam);
        EmployeeVm GetItem(int employeeId);
        void Save(EmployeeVm employeeVm, UserContext userCtx);
        void Delete(int employeeId, int userId);
    }
}
