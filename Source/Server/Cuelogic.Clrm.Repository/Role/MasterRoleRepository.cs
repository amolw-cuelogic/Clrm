using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.DataAccessLayer.Role;

namespace Cuelogic.Clrm.Repository.Role
{
    public class MasterRoleRepository : IMasterRoleRepository
    {
        private readonly IMasterRoleDataAccess _masterProjectRoleDataAccess;
        public MasterRoleRepository()
        {
            _masterProjectRoleDataAccess = new MasterRoleDataAccess();
        }
        public void AddOrUpdateMasterProjectRole(MasterRole masterProjectRole, UserContext userCtx)
        {
            masterProjectRole.CreatedBy = userCtx.UserId;
            masterProjectRole.UpdatedBy = userCtx.UserId;
            masterProjectRole.CreatedOn = DateTime.Now.ToMySqlDateString();
            masterProjectRole.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterProjectRoleDataAccess.AddOrUpdateMasterProjectRole(masterProjectRole);
        }

        public MasterRole GetMasterProjectRole(int masterProjectRoleId)
        {
            if (masterProjectRoleId != 0)
            {
                var ds = _masterProjectRoleDataAccess.GetMasterProjectRole(masterProjectRoleId);
                var masterProjectRole = ds.Tables[0].ToModel<MasterRole>();
                return masterProjectRole;
            }
            else
            {
                return new MasterRole();
            }
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
