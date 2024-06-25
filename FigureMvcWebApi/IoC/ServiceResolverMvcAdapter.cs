using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FigureMvcWebApi.IoC
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceResolverMvcAdapter : IDependencyResolver
    {
        private readonly IDependencyResolver dependencyResolver;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dependencyResolver"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ServiceResolverMvcAdapter(IDependencyResolver dependencyResolver)
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