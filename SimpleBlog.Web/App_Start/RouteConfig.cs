using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SimpleBlog.Web.Controllers;

namespace SimpleBlog.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            // add the namespaces to the type of the simpleblog.web.controllers PostsController namespace.
            // solves the conflict of postsController in the admin area and in the normal area
            var namespaces = new[] { typeof(PostsController).Namespace };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new {controller = "Auth", action = "Login", id = UrlParameter.Optional},
                namespaces: namespaces
            );

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Posts", action = "Index" },
                namespaces: namespaces
            );
        }
    }
}