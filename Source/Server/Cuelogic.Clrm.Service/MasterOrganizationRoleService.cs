using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;
using System;

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

            if (masterOrganizationRoleId != 0)
            {
                var masterOrganizationRoleDs = _masterOrganizationRoleRepository.GetMasterOrganizationRole(masterOrganizationRoleId);
                var masterDepartment = masterOrganizationRoleDs.Tables[0].ToModel<MasterOrganizationRole>();
                return masterDepartment;
            }
            else
            {
                return new MasterOrganizationRole();
            }
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
            {
                masterOrganizationRole.CreatedBy = userCtx.UserId;
                masterOrganizationRole.CreatedOn = DateTime.Now.ToMySqlDateString();
                _masterOrganizationRoleRepository.SaveMasterOrganizationRole(masterOrganizationRole);
            }
            else
            {
                masterOrganizationRole.UpdatedBy = userCtx.UserId;
                masterOrganizationRole.UpdatedOn = DateTime.Now.ToMySqlDateString();
                _masterOrganizationRoleRepository.UpdateMasterOrganizationRole(masterOrganizationRole);
            }
        }
    }
}
