using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.CommonModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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

        public static Object XmlToObject(string xml, Type objectType)
        {
            var serializer = new XmlSerializer(objectType);
            var data = serializer.Deserialize(new StringReader(xml));
            return data;

        }

        public static string ComposeClientMessage(string messageType, string message)
        {
            message = "<clrm>" + messageType + "|" + message + "</clrm>";
            return message;
        }
    }
}
