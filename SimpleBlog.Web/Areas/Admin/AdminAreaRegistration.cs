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
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            var namespaces = new[] { typeof(PostsController).Namespace };

            context.MapRoute(
                name: "Admin_default",
                url: "admin/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: namespaces
            );
        }
    }
}
