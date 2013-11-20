using SimpleBlog.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleBlog.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var namespaces = new[] { typeof(PostsController).Namespace };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Auth", action = "Index" },
                namespaces: namespaces);

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Posts", action = "Index" },
                namespaces: namespaces);

        }
    }
}
