using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.MockData;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Service.Interface;

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
        public void TestCommonServiceGetEmployeeAllocationList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = AllocationMockData.GetMockDataAllocationListDataset();
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
        public void TestCommonServiceGetEmployeeByEmail()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataEmployeeDataset();
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
        public void TestCommonServiceGetEmployeeById()
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
        public void TestCommonServiceGetEmployeeRights()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataEmployeeGroupRightDataset();
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
        public void TestCommonServiceLogLoginTime()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.LogLoginTime(It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.LogLoginTime(1);

            //ASSERT
            mockService.Verify(m => m.LogLoginTime(It.IsAny<int>()));
            mockService.Verify(m => m.LogLoginTime(It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestCommonServiceSave()
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
            mockService.Verify(m => m.Save(It.IsAny<EmployeeVm>(), It.IsAny<UserContext>()));
            mockService.Verify(m => m.Save(It.IsAny<EmployeeVm>(), It.IsAny<UserContext>()), Times.Once);
            mockService.VerifyAll();
        }
    }
}
