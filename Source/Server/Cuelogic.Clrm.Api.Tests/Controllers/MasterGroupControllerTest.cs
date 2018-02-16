using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.Service.Service;
using Cuelogic.Clrm.Repository;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class MasterGroupControllerTest
    {
        [TestMethod]
        public void TestGetMasterGroupList()
        {
            MasterGroupController obj = new MasterGroupController(new MasterGroupService());
            var data = obj.Get(10,0,"");
            Assert.IsNotNull(data);

        }
    }
}
