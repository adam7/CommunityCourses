using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommunityCourses.Web.Model;
using CommunityCourses.Web.ViewModel;
using CommunityCourses.Web.Indexes;

namespace CommunityCourses.Web.Controllers
{
	[Authorize]
	public partial class CourseController : Controller
	{
		CourseViewModel ConvertToCourseViewModel(Course course)
		{
			CourseViewModel courseViewModel = new CourseViewModel
			{
				Centre = MvcApplication.CurrentSession.Load<Centre>(course.CentreId),
				CentreId = course.CentreId,
				EndDate = course.EndDate,
				Id = course.Id,
				Name = course.Name,
				StartDate = course.StartDate,
				StudentIds = course.StudentIds,
				Tutor = MvcApplication.CurrentSession.Load<Person>(course.TutorId),
				TutorId = course.TutorId,
				Unit = MvcApplication.CurrentSession.Load<Unit>(course.UnitId),
				UnitId = course.UnitId,				
				VerifierId = course.VerifierId
			};

			if (course.VerifierId != null)
			{
				courseViewModel.Verifier = MvcApplication.CurrentSession.Load<Person>(course.VerifierId);
			}

			courseViewModel.Students = MvcApplication.CurrentSession.Load<Person>(course.StudentIds.ToArray()).ToList();

			return courseViewModel;
		}


		public virtual ActionResult Index()
		{
			// CreateUnits();
			List<CourseViewModel> courseViewModels = new List<CourseViewModel>();

			foreach (Course course in MvcApplication.CurrentSession
				.Query<Course>(new Courses_All().IndexName)
				.Customize(customize => customize.WaitForNonStaleResults()))
			{
				courseViewModels.Add(ConvertToCourseViewModel(course));
			}

			return View(courseViewModels);
		}

		public virtual ActionResult Details(string id)
		{
			Course course = MvcApplication.CurrentSession.Load<Course>(id);
			return PartialView(ConvertToCourseViewModel(course));
		}

