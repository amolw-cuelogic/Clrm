using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Repository.Client;
using Moq;
using Cuelogic.Clrm.Service.Client;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.MockData;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class MasterClientServiceTest
    {
        Mock<IMasterClientRepository> mockService = new Mock<IMasterClientRepository>();

        [TestMethod]
        public void TestMasterClientServiceDelete()
        {
            //ARRANGE
            var serviceObject = new MasterClientService();
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterClientInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField("_masterClientRepository", mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

        [TestMethod]
        public void TestMasterClientServiceGetItem()
        {
            //ARRANGE
            var serviceObject = new MasterClientService();
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterClientMockData.GetMockDataMasterClient();
            mockService.Setup(m => m.GetMasterClient(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField("_masterClientRepository", mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterClient));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        public void TestMasterClientServiceGetCityList()
        {
            //ARRANGE
            var serviceObject = new MasterClientService();
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterClientMockData.GetMockDataMasterCity();
            mockService.Setup(m => m.GetCityList(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField("_masterClientRepository", mockService.Object);

            //ACT
            var data = serviceObject.GetCityList(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<MasterCity>));
            Assert.IsTrue(data.Count > 1);
        }

        [TestMethod]
        public void TestMasterClientServiceSave()
        {
            //ARRANGE
            var serviceObject = new MasterClientService();
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterClientMockData.GetMockDataMasterClient();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateMasterClient(It.IsAny<MasterClient>(), It.IsAny<UserContext>()));
            privateObject.SetField("_masterClientRepository", mockService.Object);

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

    }
}
