using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Interface;
using System;
using System.Web.Http;
using static Cuelogic.Clrm.Api.Filter.CustomFilter;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Api.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiBaseController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [AuthorizeUserRights(IdentityRights.AdminEmployee, AuthorizeFlag.Read)]
        [Route("")]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            if (show < 0 || page < 0)
                throw new Exception(CustomError.InValidId);
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var jsonString = _employeeService.GetList(searchParam);
            return Ok(jsonString);
        }

        [AuthorizeUserRights(IdentityRights.AdminEmployee, AuthorizeFlag.Read)]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
                throw new Exception(CustomError.InValidId);
            var employeeVm = _employeeService.GetItem(id);
            return Ok(employeeVm);
        }

        [AuthorizeUserRights(IdentityRights.AdminEmployee, AuthorizeFlag.Write)]
        [Route("")]
        public IHttpActionResult Post([FromBody]EmployeeVm employeeVm)
        {
            var userContext = base.GetUserContext();
            _employeeService.Save(employeeVm, userContext);
            return Ok();
        }

        [AuthorizeUserRights(IdentityRights.AdminEmployee, AuthorizeFlag.Delete)]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
                throw new Exception(CustomError.InValidId);
            var userContext = base.GetUserContext();
            _employeeService.Delete(id, userContext.UserId);
            return Ok();
        }
    }
}
