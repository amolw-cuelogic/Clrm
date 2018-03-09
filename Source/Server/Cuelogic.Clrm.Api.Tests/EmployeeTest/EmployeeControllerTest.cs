using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.Service.Employees;
using System.Web.Http.Results;
using System.Security.Claims;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Web.Http;
using Moq;
using Cuelogic.Clrm.Model.CommonModel;
using System.Threading;
using System.Net;
using Cuelogic.Clrm.Api.Tests.Common;

namespace Cuelogic.Clrm.Api.Tests.EmployeeTest
{
    [TestClass]
    public class EmployeeControllerTest
    {
        Mock<IEmployeeService> mockService = new Mock<IEmployeeService>();

        [TestMethod]
        public void TestEmployeeGet()
        {
            //ARRANGE
            var mockData = EmployeeMockData.GetMockDataemployeeList();
            mockService.Setup(m => m.GetList(It.IsAny<SearchParam>())).Returns(mockData);
            EmployeeController controller = new EmployeeController(mockService.Object)
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
        public void TestEmployeeGetPerId()
        {
            //ARRANGE
            var mockData = EmployeeMockData.GetMockDataEmployee();
            mockService.Setup(m => m.GetItem(It.IsAny<int>())).Returns(mockData);
            EmployeeController employeeController = new EmployeeController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            int id = 1;
            IHttpActionResult response = employeeController.Get(id);
            var contentResult = response as OkNegotiatedContentResult<EmployeeVm>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(EmployeeVm));
            Assert.AreEqual(id, contentResult.Content.Employee.Id);
        }

        [TestMethod]
        public void TestEmployeePost()
        {
            //ARRANGE
            var mockData = EmployeeMockData.GetMockDataEmployee();
            mockService.Setup(m => m.Save(It.IsAny<EmployeeVm>(), It.IsAny<UserContext>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            EmployeeController controller = new EmployeeController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Post(mockData);
            var contentResult = response as OkNegotiatedContentResult<EmployeeVm>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }

        [TestMethod]
        public void TestEmployeeDelete()
        {
            //ARRANGE
            mockService.Setup(m => m.Delete(It.IsAny<int>()));
            EmployeeController controller = new EmployeeController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Delete(1);
            var contentResult = response as OkNegotiatedContentResult<Allocation>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }
    }
}
