using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface ICommonService
    {
        Employee GetEmployeeDetails(string EmailId);
    }
}
