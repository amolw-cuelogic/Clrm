using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;
using Cuelogic.Clrm.Repository.Interface;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class MasterDepartmentServiceTest
    {
        private Mock<IMasterDepartmentRepository> mockService = new Mock<IMasterDepartmentRepository>();
        private MasterDepartmentService serviceObject = new MasterDepartmentService();
        private string dependencyField = "_masterDepartmentRepository";
        private const string _testCategory = "Service - Master Department";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentServiceDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterDepartmentInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkMasterDepartmentInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkMasterDepartmentInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentServiceGetItem()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterDepartmentMockData.GetMockDataMasterDepartment();
            mockService.Setup(m => m.GetMasterDepartment(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterDepartment));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentServiceGetList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterDepartmentMockData.GetMockDataMasterDepartmentListDataset();
            mockService.Setup(m => m.GetMasterDepartmentList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = EmployeeMockData.GetMockDataemployeeList();

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
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentServiceSave()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterDepartmentMockData.GetMockDataMasterDepartment();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.SaveMasterDepartment(It.IsAny<MasterDepartment>(), It.IsAny<UserContext>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            mockdata.Id = 0;
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.UpdateMasterDepartment(It.IsAny<MasterDepartment>(), It.IsAny<UserContext>()), Times.Never);
            mockService.Verify(m => m.SaveMasterDepartment(It.IsAny<MasterDepartment>(), It.IsAny<UserContext>()));
            mockService.Verify(m => m.SaveMasterDepartment(It.IsAny<MasterDepartment>(), It.IsAny<UserContext>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterDepartmentServiceUpdate()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterDepartmentMockData.GetMockDataMasterDepartment();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.UpdateMasterDepartment(It.IsAny<MasterDepartment>(), It.IsAny<UserContext>()));
            privateObject.SetField(dependencyField, mockService.Object);

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.SaveMasterDepartment(It.IsAny<MasterDepartment>(), It.IsAny<UserContext>()), Times.Never);
            mockService.Verify(m => m.UpdateMasterDepartment(It.IsAny<MasterDepartment>(), It.IsAny<UserContext>()));
            mockService.Verify(m => m.UpdateMasterDepartment(It.IsAny<MasterDepartment>(), It.IsAny<UserContext>()), Times.Once);
            mockService.VerifyAll();
        }
    }
}
