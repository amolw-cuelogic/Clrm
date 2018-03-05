using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http.Results;
using Cuelogic.Clrm.Service.Client;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using System.Web.Http;
using Cuelogic.Clrm.Common;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class MasterClientControllerTest
    {
        [TestMethod]
        public void TestGetMasterClientList()
        {
            MasterClientController obj = new MasterClientController(new MasterClientService());
            var response = obj.Get(10, 0, "") as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestGetMasterClientPerId()
        {
            MasterClientController obj = new MasterClientController(new MasterClientService());
            var response = obj.Get(1) as OkNegotiatedContentResult<MasterClient>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestUpdateMasterClient()
        {
            var TestData = new MasterClient();
            TestData.Id = 1;
            TestData.ClientLocation = "USA";
            TestData.ClientName = "Microsoft";
            TestData.IsValid = true;
            TestData.CreatedBy = 1;
            TestData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedBy = 1;

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            MasterClientController objController =
                new MasterClientController(new MasterClientService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestAddMasterClient()
        {
            var TestData = new MasterClient();
            TestData.Id = 0;
            TestData.ClientLocation = "USA";
            TestData.ClientName = "Microsoft";
            TestData.IsValid = true;
            TestData.CreatedBy = 1;
            TestData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedBy = 1;

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            MasterClientController objController =
                new MasterClientController(new MasterClientService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestMarkMasterClientInvalid()
        {
            MasterClientController obj = new MasterClientController(new MasterClientService());
            IHttpActionResult response = obj.Delete(1);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
