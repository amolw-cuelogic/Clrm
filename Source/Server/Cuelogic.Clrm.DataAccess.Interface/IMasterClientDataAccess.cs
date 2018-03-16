using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
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
