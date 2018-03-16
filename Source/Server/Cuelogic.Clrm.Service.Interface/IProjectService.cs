using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface IProjectService
    {
        string GetList(SearchParam searchParam);
        Project GetItem(int projectId);
        void Save(Project project, UserContext userCtx);
        void Delete(int projectId, int employeeId);
    }
}
