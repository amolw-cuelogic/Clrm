using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess.MySql;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private readonly ICommonDataAccess _commonDataAccess;
        public CommonRepository()
        {
            var databaseType = AppUtillity.GetTargetDatabase();
            if (databaseType == DatabaseType.MySql)
                _commonDataAccess = new CommonDataAccessMySql();
            else
                throw new Exception(CustomError.DbConcreteImplementation);
        }

        public string GetEmployeeAllocationList(int employeeId)
        {
            var ds = _commonDataAccess.GetEmployeeAllocationList(employeeId);
            string jsonString = "";
            if (ds.Tables[0].Rows.Count == 0)
                jsonString = "[]";
            else
                jsonString = ds.Tables[0].ToJsonString();
            return jsonString;
        }

        public Employee GetEmployeeDetails(string emailId)
        {
            var userContextDs = _commonDataAccess.GetEmployeeDetailsByEmailId(emailId);
            var employee = new Employee();
            if (userContextDs.Tables[0].Rows.Count > 0)
                employee = userContextDs.Tables[0].ToModel<Employee>();
            return employee;
        }

        public List<IdentityGroupRight> GetGroupRights(int employeeId)
        {
            var ds = _commonDataAccess.GetEmployeeRightList(employeeId);
            var list = ds.Tables[0].ToList<IdentityGroupRight>();
            return list;
        }

        public void LogLoginTime(int employeeId)
        {
            _commonDataAccess.LogLoginTime(employeeId);
        }
    }
}
