using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cuelogic.Clrm.Api.Controllers
{
    [RoutePrefix("api/Department")]
    public class MasterDepartmentController : ApiBaseController
    {
        
        private readonly IMasterDepartmentService _masterDepartmentService;
        public MasterDepartmentController(IMasterDepartmentService masterDepartmentService)
        {
            _masterDepartmentService = masterDepartmentService;
        }

        [Route("")]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var masterDepartmentJsonString = _masterDepartmentService.GetList(searchParam);
            return Ok(masterDepartmentJsonString);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var masterDepartment = _masterDepartmentService.GetItem(id);
            return Ok(masterDepartment);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]MasterDepartment masterDepartment)
        {
            var userCtx = base.GetUserContext();
            _masterDepartmentService.Save(masterDepartment, userCtx);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _masterDepartmentService.Delete(id);
            return Ok();
        }
    }
}
