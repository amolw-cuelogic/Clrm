using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Role;

namespace Cuelogic.Clrm.Service.ProjectRole
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
