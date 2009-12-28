using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using StudentTracking.Data;
using StudentTracking.Data.Repository;
using StudentTracking.Data.Model;

namespace StudentTracking.Web.Controllers
{
	[Authorize]
	public partial class CentreController : Controller
	{
		public virtual ActionResult Index()
		{
			return View(new CentreRepository().GetAll());
		}

		public virtual ActionResult Details(int id)
		{
			return View(new CentreRepository().Get(id));
		}

		public virtual ActionResult Create()
		{
			return View(MVC.Centre.Actions.Edit, new Centre());
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create(Centre centre, Address address)
		{
			try
			{
				new CentreRepository().Add(centre, address);
				TempData.SetMessage("New centre created");
				return RedirectToAction(MVC.Centre.Actions.Index);
			}
			catch (ValidationException validationException)
			{
				validationException.CopyToModelState(ModelState, "centre");
				return View();
			}
		}

		public virtual ActionResult Edit(int id)
		{
			return View(new CentreRepository().Get(id));
		}

		//
		// POST: /Centre/Edit/5

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(Centre centre, Address address)
		{
			try
			{
				new CentreRepository().Update(centre);
				return RedirectToAction(MVC.Centre.Actions.Index);
			}
			catch
			{
				return View();
			}
		}
	}
}
