using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
{
    public interface IProjectDataAccess
    {
        #region GET FUNCTIONS
        DataSet GetProject(int projectId);
        DataSet GetProjectSelectList();
        DataSet GetProjectList(SearchParam searchParam);

        DataSet GetLatestId();
        #endregion

        #region ADD OR UPDATE
        void AddOrUpdateProject(Project project);
        void AddProjectRoles(string xmlString, int userId);

        #endregion

        #region OTHER FUNCTIONS
        void MarkProjectInvalid(int projectId,int employeeId);
        #endregion
    }
}
