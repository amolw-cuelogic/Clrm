using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Model.CommonModel;
using System.Data;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Service;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.Repository.Tests.TestCase
{
    [TestClass]
    public class MasterClientRepositoryTest
    {
        private Mock<IDataAccess> mockService = new Mock<IDataAccess>();
        private MasterClientRepository serviceObject = new MasterClientRepository();
        private string _dependencyField = "_dataAccess";
        private const string _testCategory = "Repository - Master Client";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientRepositoryMarkMasterClientInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkMasterClientInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientRepositoryGetMasterClient()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterClientMockData.GetMockDataMasterClientDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var ds = serviceObject.GetMasterClient(1);
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
        public void TestMasterClientRepositoryGetMasterClientList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterClientMockData.GetMockDataMasterClientDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };

            //ACT
            var ds = serviceObject.GetMasterClientList(searchParam);
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
            Assert.IsTrue(dt.Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientRepositoryGetCityList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterClientMockData.GetMockDataCityListDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var ds = serviceObject.GetCityList(1);
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
            Assert.IsTrue(dt.Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientRepositoryGetCountryList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterClientMockData.GetMockDataCountryListDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var ds = serviceObject.GetCountryList();
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
            Assert.IsTrue(dt.Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientRepositoryAddOrUpdateMasterClient()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterClientMockData.GetMockDataMasterClient();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.AddOrUpdateMasterClient(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
