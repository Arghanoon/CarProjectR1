using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CarProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Admin_defaultApi",
                routeTemplate: "AdminApi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
