using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Service.Interface
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
