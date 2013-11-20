﻿using SimpleBlog.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
	}
}