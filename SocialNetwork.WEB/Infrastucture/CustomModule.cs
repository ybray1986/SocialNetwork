using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Modules;
using AutoMapper;
using Ninject.Activation;
using SocialNetwork.WEB.Profiles;
using SocialNetwork.AUTH.Infrastucture;

namespace SocialNetwork.WEB.Infrastucture
{
    public class CustomModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(AutoMapping).InSingletonScope();
            Bind<IAuthProvider>().To<AuthProvider>();
        }

        private IMapper AutoMapping(IContext context)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.ConstructServicesUsing(t => context.Kernel.Get(t));
                cfg.AddProfile<MapperProfile>();
            });
            return Mapper.Instance;
        }
    }
}