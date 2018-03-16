using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Repository.OrganizationRole;
using Moq;
using Cuelogic.Clrm.Service.OrganizationRole;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;

namespace Cuelogic.Clrm.Service.Tests.TestCase
{
    [TestClass]
    public class MasterOrganizationRoleServiceTest
    {
        private Mock<IMasterOrganizationRoleRepository> mockService = new Mock<IMasterOrganizationRoleRepository>();
        private MasterOrganizationRoleService serviceObject = new MasterOrganizationRoleService();
        private string _dependencyField = "_masterOrganizationRoleRepository";
        private const string _testCategory = "Service - Master Organization Role";

        
        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterOrganizationRoleDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterOrganizationRoleInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterOrganizationRoleGetItem()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRole();
            mockService.Setup(m => m.GetMasterOrganizationRole(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterOrganizationRole));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterOrganizationRoleGetList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRoleDataset();
            mockService.Setup(m => m.GetMasterOrganizationRoleList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRoleList();

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
        public void TestMasterOrganizationRoleSave()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRole();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.SaveMasterOrganizationRole(It.IsAny<MasterOrganizationRole>(), It.IsAny<UserContext>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            mockdata.Id = 0;
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterOrganizationRoleUpdate()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterOrganizationRoleMockData.GetMockDataMasterOrganizationRole();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.UpdateMasterOrganizationRole(It.IsAny<MasterOrganizationRole>(), It.IsAny<UserContext>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            mockdata.Id = 0;
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

    }
}
