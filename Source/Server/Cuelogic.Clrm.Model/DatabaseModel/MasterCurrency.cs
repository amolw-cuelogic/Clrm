using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class MasterCurrency
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Currency { get; set; }
        
    }
}
