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
    public class MasterOrganizationRoleRepository : IMasterOrganizationRoleRepository
    {
        private readonly IMasterOrganizationRoleDataAccess _masterOrganizationRoleDataAccess;

        public MasterOrganizationRoleRepository()
        {
            var databaseType = AppUtillity.GetTargetDatabase();
            if (databaseType == DatabaseType.MySql)
                _masterOrganizationRoleDataAccess = new MasterOrganizationRoleDataAccessMySql();
            else
                throw new Exception(CustomError.DbConcreteImplementation);
        }

        public MasterOrganizationRole GetMasterOrganizationRole(int masterOrganizationRoleId)
        {
            if (masterOrganizationRoleId != 0)
            {
                var masterOrganizationRoleDs = _masterOrganizationRoleDataAccess.GetMasterOrganizationRole(masterOrganizationRoleId);
                var masterDepartment = masterOrganizationRoleDs.Tables[0].ToModel<MasterOrganizationRole>();
                return masterDepartment;
            }
            else
            {
                return new MasterOrganizationRole();
            }
        }

        public DataSet GetMasterOrganizationRoleList(SearchParam searchParam)
        {
            var ds = _masterOrganizationRoleDataAccess.GetMasterOrganizationRoleList(searchParam);
            return ds;
        }

        public void MarkMasterOrganizationRoleInvalid(int masterOrganizationRoleId, int employeeId)
        {
            _masterOrganizationRoleDataAccess.MarkMasterOrganizationRoleInvalid(masterOrganizationRoleId, employeeId);
        }

        public void SaveMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole, UserContext userCtx)
        {
            masterOrganizationRole.CreatedBy = userCtx.UserId;
            masterOrganizationRole.CreatedOn = DateTime.Now.ToMySqlDateString();
            _masterOrganizationRoleDataAccess.InsertMasterOrganizationRole(masterOrganizationRole);
        }

        public void UpdateMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole, UserContext userCtx)
        {
            masterOrganizationRole.UpdatedBy = userCtx.UserId;
            masterOrganizationRole.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterOrganizationRoleDataAccess.UpdateMasterOrganizationRole(masterOrganizationRole);
        }
    }
}
