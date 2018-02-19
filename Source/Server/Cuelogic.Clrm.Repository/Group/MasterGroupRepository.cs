using Cuelogic.Clrm.DataAccessLayer;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using log4net;
using Cuelogic.Clrm.DataAccessLayer.Group;

namespace Cuelogic.Clrm.Repository.Group
{
    public class MasterGroupRepository : IMasterGroupRepository
    {
        private readonly IMasterGroupDataAccess _masterGroupDataAccess;
        public MasterGroupRepository()
        {
            _masterGroupDataAccess = new MasterGroupDataAccess();
        }
        public DataSet GetIdentityGroupList(SearchParam objSearchParam)
        {
            var ds = _masterGroupDataAccess.GetIdentityGroupList(objSearchParam);
            return ds;
        }

        public IdentityGroup GetGroup(int GroupId)
        {
            var GroupObj = new IdentityGroup();
            if (GroupId != 0)
            {
                var GroupDs = _masterGroupDataAccess.GetIdentityGroup(GroupId);
                var GroupRightDs = _masterGroupDataAccess.GetIdentityGroupRights(GroupId);
                GroupObj = GroupDs.Tables[0].ToModel<IdentityGroup>();
                var GroupRightLlist = GroupRightDs.Tables[0].ToList<IdentityGroupRight>();
                foreach (var item in GroupRightLlist)
                {
                    item.SetBooleanRights(item.Action);
                }
                GroupObj.GroupRight = GroupRightLlist;
            }
            else
            {
                var RightDs = _masterGroupDataAccess.GetIdentityRightList();
                var RightObj = RightDs.Tables[0].ToList<IdentityRight>();
                foreach (var item in RightObj)
                {
                    var temp = new IdentityGroupRight();
                    temp.Action = 4; //Set read right by default
                    temp.IsValid = true;
                    temp.RightId = item.Id;
                    temp.RightTitle = item.RightTitle;
                    temp.SetBooleanRights(temp.Action);
                    GroupObj.GroupRight.Add(temp);
                }
            }
            return GroupObj;
        }

        public void SaveIdentityGroup(IdentityGroup ObjIdentityGroup, UserContext userCtx)
        {
            ObjIdentityGroup.CreatedBy = userCtx.UserId;
            ObjIdentityGroup.CreatedOn = DateTime.Now.ToMySqlDateString();
            var ds = _masterGroupDataAccess.InsertIdentityGroup(ObjIdentityGroup);
            var LatestId = ds.Tables[0].ToId();
            foreach (var item in ObjIdentityGroup.GroupRight)
            {
                item.GroupId = LatestId;
                item.CreatedBy = userCtx.UserId; ;
                item.CreatedOn = DateTime.Now.ToMySqlDateString();
                item.IsValid = true;
                item.SetDecimalRights();
            }
            var XmlString = Helper.ObjectToXml(ObjIdentityGroup.GroupRight);
            _masterGroupDataAccess.InsertIdentityGroupRight(XmlString);

        }

        public void UpdateIdentityGroup(IdentityGroup ObjIdentityGroup, UserContext userCtx)
        {
            ObjIdentityGroup.UpdatedBy = userCtx.UserId;
            ObjIdentityGroup.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterGroupDataAccess.UpdateIdentityGroup(ObjIdentityGroup);
            foreach (var item in ObjIdentityGroup.GroupRight)
            {
                item.UpdatedBy = userCtx.UserId;
                item.UpdatedOn = DateTime.Now.ToMySqlDateString();
                item.SetDecimalRights();
            }
            var XmlString = Helper.ObjectToXml(ObjIdentityGroup.GroupRight);
            _masterGroupDataAccess.UpdateIdentityGroupRight(XmlString);

        }

        public void MarkGroupInvalid(int GroupId)
        {
            _masterGroupDataAccess.MarkGroupInvalid(GroupId);
        }
    }
}
