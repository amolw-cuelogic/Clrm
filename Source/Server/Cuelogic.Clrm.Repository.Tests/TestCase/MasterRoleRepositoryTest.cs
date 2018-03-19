using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Service;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.Repository.Tests.TestCase
{
    [TestClass]
    public class MasterRoleRepositoryTest
    {
        private Mock<IMasterRoleDataAccess> mockService = new Mock<IMasterRoleDataAccess>();
        private MasterRoleRepository serviceObject = new MasterRoleRepository();
        private string _dependencyField = "_masterProjectRoleDataAccess";
        private const string _testCategory = "Repository - Master Role";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterRoleRepositoryMarkMasterProjectRoleInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterProjectRoleInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkMasterProjectRoleInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkMasterProjectRoleInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkMasterProjectRoleInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterRoleRepositoryGetMasterProjectRole()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterRoleMockData.GetMockDataMasterProjectRoleDataset();
            mockService.Setup(m => m.GetMasterProjectRole(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetMasterProjectRole(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterRole));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterRoleRepositoryGetMasterProjectRoleList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterRoleMockData.GetMockDataMasterProjectRoleDataset();
            mockService.Setup(m => m.GetMasterProjectRoleList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = MasterRoleMockData.GetMockDataMasterProjectRoleList();

            //ACT
            var data = serviceObject.GetMasterProjectRoleList(searchParam);
            var dt = data.Tables[0];
            var jsonString = dt.ToJsonString();

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsTrue(jsonString != "");
            Assert.IsInstanceOfType(data, typeof(DataSet));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsInstanceOfType(jsonString, typeof(string));
            Assert.IsTrue(dt.Rows.Count > 0);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterRoleRepositoryAddOrUpdateMasterProjectRole()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterRoleMockData.GetMockDataMasterProjectRole();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateMasterProjectRole(It.IsAny<MasterRole>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.AddOrUpdateMasterProjectRole(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.AddOrUpdateMasterProjectRole(It.IsAny<MasterRole>()));
            mockService.Verify(m => m.AddOrUpdateMasterProjectRole(It.IsAny<MasterRole>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
