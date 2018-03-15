using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.OrganizationRole
{
    public interface IMasterOrganizationRoleService
    {
        string GetList(SearchParam searchParam);

        MasterOrganizationRole GetItem(int masterOrganizationRoleId);

        void Save(MasterOrganizationRole masterOrganizationRole, UserContext userCtx);

        void Delete(int masterOrganizationRoleId, int employeeId);
    }
}
