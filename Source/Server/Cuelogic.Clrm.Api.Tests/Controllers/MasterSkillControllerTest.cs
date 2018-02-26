using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http.Results;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using System.Security.Claims;
using System.Web.Http;
using Cuelogic.Clrm.Service.Skill;
using Cuelogic.Clrm.Common;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class MasterSkillControllerTest
    {
        [TestMethod]
        public void TestGetMasterSkillList()
        {
            MasterSkillController obj = new MasterSkillController(new MasterSkillService());
            var response = obj.Get(10, 0, "") as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestGetSkillPerId()
        {
            MasterSkillController obj = new MasterSkillController(new MasterSkillService());
            var response = obj.Get(1) as OkNegotiatedContentResult<MasterSkill>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestUpdateSkill()
        {
            var TestData = new MasterSkill();
            TestData.Id = 1;
            TestData.Skill = "Unit Test";
            TestData.IsValid = true;
            TestData.CreatedBy = 1;
            TestData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedBy = 1;

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            MasterSkillController objMasterGroupController =
                new MasterSkillController(new MasterSkillService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objMasterGroupController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestAddSkill()
        {
            var TestData = new MasterSkill();
            TestData.Id = 0;
            TestData.Skill = "Unit Test";
            TestData.IsValid = true;
            TestData.CreatedBy = 1;
            TestData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.UpdatedBy = 1;

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            MasterSkillController objMasterGroupController =
                new MasterSkillController(new MasterSkillService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objMasterGroupController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestMarkSkillInvalid()
        {
            MasterSkillController obj = new MasterSkillController(new MasterSkillService());
            IHttpActionResult response = obj.Delete(1);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
