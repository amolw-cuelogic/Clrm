using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.OrganizationRole
{
    public interface IMasterOrganizationRoleDataAccess
    {
        DataSet GetMasterOrganizationRoleList(SearchParam SearchParam);

        DataSet GetMasterOrganizationRole(int masterOrganizationRoleId);

        void UpdateMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole);

        void InsertMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole);

        void MarkMasterOrganizationRoleInvalid(int masterOrganizationRoleId);
    }
}
