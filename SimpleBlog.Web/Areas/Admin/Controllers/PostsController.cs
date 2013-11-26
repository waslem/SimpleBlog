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

        public ActionResult New()
        {
            return View("Form", new PostsForm
            {
                IsNew = true,
                Tags = Database.Session.Query<Tag>().Select(t => new TagCheckBox
                {
                    Id = t.Id, 
                    Name = t.Name, 
                    IsChecked = false
                }).ToList()
            });
        }

        public ActionResult Edit(int id)
        {
            //var post = Database.Session.Query<Post>().FirstOrDefault(p => p.Id == id);
            var post = Database.Session.Load<Post>(id);

            if (post == null)
                return HttpNotFound();

            return View("Form", new PostsForm
            {
                IsNew = false,
                PostId = post.Id,
                Content = post.Content, 
                Slug = post.Slug,
                Title = post.Title, Tags = Database.Session.Query<Tag>().Select(t => new TagCheckBox 
                {
                    Id = t.Id, 
                    Name = t.Name, 
                    IsChecked = post.Tags.Contains(t)
                }).ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(PostsForm form)
        {
            form.IsNew = form.PostId == null;
            
            if (!ModelState.IsValid)
                return View(form);

            Post post;
            if (form.IsNew)
            {
                post = new Post
                {
                    Created = DateTime.Now,
                    User = Auth.User
                };
            }
            else
            {
                post = Database.Session.Load<Post>(form.PostId);
                if (post == null)
                    return HttpNotFound();

                post.Updated = DateTime.Now;
            }

            post.Title = form.Title;
            post.Slug = form.Slug;
            post.Content = form.Content;

            Database.Session.SaveOrUpdate(post);

            return Redirect("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Trash(int id)
        {
            var post = Database.Session.Load<Post>(id);
            if (post == null)
                return HttpNotFound();

            post.Deleted = DateTime.Now;
            Database.Session.Update(post);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var post = Database.Session.Load<Post>(id);
            if (post == null)
                return HttpNotFound();

            Database.Session.Delete(post);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Restore(int id)
        {
            var post = Database.Session.Load<Post>(id);
            if (post == null)
                return HttpNotFound();

            post.Deleted = null;
            Database.Session.Update(post);

            return RedirectToAction("Index");
        }
	}
}