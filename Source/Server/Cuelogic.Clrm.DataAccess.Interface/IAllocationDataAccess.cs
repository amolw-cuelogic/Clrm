using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
{
    public interface IAllocationDataAccess
    {
        void AddOrUpdateAllocation(Allocation allocation);
        DataSet GetAllocationList(SearchParam searchParam);
        DataSet GetAllocation(int allocationId);
        DataSet GetAllocationSelectList();
        void MarkAllocationInvalid(int allocationId, int employeeId);
        DataSet GetAllocationSum(int employeeId);
        DataSet GetProjectRolebyId(int projectId);

    }
}
