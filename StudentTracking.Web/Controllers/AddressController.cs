using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace StudentTracking.Web.Controllers
{
	public partial class AddressController : Controller
	{
		public virtual ActionResult Index()
		{
			return View();
		}
	}
}
