using System.Linq;
using System.Web.Mvc;
using CommunityCourses.Web.Model;
using CommunityCourses.Web.Indexes;

namespace CommunityCourses.Web.Controllers
{
	[Authorize]
	public partial class TasterSessionController : Controller
	{
		const int pageSize = 20;

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
			if (ModelState.IsValid)
			{
				tasterSession.CentreName = MvcApplication.CurrentSession.Load<Centre>(tasterSession.CentreId).Name;
				tasterSession.TutorName = MvcApplication.CurrentSession.Load<Person>(tasterSession.TutorId).Name;
				MvcApplication.CurrentSession.Store(tasterSession);
				TempData.SetMessage(string.Format("Taster session {0} created", tasterSession.Name));
				return RedirectToAction(MVC.TasterSession.Actions.Index(1));
			}
			else
			{
				return View(tasterSession);
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
				tasterSession.CentreName = MvcApplication.CurrentSession.Load<Centre>(tasterSession.CentreId).Name;
				tasterSession.TutorName = MvcApplication.CurrentSession.Load<Person>(tasterSession.TutorId).Name;
				MvcApplication.CurrentSession.Store(tasterSession);
				TempData.SetMessage(string.Format("Taster session {0} updated", tasterSession.Name));
				return RedirectToAction(MVC.TasterSession.Actions.Index(1));
			}
			else
			{
				return View(tasterSession);
			}
		}

		public virtual ActionResult Index(int page)
		{
			var query = MvcApplication.CurrentSession
				.Query<TasterSession, TasterSessions_All>()
				.Customize(customize => customize.WaitForNonStaleResults())
				.OrderBy(tasterSession => tasterSession.Name);
			
			ViewData.SetPageNumber(page);
			ViewData.SetTotalPages(query, pageSize);

			return View(query.Skip((page-1) * pageSize).Take(pageSize));
		}

		void PopulateViewData(string tasterSessionId)
		{
			ViewData.SetPotentialStudents(MvcApplication.CurrentSession.Query<Person>(new People_All().IndexName).ToList());
		}
	}
}
