using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentTracking.Web.ViewModel
{
	public class StudentCourseModuleViewModel
	{
		public int CourseId { get; set; }
		public int StudentId { get; set; }
		public int ModuleId { get; set; }
		public string StudentName { get; set; }
		public string ModuleName { get; set; }
		public bool Completed { get; set; }
	}
}
