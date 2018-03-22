using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;
using System.Threading;
using Moq;
using Cuelogic.Clrm.Common;
using System.Security.Claims;
using System;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Service.Interface;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Api.Tests.TestCase
{
    [TestClass]
    public class MasterGroupControllerTest
    {
        Mock<IMasterGroupService> mockService = new Mock<IMasterGroupService>();
        private const string _testCategory = "Controller - Master Group";

        [TestMethod]
        [TestCategory(_testCategory)]
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(idResponse);
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(String));
        }

        [TestMethod]
        [TestCategory(_testCategory)]
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(idResponse);
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(IdentityGroup));
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupPost()
        {
            //ARRANGE
            var mockData = MasterGroupMockData.GetMockDataMasterGroup();
            mockService.Setup(m => m.Save(It.IsAny<IdentityGroup>(), It.IsAny<UserContext>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
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
            Assert.IsNotNull(response);
            Assert.IsNotNull(idResponse);
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupDelete()
        {
            //ARRANGE
            mockService.Setup(m => m.Delete(It.IsAny<int>(), It.IsAny<int>()));
            MasterGroupController controller = new MasterGroupController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(CommonMockData.GetUserClaimsIdentity()),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Delete(1);
            var contentResult = response as OkNegotiatedContentResult<IdentityGroup>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(response);
            Assert.IsNotNull(idResponse);
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupGet_InValidId()
        {
            //ARRANGE
            MasterGroupController controller = new MasterGroupController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Get(-1, 1, "text");
            var contentResult = response as BadRequestErrorMessageResult;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(response);
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(idResponse);
            Assert.IsFalse(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, idResponse.StatusCode);
            Assert.AreEqual(contentResult.Message, CustomError.InValidId);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupGetPerId_InValidId()
        {
            //ARRANGE
            MasterGroupController controller = new MasterGroupController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Get(-1);
            var contentResult = response as BadRequestErrorMessageResult;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(response);
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(idResponse);
            Assert.IsFalse(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, idResponse.StatusCode);
            Assert.AreEqual(contentResult.Message, CustomError.InValidId);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupDelete_InValidId()
        {
            //ARRANGE
            MasterGroupController controller = new MasterGroupController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Delete(-1);
            var contentResult = response as BadRequestErrorMessageResult;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(response);
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(idResponse);
            Assert.IsFalse(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, idResponse.StatusCode);
            Assert.AreEqual(contentResult.Message, CustomError.InValidId);
        }
    }

}
