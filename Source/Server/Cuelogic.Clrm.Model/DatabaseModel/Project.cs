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
            IsComplete = false;
            IsValid = false;
            CreatedBy = 0;
            CreatedOn = "";
            UpdatedBy = 0;
            UpdatedOn = "";
            CreatedByName = "";
            UpdatedByName = "";
            ClientName = "";
            ProjectClientChildList = new List<ProjectClient>();
            ProjectMasterClientList = new List<MasterClient>();
        }
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int ProjectTypeId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
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
        public string ClientName { get; set; }
        public List<ProjectClient> ProjectClientChildList { get; set; }
        public List<MasterClient> ProjectMasterClientList { get; set; }
        #endregion
    }
}
