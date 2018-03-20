using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IAllocationRepository
    {
        void AddOrUpdateAllocation(Allocation allocation, UserContext userContext);
        DataSet GetAllocationList(SearchParam searchParam);
        DataSet GetAllocation(int allocationId);
        void MarkAllocationInvalid(int allocationId, int employeeId);
        DataSet GetAllocationSum(int employeeId);
        DataSet GetProjectRolebyId(int projectId);
        DataSet GetAllocationSelectList();
    }
}
