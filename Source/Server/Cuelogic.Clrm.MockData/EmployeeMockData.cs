using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.MockData
{
    public class EmployeeMockData
    {
        public static string GetMockDataemployeeList()
        {
            return "[{'Id':1,'FullName':'Amol Maruti Wabale','OrgEmpId':'CUE355','JoiningDate':'2018/02/28','Email':'amol.wabale@cuelogic.com','IsValid':'Yes','CreatedByName':'Amol Wabale'},{'Id':17,'FullName':'Abhijeet  Jivan Sawant','OrgEmpId':'CUE238','JoiningDate':'2018/03/15','Email':'abhijeet.sawant@cuelogic.co.in','IsValid':'Yes','CreatedByName':'Amol Wabale'},{'Id':18,'FullName':'Pranav Ravindra Shinde','OrgEmpId':'CUE672','JoiningDate':'2018/01/05','Email':'pranav.shinde@cuelogic.com','IsValid':'Yes','CreatedByName':'Amol Wabale'},{'Id':19,'FullName':'Debujit Shrikant Suryavanshi','OrgEmpId':'CUE295','JoiningDate':'2017/08/04','Email':'debujit.suryavanshi@cuelogic.com','IsValid':'Yes','CreatedByName':'Amol Wabale'},{'Id':20,'FullName':'Pandurang Tukaram Deshpande','OrgEmpId':'CUE674','JoiningDate':'2017/08/04','Email':'panduranf.tukaram@cuelogic.com','IsValid':'Yes','CreatedByName':'Amol Wabale'},{'Id':21,'FullName':'Bharat  Puranik','OrgEmpId':'CUE456','JoiningDate':'2018/02/21','Email':'bharat.puranik@cuelogic.com','IsValid':'Yes','CreatedByName':'Amol Wabale'}]";
        }

        public static DataSet GetMockDataEmployeeListDataset()
        {
            var ds = new DataSet();
            var jsonString = GetMockDataemployeeList();
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet GetMockDataEmployeeBlankDataset()
        {
            var ds = new DataSet();
            var dt = new DataTable();
            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet GetMockDataMasterDependentListDataset()
        {
            var ds = new DataSet();

            var data = MasterGroupMockData.GetMockDataIdentityGroupRightList();
            var jsonString = Helper.ObjectToJson(data);
            var dt = Helper.JsonStringToDatatable(jsonString);
            dt.Columns.Remove("BooleanRight");
            dt.TableName = TableName.IdentityGroup;
            ds.Tables.Add(dt);

            var jsonString1 = MasterDepartmentMockData.GetMockDataMasterDepartmentList();
            var dt1 = Helper.JsonStringToDatatable(jsonString1);
            dt1.TableName = TableName.MasterDepartment;
            ds.Tables.Add(dt1);

            var jsonString2 = MasterSkillMockData.GetMockDataMasterSkillList();
            var dt2 = Helper.JsonStringToDatatable(jsonString2);
            dt2.TableName = TableName.MasterSkill;
            ds.Tables.Add(dt2);

            var jsonString3 = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRoleList();
            var dt3 = Helper.JsonStringToDatatable(jsonString3);
            dt3.TableName = TableName.MasterOrganizationRole;
            ds.Tables.Add(dt3);
            
            return ds;
        }

        public static DataSet GetMockDataChildDependentListDataset()
        {
            var ds = new DataSet();

            var listEmployeeGroup = new List<IdentityEmployeeGroup>();
            var objEmplGrp1 = new IdentityEmployeeGroup();
            objEmplGrp1.Id = 1;
            objEmplGrp1.EmployeeId = 1;
            objEmplGrp1.GroupId = 2;
            objEmplGrp1.IsValid = true;
            objEmplGrp1.CreatedBy = 1;
            objEmplGrp1.CreatedOn = "2018-02-02";
            listEmployeeGroup.Add(objEmplGrp1);
            var jsonString = Helper.ObjectToJson(listEmployeeGroup);
            var dt = Helper.JsonStringToDatatable(jsonString);
            dt.TableName = TableName.IdentityEmployeeGroup;
            ds.Tables.Add(dt);

            var list0 = new List<EmployeeDepartment>();
            var obj01 = new EmployeeDepartment();
            obj01.Id = 1;
            obj01.EmployeeId = 1;
            obj01.DepartmentId = 2;
            obj01.IsValid = true;
            obj01.CreatedBy = 1;
            obj01.CreatedOn = "2018-02-02";
            list0.Add(obj01);
            var jsonString1 = Helper.ObjectToJson(list0);
            var dt1 = Helper.JsonStringToDatatable(jsonString1);
            dt1.TableName = TableName.EmployeeDepartment;
            ds.Tables.Add(dt1);


            var list = new List<EmployeeSkill>();
            var obj1 = new EmployeeSkill();
            obj1.Id = 1;
            obj1.EmployeeId = 1;
            obj1.SkillId = 2;
            obj1.IsValid = true;
            obj1.CreatedBy = 1;
            obj1.CreatedOn = "2018-02-02";
            list.Add(obj1);
            var obj2 = new EmployeeSkill();
            obj2.Id = 2;
            obj2.EmployeeId = 1;
            obj2.SkillId = 4;
            obj2.IsValid = true;
            obj2.CreatedBy = 1;
            obj2.CreatedOn = "2018-02-02";
            list.Add(obj2);
            var jsonString2 = Helper.ObjectToJson(list);
            var dt2 = Helper.JsonStringToDatatable(jsonString2);
            dt2.TableName = TableName.EmployeeSkill;
            ds.Tables.Add(dt2);

            var list02 = new List<EmployeeOrganizationRole>();
            var obj11 = new EmployeeOrganizationRole();
            obj11.Id = 1;
            obj11.EmployeeId = 1;
            obj11.RoleId = 2;
            obj11.IsValid = true;
            obj11.CreatedBy = 1;
            obj11.CreatedOn = "2018-02-02";
            list02.Add(obj11);
            var jsonString3 = Helper.ObjectToJson(list02);
            var dt3 = Helper.JsonStringToDatatable(jsonString3);
            dt3.TableName = TableName.EmployeeOrganizationRole;
            ds.Tables.Add(dt3);

            return ds;
        }

        public static DataSet GetMockDataEmployeeDataset()
        {
            var ds = new DataSet();
            var data = GetMockDataEmployee();
            var jsonString = Helper.ObjectToJson(data);
            var dt = Helper.JsonStringToDatatable(jsonString);
            dt.Columns.Remove("IdentityEmployeeGroupList");
            dt.Columns.Remove("EmployeeDepartmentList");
            dt.Columns.Remove("EmployeeOrganizationRoleList");
            dt.Columns.Remove("EmployeeSkillList");
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

        public static DataSet GetMockDataEmployeeVmDataset()
        {
            var ds = new DataSet();
            var data = GetMockDataEmployeeVm();
            var jsonString = Helper.ObjectToJson(data);
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
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
