using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;

namespace Cuelogic.Clrm.DataAccessLayer.Role
{
    public class MasterRoleDataAccess : IMasterRoleDataAccess
    {
        public void AddOrUpdateMasterProjectRole(MasterRole masterProjectRole)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterRole_AddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@mpId", masterProjectRole.Id),
                    new MySqlParameter("@mpRole", masterProjectRole.Role),
                    new MySqlParameter("@mpIsValid", masterProjectRole.IsValid),
                    new MySqlParameter("@mpUpdatedBy", masterProjectRole.UpdatedBy),
                    new MySqlParameter("@mpCreatedBy", masterProjectRole.CreatedBy),
                    new MySqlParameter("@mpUpdatedOn", masterProjectRole.UpdatedOn),
                    new MySqlParameter("@mpCreatedOn", masterProjectRole.CreatedOn),
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public DataSet GetMasterProjectRole(int masterProjectRoleId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spMasterRole_Get;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@mpId", masterProjectRoleId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetMasterProjectRoleList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spMasterRole_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@filterText", searchParam.FilterText),
                    new MySqlParameter("@recordFrom", recordFrom),
                    new MySqlParameter("@recordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public void MarkMasterProjectRoleInvalid(int masterProjectRoleId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spMasterRole_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@masterProjectRoleId", masterProjectRoleId)
            };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
        }
    }
}
