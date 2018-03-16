using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterDepartmentRepository
    {
        DataSet GetMasterDepartmentList(SearchParam searchParam);
        MasterDepartment GetMasterDepartment(int masterDepartmentId);
        void SaveMasterDepartment(MasterDepartment masterDepartment, UserContext userCtx);
        void UpdateMasterDepartment(MasterDepartment masterDepartment, UserContext userCtx);
        void MarkMasterDepartmentInvalid(int masterDepartmentId, int employeeId);
    }
}
