using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface IMasterClientService
    {
        string GetList(SearchParam searchParam);
        MasterClient GetItem(int masterClientId);
        void Save(MasterClient masterClient, UserContext userCtx);
        void Delete(int masterClientId, int employeeId);
        List<MasterCity> GetCityList(int countryId);
    }
}
