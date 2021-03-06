﻿using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service;
using Cuelogic.Clrm.Service.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Cuelogic.Clrm.Api.Controllers
{
    [RoutePrefix("api/Group")]
    public class MasterGroupController : ApiBaseController
    {
        private readonly IMasterGroup _masterGroup;
        public MasterGroupController(IMasterGroup masterGroup)
        {
            
            _masterGroup = masterGroup;
        }

        [Route("")]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var identityGroupJsonString = _masterGroup.GetList(searchParam);
            return Ok(identityGroupJsonString);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var identityGroup = _masterGroup.GetItem(id);
            return Ok(identityGroup);
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]IdentityGroup identityGroup)
        {
            var userCtx = base.GetUserContext();
            _masterGroup.Save(identityGroup, userCtx);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _masterGroup.Delete(id);
            return Ok();
        }
    }
}
