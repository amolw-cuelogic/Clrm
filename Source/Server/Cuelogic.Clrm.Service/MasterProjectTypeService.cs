using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;

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
            var masterProjectType = _masterProjectTypeRepository.GetMasterProjectType(masterProjectTypeId);
            return masterProjectType;
        }

        public string GetList(SearchParam searchParam)
        {
            var ds = _masterProjectTypeRepository.GetMasterProjectTypeList(searchParam);
            var jsonString = ds.Tables[0].ToJsonString();
            return jsonString;
        }

        public void Save(MasterProjectType masterProjectType, UserContext userCtx)
        {
            _masterProjectTypeRepository.AddOrUpdateMasterProjectType(masterProjectType, userCtx);
        }
    }
}
