using SimpleBlog.Web.Areas.Admin.ViewModels;
using SimpleBlog.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using SimpleBlog.Web.Models;

namespace SimpleBlog.Web.Areas.Admin.Controllers
{
    [Authorize(Roles="admin")]
    [SelectedTab("users")]
    public class UsersController : Controller
    {
        //
        // GET: /Admin/Users/
        public ActionResult Index()
        {
            var userlist = Database.Session.Query<User>().ToList();

            return View(new UsersIndex {Users = userlist});
        }
	}
}