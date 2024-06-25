using FigureMvcWebApi.IoC;
using System.Security.Cryptography;
using System.Web.Mvc;
using DependencyResolverMvc = System.Web.Mvc;
using DependencyResolverWebApi = System.Web.Http.Dependencies;

namespace FigureMvcWebApi.Extensions
{
    public static class ServiceResolverExtensions
    {
        public static DependencyResolverMvc.IDependencyResolver ToServiceMvcResolver(
            this DependencyResolverMvc.IDependencyResolver dependencyResolver)
        {
            return new ServiceResolverMvcAdapter(dependencyResolver);
        }

        public static DependencyResolverWebApi.IDependencyResolver ToServiceWebApiResolver(
            this DependencyResolverWebApi.IDependencyResolver dependencyResolver)
        {
            return new ServiceResolverWebApiAdapter(dependencyResolver);
        }
    }
}