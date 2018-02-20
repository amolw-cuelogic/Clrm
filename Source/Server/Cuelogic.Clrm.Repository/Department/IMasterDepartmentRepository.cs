using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Department
{
    public interface IMasterDepartmentRepository
    {
        DataSet GetMasterDepartmentList(SearchParam searchParam);

        MasterDepartment GetMasterDepartment(int masterDepartmentId);

        void SaveMasterDepartment(MasterDepartment masterDepartment, UserContext userCtx);

        void UpdateMasterDepartment(MasterDepartment masterDepartment, UserContext userCtx);

        void MarkMasterDepartmentInvalid(int masterDepartmentId);
    }
}
