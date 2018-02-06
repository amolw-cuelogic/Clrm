using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.DataAccessLayer;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {

            var temp = MasterGroupDa.GetIdentityGroupList();
            
        }
    }
}
