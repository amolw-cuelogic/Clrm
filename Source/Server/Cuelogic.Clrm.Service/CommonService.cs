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
            var ds = _commonRepository.GetEmployeeAllocationList(employeeId);
            string jsonString = "";
            if (ds.Tables[0].Rows.Count == 0)
                jsonString = "[]";
            else
                jsonString = ds.Tables[0].ToJsonString();
            return jsonString;
        }

        public Employee GetEmployeeByEmail(string emailId)
        {
            var ds = _commonRepository.GetEmployeeDetails(emailId);
            var employee = new Employee();
            if (ds.Tables[0].Rows.Count > 0)
                employee = ds.Tables[0].ToModel<Employee>();
            return employee;
        }

        public EmployeeVm GetEmployeeById(int employeeId)
        {
            var employee = _employeeService.GetItem(employeeId);
            return employee;
        }

        public List<IdentityGroupRight> GetEmployeeRights(int employeeId)
        {
            var ds = _commonRepository.GetGroupRights(employeeId);
            var duplicateList = ds.Tables[0].ToList<IdentityGroupRight>();
            
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
