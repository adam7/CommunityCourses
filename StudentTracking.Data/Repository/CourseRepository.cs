using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using StudentTracking.Data.Model;
using StudentTracking.Data.Extensions;
using System.Transactions;
using SubSonic.DataProviders;

namespace StudentTracking.Data.Repository
{
	public class CourseRepository : RepositoryBase<Course>
	{
		public new void Add(Course course)
		{
			// If the course is valid save it and add all the course modules and units to it
			if (course.IsValid())
			{
				using (TransactionScope transactionScope = new TransactionScope())
				{
					using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
					{
						course.Add();
					
						IList<Module> modules = Module.Find(module => module.UnitId == course.UnitId);
						
						foreach(Module module in modules)
						{
							CourseModule courseModule = 
								new CourseModule { CourseId = course.Id, ModuleId = module.Id };
							courseModule.Add();
						}
												
						IList<Session> sessions = Session.Find(session => session.UnitId == course.UnitId);
						
						foreach(Session session in sessions)
						{
							CourseSession courseSession = 
								new CourseSession { CourseId = course.Id, SessionId = session.Id };
							courseSession.Add();
						}
						
						transactionScope.Complete();
					}
				}
			}
			else
			{
				throw new ValidationException(course.GetErrors());
			}
		}

		public void AddStudentToCourse(int studentId, int courseId)
		{
			using (TransactionScope transactionScope = new TransactionScope())
			{
				using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
				{
					IList<CourseModule> courseModules = CourseModule.Find(courseModule => courseModule.CourseId == courseId);

					foreach (CourseModule courseModule in courseModules)
					{
						StudentCourseModule studentCourseModule =
							new StudentCourseModule { CourseModuleId = courseModule.Id, StudentId = studentId };
						studentCourseModule.Add();
					}

					IList<CourseSession> courseSessions = CourseSession.Find(courseSession => courseSession.CourseId == courseId);

					foreach (CourseSession courseSession in courseSessions)
					{
						StudentCourseSession studentCourseSession =
							new StudentCourseSession { CourseSessionId = courseSession.Id, StudentId = studentId };
						studentCourseSession.Add();
					}

					transactionScope.Complete();
				}
			}
		}
	}
}
