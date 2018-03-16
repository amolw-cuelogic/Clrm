using System;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess.MySql;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Repository
{
    public class MasterRoleRepository : IMasterRoleRepository
    {
        private readonly IMasterRoleDataAccess _masterProjectRoleDataAccess;
        public MasterRoleRepository()
        {
            var databaseType = AppUtillity.GetTargetDatabase();
            if (databaseType == DatabaseType.MySql)
                _masterProjectRoleDataAccess = new MasterRoleDataAccessMySql();
            else
                throw new Exception(CustomError.DbConcreteImplementation);

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

        public void MarkMasterProjectRoleInvalid(int masterProjectRoleId, int employeeId)
        {
            _masterProjectRoleDataAccess.MarkMasterProjectRoleInvalid(masterProjectRoleId, employeeId);
        }
    }
}
