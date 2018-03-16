using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
{
    public interface IMasterDepartmentDataAccess
    {
        DataSet GetMasterDepartmentList(SearchParam searchParam);

        DataSet GetMasterDepartment(int masterDepartmentId);
        
        void UpdateMasterDepartment(MasterDepartment masterDepartment);
        
        void InsertMasterDepartment(MasterDepartment masterDepartment);
        
        void MarkMasterDepartmentInvalid(int masterDepartmentId, int employeeId);
        
    }
}
