using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Interface;
using System;
using System.Web.Http;
using static Cuelogic.Clrm.Api.Filter.CustomFilter;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Api.Controllers
{
    [RoutePrefix("api/ProjectCategory")]
    public class MasterProjectTypeController : ApiBaseController
    {
        private readonly IMasterProjectTypeService _masterProjectTypeService;

        public MasterProjectTypeController(IMasterProjectTypeService masterProjectTypeService)
        {
            _masterProjectTypeService = masterProjectTypeService;
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.MasterProjectType, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            if (show < 0 || page < 0)
                return BadRequest(CustomError.InValidId);
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var jsonString = _masterProjectTypeService.GetList(searchParam);
            return Ok(jsonString);
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.MasterProjectType, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
                return BadRequest(CustomError.InValidId);
            var masterProjectType = _masterProjectTypeService.GetItem(id);
            return Ok(masterProjectType);
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.MasterProjectType, AuthorizeFlag.Write)]
        public IHttpActionResult Post([FromBody]MasterProjectType masterProjectType)
        {
            var userCtx = base.GetUserContext();
            _masterProjectTypeService.Save(masterProjectType, userCtx);
            return Ok();
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.MasterProjectType, AuthorizeFlag.Delete)]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest(CustomError.InValidId);
            var userContext = base.GetUserContext();
            _masterProjectTypeService.Delete(id, userContext.UserId);
            return Ok();
        }
    }
}
