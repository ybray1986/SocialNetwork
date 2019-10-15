using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(SocialNetwork.WEB.Infrastucture.Startup))]
namespace SocialNetwork.WEB.Infrastucture
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}