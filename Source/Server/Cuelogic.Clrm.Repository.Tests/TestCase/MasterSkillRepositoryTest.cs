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
    public class MasterSkillRepositoryTest
    {
        private Mock<IMasterSkillDataAccess> mockService = new Mock<IMasterSkillDataAccess>();
        private MasterSkillRepository serviceObject = new MasterSkillRepository();
        private string _dependencyField = "_masterSkillDataAccess";
        private const string _testCategory = "Repository - Master Skill";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterSkillRepositoryMarkMasterSkillInvalid()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterSkillInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.MarkMasterSkillInvalid(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkMasterSkillInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkMasterSkillInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterSkillRepositoryGetMasterSkill()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterSkillMockData.GetMockDataMasterSkillDataset();
            mockService.Setup(m => m.GetMasterSkill(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetMasterSkill(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterSkill));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterSkillRepositoryGetMasterSkillList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterSkillMockData.GetMockDataMasterSkillListDataset();
            mockService.Setup(m => m.GetMasterSkillList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = MasterSkillMockData.GetMockDataMasterSkillList();

            //ACT
            var data = serviceObject.GetMasterSkillList(searchParam);
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
        public void TestMasterSkillRepositorySaveMasterSkill()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterSkillMockData.GetMockDataMasterSkill();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.InsertMasterSkill(It.IsAny<MasterSkill>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            mockdata.Id = 0;
            serviceObject.SaveMasterSkill(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.UpdateMasterSkill(It.IsAny<MasterSkill>()), Times.Never);
            mockService.Verify(m => m.InsertMasterSkill(It.IsAny<MasterSkill>()));
            mockService.Verify(m => m.InsertMasterSkill(It.IsAny<MasterSkill>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterSkillRepositoryUpdateMasterSkill()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterSkillMockData.GetMockDataMasterSkill();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.UpdateMasterSkill(It.IsAny<MasterSkill>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.UpdateMasterSkill(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.InsertMasterSkill(It.IsAny<MasterSkill>()), Times.Never);
            mockService.Verify(m => m.UpdateMasterSkill(It.IsAny<MasterSkill>()));
            mockService.Verify(m => m.UpdateMasterSkill(It.IsAny<MasterSkill>()), Times.Once);
            mockService.VerifyAll();
        }
    }
}
