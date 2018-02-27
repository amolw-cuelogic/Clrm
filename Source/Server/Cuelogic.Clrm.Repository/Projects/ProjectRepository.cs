using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.DataAccessLayer.Projects;
using Cuelogic.Clrm.Common;

namespace Cuelogic.Clrm.Repository.Projects
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IProjectDataAccess _projectDataAccess;
        public ProjectRepository()
        {
            _projectDataAccess = new ProjectDataAccess();
        }
        public void AddOrUpdateProject(Project project, UserContext userContext)
        {
            project.UpdatedBy = userContext.UserId;
            project.CreatedBy = userContext.UserId;
            project.CreatedOn = DateTime.Now.ToMySqlDateString();
            project.CreatedOn = DateTime.Now.ToMySqlDateString();

            _projectDataAccess.AddOrUpdateProject(project);

            if(project.Id == 0)
            {
                var ds = _projectDataAccess.GetLatestId();
                var id = ds.Tables[0].ToId();
                foreach(var item in project.ProjectClientChildList)
                {
                    item.ProjectId = id;
                }
            }

            var xmlString = Helper.ObjectToXml(project.ProjectClientChildList);
            _projectDataAccess.AddOrUpdateProjectClient(xmlString, userContext.UserId);
        }

        public Project GetProject(int projectId)
        {
            var project = new Project();

            if(projectId != 0)
            {
                var projectDs = _projectDataAccess.GetProject(projectId);
                project = projectDs.Tables[0].ToModel<Project>();
            }

            var masterClientDs = _projectDataAccess.GetProjectMasterList();
            var masterClientList = masterClientDs.Tables[0].ToList<MasterClient>();
            project.ProjectMasterClientList = masterClientList;

            return project;
        }

        public DataSet GetProjectList(SearchParam searchParam)
        {
            var ds = _projectDataAccess.GetProjectList(searchParam);
            return ds;
        }

        public void MarkProjectInvalid(int projectId)
        {
            _projectDataAccess.MarkProjectInvalid(projectId);
        }
    }
}
