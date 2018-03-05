using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.Service.ProjectRole;
using System.Web.Http.Results;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using System.Web.Http;
using Cuelogic.Clrm.Common;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class MasterProjectRoleControllerTest
    {
        [TestMethod]
        public void TestGetMasterProjectRoleList()
        {
            MasterProjectRoleController obj = new MasterProjectRoleController(new MasterProjectRoleService());
            var response = obj.Get(10, 0, "") as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestGetProjectRolePerId()
        {
            MasterProjectRoleController obj = new MasterProjectRoleController(new MasterProjectRoleService());
            var response = obj.Get(1) as OkNegotiatedContentResult<MasterProjectRole>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestUpdateProjectRole()
        {
            var TestData = new MasterProjectRole();
            TestData.Id = 1;
            TestData.Role = "Unit Test Engineer";
            TestData.IsValid = true;
            TestData.CreatedBy = 1;
            TestData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedBy = 1;

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            MasterProjectRoleController objController =
                new MasterProjectRoleController(new MasterProjectRoleService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestAddProjectRole()
        {
            var TestData = new MasterProjectRole();
            TestData.Id = 0;
            TestData.Role = "Unit Test Engineer";
            TestData.IsValid = true;
            TestData.CreatedBy = 1;
            TestData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedBy = 1;

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            MasterProjectRoleController objController =
                new MasterProjectRoleController(new MasterProjectRoleService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestMarkProjectRoleInvalid()
        {
            MasterProjectRoleController obj = new MasterProjectRoleController(new MasterProjectRoleService());
            IHttpActionResult response = obj.Delete(1);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
