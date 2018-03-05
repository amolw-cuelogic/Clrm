using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http.Results;
using System.Web.Http;
using Cuelogic.Clrm.Service.Department;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using Cuelogic.Clrm.Common;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class MasterDepartmentControllerTest
    {
        [TestMethod]
        public void TestGetMasterDepartmentList()
        {
            MasterDepartmentController obj = new MasterDepartmentController(new MasterDepartmentService());
            var response = obj.Get(10, 0, "") as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestGetDepartmentPerId()
        {
            MasterDepartmentController obj = new MasterDepartmentController(new MasterDepartmentService());
            var response = obj.Get(1) as OkNegotiatedContentResult<MasterDepartment>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestUpdateDepartment()
        {
            var TestData = new MasterDepartment();
            TestData.Id = 1;
            TestData.DepartmentName = "Unit Test Department";
            TestData.DepartmentHead = "Unit Test Department Head";
            TestData.IsValid = true;
            TestData.CreatedBy = 1;
            TestData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedBy = 1;

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            MasterDepartmentController objController =
                new MasterDepartmentController(new MasterDepartmentService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestAddDepartment()
        {
            var TestData = new MasterDepartment();
            TestData.Id = 0;
            TestData.DepartmentName = "Unit Test Department";
            TestData.DepartmentHead = "Unit Test Department Head";
            TestData.IsValid = true;
            TestData.CreatedBy = 1;
            TestData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedBy = 1;

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            MasterDepartmentController objController =
                new MasterDepartmentController(new MasterDepartmentService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestMarkDepartmentInvalid()
        {
            MasterDepartmentController obj = new MasterDepartmentController(new MasterDepartmentService());
            IHttpActionResult response = obj.Delete(1);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
