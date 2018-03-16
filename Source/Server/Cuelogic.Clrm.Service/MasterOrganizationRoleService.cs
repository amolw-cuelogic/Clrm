using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;

namespace Cuelogic.Clrm.Service
{
    public class MasterOrganizationRoleService : IMasterOrganizationRoleService
    {
        private readonly IMasterOrganizationRoleRepository _masterOrganizationRoleRepository;

        public MasterOrganizationRoleService()
        {
            _masterOrganizationRoleRepository = new MasterOrganizationRoleRepository();
        }
        public void Delete(int masterOrganizationRoleId, int employeeId)
        {
            _masterOrganizationRoleRepository.MarkMasterOrganizationRoleInvalid(masterOrganizationRoleId, employeeId);
        }

        public MasterOrganizationRole GetItem(int masterOrganizationRoleId)
        {
            var masterOrganizationRole = _masterOrganizationRoleRepository.GetMasterOrganizationRole(masterOrganizationRoleId);
            return masterOrganizationRole;
        }

        public string GetList(SearchParam searchParam)
        {
            DataSet ds = _masterOrganizationRoleRepository.GetMasterOrganizationRoleList(searchParam);
            var masterOrganizationRoleJson = ds.Tables[0].ToJsonString();
            return masterOrganizationRoleJson;
        }

        public void Save(MasterOrganizationRole masterOrganizationRole, UserContext userCtx)
        {
            if (masterOrganizationRole.Id == 0)
                _masterOrganizationRoleRepository.SaveMasterOrganizationRole(masterOrganizationRole, userCtx);
            else
                _masterOrganizationRoleRepository.UpdateMasterOrganizationRole(masterOrganizationRole, userCtx);
        }
    }
}
