using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.Projects
{
    public interface IProjectDataAccess
    {
        #region GET FUNCTIONS
        DataSet GetProject(int projectId);
        DataSet GetProjectChildList(int projectId);
        DataSet GetProjectList(SearchParam searchParam);
        DataSet GetProjectMasterList();

        DataSet GetLatestId();
        #endregion

        #region ADD OR UPDATE
        void AddOrUpdateProject(Project project);
        void AddOrUpdateProjectClient(string xmlString, int userId);
        #endregion

        #region OTHER FUNCTIONS
        void MarkProjectInvalid(int projectId);
        #endregion
    }
}
