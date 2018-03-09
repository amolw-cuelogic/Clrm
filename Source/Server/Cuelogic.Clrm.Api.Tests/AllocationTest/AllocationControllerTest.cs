using System;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http.Results;
using Cuelogic.Clrm.Service.Allocations;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using System.Web.Http;
using Cuelogic.Clrm.Common;
using Moq;
using Cuelogic.Clrm.Model.CommonModel;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Cuelogic.Clrm.Api.Tests.Common;

namespace Cuelogic.Clrm.Api.Tests.AllocationTest
{
    [TestClass]
    public class AllocationControllerTest
    {
        Mock<IAllocationService> mockService = new Mock<IAllocationService>();

        [TestMethod]
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
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content,typeof(String));
        }

        [TestMethod]
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
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(Allocation));
            Assert.AreEqual(id, contentResult.Content.Id);
        }

        [TestMethod]
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
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(Allocation));
            Assert.AreEqual(allocationId, contentResult.Content.Id);
        }

        [TestMethod]
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
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }


        [TestMethod]
        public void TestAllocationDelete()
        {
            //ARRANGE
            mockService.Setup(m => m.Delete(It.IsAny<int>()));
            AllocationController allocationController = new AllocationController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = allocationController.Delete(1);
            var contentResult = response as OkNegotiatedContentResult<Allocation>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }
        
    }
    
}
