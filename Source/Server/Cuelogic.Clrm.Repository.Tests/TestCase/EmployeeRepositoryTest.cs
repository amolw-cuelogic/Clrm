using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Service;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.Repository.Tests.TestCase
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private Mock<IDataAccess> mockService = new Mock<IDataAccess>();
        private EmployeeRepository serviceObject = new EmployeeRepository();
        private string _dependencyField = "_dataAccess";
        private const string _testCategory = "Repository - Employee";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeRepositoryMarkEmployeeInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkEmployeeInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeRepositoryGetEmployeeList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataEmployeeDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };

            //ACT
            var ds = serviceObject.GetEmployeeList(searchParam);
            var jsonStr = ds.Tables[0].ToJsonString();

            //ASSERT
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
            Assert.IsNotNull(ds);
            Assert.IsTrue(jsonStr != "");
            Assert.IsInstanceOfType(jsonStr, typeof(string));
            Assert.IsInstanceOfType(ds.Tables[0], typeof(DataTable));
            Assert.IsTrue(ds.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeRepositoryGetEmployee()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataEmployeeDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetEmployee(1);

            //ASSERT
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(DataSet));
            Assert.IsTrue(data.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeRepositoryGetMasterListForEmployees()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataMasterDependentListDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetMasterListForEmployees();

            //ASSERT
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(DataSet));
            Assert.IsTrue(data.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeRepositoryGetChildListForEmployees()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataChildDependentListDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetChildListForEmployees(1);

            //ASSERT
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(DataSet));
            Assert.IsTrue(data.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeRepositoryAddOrUpdateEmployee()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = EmployeeMockData.GetMockDataEmployeeVm();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);
            //ACT
            serviceObject.AddOrUpdateEmployee(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.AtMost(5));
            mockService.VerifyAll();
        }

    }
}
