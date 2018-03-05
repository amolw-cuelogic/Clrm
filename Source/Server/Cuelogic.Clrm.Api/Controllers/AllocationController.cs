using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Allocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Cuelogic.Clrm.Api.Filter.CustomFilter;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Api.Controllers
{
    [RoutePrefix("api/EmployeeAllocation")]
    public class AllocationController : ApiBaseController
    {
        private readonly IAllocationService _allocationService;
        public AllocationController(IAllocationService allocationService)
        {
            _allocationService = allocationService;
        }
        
        [AuthorizeUserRights(IdentityRights.Allocation, AuthorizeFlag.Read)]
        [Route("")]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var jsonString = _allocationService.GetList(searchParam);
            return Ok(jsonString);
        }

        [AuthorizeUserRights(IdentityRights.Allocation, AuthorizeFlag.Read)]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var allocation = _allocationService.GetItem(id);
            return Ok(allocation);
        }

        [AuthorizeUserRights(IdentityRights.Allocation, AuthorizeFlag.Read)]
        [Route("GetAllocation/{id}")]
        public IHttpActionResult GetAllocation(int id)
        {
            var allocation = _allocationService.GetAllocationSum(id);
            return Ok(allocation);
        }

        [AuthorizeUserRights(IdentityRights.Allocation, AuthorizeFlag.Write)]
        [Route("")]
        public IHttpActionResult Post([FromBody]Allocation allocation)
        {
            var userContext = base.GetUserContext();
            _allocationService.Save(allocation, userContext);
            return Ok();
        }

        [AuthorizeUserRights(IdentityRights.Allocation, AuthorizeFlag.Delete)]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _allocationService.Delete(id);
            return Ok();
        }
    }
}
