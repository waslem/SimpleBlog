using SimpleBlog.Web.Areas.Admin.Controllers;
using System.Web.Mvc;

namespace SimpleBlog.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            var namespaces = new[] { typeof(PostsController).Namespace};

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces
            );
        }
    }
}