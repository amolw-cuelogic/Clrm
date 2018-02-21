using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Service.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        [Route("")]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var masterDepartmentJsonString = _employeeService.GetList(searchParam);
            return Ok(masterDepartmentJsonString);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var employeeVm = _employeeService.GetEmployee(id);
            return Ok(employeeVm);
        }

        [Route("")]
        public void Post([FromBody]string value)
        {
        }
        
        [Route("{id}")]
        public void Delete(int id)
        {
        }
    }
}
