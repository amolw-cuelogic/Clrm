using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Service.Projects;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http.Results;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using Cuelogic.Clrm.Common;
using System.Web.Http;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class ProjectControllerTest
    {
        [TestMethod]
        public void TestGetProjectList()
        {
            ProjectController obj = new ProjectController(new ProjectService());
            var response = obj.Get(10, 0, "") as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestGetProjectPerId()
        {
            ProjectController obj = new ProjectController(new ProjectService());
            var response = obj.Get(6) as OkNegotiatedContentResult<Project>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestUpdateProject()
        {
            var TestData = new Project();
            TestData.Id = 1;
            TestData.ProjectName = "Test Project";
            TestData.ProjectTypeId = 1;
            TestData.Description = "Test Project Description";
            TestData.StartDate = DateTime.Now.ToMySqlDateString();
            TestData.EndDate = "";
            TestData.IsComplete = false;
            TestData.IsValid = true;
            TestData.CreatedBy = 1;
            TestData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedBy = 1;

            var TestProjectClientData = new ProjectClient();
            TestProjectClientData.Id = 1;
            TestProjectClientData.ProjectId = 1;
            TestProjectClientData.ClientId = 1;
            TestProjectClientData.IsValid = true;
            TestProjectClientData.CreatedBy = 1;
            TestProjectClientData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestProjectClientData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestProjectClientData.UpdatedBy = 1;

            TestData.ProjectClientChildList.Add(TestProjectClientData);

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            ProjectController objController =
                new ProjectController(new ProjectService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestAddProject()
        {
            var TestData = new Project();
            TestData.Id = 0;
            TestData.ProjectName = "Test Project";
            TestData.ProjectTypeId = 1;
            TestData.Description = "Test Project Description";
            TestData.StartDate = DateTime.Now.ToMySqlDateString();
            TestData.EndDate = "";
            TestData.IsComplete = false;
            TestData.IsValid = true;
            TestData.CreatedBy = 1;
            TestData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedBy = 1;

            var TestProjectClientData = new ProjectClient();
            TestProjectClientData.Id = 0;
            TestProjectClientData.ProjectId = 0;
            TestProjectClientData.ClientId = 1;
            TestProjectClientData.IsValid = true;
            TestProjectClientData.CreatedBy = 1;
            TestProjectClientData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestProjectClientData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestProjectClientData.UpdatedBy = 1;

            TestData.ProjectClientChildList.Add(TestProjectClientData);

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            ProjectController objController =
                new ProjectController(new ProjectService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestMarkProjectInvalid()
        {
            ProjectController obj = new ProjectController(new ProjectService());
            IHttpActionResult response = obj.Delete(1);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
