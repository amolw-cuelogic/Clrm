using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.DataAccess.MySql
{
    public class MasterDepartmentDataAccessMySql : IMasterDepartmentDataAccess
    {
        public DataSet GetMasterDepartment(int masterDepartmentId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.MasterDepartment_Get;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@MasterDepartmentId", masterDepartmentId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetMasterDepartmentList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterDepartment_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@FilterText", searchParam.FilterText),
                    new MySqlParameter("@RecordFrom", recordFrom),
                    new MySqlParameter("@RecordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public void InsertMasterDepartment(MasterDepartment masterDepartment)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterDepartment_Insert;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@departmentName", masterDepartment.DepartmentName),
                    new MySqlParameter("@departmentHead", masterDepartment.DepartmentHead),
                    new MySqlParameter("@isValid", masterDepartment.IsValid),
                    new MySqlParameter("@createdBy", masterDepartment.CreatedBy),
                    new MySqlParameter("@createdOn", masterDepartment.CreatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(),
                 sqlParam.StoreProcedureParam);
        }

        public void UpdateMasterDepartment(MasterDepartment masterDepartment)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterDepartment_Update;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@departmentId", masterDepartment.Id),
                    new MySqlParameter("@departmentName", masterDepartment.DepartmentName),
                    new MySqlParameter("@departmentHead", masterDepartment.DepartmentHead),
                    new MySqlParameter("@isValid", masterDepartment.IsValid),
                    new MySqlParameter("@updatedby", masterDepartment.UpdatedBy),
                    new MySqlParameter("@updatedon", masterDepartment.UpdatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(),
                 sqlParam.StoreProcedureParam);
        }

        public void MarkMasterDepartmentInvalid(int masterDepartmentId, int employeeId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterDepartment_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@MasterDepartmentId", masterDepartmentId),
                    new MySqlParameter("@employeeId", employeeId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(),
                 sqlParam.StoreProcedureParam);
        }

    }
}
