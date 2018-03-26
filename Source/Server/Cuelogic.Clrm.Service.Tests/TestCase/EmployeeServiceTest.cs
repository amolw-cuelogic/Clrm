﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Repository.Interface;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class EmployeeServiceTest
    {
        private Mock<IEmployeeRepository> mockService = new Mock<IEmployeeRepository>();
        private EmployeeService serviceObject = new EmployeeService();
        private string dependencyField = "_employeeRepository";
        private const string _testCategory = "Service - Employee";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeServiceDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkEmployeeInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkEmployeeInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkEmployeeInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeServiceGetItem()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockDataEmployeeVm = EmployeeMockData.GetMockDataMasterDependentListDataset();
            var mockDataEmployee = EmployeeMockData.GetMockDataEmployeeDataset();
            var mockDataChildList = EmployeeMockData.GetMockDataChildDependentListDataset();
            mockService.Setup(m => m.GetMasterListForEmployees()).Returns(mockDataEmployeeVm);
            mockService.Setup(m => m.GetEmployee(It.IsAny<int>())).Returns(mockDataEmployee);
            mockService.Setup(m => m.GetChildListForEmployees(It.IsAny<int>())).Returns(mockDataChildList);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            mockService.Verify(m => m.GetEmployee(It.IsAny<int>()));
            mockService.Verify(m => m.GetEmployee(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetChildListForEmployees(It.IsAny<int>()));
            mockService.Verify(m => m.GetChildListForEmployees(It.IsAny<int>()), Times.Once);
            mockService.Verify();
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(EmployeeVm));
            Assert.IsTrue(data.Employee.Id == 1);
            Assert.IsTrue(data.Employee.IdentityEmployeeGroupList.Count > 0);
            Assert.IsTrue(data.Employee.EmployeeDepartmentList.Count > 0);
            Assert.IsTrue(data.Employee.EmployeeOrganizationRoleList.Count > 0);
            Assert.IsTrue(data.Employee.EmployeeSkillList.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeServiceGetMasterList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockDataEmployeeVm = EmployeeMockData.GetMockDataMasterDependentListDataset();
            mockService.Setup(m => m.GetMasterListForEmployees()).Returns(mockDataEmployeeVm);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetMasterList();

            //ASSERT
            mockService.Verify(m => m.GetMasterListForEmployees());
            mockService.Verify(m => m.GetMasterListForEmployees(), Times.Once);
            mockService.Verify();
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(EmployeeVm));
            Assert.IsTrue(data.IdentityGroupList.Count > 0);
            Assert.IsTrue(data.MasterDepartmentList.Count > 0);
            Assert.IsTrue(data.MasterOrganizationRoleList.Count > 0);
            Assert.IsTrue(data.MasterSkillList.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeServiceGetList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataEmployeeDataset();
            mockService.Setup(m => m.GetEmployeeList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = EmployeeMockData.GetMockDataemployeeList();

            //ACT
            var data = serviceObject.GetList(searchParam);
            var dt = Helper.JsonStringToDatatable(data);

            //ASSERT
            mockService.Verify(m => m.GetEmployeeList(It.IsAny<SearchParam>()));
            mockService.Verify(m => m.GetEmployeeList(It.IsAny<SearchParam>()), Times.Once);
            mockService.Verify();
            Assert.IsNotNull(data);
            Assert.IsTrue(data != "");
            Assert.IsInstanceOfType(data, typeof(string));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsTrue(dt.Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestEmployeeServiceSave()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = EmployeeMockData.GetMockDataEmployeeVm();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateEmployee(It.IsAny<EmployeeVm>(), It.IsAny<UserContext>()));

            var mockData2 = EmployeeMockData.GetMockDataEmployeeDataset();
            Mock<ICommonRepository> mockService1 = new Mock<ICommonRepository>();
            mockService1.Setup(m => m.GetEmployeeDetails(It.IsAny<string>())).Returns(mockData2);
            mockService1.Setup(m => m.GetEmployeeDetailsByOrgEmpId(It.IsAny<string>())).Returns(mockData2);

            privateObject.SetField(dependencyField, mockService.Object);
            privateObject.SetField("_commonRepository", mockService1.Object);

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.AddOrUpdateEmployee(It.IsAny<EmployeeVm>(), It.IsAny<UserContext>()));
            mockService.Verify(m => m.AddOrUpdateEmployee(It.IsAny<EmployeeVm>(), It.IsAny<UserContext>()), Times.Once);
            mockService1.Verify(m => m.GetEmployeeDetails(It.IsAny<string>()));
            mockService1.Verify(m => m.GetEmployeeDetails(It.IsAny<string>()), Times.Once);
            mockService1.Verify(m => m.GetEmployeeDetailsByOrgEmpId(It.IsAny<string>()));
            mockService1.Verify(m => m.GetEmployeeDetailsByOrgEmpId(It.IsAny<string>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
