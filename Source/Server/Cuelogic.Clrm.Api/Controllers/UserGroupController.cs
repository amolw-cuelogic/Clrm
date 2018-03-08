using Cuelogic.Clrm.Service.UserGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public IHttpActionResult GetEmployeeList(string employeeName)
        {
            if (employeeName == null)
                employeeName = "";
            var data = _userGroupService.GetEmployeeList(employeeName);
            return Ok(data);
        }

        [Route("groups")]
        public IHttpActionResult GetGroupList()
        {
            var data = _userGroupService.GetGroupList();
            return Ok(data);
        }

        [Route("groupmembers/{id}")]
        public IHttpActionResult GetIdentityGroupMembers(int id)
        {
            var data = _userGroupService.GetIdentityGroupMembers(id);
            return Ok(data);
        }

        // POST: api/UserGroup
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserGroup/5
        public void Delete(int id)
        {
        }
    }
}
