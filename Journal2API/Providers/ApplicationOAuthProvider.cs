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
using Journal2API.Models;
using Journal2API.Models.Auth;

namespace Journal2API.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private string AppId { get; set; }
        private JournalRepo JournalRepo { get; set; }

        public ApplicationOAuthProvider(string app_id)
        {
            AppId = app_id;
        }
        

        public override async Task GrantResourceOwnerCredentials
  (OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user_man = context.OwinContext.GetUserManager<UserManager<User>>();

            var user = new User(context.UserName);
            user.Password = context.Password;
            var res = await user_man.UserValidator.ValidateAsync(user);
        }
    }
}