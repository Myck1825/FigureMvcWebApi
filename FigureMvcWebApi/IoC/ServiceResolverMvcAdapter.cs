using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FigureMvcWebApi.IoC
{
    public class ServiceResolverMvcAdapter : IDependencyResolver
    {
        private readonly IDependencyResolver dependencyResolver;

        public ServiceResolverMvcAdapter(IDependencyResolver dependencyResolver)
        {
            if (dependencyResolver == null)
            {
                throw new ArgumentNullException("dependencyResolver");
            }

            this.dependencyResolver = dependencyResolver;
        }

        public object GetService(Type serviceType)
        {
            return dependencyResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return dependencyResolver.GetServices(serviceType);
        }
    }
}