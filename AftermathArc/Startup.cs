﻿using Microsoft.Owin;
using Owin;
using System.Dynamic;
[assembly: OwinStartupAttribute(typeof(AftermathArc.Startup))]
namespace AftermathArc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
