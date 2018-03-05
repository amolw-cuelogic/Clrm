using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.ProjectRole;

namespace Cuelogic.Clrm.Service.ProjectRole
{
    public class MasterProjectRoleService : IMasterProjectRoleService
    {
        private readonly IMasterProjectRoleRepository _projectRoleRepository;
        public MasterProjectRoleService()
        {
            _projectRoleRepository = new MasterProjectRoleRepository();
        }
        public void Delete(int masterProjectRoleId)
        {
            _projectRoleRepository.MarkMasterProjectRoleInvalid(masterProjectRoleId);
        }

        public MasterProjectRole GetItem(int masterProjectRoleId)
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

        public void Save(MasterProjectRole masterProjectRole, UserContext userCtx)
        {
            _projectRoleRepository.AddOrUpdateMasterProjectRole(masterProjectRole, userCtx);
        }
    }
}
