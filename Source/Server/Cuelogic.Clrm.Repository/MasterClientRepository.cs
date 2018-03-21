using System;
using System.Collections.Generic;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess;

namespace Cuelogic.Clrm.Repository
{
    public class MasterClientRepository : IMasterClientRepository
    {
        private readonly IDataAccess _dataAccess;
        public MasterClientRepository()
        {
            _dataAccess = DataAccessFactory.GetDataAccess();
        }

        public void AddOrUpdateMasterClient(MasterClient masterClient, UserContext userCtx)
        {
            masterClient.CreatedBy = userCtx.UserId;
            masterClient.UpdatedBy = userCtx.UserId;
            masterClient.CreatedOn = DateTime.Now.ToMySqlDateString();
            masterClient.UpdatedOn = DateTime.Now.ToMySqlDateString();

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_AddOrUpdate;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@mcId", Value=masterClient.Id },
                    new Param() { Key="@mcClientName", Value=masterClient.ClientName },
                    new Param() { Key="@mcCountryId", Value=masterClient.CountryId },
                    new Param() { Key="@mcCityId", Value=masterClient.CityId },
                    new Param() { Key="@mcIsValid", Value=masterClient.IsValid },
                    new Param() { Key="@mcUpdatedBy", Value=masterClient.UpdatedBy },
                    new Param() { Key="@mcCreatedBy", Value=masterClient.CreatedBy },
                    new Param() { Key="@mcUpdatedOn", Value=masterClient.UpdatedOn },
                    new Param() { Key="@mcCreatedOn", Value=masterClient.CreatedOn },

            });
            _dataAccess.ExecuteNonQuery(sqlParam);
            
        }

        public DataSet GetCityList(int countryId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_GetCityList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@mcCountryId", Value=countryId}
            });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetMasterClient(int masterClientId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_Get;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@mcId", Value=masterClientId}
            });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetCountryList()
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_GetCountryList;
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetMasterClientList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_GetList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@filterText", Value=searchParam.FilterText },
                    new Param() { Key="@recordFrom", Value= recordFrom },
                    new Param() { Key="@recordTill", Value= show } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void MarkMasterClientInvalid(int masterClientId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterClient_MarkInvalid;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@mcId", Value=masterClientId },
                    new Param() { Key="@employeeId", Value=employeeId }});
            _dataAccess.ExecuteNonQuery(sqlParam);
        }
        
    }
}
