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

        public string GetEmployeeAllocationList(int employeeId)
        {
            var ds = _commonDataAccess.GetEmployeeAllocationList(employeeId);
            var jsonString = ds.Tables[0].ToJsonString();
            return jsonString;
        }

        public Employee GetEmployeeDetails(string emailId)
        {
            var userContextDs = _commonDataAccess.GetEmployeeDetails(emailId);
            var employee = userContextDs.Tables[0].ToModel<Employee>();
            return employee;
        }

        public List<IdentityGroupRight> GetGroupRights(int employeeId)
        {
            var ds = _commonDataAccess.GetEmployeeRightList(employeeId);
            var list = ds.Tables[0].ToList<IdentityGroupRight>();
            return list;
        }
    }
}
