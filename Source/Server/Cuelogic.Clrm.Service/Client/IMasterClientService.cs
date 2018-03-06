using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Client
{
    public interface IMasterClientService
    {
        string GetList(SearchParam searchParam);
        MasterClient GetItem(int masterClientId);
        void Save(MasterClient masterClient, UserContext userCtx);
        void Delete(int masterClientId);
        List<MasterCity> GetCityList(int countryId);
    }
}
