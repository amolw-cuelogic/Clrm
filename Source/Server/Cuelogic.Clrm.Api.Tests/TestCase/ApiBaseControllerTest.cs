using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading;
using System.Net;
using System.Security.Claims;
using Cuelogic.Clrm.MockData;
using System.Web.Mvc;
using Moq;
using Cuelogic.Clrm.Common;

namespace Cuelogic.Clrm.Api.Tests.TestCase
{
    [TestClass]
    public class ApiBaseControllerTest
    {
        private const string _testCategory = "Controller - Base Api";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestApiBaseGetUserContext()
        {
            //ARRANGE
            var customIdentity = CommonMockData.GetUserClaimsIdentity();
            ApiBaseController controller = new ApiBaseController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                User = new ClaimsPrincipal(customIdentity),
                Configuration = new HttpConfiguration()
            };

            //ACT
            var response = controller.GetUserContext();

            //ASSERT
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(UserContext));
        }
    }
}
