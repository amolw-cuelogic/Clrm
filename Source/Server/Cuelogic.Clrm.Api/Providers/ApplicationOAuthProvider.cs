using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Cuelogic.Clrm.Api.Models;
using System.Text.RegularExpressions;

namespace Cuelogic.Clrm.Api.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            /*** Replace below user authentication code as per your Entity Framework Model ***
         using (var obj = new UserDBEntities())
         {

             tblUserMaster entry = obj.tblUserMasters.Where
             <tblUserMaster>(record => 
             record.User_ID == context.UserName && 
             record.User_Password == context.Password).FirstOrDefault();

             if (entry == null)
             {
                 context.SetError("invalid_grant", 
                 "The user name or password is incorrect.");
                 return;
             }                
         }
         */

            var domain = Regex.Match(context.UserName, @"@(.+?).com").Groups[1].Value.ToLower();
            if (domain != "cuelogic")
            {
                context.SetError("invalid_domain",
                 "Please login from cuelogic Id, Signout from your Gmail account : " + context.UserName);
                context.Response.StatusCode = 401;
                return;
            }

            ClaimsIdentity oAuthIdentity =
            new ClaimsIdentity(context.Options.AuthenticationType);
            ClaimsIdentity cookiesIdentity =
            new ClaimsIdentity(context.Options.AuthenticationType);
            AuthenticationProperties properties = CreateProperties(context.UserName);
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

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}