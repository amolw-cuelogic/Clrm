using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.DataAccessLayer;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository
{
    public class CommonRepo
    {
        public static Employee GetEmployeeDetails(string EmailId)
        {
            var UserContextDs = CommonDa.GetEmployeeDetails(EmailId);
            var Obj = UserContextDs.Tables[0].ToModel<Employee>();
            return Obj;
        }
    }
}
