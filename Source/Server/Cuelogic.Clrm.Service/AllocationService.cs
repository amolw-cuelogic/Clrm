using System.Collections.Generic;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;
using System;
using static Cuelogic.Clrm.Common.AppConstants;
using static Cuelogic.Clrm.Common.CustomException;

namespace Cuelogic.Clrm.Service
{
    public class AllocationService : IAllocationService
    {
        private readonly IAllocationRepository _allocationRepository;

        public AllocationService()
        {
            _allocationRepository = new AllocationRepository();
        }
        public void Delete(int allocationId, int employeeId)
        {
            var previousState = GetItem(allocationId);
            if (!previousState.IsValid)
            {
                var sum = GetAllocationSum(previousState.EmployeeId);
                if (sum >= 100)
                    throw new ClientWarning("Allocation cannot exceed 100% (Making this record valid will cause allocation to exceed 100%.)");

                var total = sum + previousState.PercentageAllocation;
                if (total > 100)
                    throw new ClientWarning("Allocation cannot exceed 100% (Making this record valid will cause allocation to exceed 100%.)");
            }
            _allocationRepository.MarkAllocationInvalid(allocationId, employeeId);
        }

        public int GetAllocationSum(int employeeId)
        {
            var ds = _allocationRepository.GetAllocationSum(employeeId);
            int id = 0;
            if (ds.Tables[0].Rows.Count > 0)
                id = ds.Tables[0].ToId();
            return id;
        }

        public Allocation GetItem(int allocationId)
        {
            var allocation = new Allocation();
            if (allocationId > 0)
            {
                var allocationDs = _allocationRepository.GetAllocation(allocationId);
                allocation = allocationDs.Tables[0].ToModel<Allocation>();
                if (allocation.IsValid)
                    allocation.ExistingAllocation = GetAllocationSum(allocation.EmployeeId) - allocation.PercentageAllocation;
                else
                    allocation.ExistingAllocation = GetAllocationSum(allocation.EmployeeId);

                var masterRoleList = new List<MasterRole>();
                var projectRoleDs = _allocationRepository.GetProjectRolebyId(allocation.ProjectId);
                if (projectRoleDs.Tables[0].Rows.Count > 0)
                    masterRoleList = projectRoleDs.Tables[0].ToList<MasterRole>();
                allocation.SelectListMasterRole = masterRoleList;
            }
            if (allocationId < 0)
                throw new BadRequest(CustomError.InValidId);
            var ds = _allocationRepository.GetAllocationSelectList();
            allocation.SelectListEmployee = ds.Tables[TableName.Employee].ToList<Employee>();
            allocation.SelectListProject = ds.Tables[TableName.Project].ToList<Project>();
            
            return allocation;
        }

        public string GetList(SearchParam searchParam)
        {
            var ds = _allocationRepository.GetAllocationList(searchParam);
            var jsonString = ds.Tables[0].ToJsonString();
            return jsonString;
        }

        public List<MasterRole> GetProjectRolebyId(int projectId)
        {
            var ds = _allocationRepository.GetProjectRolebyId(projectId);
            var masterRoleList = new List<MasterRole>();
            if (ds.Tables[0].Rows.Count > 0)
                masterRoleList = ds.Tables[0].ToList<MasterRole>();
            return masterRoleList;
        }

        public void Save(Allocation allocation, UserContext userContext)
        {
            if (allocation.IsValid)
            {
                var previousState = GetItem(allocation.Id);
                if (!previousState.IsValid)
                {
                    var sum = GetAllocationSum(allocation.EmployeeId);
                    var total = sum + allocation.PercentageAllocation;
                    if (total > 100)
                        throw new ClientWarning("Employee has been already occupied 100%, please check the allocation list.");
                }
            }
            allocation.UpdatedBy = userContext.UserId;
            allocation.CreatedBy = userContext.UserId;
            allocation.UpdatedOn = DateTime.Now.ToMySqlDateString();
            allocation.CreatedOn = DateTime.Now.ToMySqlDateString();
            _allocationRepository.AddOrUpdateAllocation(allocation, userContext);
        }
    }
}
