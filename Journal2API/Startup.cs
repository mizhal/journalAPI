using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Journal2API.Startup))]

namespace Journal2API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
