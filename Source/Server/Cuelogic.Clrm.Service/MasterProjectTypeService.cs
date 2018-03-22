using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;
using System;

namespace Cuelogic.Clrm.Service
{
    public class MasterProjectTypeService : IMasterProjectTypeService
    {
        private readonly IMasterProjectTypeRepository _masterProjectTypeRepository;
        public MasterProjectTypeService()
        {
            _masterProjectTypeRepository = new MasterProjectTypeRepository();
        }
        public void Delete(int masterProjectTypeId, int employeeId)
        {
            _masterProjectTypeRepository.MarkMasterProjectTypeInvalid(masterProjectTypeId, employeeId);
        }

        public MasterProjectType GetItem(int masterProjectTypeId)
        {

            if (masterProjectTypeId > 0)
            {
                var ds = _masterProjectTypeRepository.GetMasterProjectType(masterProjectTypeId);
                var masterProjecType = ds.Tables[0].ToModel<MasterProjectType>();
                return masterProjecType;
            }
            else
            {
                return new MasterProjectType();
            }
        }

        public string GetList(SearchParam searchParam)
        {
            var ds = _masterProjectTypeRepository.GetMasterProjectTypeList(searchParam);
            var jsonString = ds.Tables[0].ToJsonString();
            return jsonString;
        }

        public void Save(MasterProjectType masterProjectType, UserContext userCtx)
        {

            masterProjectType.CreatedBy = userCtx.UserId;
            masterProjectType.UpdatedBy = userCtx.UserId;
            masterProjectType.CreatedOn = DateTime.Now.ToMySqlDateString();
            masterProjectType.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterProjectTypeRepository.AddOrUpdateMasterProjectType(masterProjectType);
        }
    }
}
