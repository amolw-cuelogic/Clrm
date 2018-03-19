using System.Collections.Generic;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;
using System;

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
            _allocationRepository.MarkAllocationInvalid(allocationId, employeeId);
        }

        public int GetAllocationSum(int employeeId)
        {
            var id = _allocationRepository.GetAllocationSum(employeeId);
            return id;
        }

        public Allocation GetItem(int allocationId)
        {
            var allocation = _allocationRepository.GetAllocation(allocationId);
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
            var masterRoleList = _allocationRepository.GetProjectRolebyId(projectId);
            return masterRoleList;
        }

        public void Save(Allocation allocation, UserContext userCtx)
        {
            _allocationRepository.AddOrUpdateAllocation(allocation, userCtx);
        }
    }
}
