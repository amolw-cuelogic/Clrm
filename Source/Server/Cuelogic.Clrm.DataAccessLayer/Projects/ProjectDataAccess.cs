using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;

namespace Cuelogic.Clrm.DataAccessLayer.Projects
{
    public class ProjectDataAccess : IProjectDataAccess
    {
        public void AddOrUpdateProject(Project project)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spProject_AddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@pId", project.Id),
                    new MySqlParameter("@pProjectName", project.ProjectName),
                    new MySqlParameter("@pProjectTypeId", project.ProjectTypeId),
                    new MySqlParameter("@pStartDate", project.StartDate),
                    new MySqlParameter("@pEndDate", project.EndDate),
                    new MySqlParameter("@pDescription", project.Description),
                    new MySqlParameter("@pClientId", project.ClientId),
                    new MySqlParameter("@pIsComplete", project.IsComplete),
                    new MySqlParameter("@pIsValid", project.IsValid),
                    new MySqlParameter("@pCreatedBy", project.CreatedBy),
                    new MySqlParameter("@pCreatedOn", project.CreatedOn),
                    new MySqlParameter("@pUpdatedBy", project.UpdatedBy),
                    new MySqlParameter("@pUpdatedOn", project.UpdatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
        }
        

        public DataSet GetLatestId()
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spProject_GetLatestId;
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand());
            return ds;
        }

        public DataSet GetProject(int projectId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spProject_Get;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@pId", projectId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetProjectSelectList()
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spProject_GetSelectList;
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), 
                null, 
                new List<string> {
                AppConstants.StoreProcedure.spProject_GetSelectList_Tables.MasterClient });
            return ds;
        }

        public DataSet GetProjectList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spProject_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@filterText", searchParam.FilterText),
                    new MySqlParameter("@recordFrom", recordFrom),
                    new MySqlParameter("@recordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }
        
        public void MarkProjectInvalid(int projectId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spProject_MarkInvalid;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@pId", projectId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
        }
    }
}
