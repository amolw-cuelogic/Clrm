using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http.Results;
using System.Web.Http;
using Cuelogic.Clrm.Service.Department;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using Cuelogic.Clrm.Common;
using Moq;
using Cuelogic.Clrm.Model.CommonModel;
using System.Threading;
using System.Net;
using Cuelogic.Clrm.MockData;

namespace Cuelogic.Clrm.Api.Tests.TestCase
{
    [TestClass]
    public class MasterDepartmentControllerTest
    {
        Mock<IMasterDepartmentService> mockService = new Mock<IMasterDepartmentService>();
        private const string _testCategory = "Controller - Master Department";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentGet()
        {
            //ARRANGE
            var mockData = MasterDepartmentMockData.GetMockDataMasterDepartmentList();
            mockService.Setup(m => m.GetList(It.IsAny<SearchParam>())).Returns(mockData);
            MasterDepartmentController controller = new MasterDepartmentController(mockService.Object)
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
        public void TestMasterDepartmentGetPerId()
        {
            //ARRANGE
            var mockData = MasterDepartmentMockData.GetMockDataMasterDepartment();
            mockService.Setup(m => m.GetItem(It.IsAny<int>())).Returns(mockData);
            MasterDepartmentController employeeController = new MasterDepartmentController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            int id = 1;
            IHttpActionResult response = employeeController.Get(id);
            var contentResult = response as OkNegotiatedContentResult<MasterDepartment>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(MasterDepartment));
            Assert.AreEqual(id, contentResult.Content.Id);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentPost()
        {
            //ARRANGE
            var mockData = MasterDepartmentMockData.GetMockDataMasterDepartment();
            mockService.Setup(m => m.Save(It.IsAny<MasterDepartment>(), It.IsAny<UserContext>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            MasterDepartmentController controller = new MasterDepartmentController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Post(mockData);
            var contentResult = response as OkNegotiatedContentResult<MasterDepartment>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentDelete()
        {
            //ARRANGE
            mockService.Setup(m => m.Delete(It.IsAny<int>(), It.IsAny<int>()));
            MasterDepartmentController controller = new MasterDepartmentController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(CommonMockData.GetUserClaimsIdentity()),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Delete(1);
            var contentResult = response as OkNegotiatedContentResult<MasterDepartment>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }
    }
}
