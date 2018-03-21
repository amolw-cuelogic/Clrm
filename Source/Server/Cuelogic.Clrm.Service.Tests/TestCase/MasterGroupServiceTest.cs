using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class MasterGroupServiceTest
    {
        private Mock<IMasterGroupRepository> mockService = new Mock<IMasterGroupRepository>();
        private MasterGroupService serviceObject = new MasterGroupService();
        private string dependencyField = "_masterGroupRepository";
        private const string _testCategory = "Service - Master Group";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupServiceGetList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataMasterGroupListDataset();
            mockService.Setup(m => m.GetIdentityGroupList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = MasterGroupMockData.GetMockDataMasterGroupList();

            //ACT
            var data = serviceObject.GetList(searchParam);
            var dt = Helper.JsonStringToDatatable(data);

            //ASSERT
            mockService.Verify(m => m.GetIdentityGroupList(It.IsAny<SearchParam>()));
            mockService.Verify(m => m.GetIdentityGroupList(It.IsAny<SearchParam>()), Times.Once);
            mockService.Verify();
            Assert.IsNotNull(data);
            Assert.IsTrue(data != "");
            Assert.IsInstanceOfType(data, typeof(string));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsTrue(dt.Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupServiceGetItem_Condition1()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataMasterGroupDataSet();
            var mockDataGroupRights = MasterGroupMockData.GetMockDataEmployeeGroupRightDataset();
            var mockDataIdentityRightList = MasterGroupMockData.GetMockDataIdentityRightListDataSet();
            mockService.Setup(m => m.GetGroup(It.IsAny<int>())).Returns(mockData);
            mockService.Setup(m => m.GetIdentityGroupRights(It.IsAny<int>())).Returns(mockDataGroupRights);
            mockService.Setup(m => m.GetIdentityRightList()).Returns(mockDataIdentityRightList);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            mockService.Verify(m => m.GetGroup(It.IsAny<int>()));
            mockService.Verify(m => m.GetGroup(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetIdentityGroupRights(It.IsAny<int>()));
            mockService.Verify(m => m.GetIdentityGroupRights(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetIdentityRightList(), Times.Never);
            mockService.Verify();
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(IdentityGroup));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupServiceGetItem_Condition2()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataMasterGroupDataSet();
            var mockDataGroupRights = MasterGroupMockData.GetMockDataEmployeeGroupRightDataset();
            var mockDataIdentityRightList = MasterGroupMockData.GetMockDataIdentityRightListDataSet();
            mockService.Setup(m => m.GetGroup(It.IsAny<int>())).Returns(mockData);
            mockService.Setup(m => m.GetIdentityGroupRights(It.IsAny<int>())).Returns(mockDataGroupRights);
            mockService.Setup(m => m.GetIdentityRightList()).Returns(mockDataIdentityRightList);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetItem(0);

            //ASSERT
            mockService.Verify(m => m.GetGroup(It.IsAny<int>()), Times.Never);
            mockService.Verify(m => m.GetIdentityGroupRights(It.IsAny<int>()), Times.Never);
            mockService.Verify(m => m.GetIdentityRightList());
            mockService.Verify(m => m.GetIdentityRightList(), Times.Once);
            mockService.Verify();
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(IdentityGroup));
            Assert.IsTrue(data.Id == 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupServiceSave_Condition1()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterGroupMockData.GetMockDataMasterGroup();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            var mockDataLatestId = MasterGroupMockData.GetMockDataGetLatestId();
            mockService.Setup(m => m.SaveIdentityGroup(It.IsAny<IdentityGroup>())).Returns(mockDataLatestId);
            mockService.Setup(m => m.SaveIdentityGroupRight(It.IsAny<string>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            mockdata.Id = 0;
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.UpdateIdentityGroup(It.IsAny<IdentityGroup>()), Times.Never);
            mockService.Verify(m => m.UpdateIdentityGroupRight(It.IsAny<string>()), Times.Never);
            mockService.Verify(m => m.SaveIdentityGroup(It.IsAny<IdentityGroup>()));
            mockService.Verify(m => m.SaveIdentityGroup(It.IsAny<IdentityGroup>()), Times.Once);
            mockService.Verify(m => m.SaveIdentityGroupRight(It.IsAny<string>()));
            mockService.Verify(m => m.SaveIdentityGroupRight(It.IsAny<string>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupServiceSave_Condition2()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterGroupMockData.GetMockDataMasterGroup();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.UpdateIdentityGroup(It.IsAny<IdentityGroup>()));
            mockService.Setup(m => m.UpdateIdentityGroupRight(It.IsAny<string>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.UpdateIdentityGroup(It.IsAny<IdentityGroup>()));
            mockService.Verify(m => m.UpdateIdentityGroup(It.IsAny<IdentityGroup>()), Times.Once);
            mockService.Verify(m => m.UpdateIdentityGroupRight(It.IsAny<string>()));
            mockService.Verify(m => m.UpdateIdentityGroupRight(It.IsAny<string>()), Times.Once);
            mockService.Verify(m => m.SaveIdentityGroup(It.IsAny<IdentityGroup>()), Times.Never);
            mockService.Verify(m => m.SaveIdentityGroupRight(It.IsAny<string>()), Times.Never);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupServiceDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkGroupInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkGroupInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkGroupInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
