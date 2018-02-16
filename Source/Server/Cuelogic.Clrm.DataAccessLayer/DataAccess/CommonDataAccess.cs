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
        private ILog applogManager = AppLogManager.GetLogger();
        public DataSet GetEmployeeDetails(string EmailId)
        {
            try
            {
                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spGetEmployeeByEmailId;
                sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@EmailId", EmailId)
                };
                var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
                return ds;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }
    }
}
