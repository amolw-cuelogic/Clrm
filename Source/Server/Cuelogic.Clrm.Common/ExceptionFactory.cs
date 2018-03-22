using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using static Cuelogic.Clrm.Common.AppConstants;
using static Cuelogic.Clrm.Common.CustomException;

namespace Cuelogic.Clrm.Common
{
    public class ExceptionFactory
    {
        public static HttpActionExecutedContext GetException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is BadRequest)
            {
                actionExecutedContext.Response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = actionExecutedContext.Exception.Message
                };
            }
            else if (actionExecutedContext.Exception is ClientWarning)
            {
                actionExecutedContext.Response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.MethodNotAllowed,
                    ReasonPhrase = actionExecutedContext.Exception.InnerException.Message
                };
            }
            else if (actionExecutedContext.Exception is NoContentFound)
            {
                actionExecutedContext.Response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.NoContent,
                    ReasonPhrase = actionExecutedContext.Exception.InnerException.Message
                };
            }
            else
            {
                actionExecutedContext.ActionContext.Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                    "InternalServerError",
                    actionExecutedContext.Exception);
            }
            return actionExecutedContext;
        }
    }
}
