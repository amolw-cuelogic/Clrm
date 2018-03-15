using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Tests.EmployeeTest
{
    public class EmployeeServiceMockData
    {
        public static string GetMockDataemployeeList()
        {
            return "[{'Id':1,'FullName':'Amol Maruti Wabale','OrgEmpId':'CUE355','JoiningDate':'2018/02/28','Email':'amol.wabale@cuelogic.com','IsValid':'Yes','CreatedByName':'Amol Wabale'},{'Id':17,'FullName':'Abhijeet  Jivan Sawant','OrgEmpId':'CUE238','JoiningDate':'2018/03/15','Email':'abhijeet.sawant@cuelogic.co.in','IsValid':'Yes','CreatedByName':'Amol Wabale'},{'Id':18,'FullName':'Pranav Ravindra Shinde','OrgEmpId':'CUE672','JoiningDate':'2018/01/05','Email':'pranav.shinde@cuelogic.com','IsValid':'Yes','CreatedByName':'Amol Wabale'},{'Id':19,'FullName':'Debujit Shrikant Suryavanshi','OrgEmpId':'CUE295','JoiningDate':'2017/08/04','Email':'debujit.suryavanshi@cuelogic.com','IsValid':'Yes','CreatedByName':'Amol Wabale'},{'Id':20,'FullName':'Pandurang Tukaram Deshpande','OrgEmpId':'CUE674','JoiningDate':'2017/08/04','Email':'panduranf.tukaram@cuelogic.com','IsValid':'Yes','CreatedByName':'Amol Wabale'},{'Id':21,'FullName':'Bharat  Puranik','OrgEmpId':'CUE456','JoiningDate':'2018/02/21','Email':'bharat.puranik@cuelogic.com','IsValid':'Yes','CreatedByName':'Amol Wabale'}]";
        }

        public static DataSet GetMockDataEmployeeDataset()
        {
            var ds = new DataSet();
            var jsonString = GetMockDataemployeeList();
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }

        public static Employee GetMockDataEmployee()
        {
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
            
            return data;
        }

        public static EmployeeVm GetMockDataEmployeeVm()
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
