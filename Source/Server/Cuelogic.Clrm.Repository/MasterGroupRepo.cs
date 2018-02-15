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

namespace Cuelogic.Clrm.Repository
{
    public class MasterGroupRepo
    {
        public static DataSet GetIdentityGroupList(SearchParam objSearchParam)
        {
            var ds = MasterGroupDa.GetIdentityGroupList(objSearchParam);
            return ds;
        }

        public static IdentityGroup GetGroup(int GroupId)
        {
            var GroupObj = new IdentityGroup();
            if (GroupId != 0)
            {
                var GroupDs = MasterGroupDa.GetIdentityGroup(GroupId);
                var GroupRightDs = MasterGroupDa.GetIdentityGroupRights(GroupId);
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
                var RightDs = MasterGroupDa.GetIdentityRightList();
                var RightObj = RightDs.Tables[0].ToList<IdentityRight>();
                foreach(var item in RightObj)
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

        public static void SaveIdentityGroup(IdentityGroup ObjIdentityGroup, UserContext userCtx)
        {
            ObjIdentityGroup.CreatedBy = userCtx.UserId;
            ObjIdentityGroup.CreatedOn = DateTime.Now.ToMySqlDateString();
            var ds = MasterGroupDa.InsertIdentityGroup(ObjIdentityGroup);
            var LatestId = ds.Tables[0].ToId();
            foreach(var item in ObjIdentityGroup.GroupRight)
            {
                item.GroupId = LatestId;
                item.CreatedBy = userCtx.UserId; ;
                item.CreatedOn = DateTime.Now.ToMySqlDateString();
                item.IsValid = true;
                item.SetDecimalRights();
            }
            var XmlString = Helper.ObjectToXml(ObjIdentityGroup.GroupRight);
            MasterGroupDa.InsertIdentityGroupRight(XmlString);
        }

        public static void UpdateIdentityGroup(IdentityGroup ObjIdentityGroup, UserContext userCtx)
        {
            ObjIdentityGroup.UpdatedBy = userCtx.UserId;
            ObjIdentityGroup.UpdatedOn = DateTime.Now.ToMySqlDateString();
            MasterGroupDa.UpdateIdentityGroup(ObjIdentityGroup);
            foreach(var item in ObjIdentityGroup.GroupRight)
            {
                item.UpdatedBy = userCtx.UserId;
                item.UpdatedOn = DateTime.Now.ToMySqlDateString();
                item.SetDecimalRights();
            }
            var XmlString = Helper.ObjectToXml(ObjIdentityGroup.GroupRight);
            MasterGroupDa.UpdateIdentityGroupRight(XmlString);
        }

        public static void MarkGroupInvalid(int GroupId)
        {
            MasterGroupDa.MarkGroupInvalid(GroupId);
        }
    }
}
