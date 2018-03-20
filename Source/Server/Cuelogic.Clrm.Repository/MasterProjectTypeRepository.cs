using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Repository
{
    public class MasterProjectTypeRepository : IMasterProjectTypeRepository
    {
        private readonly IDataAccess _dataAccess;
        public MasterProjectTypeRepository()
        {
            _dataAccess = new MySqlDataAccess();
        }
        public void AddOrUpdateMasterProjectType(MasterProjectType masterProjectType)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterProjectType_AddOrUpdate;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@mptId", Value=masterProjectType.Id },
                    new Param() { Key="@mptType", Value=masterProjectType.Type },
                    new Param() { Key="@mptIsValid", Value=masterProjectType.IsValid },
                    new Param() { Key="@mptUpdatedBy", Value=masterProjectType.UpdatedBy },
                    new Param() { Key="@mptCreatedBy", Value=masterProjectType.CreatedBy },
                    new Param() { Key="@mptUpdatedOn", Value=masterProjectType.UpdatedOn },
                    new Param() { Key="@mptCreatedOn", Value=masterProjectType.CreatedOn },
            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public DataSet GetMasterProjectType(int masterProjectTypeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterProjectType_Get;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@mptId", Value = masterProjectTypeId }
            });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetMasterProjectTypeList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterProjectType_GetList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@filterText", Value=searchParam.FilterText },
                    new Param() { Key="@recordFrom", Value= recordFrom },
                    new Param() { Key="@recordTill", Value= show } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetMasterProjectTypeValidList()
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterProjectType_GetValidList;
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void MarkMasterProjectTypeInvalid(int masterProjectTypeId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterProjectType_MarkInvalid;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@mptId", Value = masterProjectTypeId },
                    new Param() { Key="@employeeId", Value=employeeId }});
            _dataAccess.ExecuteNonQuery(sqlParam);
        }
    }
}
