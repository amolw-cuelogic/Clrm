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
        private Mock<IAllocationDataAccess> mockService = new Mock<IAllocationDataAccess>();
        private AllocationRepository serviceObject = new AllocationRepository();
        private string dependencyField = "_allocationDataAccess";
        private const string _testCategory = "Repository - Allocation";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryMarkAllocationInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);

            mockService.Setup(m => m.MarkAllocationInvalid(It.IsAny<int>(), It.IsAny<int>()));
            
            var mockdata1 = AllocationMockData.GetMockDataAllocationDataset();
            mockService.Setup(m => m.GetAllocation(It.IsAny<int>())).Returns(mockdata1);

            var mockdata = AllocationMockData.GetMockDataAllocationIdDataset();
            mockService.Setup(m => m.GetAllocationSum(It.IsAny<int>())).Returns(mockdata);
            
            var mockdata2 = AllocationMockData.GetMockDataMasterRoleListDataset();
            mockService.Setup(m => m.GetProjectRolebyId(It.IsAny<int>())).Returns(mockdata2);

            var mockdata3 = AllocationMockData.GetMockDataAllocationSelectListDataset();
            mockService.Setup(m => m.GetAllocationSelectList()).Returns(mockdata3);

            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkAllocationInvalid(1,1);

            //ASSERT
            mockService.Verify(m => m.MarkAllocationInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkAllocationInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetAllocation(It.IsAny<int>()));
            mockService.Verify(m => m.GetAllocation(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetAllocationSum(It.IsAny<int>()));
            mockService.Verify(m => m.GetAllocationSum(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetProjectRolebyId(It.IsAny<int>()));
            mockService.Verify(m => m.GetProjectRolebyId(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetAllocationSelectList());
            mockService.Verify(m => m.GetAllocationSelectList(), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryGetAllocationSum()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataAllocationIdDataset();
            mockService.Setup(m => m.GetAllocationSum(It.IsAny<int>())).Returns(mockdata);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetAllocationSum(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(int));
            Assert.IsTrue(data > 0);
            Assert.IsTrue(data <= 100);

        }
        
        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryGetAllocation()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);

            var mockdata1 = AllocationMockData.GetMockDataAllocationDataset();
            mockService.Setup(m => m.GetAllocation(It.IsAny<int>())).Returns(mockdata1);

            var mockdata = AllocationMockData.GetMockDataAllocationIdDataset();
            mockService.Setup(m => m.GetAllocationSum(It.IsAny<int>())).Returns(mockdata);

            var mockdata2 = AllocationMockData.GetMockDataMasterRoleListDataset();
            mockService.Setup(m => m.GetProjectRolebyId(It.IsAny<int>())).Returns(mockdata2);

            var mockdata3 = AllocationMockData.GetMockDataAllocationSelectListDataset();
            mockService.Setup(m => m.GetAllocationSelectList()).Returns(mockdata3);

            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetAllocation(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(Allocation));
            Assert.IsTrue(data.Id == 1);

        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryGetAllocationList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataAllocationListDataset();
            mockService.Setup(m => m.GetAllocationList(It.IsAny<SearchParam>())).Returns(mockdata);
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
            mockService.Setup(m => m.GetProjectRolebyId(It.IsAny<int>())).Returns(mockdata);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetProjectRolebyId(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<MasterRole>));
            Assert.IsTrue(data.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationRepositoryAddOrUpdateAllocation()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);

            var mockdata = AllocationMockData.GetMockDataAllocation();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateAllocation(It.IsAny<Allocation>()));

            var mockdata1 = AllocationMockData.GetMockDataAllocationDataset();
            mockService.Setup(m => m.GetAllocation(It.IsAny<int>())).Returns(mockdata1);
            
            var mockdata2 = AllocationMockData.GetMockDataMasterRoleListDataset();
            mockService.Setup(m => m.GetProjectRolebyId(It.IsAny<int>())).Returns(mockdata2);

            var mockdata3 = AllocationMockData.GetMockDataAllocationSelectListDataset();
            mockService.Setup(m => m.GetAllocationSelectList()).Returns(mockdata3);

            var mockdata4 = AllocationMockData.GetMockDataAllocationIdDataset();
            mockService.Setup(m => m.GetAllocationSum(It.IsAny<int>())).Returns(mockdata4);

            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.AddOrUpdateAllocation(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.GetAllocation(It.IsAny<int>()));
            mockService.Verify(m => m.GetAllocation(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetAllocationSum(It.IsAny<int>()));
            mockService.Verify(m => m.GetAllocationSum(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetProjectRolebyId(It.IsAny<int>()));
            mockService.Verify(m => m.GetProjectRolebyId(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetAllocationSelectList());
            mockService.Verify(m => m.GetAllocationSelectList(), Times.Once);
            mockService.Verify(m => m.AddOrUpdateAllocation(It.IsAny<Allocation>()));
            mockService.Verify(m => m.AddOrUpdateAllocation(It.IsAny<Allocation>()), Times.Once);
            mockService.VerifyAll();

        }
        
    }

}
