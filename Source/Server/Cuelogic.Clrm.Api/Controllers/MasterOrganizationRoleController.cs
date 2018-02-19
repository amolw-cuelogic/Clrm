using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.OrganizationRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cuelogic.Clrm.Api.Controllers
{
    public class MasterOrganizationRoleController : ApiBaseController
    {
        private readonly IMasterOrganizationRoleService _masterOrganizationRoleService;

        public MasterOrganizationRoleController(IMasterOrganizationRoleService masterOrganizationRoleService)
        {
            _masterOrganizationRoleService = masterOrganizationRoleService;
        }
        // GET: api/MasterOrganizationRole
        public string Get(int Show, int Page, string FilterText)
        {
            var objSearchParam = new SearchParam();
            objSearchParam.FilterText = FilterText ?? "";
            objSearchParam.Page = Page;
            objSearchParam.Show = Show;
            var identityGroupJsonString = _masterOrganizationRoleService.GetList(objSearchParam);
            return identityGroupJsonString;
        }

        // GET: api/MasterOrganizationRole/5
        public MasterOrganizationRole Get(int id)
        {
            var ObjMasterOrganizationRole = _masterOrganizationRoleService.GetItem(id);
            return ObjMasterOrganizationRole;
        }

        // POST: api/MasterOrganizationRole
        public void Post([FromBody]MasterOrganizationRole ObjMasterOrganizationRole)
        {
            var userCtx = base.GetUserContext();
            _masterOrganizationRoleService.Save(ObjMasterOrganizationRole, userCtx);
        }
        
        // DELETE: api/MasterOrganizationRole/5
        public void Delete(int id)
        {
            _masterOrganizationRoleService.Delete(id);
        }
    }
}
