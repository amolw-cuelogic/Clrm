
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using static Cuelogic.Clrm.Common.AppConstants;
using static Cuelogic.Clrm.Common.CustomException;

namespace Cuelogic.Clrm.Common
{
    public static class Extension
    {
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        public static T ToModel<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            if (table.Rows.Count == 0)
                throw new NoContentFound(CustomError.NoRecordFound);
            var item = CreateItemFromRow<T>((DataRow)table.Rows[0], properties);
            return item;
        }

        public static string ToJsonString(this DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }
        public static int ToId(this DataTable table)
        {
            int id = 0;
            try
            {
                var data = table.Rows[0][0];
                string stringNumeric = "";
                if (data != null)
                    stringNumeric = data.ToString();
                if (stringNumeric != "")
                    id = int.Parse(stringNumeric);
                else
                    id = 0;
                return id;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public static string ToMySqlDateString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }
        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (row.Table.Columns.Contains(property.Name))
                {
                    if (row[property.Name] == DBNull.Value)
                        property.SetValue(item, null, null);
                    else
                    {
                        if (property.PropertyType.FullName == "System.Boolean")
                        {
                            var rowData = row[property.Name].ToString();
                            if (rowData == "1" || rowData == "true")
                                property.SetValue(item, true);
                            else
                                property.SetValue(item, false);
                        }
                        else if (row[property.Name] is DateTime)
                        {
                            var data = (row[property.Name] != null) ? DateTime.Parse(row[property.Name].ToString()).ToMySqlDateString() : "";
                            property.SetValue(item, data, null);
                        }
                        else if (property.PropertyType.FullName == "System.Int32" || property.PropertyType.FullName == "System.Decimal")
                        {
                            if (row[property.Name].ToString().ToLower() == "null" || row[property.Name].ToString().ToLower() == "")
                                row[property.Name] = 0;
                            var data = (!string.IsNullOrEmpty(row[property.Name].ToString())) ? int.Parse(row[property.Name].ToString()) : 0;
                            property.SetValue(item, data, null);
                        }
                        else
                        {
                            property.SetValue(item, row[property.Name]);
                        }
                    }
                }
            }
            return item;
        }
    }
}
