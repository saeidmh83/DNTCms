using System.Web.Mvc;
using System.Web.Routing;

namespace DNTCms.Web
{
    public static class RoutingConfig
    {
        #region RegisterRoutes
        public static void RegisterRoutes(RouteCollection routes)
        {
            IgnoreRoutes(routes);

            // Improve SEO by stopping duplicate URL's due to case differences or trailing slashes.
            // See http://googlewebmastercentral.blogspot.co.uk/2010/04/to-slash-or-not-to-slash.html
            //routes.AppendTrailingSlash = true;
            routes.LowercaseUrls = true;

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults:
                    new
                    {
                        controller = MVC.Home.Name,
                        action = MVC.Home.ActionNames.Index,
                        id = UrlParameter.Optional
                    },
                namespaces: new[] { $"{typeof(RoutingConfig).Namespace}.Controllers" }
                );
        }

        #endregion

        #region IgnoreRoutes
        private static void IgnoreRoutes(RouteCollection routes)
        {
            // for redirect static files request to controller
            //routes.IgnoreRoute("favicon.ico");
            //routes.IgnoreRoute("{resource}.ico");
            //routes.IgnoreRoute("{resource}.png");
            //routes.IgnoreRoute("{resource}.jpg");
            //routes.IgnoreRoute("{resource}.gif");
            //routes.IgnoreRoute("{resource}.txt");
            //routes.RouteExistingFiles = true;


            // Ignore .axd files.
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Ignore everything in the Content folder.
            routes.IgnoreRoute("Content/{*pathInfo}");
            // Ignore everything in the Scripts folder.
            routes.IgnoreRoute("Scripts/{*pathInfo}");
            // Ignore the Forbidden.html file.
            routes.IgnoreRoute("Error/Forbidden.html");
            // Ignore the GatewayTimeout.html file.
            routes.IgnoreRoute("Error/GatewayTimeout.html");
            // Ignore the ServiceUnavailable.html file.
            routes.IgnoreRoute("Error/ServiceUnavailable.html");
            // Ignore the humans.txt file.
            routes.IgnoreRoute("humans.txt");

        }
        #endregion
    }
}
