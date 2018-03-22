using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository;
using System;
using System.Data;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using static Cuelogic.Clrm.Common.AppConstants;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Service.Interface;
using static Cuelogic.Clrm.Common.CustomException;

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
            var identityGroup = new IdentityGroup();
            if (groupId > 0)
            {
                var GroupDs = _masterGroupRepository.GetGroup(groupId);
                var GroupRightDs = _masterGroupRepository.GetIdentityGroupRights(groupId);
                identityGroup = GroupDs.Tables[0].ToModel<IdentityGroup>();
                var GroupRightLlist = GroupRightDs.Tables[0].ToList<IdentityGroupRight>();
                foreach (var item in GroupRightLlist)
                {
                    item.SetBooleanRights(item.Action);
                }
                identityGroup.GroupRight = GroupRightLlist;
            }
            else
            {
                var RightDs = _masterGroupRepository.GetIdentityRightList();
                var RightObj = RightDs.Tables[0].ToList<IdentityRight>();
                foreach (var item in RightObj)
                {
                    var temp = new IdentityGroupRight();
                    temp.Action = 4; //Set read right by default
                    temp.IsValid = true;
                    temp.RightId = item.RightId;
                    temp.RightTitle = item.RightTitle;
                    temp.SetBooleanRights(temp.Action);
                    identityGroup.GroupRight.Add(temp);
                }
            }
            return identityGroup;

        }

        public void Save(IdentityGroup identityGroup, UserContext userCtx)
        {
            if (identityGroup.Id == 0)
            {
                identityGroup.CreatedBy = userCtx.UserId;
                identityGroup.CreatedOn = DateTime.Now.ToMySqlDateString();
                var ds = _masterGroupRepository.SaveIdentityGroup(identityGroup);
                var LatestId = ds.Tables[0].ToId();
                foreach (var item in identityGroup.GroupRight)
                {
                    item.GroupId = LatestId;
                    item.CreatedBy = userCtx.UserId; ;
                    item.CreatedOn = DateTime.Now.ToMySqlDateString();
                    item.IsValid = true;
                    item.SetDecimalRights();
                }
                var XmlString = Helper.ObjectToXml(identityGroup.GroupRight);
                _masterGroupRepository.SaveIdentityGroupRight(XmlString);
            }
            else
            {
                if (userCtx.Rights.Count > 0 && identityGroup.GroupRight.Count > 0)
                {
                    if (userCtx.Rights[0].GroupId == identityGroup.GroupRight[0].GroupId)
                        throw new ClientWarning("You cannot edit your own rights, please contact Super Admin or database expert");
                }
                identityGroup.UpdatedBy = userCtx.UserId;
                identityGroup.UpdatedOn = DateTime.Now.ToMySqlDateString();
                _masterGroupRepository.UpdateIdentityGroup(identityGroup);
                foreach (var item in identityGroup.GroupRight)
                {
                    item.UpdatedBy = userCtx.UserId;
                    item.UpdatedOn = DateTime.Now.ToMySqlDateString();
                    item.SetDecimalRights();
                }
                var XmlString = Helper.ObjectToXml(identityGroup.GroupRight);
                _masterGroupRepository.UpdateIdentityGroupRight(XmlString);
            }

        }

        public void Delete(int groupId, int employeeId)
        {
            _masterGroupRepository.MarkGroupInvalid(groupId, employeeId);

        }
    }
}
