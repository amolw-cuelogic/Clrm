using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Service;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.Repository.Tests.TestCase
{
    [TestClass]
    public class MasterGroupRepositoryTest
    {
        private Mock<IMasterGroupDataAccess> mockService = new Mock<IMasterGroupDataAccess>();
        private MasterGroupRepository serviceObject = new MasterGroupRepository();
        private string dependencyField = "_masterGroupDataAccess";
        private const string _testCategory = "Repository - Master Group";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositoryGetIdentityGroupList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataMasterGroupListDataset();
            mockService.Setup(m => m.GetIdentityGroupList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };

            //ACT
            var data = serviceObject.GetIdentityGroupList(searchParam);
            var dt = data.Tables[0];
            var jsonStr = dt.ToJsonString();

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsTrue(jsonStr != "");
            Assert.IsInstanceOfType(data, typeof(DataSet));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsInstanceOfType(jsonStr, typeof(string));
            Assert.IsTrue(dt.Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositoryGetGroup_Condition1()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataMasterGroupDataSet();
            mockService.Setup(m => m.GetIdentityGroup(It.IsAny<int>())).Returns(mockData);
            var mockData2 = MasterGroupMockData.GetMockDataEmployeeGroupRightDataset();
            mockService.Setup(m => m.GetIdentityGroupRights(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetGroup(1);

            //ASSERT
            mockService.Verify(m => m.GetIdentityRightList(), Times.Never);
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(IdentityGroup));
            Assert.IsTrue(data.Id == 1);
            Assert.IsTrue(data.GroupRight.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositoryGetGroup_Condition2()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataIdentityRightListDataSet();
            mockService.Setup(m => m.GetIdentityRightList()).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetGroup(0);

            //ASSERT
            mockService.Verify(m => m.GetIdentityGroup(It.IsAny<int>()), Times.Never);
            mockService.Verify(m => m.GetIdentityGroupRights(It.IsAny<int>()), Times.Never);
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(IdentityGroup));
            Assert.IsTrue(data.Id == 0);
            Assert.IsTrue(data.GroupRight.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositorySaveIdentityGroup()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterGroupMockData.GetMockDataMasterGroup();
            var mockdata1 = MasterGroupMockData.GetMockDataGetLatestId();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.InsertIdentityGroup(It.IsAny<IdentityGroup>())).Returns(mockdata1);
            mockService.Setup(m => m.InsertIdentityGroupRight(It.IsAny<string>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            mockdata.Id = 0;
            serviceObject.SaveIdentityGroup(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.UpdateIdentityGroup(It.IsAny<IdentityGroup>()), Times.Never);
            mockService.Verify(m => m.UpdateIdentityGroupRight(It.IsAny<string>()), Times.Never);
            mockService.Verify(m => m.InsertIdentityGroup(It.IsAny<IdentityGroup>()));
            mockService.Verify(m => m.InsertIdentityGroup(It.IsAny<IdentityGroup>()), Times.Once);
            mockService.Verify(m => m.InsertIdentityGroupRight(It.IsAny<string>()));
            mockService.Verify(m => m.InsertIdentityGroupRight(It.IsAny<string>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositoryUpdateIdentityGroup()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterGroupMockData.GetMockDataMasterGroup();
            var mockdata1 = MasterGroupMockData.GetMockDataGetLatestId();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.UpdateIdentityGroup(It.IsAny<IdentityGroup>()));
            mockService.Setup(m => m.UpdateIdentityGroupRight(It.IsAny<string>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.UpdateIdentityGroup(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.InsertIdentityGroup(It.IsAny<IdentityGroup>()), Times.Never);
            mockService.Verify(m => m.InsertIdentityGroupRight(It.IsAny<string>()), Times.Never);
            mockService.Verify(m => m.UpdateIdentityGroup(It.IsAny<IdentityGroup>()));
            mockService.Verify(m => m.UpdateIdentityGroup(It.IsAny<IdentityGroup>()), Times.Once);
            mockService.Verify(m => m.UpdateIdentityGroupRight(It.IsAny<string>()));
            mockService.Verify(m => m.UpdateIdentityGroupRight(It.IsAny<string>()), Times.Once);
            mockService.VerifyAll();
        }


        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientServiceMarkGroupInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkGroupInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkGroupInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkGroupInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkGroupInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
