using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Department;
using Cuelogic.Clrm.DataAccessLayer.OrganizationRole;

namespace Cuelogic.Clrm.Repository.OrganizationRole
{
    public class MasterOrganizationRoleRepository : IMasterOrganizationRoleRepository
    {
        private readonly IMasterOrganizationRoleDataAccess _masterOrganizationRoleDataAccess;

        public MasterOrganizationRoleRepository()
        {
            _masterOrganizationRoleDataAccess = new MasterOrganizationRoleDataAccess();
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

        public void MarkMasterOrganizationRoleInvalid(int masterOrganizationRoleId)
        {
            _masterOrganizationRoleDataAccess.MarkMasterOrganizationRoleInvalid(masterOrganizationRoleId);
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
