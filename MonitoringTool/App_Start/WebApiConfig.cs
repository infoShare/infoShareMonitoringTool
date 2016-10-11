using Microsoft.Practices.Unity;
using MonitoringTool.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Routing;
using Unity.Mvc5;

namespace MonitoringTool
{
   public static class WebApiConfig
   {
      public static void Register(HttpConfiguration config)
      {
         config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute("DefaultApiWithId", "api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
        config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}");
        config.Routes.MapHttpRoute("DefaultApiGet", "api/{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
        config.Routes.MapHttpRoute("DefaultApiPost", "api/{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
      }
   }
}
