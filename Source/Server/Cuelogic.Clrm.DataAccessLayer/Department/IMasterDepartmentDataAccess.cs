using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.Department
{
    public interface IMasterDepartmentDataAccess
    {
        DataSet GetMasterDepartmentList(SearchParam searchParam);

        DataSet GetMasterDepartment(int masterDepartmentId);
        
        void UpdateMasterDepartment(MasterDepartment masterDepartment);
        
        void InsertMasterDepartment(MasterDepartment masterDepartment);
        
        void MarkMasterDepartmentInvalid(int masterDepartmentId);
        
    }
}
