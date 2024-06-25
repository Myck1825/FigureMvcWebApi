using FigureMvcWebApi.IoC;
using DependencyResolverMvc = System.Web.Mvc;
using DependencyResolverWebApi = System.Web.Http.Dependencies;

namespace FigureMvcWebApi.Extensions
{
    /// <summary>
    /// Extension for dependency mvc and web api
    /// </summary>
    public static class ServiceResolverExtensions
    {
        /// <summary>
        /// Mvc resolver
        /// </summary>
        /// <param name="dependencyResolver"></param>
        /// <returns></returns>
        public static DependencyResolverMvc.IDependencyResolver ToServiceMvcResolver(
            this DependencyResolverMvc.IDependencyResolver dependencyResolver)
        {
            return new ServiceResolverMvcAdapter(dependencyResolver);
        }

        /// <summary>
        /// WebApi resolver
        /// </summary>
        /// <param name="dependencyResolver"></param>
        /// <returns></returns>
        public static DependencyResolverWebApi.IDependencyResolver ToServiceWebApiResolver(
            this DependencyResolverWebApi.IDependencyResolver dependencyResolver)
        {
            return new ServiceResolverWebApiAdapter(dependencyResolver);
        }
    }
}