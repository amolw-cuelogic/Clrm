using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
{
    public interface IMasterOrganizationRoleDataAccess
    {
        DataSet GetMasterOrganizationRoleList(SearchParam SearchParam);

        DataSet GetMasterOrganizationRole(int masterOrganizationRoleId);

        void UpdateMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole);

        void InsertMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole);

        void MarkMasterOrganizationRoleInvalid(int masterOrganizationRoleId, int employeeId);
    }
}
