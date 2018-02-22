using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Service.Group;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class MasterGroupControllerTest
    {
        [TestMethod]
        public void TestGetMasterGroupList()
        {
            MasterGroupController obj = new MasterGroupController(new MasterGroupService());
            var data = obj.Get(10, 0, "");
            Assert.IsNotNull(data);

        }

        //For this test case to be executed, it is necessary to have same data is database, 
        //super admin is the test data, do not change it
        [TestMethod]
        public void TestGetGroupPerId()
        {
            var TestData = new IdentityGroup();
            TestData.Id = 1;
            TestData.GroupName = "Super Admin";
            TestData.GroupDescription = "Super Admin";
            TestData.IsValid = true;
            TestData.CreatedBy = 1;
            TestData.CreatedOn = "2018-02-05";
            TestData.UpdatedBy = 1;
            TestData.UpdatedOn = "2018-02-16";
            TestData.CreatedByName = "Amol Wabale";
            TestData.UpdatedByName = "Amol Wabale";

            var TempIdentityGroupRight1 = new IdentityGroupRight();
            TempIdentityGroupRight1.Id = 1;
            TempIdentityGroupRight1.GroupId = 1;
            TempIdentityGroupRight1.RightId = 1;
            TempIdentityGroupRight1.RightTitle = "Group";
            TempIdentityGroupRight1.Action = 7;
            TempIdentityGroupRight1.IsValid = true;
            TempIdentityGroupRight1.CreatedBy = 1;
            TempIdentityGroupRight1.UpdatedBy = 1;
            TempIdentityGroupRight1.CreatedOn = "2018-02-02";
            TempIdentityGroupRight1.UpdatedOn = "2018-02-16";
            TempIdentityGroupRight1.CreatedByName = "Amol Wabale";
            TempIdentityGroupRight1.UpdatedByName = "Amol Wabale";
            TempIdentityGroupRight1.BooleanRight = new BooleanRights() { Delete = true, Read = true, Write = true };
            TestData.GroupRight.Add(TempIdentityGroupRight1);

            var TempIdentityGroupRight2 = new IdentityGroupRight();
            TempIdentityGroupRight2.Id = 14;
            TempIdentityGroupRight2.GroupId = 1;
            TempIdentityGroupRight2.RightId = 2;
            TempIdentityGroupRight2.RightTitle = "User Group";
            TempIdentityGroupRight2.Action = 7;
            TempIdentityGroupRight2.IsValid = true;
            TempIdentityGroupRight2.CreatedBy = 1;
            TempIdentityGroupRight2.UpdatedBy = 1;
            TempIdentityGroupRight2.CreatedOn = "2018-02-02";
            TempIdentityGroupRight2.UpdatedOn = "2018-02-16";
            TempIdentityGroupRight2.CreatedByName = "Amol Wabale";
            TempIdentityGroupRight2.UpdatedByName = "Amol Wabale";
            TempIdentityGroupRight2.BooleanRight = new BooleanRights() { Delete = true, Read = true, Write = true };
            TestData.GroupRight.Add(TempIdentityGroupRight2);

            var TempIdentityGroupRight3 = new IdentityGroupRight();
            TempIdentityGroupRight3.Id = 15;
            TempIdentityGroupRight3.GroupId = 1;
            TempIdentityGroupRight3.RightId = 3;
            TempIdentityGroupRight3.RightTitle = "Employee";
            TempIdentityGroupRight3.Action = 7;
            TempIdentityGroupRight3.IsValid = true;
            TempIdentityGroupRight3.CreatedBy = 1;
            TempIdentityGroupRight3.UpdatedBy = 1;
            TempIdentityGroupRight3.CreatedOn = "2018-02-02";
            TempIdentityGroupRight3.UpdatedOn = "2018-02-16";
            TempIdentityGroupRight3.CreatedByName = "Amol Wabale";
            TempIdentityGroupRight3.UpdatedByName = "Amol Wabale";
            TempIdentityGroupRight3.BooleanRight = new BooleanRights() { Delete = true, Read = true, Write = true };
            TestData.GroupRight.Add(TempIdentityGroupRight3);

            MasterGroupController obj = new MasterGroupController(new MasterGroupService());
            var ActualData = obj.Get(1);

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var expectedJson = serializer.Serialize(TestData);
            var actualJson = serializer.Serialize(ActualData);

            Assert.AreEqual(actualJson, expectedJson);

        }

        //[TestMethod]
        //public void TestPostGroup()
        //{
        //    var TestData = new IdentityGroup();
        //    TestData.Id = 1;
        //    TestData.GroupName = "Super Admin";
        //    TestData.GroupDescription = "Super Admin";
        //    TestData.IsValid = true;
        //    TestData.CreatedBy = 1;
        //    TestData.CreatedOn = "2018-02-05";
        //    TestData.UpdatedBy = 1;
        //    TestData.UpdatedOn = "2018-02-16";
        //    TestData.CreatedByName = "Amol Wabale";
        //    TestData.UpdatedByName = "Amol Wabale";

        //    var TempIdentityGroupRight1 = new IdentityGroupRight();
        //    TempIdentityGroupRight1.Id = 1;
        //    TempIdentityGroupRight1.GroupId = 1;
        //    TempIdentityGroupRight1.RightId = 1;
        //    TempIdentityGroupRight1.RightTitle = "Group";
        //    TempIdentityGroupRight1.Action = 7;
        //    TempIdentityGroupRight1.IsValid = true;
        //    TempIdentityGroupRight1.CreatedBy = 1;
        //    TempIdentityGroupRight1.UpdatedBy = 1;
        //    TempIdentityGroupRight1.CreatedOn = "2018-02-02";
        //    TempIdentityGroupRight1.UpdatedOn = "2018-02-16";
        //    TempIdentityGroupRight1.CreatedByName = "Amol Wabale";
        //    TempIdentityGroupRight1.UpdatedByName = "Amol Wabale";
        //    TempIdentityGroupRight1.BooleanRight = new BooleanRights() { Delete = true, Read = true, Write = true };
        //    TestData.GroupRight.Add(TempIdentityGroupRight1);

        //    var TempIdentityGroupRight2 = new IdentityGroupRight();
        //    TempIdentityGroupRight2.Id = 14;
        //    TempIdentityGroupRight2.GroupId = 1;
        //    TempIdentityGroupRight2.RightId = 2;
        //    TempIdentityGroupRight2.RightTitle = "User Group";
        //    TempIdentityGroupRight2.Action = 7;
        //    TempIdentityGroupRight2.IsValid = true;
        //    TempIdentityGroupRight2.CreatedBy = 1;
        //    TempIdentityGroupRight2.UpdatedBy = 1;
        //    TempIdentityGroupRight2.CreatedOn = "2018-02-02";
        //    TempIdentityGroupRight2.UpdatedOn = "2018-02-16";
        //    TempIdentityGroupRight2.CreatedByName = "Amol Wabale";
        //    TempIdentityGroupRight2.UpdatedByName = "Amol Wabale";
        //    TempIdentityGroupRight2.BooleanRight = new BooleanRights() { Delete = true, Read = true, Write = true };
        //    TestData.GroupRight.Add(TempIdentityGroupRight2);

        //    var TempIdentityGroupRight3 = new IdentityGroupRight();
        //    TempIdentityGroupRight3.Id = 15;
        //    TempIdentityGroupRight3.GroupId = 1;
        //    TempIdentityGroupRight3.RightId = 3;
        //    TempIdentityGroupRight3.RightTitle = "Employee";
        //    TempIdentityGroupRight3.Action = 7;
        //    TempIdentityGroupRight3.IsValid = true;
        //    TempIdentityGroupRight3.CreatedBy = 1;
        //    TempIdentityGroupRight3.UpdatedBy = 1;
        //    TempIdentityGroupRight3.CreatedOn = "2018-02-02";
        //    TempIdentityGroupRight3.UpdatedOn = "2018-02-16";
        //    TempIdentityGroupRight3.CreatedByName = "Amol Wabale";
        //    TempIdentityGroupRight3.UpdatedByName = "Amol Wabale";
        //    TempIdentityGroupRight3.BooleanRight = new BooleanRights() { Delete = true, Read = true, Write = true };
        //    TestData.GroupRight.Add(TempIdentityGroupRight3);

        //    MasterGroupController objMasterGroupController = new MasterGroupController(new MasterGroupService());

        //    var identity0 = new ClaimsIdentity("");
        //    identity0.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
        //    identity0.AddClaim(new Claim("Id", "CUE335"));
        //    identity0.AddClaim(new Claim("UserName", "Amol Wabale"));
            
        //    objMasterGroupController.Post(TestData);
        //}


    }
   
}
