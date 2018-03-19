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
    public class MasterDepartmentRepositoryTest
    {
        private Mock<IMasterDepartmentDataAccess> mockService = new Mock<IMasterDepartmentDataAccess>();
        private MasterDepartmentRepository serviceObject = new MasterDepartmentRepository();
        private string dependencyField = "_masterDepartmentDataAccess";
        private const string _testCategory = "Repository - Master Department";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentRepositoryMarkMasterDepartmentInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterDepartmentInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkMasterDepartmentInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkMasterDepartmentInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkMasterDepartmentInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentRepositoryGetMasterDepartment()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterDepartmentMockData.GetMockDataMasterDepartmentDataset();
            mockService.Setup(m => m.GetMasterDepartment(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetMasterDepartment(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterDepartment));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentRepositoryGetMasterDepartmentList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterDepartmentMockData.GetMockDataMasterDepartmentListDataset();
            mockService.Setup(m => m.GetMasterDepartmentList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };

            //ACT
            var data = serviceObject.GetMasterDepartmentList(searchParam);
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
        public void TestMasterDepartmentRepositorySaveMasterDepartment()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterDepartmentMockData.GetMockDataMasterDepartment();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.InsertMasterDepartment(It.IsAny<MasterDepartment>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            mockdata.Id = 0;
            serviceObject.SaveMasterDepartment(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.UpdateMasterDepartment(It.IsAny<MasterDepartment>()), Times.Never);
            mockService.Verify(m => m.InsertMasterDepartment(It.IsAny<MasterDepartment>()));
            mockService.Verify(m => m.InsertMasterDepartment(It.IsAny<MasterDepartment>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentRepositoryUpdateMasterDepartment()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterDepartmentMockData.GetMockDataMasterDepartment();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.UpdateMasterDepartment(It.IsAny<MasterDepartment>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.UpdateMasterDepartment(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.InsertMasterDepartment(It.IsAny<MasterDepartment>()), Times.Never);
            mockService.Verify(m => m.UpdateMasterDepartment(It.IsAny<MasterDepartment>()));
            mockService.Verify(m => m.UpdateMasterDepartment(It.IsAny<MasterDepartment>()), Times.Once);
            mockService.VerifyAll();
        }
    }
}
