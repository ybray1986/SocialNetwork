using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
[assembly: OwinStartup(typeof(SocialNetwork.WEB.Infrastucture.Startup))]
namespace SocialNetwork.WEB.Infrastucture
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();//
            //
        }
    }
}