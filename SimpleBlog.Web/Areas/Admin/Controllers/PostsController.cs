using SimpleBlog.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using SimpleBlog.Web.Models;
using SimpleBlog.Web.Areas.Admin.ViewModels;

namespace SimpleBlog.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTab("posts")]
    public class PostsController : Controller
    {
        private const int PostsPerPage = 5; 

        //
        // GET: /Admin/Posts/
        public ActionResult Index(int page = 1)
        {
            var totalPostCount = Database.Session.Query<Post>().Count();

            var currentPostsPage = Database.Session.Query<Post>()
                                .OrderByDescending(c => c.Created)
                                .Skip((page - 1) * PostsPerPage)
                                .Take(PostsPerPage)
                                .ToList();

            return View(new PostsIndex
                {
                    Posts = new PagedData<Post>(currentPostsPage, totalPostCount, page, PostsPerPage)
                });
        }
	}
}