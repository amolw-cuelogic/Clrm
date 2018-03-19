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
    public class ProjectRepositoryTest
    {
        private Mock<IProjectDataAccess> mockService = new Mock<IProjectDataAccess>();
        private ProjectRepository serviceObject = new ProjectRepository();
        private string _dependencyField = "_projectDataAccess";
        private const string _testCategory = "Repository - Project";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestProjectRepositoryMarkProjectInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkProjectInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkProjectInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkProjectInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkProjectInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestProjectRepositoryGetProject()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = ProjectMockData.GetMockDataProjectDataset();
            var mockData1 = ProjectMockData.GetMockDataMasterList();
            mockService.Setup(m => m.GetProject(It.IsAny<int>())).Returns(mockData);
            mockService.Setup(m => m.GetProjectSelectList()).Returns(mockData1);

            Mock<IMasterProjectTypeRepository> mockService1 = new Mock<IMasterProjectTypeRepository>();
            var mockData2 = MasterProjectTypeMockData.GetMockDataMasterProjectTypeListDataset();
            mockService1.Setup(m => m.GetMasterProjectTypeValidList()).Returns(mockData2);

            privateObject.SetField(_dependencyField, mockService.Object);
            privateObject.SetField("_masterProjectTypeRepository", mockService1.Object);

            //ACT
            var data = serviceObject.GetProject(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(Project));
            Assert.IsTrue(data.Id == 1);
            Assert.IsTrue(data.MasterCurrencyList.Count > 0);
            Assert.IsTrue(data.MasterRoleList.Count > 0);
            Assert.IsTrue(data.ProjectMasterClientList.Count > 0);
            mockService.Verify(m => m.GetProject(It.IsAny<int>()));
            mockService.Verify(m => m.GetProject(It.IsAny<int>()), Times.Once);
            mockService.Verify(m => m.GetProjectSelectList());
            mockService.Verify(m => m.GetProjectSelectList(), Times.Once);
            mockService1.Verify(m => m.GetMasterProjectTypeValidList());
            mockService1.Verify(m => m.GetMasterProjectTypeValidList(), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestProjectRepositoryGetProjectList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = ProjectMockData.GetMockDataProjectDataset();
            mockService.Setup(m => m.GetProjectList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = ProjectMockData.GetMockDataProjectList();

            //ACT
            var data = serviceObject.GetProjectList(searchParam);
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
        public void TestProjectRepositoryAddOrUpdateProject_Condition1()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = ProjectMockData.GetMockDataProject();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateProject(It.IsAny<Project>()));
            mockService.Setup(m => m.AddProjectRoles(It.IsAny<string>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.AddOrUpdateProject(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.GetLatestId(), Times.Never);
            mockService.Verify(m => m.AddOrUpdateProject(It.IsAny<Project>()));
            mockService.Verify(m => m.AddOrUpdateProject(It.IsAny<Project>()), Times.Once);
            mockService.Verify(m => m.AddProjectRoles(It.IsAny<string>(), It.IsAny<int>()));
            mockService.Verify(m => m.AddProjectRoles(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestProjectRepositoryAddOrUpdateProject_Condition2()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = ProjectMockData.GetMockDataProject();
            var mockdata1 = ProjectMockData.GetLatestId();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateProject(It.IsAny<Project>()));
            mockService.Setup(m => m.AddProjectRoles(It.IsAny<string>(), It.IsAny<int>()));
            mockService.Setup(m => m.GetLatestId()).Returns(mockdata1);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            mockdata.Id = 0;
            serviceObject.AddOrUpdateProject(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.GetLatestId());
            mockService.Verify(m => m.GetLatestId(), Times.Once);
            mockService.Verify(m => m.AddOrUpdateProject(It.IsAny<Project>()));
            mockService.Verify(m => m.AddOrUpdateProject(It.IsAny<Project>()), Times.Once);
            mockService.Verify(m => m.AddProjectRoles(It.IsAny<string>(), It.IsAny<int>()));
            mockService.Verify(m => m.AddProjectRoles(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
