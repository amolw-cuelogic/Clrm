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

namespace Cuelogic.Clrm.DataAccessLayer.OrganizationRole
{
    public class MasterOrganizationRoleDataAccess : IMasterOrganizationRoleDataAccess
    {
        public DataSet GetMasterOrganizationRole(int MasterOrganizationRoleId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterOrganizationRole_Get;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@Id", MasterOrganizationRoleId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetMasterOrganizationRoleList(SearchParam objSearchParam)
        {
            var RecordFrom = objSearchParam.Page * objSearchParam.Show;
            var Show = objSearchParam.Show;

            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterOrganizationRole_GetList;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@FilterText", objSearchParam.FilterText),
                    new MySqlParameter("@RecordFrom", RecordFrom),
                    new MySqlParameter("@RecordTill", Show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public void InsertMasterOrganizationRole(MasterOrganizationRole ObjMasterOrganizationRole)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterOrganizationRole_Insert;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@role", ObjMasterOrganizationRole.Role),
                    new MySqlParameter("@isValid", ObjMasterOrganizationRole.IsValid),
                    new MySqlParameter("@createdBy", ObjMasterOrganizationRole.CreatedBy),
                    new MySqlParameter("@createdOn", ObjMasterOrganizationRole.CreatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public void MarkMasterOrganizationRoleInvalid(int MasterOrganizationRoleId)
        {
            throw new NotImplementedException();
        }

        public void UpdateMasterOrganizationRole(MasterOrganizationRole ObjMasterOrganizationRole)
        {
            throw new NotImplementedException();
        }
    }
}
