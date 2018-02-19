using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.DataAccessLayer.Interface;
using Cuelogic.Clrm.Model.CommonModel;
using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.DataAccess
{
    public class CommonDataAccess : ICommonDataAccess
    {
        public DataSet GetEmployeeDetails(string EmailId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spEmployee_GetByEmailId;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@EmailId", EmailId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }
    }
}
