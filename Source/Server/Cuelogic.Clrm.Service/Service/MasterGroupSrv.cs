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
using Cuelogic.Clrm.Service.Interface;

namespace Cuelogic.Clrm.Service.Service
{
    public class MasterGroupSrv : IMasterGroup
    {
        public string GetList(SearchParam objSearchParam)
        {
            DataSet ds = MasterGroupRepo.GetIdentityGroupList(objSearchParam);
            var IdentityGroupJson = ds.Tables[0].ToJsonString();
            return IdentityGroupJson;
        }

        public IdentityGroup GetItem(int GroupId)
        {
            var grp = MasterGroupRepo.GetGroup(GroupId);
            return grp;
        }

        public void Save(IdentityGroup ObjIdentityGroup, UserContext userCtx)
        {
            if (ObjIdentityGroup.Id == 0)
                MasterGroupRepo.SaveIdentityGroup(ObjIdentityGroup, userCtx);
            else
                MasterGroupRepo.UpdateIdentityGroup(ObjIdentityGroup, userCtx);
        }

        public void Delete(int GroupId)
        {
            MasterGroupRepo.MarkGroupInvalid(GroupId);
        }
    }
}
