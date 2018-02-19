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

        public MasterOrganizationRole GetMasterOrganizationRole(int MasterOrganizationRoleId)
        {
            if (MasterOrganizationRoleId != 0)
            {
                var MasterOrganizationRoleDs = _masterOrganizationRoleDataAccess.GetMasterOrganizationRole(MasterOrganizationRoleId);
                var MasterDepartmentObj = MasterOrganizationRoleDs.Tables[0].ToModel<MasterOrganizationRole>();
                return MasterDepartmentObj;
            }
            else
            {
                return new MasterOrganizationRole();
            }
        }

        public DataSet GetMasterOrganizationRoleList(SearchParam objSearchParam)
        {
            var ds = _masterOrganizationRoleDataAccess.GetMasterOrganizationRoleList(objSearchParam);
            return ds;
        }

        public void MarkMasterOrganizationRoleInvalid(int MasterOrganizationRoleId)
        {
            _masterOrganizationRoleDataAccess.MarkMasterOrganizationRoleInvalid(MasterOrganizationRoleId);
        }

        public void SaveMasterOrganizationRole(MasterOrganizationRole ObjMasterOrganizationRole, UserContext userCtx)
        {
            ObjMasterOrganizationRole.CreatedBy = userCtx.UserId;
            ObjMasterOrganizationRole.CreatedOn = DateTime.Now.ToMySqlDateString();
            _masterOrganizationRoleDataAccess.InsertMasterOrganizationRole(ObjMasterOrganizationRole);
        }

        public void UpdateMasterOrganizationRole(MasterOrganizationRole ObjMasterOrganizationRole, UserContext userCtx)
        {
            ObjMasterOrganizationRole.UpdatedBy = userCtx.UserId;
            ObjMasterOrganizationRole.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterOrganizationRoleDataAccess.UpdateMasterOrganizationRole(ObjMasterOrganizationRole);
        }
    }
}
