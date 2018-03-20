using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterRoleRepository
    {
        DataSet GetMasterProjectRoleList(SearchParam searchParam);
        DataSet GetMasterProjectRole(int masterProjectRoleId);
        void AddOrUpdateMasterProjectRole(MasterRole masterProjectRole);
        void MarkMasterProjectRoleInvalid(int masterProjectRoleId, int employeeId);
    }
}
