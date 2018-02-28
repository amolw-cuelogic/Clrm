using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Allocations;

namespace Cuelogic.Clrm.Service.Allocations
{
    public class AllocationService : IAllocationService
    {
        private readonly IAllocationRepository _allocationRepository;

        public AllocationService()
        {
            _allocationRepository = new AllocationRepository();
        }
        public void Delete(int allocationId)
        {
            _allocationRepository.MarkAllocationInvalid(allocationId);
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

        public void Save(Allocation allocation, UserContext userCtx)
        {
            _allocationRepository.AddOrUpdateAllocation(allocation, userCtx);
        }
    }
}
