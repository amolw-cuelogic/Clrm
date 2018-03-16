using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository;
using System.Collections.Generic;
using System.Linq;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Service.Interface;

namespace Cuelogic.Clrm.Service
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IEmployeeService _employeeService;
        public CommonService()
        {
            _commonRepository = new CommonRepository();
            _employeeService = new EmployeeService();
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

        public void LogLoginTime(int employeeId)
        {
            _commonRepository.LogLoginTime(employeeId);
        }

        public void Save(EmployeeVm employeeVm, UserContext userContext)
        {
            _employeeService.Save(employeeVm, userContext);
        }
    }
}
