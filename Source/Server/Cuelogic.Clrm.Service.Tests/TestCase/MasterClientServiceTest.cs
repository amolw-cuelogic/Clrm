using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Model.CommonModel;
using System.Data;
using Cuelogic.Clrm.Repository.Interface;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class MasterClientServiceTest
    {
        private Mock<IMasterClientRepository> mockService = new Mock<IMasterClientRepository>();
        private MasterClientService serviceObject = new MasterClientService();
        private string dependencyField = "_masterClientRepository";
        private const string _testCategory = "Service - Master Client";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientServiceDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterClientInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkMasterClientInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkMasterClientInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientServiceGetItem()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterClientMockData.GetMockDataMasterClient();
            mockService.Setup(m => m.GetMasterClient(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterClient));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientServiceGetList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterClientMockData.GetMockDataMasterClientDataset();
            mockService.Setup(m => m.GetMasterClientList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = EmployeeMockData.GetMockDataemployeeList();

            //ACT
            var data = serviceObject.GetList(searchParam);
            var dt = Helper.JsonStringToDatatable(data);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsTrue(data != "");
            Assert.IsInstanceOfType(data, typeof(string));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsTrue(dt.Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterClientServiceGetCityList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterClientMockData.GetMockDataMasterCity();
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
        public void TestMasterClientServiceSave()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterClientMockData.GetMockDataMasterClient();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateMasterClient(It.IsAny<MasterClient>(), It.IsAny<UserContext>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.AddOrUpdateMasterClient(It.IsAny<MasterClient>(), It.IsAny<UserContext>()));
            mockService.Verify(m => m.AddOrUpdateMasterClient(It.IsAny<MasterClient>(), It.IsAny<UserContext>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
