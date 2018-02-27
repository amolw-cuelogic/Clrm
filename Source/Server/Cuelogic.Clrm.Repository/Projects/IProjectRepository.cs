using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Projects
{
    public interface IProjectRepository
    {
        Project GetProject(int projectId);
        DataSet GetProjectList(SearchParam searchParam);
        void AddOrUpdateProject(Project project, UserContext userContext);
        void MarkProjectInvalid(int projectId);
    }
}
