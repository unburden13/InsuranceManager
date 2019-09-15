using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InsuranceManager
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PoliciesByCustomer",
                url: "{controller}/{action}/{id}/{customerName}",
                defaults: new { controller = "PoliciesByCustomer", action = "Index", id = UrlParameter.Optional, customerName = UrlParameter.Optional }
            );
        }
    }
}
