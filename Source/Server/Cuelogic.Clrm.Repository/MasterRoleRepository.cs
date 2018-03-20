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
    public class MasterRoleRepository : IMasterRoleRepository
    {
        private readonly IDataAccess _dataAccess;
        public MasterRoleRepository()
        {
            _dataAccess = new MySqlDataAccess();
        }
        public void AddOrUpdateMasterProjectRole(MasterRole masterProjectRole)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterRole_AddOrUpdate;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@mpId", Value=masterProjectRole.Id },
                    new Param() { Key="@mpRole", Value=masterProjectRole.Role },
                    new Param() { Key="@mpIsValid", Value=masterProjectRole.IsValid },
                    new Param() { Key="@mpUpdatedBy", Value=masterProjectRole.UpdatedBy },
                    new Param() { Key="@mpCreatedBy", Value=masterProjectRole.CreatedBy },
                    new Param() { Key="@mpUpdatedOn", Value=masterProjectRole.UpdatedOn },
                    new Param() { Key="@mpCreatedOn", Value=masterProjectRole.CreatedOn },
            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public DataSet GetMasterProjectRole(int masterProjectRoleId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterRole_Get;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@mpId", Value = masterProjectRoleId }
            });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetMasterProjectRoleList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterRole_GetList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@filterText", Value=searchParam.FilterText },
                    new Param() { Key="@recordFrom", Value= recordFrom },
                    new Param() { Key="@recordTill", Value= show } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void MarkMasterProjectRoleInvalid(int masterProjectRoleId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterRole_MarkInvalid;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@masterProjectRoleId", Value = masterProjectRoleId },
                    new Param() { Key="@employeeId", Value=employeeId }});
            _dataAccess.ExecuteNonQuery(sqlParam);
        }
    }
}
