using Cuelogic.Clrm.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Security.Claims;
using static Cuelogic.Clrm.Common.AppConstants;
using Cuelogic.Clrm.Model.DatabaseModel;
using Newtonsoft.Json.Linq;
using static Cuelogic.Clrm.Common.CustomException;

namespace Cuelogic.Clrm.Api.Filter
{
    public class CustomFilter
    {
        public class CustomExceptionFilter : ExceptionFilterAttribute
        {
            private ILog applogManager = AppLogManager.GetLogger();
            public override void OnException(HttpActionExecutedContext actionExecutedContext)
            {
                applogManager.Error(actionExecutedContext.Exception);
                ExceptionFactory.GetException(actionExecutedContext);
            }
        }


        public class AuthorizeUserRightsAttribute : AuthorizeAttribute
        {
            public int RightId { get; set; }
            public int ActionFlag { get; set; }

            public AuthorizeUserRightsAttribute(int rightid = 0, int actionFlag = 0)
            {
                RightId = rightid;
                ActionFlag = actionFlag;
            }

            public override void OnAuthorization(HttpActionContext actionContext)
            {

                if (RightId != 0 && ActionFlag != 0)
                {
                    ClaimsPrincipal principal = actionContext.Request.GetRequestContext().Principal as ClaimsPrincipal;
                    var xml = principal.Claims.Where(c => c.Type == "Rights").Single().Value;
                    Type t = (new List<IdentityGroupRight>()).GetType();
                    var employeeRights = Helper.XmlToObject(xml, t) as List<IdentityGroupRight>;
                    var sectionRight = employeeRights.Where(m => m.RightId == RightId).FirstOrDefault();

                    if (sectionRight == null)
                        throw new ClientWarning("No rights defined");

                    switch (ActionFlag)
                    {
                        case AuthorizeFlag.Read:
                            if (!sectionRight.BooleanRight.Read)
                                throw new ClientWarning("Access Denied");
                            break;
                        case AuthorizeFlag.Write:
                            if (!sectionRight.BooleanRight.Write)
                                throw new ClientWarning("Access Denied");
                            break;
                        case AuthorizeFlag.Delete:
                            if (!sectionRight.BooleanRight.Delete)
                                throw new ClientWarning("Access Denied");
                            break;
                        default:
                            throw new ClientWarning("No rights defined");
                    }
                }
            }
        }

    }
}