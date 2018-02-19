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
        DataSet GetMasterOrganizationRoleList(SearchParam objSearchParam);

        DataSet GetMasterOrganizationRole(int MasterOrganizationRoleId);

        void UpdateMasterOrganizationRole(MasterOrganizationRole ObjMasterOrganizationRole);

        void InsertMasterOrganizationRole(MasterOrganizationRole ObjMasterOrganizationRole);

        void MarkMasterOrganizationRoleInvalid(int MasterOrganizationRoleId);
    }
}
