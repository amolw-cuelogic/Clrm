using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface ICommonRepository
    {
        DataSet GetEmployeeDetails(string emailId);
        DataSet GetEmployeeDetailsByOrgEmpId(string orgEmpId);
        DataSet GetEmployeeAllocationList(int employeeId);
        DataSet GetGroupRights(int employeeId);
        void LogLoginTime(int employeeId);
    }
}