		public virtual ActionResult Create()
		{
			PopulateViewData(null);
			return View(Views.Create, new CourseViewModel());
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create(Course course)
		{
			if(ModelState.IsValid)
			{
				MvcApplication.CurrentSession.Store(course);
				MvcApplication.CurrentSession.SaveChanges();
				
				TempData.SetMessage("New course created");
				return RedirectToAction("Index");
			}
			else
			{
				return View(ConvertToCourseViewModel(course));
			}
		}

		public virtual ActionResult Edit(string id)
		{
			PopulateViewData(id);
			Course course = MvcApplication.CurrentSession.Load<Course>(id);
			return View(ConvertToCourseViewModel(course));
		}

		public virtual ActionResult AddStudent(string id, string studentId)
		{
			// Add the student to the course
			Course course = MvcApplication.CurrentSession.Load<Course>(id);
			course.StudentIds.Add(studentId);
			MvcApplication.CurrentSession.Store(course);

			// Add the course sessions/modules to the student
			Person student = MvcApplication.CurrentSession.Load<Person>(studentId);

			Unit unit = MvcApplication.CurrentSession.Load<Unit>(course.UnitId);
			foreach (Session session in unit.Sessions)
			{
				student.CourseSessions.Add(
					new CourseSession
					{
						CourseId = course.Id,
						Complete = false,
						Name = session.Name
					});
			}

			foreach (Module module in unit.Modules)
			{
				student.CourseModules.Add(
					new CourseModule
					{
						CourseId = course.Id,
						Complete = false,
						Name = module.Name
					});
			}

			return RedirectToAction(MVC.Course.Actions.Edit(id));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult UpdateSessionComplete(string courseId, string studentId, string sessionId, bool complete)
		{
			Person student = MvcApplication.CurrentSession.Load<Person>(studentId);
			CourseSession session = student.CourseSessions
				.Where(courseSession => courseSession.CourseId == courseId && courseSession.Name == sessionId)
				.First();

			session.Complete = complete;
			MvcApplication.CurrentSession.Store(session);

			return null;
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult UpdateModuleComplete(string courseId, string studentId, string moduleId, bool complete)
		{
			Person student = MvcApplication.CurrentSession.Load<Person>(studentId);
			CourseModule module = student.CourseModules
				.Where(courseModule => courseModule.CourseId == courseId && courseModule.Name == moduleId)
				.First();

			module.Complete = complete;
			MvcApplication.CurrentSession.Store(module);

			return null;
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Edit(Course course)
		{
			if(ModelState.IsValid)
			{
				MvcApplication.CurrentSession.Store(course);

				TempData.SetMessage("Course updated");
				return RedirectToAction("Index");
			}
			else
			{
				return View(ConvertToCourseViewModel(course));
			}
		}

		void PopulateViewData(string courseId)
		{
			List<Person> people = MvcApplication.CurrentSession.Query<Person>(new People_All().IndexName).ToList();

			ViewData.SetPotentialStudents(
					people.Where(p => p.Roles.Contains(Roles.Student) 
						&& !p.CourseSessions.Any(courseSesion => courseSesion.CourseId == courseId)
						).OrderBy(p => p.Name));
		}

		protected void CreateUnits()
		{
			Unit IntroductionToFacePainting = new Unit
			{
				Name = "1 - Introduction to Face Painting",
				Sessions = new List<Session>
				{
					new Session{ Name = "Session 1" },
					new Session{ Name = "Session 2" },
					new Session{ Name = "Session 3" },
					new Session{ Name = "Session 4" },
					new Session{ Name = "Session 5" },
					new Session{ Name = "Session 6" },
				},
				Modules = new List<Module>
				{
					new Module{ Name = "Health & Safety" },
					new Module{ Name = "Communications" },
					new Module{ Name = "Design" },
					new Module{ Name = "Technique" }
				}
			};
			MvcApplication.CurrentSession.Store(IntroductionToFacePainting);

			Unit IntermediateFacePainting = new Unit
			{
				Name = "2 - Intermediate Face Painting",
				Sessions = new List<Session>
				{
					new Session{ Name = "Session 1" },
					new Session{ Name = "Session 2" },
					new Session{ Name = "Session 3" },
					new Session{ Name = "Session 4" },
					new Session{ Name = "Session 5" },
					new Session{ Name = "Session 6" },
				},
				Modules = new List<Module>
				{
					new Module{ Name = "Health & Safety" },
					new Module{ Name = "Communications" },
					new Module{ Name = "Design" },
					new Module{ Name = "Technique" }
				}
			};
			MvcApplication.CurrentSession.Store(IntermediateFacePainting);

			Unit DesignDevelopment = new Unit
			{
				Name = "3 - Design Development",
				Sessions = new List<Session>
				{
					new Session{ Name = "Session 1" },
					new Session{ Name = "Session 2" },
					new Session{ Name = "Session 3" },
					new Session{ Name = "Session 4" },
					new Session{ Name = "Session 5" },
					new Session{ Name = "Session 6" },
				},
				Modules = new List<Module>
				{
					new Module{ Name = "Health & Safety" },
					new Module{ Name = "Communications" },
					new Module{ Name = "Design" },
					new Module{ Name = "Technique" }
				}
			};
			MvcApplication.CurrentSession.Store(DesignDevelopment);

			Unit FacePaintingAtEventsVolunteerProgramme = new Unit
			{
				Name = "4 - Face Painting at Events Volunteer Programme",
				Sessions = new List<Session>
				{
					new Session{ Name = "Session 1" },
					new Session{ Name = "Session 2" },
					new Session{ Name = "Session 3" },
					new Session{ Name = "Session 4" },
					new Session{ Name = "Session 5" },
					new Session{ Name = "Session 6" },
				},
				Modules = new List<Module>
				{
					new Module{ Name = "Health & Safety" },
					new Module{ Name = "Communications" },
					new Module{ Name = "Design" },
					new Module{ Name = "Technique" }
				}
			};
			MvcApplication.CurrentSession.Store(FacePaintingAtEventsVolunteerProgramme);

			MvcApplication.CurrentSession.SaveChanges();
		}

	}
}
