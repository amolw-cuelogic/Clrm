using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Repository.Common;
using Cuelogic.Clrm.Repository.Employees;
using Cuelogic.Clrm.Service.Employees;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Cuelogic.Clrm.Service.Common
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _commonRepository;
        public CommonService()
        {
            _commonRepository = new CommonRepository();
        }

        public string GetEmployeeAllocationList(int employeeId)
        {
            return _commonRepository.GetEmployeeAllocationList(employeeId);
        }

        public Employee GetEmployeeByEmail(string emailId)
        {
            var data = _commonRepository.GetEmployeeDetails(emailId);
            return data;
        }

        public EmployeeVm GetEmployeeById(int employeeId)
        {
            IEmployeeService _employeeService = new EmployeeService();
            var employee = _employeeService.GetItem(employeeId);
            return employee;
        }

        public List<IdentityGroupRight> GetEmployeeRights(int employeeId)
        {
            var duplicateList = _commonRepository.GetGroupRights(employeeId);

            var distinctList = new List<IdentityGroupRight>();
            foreach (var item in duplicateList)
            {
                var addedItem = distinctList.Where(m => m.RightId == item.RightId).FirstOrDefault();
                if (addedItem != null)
                {
                    addedItem.Action = addedItem.Action | item.Action;
                    addedItem.SetBooleanRights(addedItem.Action);
                }
                else
                {
                    item.SetBooleanRights(item.Action);
                    distinctList.Add(item);
                }

            }
            return distinctList;
        }
        
        public void Save(EmployeeVm employeeVm, UserContext userContext)
        {
            IEmployeeService _employeeService = new EmployeeService();
            _employeeService.Save(employeeVm, userContext);
        }
    }
}
