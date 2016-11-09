using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "CarProject.Controllers" } 
            );

            routes.MapRoute(
                name: "productRoutes",
                url: "Store/Products/{id}/{info1}/{info2}/{info3}/{info4}/{info5}",
                defaults: new { controller = "Store", action = "Products", id = UrlParameter.Optional, info1 = UrlParameter.Optional, info2 = UrlParameter.Optional, info3 = UrlParameter.Optional, info4 = UrlParameter.Optional, info5 = UrlParameter.Optional },
                namespaces: new[] { "CarProject.Controllers" }
            );

            routes.MapRoute(
                name: "CarsRoutes",
                url: "Cars/Car/{id}/{info1}/{info2}/{info3}/{info4}/{info5}",
                defaults: new { controller = "Cars", action = "Car", id = UrlParameter.Optional, info1 = UrlParameter.Optional, info2 = UrlParameter.Optional, info3 = UrlParameter.Optional, info4 = UrlParameter.Optional, info5 = UrlParameter.Optional },
                namespaces: new[] { "CarProject.Controllers" }
            );
        }
    }
}