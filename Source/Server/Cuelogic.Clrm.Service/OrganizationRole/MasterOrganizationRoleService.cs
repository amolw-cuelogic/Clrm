using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.OrganizationRole;
using System.Data;

namespace Cuelogic.Clrm.Service.OrganizationRole
{
    public class MasterOrganizationRoleService : IMasterOrganizationRoleService
    {
        private readonly IMasterOrganizationRoleRepository _masterOrganizationRoleRepository;

        public MasterOrganizationRoleService()
        {
            _masterOrganizationRoleRepository = new MasterOrganizationRoleRepository();
        }
        public void Delete(int MasterOrganizationRoleId)
        {
            _masterOrganizationRoleRepository.MarkMasterOrganizationRoleInvalid(MasterOrganizationRoleId);
        }

        public MasterOrganizationRole GetItem(int MasterOrganizationRoleId)
        {
            var masterOrganizationRole = _masterOrganizationRoleRepository.GetMasterOrganizationRole(MasterOrganizationRoleId);
            return masterOrganizationRole;
        }

        public string GetList(SearchParam objSearchParam)
        {
            DataSet ds = _masterOrganizationRoleRepository.GetMasterOrganizationRoleList(objSearchParam);
            var masterOrganizationRoleJson = ds.Tables[0].ToJsonString();
            return masterOrganizationRoleJson;
        }

        public void Save(MasterOrganizationRole ObjMasterOrganizationRole, UserContext userCtx)
        {
            if (ObjMasterOrganizationRole.Id == 0)
                _masterOrganizationRoleRepository.SaveMasterOrganizationRole(ObjMasterOrganizationRole, userCtx);
            else
                _masterOrganizationRoleRepository.UpdateMasterOrganizationRole(ObjMasterOrganizationRole, userCtx);
        }
    }
}
