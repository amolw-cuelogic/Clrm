using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Projects;
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
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiBaseController
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.Project, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            if (show < 0 || page < 0)
                throw new Exception("Negative values not allowed");
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var jsonString = _projectService.GetList(searchParam);
            return Ok(jsonString);
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.Project, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
                throw new Exception("Negative id now allowed");
            var project = _projectService.GetItem(id);
            return Ok(project);
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.Project, AuthorizeFlag.Write)]
        public IHttpActionResult Post([FromBody]Project project)
        {
            var userCtx = base.GetUserContext();
            _projectService.Save(project, userCtx);
            return Ok();
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.Project, AuthorizeFlag.Delete)]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
                throw new Exception("Negative id now allowed");
            var userCtx = base.GetUserContext();
            _projectService.Delete(id, userCtx.UserId);
            return Ok();
        }
    }
}
