using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Repository.Common;
using Moq;
using Cuelogic.Clrm.Service.Common;
using Cuelogic.Clrm.MockData;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Employees;
using Cuelogic.Clrm.Service.Employees;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class CommonServiceTest
    {
        private Mock<ICommonRepository> mockService = new Mock<ICommonRepository>();
        private CommonService serviceObject = new CommonService();
        private string _dependencyField = "_commonRepository";
        private const string _testCategory = "Service - Common";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestCommonGetEmployeeAllocationList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = AllocationMockData.GetMockDataAllocationList();
            mockService.Setup(m => m.GetEmployeeAllocationList(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetEmployeeAllocationList(1);
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
        public void TestCommonGetEmployeeByEmail()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataEmployee();
            mockService.Setup(m => m.GetEmployeeDetails(It.IsAny<string>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetEmployeeByEmail("john.doe@cuelogic.com");

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(Employee));
            Assert.IsTrue(data.Email == "john.doe@cuelogic.com");
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestCommonGetEmployeeById()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockService = new Mock<IEmployeeService>();
            var mockData = EmployeeMockData.GetMockDataEmployeeVm();
            mockService.Setup(m => m.GetItem(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField("_employeeService", mockService.Object);
            //ACT
            var data = serviceObject.GetEmployeeById(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(EmployeeVm));
            Assert.IsTrue(data.Employee.Email == "john.doe@cuelogic.com");
            Assert.IsTrue(data.IdentityGroupList.Count > 0);
            Assert.IsTrue(data.MasterDepartmentList.Count > 0);
            Assert.IsTrue(data.MasterOrganizationRoleList.Count > 0);
            Assert.IsTrue(data.MasterSkillList.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestCommonGetEmployeeRights()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataIdentityGroupRight();
            mockService.Setup(m => m.GetGroupRights(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetEmployeeRights(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<IdentityGroupRight>));
            Assert.IsTrue(data.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestCommonLogLoginTime()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.LogLoginTime(It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.LogLoginTime(1);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestCommonSave()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockDataEmployeeVm = EmployeeMockData.GetMockDataEmployeeVm();
            var userContextMockData = CommonMockData.GetMockDataUserContext();
            var mockService = new Mock<IEmployeeService>();
            mockService.Setup(m => m.Save(It.IsAny<EmployeeVm>(), It.IsAny<UserContext>()));
            privateObject.SetField("_employeeService", mockService.Object);

            //ACT
            serviceObject.Save(mockDataEmployeeVm, userContextMockData);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }
    }
}
