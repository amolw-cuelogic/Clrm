using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.MockData
{
    public class MyProfileMockData
    {
        public static string GetMockDataAllocationList()
        {
            return "[{'Id':3,'FullName':'Amol Maruti Wabale','Role':'Technical Analyst','ProjectName':'Tiny Torch','IsBillable':'No','PercentageAllocation':50,'StartDate':'2018/03/06','EndDate':null,'IsValid':'Yes'},{'Id':1,'FullName':'Amol Maruti Wabale','Role':'Product Developer','ProjectName':'Kantar','IsBillable':'No','PercentageAllocation':50,'StartDate':'2018/03/06','EndDate':null,'IsValid':'Yes'},{'Id':2,'FullName':'Abhijeet  Jivan Sawant','Role':'Product Developer','ProjectName':'Tiny Torch','IsBillable':'No','PercentageAllocation':100,'StartDate':'2017/11/10','EndDate':null,'IsValid':'Yes'},{'Id':4,'FullName':'Pranav Ravindra Shinde','Role':'Developer','ProjectName':'Kantar','IsBillable':'No','PercentageAllocation':90,'StartDate':'2017/12/01','EndDate':null,'IsValid':'Yes'},{'Id':5,'FullName':'Pranav Ravindra Shinde','Role':'Ui Engineer','ProjectName':'Tiny Torch','IsBillable':'No','PercentageAllocation':5,'StartDate':'2017/12/08','EndDate':null,'IsValid':'Yes'}]";
        }
        public static EmployeeVm GetMockDataEmployee()
        {
            var employeeVm = new EmployeeVm();
            var data = new Employee();
            data.Id = 1;
            data.FirstName = "John";
            data.MiddleName = "F.";
            data.LastName = "Doe";
            data.OrgEmpId = "CUE345";
            data.JoiningDate = "2018-02-02";
            data.LeavingDate = "";
            data.ContactNum = "9876543210";
            data.Email = "john.doe@cuelogic.com";
            data.CreatedBy = 1;
            data.CreatedOn = "2018-01-01";
            data.IsValid = true;
            employeeVm.Employee = data;

            var group = new IdentityGroup();
            group.Id = 1;
            group.GroupName = "Super Admin";
            employeeVm.IdentityGroupList.Add(group);

            var department = new MasterDepartment();
            department.Id = 1;
            department.DepartmentName = "Delivery";
            employeeVm.MasterDepartmentList.Add(department);

            var skill = new MasterSkill();
            skill.Id = 1;
            skill.Skill = "C#";
            var skill1 = new MasterSkill();
            skill.Id = 1;
            skill.Skill = "NodeJs";
            employeeVm.MasterSkillList.Add(skill);
            employeeVm.MasterSkillList.Add(skill1);

            var orgRole = new MasterOrganizationRole();
            orgRole.Id = 1;
            orgRole.Role = "Sr. Software Engineer";
            employeeVm.MasterOrganizationRoleList.Add(orgRole);

            return employeeVm;
        }
    }
}
