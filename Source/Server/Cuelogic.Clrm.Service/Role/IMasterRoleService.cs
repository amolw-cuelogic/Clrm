using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.ProjectRole
{
    public interface IMasterRoleService
    {
        string GetList(SearchParam searchParam);

        MasterRole GetItem(int masterProjectRoleId);

        void Save(MasterRole masterProjectRole, UserContext userCtx);

        void Delete(int masterProjectRoleId, int employeeId);
    }
}
