using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cuelogic.Clrm.Api.Controllers
{
    [Authorize]
    public class MasterGroupController : ApiController
    {
        // GET: api/MasterGroup SearchParam objSearchParam
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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MasterGroup
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MasterGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MasterGroup/5
        public void Delete(int id)
        {
        }
    }
}
