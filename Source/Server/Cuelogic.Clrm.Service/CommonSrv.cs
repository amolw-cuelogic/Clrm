using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service
{
    public class CommonSrv
    {
        public static Employee GetEmployeeDetails(string EmailId)
        {
            var data = CommonRepo.GetEmployeeDetails(EmailId);
            return data;
        }
    }
}
