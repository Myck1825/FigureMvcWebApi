using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace FigureMvcWebApi.IoC
{
    public class ServiceResolverWebApiAdapter : IDependencyResolver
    {
        private readonly IDependencyResolver dependencyResolver;

        public ServiceResolverWebApiAdapter(IDependencyResolver dependencyResolver)
        {
            if (dependencyResolver == null)
            {
                throw new ArgumentNullException("dependencyResolver");
            }

            this.dependencyResolver = dependencyResolver;
        }

        public IDependencyScope BeginScope()
        {
            return dependencyResolver.BeginScope();
        }

        public void Dispose()
        {
            dependencyResolver.Dispose();
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