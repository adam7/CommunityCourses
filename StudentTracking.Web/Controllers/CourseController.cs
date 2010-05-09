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
			List<CourseViewModel> courses = new List<CourseViewModel>();
			foreach (Course course in Course.All())
			{
				courses.Add(Mapper.Map<Course, CourseViewModel>(course));
			}

			return View(courses);
		}

		public virtual ActionResult Details(int id)
		{
			Course course = Course.SingleOrDefault(c => c.Id == id);
			return PartialView(Mapper.Map<Course, CourseViewModel>(course));
		}

		public virtual ActionResult Create()
		{
			PopulateViewData(null);
			return View(Views.Edit, new CourseViewModel());
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
			return RedirectToRoute(new { action = MVC.Course.Actions.Edit(id) });
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult UpdateSessionComplete(int courseId, int studentId, int sessionId, bool complete)
		{
			StudentCourseSession studentCourseSession =
				(from studentCourseSessions in StudentCourseSession.All()
				 join courseSessions in CourseSession.All() on studentCourseSessions.CourseSessionId equals courseSessions.Id
				 where studentCourseSessions.CourseId == courseId
					 && studentCourseSessions.StudentId == studentId
					 && courseSessions.SessionId == sessionId
				 select studentCourseSessions).First<StudentCourseSession>();

			studentCourseSession.Complete = complete;
			studentCourseSession.Update();

			return null;
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult UpdateModuleComplete(int courseId, int studentId, int moduleId, bool complete)
		{
			StudentCourseModule studentCourseModule =
				(from studentCourseModules in StudentCourseModule.All()
				 join courseModules in CourseModule.All() on studentCourseModules.CourseModuleId equals courseModules.Id
				 where studentCourseModules.CourseId == courseId
					 && studentCourseModules.StudentId == studentId
					 && courseModules.ModuleId == moduleId
				 select studentCourseModules).First<StudentCourseModule>();

			studentCourseModule.Complete = complete;
			studentCourseModule.Update();

			return null;
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(CourseViewModel courseViewModel)
		{
			try
			{
				Course course = Course.SingleOrDefault(c => c.Id == courseViewModel.Id);				
				Mapper.Map(courseViewModel, course);
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
