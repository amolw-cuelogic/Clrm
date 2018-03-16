using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
{
    public interface IMasterRoleDataAccess
    {
        DataSet GetMasterProjectRoleList(SearchParam searchParam);

        DataSet GetMasterProjectRole(int masterProjectRoleId);

        void AddOrUpdateMasterProjectRole(MasterRole masterProjectRole);
        void MarkMasterProjectRoleInvalid(int masterProjectRoleId, int employeeId);
        

    }
}
