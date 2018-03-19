﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess.MySql;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IProjectDataAccess _projectDataAccess;
        private readonly IMasterProjectTypeRepository _masterProjectTypeRepository;
        public ProjectRepository()
        {
            _masterProjectTypeRepository = new MasterProjectTypeRepository();

            var databaseType = AppUtillity.GetTargetDatabase();
            if (databaseType == DatabaseType.MySql)
                _projectDataAccess = new ProjectDataAccessMySql();
            else
                throw new Exception(CustomError.DbConcreteImplementation);

        }
        public void AddOrUpdateProject(Project project, UserContext userContext)
        {
            project.UpdatedBy = userContext.UserId;
            project.CreatedBy = userContext.UserId;
            project.CreatedOn = DateTime.Now.ToMySqlDateString();
            project.UpdatedOn = DateTime.Now.ToMySqlDateString();

            _projectDataAccess.AddOrUpdateProject(project);

            if (project.Id == 0)
            {
                var ds = _projectDataAccess.GetLatestId();
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
            _projectDataAccess.AddProjectRoles(xmlString, userContext.UserId);
        }

        public Project GetProject(int projectId)
        {
            var project = new Project();

            if (projectId != 0)
            {
                var projectDs = _projectDataAccess.GetProject(projectId);
                project = projectDs.Tables[AppConstants.StoreProcedure.Project_GetSelectList_Tables.Project].ToModel<Project>();
                if (projectDs.Tables[AppConstants.StoreProcedure.Project_GetSelectList_Tables.ProjectRole].Rows.Count > 0)
                    project.ProjectRoleList = projectDs.Tables[AppConstants.StoreProcedure.Project_GetSelectList_Tables.ProjectRole].ToList<ProjectRole>();
                else
                    project.ProjectRoleList = new List<ProjectRole>();
            }

            var masterClientDs = _projectDataAccess.GetProjectSelectList();

            var masterClientList = masterClientDs.Tables[AppConstants.StoreProcedure.Project_GetSelectList_Tables.MasterClient].ToList<MasterClient>();
            project.ProjectMasterClientList = masterClientList;
            var masterRoleList = masterClientDs.Tables[AppConstants.StoreProcedure.Project_GetSelectList_Tables.MasterRole].ToList<MasterRole>();
            project.MasterRoleList = masterRoleList;
            var masterCurrencyList = masterClientDs.Tables[AppConstants.StoreProcedure.Project_GetSelectList_Tables.MasterCurrency].ToList<MasterCurrency>();
            project.MasterCurrencyList = masterCurrencyList;

            var masterProjectTypeDs = _masterProjectTypeRepository.GetMasterProjectTypeValidList();
            project.ProjectTypeList = masterProjectTypeDs.Tables[0].ToList<MasterProjectType>();

            return project;
        }

        public DataSet GetProjectList(SearchParam searchParam)
        {
            var ds = _projectDataAccess.GetProjectList(searchParam);
            return ds;
        }

        public void MarkProjectInvalid(int projectId, int employeeId)
        {
            _projectDataAccess.MarkProjectInvalid(projectId, employeeId);
        }
    }
}
