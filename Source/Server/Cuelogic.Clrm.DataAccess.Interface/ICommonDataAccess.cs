using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
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
