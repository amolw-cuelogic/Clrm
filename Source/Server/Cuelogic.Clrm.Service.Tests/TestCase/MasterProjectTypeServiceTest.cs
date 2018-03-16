using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Repository.ProjectType;
using Moq;
using Cuelogic.Clrm.Service.ProjectType;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class MasterProjectTypeServiceTest
    {
        private Mock<IMasterProjectTypeRepository> mockService = new Mock<IMasterProjectTypeRepository>();
        private MasterProjectTypeService serviceObject = new MasterProjectTypeService();
        private string _dependencyField = "_masterProjectTypeRepository";
        private const string _testCategory = "Service - Master Project Type";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterProjectTypeDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterProjectTypeInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterProjectTypeGetItem()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterProjectTypeMockData.GetMockDataMasterProjectType();
            mockService.Setup(m => m.GetMasterProjectType(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterProjectType));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterProjectTypeGetList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterProjectTypeMockData.GetMockDataMasterProjectTypeDataset();
            mockService.Setup(m => m.GetMasterProjectTypeList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = MasterProjectTypeMockData.GetMockDataMasterProjectTypeList();

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
        public void TestMasterProjectTypeSave()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterProjectTypeMockData.GetMockDataMasterProjectType();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateMasterProjectType(It.IsAny<MasterProjectType>(), It.IsAny<UserContext>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }
    }
}
