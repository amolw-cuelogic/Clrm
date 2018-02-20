using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.DataAccessLayer.Employees;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.Repository.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeDataAccess _employeeDataAccess;

        public EmployeeRepository()
        {
            _employeeDataAccess = new EmployeeDataAccess();
        }

        public Employee GetEmployee(int employeeId)
        {
            var ds = _employeeDataAccess.GetEmployee(employeeId);
            var employee = ds.Tables[0].ToModel<Employee>();
            return employee;
        }

        public DataSet GetEmployeeList(SearchParam searchParam)
        {
            var ds = _employeeDataAccess.GetEmployeeList(searchParam);
            return ds;
        }

        public EmployeeVm GetMasterListForEmployees()
        {
            var employeeVm = new EmployeeVm();
            var ds = _employeeDataAccess.GetMasterListForEmployees();
            employeeVm.IdentityGroupList = ds.Tables[0].ToList<IdentityGroup>();
            employeeVm.MasterDepartmentList = ds.Tables[1].ToList<MasterDepartment>();
            employeeVm.MasterSkillList = ds.Tables[2].ToList<MasterSkill>();
            employeeVm.MasterOrganizationRoleList = ds.Tables[3].ToList<MasterOrganizationRole>();
            return employeeVm;
        }
    }
}
