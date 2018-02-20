using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class Employee
    {
        public Employee()
        {
            Id = 0;
            FirstName = "";
            MiddleName = "";
            LastName = "";
            OrgEmpId = "";
            JoiningDate = "";
            LeavingDate = "";
            ContactNum = "";
            Email = "";
            IsValid = false;
            CreatedBy = 0;
            CreatedOn = "";
            UpdatedBy = 0;
            UpdatedOn = "";
            CreatedByName = "";
            UpdatedByName = "";
            FullName = "";
            IdentityEmployeeGroupList = new List<IdentityEmployeeGroup>();
            EmployeeDepartmentList = new List<EmployeeDepartment>();
            EmployeeOrganizationRoleList = new List<EmployeeOrganizationRole>();
            EmployeeSkillList = new List<EmployeeSkill>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string OrgEmpId { get; set; }
        public string JoiningDate { get; set; }
        public string LeavingDate { get; set; }
        public string ContactNum { get; set; }
        public string Email { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }
        public string FullName { get; set; }

        public List<IdentityEmployeeGroup> IdentityEmployeeGroupList { get; set; }
        public List<EmployeeDepartment> EmployeeDepartmentList { get; set; }
        public List<EmployeeOrganizationRole> EmployeeOrganizationRoleList { get; set; }
        public List<EmployeeSkill> EmployeeSkillList { get; set; }

    }
}
