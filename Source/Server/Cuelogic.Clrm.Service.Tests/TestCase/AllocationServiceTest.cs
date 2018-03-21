using Cuelogic.Clrm.Model.DatabaseModel;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cuelogic.Clrm.Model.CommonModel;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Repository.Interface;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class AllocationServiceTest
    {
        private Mock<IAllocationRepository> mockService = new Mock<IAllocationRepository>();
        private AllocationService serviceObject = new AllocationService();
        private string dependencyField = "_allocationRepository";
        private const string _testCategory = "Service - Allocation";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationServiceDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkAllocationInvalid(It.IsAny<int>(), It.IsAny<int>()));
            var mockDataAllocation = AllocationMockData.GetMockDataAllocationDataset();
            mockService.Setup(m => m.GetAllocation(It.IsAny<int>())).Returns(mockDataAllocation);
            var mockDataAllocationSum = AllocationMockData.GetMockDataAllocationIdDataset();
            mockService.Setup(m => m.GetAllocationSum(It.IsAny<int>())).Returns(mockDataAllocationSum);
            var mockDataProjectRole = AllocationMockData.GetMockDataMasterRoleListDataset();
            mockService.Setup(m => m.GetProjectRolebyId(It.IsAny<int>())).Returns(mockDataProjectRole);
            var mockDataAllocationSelectList = AllocationMockData.GetMockDataAllocationSelectListDataset();
            mockService.Setup(m => m.GetAllocationSelectList()).Returns(mockDataAllocationSelectList);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1,1);

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
        public void TestAllocationServiceGetAllocationSum()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = AllocationMockData.GetMockDataAllocationIdDataset();
            mockService.Setup(m => m.GetAllocationSum(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetAllocationSum(1);

            //ASSERT
            mockService.Verify(m => m.GetAllocationSum(It.IsAny<int>()));
            mockService.Verify(m => m.GetAllocationSum(It.IsAny<int>()), Times.Once);
            mockService.Verify();
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(int));
            Assert.IsTrue(data > 0);
            Assert.IsTrue(data <= 100);

        }
        
        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationServiceGetItem()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataAllocationDataset();
            mockService.Setup(m => m.GetAllocation(It.IsAny<int>())).Returns(mockdata);
            var mockDataAllocationSum = AllocationMockData.GetMockDataAllocationIdDataset();
            mockService.Setup(m => m.GetAllocationSum(It.IsAny<int>())).Returns(mockDataAllocationSum);
            var mockDataProjectRole = AllocationMockData.GetMockDataMasterRoleListDataset();
            mockService.Setup(m => m.GetProjectRolebyId(It.IsAny<int>())).Returns(mockDataProjectRole);
            var mockDataAllocationSelectList = AllocationMockData.GetMockDataAllocationSelectListDataset();
            mockService.Setup(m => m.GetAllocationSelectList()).Returns(mockDataAllocationSelectList);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            mockService.Verify(m => m.GetAllocation(It.IsAny<int>()));
            mockService.Verify(m => m.GetAllocation(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetAllocationSum(It.IsAny<int>()));
            mockService.Verify(m => m.GetAllocationSum(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetProjectRolebyId(It.IsAny<int>()));
            mockService.Verify(m => m.GetProjectRolebyId(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetAllocationSelectList());
            mockService.Verify(m => m.GetAllocationSelectList(), Times.Once);
            mockService.Verify();
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(Allocation));
            Assert.IsTrue(data.Id == 1);

        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationServiceGetList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataAllocationListDataset();
            mockService.Setup(m => m.GetAllocationList(It.IsAny<SearchParam>())).Returns(mockdata);
            privateObject.SetField(dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = AllocationMockData.GetMockDataAllocationList();

            //ACT
            var data = serviceObject.GetList(searchParam);
            var dt = Helper.JsonStringToDatatable(data);

            //ASSERT
            mockService.Verify(m => m.GetAllocationList(It.IsAny<SearchParam>()));
            mockService.Verify(m => m.GetAllocationList(It.IsAny<SearchParam>()), Times.Once);
            mockService.Verify();
            Assert.IsNotNull(data);
            Assert.IsTrue(data != "");
            Assert.IsInstanceOfType(data, typeof(string));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsTrue(dt.Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationServiceGetProjectRolebyId()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataMasterRoleListDataset();
            mockService.Setup(m => m.GetProjectRolebyId(It.IsAny<int>())).Returns(mockdata);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetProjectRolebyId(1);

            //ASSERT
            mockService.Verify(m => m.GetProjectRolebyId(It.IsAny<int>()));
            mockService.Verify(m => m.GetProjectRolebyId(It.IsAny<int>()), Times.Once);
            mockService.Verify();
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(List<MasterRole>));
            Assert.IsTrue(data.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestAllocationServiceSave()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataAllocation();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateAllocation(It.IsAny<Allocation>(), It.IsAny<UserContext>()));
            var mockdataAllocation = AllocationMockData.GetMockDataAllocationDataset();
            mockService.Setup(m => m.GetAllocation(It.IsAny<int>())).Returns(mockdataAllocation);
            var mockDataAllocationSum = AllocationMockData.GetMockDataAllocationIdDataset();
            mockService.Setup(m => m.GetAllocationSum(It.IsAny<int>())).Returns(mockDataAllocationSum);
            var mockDataProjectRole = AllocationMockData.GetMockDataMasterRoleListDataset();
            mockService.Setup(m => m.GetProjectRolebyId(It.IsAny<int>())).Returns(mockDataProjectRole);
            var mockDataAllocationSelectList = AllocationMockData.GetMockDataAllocationSelectListDataset();
            mockService.Setup(m => m.GetAllocationSelectList()).Returns(mockDataAllocationSelectList);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.AddOrUpdateAllocation(It.IsAny<Allocation>(), It.IsAny<UserContext>()));
            mockService.Verify(m => m.AddOrUpdateAllocation(It.IsAny<Allocation>(), It.IsAny<UserContext>()), Times.Once);
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
        
    }

}
