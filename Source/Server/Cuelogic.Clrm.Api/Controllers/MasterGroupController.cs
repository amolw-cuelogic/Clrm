using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Interface;
using System;
using System.Web.Http;
using static Cuelogic.Clrm.Api.Filter.CustomFilter;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Api.Controllers
{
    [RoutePrefix("api/Group")]
    public class MasterGroupController : ApiBaseController
    {
        private readonly IMasterGroupService _masterGroup;
        public MasterGroupController(IMasterGroupService masterGroup)
        {
            
            _masterGroup = masterGroup;
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.AdminGroup, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            if (show < 0 || page < 0)
                return BadRequest(CustomError.InValidId);
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var identityGroupJsonString = _masterGroup.GetList(searchParam);
            return Ok(identityGroupJsonString);
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.AdminGroup, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
                return BadRequest(CustomError.InValidId);
            var identityGroup = _masterGroup.GetItem(id);
            return Ok(identityGroup);
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.AdminGroup, AuthorizeFlag.Write)]
        public IHttpActionResult Post([FromBody]IdentityGroup identityGroup)
        {
            var userCtx = base.GetUserContext();
            _masterGroup.Save(identityGroup, userCtx);
            return Ok();
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.AdminGroup, AuthorizeFlag.Delete)]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest(CustomError.InValidId);
            var userContext = base.GetUserContext();
            _masterGroup.Delete(id, userContext.UserId);
            return Ok();
        }
    }
}
