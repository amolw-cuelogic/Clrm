using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.Service.Employees;
using System.Web.Http.Results;
using System.Security.Claims;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Web.Http;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void TestGetEmployeeList()
        {
            EmployeeController obj = new EmployeeController(new EmployeeService());
            var response = obj.Get(10, 0, "") as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestGetEmployeePerId()
        {
            EmployeeController obj = new EmployeeController(new EmployeeService());
            var response = obj.Get(1) as OkNegotiatedContentResult<EmployeeVm>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestUpdateEmployee()
        {
            var TestData = new EmployeeVm();
            TestData.Employee.Id = 1;
            TestData.Employee.FirstName = "John";
            TestData.Employee.MiddleName = "H";
            TestData.Employee.LastName = "Doe";
            TestData.Employee.OrgEmpId = "CUE555";
            TestData.Employee.JoiningDate = DateTime.Now.ToMySqlDateString();
            TestData.Employee.LeavingDate = DateTime.Now.ToMySqlDateString();
            TestData.Employee.ContactNum = "9876543210";
            TestData.Employee.Email = "john.doe@cuelogic.com";
            TestData.Employee.IsValid = true;
            TestData.Employee.CreatedBy = 1;
            TestData.Employee.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.Employee.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.Employee.UpdatedBy = 1;

            var TestDepartmentData = new EmployeeDepartment();
            TestDepartmentData.Id = 1;
            TestDepartmentData.EmployeeId = 1;
            TestDepartmentData.DepartmentId = 1;
            TestDepartmentData.IsValid = true;
            TestDepartmentData.CreatedBy = 1;
            TestDepartmentData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestDepartmentData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestDepartmentData.UpdatedBy = 1;

            TestData.Employee.EmployeeDepartmentList.Add(TestDepartmentData);

            var TestOrganizationRoleData = new EmployeeOrganizationRole();
            TestOrganizationRoleData.Id = 1;
            TestOrganizationRoleData.EmployeeId = 1;
            TestOrganizationRoleData.RoleId = 1;
            TestOrganizationRoleData.IsValid = true;
            TestOrganizationRoleData.CreatedBy = 1;
            TestOrganizationRoleData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestOrganizationRoleData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestOrganizationRoleData.UpdatedBy = 1;

            TestData.Employee.EmployeeOrganizationRoleList.Add(TestOrganizationRoleData);

            var TestSkillData = new EmployeeSkill();
            TestSkillData.Id = 1;
            TestSkillData.EmployeeId = 1;
            TestSkillData.SkillId = 1;
            TestSkillData.IsValid = true;
            TestSkillData.CreatedBy = 1;
            TestSkillData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestSkillData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestSkillData.UpdatedBy = 1;

            TestData.Employee.EmployeeSkillList.Add(TestSkillData);

            var TestEmployeeGroupData = new IdentityEmployeeGroup();
            TestEmployeeGroupData.Id = 1;
            TestEmployeeGroupData.EmployeeId = 1;
            TestEmployeeGroupData.GroupId = 1;
            TestEmployeeGroupData.IsValid = true;
            TestEmployeeGroupData.CreatedBy = 1;
            TestEmployeeGroupData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestEmployeeGroupData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestEmployeeGroupData.UpdatedBy = 1;

            TestData.Employee.IdentityEmployeeGroupList.Add(TestEmployeeGroupData);

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            EmployeeController objController =
                new EmployeeController(new EmployeeService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestAddEmployee()
        {
            var TestData = new EmployeeVm();
            TestData.Employee.Id = 0;
            TestData.Employee.FirstName = "John";
            TestData.Employee.MiddleName = "H";
            TestData.Employee.LastName = "Doe";
            TestData.Employee.OrgEmpId = "CUE555";
            TestData.Employee.JoiningDate = DateTime.Now.ToMySqlDateString();
            TestData.Employee.LeavingDate = DateTime.Now.ToMySqlDateString();
            TestData.Employee.ContactNum = "9876543210";
            TestData.Employee.Email = "john.doe@cuelogic.com";
            TestData.Employee.IsValid = true;
            TestData.Employee.CreatedBy = 1;
            TestData.Employee.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.Employee.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.Employee.UpdatedBy = 1;

            var TestDepartmentData = new EmployeeDepartment();
            TestDepartmentData.Id = 0;
            TestDepartmentData.EmployeeId = 0;
            TestDepartmentData.DepartmentId = 1;
            TestDepartmentData.IsValid = true;
            TestDepartmentData.CreatedBy = 1;
            TestDepartmentData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestDepartmentData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestDepartmentData.UpdatedBy = 1;

            TestData.Employee.EmployeeDepartmentList.Add(TestDepartmentData);

            var TestOrganizationRoleData = new EmployeeOrganizationRole();
            TestOrganizationRoleData.Id = 0;
            TestOrganizationRoleData.EmployeeId = 0;
            TestOrganizationRoleData.RoleId = 1;
            TestOrganizationRoleData.IsValid = true;
            TestOrganizationRoleData.CreatedBy = 1;
            TestOrganizationRoleData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestOrganizationRoleData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestOrganizationRoleData.UpdatedBy = 1;

            TestData.Employee.EmployeeOrganizationRoleList.Add(TestOrganizationRoleData);

            var TestSkillData = new EmployeeSkill();
            TestSkillData.Id = 0;
            TestSkillData.EmployeeId = 0;
            TestSkillData.SkillId = 1;
            TestSkillData.IsValid = true;
            TestSkillData.CreatedBy = 1;
            TestSkillData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestSkillData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestSkillData.UpdatedBy = 1;

            TestData.Employee.EmployeeSkillList.Add(TestSkillData);

            var TestEmployeeGroupData = new IdentityEmployeeGroup();
            TestEmployeeGroupData.Id = 0;
            TestEmployeeGroupData.EmployeeId = 0;
            TestEmployeeGroupData.GroupId = 1;
            TestEmployeeGroupData.IsValid = true;
            TestEmployeeGroupData.CreatedBy = 1;
            TestEmployeeGroupData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestEmployeeGroupData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestEmployeeGroupData.UpdatedBy = 1;

            TestData.Employee.IdentityEmployeeGroupList.Add(TestEmployeeGroupData);

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            EmployeeController objController =
                new EmployeeController(new EmployeeService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestMarkEmployeeInvalid()
        {
            EmployeeController obj = new EmployeeController(new EmployeeService());
            IHttpActionResult response = obj.Delete(1);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
