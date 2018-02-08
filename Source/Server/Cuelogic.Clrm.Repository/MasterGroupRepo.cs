using Cuelogic.Clrm.DataAccessLayer;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
