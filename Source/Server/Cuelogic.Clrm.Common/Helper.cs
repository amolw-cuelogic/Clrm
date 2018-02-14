using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cuelogic.Clrm.Common
{
    public class Helper
    {

        public static string ObjectToXml(object t)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(t.GetType());
            serializer.Serialize(stringwriter, t);
            return stringwriter.ToString();
        }
    }
}
