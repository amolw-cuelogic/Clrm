using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterRoleRepository
    {
        DataSet GetMasterProjectRoleList(SearchParam searchParam);
        MasterRole GetMasterProjectRole(int masterProjectRoleId);
        void AddOrUpdateMasterProjectRole(MasterRole masterProjectRole, UserContext userCtx);
        void MarkMasterProjectRoleInvalid(int masterProjectRoleId, int employeeId);
    }
}
