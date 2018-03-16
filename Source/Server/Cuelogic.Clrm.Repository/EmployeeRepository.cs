using System;
using System.Data;
using System.Linq;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using static Cuelogic.Clrm.Common.AppConstants;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess.MySql;

namespace Cuelogic.Clrm.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeDataAccess _employeeDataAccess;

        public EmployeeRepository()
        {
            var databaseType = AppUtillity.GetTargetDatabase();
            if (databaseType == DatabaseType.MySql)
                _employeeDataAccess = new EmployeeDataAccessMySql();
            else
                throw new Exception(CustomError.DbConcreteImplementation);

        }

        public Employee GetChildListForEmployees(int employeeId)
        {
            var employee = new Employee();
            var ds = _employeeDataAccess.GetChildListForEmployees(employeeId);
            employee.IdentityEmployeeGroupList = ds.Tables[0].ToList<IdentityEmployeeGroup>();
            employee.EmployeeDepartmentList = ds.Tables[1].ToList<EmployeeDepartment>();
            employee.EmployeeSkillList = ds.Tables[2].ToList<EmployeeSkill>();
            employee.EmployeeOrganizationRoleList = ds.Tables[3].ToList<EmployeeOrganizationRole>();
            return employee;
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
            employeeVm.IdentityGroupList = ds.Tables[StoreProcedure.Employee_GetMasterValidList_Tables.IdentityGroup].ToList<IdentityGroup>();
            employeeVm.MasterDepartmentList = ds.Tables[StoreProcedure.Employee_GetMasterValidList_Tables.MasterDepartment].ToList<MasterDepartment>();
            employeeVm.MasterSkillList = ds.Tables[StoreProcedure.Employee_GetMasterValidList_Tables.MasterSkill].ToList<MasterSkill>();
            employeeVm.MasterOrganizationRoleList = ds.Tables[StoreProcedure.Employee_GetMasterValidList_Tables.MasterOrganizationRole].ToList<MasterOrganizationRole>();
            return employeeVm;
        }

        public void AddOrUpdateEmployee(EmployeeVm employeeVm, UserContext userContext)
        {
            ICommonDataAccess commonDataAccess = new CommonDataAccessMySql();
            if (employeeVm.Employee.Id == 0)
            {
                var detailsByEmailId = commonDataAccess.GetEmployeeDetailsByEmailId(employeeVm.Employee.Email);
                if (detailsByEmailId.Tables[0].Rows.Count > 0)
                    throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "Email Id already exist, please enter different email."));
                var detailsByOrgEmpId = commonDataAccess.GetEmployeeDetailsByOrgEmpId(employeeVm.Employee.OrgEmpId);
                if (detailsByOrgEmpId.Tables[0].Rows.Count > 0)
                    throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "Employee Id already exist, please enter different Employee Id."));
            }
            else
            {
                var detailsByEmailId = commonDataAccess.GetEmployeeDetailsByEmailId(employeeVm.Employee.Email);
                if (detailsByEmailId.Tables[0].Rows.Count > 1)
                    throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "Email Id already exist, please enter different email."));
                var detailsByOrgEmpId = commonDataAccess.GetEmployeeDetailsByOrgEmpId(employeeVm.Employee.OrgEmpId);
                if (detailsByOrgEmpId.Tables[0].Rows.Count > 1)
                    throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "Employee Id already exist, please enter different Employee Id."));
            }

            employeeVm.Employee.UpdatedBy = userContext.UserId;
            employeeVm.Employee.UpdatedOn = DateTime.Now.ToMySqlDateString();
            employeeVm.Employee.CreatedBy = userContext.UserId;
            employeeVm.Employee.CreatedOn = DateTime.Now.ToMySqlDateString();
            _employeeDataAccess.AddOrUpdateEmployee(employeeVm.Employee);

            if (employeeVm.Employee.Id == 0)
            {
                var Id = _employeeDataAccess.GetLatestId().Tables[0].ToId();
                foreach (var item in employeeVm.Employee.EmployeeSkillList)
                    item.EmployeeId = Id;
                foreach (var item in employeeVm.Employee.EmployeeDepartmentList)
                    item.EmployeeId = Id;
                foreach (var item in employeeVm.Employee.EmployeeOrganizationRoleList)
                    item.EmployeeId = Id;
                foreach (var item in employeeVm.Employee.IdentityEmployeeGroupList)
                    item.EmployeeId = Id;
            }

            var skillListXml = Helper.ObjectToXml(employeeVm.Employee.EmployeeSkillList);
            _employeeDataAccess.AddOrUpdateEmployeeSkill(skillListXml, userContext.UserId);

            var departmentListXml = Helper.ObjectToXml(employeeVm.Employee.EmployeeDepartmentList);
            _employeeDataAccess.AddOrUpdateEmployeeDepartment(departmentListXml, userContext.UserId);

            var organizationRoleListXml = Helper.ObjectToXml(employeeVm.Employee.EmployeeOrganizationRoleList);
            _employeeDataAccess.AddOrUpdateEmployeeOrganizationRole(organizationRoleListXml, userContext.UserId);

            var groupListXml = Helper.ObjectToXml(employeeVm.Employee.IdentityEmployeeGroupList);
            _employeeDataAccess.AddOrUpdateEmployeeGroup(groupListXml, userContext.UserId);
        }

        public void MarkEmployeeInvalid(int employeeId, int userId)
        {
            _employeeDataAccess.MarkEmployeeInvalid(employeeId, userId);
        }
    }
}
