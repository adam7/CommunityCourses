using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using StudentTracking.Data;
using StudentTracking.Data.Repository;
using SubSonic.Query;
using SubSonic.DataProviders;
using StudentTracking.Data.Model;

namespace StudentTracking.Web.Controllers
{
	[Authorize]
  public partial class CourseController : Controller
  {
    public virtual ActionResult Index()
    {
      return View(new CourseRepository().GetAll());
    }

    public virtual ActionResult Details(int id)
    {
      return View(new CourseRepository().Get(id));
    }

    public virtual ActionResult Create()
    {
      PopulateViewData(null);
      return View(MVC.Course.Actions.Edit, new Course());
    }

    [AcceptVerbs(HttpVerbs.Post)]
    public virtual ActionResult Create(Course course)
    {
      try
      {
        new CourseRepository().Add(course);
        TempData.SetMessage("New course created");
        return RedirectToAction("Index");
      }
      catch(ValidationException validationException)
      {
        validationException.CopyToModelState(ModelState, "course");
        return View();
      }
    }

    public virtual ActionResult Edit(int id)
    {
      PopulateViewData(id);
      return View(new CourseRepository().Get(id));
    }

		public virtual ActionResult AddStudent(int id, int studentId)
		{
			CourseRepository repo = new CourseRepository();
			repo.AddStudentToCourse(studentId, id);

			PopulateViewData(id);
			return RedirectToRoute(new { action =	 MVC.Course.Actions.Edit, id = id });
		}

    [AcceptVerbs(HttpVerbs.Post)]
    public virtual ActionResult Edit(Course course)
    {
      try
      {
				new CourseRepository().Update(course);
        TempData.SetMessage("Course updated");
        return RedirectToAction("Index");
      }
      catch(ValidationException validationException)
      {
        validationException.CopyToModelState(ModelState, "course");
        return View();
      }
    }

    void PopulateViewData(int? courseId)
    {
      ViewData.SetCentres(new CentreRepository().GetAll());
      ViewData.SetTutors(new TutorRepository().GetAll());
      ViewData.SetUnits(new UnitRepository().GetAll());
      ViewData.SetVerifiers(new VerifierRepository().GetAll());
			ViewData.SetPotentialStudents(new StudentRepository().GetPotentialStudentsForCourse(courseId).ToList());
    }
  }
}
