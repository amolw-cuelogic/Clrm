using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.Service.OrganizationRole;
using System.Web.Http.Results;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using System.Web.Http;
using Cuelogic.Clrm.Common;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class MasterOrganizationRoleControllerTest
    {
        [TestMethod]
        public void TestGetMasterOrganizationRoleList()
        {
            MasterOrganizationRoleController obj = new MasterOrganizationRoleController(new MasterOrganizationRoleService());
            var response = obj.Get(10, 0, "") as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestGetOrganizationRolePerId()
        {
            MasterOrganizationRoleController obj = new MasterOrganizationRoleController(new MasterOrganizationRoleService());
            var response = obj.Get(1) as OkNegotiatedContentResult<MasterOrganizationRole>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestUpdateOrganizationRole()
        {
            var TestData = new MasterOrganizationRole();
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

            MasterOrganizationRoleController objController =
                new MasterOrganizationRoleController(new MasterOrganizationRoleService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestAddOrganizationRole()
        {
            var TestData = new MasterOrganizationRole();
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

            MasterOrganizationRoleController objController =
                new MasterOrganizationRoleController(new MasterOrganizationRoleService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestMarkOrganizationRoleInvalid()
        {
            MasterOrganizationRoleController obj = new MasterOrganizationRoleController(new MasterOrganizationRoleService());
            IHttpActionResult response = obj.Delete(1);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
