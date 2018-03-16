using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
{
    public interface IEmployeeDataAccess
    {
        #region GET FUNCTIONS

        DataSet GetEmployeeList(SearchParam searchParam);
        DataSet GetMasterListForEmployees();
        DataSet GetChildListForEmployees(int masterEmployeeId);
        DataSet GetEmployee(int employeeId);
        DataSet GetLatestId();

        #endregion

        #region ADD OR UPDATE FUNCTIONS

        void AddOrUpdateEmployee(Employee employee);
        void AddOrUpdateEmployeeSkill(string xmlString, int userId);
        void AddOrUpdateEmployeeDepartment(string xmlString, int userId);
        void AddOrUpdateEmployeeOrganizationRole(string xmlString, int userId);
        void AddOrUpdateEmployeeGroup(string xmlString, int userId);

        #endregion

        #region OTHER FUNCTIONS
        void MarkEmployeeInvalid(int masterEmployeeId, int employeeId);

        #endregion
    }
}
