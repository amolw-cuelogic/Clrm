using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.Common
{
    public interface ICommonDataAccess
    {
        DataSet GetEmployeeDetailsByEmailId(string emailId);
        DataSet GetEmployeeDetailsByOrgEmpId(string OrgEmpId);
        DataSet GetEmployeeAllocationList(int employeeId);
        DataSet GetEmployeeRightList(int employeeId);
        void LogLoginTime(int employeeId);
    }
}
