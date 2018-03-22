﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http.Results;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using System.Web.Http;
using Cuelogic.Clrm.Common;
using System.Threading;
using System.Net;
using Moq;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Service.Interface;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Api.Tests.TestCase
{
    [TestClass]
    public class MasterOrganizationRoleControllerTest
    {
        Mock<IMasterOrganizationRoleService> mockService = new Mock<IMasterOrganizationRoleService>();
        private const string _testCategory = "Controller - Master Organization Role";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterOrganizationRoleGet()
        {
            //ARRANGE
            var mockData = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRoleList();
            mockService.Setup(m => m.GetList(It.IsAny<SearchParam>())).Returns(mockData);
            MasterOrganizationRoleController controller = new MasterOrganizationRoleController(mockService.Object)
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
        public void TestMasterOrganizationRoleGetPerId()
        {
            //ARRANGE
            var mockData = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRole();
            mockService.Setup(m => m.GetItem(It.IsAny<int>())).Returns(mockData);
            MasterOrganizationRoleController employeeController = new MasterOrganizationRoleController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            int id = 1;
            IHttpActionResult response = employeeController.Get(id);
            var contentResult = response as OkNegotiatedContentResult<MasterOrganizationRole>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(response);
            Assert.IsNotNull(idResponse);
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(MasterOrganizationRole));
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterOrganizationRolePost()
        {
            //ARRANGE
            var mockData = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRole();
            mockService.Setup(m => m.Save(It.IsAny<MasterOrganizationRole>(), It.IsAny<UserContext>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            MasterOrganizationRoleController controller = new MasterOrganizationRoleController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Post(mockData);
            var contentResult = response as OkNegotiatedContentResult<MasterOrganizationRole>;
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
        public void TestMasterOrganizationRoleDelete()
        {
            //ARRANGE
            mockService.Setup(m => m.Delete(It.IsAny<int>(), It.IsAny<int>()));
            MasterOrganizationRoleController controller = new MasterOrganizationRoleController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(CommonMockData.GetUserClaimsIdentity()),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Delete(1);
            var contentResult = response as OkNegotiatedContentResult<MasterOrganizationRole>;
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
        public void TestMasterOrganizationRoleGet_InValidId()
        {
            //ARRANGE
            MasterOrganizationRoleController controller = new MasterOrganizationRoleController(mockService.Object)
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
        public void TestMasterOrganizationRoleGetPerId_InValidId()
        {
            //ARRANGE
            MasterOrganizationRoleController controller = new MasterOrganizationRoleController(mockService.Object)
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
        public void TestMasterOrganizationRoleDelete_InValidId()
        {
            //ARRANGE
            MasterOrganizationRoleController controller = new MasterOrganizationRoleController(mockService.Object)
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
