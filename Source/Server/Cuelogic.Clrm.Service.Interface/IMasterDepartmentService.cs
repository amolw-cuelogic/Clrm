using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface IMasterDepartmentService
    {
        string GetList(SearchParam searchParam);

        MasterDepartment GetItem(int departmentId);

        void Save(MasterDepartment masterDepartment, UserContext userCtx);

        void Delete(int departmentId, int employeeId);
    }
}
