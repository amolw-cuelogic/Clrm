
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

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

        public static string ToMySqlDateString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }
        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(System.DayOfWeek))
                {
                    DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                    property.SetValue(item, day, null);
                }
                else
                {
                    if (row.Table.Columns.Contains(property.Name))
                    {
                        if (row[property.Name] == DBNull.Value)
                            property.SetValue(item, null, null);
                        else
                        {
                            if (property.PropertyType.FullName == "System.Boolean")
                            {
                                var boolean = Convert.ToBoolean(Convert.ToInt16(row[property.Name].ToString()));
                                property.SetValue(item, boolean, null);
                            }
                            else
                            {
                                property.SetValue(item, row[property.Name], null);
                            }

                        }
                    }
                }
            }
            return item;
        }
    }
}
