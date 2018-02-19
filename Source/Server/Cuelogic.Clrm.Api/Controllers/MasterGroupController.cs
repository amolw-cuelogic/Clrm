using Cuelogic.Clrm.Common;
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
        public IHttpActionResult Get(int Show, int Page, string FilterText)
        {
            var objSearchParam = new SearchParam();
            objSearchParam.FilterText = FilterText ?? "";
            objSearchParam.Page = Page;
            objSearchParam.Show = Show;
            var identityGroupJsonString = _masterGroup.GetList(objSearchParam);
            return Ok(identityGroupJsonString);
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var ObjIdentityGroup = _masterGroup.GetItem(id);
            return Ok(ObjIdentityGroup);
        }

        [Route("")]
        public void Post([FromBody]IdentityGroup objIdentityGroup)
        {
            var userCtx = base.GetUserContext();
            _masterGroup.Save(objIdentityGroup, userCtx);
        }

        [Route("{id}")]
        public void Delete(int id)
        {
            _masterGroup.Delete(id);
        }
    }
}
