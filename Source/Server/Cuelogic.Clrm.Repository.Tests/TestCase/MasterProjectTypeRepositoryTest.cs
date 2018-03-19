using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Service;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.Repository.Tests.TestCase
{
    [TestClass]
    public class MasterProjectTypeRepositoryTest
    {
        private Mock<IMasterProjectTypeDataAccess> mockService = new Mock<IMasterProjectTypeDataAccess>();
        private MasterProjectTypeRepository serviceObject = new MasterProjectTypeRepository();
        private string _dependencyField = "_masterProjectTypeDataAccess";
        private const string _testCategory = "Repository - Master Project Type";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterProjectTypeRepositoryMarkMasterProjectTypeInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterProjectTypeInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkMasterProjectTypeInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkMasterProjectTypeInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkMasterProjectTypeInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterProjectTypeRepositoryGetMasterProjectType()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterProjectTypeMockData.GetMockDataMasterProjectTypeDataset();
            mockService.Setup(m => m.GetMasterProjectType(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetMasterProjectType(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterProjectType));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterProjectTypeRepositoryGetMasterProjectTypeList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterProjectTypeMockData.GetMockDataMasterProjectTypeDataset();
            mockService.Setup(m => m.GetMasterProjectTypeList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };

            //ACT
            var data = serviceObject.GetMasterProjectTypeList(searchParam);
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
        public void TestMasterProjectTypeRepositoryGetMasterProjectTypeValidList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterProjectTypeMockData.GetMockDataMasterProjectTypeDataset();
            mockService.Setup(m => m.GetMasterProjectTypeValidList()).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetMasterProjectTypeValidList();
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
        public void TestMasterProjectTypeRepositoryAddOrUpdateMasterProjectType()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterProjectTypeMockData.GetMockDataMasterProjectType();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateMasterProjectType(It.IsAny<MasterProjectType>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.AddOrUpdateMasterProjectType(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.AddOrUpdateMasterProjectType(It.IsAny<MasterProjectType>()));
            mockService.Verify(m => m.AddOrUpdateMasterProjectType(It.IsAny<MasterProjectType>()), Times.Once);
            mockService.VerifyAll();
        }
    }
}
