using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class EmployeeVm
    {
        public EmployeeVm()
        {
            Employee = new Employee();
            IdentityGroupList = new List<IdentityGroup>();
            MasterDepartmentList = new List<MasterDepartment>();
            MasterSkillList = new List<MasterSkill>();
            MasterOrganizationRoleList = new List<MasterOrganizationRole>();
        }
        public Employee Employee { get; set; }
        public List<IdentityGroup> IdentityGroupList { get; set; }
        public List<MasterDepartment> MasterDepartmentList { get; set; }
        public List<MasterSkill> MasterSkillList { get; set; }
        public List<MasterOrganizationRole> MasterOrganizationRoleList { get; set; }
    }
}
