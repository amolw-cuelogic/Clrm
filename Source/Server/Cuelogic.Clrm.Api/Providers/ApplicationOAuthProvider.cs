using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Cuelogic.Clrm.Common;
using static Cuelogic.Clrm.Common.AppConstants;
using log4net;
using Cuelogic.Clrm.Service.Interface;
using Cuelogic.Clrm.Service;

namespace Cuelogic.Clrm.Api.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private ICommonService _commonService;
        private readonly string _publicClientId;
        private ILog applogManager = AppLogManager.GetLogger();

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
            _commonService = new CommonService();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var employeeDetails = _commonService.GetEmployeeByEmail(context.UserName);
            
            if (employeeDetails.IsValid == false)
            {
                context.SetError("custom_error", Helper.ComposeClientMessage(MessageType.Error, "User not valid"));
                context.Response.StatusCode = 500;
                return;
            }

            if (!string.IsNullOrEmpty(employeeDetails.LeavingDate))
            {
                var date = DateTime.Parse(employeeDetails.LeavingDate);
                if (DateTime.Now > date)
                {
                    context.SetError("custom_error", Helper.ComposeClientMessage(MessageType.Error, "User not part of Organization"));
                    context.Response.StatusCode = 500;
                    return;
                }
            }

            var displayName = employeeDetails.FirstName + " " + employeeDetails.LastName;
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("Email", employeeDetails.Email));
            identity.AddClaim(new Claim("Id", employeeDetails.Id.ToString()));
            identity.AddClaim(new Claim("UserName", displayName));

            ICommonService commonService = new CommonService();
            commonService.LogLoginTime(employeeDetails.Id);
            var employeeRights =  commonService.GetEmployeeRights(employeeDetails.Id);
            var employeeRightsXml = Helper.ObjectToXml(employeeRights);
            var employeeRightsJson = Helper.ObjectToJson(employeeRights);

            identity.AddClaim(new Claim("Rights", employeeRightsXml));

            ClaimsIdentity oAuthIdentity = identity;
            ClaimsIdentity cookiesIdentity =
            new ClaimsIdentity(context.Options.AuthenticationType);
            AuthenticationProperties properties = CreateProperties(context.UserName, employeeRightsJson, displayName);
            AuthenticationTicket ticket =
            new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName, string rights,string displayName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName },
                { "rights", rights },
                { "displayName",displayName}
            };
            return new AuthenticationProperties(data);
        }
    }
}