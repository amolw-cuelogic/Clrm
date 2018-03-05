using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.ProjectRole
{
    public interface IMasterProjectRoleDataAccess
    {
        DataSet GetMasterProjectRoleList(SearchParam searchParam);

        DataSet GetMasterProjectRole(int masterProjectRoleId);

        void AddOrUpdateMasterProjectRole(MasterProjectRole masterProjectRole);
        void MarkMasterProjectRoleInvalid(int masterProjectRoleId);
    }
}
