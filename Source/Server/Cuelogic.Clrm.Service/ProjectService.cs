using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;
using System;
using System.Collections.Generic;
using static Cuelogic.Clrm.Common.AppConstants;

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
            var project = new Project();

            if (projectId != 0)
            {
                var projectDs = _projectRepository.GetProject(projectId);
                project = projectDs.Tables[TableName.Project].ToModel<Project>();
                if (projectDs.Tables[TableName.ProjectRole].Rows.Count > 0)
                    project.ProjectRoleList = projectDs.Tables[TableName.ProjectRole].ToList<ProjectRole>();
                else
                    project.ProjectRoleList = new List<ProjectRole>();
            }

            var masterClientDs = _projectRepository.GetProjectSelectList();

            var masterClientList = masterClientDs.Tables[TableName.MasterClient].ToList<MasterClient>();
            project.ProjectMasterClientList = masterClientList;
            var masterRoleList = masterClientDs.Tables[TableName.MasterRole].ToList<MasterRole>();
            project.MasterRoleList = masterRoleList;
            var masterCurrencyList = masterClientDs.Tables[TableName.MasterCurrency].ToList<MasterCurrency>();
            project.MasterCurrencyList = masterCurrencyList;

            var masterProjectTypeDs = _projectRepository.GetMasterProjectTypeValidList();
            project.ProjectTypeList = masterProjectTypeDs.Tables[0].ToList<MasterProjectType>();

            return project;
        }

        public string GetList(SearchParam searchParam)
        {
            var ds = _projectRepository.GetProjectList(searchParam);
            var jsonString = ds.Tables[0].ToJsonString();
            return jsonString;
        }

        public void Save(Project project, UserContext userContext)
        {

            project.UpdatedBy = userContext.UserId;
            project.CreatedBy = userContext.UserId;
            project.CreatedOn = DateTime.Now.ToMySqlDateString();
            project.UpdatedOn = DateTime.Now.ToMySqlDateString();

            _projectRepository.AddOrUpdateProject(project);

            if (project.Id == 0)
            {
                var ds = _projectRepository.GetLatestId();
                var id = ds.Tables[0].ToId();
                foreach (var item in project.ProjectRoleList)
                {
                    item.ProjectId = id;
                }
            }
            else
            {
                foreach (var item in project.ProjectRoleList)
                {
                    item.ProjectId = project.Id;
                }
            }
            var xmlString = Helper.ObjectToXml(project.ProjectRoleList);
            _projectRepository.AddProjectRoles(xmlString, userContext.UserId);
        }
    }
}
