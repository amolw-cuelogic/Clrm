using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class ProjectClient
    {
        public ProjectClient()
        {
            Id = 0;
            ProjectId = 0;
            ClientId = 0;
            IsValid = false;
            CreatedBy = 0;
            CreatedOn = "";
            UpdatedBy = 0;
            UpdatedOn = "";
            CreatedByName = "";
            UpdatedByName = "";
            ClientName = "";
        }
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ClientId { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }

        #region METADATA
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }
        public string ClientName { get; set; }
        #endregion
    }
}
