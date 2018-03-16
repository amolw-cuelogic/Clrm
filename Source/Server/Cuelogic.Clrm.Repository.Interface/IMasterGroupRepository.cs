using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterGroupRepository
    {
        DataSet GetIdentityGroupList(SearchParam searchParam);

        IdentityGroup GetGroup(int groupId);

        void SaveIdentityGroup(IdentityGroup identityGroup, UserContext userCtx);

        void UpdateIdentityGroup(IdentityGroup identityGroup, UserContext userCtx);

        void MarkGroupInvalid(int groupId, int employeeId);
    }
}
