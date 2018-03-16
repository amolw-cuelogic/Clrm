using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.CommonModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using static Cuelogic.Clrm.Common.AppConstants;

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

        public static string ObjectToJson(object obj)
        {
            var json = new JavaScriptSerializer().Serialize(obj);
            return json;
        }

        public static T JsonToObject<T>(string jsonString)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var obj = JsonConvert.DeserializeObject<T>(jsonString);
            return obj;
        }

        public static string ComposeClientMessage(string messageType, string message)
        {
            message = "<clrm>" + messageType + "|" + message + "</clrm>";
            return message;
        }

        public static DataTable JsonStringToDatatable(string jsonString)
        {
            jsonString = jsonString.Replace("'", "");
            DataTable dt = new DataTable();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            List<string> ColumnsName = new List<string>();
            foreach (string jSA in jsonStringArray)
            {
                string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                foreach (string ColumnsNameData in jsonStringData)
                {
                    try
                    {
                        int idx = ColumnsNameData.IndexOf(":");
                        string ColumnsNameString = ColumnsNameData.Substring(0, idx).Replace("\"", "");
                        if (!ColumnsName.Contains(ColumnsNameString))
                        {
                            ColumnsName.Add(ColumnsNameString);
                        }
                    }
                    catch (Exception)
                    {

                        throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                    }
                }
                break;
            }
            foreach (string AddColumnName in ColumnsName)
            {
                dt.Columns.Add(AddColumnName);
            }
            foreach (string jSA in jsonStringArray)
            {
                string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in RowData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string RowColumns = rowData.Substring(0, idx).Replace("\"", "");
                        string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                        nr[RowColumns] = RowDataString;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                dt.Rows.Add(nr);
            }
            return dt;
        }
        
    }
}
