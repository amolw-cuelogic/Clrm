using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;

namespace Cuelogic.Clrm.Service
{
    public class MasterRoleService : IMasterRoleService
    {
        private readonly IMasterRoleRepository _projectRoleRepository;
        public MasterRoleService()
        {
            _projectRoleRepository = new MasterRoleRepository();
        }
        public void Delete(int masterProjectRoleId, int employeeId)
        {
            _projectRoleRepository.MarkMasterProjectRoleInvalid(masterProjectRoleId, employeeId);
        }

        public MasterRole GetItem(int masterProjectRoleId)
        {
            var masterProjectRole = _projectRoleRepository.GetMasterProjectRole(masterProjectRoleId);
            return masterProjectRole;
        }

        public string GetList(SearchParam searchParam)
        {
            var ds = _projectRoleRepository.GetMasterProjectRoleList(searchParam);
            var jsonString = ds.Tables[0].ToJsonString();
            return jsonString;
        }

        public void Save(MasterRole masterProjectRole, UserContext userCtx)
        {
            _projectRoleRepository.AddOrUpdateMasterProjectRole(masterProjectRole, userCtx);
        }
    }
}
