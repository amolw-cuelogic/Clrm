using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterGroupRepository
    {
        DataSet GetIdentityGroupList(SearchParam searchParam);

        DataSet GetGroup(int groupId);
        DataSet GetIdentityGroupRights(int groupId);
        DataSet GetIdentityRightList();

        DataSet SaveIdentityGroup(IdentityGroup identityGroup);
        void SaveIdentityGroupRight(string xmlString);

        void UpdateIdentityGroup(IdentityGroup identityGroup);
        void UpdateIdentityGroupRight(string xmlString);

        void MarkGroupInvalid(int groupId, int employeeId);
    }
}
