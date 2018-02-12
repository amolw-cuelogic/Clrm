using Cuelogic.Clrm.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer
{
    public class CommonDa
    {
        public static DataSet GetEmployeeDetails(string EmailId)
        {
            var ds = DataAccessHelper.ExecuteQuery("spGetEmployeeByEmailId('" + EmailId + "')",
                CommandType.Text, null);
            return ds;
        }
    }
}
