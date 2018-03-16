using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;

namespace Cuelogic.Clrm.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public void Delete(int employeeId, int userId)
        {
            _employeeRepository.MarkEmployeeInvalid(employeeId, userId);
        }

        public EmployeeVm GetItem(int employeeId)
        {
            var employeeVm = new EmployeeVm();
            var virtualModel = _employeeRepository.GetMasterListForEmployees();
            employeeVm.IdentityGroupList = virtualModel.IdentityGroupList;
            employeeVm.MasterDepartmentList = virtualModel.MasterDepartmentList;
            employeeVm.MasterSkillList = virtualModel.MasterSkillList;
            employeeVm.MasterOrganizationRoleList = virtualModel.MasterOrganizationRoleList;

            if (employeeId != 0)
            {
                employeeVm.Employee = _employeeRepository.GetEmployee(employeeId);
                var childList = _employeeRepository.GetChildListForEmployees(employeeId);
                employeeVm.Employee.EmployeeSkillList = childList.EmployeeSkillList;
                employeeVm.Employee.EmployeeDepartmentList = childList.EmployeeDepartmentList;
                employeeVm.Employee.EmployeeOrganizationRoleList = childList.EmployeeOrganizationRoleList;
                employeeVm.Employee.IdentityEmployeeGroupList = childList.IdentityEmployeeGroupList;
            }

            return employeeVm;
        }

        public string GetList(SearchParam searchParam)
        {
            DataSet ds = _employeeRepository.GetEmployeeList(searchParam);
            var employeeJson = ds.Tables[0].ToJsonString();
            return employeeJson;
        }

        public void Save(EmployeeVm employeeVm, UserContext userCtx)
        {
            _employeeRepository.AddOrUpdateEmployee(employeeVm, userCtx);
        }
    }
}
