using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Query;
using SubSonic.Repository;
using System.Reflection;
using StudentTracking.Data.Model;

namespace StudentTracking.Data.Repository
{
	public class StudentRepository : RepositoryBase<Student>
	{
		public IQueryable<Student> GetByCourse(int courseId)
		{
			IQueryable<Student> query = from students in Student.All()
																	join studentCourseSessions in StudentCourseSession.All()
																		on students.Id equals studentCourseSessions.StudentId
																	join courseSessions in CourseSession.All()
																		on studentCourseSessions.CourseSessionId equals courseSessions.Id
																	join courses in Course.All()
																		on courseSessions.CourseId equals courses.Id
																	where courses.Id == courseId
																	select students;

			return query.Distinct();
		}

		public IQueryable<Student> GetByTasterSession(int tasterSessionId)
		{
			return from students in Student.All()
						 join studentTasterSessions in StudentTasterSession.All()
							 on students.Id equals studentTasterSessions.StudentId
						 where studentTasterSessions.Id == tasterSessionId
						 select students;
		}

		public IList<Student> GetPotentialStudentsForCourse(int? courseId)
		{
			if (courseId.HasValue)
			{
				// TODO: This is horrible, should be able to convert it into a nice simple query
				// but can't at the moment. Once SubSonic linq implementation improves should be ok
				IList<Student> studentsOnCourse = GetByCourse(courseId.Value).ToList();

				return Student.All().ToList().Except(studentsOnCourse).ToList();				
			}
			else
			{
				IQueryable<Student> query = from students in Student.All()
							 select students;

				return query.ToList();
			}
		}

		public IList<Student> GetPotentialStudentsForTasterSession(int? tasterSessionId)
		{
			if (tasterSessionId.HasValue)
			{
				// TODO: This is horrible, should be able to convert it into a nice simple query
				// but can't at the moment. Once SubSonic linq implementation improves should be ok
				IList<Student> studentsOnTasterSession = GetByTasterSession(tasterSessionId.Value).ToList();

				return Student.All().ToList().Except(studentsOnTasterSession).ToList();
			}
			else
			{
				IQueryable<Student> query = from students in Student.All()
																		select students;

				return query.ToList();
			}
		}
	}
}
