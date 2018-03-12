using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class ProjectRole
    {
        public ProjectRole()
        {
            Id = 0;
            ProjectId = 0;
            RoleId = 0;
            BillingRate = 0;
            CurrencyId = 0;
            IsValid = false;
            CreatedBy = 0;
            CreatedOn = "";
            UpdatedBy = 0;
            UpdatedOn = "";
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
        public int BillingRate { get; set; }
        public int CurrencyId { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        

    }
}
