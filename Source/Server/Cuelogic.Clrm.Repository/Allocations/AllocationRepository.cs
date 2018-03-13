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
using System.Web;
using static Cuelogic.Clrm.Common.AppConstants;

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
            if (allocation.IsValid)
            {
                var previousState = GetAllocation(allocation.Id);
                if(!previousState.IsValid)
                {
                    var sum = GetAllocationSum(allocation.EmployeeId);
                    var total = sum + allocation.PercentageAllocation;
                    if (total > 100)
                        throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "Employee has been already occupied 100%, please check the allocation list."));
                }
            }
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
                if (allocation.IsValid)
                    allocation.ExistingAllocation = GetAllocationSum(allocation.EmployeeId) - allocation.PercentageAllocation;
                else
                    allocation.ExistingAllocation = GetAllocationSum(allocation.EmployeeId);

                var masterRoleList = new List<MasterRole>();
                var projectRoleDs = _allocationDataAccess.GetProjectRolebyId(allocation.ProjectId);
                if (projectRoleDs.Tables[0].Rows.Count > 0)
                    masterRoleList = projectRoleDs.Tables[0].ToList<MasterRole>();
                allocation.SelectListMasterRole = masterRoleList;
            }

            var ds = _allocationDataAccess.GetAllocationSelectList();
            allocation.SelectListEmployee = ds.Tables[AppConstants.StoreProcedure.Allocation_GetSelectList_Tables.Employee].ToList<Employee>();
            allocation.SelectListProject = ds.Tables[AppConstants.StoreProcedure.Allocation_GetSelectList_Tables.Project].ToList<Project>();

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
            int id = 0;
            if (ds.Tables[0].Rows.Count > 0)
                id = ds.Tables[0].ToId();
            return id;
        }

        public List<MasterRole> GetProjectRolebyId(int projectId)
        {
            var masterRoleList = new List<MasterRole>();
            var ds = _allocationDataAccess.GetProjectRolebyId(projectId);
            if (ds.Tables[0].Rows.Count > 0)
                masterRoleList = ds.Tables[0].ToList<MasterRole>();
            return masterRoleList;
        }

        public void MarkAllocationInvalid(int allocationId, int employeeId)
        {
            var previousState = GetAllocation(allocationId);
            if (!previousState.IsValid)
            {
                var sum = GetAllocationSum(previousState.EmployeeId);
                if (sum >= 100)
                    throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "Allocation cannot exceed 100% (Making this record valid will cause allocation to exceed 100%.)"));

                var total = sum + previousState.PercentageAllocation;
                if (total > 100)
                    throw new Exception(Helper.ComposeClientMessage(MessageType.Warning, "Allocation cannot exceed 100% (Making this record valid will cause allocation to exceed 100%.)"));
            }
            _allocationDataAccess.MarkAllocationInvalid(allocationId, employeeId);
        }
    }
}
