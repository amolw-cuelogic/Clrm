using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IProjectRepository
    {
        DataSet GetProject(int projectId);
        DataSet GetProjectList(SearchParam searchParam);
        DataSet GetProjectSelectList();
        DataSet GetMasterProjectTypeValidList();
        DataSet AddOrUpdateProject(Project project);
        void AddProjectRoles(string xmlString, int userId);
        DataSet GetLatestId();
        void MarkProjectInvalid(int projectId, int employeeId);
    }
}
