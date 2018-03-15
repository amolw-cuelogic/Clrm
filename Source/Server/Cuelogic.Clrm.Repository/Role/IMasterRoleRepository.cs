using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Role
{
    public interface IMasterRoleRepository
    {
        DataSet GetMasterProjectRoleList(SearchParam searchParam);
        MasterRole GetMasterProjectRole(int masterProjectRoleId);
        void AddOrUpdateMasterProjectRole(MasterRole masterProjectRole, UserContext userCtx);
        void MarkMasterProjectRoleInvalid(int masterProjectRoleId, int employeeId);
    }
}
