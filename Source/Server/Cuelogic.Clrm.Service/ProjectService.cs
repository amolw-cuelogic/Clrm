using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;

namespace Cuelogic.Clrm.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService()
        {
            _projectRepository = new ProjectRepository();
        }

        public void Delete(int projectId, int employeeId)
        {
            _projectRepository.MarkProjectInvalid(projectId, employeeId);
        }

        public Project GetItem(int projectId)
        {
            var project = _projectRepository.GetProject(projectId);
            return project;
        }

        public string GetList(SearchParam searchParam)
        {
            var ds = _projectRepository.GetProjectList(searchParam);
            var jsonString = ds.Tables[0].ToJsonString();
            return jsonString;
        }

        public void Save(Project project, UserContext userCtx)
        {
            _projectRepository.AddOrUpdateProject(project, userCtx);
        }
    }
}
