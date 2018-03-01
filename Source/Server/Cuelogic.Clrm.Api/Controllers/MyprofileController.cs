using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace Cuelogic.Clrm.Api.Controllers
{
    [RoutePrefix("api/MyProfile")]
    public class MyprofileController : ApiBaseController
    {
        private readonly ICommonService _commonService;
        public MyprofileController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            var userContext = base.GetUserContext();
            var employeeVm = _commonService.GetEmployeeById(userContext.UserId);
            var employeeAllocation = _commonService.GetEmployeeAllocationList(userContext.UserId);
            return Ok(new { employeeVm= employeeVm, employeeAllocation = employeeAllocation });
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]EmployeeVm employeeVm)
        {
            var userContext = base.GetUserContext();
            _commonService.Save(employeeVm, userContext);
            return Ok();
        }

    }
}
