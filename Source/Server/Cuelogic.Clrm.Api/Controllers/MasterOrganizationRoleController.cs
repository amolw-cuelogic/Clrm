using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.OrganizationRole;
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
    [RoutePrefix("api/OrganizationRole")]
    public class MasterOrganizationRoleController : ApiBaseController
    {
        private readonly IMasterOrganizationRoleService _masterOrganizationRoleService;

        public MasterOrganizationRoleController(IMasterOrganizationRoleService masterOrganizationRoleService)
        {
            _masterOrganizationRoleService = masterOrganizationRoleService;
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.MasterOrganizationRole, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var jsonString = _masterOrganizationRoleService.GetList(searchParam);
            return Ok(jsonString);
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.MasterOrganizationRole, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int id)
        {
            var masterOrganizationRole = _masterOrganizationRoleService.GetItem(id);
            return Ok(masterOrganizationRole);
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.MasterOrganizationRole, AuthorizeFlag.Write)]
        public IHttpActionResult Post([FromBody]MasterOrganizationRole masterOrganizationRole)
        {
            var userCtx = base.GetUserContext();
            _masterOrganizationRoleService.Save(masterOrganizationRole, userCtx);
            return Ok();
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.MasterOrganizationRole, AuthorizeFlag.Delete)]
        public IHttpActionResult Delete(int id)
        {
            _masterOrganizationRoleService.Delete(id);
            return Ok();
        }
    }
}
