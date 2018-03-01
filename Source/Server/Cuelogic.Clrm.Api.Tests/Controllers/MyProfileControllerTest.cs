using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Service.Common;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class MyProfileControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CommonService obj = new CommonService();
            var r1 = 3 | 3;
            var r2 = 3 | 7;
            var r3 = 4 | 6;
            var list = obj.GetEmployeeRights(1);
            var xml = Helper.ObjectToXml(list);

            XmlSerializer oXmlSerializer = new XmlSerializer(list.GetType());
            //The StringReader will be the stream holder for the existing XML file 
            var data = oXmlSerializer.Deserialize(new StringReader(xml));
            Type t = (new List<IdentityGroupRight>()).GetType();

            var obj1 = Helper.XmlToObject(xml, list.GetType()) as List<IdentityGroupRight>;
            
           
        }
    }
}
