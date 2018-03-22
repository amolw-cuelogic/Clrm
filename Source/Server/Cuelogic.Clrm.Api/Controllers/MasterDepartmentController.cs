using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Interface;
using System;
using System.Web.Http;
using static Cuelogic.Clrm.Api.Filter.CustomFilter;
using static Cuelogic.Clrm.Common.AppConstants;

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
        [AuthorizeUserRights(IdentityRights.MasterDepartment, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            if (show < 0 || page < 0)
                return BadRequest(CustomError.InValidId);
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var masterDepartmentJsonString = _masterDepartmentService.GetList(searchParam);
            return Ok(masterDepartmentJsonString);
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.MasterDepartment, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
                return BadRequest(CustomError.InValidId);
            var masterDepartment = _masterDepartmentService.GetItem(id);
            return Ok(masterDepartment);
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.MasterDepartment, AuthorizeFlag.Write)]
        public IHttpActionResult Post([FromBody]MasterDepartment masterDepartment)
        {
            var userCtx = base.GetUserContext();
            _masterDepartmentService.Save(masterDepartment, userCtx);
            return Ok();
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.MasterDepartment, AuthorizeFlag.Delete)]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest(CustomError.InValidId);
            var userContext = base.GetUserContext();
            _masterDepartmentService.Delete(id, userContext.UserId);
            return Ok();
        }
    }
}
