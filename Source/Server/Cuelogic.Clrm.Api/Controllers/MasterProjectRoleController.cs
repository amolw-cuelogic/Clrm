using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.ProjectRole;
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
    [RoutePrefix("api/ProjectProfile")]
    public class MasterProjectRoleController : ApiBaseController
    {
        private readonly IMasterProjectRoleService _masterProjectRoleService;
        public MasterProjectRoleController(IMasterProjectRoleService masterProjectRoleService)
        {
            _masterProjectRoleService = masterProjectRoleService;
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.MasterProjectRole, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            if (show < 0 || page < 0)
                throw new Exception("Negative values not allowed");
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var jsonString = _masterProjectRoleService.GetList(searchParam);
            return Ok(jsonString);
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.MasterProjectRole, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
                throw new Exception("Negative id now allowed");
            var masterProjectRole = _masterProjectRoleService.GetItem(id);
            return Ok(masterProjectRole);
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.MasterProjectRole, AuthorizeFlag.Write)]
        public IHttpActionResult Post([FromBody]MasterProjectRole masterProjectRole)
        {
            var userCtx = base.GetUserContext();
            _masterProjectRoleService.Save(masterProjectRole, userCtx);
            return Ok();
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.MasterProjectRole, AuthorizeFlag.Delete)]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
                throw new Exception("Negative id now allowed");
            _masterProjectRoleService.Delete(id);
            return Ok();
        }
    }
}
