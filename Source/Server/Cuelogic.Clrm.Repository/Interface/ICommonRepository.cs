using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface ICommonRepository
    {
        Employee GetEmployeeDetails(string EmailId);
    }
}
