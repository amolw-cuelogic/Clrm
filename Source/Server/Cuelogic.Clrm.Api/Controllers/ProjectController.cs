using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var identityGroupJsonString = _projectService.GetList(searchParam);
            return Ok(identityGroupJsonString);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var project = _projectService.GetItem(id);
            return Ok(project);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]Project project)
        {
            var userCtx = base.GetUserContext();
            _projectService.Save(project, userCtx);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return Ok();
        }
    }
}
