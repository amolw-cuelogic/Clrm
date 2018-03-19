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
    public class MasterOrganizationRoleRepositoryTest
    {
        private Mock<IMasterOrganizationRoleDataAccess> mockService = new Mock<IMasterOrganizationRoleDataAccess>();
        private MasterOrganizationRoleRepository serviceObject = new MasterOrganizationRoleRepository();
        private string _dependencyField = "_masterOrganizationRoleDataAccess";
        private const string _testCategory = "Repository - Master Organization Role";


        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterOrganizationRoleRepositoryMarkMasterOrganizationRoleInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterOrganizationRoleInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkMasterOrganizationRoleInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkMasterOrganizationRoleInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkMasterOrganizationRoleInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterOrganizationRoleRepositoryGetMasterOrganizationRole()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRoleDataset();
            mockService.Setup(m => m.GetMasterOrganizationRole(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetMasterOrganizationRole(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterOrganizationRole));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterOrganizationRoleRepositoryGetMasterOrganizationRoleList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRoleListDataset();
            mockService.Setup(m => m.GetMasterOrganizationRoleList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };

            //ACT
            var data = serviceObject.GetMasterOrganizationRoleList(searchParam);
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
        public void TestMasterOrganizationRoleRepositorySaveMasterOrganizationRole()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRole();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.InsertMasterOrganizationRole(It.IsAny<MasterOrganizationRole>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            mockdata.Id = 0;
            serviceObject.SaveMasterOrganizationRole(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.UpdateMasterOrganizationRole(It.IsAny<MasterOrganizationRole>()), Times.Never);
            mockService.Verify(m => m.InsertMasterOrganizationRole(It.IsAny<MasterOrganizationRole>()));
            mockService.Verify(m => m.InsertMasterOrganizationRole(It.IsAny<MasterOrganizationRole>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterOrganizationRoleRepositoryUpdateMasterOrganizationRole()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRole();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.UpdateMasterOrganizationRole(It.IsAny<MasterOrganizationRole>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.UpdateMasterOrganizationRole(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.InsertMasterOrganizationRole(It.IsAny<MasterOrganizationRole>()), Times.Never);
            mockService.Verify(m => m.UpdateMasterOrganizationRole(It.IsAny<MasterOrganizationRole>()));
            mockService.Verify(m => m.UpdateMasterOrganizationRole(It.IsAny<MasterOrganizationRole>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
