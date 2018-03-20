using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterOrganizationRoleRepository
    {
        DataSet GetMasterOrganizationRoleList(SearchParam searchParam);

        DataSet GetMasterOrganizationRole(int masterOrganizationRoleId);

        void SaveMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole, UserContext userCtx);

        void UpdateMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole, UserContext userCtx);

        void MarkMasterOrganizationRoleInvalid(int masterOrganizationRoleId, int employeeId);
    }
}
