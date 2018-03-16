using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Repository.UserGroup;
using Moq;
using Cuelogic.Clrm.Service.UserGroup;
using Cuelogic.Clrm.MockData;
using System.Collections.Generic;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;

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
        public void TestUserGroupGetEmployeeList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = UserGroupMockData.GetEmployeeList();
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
        public void TestUserGroupGetGroupList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = UserGroupMockData.GetGroupList();
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
        public void TestUserGroupGetIdentityGroupMembers()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = UserGroupMockData.GetIdentityGroupMemberList();
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
        public void TestUserGroupInsertGroupUsers()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = UserGroupMockData.GetIdentityEmployeeGroupList();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.InsertGroupUsers(It.IsAny<List<IdentityEmployeeGroup>>(), It.IsAny<UserContext>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.InsertGroupUsers(mockData, mockDataUserContext);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }
    }
}
