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
        private Mock<IDataAccess> mockService = new Mock<IDataAccess>();
        private MasterGroupRepository serviceObject = new MasterGroupRepository();
        private string _dependencyField = "_dataAccess";
        private const string _testCategory = "Repository - Master Group";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositoryGetIdentityGroupList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataMasterGroupListDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };

            //ACT
            var ds = serviceObject.GetIdentityGroupList(searchParam);
            var dt = ds.Tables[0];
            var jsonString = dt.ToJsonString();

            //ASSERT
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
            Assert.IsNotNull(ds);
            Assert.IsTrue(jsonString != "");
            Assert.IsInstanceOfType(ds, typeof(DataSet));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsInstanceOfType(jsonString, typeof(string));
            Assert.IsTrue(ds.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositoryGetGroup()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataMasterGroupDataSet();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var ds = serviceObject.GetGroup(1);
            var dt = ds.Tables[0];
            var jsonString = dt.ToJsonString();

            //ASSERT
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
            Assert.IsNotNull(ds);
            Assert.IsTrue(jsonString != "");
            Assert.IsInstanceOfType(ds, typeof(DataSet));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsInstanceOfType(jsonString, typeof(string));
            Assert.IsTrue(ds.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositoryGetIdentityGroupRights()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataIdentityRightListDataSet();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var ds = serviceObject.GetIdentityGroupRights(0);
            var dt = ds.Tables[0];
            var jsonString = dt.ToJsonString();

            //ASSERT
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
            Assert.IsNotNull(ds);
            Assert.IsTrue(jsonString != "");
            Assert.IsInstanceOfType(ds, typeof(DataSet));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsInstanceOfType(jsonString, typeof(string));
            Assert.IsTrue(ds.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositoryGetIdentityRightList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataIdentityRightListDataSet();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var ds = serviceObject.GetIdentityRightList();
            var dt = ds.Tables[0];
            var jsonString = dt.ToJsonString();

            //ASSERT
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
            Assert.IsNotNull(ds);
            Assert.IsTrue(jsonString != "");
            Assert.IsInstanceOfType(ds, typeof(DataSet));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsInstanceOfType(jsonString, typeof(string));
            Assert.IsTrue(ds.Tables[0].Rows.Count > 0);
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
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockdata1);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var ds = serviceObject.SaveIdentityGroup(mockdata);
            var dt = ds.Tables[0];
            var jsonString = dt.ToJsonString();

            //ASSERT
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
            Assert.IsNotNull(ds);
            Assert.IsTrue(jsonString != "");
            Assert.IsInstanceOfType(ds, typeof(DataSet));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsInstanceOfType(jsonString, typeof(string));
            Assert.IsTrue(ds.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositorySaveIdentityGroupRight()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = Helper.ObjectToXml(MasterGroupMockData.GetMockDataIdentityGroupRightList());
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.SaveIdentityGroupRight(mockdata);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositoryUpdateIdentityGroup()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataMasterGroup();
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.UpdateIdentityGroup(mockData);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupRepositoryUpdateIdentityGroupRight()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = Helper.ObjectToXml(MasterGroupMockData.GetMockDataIdentityGroupRightList());
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.UpdateIdentityGroupRight(mockdata);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterGroupServiceMarkGroupInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkGroupInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
