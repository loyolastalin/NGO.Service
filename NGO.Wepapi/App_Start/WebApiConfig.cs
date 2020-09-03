using System.Web.Http;

namespace NGO.Wepapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Name",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "Values", action = "Get", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.EnableSystemDiagnosticsTracing();
        }
    }
}
