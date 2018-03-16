﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http.Results;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using System.Web.Http;
using Cuelogic.Clrm.Common;
using Moq;
using Cuelogic.Clrm.Model.CommonModel;
using System.Threading;
using System.Net;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Service.Interface;

namespace Cuelogic.Clrm.Api.Tests.TestCase
{
    [TestClass]
    public class MasterClientControllerTest
    {
        Mock<IMasterClientService> mockService = new Mock<IMasterClientService>();
        private const string _testCategory = "Controller - Master Client";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientGet()
        {
            //ARRANGE
            var mockData = MasterClientMockData.GetMockDataMasterClientList();
            mockService.Setup(m => m.GetList(It.IsAny<SearchParam>())).Returns(mockData);
            MasterClientController controller = new MasterClientController(mockService.Object)
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
        [TestCategory(_testCategory)]
        public void TestMasterClientGetPerId()
        {
            //ARRANGE
            var mockData = MasterClientMockData.GetMockDataMasterClient();
            mockService.Setup(m => m.GetItem(It.IsAny<int>())).Returns(mockData);
            MasterClientController employeeController = new MasterClientController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            int id = 1;
            IHttpActionResult response = employeeController.Get(id);
            var contentResult = response as OkNegotiatedContentResult<MasterClient>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(MasterClient));
            Assert.AreEqual(id, contentResult.Content.Id);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientPost()
        {
            //ARRANGE
            var mockData = MasterClientMockData.GetMockDataMasterClient();
            mockService.Setup(m => m.Save(It.IsAny<MasterClient>(), It.IsAny<UserContext>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            MasterClientController controller = new MasterClientController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Post(mockData);
            var contentResult = response as OkNegotiatedContentResult<MasterClient>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientDelete()
        {
            //ARRANGE
            mockService.Setup(m => m.Delete(It.IsAny<int>(), It.IsAny<int>()));
            MasterClientController controller = new MasterClientController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(CommonMockData.GetUserClaimsIdentity()),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Delete(1);
            var contentResult = response as OkNegotiatedContentResult<MasterClient>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }
    }
}