using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using System.Web.Http.Results;
using Cuelogic.Clrm.Service.Allocations;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Security.Claims;
using System.Web.Http;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Api.Tests.DataAccess;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class AllocationControllerTest
    {
        [TestMethod]
        public void TestGetAllocationList()
        {
            AllocationController obj = new AllocationController(new AllocationService());
            var response = obj.Get(10, 0, "") as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestGetAllocationPerId()
        {
            AllocationController obj = new AllocationController(new AllocationService());
            var id = CommonDataAccess.GetAllocationFirstRowId();
            var response = obj.Get(1000) as OkNegotiatedContentResult<Allocation>;
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestUpdateAllocation()
        {
            var id = CommonDataAccess.GetAllocationFirstRowId();
            var TestData = new Allocation();
            TestData.Id = id;
            TestData.EmployeeId = 1;
            TestData.ProjectRoleId = 1;
            TestData.ProjectId = 6;
            TestData.IsBillable = true;
            TestData.PercentageAllocation = 30;
            TestData.StartDate = DateTime.Now.ToMySqlDateString();
            TestData.EndDate = DateTime.Now.ToMySqlDateString();
            TestData.IsValid = true;
            TestData.CreatedOn = DateTime.Now.ToMySqlDateString();
            TestData.CreatedBy = 1;

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            AllocationController objController =
                new AllocationController(new AllocationService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestAddAllocation()
        {
            var TestData = new Allocation();
            TestData.Id = 0;
            TestData.EmployeeId = 1;
            TestData.ProjectRoleId = 1;
            TestData.ProjectId = 6;
            TestData.IsBillable = true;
            TestData.PercentageAllocation = 60;
            TestData.StartDate = DateTime.Now.ToMySqlDateString();
            TestData.EndDate = DateTime.Now.ToMySqlDateString();
            TestData.IsValid = true;
            TestData.UpdatedOn = DateTime.Now.ToMySqlDateString();
            TestData.CreatedBy = 1;

            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));

            AllocationController objController =
                new AllocationController(new AllocationService())
                {
                    Request = new System.Net.Http.HttpRequestMessage(),
                    User = new ClaimsPrincipal(customIdentity),
                    Configuration = new HttpConfiguration()
                };

            IHttpActionResult response = objController.Post(TestData);
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void TestMarkAllocationInvalid()
        {
            AllocationController obj = new AllocationController(new AllocationService());
            IHttpActionResult response = obj.Delete(1);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
