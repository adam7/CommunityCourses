using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using StudentTracking.Data.Repository;
using StudentTracking.Data;
using StudentTracking.Data.Model;

namespace StudentTracking.Web.Controllers
{
	[Authorize]
	public partial class TasterSessionController : Controller
	{
		#region Methods (7) 

		// Public Methods (6) 
		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult AddStudent(int id, int studentId)
		{
			TasterSessionRepository repo = new TasterSessionRepository();
			repo.AddStudentToTasterSession(studentId, id);

			return RedirectToRoute(new { action = MVC.TasterSession.Actions.Edit, id = id });
		}

		public virtual ActionResult Create()
		{
			PopulateViewData(null);
			return View(MVC.TasterSession.Actions.Edit, new TasterSession());
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create(TasterSession tasterSession)
		{
			try
			{
				new TasterSessionRepository().Add(tasterSession);
				return RedirectToAction(MVC.TasterSession.Actions.Index);
			}
			catch (ValidationException validationException)
			{
				validationException.CopyToModelState(ModelState, "tasterSession");
				return View();
			}
		}

		public virtual ActionResult Edit(int id)
		{
			PopulateViewData(id);
			return View(new TasterSessionRepository().Get(id));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(TasterSession tasterSession)
		{
			try
			{
				new TasterSessionRepository().Update(tasterSession);
				return RedirectToAction(MVC.TasterSession.Actions.Index);
			}
			catch (ValidationException validationException)
			{
				validationException.CopyToModelState(ModelState, "tasterSession");
				return View();
			}
		}

		public virtual ActionResult Index()
		{
			return View(new TasterSessionRepository().GetAll());
		}
		// Private Methods (1) 

		void PopulateViewData(int? courseId)
		{
			ViewData.SetCentres(new CentreRepository().GetAll());
			ViewData.SetTutors(new TutorRepository().GetAll());
			ViewData.SetPotentialStudents(new StudentRepository().GetPotentialStudentsForTasterSession(courseId).ToList());
		}

		#endregion Methods 
	}
}
