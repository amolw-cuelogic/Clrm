using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface IMasterProjectTypeService
    {
        string GetList(SearchParam searchParam);

        MasterProjectType GetItem(int masterProjectTypeId);

        void Save(MasterProjectType masterProjectType, UserContext userCtx);

        void Delete(int masterProjectTypeId, int employeeId);
    }
}
