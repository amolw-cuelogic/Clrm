using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class MasterClient
    {
        public MasterClient()
        {
            Id = 0;
            ClientName = "";
            CountryId = 0;
            CountryName = "";
            CityName = "";
            CityId = 0;
            IsValid = false;
            CreatedBy = 0;
            CreatedOn = "";
            UpdatedBy = 0;
            UpdatedOn = "";
            CreatedByName = "";
            UpdatedByName = "";
            MasterCountryList = new List<MasterCountry>();
            MasterCityList = new List<MasterCity>();
        }
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }

        #region METADATA
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public List<MasterCountry> MasterCountryList { get; set; }
        public List<MasterCity> MasterCityList { get; set; }
        #endregion
    }
}
