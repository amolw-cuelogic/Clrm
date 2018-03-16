using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
{
    public interface IMasterProjectTypeDataAccess
    {
        DataSet GetMasterProjectTypeList(SearchParam searchParam);
        DataSet GetMasterProjectType(int masterProjectTypeId);
        DataSet GetMasterProjectTypeValidList();
        void AddOrUpdateMasterProjectType(MasterProjectType masterProjectType);
        void MarkMasterProjectTypeInvalid(int masterProjectTypeId, int employeeId);
    }
}
