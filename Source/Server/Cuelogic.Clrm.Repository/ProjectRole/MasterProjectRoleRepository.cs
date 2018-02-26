using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.DataAccessLayer.ProjectRole;

namespace Cuelogic.Clrm.Repository.ProjectRole
{
    public class MasterProjectRoleRepository : IMasterProjectRoleRepository
    {
        private readonly IMasterProjectRoleDataAccess _masterProjectRoleDataAccess;
        public MasterProjectRoleRepository()
        {
            _masterProjectRoleDataAccess = new MasterProjectRoleDataAccess();
        }
        public void AddOrUpdateMasterProjectRole(MasterProjectRole masterProjectRole, UserContext userCtx)
        {
            masterProjectRole.CreatedBy = userCtx.UserId;
            masterProjectRole.UpdatedBy = userCtx.UserId;
            masterProjectRole.CreatedOn = DateTime.Now.ToMySqlDateString();
            masterProjectRole.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterProjectRoleDataAccess.AddOrUpdateMasterProjectRole(masterProjectRole);
        }

        public MasterProjectRole GetMasterProjectRole(int masterProjectRoleId)
        {
            var ds = _masterProjectRoleDataAccess.GetMasterProjectRole(masterProjectRoleId);
            var masterProjectRole = ds.Tables[0].ToModel<MasterProjectRole>();
            return masterProjectRole;
        }

        public DataSet GetMasterProjectRoleList(SearchParam searchParam)
        {
            var ds = _masterProjectRoleDataAccess.GetMasterProjectRoleList(searchParam);
            return ds;
        }

        public void MarkMasterProjectRoleInvalid(int masterProjectRoleId)
        {
            _masterProjectRoleDataAccess.MarkMasterProjectRoleInvalid(masterProjectRoleId);
        }
    }
}
