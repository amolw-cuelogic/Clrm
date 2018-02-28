using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cuelogic.Clrm.Api.Controllers
{
    [RoutePrefix("api/Skill")]
    public class MasterSkillController : ApiBaseController
    {
        private readonly IMasterSkillService _masterSkillService;

        public MasterSkillController(IMasterSkillService masterSkillService)
        {
            _masterSkillService = masterSkillService;
        }

        [Route("")]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var jsonString = _masterSkillService.GetList(searchParam);
            return Ok(jsonString);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var masterSkill = _masterSkillService.GetItem(id);
            return Ok(masterSkill);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]MasterSkill masterSkill)
        {
            var userCtx = base.GetUserContext();
            _masterSkillService.Save(masterSkill, userCtx);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _masterSkillService.Delete(id);
            return Ok();
        }
    }
}
