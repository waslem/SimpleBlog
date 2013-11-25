using SimpleBlog.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NHibernate.Linq;
using SimpleBlog.Web.Models;

namespace SimpleBlog.Web.Controllers
{
    public class AuthController : Controller
    {
        //
        // GET: /Auth/login
        public ActionResult Login()
        {
            return View(new AuthLogin());
        }

        // 
        // POST: /Auth/login
        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            var user = Database.Session.Query<User>().FirstOrDefault(u => u.Username == form.UserName);

            // we do this to prevent timing attacks, we run a fake hash function to simulate a real password check 
            // this makes the time for a login attempt with an unknown username in the database take the same amount of time as one
            // which exists in the database.
            if (user == null)
            {
                SimpleBlog.Web.Models.User.FakeHash();
            }

            if (!user.CheckPassword(form.Password))
            {
                ModelState.AddModelError("Username", "Username or password is incorrect");
            }

            if (!ModelState.IsValid)
            {
                return View(form);
            }

            FormsAuthentication.SetAuthCookie(user.Username, true);

            if (!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);

            return RedirectToRoute("home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }
	}
}