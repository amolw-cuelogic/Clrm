﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.MockData;
using System.Collections.Generic;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Service;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.Repository.Tests.TestCase
{
    [TestClass]
    public class UserGroupRepositoryTest
    {
        private Mock<IUserGroupDataAccess> mockService = new Mock<IUserGroupDataAccess>();
        private UserGroupRepository serviceObject = new UserGroupRepository();
        private string _dependencyField = "_userGroupDataAcces";
        private const string _testCategory = "Repository - User Group";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestUserGroupRepositoryGetEmployeeList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataEmployeeListDataset();
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
        public void TestUserGroupRepositoryGetGroupList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataMasterGroupListDataset();
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
        public void TestUserGroupRepositoryGetIdentityGroupMembers()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataEmployeeListDataset();
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
        public void TestUserGroupRepositoryInsertGroupUsers()
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