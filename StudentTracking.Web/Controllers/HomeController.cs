﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentTracking.Data.Model;

namespace StudentTracking.Web.Controllers
{
	[HandleError]
	[Authorize]
	public partial class HomeController : Controller
	{
		public virtual ActionResult Index()
		{
			return View();
		}

		public virtual ActionResult About()
		{
			return View();
		}
	}
}
