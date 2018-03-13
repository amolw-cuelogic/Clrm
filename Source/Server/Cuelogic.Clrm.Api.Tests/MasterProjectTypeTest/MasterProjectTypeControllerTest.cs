using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.Service.ProjectType;
using System.Web.Http.Results;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using System.Web.Http;
using Cuelogic.Clrm.Common;
using System.Threading;
using System.Net;
using Moq;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Api.Tests.Common;

namespace Cuelogic.Clrm.Api.Tests.MasterProjectTypeTest
{
    [TestClass]
    public class MasterProjectTypeControllerTest
    {
        Mock<IMasterProjectTypeService> mockService = new Mock<IMasterProjectTypeService>();

        [TestMethod]
        public void TestMasterProjectTypeGet()
        {
            //ARRANGE
            var mockData = MasterProjectTypeMockData.GetMockDataMasterProjectTypeList();
            mockService.Setup(m => m.GetList(It.IsAny<SearchParam>())).Returns(mockData);
            MasterProjectTypeController controller = new MasterProjectTypeController(mockService.Object)
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
        public void TestMasterProjectTypeGetPerId()
        {
            //ARRANGE
            var mockData = MasterProjectTypeMockData.GetMockDataMasterProjectType();
            mockService.Setup(m => m.GetItem(It.IsAny<int>())).Returns(mockData);
            MasterProjectTypeController employeeController = new MasterProjectTypeController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //ACT
            int id = 1;
            IHttpActionResult response = employeeController.Get(id);
            var contentResult = response as OkNegotiatedContentResult<MasterProjectType>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNotNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
            Assert.IsInstanceOfType(contentResult.Content, typeof(MasterProjectType));
            Assert.AreEqual(id, contentResult.Content.Id);
        }

        [TestMethod]
        public void TestMasterProjectTypePost()
        {
            //ARRANGE
            var mockData = MasterProjectTypeMockData.GetMockDataMasterProjectType();
            mockService.Setup(m => m.Save(It.IsAny<MasterProjectType>(), It.IsAny<UserContext>()));
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            MasterProjectTypeController controller = new MasterProjectTypeController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Post(mockData);
            var contentResult = response as OkNegotiatedContentResult<MasterProjectType>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }

        [TestMethod]
        public void TestMasterProjectTypeDelete()
        {
            //ARRANGE
            mockService.Setup(m => m.Delete(It.IsAny<int>(), It.IsAny<int>()));
            MasterProjectTypeController controller = new MasterProjectTypeController(mockService.Object)
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(CommonMockData.GetUserClaimsIdentity()),
                Configuration = new HttpConfiguration()
            };

            //ACT
            IHttpActionResult response = controller.Delete(1);
            var contentResult = response as OkNegotiatedContentResult<MasterProjectType>;
            var idResponse = response.ExecuteAsync(CancellationToken.None).Result;

            //ASSERT
            Assert.IsNull(contentResult);
            Assert.IsTrue(idResponse.IsSuccessStatusCode);
            Assert.AreEqual(HttpStatusCode.OK, idResponse.StatusCode);
        }
    }
}
