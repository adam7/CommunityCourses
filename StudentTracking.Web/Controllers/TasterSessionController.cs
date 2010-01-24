using System.Linq;
using System.Web.Mvc;
using StudentTracking.Data;
using StudentTracking.Data.Model;
using System;

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
			TasterSession.AddStudentToTasterSession(studentId, id);

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
				tasterSession.Add();
				return RedirectToAction(MVC.TasterSession.Actions.Index);
			}
			catch (ValidationException validationException)
			{
				validationException.CopyToModelState(ModelState, "tasterSession");
				return View();
			}
		}

		public virtual ActionResult Details(int id)
		{
			return View(TasterSession.SingleOrDefault(tasterSession => tasterSession.Id == id));
		}

		public virtual ActionResult Edit(int id)
		{
			PopulateViewData(id);
			return View(TasterSession.SingleOrDefault(tasterSession => tasterSession.Id == id));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(FormCollection form)
		{
			try
			{
				TasterSession tasterSession = TasterSession.SingleOrDefault(t => t.Id == Convert.ToInt32(form["Id"]));
				UpdateModel(tasterSession);
				tasterSession.Update();
				TempData.SetMessage("Taster session updated");
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
			return View(TasterSession.All());
		}
		// Private Methods (1) 

		void PopulateViewData(int? tasterSessionId)
		{
			ViewData.SetCentres(Centre.All().ToList());
			ViewData.SetTutors(Tutor.All().ToList());
			ViewData.SetPotentialStudents(Student.GetPotentialStudentsForTasterSession(tasterSessionId).ToList());
		}

		#endregion Methods 
	}
}
