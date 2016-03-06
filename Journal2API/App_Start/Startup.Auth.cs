using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Journal2API.Providers;
using Journal2API.Models;
using Microsoft.AspNet.Identity.Owin;
using Journal2API.Models.Auth;

namespace Journal2API
{
    public partial class Startup
    {

        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<JournalContext>(() => new JournalContext());
            app.CreatePerOwinContext<UserManager<User>>(CreateManager);

            var PublicClientId = "journal";
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // Note: Remove the following line before you deploy to production:
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
        }

        private UserManager<User> CreateManager(
          IdentityFactoryOptions<UserManager<User>> options,
          IOwinContext context)
        {
            var user_store =
                new UserStore<User>(context.Get<JournalContext>());

            var manager =
                new UserManager<User>(user_store);

            return manager;
        }
    }
}
