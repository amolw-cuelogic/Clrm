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
using log4net;
using Cuelogic.Clrm.Repository.Group;

namespace Cuelogic.Clrm.Service.Group
{
    public class MasterGroupService : IMasterGroup
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
                _masterGroupRepository.UpdateIdentityGroup(identityGroup, userCtx);

        }

        public void Delete(int groupId)
        {
            _masterGroupRepository.MarkGroupInvalid(groupId);

        }
    }
}
