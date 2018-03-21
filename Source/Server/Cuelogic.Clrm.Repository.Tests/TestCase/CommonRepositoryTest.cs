using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.MockData;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Service;
using Cuelogic.Clrm.Service.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.Model.CommonModel;

namespace Cuelogic.Clrm.Repository.Tests.TestCase
{
    [TestClass]
    public class CommonRepositoryTest
    {
        private Mock<IDataAccess> mockService = new Mock<IDataAccess>();
        private CommonRepository serviceObject = new CommonRepository();
        private string _dependencyField = "_dataAccess";
        private const string _testCategory = "Repository - Common";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestCommonRepositoryGetEmployeeAllocationList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = AllocationMockData.GetMockDataAllocationListDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetEmployeeAllocationList(1);
            var jsonString = data.Tables[0].ToJsonString();

            //ASSERT
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
            Assert.IsNotNull(data);
            Assert.IsTrue(jsonString != "");
            Assert.IsInstanceOfType(jsonString, typeof(string));
            Assert.IsInstanceOfType(data.Tables[0], typeof(DataTable));
            Assert.IsInstanceOfType(data, typeof(DataSet));
            Assert.IsTrue(data.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestCommonRepositoryGetEmployeeDetails()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataEmployeeDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetEmployeeDetails("john.doe@cuelogic.com");

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
        public void TestCommonRepositoryGetEmployeeDetailsByOrgEmpId()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = EmployeeMockData.GetMockDataEmployeeDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetEmployeeDetails("CUE346");

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
        public void TestCommonRepositoryGetGroupRights()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterGroupMockData.GetMockDataEmployeeGroupRightDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetGroupRights(1);

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
        public void TestCommonRepositoryLogLoginTime()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.LogLoginTime(1);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
        }
        
    }
}
