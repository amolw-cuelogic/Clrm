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
using log4net;

namespace Cuelogic.Clrm.Service.Service
{
    public class MasterGroupService : IMasterGroup
    {
        private readonly IMasterGroupRepository _masterGroupRepository;
        private ILog applogManager = AppLogManager.GetLogger();
        public MasterGroupService()
        {
            _masterGroupRepository = new MasterGroupRepository();
        }
        public string GetList(SearchParam objSearchParam)
        {
            try
            {
                DataSet ds = _masterGroupRepository.GetIdentityGroupList(objSearchParam);
                var IdentityGroupJson = ds.Tables[0].ToJsonString();
                return IdentityGroupJson;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public IdentityGroup GetItem(int GroupId)
        {
            try
            {
                var grp = _masterGroupRepository.GetGroup(GroupId);
                return grp;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void Save(IdentityGroup ObjIdentityGroup, UserContext userCtx)
        {
            try
            {
                if (ObjIdentityGroup.Id == 0)
                    _masterGroupRepository.SaveIdentityGroup(ObjIdentityGroup, userCtx);
                else
                    _masterGroupRepository.UpdateIdentityGroup(ObjIdentityGroup, userCtx);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void Delete(int GroupId)
        {
            try
            {
                _masterGroupRepository.MarkGroupInvalid(GroupId);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }
    }
}
