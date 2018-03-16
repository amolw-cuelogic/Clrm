﻿using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Interface;
using System.Runtime.CompilerServices;
using System.Web.Http;
using static Cuelogic.Clrm.Api.Filter.CustomFilter;
using static Cuelogic.Clrm.Common.AppConstants;

[assembly: InternalsVisibleTo("Tests.Unit")]
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
        [AuthorizeUserRights(IdentityRights.MyProfile, AuthorizeFlag.Read)]
        public IHttpActionResult Get()
        {
            var userContext = base.GetUserContext();
            var employeeVm = _commonService.GetEmployeeById(userContext.UserId);
            var employeeAllocation = _commonService.GetEmployeeAllocationList(userContext.UserId);
            return Ok(new { employeeVm= employeeVm, employeeAllocation = employeeAllocation });
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.MyProfile, AuthorizeFlag.Write)]
        public IHttpActionResult Post([FromBody]EmployeeVm employeeVm)
        {
            var userContext = base.GetUserContext();
            _commonService.Save(employeeVm, userContext);
            return Ok();
        }

    }
}
