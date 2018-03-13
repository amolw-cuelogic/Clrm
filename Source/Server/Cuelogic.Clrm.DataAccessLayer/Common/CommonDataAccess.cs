using Cuelogic.Clrm.Common;
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
        public DataSet GetEmployeeAllocationList(int employeeId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.EmployeeAllocation_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@employeeId", employeeId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetEmployeeDetailsByEmailId(string emailId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetByEmailId;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@EmailId", emailId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetEmployeeDetailsByOrgEmpId(string OrgEmpId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetByOrgEmpId;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@eOrgEmpId", OrgEmpId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetEmployeeRightList(int employeeId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.EmployeeRights_Get;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@employeeId", employeeId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public void LogLoginTime(int employeeId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Common_LogLoginTime;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@employeeId", employeeId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
        }
    }
}
