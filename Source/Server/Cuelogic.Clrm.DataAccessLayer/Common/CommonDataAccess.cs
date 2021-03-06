﻿using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.Common
{
    public class CommonDataAccess : ICommonDataAccess
    {
        public DataSet GetEmployeeDetails(string emailId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spEmployee_GetByEmailId;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@EmailId", emailId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }
    }
}
