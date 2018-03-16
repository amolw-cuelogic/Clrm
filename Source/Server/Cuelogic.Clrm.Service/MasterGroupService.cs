using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository;
using System;
using System.Data;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using static Cuelogic.Clrm.Common.AppConstants;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Service.Interface;

namespace Cuelogic.Clrm.Service
{
    public class MasterGroupService : IMasterGroupService
    {
        private readonly IMasterGroupRepository _masterGroupRepository;
        public MasterGroupService()
        {
            _masterGroupRepository = new MasterGroupRepository();
        }
        public string GetList(SearchParam searchParam)
        {
            DataSet ds = _masterGroupRepository.GetIdentityGroupList(searchParam);
            var identityGroupJson = ds.Tables[0].ToJsonString();
            return identityGroupJson;

        }

        public IdentityGroup GetItem(int groupId)
        {
            var grp = _masterGroupRepository.GetGroup(groupId);
            return grp;

        }

        public void Save(IdentityGroup identityGroup, UserContext userCtx)
        {
            if (identityGroup.Id == 0)
                _masterGroupRepository.SaveIdentityGroup(identityGroup, userCtx);
            else
            {
                if (userCtx.Rights.Count > 0 && identityGroup.GroupRight.Count > 0)
                {
                    if (userCtx.Rights[0].GroupId == identityGroup.GroupRight[0].GroupId)
                        throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "You cannot edit your own rights, please contact Super Admin or database expert"));
                }
                _masterGroupRepository.UpdateIdentityGroup(identityGroup, userCtx);
            }

        }

        public void Delete(int groupId, int employeeId)
        {
            _masterGroupRepository.MarkGroupInvalid(groupId, employeeId);

        }
    }
}
