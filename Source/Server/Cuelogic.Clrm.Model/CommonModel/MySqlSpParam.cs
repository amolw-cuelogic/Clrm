using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.CommonModel
{
    public class MySqlSpParam
    {
        public string StoreProcedureName { get; set; }
        public MySqlParameter[] StoreProcedureParam { get; set; }

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
