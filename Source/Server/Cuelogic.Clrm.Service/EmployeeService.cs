﻿using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;
using static Cuelogic.Clrm.Common.AppConstants;
using System;

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
            employeeVm.IdentityGroupList = employeeVmDs.Tables[StoreProcedure.Employee_GetMasterValidList_Tables.IdentityGroup].ToList<IdentityGroup>(); 
            employeeVm.MasterDepartmentList = employeeVmDs.Tables[StoreProcedure.Employee_GetMasterValidList_Tables.MasterDepartment].ToList<MasterDepartment>();
            employeeVm.MasterSkillList = employeeVmDs.Tables[StoreProcedure.Employee_GetMasterValidList_Tables.MasterSkill].ToList<MasterSkill>();
            employeeVm.MasterOrganizationRoleList = employeeVmDs.Tables[StoreProcedure.Employee_GetMasterValidList_Tables.MasterOrganizationRole].ToList<MasterOrganizationRole>();

            if (employeeId != 0)
            {
                var employeeDs = _employeeRepository.GetEmployee(employeeId);
                employeeVm.Employee = employeeDs.Tables[0].ToModel<Employee>();
                var ds = _employeeRepository.GetChildListForEmployees(employeeId);
                employeeVm.Employee.EmployeeSkillList = ds.Tables[2].ToList<EmployeeSkill>();
                employeeVm.Employee.EmployeeDepartmentList = ds.Tables[1].ToList<EmployeeDepartment>();
                employeeVm.Employee.EmployeeOrganizationRoleList = ds.Tables[3].ToList<EmployeeOrganizationRole>();
                employeeVm.Employee.IdentityEmployeeGroupList = ds.Tables[0].ToList<IdentityEmployeeGroup>();
            }

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
                    throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "Email Id already exist, please enter different email."));
                var detailsByOrgEmpId = _commonRepository.GetEmployeeDetailsByOrgEmpId(employeeVm.Employee.OrgEmpId);
                if (detailsByOrgEmpId.Tables[0].Rows.Count > 0)
                    throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "Employee Id already exist, please enter different Employee Id."));
            }
            else
            {
                var detailsByEmailId = _commonRepository.GetEmployeeDetails(employeeVm.Employee.Email);
                if (detailsByEmailId.Tables[0].Rows.Count > 1)
                    throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "Email Id already exist, please enter different email."));
                var detailsByOrgEmpId = _commonRepository.GetEmployeeDetailsByOrgEmpId(employeeVm.Employee.OrgEmpId);
                if (detailsByOrgEmpId.Tables[0].Rows.Count > 1)
                    throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "Employee Id already exist, please enter different Employee Id."));
            }

            employeeVm.Employee.UpdatedBy = userContext.UserId;
            employeeVm.Employee.UpdatedOn = DateTime.Now.ToMySqlDateString();
            employeeVm.Employee.CreatedBy = userContext.UserId;
            employeeVm.Employee.CreatedOn = DateTime.Now.ToMySqlDateString();

            _employeeRepository.AddOrUpdateEmployee(employeeVm, userContext);
        }
    }
}
