using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface IMasterDepartmentService
    {
        string GetList(SearchParam objSearchParam);

        MasterDepartment GetItem(int DepartmentId);

        void Save(MasterDepartment ObjMasterDepartment, UserContext userCtx);

        void Delete(int DepartmentId);
    }
}
