using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.UserGroup;
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
    [RoutePrefix("api/Usergroup")]
    public class UserGroupController : ApiBaseController
    {
        private readonly IUserGroupService _userGroupService;
        public UserGroupController(IUserGroupService userGroupService)
        {
            _userGroupService = userGroupService;
        }

        [Route("employees")]
        [AuthorizeUserRights(IdentityRights.AdminUserGroup, AuthorizeFlag.Read)]
        public IHttpActionResult GetEmployeeList(string employeeName)
        {
            if (employeeName == null)
                employeeName = "";
            var data = _userGroupService.GetEmployeeList(employeeName);
            return Ok(data);
        }

        [Route("groups")]
        [AuthorizeUserRights(IdentityRights.AdminUserGroup, AuthorizeFlag.Read)]
        public IHttpActionResult GetGroupList()
        {
            var data = _userGroupService.GetGroupList();
            return Ok(data);
        }

        [Route("groupmembers/{id}")]
        [AuthorizeUserRights(IdentityRights.AdminUserGroup, AuthorizeFlag.Read)]
        public IHttpActionResult GetIdentityGroupMembers(int id)
        {
            if (id < 0)
                throw new Exception("Negative id now allowed");
            var data = _userGroupService.GetIdentityGroupMembers(id);
            return Ok(data);
        }

        [Route("")]
        [AuthorizeUserRights(IdentityRights.AdminUserGroup, AuthorizeFlag.Write)]
        public void Post([FromBody]List<IdentityEmployeeGroup> identityEmployeeGroup)
        {
            if(identityEmployeeGroup == null)
                throw new Exception("Null object not allowed");
            var userContext = base.GetUserContext();
            _userGroupService.InsertGroupUsers(identityEmployeeGroup, userContext);
        }
        
    }
}
