using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.CommonModel
{
    public class Param
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
    public class DataAccessParameter
    {
        public DataAccessParameter()
        {
            StoreProcedureParameter = new List<Param>();
            TableName = new List<string>();
        }
        public string StoreProcedureName { get; set; }
        public MySqlParameter[] StoreProcedureParam { get; set; }

        public List<Param> StoreProcedureParameter { get; set; }
        public List<string> TableName { get; set; }

        public string ToSqlCommandd()
        {
            string sqlCmd = "";
            sqlCmd = "call " + StoreProcedureName + "(";
            if (StoreProcedureParameter != null)
            {
                for (var i = 0; i < StoreProcedureParameter.Count(); i++)
                {
                    sqlCmd += StoreProcedureParameter[i].Key;
                    if (i < StoreProcedureParameter.Count() - 1)
                        sqlCmd += ",";
                }
            }
            sqlCmd += ")";
            return sqlCmd;
        }

        public string ToSqlCommand()
        {
            string sqlCmd = "";
            sqlCmd = "call " + StoreProcedureName + "(";
            if (StoreProcedureParam != null)
            {
                for (var i = 0; i < StoreProcedureParam.Count(); i++)
                {
                    sqlCmd += StoreProcedureParam[i].ParameterName;
                    if (i < StoreProcedureParam.Count() - 1)
                        sqlCmd += ",";
                }
            }
            sqlCmd += ")";
            return sqlCmd;
        }
    }
}
