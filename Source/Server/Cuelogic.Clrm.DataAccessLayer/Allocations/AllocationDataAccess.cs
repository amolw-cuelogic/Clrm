﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;

namespace Cuelogic.Clrm.DataAccessLayer.Allocations
{
    public class AllocationDataAccess : IAllocationDataAccess
    {
        public void AddOrUpdateAllocation(Allocation allocation)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spAllocation_AddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@aId", allocation.Id),
                    new MySqlParameter("@aEmployeeId", allocation.EmployeeId),
                    new MySqlParameter("@aProjectRoleId", allocation.ProjectRoleId),
                    new MySqlParameter("@aProjectId", allocation.ProjectId),
                    new MySqlParameter("@aIsBillable", allocation.IsBillable),
                    new MySqlParameter("@aPercentageAllocation", allocation.PercentageAllocation),
                    new MySqlParameter("@aStartDate", allocation.StartDate),
                    new MySqlParameter("@aEndDate", allocation.EndDate),
                    new MySqlParameter("@aIsValid", allocation.IsValid),
                    new MySqlParameter("@aUpdatedBy", allocation.UpdatedBy),
                    new MySqlParameter("@aCreatedBy", allocation.CreatedBy),
                    new MySqlParameter("@aUpdatedOn", allocation.UpdatedOn),
                    new MySqlParameter("@aCreatedOn", allocation.CreatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
        }

        public DataSet GetAllocation(int allocationId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spAllocation_Get;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@aId", allocationId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetAllocationList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spAllocation_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@filterText", searchParam.FilterText),
                    new MySqlParameter("@recordFrom", recordFrom),
                    new MySqlParameter("@recordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetAllocationSelectList()
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spAllocation_GetSelectList;
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand());
            return ds;
        }

        public DataSet GetAllocationSum(int employeeId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spAllocation_GetAllocationSum;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@employeeId", employeeId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public void MarkAllocationInvalid(int allocationId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spAllocation_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@aId", allocationId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
        }
    }
}