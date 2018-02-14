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
            var GroupDs = MasterGroupDa.GetIdentityGroup(GroupId);
            var GroupRightDs = MasterGroupDa.GetIdentityGroupRights(GroupId);
            var GroupObj = GroupDs.Tables[0].ToModel<IdentityGroup>();
            var GroupRightLlist = GroupRightDs.Tables[0].ToList<IdentityGroupRight>();
            foreach(var item in GroupRightLlist)
            {
                item.BooleanRight = Helper.GetBooleanRights(item.Action);
            }
            GroupObj.GroupRight = GroupRightLlist;
            return GroupObj;
        }

        public static void SaveIdentityGroup(IdentityGroup ObjIdentityGroup, UserContext userCtx)
        {
            ObjIdentityGroup.CreatedBy = userCtx.UserId;
            ObjIdentityGroup.CreatedOn = DateTime.Now.ToMySqlDateString();
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
    }
}
