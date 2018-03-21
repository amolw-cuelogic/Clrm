using System.Collections.Generic;
using System.Data;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.DataAccess.MySql
{
    public class EmployeeDataAccessMySql : IEmployeeDataAccess
    {
        #region GET FUNCTIONS

        public DataSet GetEmployee(int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetById;
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

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetList;
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
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetMasterValidList;
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(),null,new List<string> {
                AppConstants.StoreProcedure.Employee_GetMasterValidList_Tables.IdentityGroup,
                AppConstants.StoreProcedure.Employee_GetMasterValidList_Tables.MasterDepartment,
                AppConstants.StoreProcedure.Employee_GetMasterValidList_Tables.MasterSkill,
                AppConstants.StoreProcedure.Employee_GetMasterValidList_Tables.MasterOrganizationRole
            });
            return ds;
        }

        public DataSet GetChildListForEmployees(int masterEmployeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetChildValidList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@masterEmployeeId", masterEmployeeId)
            };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetLatestId()
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetLatestId;
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand());
            return ds;
        }

        #endregion

        #region ADD OR UPDATE FUNCTIONS

        public void AddOrUpdateEmployee(Employee employee)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_AddOrUpdate;
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
            var sqlparam = new DataAccessParameter();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.EmployeeSkill_BulkAddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", xmlString),
                    new MySqlParameter("@userId", userId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public void AddOrUpdateEmployeeDepartment(string xmlString, int userId)
        {
            var sqlparam = new DataAccessParameter();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.EmployeeDepartment_BulkAddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", xmlString),
                    new MySqlParameter("@userId", userId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public void AddOrUpdateEmployeeOrganizationRole(string xmlString, int userId)
        {
            var sqlparam = new DataAccessParameter();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.EmployeeOrganizationRole_BulkAddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", xmlString),
                    new MySqlParameter("@userId", userId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public void AddOrUpdateEmployeeGroup(string xmlString, int userId)
        {
            var sqlparam = new DataAccessParameter();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.EmployeeGroup_BulkAddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", xmlString),
                    new MySqlParameter("@userId", userId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        #endregion

        #region OTHER FUNCTIONS

        public void MarkEmployeeInvalid(int masterEmployeeId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@masterEmployeeId", masterEmployeeId),
                    new MySqlParameter("@employeeId", employeeId)
            };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);

        }

        #endregion
    }
}
