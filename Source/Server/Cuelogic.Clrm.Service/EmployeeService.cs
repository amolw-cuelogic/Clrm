using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;
using static Cuelogic.Clrm.Common.AppConstants;
using System;
using static Cuelogic.Clrm.Common.CustomException;

namespace Cuelogic.Clrm.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICommonRepository _commonRepository;
        public EmployeeService()
        {
            _commonRepository = new CommonRepository();
            _employeeRepository = new EmployeeRepository();
        }

        public void Delete(int employeeId, int userId)
        {
            _employeeRepository.MarkEmployeeInvalid(employeeId, userId);
        }

        public EmployeeVm GetItem(int employeeId)
        {
            var employeeVm = new EmployeeVm();
            var employeeVmDs = _employeeRepository.GetMasterListForEmployees();
            employeeVm.IdentityGroupList = employeeVmDs.Tables[TableName.IdentityGroup].ToList<IdentityGroup>(); 
            employeeVm.MasterDepartmentList = employeeVmDs.Tables[TableName.MasterDepartment].ToList<MasterDepartment>();
            employeeVm.MasterSkillList = employeeVmDs.Tables[TableName.MasterSkill].ToList<MasterSkill>();
            employeeVm.MasterOrganizationRoleList = employeeVmDs.Tables[TableName.MasterOrganizationRole].ToList<MasterOrganizationRole>();

            if (employeeId > 0)
            {
                var employeeDs = _employeeRepository.GetEmployee(employeeId);
                employeeVm.Employee = employeeDs.Tables[0].ToModel<Employee>();
                var ds = _employeeRepository.GetChildListForEmployees(employeeId);
                employeeVm.Employee.EmployeeSkillList = ds.Tables[TableName.EmployeeSkill].ToList<EmployeeSkill>();
                employeeVm.Employee.EmployeeDepartmentList = ds.Tables[TableName.EmployeeDepartment].ToList<EmployeeDepartment>();
                employeeVm.Employee.EmployeeOrganizationRoleList = ds.Tables[TableName.EmployeeOrganizationRole].ToList<EmployeeOrganizationRole>();
                employeeVm.Employee.IdentityEmployeeGroupList = ds.Tables[TableName.IdentityEmployeeGroup].ToList<IdentityEmployeeGroup>();
            }
            if (employeeId < 0)
                throw new BadRequest(CustomError.InValidId);
            return employeeVm;
        }

        public string GetList(SearchParam searchParam)
        {
            DataSet ds = _employeeRepository.GetEmployeeList(searchParam);
            var employeeJson = ds.Tables[0].ToJsonString();
            return employeeJson;
        }

        public void Save(EmployeeVm employeeVm, UserContext userContext)
        {
            if (employeeVm.Employee.Id == 0)
            {
                var detailsByEmailId = _commonRepository.GetEmployeeDetails(employeeVm.Employee.Email);
                if (detailsByEmailId.Tables[0].Rows.Count > 0)
                    throw new ClientWarning("Email Id already exist, please enter different email.");
                var detailsByOrgEmpId = _commonRepository.GetEmployeeDetailsByOrgEmpId(employeeVm.Employee.OrgEmpId);
                if (detailsByOrgEmpId.Tables[0].Rows.Count > 0)
                    throw new ClientWarning("Employee Id already exist, please enter different Employee Id.");
            }
            else
            {
                var detailsByEmailId = _commonRepository.GetEmployeeDetails(employeeVm.Employee.Email);
                if (detailsByEmailId.Tables[0].Rows.Count > 1)
                    throw new ClientWarning("Email Id already exist, please enter different email.");
                var detailsByOrgEmpId = _commonRepository.GetEmployeeDetailsByOrgEmpId(employeeVm.Employee.OrgEmpId);
                if (detailsByOrgEmpId.Tables[0].Rows.Count > 1)
                    throw new ClientWarning("Employee Id already exist, please enter different Employee Id.");
            }

            employeeVm.Employee.UpdatedBy = userContext.UserId;
            employeeVm.Employee.UpdatedOn = DateTime.Now.ToMySqlDateString();
            employeeVm.Employee.CreatedBy = userContext.UserId;
            employeeVm.Employee.CreatedOn = DateTime.Now.ToMySqlDateString();

            _employeeRepository.AddOrUpdateEmployee(employeeVm, userContext);
        }
    }
}
