﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using CommunityCourses.Data.Extensions;
using SubSonic.DataProviders;
using CommunityCourses.Data.Enum;

namespace CommunityCourses.Data.Model
{
	public partial class Course
	{
		public IEnumerable<Student> Students
		{
			get
			{
				return Student.GetByCourse(Id);
			}
		}
		public void Add(Course course)
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

						foreach (Module module in modules)
						{
							CourseModule courseModule =
								new CourseModule { CourseId = course.Id, ModuleId = module.Id };
							courseModule.Add();
						}

						IList<Session> sessions = Session.Find(session => session.UnitId == course.UnitId);

						foreach (Session session in sessions)
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
		
		// TODO: This should become AddStudent(Student student);
		public static void AddStudentToCourse(int studentId, int courseId)
		{
			using (TransactionScope transactionScope = new TransactionScope())
			{
				using (SharedDbConnectionScope connectionScope = new SharedDbConnectionScope())
				{
					IList<CourseModule> courseModules = CourseModule.Find(courseModule => courseModule.CourseId == courseId);

					foreach (CourseModule courseModule in courseModules)
					{
						StudentCourseModule studentCourseModule =
							new StudentCourseModule { CourseModuleId = courseModule.Id, StudentId = studentId, CourseId = courseId };
						studentCourseModule.Add();
					}

					IList<CourseSession> courseSessions = CourseSession.Find(courseSession => courseSession.CourseId == courseId);

					foreach (CourseSession courseSession in courseSessions)
					{
						StudentCourseSession studentCourseSession =
							new StudentCourseSession { CourseSessionId = courseSession.Id, StudentId = studentId, CourseId = courseId };
						studentCourseSession.Add();
					}

					transactionScope.Complete();
				}
			}
		}
	}
}