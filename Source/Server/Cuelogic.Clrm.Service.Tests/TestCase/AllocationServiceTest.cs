using Cuelogic.Clrm.Service.Allocations;
using Cuelogic.Clrm.Model.DatabaseModel;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cuelogic.Clrm.Repository.Allocations;
using Cuelogic.Clrm.Model.CommonModel;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.MockData;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class AllocationServiceTest
    {
        private Mock<IAllocationRepository> mockService = new Mock<IAllocationRepository>();
        private AllocationService serviceObject = new AllocationService();
        private string dependencyField = "_allocationRepository";

        [TestMethod]
        public void TestAllocationServiceDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkAllocationInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1,1);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

        [TestMethod]
        public void TestAllocationServiceGetAllocationSum()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.GetAllocationSum(It.IsAny<int>())).Returns(100);
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
        public void TestAllocationServiceGetItem()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataAllocation();
            mockService.Setup(m => m.GetAllocation(It.IsAny<int>())).Returns(mockdata);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(Allocation));
            Assert.IsTrue(data.Id == 1);

        }

        [TestMethod]
        public void TestAllocationServiceGetList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataAllocationDataset();
            mockService.Setup(m => m.GetAllocationList(It.IsAny<SearchParam>())).Returns(mockdata);
            privateObject.SetField(dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = AllocationMockData.GetMockDataAllocationList();

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
        public void TestAllocationServiceGetProjectRolebyId()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataMasterRoleList();
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
        public void TestAllocationServiceSave()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = AllocationMockData.GetMockDataAllocation();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            privateObject.SetField(dependencyField, mockService.Object);
            mockService.Setup(m => m.AddOrUpdateAllocation(It.IsAny<Allocation>(), It.IsAny<UserContext>()));

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }
        
    }

}
