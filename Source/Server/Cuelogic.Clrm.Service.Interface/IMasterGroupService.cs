using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface IMasterGroupService
    {
        string GetList(SearchParam searchParam);

        IdentityGroup GetItem(int groupId);

        void Save(IdentityGroup identityGroup, UserContext userCtx);

        void Delete(int groupId, int employeeId);

    }
}
