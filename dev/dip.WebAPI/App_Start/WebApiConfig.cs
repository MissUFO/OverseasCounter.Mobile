using System.Web.Http;

namespace dip.WebAPI
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      config.EnableCors();

      // Web API routes
      config.MapHttpAttributeRoutes();

      // Controller Only
      // To handle routes like `/api/VTRouting`
      config.Routes.MapHttpRoute(
          name: "ControllerOnly",
          routeTemplate: "api/{controller}"
      );


      // Controller with ID
      // To handle routes like `/api/VTRouting/1`
      config.Routes.MapHttpRoute(
          name: "ControllerAndId",
          routeTemplate: "api/{controller}/{id}",
          defaults: null,
          constraints: new { id = @"^\d+$" } // Only integers 
      );

      // Controllers with Actions
      // To handle routes like `/api/VTRouting/route`
      config.Routes.MapHttpRoute(
          name: "ControllerAndAction",
          routeTemplate: "api/{controller}/{action}"
      );

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{action}/{id}",
          defaults: new { id = RouteParameter.Optional }
          );
    }
  }
}
