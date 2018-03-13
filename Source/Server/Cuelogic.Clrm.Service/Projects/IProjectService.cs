using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Projects
{
    public interface IProjectService
    {
        string GetList(SearchParam searchParam);
        Project GetItem(int projectId);
        void Save(Project project, UserContext userCtx);
        void Delete(int projectId, int employeeId);
    }
}
