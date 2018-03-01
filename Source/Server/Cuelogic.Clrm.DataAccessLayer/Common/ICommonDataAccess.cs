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
        DataSet GetEmployeeDetails(string emailId);
        DataSet GetEmployeeAllocationList(int employeeId);
    }
}
