using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.DataAccessLayer.Allocations;
using Cuelogic.Clrm.Common;

namespace Cuelogic.Clrm.Repository.Allocations
{
    public class AllocationRepository : IAllocationRepository
    {
        private readonly IAllocationDataAccess _allocationDataAccess;
        public AllocationRepository()
        {
            _allocationDataAccess = new AllocationDataAccess();
        }
        public void AddOrUpdateAllocation(Allocation allocation, UserContext userContext)
        {
            allocation.UpdatedBy = userContext.UserId;
            allocation.CreatedBy = userContext.UserId;
            allocation.UpdatedOn = DateTime.Now.ToMySqlDateString();
            allocation.CreatedOn = DateTime.Now.ToMySqlDateString();
            _allocationDataAccess.AddOrUpdateAllocation(allocation);
        }

        public Allocation GetAllocation(int allocationId)
        {
            var allocation = new Allocation();
            if (allocationId != 0)
            {
                var allocationDs = _allocationDataAccess.GetAllocation(allocationId);
                allocation = allocationDs.Tables[0].ToModel<Allocation>();
                allocation.ExistingAllocation = GetAllocationSum(allocation.EmployeeId);
            }

            var ds = _allocationDataAccess.GetAllocationSelectList();
            allocation.SelectListEmployee = ds.Tables[AppConstants.StoreProcedure.spAllocation_GetSelectList_Tables.Employee].ToList<Employee>();
            allocation.SelectListMasterProjectRole = ds.Tables[AppConstants.StoreProcedure.spAllocation_GetSelectList_Tables.MasterProjectRole].ToList<MasterProjectRole>();
            allocation.SelectListProject = ds.Tables[AppConstants.StoreProcedure.spAllocation_GetSelectList_Tables.Project].ToList<Project>();

            return allocation;
        }

        public DataSet GetAllocationList(SearchParam searchParam)
        {
            var ds = _allocationDataAccess.GetAllocationList(searchParam);
            return ds;
        }

        public int GetAllocationSum(int employeeId)
        {
            var ds = _allocationDataAccess.GetAllocationSum(employeeId);
            var id = ds.Tables[0].ToId();
            return id;
        }

        public void MarkAllocationInvalid(int allocationId)
        {
            _allocationDataAccess.MarkAllocationInvalid(allocationId);
        }
    }
}
