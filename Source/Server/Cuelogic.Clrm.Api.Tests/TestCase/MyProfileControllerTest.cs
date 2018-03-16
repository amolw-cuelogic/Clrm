using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Service.Common;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Api.Controllers;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;
using System.Threading;
using System.Security.Claims;
using Cuelogic.Clrm.MockData;

namespace Cuelogic.Clrm.Api.Tests.TestCase
{
    [TestClass]
    public class MyProfileControllerTest
    {
        Mock<ICommonService> mockService = new Mock<ICommonService>();
        private const string _testCategory = "Controller - My Profile";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeGetPerId()
        {
            //ARRANGE
            var mockData1 = MyProfileMockData.GetMockDataEmployee();
            mockService.Setup(m => m.GetEmployeeById(It.IsAny<int>())).Returns(mockData1);
            var mockData2 = MyProfileMockData.GetMockDataAllocationList();
            mockService.Setup(m => m.GetEmployeeAllocationList(It.IsAny<int>())).Returns(mockData2);
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            MyprofileController employeeController = new MyprofileController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            dynamic response = employeeController.Get();
            
            //ASSERT
            Assert.IsNotNull(response); //As the return type is anonymous so only possible to check if null
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeePost()
        {
            //ARRANGE
            var mockData = MyProfileMockData.GetMockDataEmployee();
            mockService.Setup(m => m.Save(It.IsAny<EmployeeVm>(), It.IsAny<UserContext>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            MyprofileController controller = new MyprofileController(mockService.Object)
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

    }
}
