using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityCourses.Web.ViewModel
{
	public class StudentCourseSessionViewModel
	{
		public int CourseId { get; set; }
		public int StudentId { get; set; }
		public int SessionId { get; set; }
		public string StudentName { get; set; }
		public string SessionName { get; set; }
		public bool Completed { get; set; }
	}
}
