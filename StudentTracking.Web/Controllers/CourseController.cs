using System.Linq;
using System.Web.Mvc;
using StudentTracking.Data;
using StudentTracking.Data.Model;
using System;

namespace StudentTracking.Web.Controllers
{
	[Authorize]
  public partial class CourseController : Controller
  {
    public virtual ActionResult Index()
    {
      return View(Course.All());
    }

    public virtual ActionResult Details(int id)
    {
      return View(Course.SingleOrDefault(course => course.Id == id));
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
				course.Add();
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
			return View(Course.SingleOrDefault(course => course.Id == id));
    }

		public virtual ActionResult AddStudent(int id, int studentId)
		{
			Course.AddStudentToCourse(studentId, id);

			PopulateViewData(id);
			return RedirectToRoute(new { action =	 MVC.Course.Actions.Edit, id = id });
		}

    [AcceptVerbs(HttpVerbs.Post)]
    public virtual ActionResult Edit(FormCollection form)
    {
      try
      {
				Course course = Course.SingleOrDefault(c => c.Id == Convert.ToInt32(form["Id"]));
				UpdateModel(course);
				course.Update();
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
      ViewData.SetCentres(Centre.All().ToList());
			ViewData.SetTutors(Tutor.All().ToList());
			ViewData.SetUnits(Unit.All().ToList());
      ViewData.SetVerifiers(Verifier.All().ToList());
			ViewData.SetPotentialStudents(Student.GetPotentialStudentsForCourse(courseId).ToList());
    }
  }
}
