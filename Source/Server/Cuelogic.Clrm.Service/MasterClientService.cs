using System.Collections.Generic;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;
using static Cuelogic.Clrm.Common.CustomException;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Service
{
    public class MasterClientService : IMasterClientService
    {
        private readonly IMasterClientRepository _masterClientRepository;
        public MasterClientService()
        {
            _masterClientRepository = new MasterClientRepository();
        }
        public void Delete(int masterClientId, int employeeId)
        {
            _masterClientRepository.MarkMasterClientInvalid(masterClientId, employeeId);
        }

        public MasterClient GetItem(int masterClientId)
        {
            var masterClient = new MasterClient();
            if (masterClientId > 0)
            {
                var ds = _masterClientRepository.GetMasterClient(masterClientId);
                masterClient = ds.Tables[0].ToModel<MasterClient>();

                var masterCityDs = _masterClientRepository.GetCityList(masterClient.CountryId);
                masterClient.MasterCityList = masterCityDs.Tables[0].ToList<MasterCity>();

            }
            if (masterClientId < 0)
                throw new BadRequest(CustomError.InValidId);
            var countryListDs = _masterClientRepository.GetCountryList();
            masterClient.MasterCountryList = countryListDs.Tables[0].ToList<MasterCountry>();
            return masterClient;
        }

        public List<MasterCity> GetCityList(int countryId)
        {
            var ds = _masterClientRepository.GetCityList(countryId);
            var cityList = ds.Tables[0].ToList<MasterCity>();
            return cityList;
        }

        public string GetList(SearchParam searchParam)
        {
            var ds = _masterClientRepository.GetMasterClientList(searchParam);
            var jsonString = ds.Tables[0].ToJsonString();
            return jsonString;
        }

        public void Save(MasterClient masterClient, UserContext userCtx)
        {
            _masterClientRepository.AddOrUpdateMasterClient(masterClient, userCtx);
        }
    }
}
