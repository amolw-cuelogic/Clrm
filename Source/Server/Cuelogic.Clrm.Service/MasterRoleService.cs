using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;
using System;

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

            if (masterProjectRoleId != 0)
            {
                var ds = _projectRoleRepository.GetMasterProjectRole(masterProjectRoleId);
                var masterProjectRole = ds.Tables[0].ToModel<MasterRole>();
                return masterProjectRole;
            }
            else
            {
                return new MasterRole();
            }
        }

        public string GetList(SearchParam searchParam)
        {
            var ds = _projectRoleRepository.GetMasterProjectRoleList(searchParam);
            var jsonString = ds.Tables[0].ToJsonString();
            return jsonString;
        }

        public void Save(MasterRole masterProjectRole, UserContext userCtx)
        {
            masterProjectRole.CreatedBy = userCtx.UserId;
            masterProjectRole.UpdatedBy = userCtx.UserId;
            masterProjectRole.CreatedOn = DateTime.Now.ToMySqlDateString();
            masterProjectRole.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _projectRoleRepository.AddOrUpdateMasterProjectRole(masterProjectRole);
        }
    }
}
