﻿using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterClientRepository
    {
        DataSet GetMasterClientList(SearchParam searchParam);
        MasterClient GetMasterClient(int masterClientId);
        void AddOrUpdateMasterClient(MasterClient masterClient, UserContext userCtx);
        void MarkMasterClientInvalid(int masterClientId, int employeeId);
        List<MasterCity> GetCityList(int countryId);
    }
}