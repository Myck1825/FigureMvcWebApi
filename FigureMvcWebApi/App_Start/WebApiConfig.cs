using System.Web.Http;

namespace FigureMvcWebApi
{
    /// <summary>
    /// WebApi Configuration
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register rule for route
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
