using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface IMasterRoleService
    {
        string GetList(SearchParam searchParam);

        MasterRole GetItem(int masterProjectRoleId);

        void Save(MasterRole masterProjectRole, UserContext userCtx);

        void Delete(int masterProjectRoleId, int employeeId);
    }
}
