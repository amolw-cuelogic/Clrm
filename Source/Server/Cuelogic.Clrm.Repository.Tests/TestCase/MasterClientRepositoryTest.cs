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
        private Mock<IMasterClientDataAccess> mockService = new Mock<IMasterClientDataAccess>();
        private MasterClientRepository serviceObject = new MasterClientRepository();
        private string dependencyField = "_masterClientDataAccess";
        private const string _testCategory = "Repository - Master Client";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientRepositoryMarkMasterClientInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterClientInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkMasterClientInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkMasterClientInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkMasterClientInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientRepositoryGetMasterClient()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterClientMockData.GetMockDataMasterClientDataset();
            mockService.Setup(m => m.GetMasterClient(It.IsAny<int>())).Returns(mockData);
            var mockData1 = MasterClientMockData.GetMockDataCityListDataset();
            mockService.Setup(m => m.GetCityList(It.IsAny<int>())).Returns(mockData1);
            var mockData2 = MasterClientMockData.GetMockDataCountryListDataset();
            mockService.Setup(m => m.GetCountryList()).Returns(mockData2);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetMasterClient(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterClient));
            Assert.IsTrue(data.Id == 1);
            mockService.Verify(m => m.GetCityList(It.IsAny<int>()));
            mockService.Verify(m => m.GetCityList(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetCountryList());
            mockService.Verify(m => m.GetCountryList(), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientRepositoryGetMasterClientList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterClientMockData.GetMockDataMasterClientDataset();
            mockService.Setup(m => m.GetMasterClientList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };

            //ACT
            var data = serviceObject.GetMasterClientList(searchParam);
            var dt = data.Tables[0];
            var jsonString = dt.ToJsonString();

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsTrue(jsonString != "");
            Assert.IsInstanceOfType(data, typeof(DataSet));
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
            mockService.Setup(m => m.GetCityList(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetCityList(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<MasterCity>));
            Assert.IsTrue(data.Count > 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientRepositoryAddOrUpdateMasterClient()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterClientMockData.GetMockDataMasterClient();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateMasterClient(It.IsAny<MasterClient>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.AddOrUpdateMasterClient(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.AddOrUpdateMasterClient(It.IsAny<MasterClient>()));
            mockService.Verify(m => m.AddOrUpdateMasterClient(It.IsAny<MasterClient>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
