using System.Linq;
using System.Web.Mvc;
using StudentTracking.Data;
using StudentTracking.Data.Model;
using System;
using StudentTracking.Web.ViewModel;
using AutoMapper;
using System.Transactions;
using SubSonic.DataProviders;
using System.Collections.Generic;

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
			return View(MVC.Course.Actions.Edit, new CourseViewModel());
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create(CourseViewModel courseViewModel)
		{
			try
			{
				Course course = Mapper.Map<CourseViewModel, Course>(courseViewModel);
				using (TransactionScope transactionScope = new TransactionScope())
				{
					using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
					{
						course.Add();

						// Add all the CourseModules for the selected Unit
						IList<Module> modules = Module.Find(module => module.UnitId == course.UnitId);
						foreach (Module module in modules)
						{
							CourseModule courseModule =
								new CourseModule { CourseId = course.Id, ModuleId = module.Id };
							courseModule.Add();
						}

						// Add all the CourseSessions for the selected Unit
						IList<Session> sessions = StudentTracking.Data.Model.Session.Find(session => session.UnitId == course.UnitId);
						foreach (Session session in sessions)
						{
							CourseSession courseSession =
								new CourseSession { CourseId = course.Id, SessionId = session.Id };
							courseSession.Add();
						}

						transactionScope.Complete();
					}
				}
				TempData.SetMessage("New course created");
				return RedirectToAction("Index");
			}
			catch (ValidationException validationException)
			{
				validationException.CopyToModelState(ModelState, "course");
				return View();
			}
		}

		public virtual ActionResult Edit(int id)
		{
			PopulateViewData(id);
			return View(Mapper.Map<Course, CourseViewModel>(Course.SingleOrDefault(course => course.Id == id)));
		}

		public virtual ActionResult AddStudent(int id, int studentId)
		{
			Course.AddStudentToCourse(studentId, id);

			PopulateViewData(id);
			return RedirectToRoute(new { action = MVC.Course.Actions.Edit, id = id });
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult UpdateSessionComplete(int courseId, int studentId, int courseSessionId, bool complete)
		{
			StudentCourseSession studentCourseSession = StudentCourseSession.SingleOrDefault(session =>
				session.CourseId == courseId
				&& session.StudentId == studentId
				&& session.CourseSessionId == courseSessionId);
			studentCourseSession.Complete = complete;
			studentCourseSession.Update();

			return null;
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult UpdateModuleComplete(int courseId, int studentId, int courseModuleId, bool complete)
		{
			StudentCourseModule studentCourseModule = StudentCourseModule.SingleOrDefault(module =>
				module.CourseId == courseId
				&& module.StudentId == studentId
				&& module.CourseModuleId == courseModuleId);
			studentCourseModule.Complete = complete;
			studentCourseModule.Update();

			return null;
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(CourseViewModel courseViewModel)
		{
			try
			{
				Course course = Mapper.Map<CourseViewModel, Course>(courseViewModel);
				course.Update();

				TempData.SetMessage("Course updated");
				return RedirectToAction("Index");
			}
			catch (ValidationException validationException)
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
