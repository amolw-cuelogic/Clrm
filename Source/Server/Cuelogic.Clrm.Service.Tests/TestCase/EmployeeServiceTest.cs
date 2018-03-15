using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Repository.Employees;
using Moq;
using Cuelogic.Clrm.Service.Employees;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.MockData;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class EmployeeServiceTest
    {
        Mock<IEmployeeRepository> mockService = new Mock<IEmployeeRepository>();

        [TestMethod]
        public void TestEmployeeServiceDelete()
        {
            //ARRANGE
            var serviceObject = new EmployeeService();
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkEmployeeInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField("_employeeRepository", mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

        [TestMethod]
        public void TestEmployeeServiceGetItem()
        {
            //ARRANGE
            var serviceObject = new EmployeeService();
            var privateObject = new PrivateObject(serviceObject);
            var mockDataEmployeeVm = EmployeeMockData.GetMockDataEmployeeVm();
            var mockDataEmployee = EmployeeMockData.GetMockDataEmployee();
            mockService.Setup(m => m.GetMasterListForEmployees()).Returns(mockDataEmployeeVm);
            mockService.Setup(m => m.GetEmployee(It.IsAny<int>())).Returns(mockDataEmployee);
            mockService.Setup(m => m.GetChildListForEmployees(It.IsAny<int>())).Returns(mockDataEmployee);
            privateObject.SetField("_employeeRepository", mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(EmployeeVm));
            Assert.IsTrue(data.Employee.Id == 1);
            Assert.IsTrue(data.IdentityGroupList.Count > 0);
            Assert.IsTrue(data.MasterDepartmentList.Count > 0);
            Assert.IsTrue(data.MasterOrganizationRoleList.Count > 0);
            Assert.IsTrue(data.MasterSkillList.Count > 0);
        }

        [TestMethod]
        public void TestEmployeeServiceGetList()
        {
            //ARRANGE
            var serviceObject = new EmployeeService();
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataEmployeeDataset();
            mockService.Setup(m => m.GetEmployeeList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField("_employeeRepository", mockService.Object);
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
        public void TestEmployeeServiceSave()
        {
            //ARRANGE
            var serviceObject = new EmployeeService();
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = EmployeeMockData.GetMockDataEmployeeVm();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateEmployee(It.IsAny<EmployeeVm>(), It.IsAny<UserContext>()));
            privateObject.SetField("_employeeRepository", mockService.Object);

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

    }
}
