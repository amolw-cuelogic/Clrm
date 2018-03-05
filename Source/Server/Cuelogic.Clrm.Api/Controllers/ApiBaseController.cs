using Cuelogic.Clrm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Api.Controllers
{
    [Authorize]
    public class ApiBaseController : ApiController
    {
        
        public UserContext GetUserContext()
        {
            var ObjUserContext = new UserContext();
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            ObjUserContext.EmailId = principal.Claims.Where(c => c.Type == "Email").Single().Value;
            ObjUserContext.UserId = int.Parse(principal.Claims.Where(c => c.Type == "Id").Single().Value.ToString());
            ObjUserContext.UserName = principal.Claims.Where(c => c.Type == "UserName").Single().Value;
            return ObjUserContext;
        }

        public HttpResponseMessage MessageClient(string messageType,string message)
        {
            var composedMessage = Helper.ComposeClientMessage(messageType, message);
            throw new Exception(composedMessage);
        }

    }
}
