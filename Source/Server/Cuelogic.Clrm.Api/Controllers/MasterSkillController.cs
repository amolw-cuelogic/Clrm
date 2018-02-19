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
        public IHttpActionResult Get(int Show, int Page, string FilterText)
        {
            var objSearchParam = new SearchParam();
            objSearchParam.FilterText = FilterText ?? "";
            objSearchParam.Page = Page;
            objSearchParam.Show = Show;
            var identityGroupJsonString = _masterSkillService.GetList(objSearchParam);
            return Ok(identityGroupJsonString);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var ObjMasterSkill = _masterSkillService.GetItem(id);
            return Ok(ObjMasterSkill);
        }

        [Route("")]
        public void Post([FromBody]MasterSkill ObjMasterSkill)
        {
            var userCtx = base.GetUserContext();
            _masterSkillService.Save(ObjMasterSkill, userCtx);
        }

        [Route("{id}")]
        public void Delete(int id)
        {
            _masterSkillService.Delete(id);
        }
    }
}
