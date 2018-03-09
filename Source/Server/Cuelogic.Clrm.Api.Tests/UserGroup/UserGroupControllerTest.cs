﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Service.Group;
using Cuelogic.Clrm.Service.UserGroup;
using Moq;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading;
using System.Net;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;
using Cuelogic.Clrm.Common;
using System.Security.Claims;
using Cuelogic.Clrm.Api.Tests.Common;

namespace Cuelogic.Clrm.Api.Tests.UserGroup
{
    [TestClass]
    public class UserGroupControllerTest
    {
        Mock<IUserGroupService> mockService = new Mock<IUserGroupService>();

        [TestMethod]
        public void TestUserGroupGetEmployeeList()
        {
            //ARRANGE
            var mockData = UserGroupMockData.GetEmployeeList();
            mockService.Setup(m => m.GetEmployeeList(It.IsAny<string>())).Returns(mockData);
            UserGroupController controller = new UserGroupController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.GetEmployeeList("");
            var contentResult = response as OkNegotiatedContentResult<List<Employee>>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(List<Employee>));
        }

        [TestMethod]
        public void TestUserGroupGetGroupList()
        {
            //ARRANGE
            var mockData = UserGroupMockData.GetGroupList();
            mockService.Setup(m => m.GetGroupList()).Returns(mockData);
            UserGroupController controller = new UserGroupController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.GetGroupList();
            var contentResult = response as OkNegotiatedContentResult<List<IdentityGroup>>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(List<IdentityGroup>));
        }

        [TestMethod]
        public void TestUserGroupGetIdentityGroupMembers()
        {
            //ARRANGE
            var mockData = UserGroupMockData.GetIdentityGroupMemberList();
            mockService.Setup(m => m.GetIdentityGroupMembers(It.IsAny<int>())).Returns(mockData);
            UserGroupController controller = new UserGroupController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.GetIdentityGroupMembers(1);
            var contentResult = response as OkNegotiatedContentResult<List<Employee>>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(List<Employee>));
        }

        [TestMethod]
        public void TestUserGroupPost()
        {
            //ARRANGE
            var mockData = UserGroupMockData.GetIdentityEmployeeGroupList();
            mockService.Setup(m => m.InsertGroupUsers(It.IsAny<List<IdentityEmployeeGroup>>(), It.IsAny<UserContext>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            UserGroupController controller = new UserGroupController(mockService.Object)
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
    }
}
