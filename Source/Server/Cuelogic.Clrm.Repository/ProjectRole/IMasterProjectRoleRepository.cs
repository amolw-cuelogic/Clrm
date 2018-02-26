using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.ProjectRole
{
    public interface IMasterProjectRoleRepository
    {
        DataSet GetMasterProjectRoleList(SearchParam searchParam);
        MasterProjectRole GetMasterProjectRole(int masterProjectRoleId);
        void AddOrUpdateMasterProjectRole(MasterProjectRole masterProjectRole, UserContext userCtx);
        void MarkMasterProjectRoleInvalid(int masterProjectRoleId);
    }
}
