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
    public class ProjectServiceTest
    {
        private Mock<IProjectRepository> mockService = new Mock<IProjectRepository>();
        private ProjectService serviceObject = new ProjectService();
        private string _dependencyField = "_projectRepository";
        private const string _testCategory = "Service - Project";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestProjectServiceDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkProjectInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkProjectInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkProjectInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestProjectServiceGetItem()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = ProjectMockData.GetMockDataProject();
            mockService.Setup(m => m.GetProject(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(Project));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestProjectServiceGetList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = ProjectMockData.GetMockDataProjectDataset();
            mockService.Setup(m => m.GetProjectList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = ProjectMockData.GetMockDataProjectList();

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
        public void TestProjectServiceSave()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = ProjectMockData.GetMockDataProject();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.AddOrUpdateProject(It.IsAny<Project>(), It.IsAny<UserContext>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.AddOrUpdateProject(It.IsAny<Project>(), It.IsAny<UserContext>()));
            mockService.Verify(m => m.AddOrUpdateProject(It.IsAny<Project>(), It.IsAny<UserContext>()), Times.Once);
            mockService.VerifyAll();
        }

    }
}
