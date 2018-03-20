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
    public class MasterSkillServiceTest
    {
        private Mock<IMasterSkillRepository> mockService = new Mock<IMasterSkillRepository>();
        private MasterSkillService serviceObject = new MasterSkillService();
        private string _dependencyField = "_IMasterSkillRepository";
        private const string _testCategory = "Service - Master Skill";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterSkillServiceDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterSkillInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            mockService.Verify(m => m.MarkMasterSkillInvalid(It.IsAny<int>(), It.IsAny<int>()));
            mockService.Verify(m => m.MarkMasterSkillInvalid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterSkillServiceGetItem()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterSkillMockData.GetMockDataMasterSkillDataset();
            mockService.Setup(m => m.GetMasterSkill(It.IsAny<int>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            var data = serviceObject.GetItem(1);

            //ASSERT
            Assert.IsNotNull(data);
            Assert.IsInstanceOfType(data, typeof(MasterSkill));
            Assert.IsTrue(data.Id == 1);
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterSkillServiceGetList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterSkillMockData.GetMockDataMasterSkillListDataset();
            mockService.Setup(m => m.GetMasterSkillList(It.IsAny<SearchParam>())).Returns(mockData);
            privateObject.SetField(_dependencyField, mockService.Object);
            var searchParam = new SearchParam() { FilterText = "", Page = 0, Show = 10 };
            var expectedResult = MasterSkillMockData.GetMockDataMasterSkillList();

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
        public void TestMasterSkillServiceSave()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterSkillMockData.GetMockDataMasterSkill();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.SaveMasterSkill(It.IsAny<MasterSkill>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            mockdata.Id = 0;
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.UpdateMasterSkill(It.IsAny<MasterSkill>()), Times.Never);
            mockService.Verify(m => m.SaveMasterSkill(It.IsAny<MasterSkill>()));
            mockService.Verify(m => m.SaveMasterSkill(It.IsAny<MasterSkill>()), Times.Once);
            mockService.VerifyAll();
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterSkillServiceUpdate()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterSkillMockData.GetMockDataMasterSkill();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.UpdateMasterSkill(It.IsAny<MasterSkill>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            mockService.Verify(m => m.SaveMasterSkill(It.IsAny<MasterSkill>()), Times.Never);
            mockService.Verify(m => m.UpdateMasterSkill(It.IsAny<MasterSkill>()));
            mockService.Verify(m => m.UpdateMasterSkill(It.IsAny<MasterSkill>()), Times.Once);
            mockService.VerifyAll();
        }
    }
}
