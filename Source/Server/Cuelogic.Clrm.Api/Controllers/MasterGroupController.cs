using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Cuelogic.Clrm.Api.Controllers
{
    public class MasterGroupController : ApiBaseController
    {
        // GET: api/MasterGroup | TODO : Revise returning logic later
        public string Get(int Show, int Page, string FilterText)
        {
            var objSearchParam = new SearchParam();
            objSearchParam.FilterText = FilterText ?? "";
            objSearchParam.Page = Page;
            objSearchParam.Show = Show;
            var ListIdentityGroup = MasterGroupSrv.GetIdentityGroupList(objSearchParam);
            return ListIdentityGroup;
        }

        // GET: api/MasterGroup/5
        public IdentityGroup Get(int id)
        {
            var ObjIdentityGroup = MasterGroupSrv.GetGroup(id);
            return ObjIdentityGroup;
        }

        // POST: api/MasterGroup
        public void Post([FromBody]IdentityGroup objIdentityGroup)
        {
            var userCtx = base.GetUserContext();
            MasterGroupSrv.Save(objIdentityGroup, userCtx);
        }

        // PUT: api/MasterGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MasterGroup/5
        public void Delete(int id)
        {
            MasterGroupSrv.Delete(id);
        }
    }
}
