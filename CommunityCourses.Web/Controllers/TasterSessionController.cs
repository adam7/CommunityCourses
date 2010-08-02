using System.Linq;
using System.Web.Mvc;
using CommunityCourses.Web.Model;
using CommunityCourses.Web.Indexes;

namespace CommunityCourses.Web.Controllers
{
	[Authorize]
	public partial class TasterSessionController : Controller
	{
		#region Methods (7) 

		// Public Methods (6) 
		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult AddStudent(string id, string studentId)
		{
			TasterSession tasterSession = MvcApplication.CurrentSession.Load<TasterSession>(id);
			tasterSession.Students.Add(MvcApplication.CurrentSession.Load<Person>(studentId));
			MvcApplication.CurrentSession.Store(tasterSession);

			return RedirectToRoute(new { action = MVC.TasterSession.Actions.Edit(id) });
		}

		public virtual ActionResult Create()
		{
			PopulateViewData(null);
			return View(Views.Edit, new TasterSession());
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create(TasterSession tasterSession)
		{
			if(ModelState.IsValid)
			{
				tasterSession.Centre = MvcApplication.CurrentSession.Load<Centre>(tasterSession.CentreId);
				tasterSession.Tutor = MvcApplication.CurrentSession.Load<Person>(tasterSession.TutorId);
				MvcApplication.CurrentSession.Store(tasterSession);
				return RedirectToAction(MVC.TasterSession.Actions.Index());
			}
			else
			{
				return View(MVC.TasterSession.Views.Edit, tasterSession);
			}
		}

		public virtual ActionResult Details(string id)
		{
			return PartialView(MvcApplication.CurrentSession.Load<TasterSession>(id));
		}

		public virtual ActionResult Edit(string id)
		{
			PopulateViewData(id);
			return View(MvcApplication.CurrentSession.Load<TasterSession>(id));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(TasterSession tasterSession)
		{
			if(ModelState.IsValid)
			{
				tasterSession.Centre = MvcApplication.CurrentSession.Load<Centre>(tasterSession.CentreId);
				tasterSession.Tutor = MvcApplication.CurrentSession.Load<Person>(tasterSession.TutorId);
				MvcApplication.CurrentSession.Store(tasterSession);
				TempData.SetMessage("Taster session updated");
				return RedirectToAction(MVC.TasterSession.Actions.Index());
			}
			else
			{
				return View(tasterSession);
			}
		}

		public virtual ActionResult Index()
		{
			return View(MvcApplication.CurrentSession.Query<TasterSession>(new TasterSessions_All().IndexName));
		}
		// Private Methods (1) 

		void PopulateViewData(string tasterSessionId)
		{
			ViewData.SetPotentialStudents(MvcApplication.CurrentSession.Query<Person>(new People_All().IndexName).ToList());
		}

		#endregion Methods 
	}
}
