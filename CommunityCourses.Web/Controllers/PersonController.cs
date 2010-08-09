using System.Linq;
using System.Web.Mvc;
using CommunityCourses.Web.Model;
using CommunityCourses.Web.Indexes;
using Raven.Client;
using Raven.Database.Extensions;

namespace CommunityCourses.Web.Controllers
{
	[Authorize]
	public partial class PersonController : Controller
	{
		const int pageSize = 20;

		//public virtual ActionResult Index(int? page)
		//{
		//  return View(MvcApplication.CurrentSession.Query<Person>(new People_All().IndexName)
		//    .Skip(page ?? 0 * pageSize).Take(pageSize));
		//}

		public virtual ActionResult Index()
		{
			return View(MvcApplication.CurrentSession
				.Query<Person>(new People_All().IndexName)
				.Customize(customize => customize.WaitForNonStaleResults()));
		}

		//
		// GET: /Student/Details/5

		public virtual ActionResult Details(string id)
		{
			return PartialView(MvcApplication.CurrentSession.Load<Person>(id));
		}

		//
		// GET: /Student/Create

		public virtual ActionResult Create()
		{
			return View(Views.Edit, new Person());
		}

		//
		// POST: /Student/Create

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create(Person person)
		{
			if(ModelState.IsValid)
			{
				MvcApplication.CurrentSession.Store(person);
				TempData.SetMessage("Student created");
				return RedirectToAction(MVC.Person.Actions.Index());
			}
			else
			{
				return View(MVC.Person.Views.Edit, person);
			}
		}

		//
		// GET: /Student/Edit/5
		[AcceptVerbs(HttpVerbs.Get)]
		public virtual ActionResult Edit(string id)
		{
			return View(MvcApplication.CurrentSession.Load<Person>(id));
		}

		//
		// POST: /Student/Edit/5
		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(Person person)
		{
			if(ModelState.IsValid)
			{
				MvcApplication.CurrentSession.Store(person);

				TempData.SetMessage("Student updated");
				return RedirectToAction(MVC.Person.Actions.Index());
			}
			else
			{
				return View(MVC.Person.Views.Edit, person);
			}
		}
	}
}
