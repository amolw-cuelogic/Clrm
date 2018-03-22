using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http.Results;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using Cuelogic.Clrm.Common;
using System.Web.Http;
using Moq;
using Cuelogic.Clrm.Model.CommonModel;
using System.Threading;
using System.Net;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Service.Interface;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Api.Tests.TestCase
{
    [TestClass]
    public class ProjectControllerTest
    {
        Mock<IProjectService> mockService = new Mock<IProjectService>();
        private const string _testCategory = "Controller - Project";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestProjectGet()
        {
            //ARRANGE
            var mockData = ProjectMockData.GetMockDataProjectList();
            mockService.Setup(m => m.GetList(It.IsAny<SearchParam>())).Returns(mockData);
            ProjectController controller = new ProjectController(mockService.Object)
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
        public void TestProjectGetPerId()
        {
            //ARRANGE
            var mockData = ProjectMockData.GetMockDataProject();
            mockService.Setup(m => m.GetItem(It.IsAny<int>())).Returns(mockData);
            ProjectController employeeController = new ProjectController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            int id = 1;
            IHttpActionResult response = employeeController.Get(id);
            var contentResult = response as OkNegotiatedContentResult<Project>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(response);
            Assert.IsNotNull(idResponse);
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(Project));
            Assert.AreEqual(id, contentResult.Content.Id);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestProjectPost()
        {
            //ARRANGE
            var mockData = ProjectMockData.GetMockDataProject();
            mockService.Setup(m => m.Save(It.IsAny<Project>(), It.IsAny<UserContext>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            ProjectController controller = new ProjectController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Post(mockData);
            var contentResult = response as OkNegotiatedContentResult<Project>;
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
        public void TestProjectDelete()
        {
            //ARRANGE
            mockService.Setup(m => m.Delete(It.IsAny<int>(), It.IsAny<int>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            ProjectController controller = new ProjectController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Delete(1);
            var contentResult = response as OkNegotiatedContentResult<Project>;
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
        public void TestProjectGet_InValidId()
        {
            //ARRANGE
            ProjectController controller = new ProjectController(mockService.Object)
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
        public void TestProjectGetPerId_InValidId()
        {
            //ARRANGE
            ProjectController controller = new ProjectController(mockService.Object)
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
        public void TestProjectDelete_InValidId()
        {
            //ARRANGE
            ProjectController controller = new ProjectController(mockService.Object)
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
