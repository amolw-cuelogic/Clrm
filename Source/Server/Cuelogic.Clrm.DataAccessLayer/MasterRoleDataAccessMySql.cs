using System.Data;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.DataAccess.MySql
{
    public class MasterRoleDataAccessMySql : IMasterRoleDataAccess
    {
        public void AddOrUpdateMasterProjectRole(MasterRole masterProjectRole)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.MasterRole_AddOrUpdate;
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
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterRole_Get;
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
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterRole_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@filterText", searchParam.FilterText),
                    new MySqlParameter("@recordFrom", recordFrom),
                    new MySqlParameter("@recordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public void MarkMasterProjectRoleInvalid(int masterProjectRoleId, int employeeId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterRole_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@masterProjectRoleId", masterProjectRoleId),
                    new MySqlParameter("@employeeId", employeeId)
            };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
        }
    }
}
