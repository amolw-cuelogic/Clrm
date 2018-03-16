using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Repository.Skill;
using Moq;
using Cuelogic.Clrm.Service.Skill;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using System.Data;

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
        public void TestMasterSkillDelete()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            mockService.Setup(m => m.MarkMasterSkillInvalid(It.IsAny<int>(), It.IsAny<int>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.Delete(1, 1);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMasterSkillGetItem()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterSkillMockData.GetMockDataMasterSkill();
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
        public void TestMasterSkillGetList()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockData = MasterSkillMockData.GetMockDataMasterSkillDataset();
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
        public void TestMasterSkillSave()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterSkillMockData.GetMockDataMasterSkill();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.SaveMasterSkill(It.IsAny<MasterSkill>(), It.IsAny<UserContext>()));
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
        public void TestMasterSkillUpdate()
        {
            //ARRANGE
            var privateObject = new PrivateObject(serviceObject);
            var mockdata = MasterSkillMockData.GetMockDataMasterSkill();
            var mockDataUserContext = CommonMockData.GetMockDataUserContext();
            mockService.Setup(m => m.UpdateMasterSkill(It.IsAny<MasterSkill>(), It.IsAny<UserContext>()));
            privateObject.SetField(_dependencyField, mockService.Object);

            //ACT
            serviceObject.Save(mockdata, mockDataUserContext);

            //ASSERT
            //AS IT IS VOID TYPE IT DOES NOT RETURN ANYTHING
            //If error occurs test will fail automatically
        }
    }
}
