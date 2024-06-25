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
    public class WebApiApplication : NinjectHttpApplication
    {
        public static IKernel LocalKernel { get; set; }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(LocalKernel).ToServiceWebApiResolver();
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new DependencyMapper());
            LocalKernel = kernel;
            //kernel.Load(Assembly.GetExecutingAssembly(), Assembly.Load("NInjectSample.Common"));

            return kernel;

        }
    }
}
