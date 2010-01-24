using System.Web.Mvc;

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
