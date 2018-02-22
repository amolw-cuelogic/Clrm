using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.DataAccessLayer.Employees
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        public DataSet GetEmployee(int employeeId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spEmployee_GetById;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@employeeId", employeeId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetEmployeeList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spEmployee_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@filterText", searchParam.FilterText),
                    new MySqlParameter("@recordFrom", recordFrom),
                    new MySqlParameter("@recordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetMasterListForEmployees()
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spEmployeeVm_GetValidList;
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand());
            return ds;
        }

        public void UpdateEmployee(Employee employee)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spEmployee_Update;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@employeeId", employee.Id),
                    new MySqlParameter("@firstName", employee.FirstName),
                    new MySqlParameter("@middleName", employee.MiddleName),
                    new MySqlParameter("@lastName", employee.LastName),
                    new MySqlParameter("@orgEmpId", employee.OrgEmpId),
                    new MySqlParameter("@joiningDate", employee.JoiningDate),
                    new MySqlParameter("@leavingDate", employee.LeavingDate),
                    new MySqlParameter("@contactNum", employee.ContactNum),
                    new MySqlParameter("@email", employee.Email),
                    new MySqlParameter("@isValid", employee.IsValid),
                    new MySqlParameter("@updatedBy", employee.UpdatedBy),
                    new MySqlParameter("@updatedOn", employee.UpdatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
        }
    }
}
