using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.Allocations
{
    public interface IAllocationDataAccess
    {
        void AddOrUpdateAllocation(Allocation allocation);
        DataSet GetAllocationList(SearchParam searchParam);
        DataSet GetAllocation(int allocationId);
        DataSet GetAllocationSelectList();
        void MarkAllocationInvalid(int allocationId);
        DataSet GetAllocationSum(int employeeId);
        DataSet GetProjectRolebyId(int projectId);

    }
}
