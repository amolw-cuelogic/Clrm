using System;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http.Results;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using System.Web.Http;
using Cuelogic.Clrm.Common;
using Moq;
using Cuelogic.Clrm.Model.CommonModel;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Collections.Generic;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Service.Interface;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Api.Tests.TestCase
{
    [TestClass]
    public class AllocationControllerTest
    {
        Mock<IAllocationService> mockService = new Mock<IAllocationService>();
        private const string _testCategory = "Controller - Allocation";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationGet()
        {
            //ARRANGE
            var mockData = AllocationMockData.GetMockDataAllocationList();
            mockService.Setup(m => m.GetList(It.IsAny<SearchParam>())).Returns(mockData);
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = allocationController.Get(10, 0, "");
            var contentResult = response as OkNegotiatedContentResult<string>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(response);
            Assert.IsNotNull(idResponse);
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content,typeof(String));
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationGetPerId()
        {
            //ARRANGE
            var mockData = AllocationMockData.GetMockDataAllocation();
            mockService.Setup(m => m.GetItem(It.IsAny<int>())).Returns(mockData);
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            int id = 1;
            IHttpActionResult response = allocationController.Get(id);
            var contentResult = response as OkNegotiatedContentResult<Allocation>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(response);
            Assert.IsNotNull(idResponse);
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(Allocation));
            Assert.AreEqual(id, contentResult.Content.Id);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationGetAllocation()
        {
            //ARRANGE
            var mockData = AllocationMockData.GetMockDataAllocation();
            mockService.Setup(m => m.GetItem(It.IsAny<int>())).Returns(mockData);
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            int allocationId = 1;
            IHttpActionResult response = allocationController.Get(allocationId);
            var contentResult = response as OkNegotiatedContentResult<Allocation>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(response);
            Assert.IsNotNull(idResponse);
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(Allocation));
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationGetProjectRole()
        {
            //ARRANGE
            var mockData = AllocationMockData.GetMockDataMasterRoleList();
            mockService.Setup(m => m.GetProjectRolebyId(It.IsAny<int>())).Returns(mockData);
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            int projectId = 1;
            IHttpActionResult response = allocationController.GetProjectRole(projectId);
            var contentResult = response as OkNegotiatedContentResult<List<MasterRole>>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(response);
            Assert.IsNotNull(idResponse);
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(List<MasterRole>));
            Assert.IsTrue(contentResult.Content.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationPost()
        {
            //ARRANGE
            var mockData = AllocationMockData.GetMockDataAllocation();
            mockService.Setup(m => m.Save(It.IsAny<Allocation>(), It.IsAny< UserContext>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };
          
            //ACT
            IHttpActionResult response = allocationController.Post(mockData);
            var contentResult = response as OkNegotiatedContentResult<Allocation>;
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
        public void TestAllocationDelete()
        {
            //ARRANGE
            mockService.Setup(m => m.Delete(It.IsAny<int>(), It.IsAny<int>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = allocationController.Delete(1);
            var contentResult = response as OkNegotiatedContentResult<Allocation>;
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
        public void TestAllocationGet_InValidId()
        {
            //ARRANGE
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = allocationController.Get(-1,1,"text");
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
        public void TestAllocationGetPerId_InValidId()
        {
            //ARRANGE
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = allocationController.Get(-1);
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
        public void TestAllocationDelete_InValidId()
        {
            //ARRANGE
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = allocationController.Delete(-1);
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
        public void TestAllocationGetProjectRole_InValidId()
        {
            //ARRANGE
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = allocationController.GetProjectRole(-1);
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
        public void TestAllocationGetAllocation_InValidId()
        {
            //ARRANGE
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = allocationController.GetAllocation(-1);
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
