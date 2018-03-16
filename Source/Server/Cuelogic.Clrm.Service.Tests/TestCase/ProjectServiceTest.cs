using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Repository.Projects;
using Moq;
using Cuelogic.Clrm.Service.Projects;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;

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
        public void TestProjectDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkProjectInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestProjectGetItem()
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
        public void TestProjectGetList()
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
        public void TestMasterSkillSave()
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
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

    }
}
