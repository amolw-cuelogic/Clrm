using System;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Repository
{
    public class MasterDepartmentRepository : IMasterDepartmentRepository
    {
        private readonly IDataAccess _dataAccess;
        public MasterDepartmentRepository()
        {
            _dataAccess = DataAccessFactory.GetDataAccess();
        }
        public DataSet GetMasterDepartment(int masterDepartmentId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterDepartment_Get;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@MasterDepartmentId", Value=masterDepartmentId }
            });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetMasterDepartmentList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterDepartment_GetList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@filterText", Value=searchParam.FilterText },
                    new Param() { Key="@recordFrom", Value= recordFrom },
                    new Param() { Key="@recordTill", Value= show } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void MarkMasterDepartmentInvalid(int masterDepartmentId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterDepartment_MarkInvalid;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@MasterDepartmentId", Value=masterDepartmentId },
                    new Param() { Key="@employeeId", Value=employeeId }});
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public void SaveMasterDepartment(MasterDepartment masterDepartment, UserContext userCtx)
        {
            masterDepartment.CreatedBy = userCtx.UserId;
            masterDepartment.CreatedOn = DateTime.Now.ToMySqlDateString();

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterDepartment_Insert;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramDepartmentName", Value=masterDepartment.DepartmentName },
                    new Param() { Key="@paramDepartmentHead", Value=masterDepartment.DepartmentHead },
                    new Param() { Key="@paramIsValid", Value=masterDepartment.IsValid },
                    new Param() { Key="@paramCreatedBy", Value=masterDepartment.CreatedBy },
                    new Param() { Key="@paramCreatedOn", Value=masterDepartment.CreatedOn }

            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public void UpdateMasterDepartment(MasterDepartment masterDepartment, UserContext userCtx)
        {
            masterDepartment.UpdatedBy = userCtx.UserId;
            masterDepartment.UpdatedOn = DateTime.Now.ToMySqlDateString();
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterDepartment_Update;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramDepartmentId", Value=masterDepartment.Id },
                    new Param() { Key="@paramDepartmentName", Value=masterDepartment.DepartmentName },
                    new Param() { Key="@paramDepartmentHead", Value=masterDepartment.DepartmentHead },
                    new Param() { Key="@paramIsValid", Value=masterDepartment.IsValid },
                    new Param() { Key="@paramUpdatedby", Value=masterDepartment.UpdatedBy },
                    new Param() { Key="@paramUpdatedon", Value=masterDepartment.UpdatedOn }

            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }
    }
}
