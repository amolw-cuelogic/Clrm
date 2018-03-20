using System.Collections.Generic;
using System.Data;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IDataAccess _dataAccess;
        public ProjectRepository()
        {
            _dataAccess = new MySqlDataAccess();
        }
        public DataSet AddOrUpdateProject(Project project)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Project_AddOrUpdate;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@pId", Value=project.Id },
                    new Param() { Key="@pProjectName", Value=project.ProjectName },
                    new Param() { Key="@pProjectTypeId", Value=project.ProjectTypeId },
                    new Param() { Key="@pStartDate", Value=project.StartDate },
                    new Param() { Key="@pEndDate", Value=project.EndDate },
                    new Param() { Key="@pDescription", Value=project.Description },
                    new Param() { Key="@pClientId", Value=project.ClientId },
                    new Param() { Key="@pIsComplete", Value=project.IsComplete },
                    new Param() { Key="@pIsValid", Value=project.IsValid },
                    new Param() { Key="@pCreatedBy", Value=project.CreatedBy },
                    new Param() { Key="@pCreatedOn", Value=project.CreatedOn },
                    new Param() { Key="@pUpdatedBy", Value=project.UpdatedBy },
                    new Param() { Key="@pUpdatedOn", Value=project.UpdatedOn },
            });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetProject(int projectId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Project_Get;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@pId", Value= projectId },
            });
            sqlParam.TableName = new List<string> {
                TableName.Project,
                TableName.ProjectRole};
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
           
        }

        public DataSet GetProjectList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Project_GetList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@filterText", Value=searchParam.FilterText },
                    new Param() { Key="@recordFrom", Value= recordFrom },
                    new Param() { Key="@recordTill", Value= show } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void MarkProjectInvalid(int projectId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Project_MarkInvalid;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@pId", Value = projectId },
                    new Param() { Key="@pEmployeeId", Value=employeeId }});
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public void AddProjectRoles(string xmlString, int userId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Project_BulkInsertRoles;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@xmlString", Value=xmlString },
                    new Param() { Key="@userId", Value=userId },
            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public DataSet GetLatestId()
        {
            var sqlparam = new DataAccessParameter();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.Project_GetLatestId;
            var ds = _dataAccess.ExecuteQuery(sqlparam);
            return ds;
        }

        public DataSet GetProjectSelectList()
        {
            var sqlparam = new DataAccessParameter();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.Project_GetSelectList;
            sqlparam.TableName = new List<string> {
                TableName.MasterClient,
                TableName.MasterRole,
                TableName.MasterCurrency};
            var ds = _dataAccess.ExecuteQuery(sqlparam);
            return ds;
        }

        public DataSet GetMasterProjectTypeValidList()
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterProjectType_GetValidList;
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }
    }
}
