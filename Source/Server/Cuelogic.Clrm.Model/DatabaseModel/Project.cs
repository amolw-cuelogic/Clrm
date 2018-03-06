using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class Project
    {
        public Project()
        {
            Id = 0;
            ProjectName = "";
            Type = "";
            ProjectTypeId = 0;
            StartDate = "";
            EndDate = "";
            Description = "";
            CurrencyId = 0;
            ClientId = 0;
            IsComplete = false;
            IsValid = false;
            CreatedBy = 0;
            CreatedOn = "";
            UpdatedBy = 0;
            UpdatedOn = "";
            CreatedByName = "";
            UpdatedByName = "";
            ProjectMasterCurrencyList = new List<MasterCurrency>();
            ProjectMasterClientList = new List<MasterClient>();
            ProjectTypeList = new List<MasterProjectType>();
        }
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int ProjectTypeId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
        public int CurrencyId { get; set; }
        public int ClientId { get; set; }
        public bool IsComplete { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }

        #region METADATA
        public string Type { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }
        public List<MasterCurrency> ProjectMasterCurrencyList { get; set; }
        public List<MasterClient> ProjectMasterClientList { get; set; }
        public List<MasterProjectType> ProjectTypeList { get; set; }
        #endregion
    }
}
