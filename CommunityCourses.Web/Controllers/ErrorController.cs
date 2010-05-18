using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommunityCourses.Web.Controllers
{
	public partial class ErrorController : Controller
	{
		public virtual ActionResult Index()
		{
			return View();
		}
	}
}
