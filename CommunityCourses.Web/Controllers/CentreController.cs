using System.Web.Mvc;
using CommunityCourses.Web.Model;

namespace CommunityCourses.Web.Controllers
{
	[Authorize]
	public partial class CentreController : Controller
	{
		public virtual ActionResult Index()
		{
			return View(MvcApplication.CurrentSession.Query<Centre>("AllCentres"));
		}

		public virtual ActionResult Details(string id)
		{
			return PartialView(MvcApplication.CurrentSession.Load<Centre>(id));
		}

		public virtual ActionResult Create()
		{
			return View(Views.Edit, new Centre());
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create(Centre centre)
		{
			if(ModelState.IsValid)
			{
				MvcApplication.CurrentSession.Store(centre);
				TempData.SetMessage("New centre created");
				return RedirectToAction(MVC.Centre.Actions.Index());
			}
			else
			{
				return View(MVC.Centre.Views.Edit, centre);
			}
		}

		[AcceptVerbs(HttpVerbs.Get)]
		public virtual ActionResult Edit(string id)
		{
			return View(MvcApplication.CurrentSession.Load<Centre>(id));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(Centre centre)
		{
			if(ModelState.IsValid)
			{
				MvcApplication.CurrentSession.Store(centre);
				TempData.SetMessage("Centre updated");
				return RedirectToAction(MVC.Centre.Actions.Index());
			}
			else
			{
				return View(centre);
			}
		}
	}
}
