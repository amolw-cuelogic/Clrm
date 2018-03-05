﻿using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Skill;
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
    [RoutePrefix("api/Skill")]
    public class MasterSkillController : ApiBaseController
    {
        private readonly IMasterSkillService _masterSkillService;

        public MasterSkillController(IMasterSkillService masterSkillService)
        {
            _masterSkillService = masterSkillService;
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.MasterSkill, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            if (show < 0 || page < 0)
                throw new Exception("Negative values not allowed");
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var jsonString = _masterSkillService.GetList(searchParam);
            return Ok(jsonString);
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.MasterSkill, AuthorizeFlag.Read)]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
                throw new Exception("Negative id now allowed");
            var masterSkill = _masterSkillService.GetItem(id);
            return Ok(masterSkill);
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.MasterSkill, AuthorizeFlag.Write)]
        public IHttpActionResult Post([FromBody]MasterSkill masterSkill)
        {
            var userCtx = base.GetUserContext();
            _masterSkillService.Save(masterSkill, userCtx);
            return Ok();
        }

        [Route("{id}")]
        [AuthorizeUserRights(IdentityRights.MasterSkill, AuthorizeFlag.Delete)]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
                throw new Exception("Negative id now allowed");
            _masterSkillService.Delete(id);
            return Ok();
        }
    }
}
