using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model
{
    public class IdentityGroupRight
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int RightId { get; set; }
        public int Action { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
}
