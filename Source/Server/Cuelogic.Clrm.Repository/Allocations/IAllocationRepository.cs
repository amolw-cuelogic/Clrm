using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Allocations
{
    public interface IAllocationRepository
    {
        void AddOrUpdateAllocation(Allocation allocation, UserContext userContext);
        DataSet GetAllocationList(SearchParam searchParam);
        Allocation GetAllocation(int allocationId);
        void MarkAllocationInvalid(int allocationId);
        int GetAllocationSum(int employeeId);
    }
}
