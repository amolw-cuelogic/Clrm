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
        private Mock<IEmployeeDataAccess> mockService = new Mock<IEmployeeDataAccess>();
        private EmployeeRepository serviceObject = new EmployeeRepository();
        private string dependencyField = "_employeeDataAccess";
        private const string _testCategory = "Repository - Employee";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeRepositoryMarkEmployeeInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkEmployeeInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkEmployeeInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkEmployeeInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkEmployeeInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeRepositoryGetEmployeeList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataEmployeeDataset();
            mockService.Setup(m => m.GetEmployeeList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };

            //ACT
            var ds = serviceObject.GetEmployeeList(searchParam);
            var jsonStr = ds.Tables[0].ToJsonString();

            //ASSERT
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
            mockService.Setup(m => m.GetEmployee(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetEmployee(1);

            //ASSERT
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
            var mockData = EmployeeMockData.GetMockDataDependentListDataset();
            mockService.Setup(m => m.GetMasterListForEmployees()).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetMasterListForEmployees();

            //ASSERT
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
            var mockData = EmployeeMockData.GetMockDataDependentListDataset();
            mockService.Setup(m => m.GetChildListForEmployees(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetChildListForEmployees(1);

            //ASSERT
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
            mockService.Setup(m => m.AddOrUpdateEmployee(It.IsAny<Employee>()));
            mockService.Setup(m => m.AddOrUpdateEmployeeDepartment(It.IsAny<string>(), It.IsAny<int>()));
            mockService.Setup(m => m.AddOrUpdateEmployeeGroup(It.IsAny<string>(), It.IsAny<int>()));
            mockService.Setup(m => m.AddOrUpdateEmployeeOrganizationRole(It.IsAny<string>(), It.IsAny<int>()));
            mockService.Setup(m => m.AddOrUpdateEmployeeSkill(It.IsAny<string>(), It.IsAny<int>()));

            Mock<ICommonDataAccess> mockService1 = new Mock<ICommonDataAccess>();
            var mockData1 = EmployeeMockData.GetMockDataEmployeeBlankDataset();
            mockService1.Setup(m => m.GetEmployeeDetailsByEmailId(It.IsAny<string>())).Returns(mockData1);
            mockService1.Setup(m => m.GetEmployeeDetailsByOrgEmpId(It.IsAny<string>())).Returns(mockData1);

            privateObject.SetField(dependencyField, mockService.Object);
            privateObject.SetField("_commonDataAccess", mockService1.Object);
            //ACT
            serviceObject.AddOrUpdateEmployee(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.AddOrUpdateEmployee(It.IsAny<Employee>()));
            mockService.Verify(m => m.AddOrUpdateEmployee(It.IsAny<Employee>()), Times.Once);
            mockService.Verify(m => m.AddOrUpdateEmployeeDepartment(It.IsAny<string>(), It.IsAny<int>()));
            mockService.Verify(m => m.AddOrUpdateEmployeeDepartment(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.AddOrUpdateEmployeeGroup(It.IsAny<string>(), It.IsAny<int>()));
            mockService.Verify(m => m.AddOrUpdateEmployeeGroup(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.AddOrUpdateEmployeeOrganizationRole(It.IsAny<string>(), It.IsAny<int>()));
            mockService.Verify(m => m.AddOrUpdateEmployeeOrganizationRole(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.AddOrUpdateEmployeeSkill(It.IsAny<string>(), It.IsAny<int>()));
            mockService.Verify(m => m.AddOrUpdateEmployeeSkill(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            mockService1.Verify(m => m.GetEmployeeDetailsByEmailId(It.IsAny<string>()));
            mockService1.Verify(m => m.GetEmployeeDetailsByEmailId(It.IsAny<string>()), Times.Once);
            mockService1.Verify(m => m.GetEmployeeDetailsByOrgEmpId(It.IsAny<string>()));
            mockService1.Verify(m => m.GetEmployeeDetailsByOrgEmpId(It.IsAny<string>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
