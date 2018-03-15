using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Group
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
