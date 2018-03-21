using Cuelogic.Clrm.Model.DatabaseModel;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cuelogic.Clrm.Model.CommonModel;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.Repository.Tests.TestCase
{
    [TestClass]
    public class AllocationRepositoryTest
    {
        private Mock<IDataAccess> mockService = new Mock<IDataAccess>();
        private AllocationRepository serviceObject = new AllocationRepository();
        private string dependencyField = "_dataAccess";
        private const string _testCategory = "Repository - Allocation";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryMarkAllocationInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkAllocationInvalid(1,1);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryGetAllocationSum()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataAllocationIdDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockdata);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetAllocationSum(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(DataSet));
            Assert.IsTrue(data.Tables[0].Rows.Count > 0);

        }
        
        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryGetAllocation()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);

            var mockdata = AllocationMockData.GetMockDataAllocationDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockdata);

            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetAllocation(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(DataSet));
            Assert.IsTrue(data.Tables[0].Rows.Count > 0);

        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryGetAllocationList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataAllocationListDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockdata);
            privateObject.SetField(dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };

            //ACT
            var data = serviceObject.GetAllocationList(searchParam);
            var dt = data.Tables[0].ToJsonString();

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsTrue(dt != "");
            Assert.IsInstanceOfType(data, typeof(DataSet));
            Assert.IsInstanceOfType(dt, typeof(string));
            Assert.IsTrue(data.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryGetProjectRolebyId()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataMasterRoleListDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockdata);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetProjectRolebyId(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(DataSet));
            Assert.IsTrue(data.Tables[0].Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryAddOrUpdateAllocation()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);

            var mockdata = AllocationMockData.GetMockDataAllocation();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.AddOrUpdateAllocation(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()));
            mockService.Verify(m => m.ExecuteNonQuery(It.IsAny<DataAccessParameter>()), Times.Once);
            mockService.VerifyAll();

        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryGetAllocationSelectList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataAllocationSelectListDataset();
            mockService.Setup(m => m.ExecuteQuery(It.IsAny<DataAccessParameter>())).Returns(mockdata);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetAllocationSelectList();

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(DataSet));
            Assert.IsTrue(data.Tables[0].Rows.Count > 0);
        }

    }

}
