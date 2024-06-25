using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace FigureMvcWebApi.IoC
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceResolverWebApiAdapter : IDependencyResolver
    {
        private readonly IDependencyResolver dependencyResolver;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dependencyResolver"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ServiceResolverWebApiAdapter(IDependencyResolver dependencyResolver)
        {
            if (dependencyResolver == null)
            {
                throw new ArgumentNullException("dependencyResolver");
            }

            this.dependencyResolver = dependencyResolver;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            return dependencyResolver.BeginScope();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            dependencyResolver.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return dependencyResolver.GetService(serviceType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return dependencyResolver.GetServices(serviceType);
        }
    }
}