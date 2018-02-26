using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.ProjectType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var jsonString = _masterProjectTypeService.GetList(searchParam);
            return Ok(jsonString);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var masterProjectType = _masterProjectTypeService.GetItem(id);
            return Ok(masterProjectType);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]MasterProjectType masterProjectType)
        {
            var userCtx = base.GetUserContext();
            _masterProjectTypeService.Save(masterProjectType, userCtx);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _masterProjectTypeService.Delete(id);
            return Ok();
        }
    }
}
