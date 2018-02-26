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
    public interface IMasterProjectRoleService
    {
        string GetList(SearchParam searchParam);

        MasterProjectRole GetItem(int masterProjectRoleId);

        void Save(MasterProjectRole masterProjectRole, UserContext userCtx);

        void Delete(int masterProjectRoleId);
    }
}
