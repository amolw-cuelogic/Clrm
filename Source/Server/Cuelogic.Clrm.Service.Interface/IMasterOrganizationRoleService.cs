using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface IMasterOrganizationRoleService
    {
        string GetList(SearchParam searchParam);

        MasterOrganizationRole GetItem(int masterOrganizationRoleId);

        void Save(MasterOrganizationRole masterOrganizationRole, UserContext userCtx);

        void Delete(int masterOrganizationRoleId, int employeeId);
    }
}
