﻿using System.Collections.Generic;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;

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
            var masterClient = _masterClientRepository.GetMasterClient(masterClientId);
            return masterClient;
        }

        public List<MasterCity> GetCityList(int countryId)
        {
            var cityList = _masterClientRepository.GetCityList(countryId);
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