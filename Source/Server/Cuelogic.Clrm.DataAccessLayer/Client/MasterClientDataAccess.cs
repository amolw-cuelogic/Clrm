using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.DataAccessLayer.Client
{
    public class MasterClientDataAccess : IMasterClientDataAccess
    {
        public void AddOrUpdateMasterClient(MasterClient masterClient)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterClient_AddOrUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@mcId", masterClient.Id),
                    new MySqlParameter("@mcClientName", masterClient.ClientName),
                    new MySqlParameter("@mcClientLocation", masterClient.ClientLocation),
                    new MySqlParameter("@mcIsValid", masterClient.IsValid),
                    new MySqlParameter("@mcUpdatedBy", masterClient.UpdatedBy),
                    new MySqlParameter("@mcCreatedBy", masterClient.CreatedBy),
                    new MySqlParameter("@mcUpdatedOn", masterClient.UpdatedOn),
                    new MySqlParameter("@mcCreatedOn", masterClient.CreatedOn),
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
        }

        public DataSet GetMasterClient(int masterClientId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spMasterClient_Get;
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
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spMasterClient_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@filterText", searchParam.FilterText),
                    new MySqlParameter("@recordFrom", recordFrom),
                    new MySqlParameter("@recordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public void MarkMasterClientInvalid(int masterClientId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spMasterClient_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@mcId", masterClientId)
            };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
        }
    }
}
