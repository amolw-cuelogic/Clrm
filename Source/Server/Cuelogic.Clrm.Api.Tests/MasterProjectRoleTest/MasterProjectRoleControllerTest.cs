using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.Service.ProjectRole;
using System.Web.Http.Results;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using System.Web.Http;
using Cuelogic.Clrm.Common;
using Moq;
using Cuelogic.Clrm.Model.CommonModel;
using System.Threading;
using System.Net;
using Cuelogic.Clrm.Api.Tests.Common;

namespace Cuelogic.Clrm.Api.Tests.MasterProjectRoleTest
{
    [TestClass]
    public class MasterProjectRoleControllerTest
    {
        Mock<IMasterProjectRoleService> mockService = new Mock<IMasterProjectRoleService>();

        [TestMethod]
        public void TestMasterProjectRoleGet()
        {
            //ARRANGE
            var mockData = MasterProjectRoleMockData.GetMockDataMasterProjectRoleList();
            mockService.Setup(m => m.GetList(It.IsAny<SearchParam>())).Returns(mockData);
            MasterProjectRoleController controller = new MasterProjectRoleController(mockService.Object)
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
        public void TestMasterProjectRoleGetPerId()
        {
            //ARRANGE
            var mockData = MasterProjectRoleMockData.GetMockDataMasterProjectRole();
            mockService.Setup(m => m.GetItem(It.IsAny<int>())).Returns(mockData);
            MasterProjectRoleController employeeController = new MasterProjectRoleController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            int id = 1;
            IHttpActionResult response = employeeController.Get(id);
            var contentResult = response as OkNegotiatedContentResult<MasterProjectRole>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(MasterProjectRole));
            Assert.AreEqual(id, contentResult.Content.Id);
        }

        [TestMethod]
        public void TestMasterProjectRolePost()
        {
            //ARRANGE
            var mockData = MasterProjectRoleMockData.GetMockDataMasterProjectRole();
            mockService.Setup(m => m.Save(It.IsAny<MasterProjectRole>(), It.IsAny<UserContext>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            MasterProjectRoleController controller = new MasterProjectRoleController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Post(mockData);
            var contentResult = response as OkNegotiatedContentResult<MasterProjectRole>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }

        [TestMethod]
        public void TestMasterProjectRoleDelete()
        {
            //ARRANGE
            mockService.Setup(m => m.Delete(It.IsAny<int>()));
            MasterProjectRoleController controller = new MasterProjectRoleController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Delete(1);
            var contentResult = response as OkNegotiatedContentResult<MasterProjectRole>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }
    }
}
