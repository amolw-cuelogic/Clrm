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
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository.Repository;

namespace Cuelogic.Clrm.Service.Service
{
    public class MasterGroupService : IMasterGroup
    {
        private readonly IMasterGroupRepository _masterGroupRepository;
        public MasterGroupService()
        {
            _masterGroupRepository = new MasterGroupRepository();
        }
        public string GetList(SearchParam objSearchParam)
        {
            DataSet ds = _masterGroupRepository.GetIdentityGroupList(objSearchParam);
            var IdentityGroupJson = ds.Tables[0].ToJsonString();
            return IdentityGroupJson;
        }

        public IdentityGroup GetItem(int GroupId)
        {
            var grp = _masterGroupRepository.GetGroup(GroupId);
            return grp;
        }

        public void Save(IdentityGroup ObjIdentityGroup, UserContext userCtx)
        {
            if (ObjIdentityGroup.Id == 0)
                _masterGroupRepository.SaveIdentityGroup(ObjIdentityGroup, userCtx);
            else
                _masterGroupRepository.UpdateIdentityGroup(ObjIdentityGroup, userCtx);
        }

        public void Delete(int GroupId)
        {
            _masterGroupRepository.MarkGroupInvalid(GroupId);
        }
    }
}
