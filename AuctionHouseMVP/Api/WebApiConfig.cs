using System.Web.Http;

namespace AHWForm.Api
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "WebApi",
                routeTemplate: "Api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );
        }
    }
}