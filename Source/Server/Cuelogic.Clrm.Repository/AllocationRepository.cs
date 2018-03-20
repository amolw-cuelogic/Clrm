using System.Collections.Generic;
using System.Data;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using static Cuelogic.Clrm.Common.AppConstants;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess;

namespace Cuelogic.Clrm.Repository
{
    public class AllocationRepository : IAllocationRepository
    {
        private readonly IDataAccess _dataAccess;

        public AllocationRepository()
        {
            _dataAccess = new MySqlDataAccess();
        }
        public void AddOrUpdateAllocation(Allocation allocation, UserContext userContext)
        {
            var sqlparam = new DataAccessParameter();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.Allocation_AddOrUpdate;
            sqlparam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramId", Value= allocation.Id },
                    new Param() { Key="@paramEmployeeId", Value= allocation.EmployeeId },
                    new Param() { Key="@paramProjectRoleId", Value= allocation.ProjectRoleId },
                    new Param() { Key="@paramProjectId", Value= allocation.ProjectId},
                    new Param() { Key="@paramIsBillable", Value= allocation.IsBillable},
                    new Param() { Key="@paramPercentageAllocation", Value= allocation.PercentageAllocation},
                    new Param() { Key="@paramStartDate", Value= allocation.StartDate },
                    new Param() { Key="@paramEndDate", Value= allocation.EndDate },
                    new Param() { Key="@paramIsValid", Value= allocation.IsValid},
                    new Param() { Key="@paramUpdatedBy", Value= allocation.UpdatedBy},
                    new Param() { Key="@paramCreatedBy", Value= allocation.CreatedBy},
                    new Param() { Key="@paramUpdatedOn", Value= allocation.UpdatedOn},
                    new Param() { Key="@paramCreatedOn", Value= allocation.CreatedOn}
                });
            _dataAccess.ExecuteNonQuery(sqlparam);
        }

        public DataSet GetAllocation(int allocationId)
        {
            var sqlparam = new DataAccessParameter();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.Allocation_Get;
            sqlparam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramId", Value= allocationId } });
            var ds = _dataAccess.ExecuteQuery(sqlparam);
            return ds;
        }

        public DataSet GetAllocationList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = StoreProcedure.Allocation_GetList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@filterText", Value=searchParam.FilterText },
                    new Param() { Key="@recordFrom", Value= recordFrom },
                    new Param() { Key="@recordTill", Value= show } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetAllocationSum(int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Allocation_GetAllocationSum;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramEmployeeId", Value=employeeId } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetProjectRolebyId(int projectId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Allocation_GetRoleByProject;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramProjectId", Value=projectId } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void MarkAllocationInvalid(int allocationId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Allocation_MarkInvalid;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramId", Value=allocationId },
                    new Param() { Key="@paramEmployeeId", Value=employeeId }});
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public DataSet GetAllocationSelectList()
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Allocation_GetSelectList;
            sqlParam.TableName = new List<string> {
                TableName.Employee, TableName.Project
            };
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }
    }
}
