using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.Service
{
    public static class MasterGroupSrv
    {
        public static string GetIdentityGroupList(SearchParam objSearchParam)
        {
            DataSet ds = MasterGroupRepo.GetIdentityGroupList(objSearchParam);
            var IdentityGroupJson = ds.Tables[0].ToJsonString();
            return IdentityGroupJson;
        }

        public static IdentityGroup GetGroup(int GroupId)
        {
            var grp = MasterGroupRepo.GetGroup(GroupId);
            return grp;
        }

        public static void Save(IdentityGroup ObjIdentityGroup, UserContext userCtx)
        {
            if (ObjIdentityGroup.Id == 0)
                MasterGroupRepo.SaveIdentityGroup(ObjIdentityGroup, userCtx);
            else
                MasterGroupRepo.UpdateIdentityGroup(ObjIdentityGroup, userCtx);
        }

        public static void Delete(int GroupId)
        {
            MasterGroupRepo.MarkGroupInvalid(GroupId);
        }
    }
}
