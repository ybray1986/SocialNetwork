using Ninject;
//using Ninject.Web.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SocialNetwork.WEB
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var kernel = new StandardKernel();
            //config.DependencyResolver = new NinjectDependencyResolver(kernel);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "Home/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
