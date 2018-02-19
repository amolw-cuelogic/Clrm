using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.DataAccessLayer;
using Cuelogic.Clrm.DataAccessLayer.Common;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.DatabaseModel;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Common
{
    public class CommonRepository : ICommonRepository
    {
        private readonly ICommonDataAccess _commonDataAccess;
        public CommonRepository()
        {
            _commonDataAccess = new CommonDataAccess();
        }
        public Employee GetEmployeeDetails(string EmailId)
        {
            var UserContextDs = _commonDataAccess.GetEmployeeDetails(EmailId);
            var Obj = UserContextDs.Tables[0].ToModel<Employee>();
            return Obj;
        }
    }
}
