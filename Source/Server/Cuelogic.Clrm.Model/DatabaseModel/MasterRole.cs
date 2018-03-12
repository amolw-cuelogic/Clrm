using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class MasterRole
    {
        public MasterRole()
        {
            Id = 0;
            Role = "";
            IsValid = false;
            CreatedBy = 0;
            CreatedOn = "";
            UpdatedBy = 0;
            UpdatedOn = "";
            CreatedByName = "";
            UpdatedByName = "";
        }
        public int Id { get; set; }
        public string Role { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }
    }
}
