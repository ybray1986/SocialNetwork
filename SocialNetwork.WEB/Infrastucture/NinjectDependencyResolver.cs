using AutoMapper;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject.Activation;
using SocialNetwork.WEB.Profiles;

namespace SocialNetwork.WEB.Infrastucture
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IMapper>().ToMethod(Mapping);
        }

        private IMapper Mapping(IContext context)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.ConstructServicesUsing(t => kernel.Get(t));
                cfg.AddProfile<MapperProfile>();
            });
            return Mapper.Instance;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}