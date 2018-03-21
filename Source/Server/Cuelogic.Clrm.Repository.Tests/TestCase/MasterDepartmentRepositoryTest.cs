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
        private Mock<IDataAccess> mockService = new Mock<IDataAccess>();
        private MasterDepartmentRepository serviceObject = new MasterDepartmentRepository();
        private string _dependencyField = "_dataAccess";
        private const string _testCategory = "Repository - Master Department";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentRepositoryMarkMasterDepartmentInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkMasterDepartmentInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentRepositoryGetMasterDepartment()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterDepartmentMockData.GetMockDataMasterDepartmentDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var ds = serviceObject.GetMasterDepartment(1);
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
        public void TestMasterDepartmentRepositoryGetMasterDepartmentList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterDepartmentMockData.GetMockDataMasterDepartmentListDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };

            //ACT
            var ds = serviceObject.GetMasterDepartmentList(searchParam);
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
        public void TestMasterDepartmentRepositorySaveMasterDepartment()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterDepartmentMockData.GetMockDataMasterDepartment();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            mockdata.Id = 0;
            serviceObject.SaveMasterDepartment(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
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
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.UpdateMasterDepartment(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
        }
    }
}
