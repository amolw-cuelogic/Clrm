using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Api.Tests.MasterClientTest
{
    public class MasterClientMockData
    {
        public static string GetMockDataMasterClientList()
        {
            return "[{'Id':15,'ClientName':'Abbott Laboratories','CountryName':'USA','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':16,'ClientName':'Aarons, Inc','CountryName':'USA','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':17,'ClientName':'Walmart','CountryName':'USA','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':18,'ClientName':'ExxonMobil','CountryName':'USA','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'}]";
        }

        public static MasterClient GetMockDataMasterClient()
        {
            var data = new MasterClient();
            data.Id = 1;
            data.ClientName = "ZS Associate";
            data.IsValid = true;
            data.CreatedBy = 1;
            data.CreatedOn = "2018-02-02";
            return data;
        }
    }
}
