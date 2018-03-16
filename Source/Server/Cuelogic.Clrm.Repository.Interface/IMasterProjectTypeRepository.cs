using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterProjectTypeRepository
    {
        DataSet GetMasterProjectTypeList(SearchParam searchParam);
        MasterProjectType GetMasterProjectType(int masterProjectTypeId);
        DataSet GetMasterProjectTypeValidList();
        void AddOrUpdateMasterProjectType(MasterProjectType masterProjectType, UserContext userCtx);
        void MarkMasterProjectTypeInvalid(int masterProjectTypeId, int employeeId);
    }
}
