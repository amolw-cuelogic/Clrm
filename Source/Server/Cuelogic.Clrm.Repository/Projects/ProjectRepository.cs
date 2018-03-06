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
using Cuelogic.Clrm.Repository.ProjectType;

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
            
        }

        public Project GetProject(int projectId)
        {
            var project = new Project();

            if(projectId != 0)
            {
                var projectDs = _projectDataAccess.GetProject(projectId);
                project = projectDs.Tables[0].ToModel<Project>();

            }

            var masterClientDs = _projectDataAccess.GetProjectSelectList();

            var masterClientList = masterClientDs.Tables[AppConstants.StoreProcedure.spProject_GetSelectList_Tables.MasterClient].ToList<MasterClient>();
            project.ProjectMasterClientList = masterClientList;
            project.ProjectMasterCurrencyList = masterClientDs.Tables[AppConstants.StoreProcedure.spProject_GetSelectList_Tables.MasterCurrency].ToList<MasterCurrency>();

            IMasterProjectTypeRepository _masterProjectTypeRepository = new MasterProjectTypeRepository();
            var masterProjectTypeDs = _masterProjectTypeRepository.GetMasterProjectTypeValidList();
            project.ProjectTypeList = masterProjectTypeDs.Tables[0].ToList<MasterProjectType>();

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
