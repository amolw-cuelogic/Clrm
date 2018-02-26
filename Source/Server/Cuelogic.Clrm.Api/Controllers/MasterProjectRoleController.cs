using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.ProjectRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var jsonString = _masterProjectRoleService.GetList(searchParam);
            return Ok(jsonString);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var masterProjectRole = _masterProjectRoleService.GetItem(id);
            return Ok(masterProjectRole);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]MasterProjectRole masterProjectRole)
        {
            var userCtx = base.GetUserContext();
            _masterProjectRoleService.Save(masterProjectRole, userCtx);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _masterProjectRoleService.Delete(id);
            return Ok();
        }
    }
}
