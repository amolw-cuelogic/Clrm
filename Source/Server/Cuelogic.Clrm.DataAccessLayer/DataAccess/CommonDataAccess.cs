using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.DataAccess
{
    public class CommonDataAccess : ICommonDataAccess
    {
        public DataSet GetEmployeeDetails(string EmailId)
        {
            var ds = DataAccessHelper.ExecuteQuery("spGetEmployeeByEmailId('" + EmailId + "')");
            return ds;
        }
    }
}
