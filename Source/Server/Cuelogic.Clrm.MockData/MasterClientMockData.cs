using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.MockData
{
    public class MasterClientMockData
    {
        public static string GetMockDataMasterClientList()
        {
            return "[{'Id':15,'ClientName':'Abbott Laboratories','CountryName':'USA','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':16,'ClientName':'Aarons, Inc','CountryName':'USA','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':17,'ClientName':'Walmart','CountryName':'USA','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':18,'ClientName':'ExxonMobil','CountryName':'USA','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'}]";
        }

        public static DataSet GetMockDataMasterClientDataset()
        {
            var ds = new DataSet();
            var jsonString = GetMockDataMasterClientList();
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
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

        public static List<MasterCity> GetMockDataMasterCity()
        {
            var data = new List<MasterCity>();

            var obj1 = new MasterCity();
            obj1.Id = 1;
            obj1.CountryId = 1;
            obj1.CityName = "USA";
            data.Add(obj1);

            var obj2 = new MasterCity();
            obj2.Id = 1;
            obj2.CountryId = 1;
            obj2.CityName = "Houstan";
            data.Add(obj2);

            return data;
        }
    }
}
