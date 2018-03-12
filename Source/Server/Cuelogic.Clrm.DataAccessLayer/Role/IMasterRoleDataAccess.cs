using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.Role
{
    public interface IMasterRoleDataAccess
    {
        DataSet GetMasterProjectRoleList(SearchParam searchParam);

        DataSet GetMasterProjectRole(int masterProjectRoleId);

        void AddOrUpdateMasterProjectRole(MasterRole masterProjectRole);
        void MarkMasterProjectRoleInvalid(int masterProjectRoleId);
    }
}
