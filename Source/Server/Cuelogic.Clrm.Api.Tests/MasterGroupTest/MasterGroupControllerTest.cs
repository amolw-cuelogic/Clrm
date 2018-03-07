using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Service.Group;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;
using System.Threading;
using Moq;
using Cuelogic.Clrm.Common;
using System.Security.Claims;
using System;

namespace Cuelogic.Clrm.Api.Tests.MasterGroupTest
{
    [TestClass]
    public class MasterGroupControllerTest
    {
        Mock<IMasterGroupService> mockService = new Mock<IMasterGroupService>();

        [TestMethod]
        public void TestMasterGroupGet()
        {
            //ARRANGE
            var mockData = MasterGroupMockData.GetMockDataMasterGroupList();
            mockService.Setup(m => m.GetList(It.IsAny<SearchParam>())).Returns(mockData);
            MasterGroupController controller = new MasterGroupController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Get(10, 0, "");
            var contentResult = response as OkNegotiatedContentResult<string>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(String));
        }

        [TestMethod]
        public void TestMasterGroupGetPerId()
        {
            //ARRANGE
            var mockData = MasterGroupMockData.GetMockDataMasterGroup();
            mockService.Setup(m => m.GetItem(It.IsAny<int>())).Returns(mockData);
            MasterGroupController employeeController = new MasterGroupController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            int id = 1;
            IHttpActionResult response = employeeController.Get(id);
            var contentResult = response as OkNegotiatedContentResult<IdentityGroup>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(IdentityGroup));
            Assert.AreEqual(id, contentResult.Content.Id);
        }

        [TestMethod]
        public void TestMasterGroupPost()
        {
            //ARRANGE
            var mockData = MasterGroupMockData.GetMockDataMasterGroup();
            mockService.Setup(m => m.Save(It.IsAny<IdentityGroup>(), It.IsAny<UserContext>()));
            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));
            MasterGroupController controller = new MasterGroupController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Post(mockData);
            var contentResult = response as OkNegotiatedContentResult<IdentityGroup>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }

        [TestMethod]
        public void TestMasterGroupDelete()
        {
            //ARRANGE
            mockService.Setup(m => m.Delete(It.IsAny<int>()));
            MasterGroupController controller = new MasterGroupController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Delete(1);
            var contentResult = response as OkNegotiatedContentResult<IdentityGroup>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }

    }

}
