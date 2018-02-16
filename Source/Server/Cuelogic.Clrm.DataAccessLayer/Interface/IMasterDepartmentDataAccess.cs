using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.Interface
{
    public interface IMasterDepartmentDataAccess
    {
        #region GET FUNCTIONS

        DataSet GetMasterDepartmentList(SearchParam objSearchParam);

        DataSet GetMasterDepartment(int MasterDepartmentId);
        

        #endregion

        #region UPDATE FUNCTIONS

        void UpdateMasterDepartment(MasterDepartment ObjMasterDepartment);
        
        #endregion

        #region INSERT FUNCTIONS

        DataSet InsertMasterDepartment(MasterDepartment ObjMasterDepartment);
        
        #endregion

        #region OTHER FUNCTIONS

        void MarkMasterDepartmentInvalid(int MasterDepartmentId);

        #endregion
    }
}
