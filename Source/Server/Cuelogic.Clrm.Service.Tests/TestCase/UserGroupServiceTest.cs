using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.MockData;
using System.Collections.Generic;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository.Interface;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class UserGroupServiceTest
    {
        private Mock<IUserGroupRepository> mockService = new Mock<IUserGroupRepository>();
        private UserGroupService serviceObject = new UserGroupService();
        private string _dependencyField = "_userGroupRepository";
        private const string _testCategory = "Service - User Group";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestUserGroupServiceGetEmployeeList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = UserGroupMockData.GetEmployeeListDataset();
            mockService.Setup(m => m.GetEmployeeList()).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetEmployeeList();

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<Employee>));
            Assert.IsTrue(data.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestUserGroupServiceGetGroupList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = UserGroupMockData.GetGroupListDataset();
            mockService.Setup(m => m.GetGroupList()).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetGroupList();

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<IdentityGroup>));
            Assert.IsTrue(data.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestUserGroupServiceGetIdentityGroupMembers()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = UserGroupMockData.GetIdentityGroupMemberListDataset();
            mockService.Setup(m => m.GetIdentityGroupMembers(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetIdentityGroupMembers(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<Employee>));
            Assert.IsTrue(data.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestUserGroupServiceInsertGroupUsers()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = UserGroupMockData.GetIdentityEmployeeGroupList();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.InsertGroupUsers(It.IsAny<string>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.InsertGroupUsers(mockData, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.InsertGroupUsers(It.IsAny<string>()));
            mockService.Verify(m => m.InsertGroupUsers(It.IsAny<string>()), Times.Once);
            mockService.VerifyAll();
        }
    }
}
