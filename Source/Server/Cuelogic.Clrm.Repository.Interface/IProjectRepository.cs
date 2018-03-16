using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IProjectRepository
    {
        Project GetProject(int projectId);
        DataSet GetProjectList(SearchParam searchParam);
        void AddOrUpdateProject(Project project, UserContext userContext);
        void MarkProjectInvalid(int projectId, int employeeId);
    }
}
