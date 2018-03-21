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
    public class MasterOrganizationRoleRepository : IMasterOrganizationRoleRepository
    {
        private readonly IDataAccess _dataAccess;
        public MasterOrganizationRoleRepository()
        {
            _dataAccess = new MySqlDataAccess();
        }

        public DataSet GetMasterOrganizationRole(int masterOrganizationRoleId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterOrganizationRole_Get;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@MasterDepartmentId", Value=masterOrganizationRoleId }
            });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetMasterOrganizationRoleList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterOrganizationRole_GetList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@filterText", Value=searchParam.FilterText },
                    new Param() { Key="@recordFrom", Value= recordFrom },
                    new Param() { Key="@recordTill", Value= show } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void MarkMasterOrganizationRoleInvalid(int masterOrganizationRoleId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterOrganizationRole_MarkInvalid;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@MasterOrganizationRoleId", Value=masterOrganizationRoleId },
                    new Param() { Key="@employeeId", Value=employeeId }});
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public void SaveMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterOrganizationRole_Insert;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@role", Value=masterOrganizationRole.Role },
                    new Param() { Key="@isValid", Value=masterOrganizationRole.IsValid },
                    new Param() { Key="@createdBy", Value=masterOrganizationRole.CreatedBy },
                    new Param() { Key="@createdOn", Value=masterOrganizationRole.CreatedOn }
            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public void UpdateMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterOrganizationRole_Update;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@masterOrganizationRoleId", Value=masterOrganizationRole.Id },
                    new Param() { Key="@paramRole", Value=masterOrganizationRole.Role },
                    new Param() { Key="@paramIsValid", Value=masterOrganizationRole.IsValid },
                    new Param() { Key="@paramUpdatedby", Value=masterOrganizationRole.UpdatedBy },
                    new Param() { Key="@paramUpdatedon", Value=masterOrganizationRole.UpdatedOn }
            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }
    }
}
