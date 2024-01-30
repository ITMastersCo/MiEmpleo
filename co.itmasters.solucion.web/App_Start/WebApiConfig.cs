using System.Web.Http;

namespace co.itmasters.solucion.web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "WebhookApi",
                routeTemplate: "api/webhook",
                defaults: new { controller = "Webhook", action = "Post" }
            );
        }
    }
}