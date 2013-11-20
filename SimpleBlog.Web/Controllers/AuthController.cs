using SimpleBlog.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            FormsAuthentication.SetAuthCookie(form.UserName, true);

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