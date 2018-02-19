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
        DataSet GetMasterOrganizationRoleList(SearchParam objSearchParam);

        MasterOrganizationRole GetMasterOrganizationRole(int MasterOrganizationRoleId);

        void SaveMasterOrganizationRole(MasterOrganizationRole ObjMasterOrganizationRole, UserContext userCtx);

        void UpdateMasterOrganizationRole(MasterOrganizationRole ObjMasterOrganizationRole, UserContext userCtx);

        void MarkMasterOrganizationRoleInvalid(int MasterOrganizationRoleId);
    }
}
