using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Allocations
{
    public interface IAllocationService
    {
        string GetList(SearchParam searchParam);

        Allocation GetItem(int allocationId);

        void Save(Allocation allocation, UserContext userCtx);

        void Delete(int allocationId,int employeeId);
        int GetAllocationSum(int employeeId);
        List<MasterRole> GetProjectRolebyId(int projectId);
    }
}
