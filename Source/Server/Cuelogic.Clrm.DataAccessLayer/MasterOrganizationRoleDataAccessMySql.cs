using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.DataAccess.MySql
{
    public class MasterOrganizationRoleDataAccessMySql : IMasterOrganizationRoleDataAccess
    {
        public DataSet GetMasterOrganizationRole(int masterOrganizationRoleId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterOrganizationRole_Get;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@Id", masterOrganizationRoleId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetMasterOrganizationRoleList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterOrganizationRole_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@FilterText", searchParam.FilterText),
                    new MySqlParameter("@RecordFrom", recordFrom),
                    new MySqlParameter("@RecordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public void InsertMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterOrganizationRole_Insert;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@role", masterOrganizationRole.Role),
                    new MySqlParameter("@isValid", masterOrganizationRole.IsValid),
                    new MySqlParameter("@createdBy", masterOrganizationRole.CreatedBy),
                    new MySqlParameter("@createdOn", masterOrganizationRole.CreatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(),
                 sqlParam.StoreProcedureParam);
        }

        public void MarkMasterOrganizationRoleInvalid(int masterOrganizationRoleId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterOrganizationRole_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@MasterOrganizationRoleId", masterOrganizationRoleId),
                    new MySqlParameter("@employeeId", employeeId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(),
                 sqlParam.StoreProcedureParam);
        }

        public void UpdateMasterOrganizationRole(MasterOrganizationRole masterOrganizationRole)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterOrganizationRole_Update;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@masterOrganizationRoleId", masterOrganizationRole.Id),
                    new MySqlParameter("@role", masterOrganizationRole.Role),
                    new MySqlParameter("@isValid", masterOrganizationRole.IsValid),
                    new MySqlParameter("@updatedby", masterOrganizationRole.UpdatedBy),
                    new MySqlParameter("@updatedon", masterOrganizationRole.UpdatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(),
                 sqlParam.StoreProcedureParam);
        }
    }
}
