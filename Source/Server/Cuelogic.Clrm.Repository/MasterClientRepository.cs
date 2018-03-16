using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess.MySql;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Repository
{
    public class MasterClientRepository : IMasterClientRepository
    {
        private readonly IMasterClientDataAccess _masterClientDataAccess;
        public MasterClientRepository()
        {
            var databaseType = AppUtillity.GetTargetDatabase();
            if (databaseType == DatabaseType.MySql)
                _masterClientDataAccess = new MasterClientDataAccessMySql();
            else
                throw new Exception(CustomError.DbConcreteImplementation);
        }

        public void AddOrUpdateMasterClient(MasterClient masterClient, UserContext userCtx)
        {
            masterClient.CreatedBy = userCtx.UserId;
            masterClient.UpdatedBy = userCtx.UserId;
            masterClient.CreatedOn = DateTime.Now.ToMySqlDateString();
            masterClient.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterClientDataAccess.AddOrUpdateMasterClient(masterClient);
        }

        public List<MasterCity> GetCityList(int countryId)
        {
            var ds = _masterClientDataAccess.GetCityList(countryId);
            var cityList = ds.Tables[0].ToList<MasterCity>();
            return cityList;
        }

        public MasterClient GetMasterClient(int masterClientId)
        {
            var masterClient = new MasterClient();
            if (masterClientId != 0)
            {
                var ds = _masterClientDataAccess.GetMasterClient(masterClientId);
                masterClient = ds.Tables[0].ToModel<MasterClient>();

                var masterCityDs = _masterClientDataAccess.GetCityList(masterClient.CountryId);
                masterClient.MasterCityList = masterCityDs.Tables[0].ToList<MasterCity>();

            }
            var countryListDs = _masterClientDataAccess.GetCountryList();
            masterClient.MasterCountryList = countryListDs.Tables[0].ToList<MasterCountry>();
            return masterClient;
        }

        public DataSet GetMasterClientList(SearchParam searchParam)
        {
            var ds = _masterClientDataAccess.GetMasterClientList(searchParam);
            return ds;
        }

        public void MarkMasterClientInvalid(int masterClientId, int employeeId)
        {
            _masterClientDataAccess.MarkMasterClientInvalid(masterClientId, employeeId);
        }
    }
}
