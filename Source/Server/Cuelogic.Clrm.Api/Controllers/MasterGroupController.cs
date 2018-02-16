using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service;
using Cuelogic.Clrm.Service.Interface;
using Cuelogic.Clrm.Service.Service;
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
        IMasterGroup MasterObj;
        public MasterGroupController(IMasterGroup iobjMasterGroup)
        {
            
            MasterObj = iobjMasterGroup;
        }
        // GET: api/MasterGroup 
        public string Get(int Show, int Page, string FilterText)
        {
            var objSearchParam = new SearchParam();
            objSearchParam.FilterText = FilterText ?? "";
            objSearchParam.Page = Page;
            objSearchParam.Show = Show;
            var identityGroupJsonString = MasterObj.GetList(objSearchParam);
            return identityGroupJsonString;
        }

        // GET: api/MasterGroup/5
        public IdentityGroup Get(int id)
        {
            var ObjIdentityGroup = MasterObj.GetItem(id);
            return ObjIdentityGroup;
        }

        // POST: api/MasterGroup
        public void Post([FromBody]IdentityGroup objIdentityGroup)
        {
            var userCtx = base.GetUserContext();
            MasterObj.Save(objIdentityGroup, userCtx);
        }

        // PUT: api/MasterGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MasterGroup/5
        public void Delete(int id)
        {
            MasterObj.Delete(id);
        }
    }
}
