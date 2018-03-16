using System.Data;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.DataAccess.MySql
{
    public class MasterClientDataAccessMySql : IMasterClientDataAccess
    {
        public void AddOrUpdateMasterClient(MasterClient masterClient)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_AddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@mcId", masterClient.Id),
                    new MySqlParameter("@mcClientName", masterClient.ClientName),
                    new MySqlParameter("@mcCountryId", masterClient.CountryId),
                    new MySqlParameter("@mcCityId", masterClient.CityId),
                    new MySqlParameter("@mcIsValid", masterClient.IsValid),
                    new MySqlParameter("@mcUpdatedBy", masterClient.UpdatedBy),
                    new MySqlParameter("@mcCreatedBy", masterClient.CreatedBy),
                    new MySqlParameter("@mcUpdatedOn", masterClient.UpdatedOn),
                    new MySqlParameter("@mcCreatedOn", masterClient.CreatedOn),
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
        }

        public DataSet GetCityList(int countryId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_GetCityList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@mcCountryId", countryId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetCountryList()
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_GetCountryList;
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand());
            return ds;
        }

        public DataSet GetMasterClient(int masterClientId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_Get;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@mcId", masterClientId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetMasterClientList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@filterText", searchParam.FilterText),
                    new MySqlParameter("@recordFrom", recordFrom),
                    new MySqlParameter("@recordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public void MarkMasterClientInvalid(int masterClientId, int employeeId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@mcId", masterClientId),
                    new MySqlParameter("@employeeId", employeeId)
            };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
        }
    }
}
