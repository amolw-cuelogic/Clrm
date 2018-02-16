using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterDepartmentRepository
    {
        DataSet GetMasterDepartmentList(SearchParam objSearchParam);

        MasterDepartment GetMasterDepartment(int MasterDepartmentId);

        void SaveMasterDepartment(MasterDepartment ObjMasterDepartment, UserContext userCtx);

        void UpdateMasterDepartment(MasterDepartment ObjMasterDepartment, UserContext userCtx);

        void MarkMasterDepartmentInvalid(int MasterDepartmentId);
    }
}
