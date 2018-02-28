using Cuelogic.Clrm.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Cuelogic.Clrm.Api.Filter
{
    public class CustomFilter
    {
        public class CustomExceptionFilter : ExceptionFilterAttribute
        {
            private ILog applogManager = AppLogManager.GetLogger();
            public override void OnException(HttpActionExecutedContext actionExecutedContext)
            {
                string exceptionMessage = string.Empty;
                applogManager.Error(actionExecutedContext.Exception);
                if (actionExecutedContext.Exception.InnerException == null)
                {
                    exceptionMessage = actionExecutedContext.Exception.Message;
                }
                else
                {
                    exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
                }
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("An unhandled exception was thrown by service."),  
                    ReasonPhrase = exceptionMessage
                };
                actionExecutedContext.ActionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "InternalException", actionExecutedContext.Exception);
                
            }
        }
    }
}