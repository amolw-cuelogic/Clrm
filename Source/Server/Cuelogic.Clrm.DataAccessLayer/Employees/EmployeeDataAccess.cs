﻿using System;
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
        #region GET FUNCTIONS

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
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spEmployee_GetMasterValidList;
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand());
            return ds;
        }

        public DataSet GetChildListForEmployees(int masterEmployeeId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spEmployee_GetChildValidList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@masterEmployeeId", masterEmployeeId)
            };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetLatestId()
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spEmployee_GetLatestId;
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand());
            return ds;
        }

        #endregion

        #region ADD OR UPDATE FUNCTIONS

        public void AddOrUpdateEmployee(Employee employee)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spEmployee_AddOrUpdate;
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
                    new MySqlParameter("@createdBy", employee.CreatedBy),
                    new MySqlParameter("@createdOn", employee.CreatedOn),
                    new MySqlParameter("@updatedOn", employee.UpdatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
        }

        public void AddOrUpdateEmployeeSkill(string xmlString, int userId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spEmployeeSkill_BulkAddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", xmlString),
                    new MySqlParameter("@userId", userId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public void AddOrUpdateEmployeeDepartment(string xmlString, int userId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spEmployeeDepartment_BulkAddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", xmlString),
                    new MySqlParameter("@userId", userId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public void AddOrUpdateEmployeeOrganizationRole(string xmlString, int userId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spEmployeeOrganizationRole_BulkAddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", xmlString),
                    new MySqlParameter("@userId", userId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public void AddOrUpdateEmployeeGroup(string xmlString, int userId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spEmployeeGroup_BulkAddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", xmlString),
                    new MySqlParameter("@userId", userId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        #endregion

        #region OTHER FUNCTIONS

        public void MarkEmployeeInvalid(int masterEmployeeId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spEmployee_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@masterEmployeeId", masterEmployeeId)
            };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);

        }

        #endregion
    }
}