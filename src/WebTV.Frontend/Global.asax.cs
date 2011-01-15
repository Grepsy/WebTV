using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebTV.Frontend {

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Animation",
                "Animation/{id}",
                new { controller = "Animation", action = "Index" },
                new { id = @"\d+" }
            );

            routes.MapRoute(
                "Static",
                "Static/{pagename}",
                new { controller = "Static", action = "Static", pagename = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "MediaSet", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
           
        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}