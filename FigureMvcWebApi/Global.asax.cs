using FigureMvcWebApi.Extensions;
using Ninject;
using Ninject.Web.Common.WebHost;
using Ninject.Web.WebApi;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FigureMvcWebApi
{
    /// <summary>
    /// Start up
    /// </summary>
    public class WebApiApplication : NinjectHttpApplication
    {
        /// <summary>
        /// Local kernel
        /// </summary>
        public static IKernel LocalKernel { get; set; }

        /// <summary>
        /// Start application
        /// </summary>
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(LocalKernel).ToServiceWebApiResolver();
        }

        /// <summary>
        /// Create kernel
        /// </summary>
        /// <returns></returns>
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new DependencyMapper());
            LocalKernel = kernel;

            return kernel;
        }
    }
}
