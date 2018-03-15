using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.Client
{
    public interface IMasterClientDataAccess
    {
        DataSet GetMasterClientList(SearchParam searchParam);
        DataSet GetMasterClient(int masterClientId);
        void AddOrUpdateMasterClient(MasterClient masterClient);
        void MarkMasterClientInvalid(int masterClientId,int employeeId);
        DataSet GetCountryList();
        DataSet GetCityList(int countryId);
    }
}
