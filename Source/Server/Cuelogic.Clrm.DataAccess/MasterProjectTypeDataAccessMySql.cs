using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using MySql.Data.MySqlClient;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.MySql
{
    public class MasterProjectTypeDataAccessMySql : IMasterProjectTypeDataAccess
    {
        public void AddOrUpdateMasterProjectType(MasterProjectType masterProjectType)
        {
            var sqlparam = new DataAccessParameter();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.MasterProjectType_AddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@mptId", masterProjectType.Id),
                    new MySqlParameter("@mptType", masterProjectType.Type),
                    new MySqlParameter("@mptIsValid", masterProjectType.IsValid),
                    new MySqlParameter("@mptUpdatedBy", masterProjectType.UpdatedBy),
                    new MySqlParameter("@mptCreatedBy", masterProjectType.CreatedBy),
                    new MySqlParameter("@mptUpdatedOn", masterProjectType.UpdatedOn),
                    new MySqlParameter("@mptCreatedOn", masterProjectType.CreatedOn),
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public DataSet GetMasterProjectType(int masterProjectTypeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterProjectType_Get;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@mptId", masterProjectTypeId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetMasterProjectTypeList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterProjectType_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@filterText", searchParam.FilterText),
                    new MySqlParameter("@recordFrom", recordFrom),
                    new MySqlParameter("@recordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetMasterProjectTypeValidList()
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterProjectType_GetValidList;
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand());
            return ds;
        }

        public void MarkMasterProjectTypeInvalid(int masterProjectTypeId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterProjectType_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@mptId", masterProjectTypeId),
                    new MySqlParameter("@employeeId", employeeId)
            };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
        }
    }
}
