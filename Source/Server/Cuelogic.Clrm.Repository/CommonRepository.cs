using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Repository.Interface;
using System.Collections.Generic;
using System.Data;

namespace Cuelogic.Clrm.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private readonly IDataAccess _dataAccess;
        public CommonRepository()
        {
            _dataAccess = new MySqlDataAccess();
        }

        public DataSet GetEmployeeAllocationList(int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.EmployeeAllocation_GetList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramEmployeeId", Value=employeeId } });

            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetEmployeeDetails(string emailId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetByEmailId;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramEmailId", Value=emailId } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetEmployeeDetailsByOrgEmpId(string orgEmpId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetByOrgEmpId;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramOrgEmpId", Value=orgEmpId } });

            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetGroupRights(int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.EmployeeRights_Get;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramEmployeeId", Value=employeeId } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void LogLoginTime(int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Common_LogLoginTime;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramEmployeeId", Value=employeeId } });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }
    }
}
