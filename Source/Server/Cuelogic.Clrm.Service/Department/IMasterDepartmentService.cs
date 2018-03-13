using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Department
{
    public interface IMasterDepartmentService
    {
        string GetList(SearchParam searchParam);

        MasterDepartment GetItem(int departmentId);

        void Save(MasterDepartment masterDepartment, UserContext userCtx);

        void Delete(int departmentId, int employeeId);
    }
}
