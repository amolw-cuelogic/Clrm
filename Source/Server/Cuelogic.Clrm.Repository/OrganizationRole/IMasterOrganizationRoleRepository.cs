using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.OrganizationRole
{
    public interface IMasterOrganizationRoleRepository
    {
        DataSet GetMasterOrganizationRoleList(SearchParam searchParam);

        MasterOrganizationRole GetMasterOrganizationRole(int masterOrganizationRoleId);

        void SaveMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole, UserContext userCtx);

        void UpdateMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole, UserContext userCtx);

        void MarkMasterOrganizationRoleInvalid(int masterOrganizationRoleId);
    }
}
